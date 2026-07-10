using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMART_HRMS_SYSTEM.Shared.Models;

[Route("api/[controller]")]
[ApiController]
public class MovementController : ControllerBase
{
    private readonly LotusTechCrmliveContext _context;

    public MovementController(LotusTechCrmliveContext context)
    {
        _context = context;
    }

    // १. बाहेर जाताना (Start Break)
    [HttpPost("Exit")]
    public async Task<IActionResult> MarkExit([FromBody] TblMovementRegister request)
    {
        try
        {
            var movement = new TblMovementRegister
            {
                EmpId = request.EmpId,
                LogDate = DateTime.Today,
                ExitTime = DateTime.Now.TimeOfDay,
                Reason = request.Reason ?? "Short Break",
                CreatedDate = DateTime.Now
            };

            _context.TblMovementRegisters.Add(movement);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Exit marked successfully", Id = movement.Id });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // २. परत आल्यावर (Mark Return)
    [HttpPost("Return")]
    public async Task<IActionResult> MarkReturn([FromBody] TblMovementRegister request)
    {
        try
        {
            var movement = await _context.TblMovementRegisters
                .Where(x => x.EmpId == request.EmpId && x.LogDate == DateTime.Today && x.EntryTime == null)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (movement == null) return BadRequest("Record not found");

            movement.EntryTime = DateTime.Now.TimeOfDay;

            // 🔥 येथे आपण जुन्या Reason मध्ये नवीन 'Late Reason' जोडत आहोत (Concatenate)
            if (!string.IsNullOrWhiteSpace(request.Reason))
            {
                movement.Reason = $"{movement.Reason} | Late Reason: {request.Reason}";
            }

            if (movement.ExitTime.HasValue)
            {
                var duration = movement.EntryTime.Value - movement.ExitTime.Value;
                movement.DurationMinutes = (int)duration.TotalMinutes;
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }

    // ३. स्टेटस चेक करण्यासाठी (जर पेज रिफ्रेश झाले तर UI ला कळण्यासाठी)
    [HttpGet("GetStatus/{empId}")]
    public async Task<IActionResult> GetStatus(int empId)
    {
        var activeRecord = await _context.TblMovementRegisters.OrderByDescending(t=>t.Id)
            .FirstOrDefaultAsync(x => x.EmpId == empId && x.LogDate == DateTime.Today && x.EntryTime == null);

        if (activeRecord != null)
        {
            return Ok(new { IsOnBreak = true, ExitTime = activeRecord.ExitTime });
        }
        return Ok(new { IsOnBreak = false });
    }

    [HttpGet("GetMovementRecords")]
    public async Task<IActionResult> GetMovementRecords(string filterType, string? date, int? month, int? year)
    {
        var query = from m in _context.TblMovementRegisters
                    join e in _context.TblEmplyeeInfos.Where(e => e.EmployeeStatus == "Active" && e.CompanyId != null && e.VendorMstId == null) on m.EmpId equals e.Id
                    join de in _context.TblDepartmentInfos on e.DepartmentId equals de.Id
                    select new { m, e ,de};

        // Apply Filter Type
        if (filterType == "Daily" && DateTime.TryParse(date, out var d))
        {
            query = query.Where(x => x.m.LogDate.Date == d.Date);
        }
        else if (filterType == "Monthly" && month.HasValue && year.HasValue)
        {
            query = query.Where(x => x.m.LogDate.Month == month && x.m.LogDate.Year == year);
        }

        var result = await query.OrderByDescending(x => x.m.Id).Select(x => new
        {
            EmpId = x.e.Id,
            EmpName = x.e.Name,
            Designation = x.de.Name, // तुमच्या गरजेनुसार फील्ड नाव बदला
            LogDate = x.m.LogDate,
            ExitTime = x.m.ExitTime,
            EntryTime = x.m.EntryTime,
            DurationMinutes = x.m.DurationMinutes,
            Reason = x.m.Reason
        }).ToListAsync();

        return Ok(result);
    }
}