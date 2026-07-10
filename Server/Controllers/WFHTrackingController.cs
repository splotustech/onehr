using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMART_HRMS_SYSTEM.Shared;
using SMART_HRMS_SYSTEM.Shared.Models;
using SMART_HRMS_SYSTEM.Shared.ViewModel;
using System.Text;
using System.Text.Json;
using WebPush;

namespace SMART_HRMS_SYSTEM.Server.Controllers;

[Route("api/wfh")]
[ApiController]
public class WFHTrackingController : ControllerBase
{
    private readonly LotusTechCrmliveContext _context;
    private readonly ILogger<WFHTrackingController> _logger;

    // VAPID keys (same as NotificationsController)
    private const string VapidSubject = "mailto:yuvaraj.lotustech@gmail.com";
    private const string VapidPublicKey = "BPdHp1GBJ5-_apY5jYru_kiZuBja89HxGcZCsLFa06nsT1zaeGkrtz1EpXI1WM7ijcQ8So5DqNXTKH8wEUmcGJM";
    private const string VapidPrivateKey = "q_5BI5ysQ0htTvREN-TswnqYLMovVjaGZ1sSWZXK184";

    public WFHTrackingController(LotusTechCrmliveContext context, ILogger<WFHTrackingController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // ────────────────────────────────────────────────────────────────────────
    // POST /api/wfh/startTracking
    // Called after WFH punch-in.  Creates a tracking session.
    // ────────────────────────────────────────────────────────────────────────
    [HttpPost("startTracking")]
    public async Task<IActionResult> StartTracking([FromBody] WFHStartTrackingRequest req)
    {
        try
        {
            var today = DateTime.Today;

            // 1. Get today's WFH attendance record (punch-in lat/long = assigned location)
            var attendance = await _context.AttendanceLogs
                .Where(a => a.EmployeeId == req.EmployeeId
                         && a.Date == today
                         && a.WorkMode == "Work From Home"
                         && a.PunchOutTime == null)
                .OrderByDescending(a => a.Id)
                .FirstOrDefaultAsync();

            if (attendance == null)
                return BadRequest(new { success = false, message = "No active WFH punch-in found for today." });

            // 2. Office setting for allowed radius (WFH radius)
            var office = await _context.OfficeSettings.FirstOrDefaultAsync();
            double allowedRadius = office?.WfhallowedRadiusInMeters > 0
                ? office.WfhallowedRadiusInMeters.Value
                : 100;

            // 3. Check if a tracking session already exists today
            var existing = await _context.TblWFHTrackings
                .FirstOrDefaultAsync(t => t.EmployeeId == req.EmployeeId && t.TrackingDate == today);

            int trackingId;
            if (existing != null)
            {
                // Resume — update device info
                existing.TrackingEndTime = null;
                existing.DeviceName = req.DeviceName;
                existing.Browser = req.Browser;
                existing.IpAddress = req.IpAddress;
                existing.UpdatedOn = DateTime.Now;
                trackingId = existing.Id;
            }
            else
            {
                var session = new TblWFHTracking
                {
                    AttendanceId = attendance.Id,
                    EmployeeId = req.EmployeeId,
                    TrackingDate = today,
                    AssignedLat = attendance.PunchInLat,
                    AssignedLong = attendance.PunchInLong,
                    AllowedRadius = allowedRadius,
                    TrackingStartTime = DateTime.Now,
                    CurrentStatus = "Inside",
                    DeviceName = req.DeviceName,
                    Browser = req.Browser,
                    IpAddress = req.IpAddress,
                    CreatedOn = DateTime.Now
                };
                _context.TblWFHTrackings.Add(session);
                await _context.SaveChangesAsync();
                trackingId = session.Id;
            }

            // 4. Upsert current status
            await UpsertCurrentStatus(req.EmployeeId, attendance.Id, trackingId, today, "Inside",
                null, null, null, null, req.DeviceName, req.Browser, req.IpAddress);

            await _context.SaveChangesAsync();
            _logger.LogInformation("WFH tracking started for Employee {EmpId}, TrackingId {TId}", req.EmployeeId, trackingId);

            return Ok(new WFHStartTrackingResponse
            {
                Success = true,
                TrackingId = trackingId,
                AttendanceId = attendance.Id,
                AssignedLat = attendance.PunchInLat,
                AssignedLong = attendance.PunchInLong,
                AllowedRadius = allowedRadius,
                Message = "Tracking started successfully."
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error starting WFH tracking for Employee {EmpId}", req.EmployeeId);
            return StatusCode(500, new { success = false, message = ex.Message });
        }
    }

    // ────────────────────────────────────────────────────────────────────────
    // POST /api/wfh/locationPing
    // Called every 20 seconds from wfhTracking.js
    // ────────────────────────────────────────────────────────────────────────
    [HttpPost("locationPing")]
    public async Task<IActionResult> LocationPing([FromBody] WFHLocationPingRequest req)
    {
        try
        {
            var today = DateTime.Today;

            // 1. Get active tracking session
            var session = await _context.TblWFHTrackings
                .FirstOrDefaultAsync(t => t.EmployeeId == req.EmployeeId
                                       && t.TrackingDate == today
                                       && t.TrackingEndTime == null);

            if (session == null)
                return Ok(new WFHLocationPingResponse { Success = false, Message = "No active tracking session." });

            // 2. Calculate distance from assigned WFH location
            //    Always read AllowedRadius live from OfficeSetting so admin changes take effect immediately.
            var office = await _context.OfficeSettings.FirstOrDefaultAsync();
            double allowedRadius = office?.WfhallowedRadiusInMeters > 0
                ? office.WfhallowedRadiusInMeters.Value
                : session.AllowedRadius;   // fallback to session value if setting missing

            // Keep session in sync with the current setting
            if (Math.Abs(session.AllowedRadius - allowedRadius) > 0.01)
            {
                session.AllowedRadius = allowedRadius;
            }

            double distance = CalcDistance(session.AssignedLat, session.AssignedLong, req.Latitude, req.Longitude);
            bool isInside = distance <= allowedRadius;

            // 3. Save this GPS ping
            var ping = new TblWFHGPSPing
            {
                TrackingId = session.Id,
                EmployeeId = req.EmployeeId,
                AttendanceId = session.AttendanceId,
                PingTime = DateTime.Now,
                Latitude = req.Latitude,
                Longitude = req.Longitude,
                Distance = Math.Round(distance, 2),
                IsInsideRadius = isInside,
                CreatedOn = DateTime.Now
            };
            _context.TblWFHGPSPings.Add(ping);
            await _context.SaveChangesAsync();

            // 4. Get last 2 pings to apply consecutive-reading logic
            var lastTwo = await _context.TblWFHGPSPings
                .Where(p => p.EmployeeId == req.EmployeeId && p.AttendanceId == session.AttendanceId)
                .OrderByDescending(p => p.PingTime)
                .Take(2)
                .ToListAsync();

            bool bothOutside = lastTwo.Count == 2 && lastTwo.All(p => !p.IsInsideRadius);
            bool bothInside = lastTwo.Count == 2 && lastTwo.All(p => p.IsInsideRadius);

            // 5. Get current employee status
            var statusRec = await _context.TblWFHCurrentStatuses
                .FirstOrDefaultAsync(s => s.EmployeeId == req.EmployeeId);

            string currentStatus = statusRec?.CurrentStatus ?? "Inside";
            string? eventTriggered = null;

            // 6. Auto-Out detection
            if (bothOutside && currentStatus != "Outside")
            {
                eventTriggered = "AutoOut";
                var evtOut = new TblWFHTrackingEvent
                {
                    TrackingId = session.Id,
                    AttendanceId = session.AttendanceId,
                    EmployeeId = req.EmployeeId,
                    EventType = "AutoOut",
                    EventTime = DateTime.Now,
                    Latitude = req.Latitude,
                    Longitude = req.Longitude,
                    Distance = Math.Round(distance, 2),
                    Address = $"{req.Latitude:F6}, {req.Longitude:F6}",
                    DeviceName = req.DeviceName ?? statusRec?.DeviceName,
                    Browser = req.Browser ?? statusRec?.Browser,
                    IpAddress = req.IpAddress ?? statusRec?.IpAddress,
                    Reason = $"Employee moved {Math.Round(distance)}m from assigned WFH location",
                    CreatedOn = DateTime.Now
                };
                _context.TblWFHTrackingEvents.Add(evtOut);
                await _context.SaveChangesAsync();

                session.TotalAutoOutCount++;
                currentStatus = "Outside";

                await UpsertCurrentStatus(req.EmployeeId, session.AttendanceId, session.Id, today,
                    "Outside", req.Latitude, req.Longitude, Math.Round(distance, 2),
                    $"{req.Latitude:F6},{req.Longitude:F6}",
                    req.DeviceName, req.Browser, req.IpAddress, outsideSince: DateTime.Now);

                // Notify HR and Admin
                var employee = await _context.TblEmplyeeInfos
                    .Include(e => e.Department)
                    .FirstOrDefaultAsync(e => e.Id == req.EmployeeId);

                string empName = employee?.Name ?? "Unknown";
                string notifTitle = "WFH Location Alert";
                string notifBody = $"{empName} left the assigned WFH location.\n" +
                                    $"Time: {DateTime.Now:hh:mm tt}\n" +
                                    $"Distance: {Math.Round(distance)}m\n" +
                                    $"Location: {req.Latitude:F6}, {req.Longitude:F6}";

                await SendHRPushNotification(notifTitle, notifBody, "/wfh-monitoring");
                await LogNotification(req.EmployeeId, session.AttendanceId, evtOut.Id, "AutoOut", notifTitle, notifBody, "HR");
            }
            // 7. Auto-Return detection
            else if (bothInside && currentStatus == "Outside")
            {
                eventTriggered = "AutoReturn";
                var statusRec2 = await _context.TblWFHCurrentStatuses
                    .FirstOrDefaultAsync(s => s.EmployeeId == req.EmployeeId);

                int outsideMinutes = statusRec2?.OutsideSince != null
                    ? (int)(DateTime.Now - statusRec2.OutsideSince.Value).TotalMinutes
                    : 0;

                // Update AutoOut event with return info
                var lastAutoOut = await _context.TblWFHTrackingEvents
                    .Where(e => e.EmployeeId == req.EmployeeId
                             && e.AttendanceId == session.AttendanceId
                             && e.EventType == "AutoOut"
                             && e.ReturnTime == null)
                    .OrderByDescending(e => e.EventTime)
                    .FirstOrDefaultAsync();

                if (lastAutoOut != null)
                {
                    lastAutoOut.ReturnTime = DateTime.Now;
                    lastAutoOut.OutsideDurationMinutes = outsideMinutes;
                }

                var evtReturn = new TblWFHTrackingEvent
                {
                    TrackingId = session.Id,
                    AttendanceId = session.AttendanceId,
                    EmployeeId = req.EmployeeId,
                    EventType = "AutoReturn",
                    EventTime = DateTime.Now,
                    Latitude = req.Latitude,
                    Longitude = req.Longitude,
                    Distance = Math.Round(distance, 2),
                    Address = $"{req.Latitude:F6}, {req.Longitude:F6}",
                    DeviceName = req.DeviceName,
                    Browser = req.Browser,
                    IpAddress = req.IpAddress,
                    OutsideDurationMinutes = outsideMinutes,
                    CreatedOn = DateTime.Now
                };
                _context.TblWFHTrackingEvents.Add(evtReturn);
                await _context.SaveChangesAsync();

                session.TotalOutsideDurationMinutes += outsideMinutes;
                currentStatus = "Inside";

                await UpsertCurrentStatus(req.EmployeeId, session.AttendanceId, session.Id, today,
                    "Inside", req.Latitude, req.Longitude, Math.Round(distance, 2), null,
                    req.DeviceName, req.Browser, req.IpAddress,
                    returnedTime: DateTime.Now,
                    addOutsideMinutes: outsideMinutes);

                // Notify HR
                var employee = await _context.TblEmplyeeInfos
                    .FirstOrDefaultAsync(e => e.Id == req.EmployeeId);
                string empName = employee?.Name ?? "Unknown";
                string notifTitle = "WFH Employee Returned";
                string notifBody = $"{empName} returned to WFH location.\n" +
                                    $"Returned Time: {DateTime.Now:hh:mm tt}\n" +
                                    $"Outside Duration: {outsideMinutes} Minutes";

                await SendHRPushNotification(notifTitle, notifBody, "/wfh-monitoring");
                await LogNotification(req.EmployeeId, session.AttendanceId, evtReturn.Id, "AutoReturn", notifTitle, notifBody, "HR");

                // Also notify the employee
                string empNotifBody = $"You have returned to your WFH location.\nOutside Duration: {outsideMinutes} Minutes.";
                await SendEmployeePushNotification(req.EmployeeId, "WFH Return Confirmed", empNotifBody, "/attendance");
                await LogNotification(req.EmployeeId, session.AttendanceId, evtReturn.Id, "AutoReturn", "WFH Return Confirmed", empNotifBody, "Employee");
            }

            // 8. Update session with current location
            session.CurrentLat = req.Latitude;
            session.CurrentLong = req.Longitude;
            session.CurrentDistance = Math.Round(distance, 2);
            session.CurrentStatus = currentStatus;
            session.LastPingTime = DateTime.Now;
            session.UpdatedOn = DateTime.Now;

            // Keep status updated even without event
            if (eventTriggered == null)
            {
                await UpsertCurrentStatus(req.EmployeeId, session.AttendanceId, session.Id, today,
                    currentStatus, req.Latitude, req.Longitude, Math.Round(distance, 2), null,
                    req.DeviceName, req.Browser, req.IpAddress);
            }

            await _context.SaveChangesAsync();
            _logger.LogDebug("WFH ping for Emp {EmpId}: {Dist}m, Inside={Inside}", req.EmployeeId, Math.Round(distance), isInside);

            return Ok(new WFHLocationPingResponse
            {
                Success = true,
                Distance = Math.Round(distance, 2),
                IsInsideRadius = isInside,
                CurrentStatus = currentStatus,
                EventTriggered = eventTriggered,
                Message = eventTriggered ?? "Ping recorded."
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing WFH location ping for Employee {EmpId}", req.EmployeeId);
            return StatusCode(500, new { success = false, message = ex.Message });
        }
    }

    // ────────────────────────────────────────────────────────────────────────
    // POST /api/wfh/stopTracking
    // Called after WFH punch-out.
    // ────────────────────────────────────────────────────────────────────────
    [HttpPost("stopTracking")]
    public async Task<IActionResult> StopTracking([FromBody] WFHStopTrackingRequest req)
    {
        try
        {
            var today = DateTime.Today;
            var session = await _context.TblWFHTrackings
                .FirstOrDefaultAsync(t => t.EmployeeId == req.EmployeeId
                                       && t.TrackingDate == today
                                       && t.TrackingEndTime == null);

            if (session != null)
            {
                session.TrackingEndTime = DateTime.Now;
                session.CurrentStatus = "Completed";
                session.UpdatedOn = DateTime.Now;
            }

            var statusRec = await _context.TblWFHCurrentStatuses
                .FirstOrDefaultAsync(s => s.EmployeeId == req.EmployeeId);
            if (statusRec != null)
            {
                statusRec.CurrentStatus = "NotTracking";
                statusRec.UpdatedOn = DateTime.Now;
            }

            await _context.SaveChangesAsync();
            _logger.LogInformation("WFH tracking stopped for Employee {EmpId}", req.EmployeeId);

            return Ok(new { success = true, message = "Tracking stopped." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error stopping WFH tracking for Employee {EmpId}", req.EmployeeId);
            return StatusCode(500, new { success = false, message = ex.Message });
        }
    }

    // ────────────────────────────────────────────────────────────────────────
    // GET /api/wfh/dashboard
    // HR / Admin only.
    // ────────────────────────────────────────────────────────────────────────
    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard([FromQuery] DateTime? date = null)
    {
        try
        {
            var target = (date ?? DateTime.Today).Date;

            var wfhLogs = await _context.AttendanceLogs
                .Include(a => a.Employee).ThenInclude(e => e!.Department)
                .Where(a => a.Date == target && a.WorkMode == "Work From Home")
                .ToListAsync();

            var statuses = await _context.TblWFHCurrentStatuses
                .Where(s => s.TrackingDate == target)
                .ToListAsync();

            int autoOutCount = await _context.TblWFHTrackingEvents
                .CountAsync(e => e.EventTime.Date == target && e.EventType == "AutoOut");
            int autoReturnCount = await _context.TblWFHTrackingEvents
                .CountAsync(e => e.EventTime.Date == target && e.EventType == "AutoReturn");

            var outsideStatuses = statuses.Where(s => s.CurrentStatus == "Outside").ToList();
            double avgOutside = statuses.Any()
                ? statuses.Average(s => s.TotalOutsideDurationMinutes)
                : 0;

            var outsideEmps = outsideStatuses.Select(s =>
            {
                var emp = wfhLogs.FirstOrDefault(l => l.EmployeeId == s.EmployeeId)?.Employee;
                return new WFHOutsideEmployeeSummary
                {
                    EmployeeId = s.EmployeeId,
                    EmployeeName = emp?.Name,
                    Department = emp?.Department?.Name,
                    OutsideSince = s.OutsideSince,
                    CurrentDistance = s.CurrentDistance,
                    CurrentLat = s.CurrentLat,
                    CurrentLong = s.CurrentLong
                };
            }).ToList();

            return Ok(new WFHDashboardStats
            {
                TotalWFHEmployees = wfhLogs.Count,
                CurrentlyWorking = statuses.Count(s => s.CurrentStatus == "Inside"),
                CurrentlyOutside = statuses.Count(s => s.CurrentStatus == "Outside"),
                ReturnedEmployees = statuses.Count(s => s.CurrentStatus == "Returned" || s.CurrentStatus == "Inside"),
                TotalAutoOutEvents = autoOutCount,
                TotalAutoReturnEvents = autoReturnCount,
                AverageOutsideDuration = Math.Round(avgOutside, 1),
                EmployeesCurrentlyOutside = outsideEmps
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting WFH dashboard");
            return StatusCode(500, ex.Message);
        }
    }

    // ────────────────────────────────────────────────────────────────────────
    // GET /api/wfh/list
    // HR / Admin monitoring grid.
    // ────────────────────────────────────────────────────────────────────────
    [HttpGet("list")]
    public async Task<IActionResult> GetList(
        [FromQuery] DateTime? fromDate,
        [FromQuery] DateTime? toDate,
        [FromQuery] string? department,
        [FromQuery] string? currentStatus,
        [FromQuery] int? employeeId)
    {
        try
        {
            var from = (fromDate ?? DateTime.Today).Date;
            var to = (toDate ?? DateTime.Today).Date;

            var query = _context.AttendanceLogs
                .Include(a => a.Employee).ThenInclude(e => e!.Department)
                .Where(a => a.Date >= from && a.Date <= to && a.WorkMode == "Work From Home");

            if (employeeId.HasValue) query = query.Where(a => a.EmployeeId == employeeId.Value);
            if (!string.IsNullOrEmpty(department))
                query = query.Where(a => a.Employee.Department != null && a.Employee.Department.Name == department);

            var logs = await query.OrderByDescending(a => a.Date).ToListAsync();

            var empIds = logs.Select(l => l.EmployeeId).Distinct().ToList();
            var statuses = await _context.TblWFHCurrentStatuses
                .Where(s => empIds.Contains(s.EmployeeId))
                .ToListAsync();

            var sessions = await _context.TblWFHTrackings
                .Where(t => t.TrackingDate >= from && t.TrackingDate <= to && empIds.Contains(t.EmployeeId))
                .ToListAsync();

            var events = await _context.TblWFHTrackingEvents
                .Where(e => e.EventTime.Date >= from && e.EventTime.Date <= to && empIds.Contains(e.EmployeeId))
                .ToListAsync();

            var result = logs.Select(log =>
            {
                var st = statuses.FirstOrDefault(s => s.EmployeeId == log.EmployeeId);
                var ses = sessions.FirstOrDefault(s => s.EmployeeId == log.EmployeeId && s.TrackingDate == log.Date);
                var lastAutoOut = events
                    .Where(e => e.EmployeeId == log.EmployeeId && e.EventType == "AutoOut" && e.EventTime.Date == log.Date)
                    .OrderByDescending(e => e.EventTime).FirstOrDefault();

                string status = st?.TrackingDate == log.Date
                    ? (st.CurrentStatus ?? "Unknown")
                    : "Inside";

                int outMinutes = st?.TotalOutsideDurationMinutes ?? 0;
                int autoOutCnt = st?.TotalAutoOutCount ?? 0;

                return new WFHMonitoringListItem
                {
                    EmployeeId = log.EmployeeId,
                    EmployeeCode = log.Employee?.EmpId,
                    EmployeeName = log.Employee?.Name,
                    Department = log.Employee?.Department?.Name,
                    Designation = log.Employee?.Designation,
                    AttendanceDate = log.Date,
                    PunchIn = log.PunchInTime,
                    PunchOut = log.PunchOutTime,
                    CurrentStatus = status,
                    CurrentDistance = st?.CurrentDistance,
                    CurrentAddress = st?.CurrentAddress,
                    OutsideSince = st?.OutsideSince,
                    ReturnedTime = st?.ReturnedTime,
                    OutsideDurationMinutes = outMinutes,
                    TotalAutoOutCount = autoOutCnt,
                    CurrentLat = st?.CurrentLat,
                    CurrentLong = st?.CurrentLong,
                    DeviceName = st?.DeviceName,
                    Browser = st?.Browser,
                    LastUpdatedTime = st?.LastPingTime,
                    TrackingStatus = GetTrackingStatus(ses, st)
                };
            }).ToList();

            if (!string.IsNullOrEmpty(currentStatus))
                result = result.Where(r => r.CurrentStatus == currentStatus).ToList();

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting WFH list");
            return StatusCode(500, ex.Message);
        }
    }

    // ────────────────────────────────────────────────────────────────────────
    // GET /api/wfh/details/{employeeId}
    // ────────────────────────────────────────────────────────────────────────
    [HttpGet("details/{employeeId}")]
    public async Task<IActionResult> GetDetails(int employeeId, [FromQuery] DateTime? date = null)
    {
        try
        {
            var target = (date ?? DateTime.Today).Date;

            var log = await _context.AttendanceLogs
                .Include(a => a.Employee).ThenInclude(e => e!.Department)
                .Where(a => a.EmployeeId == employeeId && a.Date == target && a.WorkMode == "Work From Home")
                .OrderByDescending(a => a.Id)
                .FirstOrDefaultAsync();

            if (log == null)
                return NotFound(new { message = "No WFH attendance found for this date." });

            var session = await _context.TblWFHTrackings
                .FirstOrDefaultAsync(s => s.EmployeeId == employeeId && s.TrackingDate == target);

            var statusRec = await _context.TblWFHCurrentStatuses
                .FirstOrDefaultAsync(s => s.EmployeeId == employeeId);

            var pings = session == null ? new List<TblWFHGPSPing>()
                : await _context.TblWFHGPSPings
                    .Where(p => p.TrackingId == session.Id)
                    .OrderBy(p => p.PingTime)
                    .ToListAsync();

            var evts = await _context.TblWFHTrackingEvents
                .Where(e => e.EmployeeId == employeeId && e.EventTime.Date == target)
                .OrderBy(e => e.EventTime)
                .ToListAsync();

            var notifs = await _context.TblWFHNotificationHistories
                .Where(n => n.EmployeeId == employeeId && n.SentOn.Date == target)
                .OrderByDescending(n => n.SentOn)
                .ToListAsync();

            // Build timeline
            var timeline = new List<WFHTimelineItem>();
            if (log.PunchInTime != default)
                timeline.Add(new WFHTimelineItem { Time = log.PunchInTime, EventType = "PunchIn", Description = "Punch In", IconClass = "bi-clock-history", BadgeClass = "bg-success" });

            foreach (var e in evts)
            {
                if (e.EventType == "AutoOut")
                    timeline.Add(new WFHTimelineItem { Time = e.EventTime, EventType = "AutoOut", Description = $"Left location ({Math.Round(e.Distance)}m away)", IconClass = "bi-geo-alt", BadgeClass = "bg-danger" });
                else
                    timeline.Add(new WFHTimelineItem { Time = e.EventTime, EventType = "AutoReturn", Description = $"Returned ({e.OutsideDurationMinutes} min outside)", IconClass = "bi-house-check", BadgeClass = "bg-primary" });
            }

            if (log.PunchOutTime.HasValue)
                timeline.Add(new WFHTimelineItem { Time = log.PunchOutTime.Value, EventType = "PunchOut", Description = "Punch Out", IconClass = "bi-power", BadgeClass = "bg-secondary" });

            timeline = timeline.OrderBy(t => t.Time).ToList();

            return Ok(new WFHEmployeeDetail
            {
                EmployeeId = employeeId,
                EmployeeCode = log.Employee?.EmpId,
                EmployeeName = log.Employee?.Name,
                Department = log.Employee?.Department?.Name,
                Designation = log.Employee?.Designation,
                AttendanceDate = log.Date,
                PunchIn = log.PunchInTime,
                PunchOut = log.PunchOutTime,
                AssignedLat = session?.AssignedLat,
                AssignedLong = session?.AssignedLong,
                AllowedRadius = session?.AllowedRadius ?? 100,
                CurrentStatus = statusRec?.CurrentStatus,
                CurrentDistance = statusRec?.CurrentDistance,
                CurrentLat = statusRec?.CurrentLat,
                CurrentLong = statusRec?.CurrentLong,
                OutsideSince = statusRec?.OutsideSince,
                ReturnedTime = statusRec?.ReturnedTime,
                TotalAutoOutCount = statusRec?.TotalAutoOutCount ?? 0,
                TotalOutsideDurationMinutes = statusRec?.TotalOutsideDurationMinutes ?? 0,
                DeviceName = statusRec?.DeviceName,
                Browser = statusRec?.Browser,
                IpAddress = statusRec?.IpAddress,
                GpsPings = pings.Select(p => new WFHGPSPingItem { PingTime = p.PingTime, Latitude = p.Latitude, Longitude = p.Longitude, Distance = p.Distance, IsInsideRadius = p.IsInsideRadius }).ToList(),
                Events = evts.Select(e => new WFHEventItem { Id = e.Id, EventType = e.EventType, EventTime = e.EventTime, Latitude = e.Latitude, Longitude = e.Longitude, Distance = e.Distance, Address = e.Address, DeviceName = e.DeviceName, Browser = e.Browser, IpAddress = e.IpAddress, Reason = e.Reason, ReturnTime = e.ReturnTime, OutsideDurationMinutes = e.OutsideDurationMinutes }).ToList(),
                Notifications = notifs.Select(n => new WFHNotificationHistoryItem { NotificationType = n.NotificationType, Title = n.Title, Body = n.Body, SentTo = n.SentTo, SentOn = n.SentOn, IsDelivered = n.IsDelivered }).ToList(),
                Timeline = timeline
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting WFH details for Employee {EmpId}", employeeId);
            return StatusCode(500, ex.Message);
        }
    }

    // ────────────────────────────────────────────────────────────────────────
    // GET /api/wfh/history/{attendanceId}
    // ────────────────────────────────────────────────────────────────────────
    [HttpGet("history/{attendanceId}")]
    public async Task<IActionResult> GetHistory(int attendanceId)
    {
        try
        {
            var pings = await _context.TblWFHGPSPings
                .Where(p => p.AttendanceId == attendanceId)
                .OrderBy(p => p.PingTime)
                .Select(p => new { p.PingTime, p.Latitude, p.Longitude, p.Distance, p.IsInsideRadius })
                .ToListAsync();

            var events = await _context.TblWFHTrackingEvents
                .Where(e => e.AttendanceId == attendanceId)
                .OrderBy(e => e.EventTime)
                .ToListAsync();

            return Ok(new { pings, events });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // ────────────────────────────────────────────────────────────────────────
    // GET /api/wfh/exportExcel
    // Returns CSV data for download.
    // ────────────────────────────────────────────────────────────────────────
    [HttpGet("exportExcel")]
    public async Task<IActionResult> ExportExcel(
        [FromQuery] DateTime? fromDate,
        [FromQuery] DateTime? toDate,
        [FromQuery] string? generatedBy = "HR")
    {
        try
        {
            var from = (fromDate ?? DateTime.Today).Date;
            var to = (toDate ?? DateTime.Today).Date;

            var logs = await _context.AttendanceLogs
                .Include(a => a.Employee).ThenInclude(e => e!.Department)
                .Where(a => a.Date >= from && a.Date <= to && a.WorkMode == "Work From Home")
                .OrderBy(a => a.Employee.Name).ThenBy(a => a.Date)
                .ToListAsync();

            var empIds = logs.Select(l => l.EmployeeId).Distinct().ToList();

            var statuses = await _context.TblWFHCurrentStatuses
                .Where(s => empIds.Contains(s.EmployeeId)).ToListAsync();

            var sessions = await _context.TblWFHTrackings
                .Where(t => t.TrackingDate >= from && t.TrackingDate <= to && empIds.Contains(t.EmployeeId))
                .ToListAsync();

            var events = await _context.TblWFHTrackingEvents
                .Where(e => e.EventTime.Date >= from && e.EventTime.Date <= to && empIds.Contains(e.EmployeeId))
                .OrderBy(e => e.EventTime)
                .ToListAsync();

            var sb = new StringBuilder();
            sb.AppendLine("WFH GPS TRACKING REPORT");
            sb.AppendLine($"Company: SP ONEHR | Generated: {DateTime.Now:dd MMM yyyy HH:mm} | Generated By: {generatedBy}");
            sb.AppendLine($"Date Range: {from:dd/MM/yyyy} to {to:dd/MM/yyyy}");
            sb.AppendLine();
            sb.AppendLine("Employee Code,Employee Name,Department,Attendance Date,Punch In,Punch Out," +
                          "Current Status,Assigned Latitude,Assigned Longitude,Current Latitude,Current Longitude," +
                          "Distance (m),Auto Out Time,Auto Return Time,Outside Duration (min),Outside Count,Remarks");

            foreach (var log in logs)
            {
                var st = statuses.FirstOrDefault(s => s.EmployeeId == log.EmployeeId);
                var ses = sessions.FirstOrDefault(s => s.EmployeeId == log.EmployeeId && s.TrackingDate == log.Date);
                var lastOut = events.Where(e => e.EmployeeId == log.EmployeeId && e.EventType == "AutoOut" && e.EventTime.Date == log.Date).FirstOrDefault();
                var lastRet = events.Where(e => e.EmployeeId == log.EmployeeId && e.EventType == "AutoReturn" && e.EventTime.Date == log.Date).LastOrDefault();
                int outCnt = events.Count(e => e.EmployeeId == log.EmployeeId && e.EventType == "AutoOut" && e.EventTime.Date == log.Date);

                sb.AppendLine(string.Join(",",
                    Q(log.Employee?.EmpId),
                    Q(log.Employee?.Name),
                    Q(log.Employee?.Department?.Name),
                    Q(log.Date.ToString("dd/MM/yyyy")),
                    Q(log.PunchInTime.ToString("hh:mm tt")),
                    Q(log.PunchOutTime?.ToString("hh:mm tt") ?? "Pending"),
                    Q(st?.CurrentStatus ?? "N/A"),
                    Q(ses?.AssignedLat.ToString("F6") ?? ""),
                    Q(ses?.AssignedLong.ToString("F6") ?? ""),
                    Q(st?.CurrentLat?.ToString("F6") ?? ""),
                    Q(st?.CurrentLong?.ToString("F6") ?? ""),
                    Q(st?.CurrentDistance?.ToString("F0") ?? ""),
                    Q(lastOut?.EventTime.ToString("hh:mm tt") ?? ""),
                    Q(lastRet?.EventTime.ToString("hh:mm tt") ?? ""),
                    Q((st?.TotalOutsideDurationMinutes ?? 0).ToString()),
                    Q(outCnt.ToString()),
                    Q(outCnt > 0 ? $"Left location {outCnt} time(s)" : "Stayed within radius")
                ));
            }

            byte[] bytes = Encoding.UTF8.GetPreamble().Concat(Encoding.UTF8.GetBytes(sb.ToString())).ToArray();
            return File(bytes, "text/csv", $"WFH_Tracking_{from:yyyyMMdd}_{to:yyyyMMdd}.csv");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating WFH export");
            return StatusCode(500, ex.Message);
        }
    }

    // ────────────────────────────────────────────────────────────────────────
    // Helpers
    // ────────────────────────────────────────────────────────────────────────

    /// <summary>
    /// Determines tracking status including signal-lost detection.
    /// If no ping received in > 5 minutes while session is active = Signal Lost.
    /// </summary>
    private static string GetTrackingStatus(TblWFHTracking? session, TblWFHCurrentStatus? status)
    {
        if (session == null) return "Not Started";
        if (session.TrackingEndTime != null) return "Completed";

        // Signal lost = session is active but last ping is stale (> 5 min)
        var lastPing = status?.LastPingTime ?? session.LastPingTime;
        if (lastPing.HasValue && (DateTime.Now - lastPing.Value).TotalMinutes > 5)
            return "Signal Lost";

        return "Active";
    }

    private static string Q(string? s) => $"\"{(s ?? "").Replace("\"", "\"\"")}\"";

    private static double CalcDistance(double lat1, double lon1, double lat2, double lon2)
    {
        const double R = 6371e3;
        double dLat = (lat2 - lat1) * Math.PI / 180;
        double dLon = (lon2 - lon1) * Math.PI / 180;
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2)
                 + Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180)
                 * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        return R * 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
    }

    private async Task UpsertCurrentStatus(
        int empId, int attendanceId, int trackingId, DateTime date,
        string status, double? lat, double? lon, double? dist, string? address,
        string? device, string? browser, string? ip,
        DateTime? outsideSince = null, DateTime? returnedTime = null,
        int addOutsideMinutes = 0)
    {
        var rec = await _context.TblWFHCurrentStatuses.FirstOrDefaultAsync(s => s.EmployeeId == empId);
        if (rec == null)
        {
            rec = new TblWFHCurrentStatus { EmployeeId = empId };
            _context.TblWFHCurrentStatuses.Add(rec);
        }

        rec.AttendanceId = attendanceId;
        rec.TrackingId = trackingId;
        rec.TrackingDate = date;
        rec.CurrentStatus = status;
        rec.CurrentLat = lat;
        rec.CurrentLong = lon;
        rec.CurrentDistance = dist;
        rec.CurrentAddress = address;
        rec.LastPingTime = DateTime.Now;
        rec.DeviceName = device;
        rec.Browser = browser;
        rec.IpAddress = ip;
        rec.UpdatedOn = DateTime.Now;

        if (status == "Outside" && outsideSince.HasValue)
        {
            rec.OutsideSince = outsideSince.Value;
            rec.TotalAutoOutCount++;
        }
        if (returnedTime.HasValue)
        {
            rec.ReturnedTime = returnedTime.Value;
            rec.OutsideSince = null;
            rec.TotalOutsideDurationMinutes += addOutsideMinutes;
        }
        if (addOutsideMinutes > 0 && returnedTime == null)
            rec.TotalOutsideDurationMinutes += addOutsideMinutes;
    }

    private async Task LogNotification(int empId, int attendanceId, int eventId,
        string type, string title, string body, string sentTo)
    {
        _context.TblWFHNotificationHistories.Add(new TblWFHNotificationHistory
        {
            EmployeeId = empId,
            AttendanceId = attendanceId,
            TrackingEventId = eventId,
            NotificationType = type,
            Title = title,
            Body = body,
            SentTo = sentTo,
            SentOn = DateTime.Now
        });
        await _context.SaveChangesAsync();
    }

    private async Task SendHRPushNotification(string title, string body, string url)
    {
        try
        {
            var subs = await _context.TblPushSubscriptions
                .Where(x => x.Department == "Human  Resources")
                .ToListAsync();

            if (!subs.Any()) return;

            var vapid = new VapidDetails(VapidSubject, VapidPublicKey, VapidPrivateKey);
            var client = new WebPushClient();
            var payload = JsonSerializer.Serialize(new { title, message = body, url });

            foreach (var sub in subs)
            {
                try
                {
                    await client.SendNotificationAsync(
                        new PushSubscription(sub.Endpoint, sub.P256dh, sub.Auth), payload, vapid);
                    sub.CreatedOn = DateTime.Now;
                }
                catch (WebPushException ex) when (
                    ex.StatusCode == System.Net.HttpStatusCode.Gone ||
                    ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    _context.TblPushSubscriptions.Remove(sub);
                }
            }
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "HR push notification failed");
        }
    }

    private async Task SendEmployeePushNotification(int empId, string title, string body, string url)
    {
        try
        {
            var subs = await _context.TblPushSubscriptions
                .Where(x => x.EmpId == empId)
                .ToListAsync();

            if (!subs.Any()) return;

            var vapid = new VapidDetails(VapidSubject, VapidPublicKey, VapidPrivateKey);
            var client = new WebPushClient();
            var payload = JsonSerializer.Serialize(new { title, message = body, url });

            foreach (var sub in subs)
            {
                try
                {
                    await client.SendNotificationAsync(
                        new PushSubscription(sub.Endpoint, sub.P256dh, sub.Auth), payload, vapid);
                }
                catch (WebPushException ex) when (
                    ex.StatusCode == System.Net.HttpStatusCode.Gone ||
                    ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    _context.TblPushSubscriptions.Remove(sub);
                }
            }
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Employee push notification failed for EmpId {EmpId}", empId);
        }
    }
}
