using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X9;
using SMART_HRMS_SYSTEM.Shared;
using SMART_HRMS_SYSTEM.Shared.Models;
using SMART_HRMS_SYSTEM.Shared.ViewModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WebPush;

namespace SMART_HRMS_SYSTEM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly LotusTechCrmliveContext _context;

        public AttendanceController(LotusTechCrmliveContext context)
        {
            _context = context;
        }

        [HttpPost("punch-in")]
        public async Task<IActionResult> PunchIn([FromBody] PunchRequestViewModel request)
        {
            // ✅ Get Office Location from DB
            var data = await _context.OfficeSettings.FirstOrDefaultAsync();

            if (data == null)
                return BadRequest("Office location Not Found.");

            double officeLat = data.Latitude;
            double officeLong = data.Longitude;

            // ✅ Distance calculation
            double distance = GeoHelper.GetDistanceInMeters(
                officeLat, officeLong,
                request.Lat, request.Lng
            );

            if (distance > data.AllowedRadiusInMeters && request.WorkMode == "Office")
            {
                return BadRequest($"❌ You Are Out Of Office Location {Math.Round(distance)} meter. Please Make Sure In Office Location");
            }

            // ✅ Save Punch In

            var log = new AttendanceLog
            {
                EmployeeId = request.EmployeeId,
                Date = DateTime.Now.Date,
                PunchInTime = DateTime.Now,
                PunchInLat = request.Lat,
                PunchInLong = request.Lng,
                SelfieData = request.SelfieData,
                WorkMode = request.WorkMode,

            };

            _context.AttendanceLogs.Add(log);
            await _context.SaveChangesAsync();


            return Ok(new
            {
                Message = "✅ Punch In Successful!",
                Distance = Math.Round(distance)
            });
        }
        // HttpGet aivaji HttpPost vapra karan aapan body (Lat, Lng) pathvat ahot
        [HttpPost("Getpunch-status")]
        public async Task<IActionResult> GetPunchStatus([FromBody] PunchRequestViewModel request)
        {
            var office = await _context.OfficeSettings.FirstOrDefaultAsync();
            var empInfo = await _context.TblEmplyeeInfos.FindAsync(request.EmployeeId);

            double distance = GeoHelper.GetDistanceInMeters(office.Latitude, office.Longitude, request.Lat, request.Lng);
            bool isWithinRange = distance <= office.AllowedRadiusInMeters;

            // लॉजिक सुरू
            string allowedMode = "";
            bool needsSelfie = false;

            // १. जर युजर ऑफिस रेंजमध्ये असेल तर सरळ 'Office Mode'
            if (isWithinRange)
            {
                allowedMode = "Office";
                needsSelfie = false;
            }
            // २. जर रेंजमध्ये नसेल, पण त्याचा परमनंट मोड 'WFH' असेल तर
            else if (empInfo.DefaultWorkMode == "Work From Home")
            {
                allowedMode = "Work From Home";
                needsSelfie = true;
            }
            // ३. जर रेंजमध्ये नाही आणि परमनंट ऑफिस आहे, तर 'Approved Request' तपासा
            else
            {
                // Capture today once — midnight, no time component, no repeated DateTime.Now calls.
                var today = DateTime.Today;          // 2025-07-08 00:00:00
                var tomorrow = today.AddDays(1);        // 2025-07-09 00:00:00

                // ── Why < tomorrow instead of .Date <= today ──────────────────────
                // FromDate may be stored with a time component (e.g. 2025-07-08 09:30:00).
                // x.FromDate.Value.Date uses the .Date accessor on a nullable, which is
                // not reliably translated to SQL in all EF Core versions and can throw.
                // "FromDate < tomorrow" captures any FromDate on or before today regardless
                // of what time was saved — without calling .Date on a nullable.
                //
                // ── Why x.ToDate.Value >= today ──────────────────────────────────
                // The original x.ToDate >= DateTime.Now.Date compared the FULL ToDate
                // datetime to today-midnight. If ToDate was saved as 2025-07-07 23:59:59
                // (end-of-day style) for a July-8 approval, it evaluates to FALSE and
                // silently blocks WFH. Stripping to date-only via .Value with HasValue
                // guard ensures any ToDate on or after today activates WFH.
                var hasApprovedWFH = await _context.TblLeaveRequests.AnyAsync(x =>
                    x.EmpId == request.EmployeeId &&
                    x.RequestType == "Work From Home" &&
                    x.Status == "Approved" &&
                    x.FromDate.HasValue &&
                    x.ToDate.HasValue &&
                    x.FromDate.Value < tomorrow &&
                    x.ToDate.Value.Date >= today);

                if (hasApprovedWFH)
                {
                    allowedMode = "Work From Home";
                    needsSelfie = true;
                }
            }

            var log = await _context.AttendanceLogs
                        .Where(t => t.EmployeeId == request.EmployeeId && t.Date == DateTime.Now.Date)
                        .OrderByDescending(t => t.Id).FirstOrDefaultAsync();

            return Ok(new
            {
                Distance = Math.Round(distance),
                IsWithinRange = isWithinRange,
                AllowedMode = allowedMode, // "Office", "WFH" किंवा रिकामे (No Permission)
                NeedsSelfie = needsSelfie,
                // फक्त लागणाऱ्या व्हॅल्यूज JSON मध्ये पाठवा
                Log = log != null ? new
                {
                    PunchInTime = log.PunchInTime,
                    PunchOutTime = log.PunchOutTime
                } : null
            });
        }
        [HttpPost("punch-out")]
        public async Task<IActionResult> PunchOut([FromBody] PunchRequestViewModel request)
        {
            var data = await _context.OfficeSettings.FirstOrDefaultAsync();

            if (data == null)
                return BadRequest("Office location Not Found.");

            double officeLat = data.Latitude;
            double officeLong = data.Longitude;

            double distance = GeoHelper.GetDistanceInMeters(
                officeLat, officeLong,
                request.Lat, request.Lng
            );

            if (distance > data.AllowedRadiusInMeters && request.WorkMode == "Office")
            {
                return BadRequest($"❌ You Are Out Of Office Location {Math.Round(distance)} meter. Please Make Sure In Office Location");
            }

            // ✅ Update Punch Out

            var todayLog = await _context.AttendanceLogs
    .Where(x =>
        x.EmployeeId == request.EmployeeId &&
        x.Date == DateTime.Now.Date)
    .OrderByDescending(x => x.Id)
    .FirstOrDefaultAsync();

            if (todayLog == null)
                return BadRequest("Punch In record Not Found.");

            todayLog.Id = todayLog.Id;
            todayLog.PunchOutTime = DateTime.Now;
            todayLog.PunchOutLat = request.Lat;
            todayLog.PunchOutLong = request.Lng;

            await _context.SaveChangesAsync();


            return Ok(new
            {
                Message = "✅ Punch Out Successful!"
            });
        }

        [HttpPost("check-distance")]
        public async Task<IActionResult> CheckDistance([FromBody] LocationResultViewModel request)
        {
            var data = await _context.OfficeSettings.FirstOrDefaultAsync();

            if (data == null)
                return BadRequest("Office location Not Found");

            double officeLat = data.Latitude;
            double officeLong = data.Longitude;

            double distance = GeoHelper.GetDistanceInMeters(
                officeLat, officeLong,
                request.Latitude, request.Longitude
            );

            bool isWithinRange = distance <= data.AllowedRadiusInMeters;

            return Ok(new
            {
                Distance = Math.Round(distance),
                IsWithinRange = isWithinRange
            });
        }

        [HttpPost("report")]
        public async Task<IActionResult> GetAttendanceReport([FromBody] ReportFilterRequest request)
        {
            try
            {
                // Employee cha data filter kara (Month aani Year nusar)
                var logs = await _context.AttendanceLogs
                    .Where(x => x.EmployeeId == request.EmployeeId
                             && x.Date.Month == request.Month
                             && x.Date.Year == request.Year)
                    .OrderByDescending(x => x.Date) // Navin tarikh aadhi disel
                    .ToListAsync();

                var reportList = logs.Select(log => new AttendanceRecordViewModel
                {
                    Date = log.Date.ToString("dd MMM yyyy"),
                    DayName = log.Date.ToString("dddd"),
                    PunchIn = log.PunchInTime.ToString("hh:mm tt"),
                    PunchOut = log.PunchOutTime.HasValue ? log.PunchOutTime.Value.ToString("hh:mm tt") : "Pending",
                    WorkMode = log.WorkMode,
                    // Calculate Total Hours
                    TotalHours = log.PunchOutTime.HasValue
                        ? $"{(log.PunchOutTime.Value - log.PunchInTime).Hours:D2}:{(log.PunchOutTime.Value - log.PunchInTime).Minutes:D2} hrs"
                        : "-"
                }).ToList();

                return Ok(reportList);
            }
            catch (Exception ex)
            {
                return Ok(null);

            }

        }
        [HttpGet("AttendacereportByDate")]
        public async Task<IActionResult> AttendacereportByDate([FromQuery] DateTime ReportDate)
        {
            var today = ReportDate.Date;

            // Load employees and today's logs separately, then join in memory.
            // GroupJoin+SelectMany can produce duplicate rows when one employee
            // has multiple attendance records for the same day.
            var employees = await _context.TblEmplyeeInfos
                .Include(e => e.Department)
                .Where(t => t.EmployeeStatus == "Active" && t.CompanyId != null && t.VendorMstId == null)
                .OrderBy(t => t.Name)
                .ToListAsync();

            var logs = await _context.AttendanceLogs
                .Where(a => a.Date.Date == today)
                .ToListAsync();

            // Keep only the latest log per employee (handles double-punch-in)
            var latestLogByEmp = logs
                .GroupBy(a => a.EmployeeId)
                .ToDictionary(g => g.Key, g => g.OrderByDescending(a => a.Id).First());

            var result = employees.Select(emp =>
            {
                latestLogByEmp.TryGetValue(emp.Id, out var att);

                return new HrAttendanceModel
                {
                    EmpName = emp.Name,
                    Department = emp.Department?.Name ?? "-",

                    PunchInTime  = att?.PunchInTime,
                    PunchOutTime = att?.PunchOutTime,

                    TotalHours = (att != null && att.PunchOutTime.HasValue)
                        ? (att.PunchOutTime.Value - att.PunchInTime).ToString(@"hh\:mm") + " hrs"
                        : "-",

                    Status = att == null
                        ? "Absent"
                        : (att.PunchInTime.TimeOfDay <= new TimeSpan(9, 46, 0) ? "Present" : "Late"),

                    WorkMode = att != null && !string.IsNullOrEmpty(att.WorkMode)
                        ? att.WorkMode
                        : "Office"
                };
            }).ToList();

            return Ok(result);
        }


        [HttpGet("MonthlySummaryList")]
        public async Task<IActionResult> GetMonthlySummaryList(int Year, int Month)
        {
            try
            {
                var startDate = new DateTime(Year, Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                var totalDays = DateTime.DaysInMonth(Year, Month);

                // ✅ Employees
                var employees = await _context.TblEmplyeeInfos
                    .Include(e => e.Department)
                    .Where(t => t.EmployeeStatus == "Active" && t.CompanyId != null && t.VendorMstId == null)
                    .ToListAsync();

                // ✅ Attendance Logs
                var logs = await _context.AttendanceLogs
                    .Where(a => a.Date >= startDate && a.Date <= endDate)
                    .ToListAsync();

                // ✅ Leaves (Load once for performance)
                var leaves = await _context.TblLeaveRequests
                    .Where(l => l.FromDate <= endDate &&
                                l.ToDate >= startDate &&
                                l.Status == "Approved")
                    .ToListAsync();

                var result = employees.Select(emp =>
                {
                    var empLogs = logs.Where(x => x.EmployeeId == emp.Id).ToList();
                    var empLeaves = leaves.Where(x => x.EmpId == emp.Id).ToList();

                    // ✅ Present (any punch)
                    decimal present = empLogs.Count(x => x.PunchInTime != default);

                    // ✅ Late
                    decimal late = empLogs.Count(x =>
                        x.PunchInTime != default &&
                        x.PunchInTime.TimeOfDay > new TimeSpan(9, 46, 0));

                    // ✅ Half Day (UNPAID)
                    decimal halfDay = empLeaves.Count(x =>
                        (x.RequestType == "First Half Day" || x.RequestType == "Second Half Day") &&
                        x.LeaveType == "UnPaid");

                    // ✅ Early Out
                    decimal early = empLeaves.Count(x =>
                        x.RequestType == "Early Out");

                    // ✅ Full Day Paid Leave
                    decimal fullPaidLeave = empLeaves.Count(x =>
                        x.RequestType == "Full Day Leave" &&
                        x.LeaveType == "Paid");

                    // ✅ Half Day Paid Leave Count
                    decimal halfDayPaidCount = empLeaves.Count(x =>
                       (x.RequestType == "First Half Day" || x.RequestType == "Second Half Day") &&
                        x.LeaveType == "Paid");

                    // ✅ Convert Half Day → 0.5
                    decimal halfDayPaidLeave = halfDayPaidCount * 0.5m;

                    // ✅ Final Paid Leave
                    decimal paidLeave = fullPaidLeave + halfDayPaidLeave;

                    // ✅ WeekOff (Sunday without attendance)
                    decimal weekOff = Enumerable.Range(1, totalDays)
                        .Select(d => new DateTime(Year, Month, d))
                        .Count(d =>
                            d.DayOfWeek == DayOfWeek.Sunday &&
                            !empLogs.Any(l => l.Date.Date == d.Date)
                        );

                    // ✅ Working Days
                    decimal workingDays = empLogs.Count;

                    // ✅ Absent (Final Correct Formula)
                    decimal absent = totalDays - (workingDays + weekOff + paidLeave);
                    if (absent < 0) absent = 0;

                    return new MonthlySummaryModel
                    {
                        EmployeeId = emp.Id,
                        EmployeeName = emp.Name,
                        Department = emp.Department != null ? emp.Department.Name : "N/A",

                        Present = present,
                        Absent = absent,
                        LateMark = late,
                        WeekOff = weekOff,
                        HalfDay = halfDay,
                        EarlyDeparture = early,
                        PaidLeave = paidLeave
                    };
                })
                .OrderBy(x => x.EmployeeName)
                .ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetByDate")]
        public async Task<IActionResult> GetByDate(int empId, DateTime date)
        {
            try
            {
                var record = await _context.AttendanceLogs
                    .Where(x => x.EmployeeId == empId && x.Date.Date == date.Date)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefaultAsync();

                if (record == null)
                    return Ok(null); // frontend ला null मिळेल

                var result = new ManualAttendanceModel
                {
                    Id = record.Id,
                    EmployeeId = record.EmployeeId,
                    AttendanceDate = record.Date,

                    PunchInTime = record.PunchInTime,
                    PunchOutTime = record.PunchOutTime,

                    WorkMode = record.WorkMode,
                    Remarks = "", // optional (DB मध्ये असेल तर map कर)
                    IsManualEntry = false,
                    CreatedOn = record.Date
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("manual-entry")]
        public async Task<IActionResult> SaveManualAttendance([FromBody] ManualAttendanceModel model)
        {
            try
            {
                // ✅ Get Office Location from DB
                var data = await _context.OfficeSettings.FirstOrDefaultAsync();

                // ✅ Check existing record
                var existing = await _context.AttendanceLogs
                    .FirstOrDefaultAsync(x =>
                        x.EmployeeId == model.EmployeeId &&
                        x.Date == model.AttendanceDate.Date);

                if (existing != null)
                {
                    // ✅ Update
                    existing.PunchInTime = Convert.ToDateTime(model.PunchInTime);
                    existing.PunchOutTime = model.PunchOutTime;
                    existing.WorkMode = model.WorkMode;
                    existing.Reason = model.Remarks;

                    // optional
                    // existing.Remarks = model.Remarks;
                }
                else
                {
                    // ✅ Insert
                    var log = new AttendanceLog
                    {
                        EmployeeId = model.EmployeeId,
                        Date = model.AttendanceDate.Date,
                        PunchInTime = Convert.ToDateTime(model.PunchInTime),
                        PunchOutTime = model.PunchOutTime,
                        WorkMode = model.WorkMode,
                        Reason = model.Remarks
                    };

                    _context.AttendanceLogs.Add(log);
                }

                await _context.SaveChangesAsync();

                return Ok(new { Message = "Manual attendance saved successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CheckWfhBoundary")]
        public async Task<IActionResult> CheckWfhBoundary([FromBody] WfhPingModel model)
        {
            try
            {
                // 1. OfficeSettings मधून Allowed Radius (उदा. 100 मीटर) घ्या
                var officeSetting = await _context.OfficeSettings.FirstOrDefaultAsync();

                // जर टेबलमध्ये व्हॅल्यू नसेल तर Default 100 मीटर पकडा
                double allowedRadius = (officeSetting != null && officeSetting.AllowedRadiusInMeters > 0)
                                        ? officeSetting.AllowedRadiusInMeters
                                        : 100;

                // 2. आजचा WFH चा Punch-In रेकॉर्ड शोधा (जो अजून Punch-out झालेला नाही)
                var todayLog = await _context.AttendanceLogs
                    .FirstOrDefaultAsync(x => x.EmployeeId == model.EmployeeId
                        && x.Date == DateTime.Today
                        && x.WorkMode == "Work From Home"
                        && x.PunchOutTime == null);

                if (todayLog == null || todayLog.PunchInLat == null || todayLog.PunchInLong == null)
                    return Ok(new { message = "No active WFH punch-in found." });

                // 3. डेटाबेसमधील Punch-In लोकेशन आणि आताचे लोकेशन यातील अंतर मोजा
                double distance = GetDistanceInMeters(
                    Convert.ToDouble(todayLog.PunchInLat),
                    Convert.ToDouble(todayLog.PunchInLong),
                    model.CurrentLat,
                    model.CurrentLong);

                // 4. ट्रॅकिंग टेबलमध्ये आधीच तो बाहेर गेल्याची नोंद आहे का ते तपासा
                var openLog = await _context.TblWorkFromHomeTrackingLogs
                    .FirstOrDefaultAsync(x => x.EmployeeId == model.EmployeeId && x.Date == DateTime.Today && x.ReturnTime == null);

                // 5. 🔥 जर अंतर 'AllowedRadius' (उदा. 100m) पेक्षा जास्त असेल
                if (distance > allowedRadius)
                {
                    if (openLog == null) // तो आताच रेडियसच्या बाहेर गेला आहे
                    {
                        var newLog = new TblWorkFromHomeTrackingLog
                        {
                            EmployeeId = model.EmployeeId,
                            Date = DateTime.Today,
                            WentOutTime = DateTime.Now,
                            MaxDistance = distance
                        };
                        _context.TblWorkFromHomeTrackingLogs.Add(newLog);
                        await _context.SaveChangesAsync();
                    }
                    else // तो आधीपासूनच बाहेर आहे, फक्त Max Distance अपडेट करा
                    {
                        if (distance > openLog.MaxDistance)
                        {
                            openLog.MaxDistance = distance;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                // 6. 🔥 जर तो 'AllowedRadius' च्या आत परत आला असेल
                else
                {
                    if (openLog != null) // तो बाहेर गेला होता आणि आता आत आला आहे
                    {
                        openLog.ReturnTime = DateTime.Now;
                        _context.TblWorkFromHomeTrackingLogs.Update(openLog);
                        await _context.SaveChangesAsync();
                    }
                }

                // तुम्ही तपासणीसाठी response मध्ये distance आणि radius दोन्ही पाठवू शकता
                return Ok(new { success = true, currentDistance = distance, radiusApplied = allowedRadius });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // 🌍 अंतर (Meters मध्ये) काढण्याचे सूत्र (Haversine Formula)
        private double GetDistanceInMeters(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371e3; // पृथ्वीची त्रिज्या (Meters)
            var dLat = (lat2 - lat1) * Math.PI / 180;
            var dLon = (lon2 - lon1) * Math.PI / 180;
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        // DTO Class
        public class WfhPingModel
        {
            public int EmployeeId { get; set; }
            public double CurrentLat { get; set; }
            public double CurrentLong { get; set; }
        }


        [HttpGet("EmployeeMonthlyDayWiseReport")]
        public async Task<IActionResult> GetMonthlyDayWiseReport(int Year, int Month)
        {
            var startDate = new DateTime(Year, Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            var totalDays = DateTime.DaysInMonth(Year, Month);

            // 1. Get Active Employees
            var employees = await _context.TblEmplyeeInfos
                .Where(e => e.EmployeeStatus == "Active" && e.CompanyId != null && e.VendorMstId == null)
                .ToListAsync();

            // 2. Get Attendance Logs
            var logs = await _context.AttendanceLogs
                .Where(a => a.Date >= startDate && a.Date <= endDate)
                .ToListAsync();

            // 3. Get Approved Leave Requests that overlap with this month.
            // ToDate may be null for half-day leaves — include those as long as FromDate is in range.
            var leaves = await _context.TblLeaveRequests
                .Where(l => l.Status == "Approved" &&
                            l.FromDate.HasValue &&
                            l.FromDate.Value <= endDate &&
                            (!l.ToDate.HasValue || l.ToDate.Value >= startDate))
                .ToListAsync();

            var result = employees.Select(emp =>
            {
                var empLogs = logs.Where(x => x.EmployeeId == emp.Id).ToList();
                var empLeaves = leaves.Where(x => x.EmpId == emp.Id).ToList();

                var dailyStatus = new List<string>();

                for (int d = 1; d <= totalDays; d++)
                {
                    var date = new DateTime(Year, Month, d);

                    // Priority 1: Half Day leave on this specific date (Paid or UnPaid)
                    var halfDayLeave = empLeaves.FirstOrDefault(l =>
                        l.FromDate.HasValue &&
                        l.FromDate.Value.Date == date.Date &&
                        (l.RequestType == "First Half Day" || l.RequestType == "Second Half Day"));

                    if (halfDayLeave != null)
                    {
                        string hdCode;
                        if (halfDayLeave.LeaveType == "Paid")
                        {
                            hdCode = halfDayLeave.LeaveCategory switch
                            {
                                "Casual" => "HCL",
                                "Sick" => "HSL",
                                _ => "HPL"  // Plan
                            };
                        }
                        else
                        {
                            hdCode = "UH"; // UnPaid Half Day
                        }
                        dailyStatus.Add(hdCode);
                        continue;
                    }

                    // Priority 2: Attendance punch-in (P or L)
                    var log = empLogs.FirstOrDefault(l => l.Date.Date == date.Date);

                    if (log != null && log.PunchInTime != default)
                    {
                        dailyStatus.Add(log.PunchInTime.TimeOfDay > new TimeSpan(9, 46, 0) ? "L" : "P");
                        continue;
                    }

                    // Priority 3: Full Day Paid Leave — Casual / Sick / Plan (separate codes)
                    // ToDate may be null → treat as single-day leave (FromDate only)
                    var paidLeave = empLeaves.FirstOrDefault(l =>
                        l.RequestType == "Full Day Leave" &&
                        l.LeaveType == "Paid" &&
                        (l.LeaveCategory == "Casual" || l.LeaveCategory == "Sick" || l.LeaveCategory == "Plan") &&
                        l.FromDate.HasValue &&
                        l.FromDate.Value.Date <= date.Date &&
                        (!l.ToDate.HasValue ? l.FromDate.Value.Date == date.Date
                                            : l.ToDate.Value.Date >= date.Date));

                    if (paidLeave != null)
                    {
                        string code = paidLeave.LeaveCategory switch
                        {
                            "Casual" => "CL",
                            "Sick" => "SL",
                            _ => "PL"   // Plan
                        };
                        dailyStatus.Add(code);
                        continue;
                    }

                    // Priority 4: Absent
                    dailyStatus.Add("A");
                }

                return new
                {
                    EmployeeName = emp.Name,
                    Days = dailyStatus
                };
            }).ToList();

            return Ok(result);
        }
    }
}