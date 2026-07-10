using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMART_HRMS_SYSTEM.Shared.Models;
using SMART_HRMS_SYSTEM.Shared.ViewModel;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using WebPush;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController : ControllerBase
{
    private readonly LotusTechCrmliveContext _context;
    // हे डिटेल्स तुम्हाला तुमच्या VAPID Keys ने रिप्लेस करावे लागतील
    string subject = "mailto:yuvaraj.lotustech@gmail.com";
    string publicKey = "BPdHp1GBJ5-_apY5jYru_kiZuBja89HxGcZCsLFa06nsT1zaeGkrtz1EpXI1WM7ijcQ8So5DqNXTKH8wEUmcGJM";
    string privateKey = "q_5BI5ysQ0htTvREN-TswnqYLMovVjaGZ1sSWZXK184";

    public LeaveRequestController(LotusTechCrmliveContext context)
    {
        _context = context;
    }

    [HttpPost("Save")]
    public async Task<IActionResult> SaveRequest([FromBody] LeaveRequestModel request)
    {
        if (request == null)
            return BadRequest("Invalid request");

        try
        {
            // 🔁 Convert ViewModel → Entity
            var entity = new TblLeaveRequest
            {
                EmpId = request.EmpId,
                RequestType = request.RequestType,
                LeaveCategory = request.LeaveCategory,
                LeaveType = request.LeaveType,
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                OutTime = request.OutTime,
                DocumentAttachament = request.DocumentAttachament,
                Subject = request.Subject,
                Reason = request.Reason,
                Tlstatus = "Pending",
                Status = "Pending",
                CreatedOn = DateTime.Now,
                CreatedBy = request.EmpId // optional
            };

            // ✅ Backend safety logic
            if (entity.RequestType == "Full Day Leave")
            {
                entity.OutTime = null;
                entity.ToDate ??= entity.FromDate;
            }
            else
            {
                entity.ToDate = null;

                if (entity.OutTime == null)
                {
                    entity.OutTime = entity.RequestType switch
                    {
                        "First Half Day" => new TimeSpan(9, 30, 0),
                        "Second Half Day" => new TimeSpan(14, 0, 0),
                        _ => new TimeSpan(17, 0, 0)
                    };
                }
            }

            // 💾 Save
            _context.TblLeaveRequests.Add(entity);
            await _context.SaveChangesAsync();



            return Ok(new
            {
                success = true,
                message = "Leave request saved successfully",
                id = entity.Id
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                message = ex.Message
            });
        }
    }
    // 2. GET ALL REQUESTS (For Approval Page)
    [HttpGet("GetAllRequests")]
    public async Task<IActionResult> GetAllRequests(string viewType, string? date, int? month, int? year)
    {
        try
        {
            // Joining with Employee table to get Names
            var query = from leave in _context.TblLeaveRequests
                        join emp in _context.TblEmplyeeInfos.Where(e => e.EmployeeStatus == "Active" && e.CompanyId != null && e.VendorMstId == null)
                        on leave.EmpId equals emp.Id
                        select new LeaveRequestModel
                        {
                            Id = leave.Id,
                            EmpId = leave.EmpId,
                            EmpName = emp.Name,
                            RequestType = leave.RequestType,
                            LeaveCategory = leave.LeaveCategory,
                            LeaveType = leave.LeaveType,
                            FromDate = leave.FromDate ?? DateTime.Today,
                            ToDate = leave.ToDate ?? DateTime.MinValue,
                            OutTime = leave.OutTime,
                            Subject = leave.Subject,
                            Reason = leave.Reason,
                            TLStatus = leave.Tlstatus,
                            TLComment = leave.Tlcomment,
                            Status = leave.Status,
                            CreatedOn = leave.CreatedOn, // 👈 ADD THIS LINE
                            HRComment = leave.Hrcomment
                        };

            // Filter by Date View
            if (viewType == "Daily" && DateTime.TryParse(date, out var parsedDate))
            {
                query = query.Where(x => x.FromDate.Date == parsedDate.Date);
            }
            else if (viewType == "Monthly" && month.HasValue && year.HasValue)
            {
                query = query.Where(x => x.FromDate.Month == month && x.FromDate.Year == year);
            }

            var result = await query.OrderByDescending(x => x.Id).ToListAsync();
            return Ok(result);
        }
        catch (Exception ex) { return StatusCode(500, ex.Message); }
    }

    // 3. APPROVE REQUEST
    [HttpPut("Approve/{id}")]
    public async Task<IActionResult> Approve(int id, [FromBody] RejectPayload payload)
    {
        try
        {
            var leave = await _context.TblLeaveRequests.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (leave == null) return NotFound();

            leave.Status = "Approved";
            leave.Hrcomment = payload.HRComment;
            // Optionally set ApprovedBy if you have that column
            // leave.ApprovedBy = adminId; 

            await _context.SaveChangesAsync();
            return Ok(new { success = true, message = "Leave approved" });
        }
        catch (Exception ex) { return StatusCode(500, ex.Message); }
    }

    // 4. REJECT REQUEST
    [HttpPut("Reject/{id}")]
    public async Task<IActionResult> Reject(int id, [FromBody] RejectPayload payload)
    {
        try
        {
            var leave = await _context.TblLeaveRequests.FindAsync(id);
            if (leave == null) return NotFound();

            leave.Status = "Rejected";
            leave.Hrcomment = payload.HRComment; // Set the rejection reason

            await _context.SaveChangesAsync();
            return Ok(new { success = true, message = "Leave rejected" });
        }
        catch (Exception ex) { return StatusCode(500, ex.Message); }
    }

    // Helper class for Reject payload
    public class RejectPayload
    {
        public string HRComment { get; set; } = "";
    }
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _context.TblLeaveRequests
            .FirstOrDefaultAsync(x => x.Id == id && x.Status == "Pending");

        if (existing == null)
            return NotFound();

        _context.TblLeaveRequests.Remove(existing);
        await _context.SaveChangesAsync();

        return Ok(new { success = true });
    }
    [HttpGet("GetTeamRequests")]
    public async Task<IActionResult> GetTeamRequests(int tlId, string viewType, DateTime? date, int? month, int? year)
    {
        try
        {
            List<string> teamDepartments = new List<string>();

            if (tlId == 12)
                teamDepartments.AddRange(new[] { "Development", "Software Testing", "Deployment", "Support", "Sale", "Operation", "Account", "SalesManger", "Post Sale" });
            if (tlId == 10)
                teamDepartments.AddRange(new[] { "Development", "Software Testing", "Deployment" });
            else if (tlId == 1061)
                teamDepartments.Add("Support");
            else if (tlId == 6)
                teamDepartments.AddRange(new[] { "Sale" });
            else if (tlId == 1058)
                teamDepartments.AddRange(new[] { "Operation" });
            // (तुमचे इतर TL Ids जसे 1053, 12, 1047 साठी इथे लॉजिक ऍड करा)

            // १. प्रथम फक्त Join करून IQueryable बनवा (लगेच Select करू नका)
            var query = from req in _context.TblLeaveRequests
                        join emp in _context.TblEmplyeeInfos.Where(e => e.EmployeeStatus == "Active" && e.CompanyId != null && e.VendorMstId == null) on req.EmpId equals emp.Id
                        join dep in _context.TblDepartmentInfos on emp.DepartmentId equals dep.Id
                        where teamDepartments.Contains(dep.Name)
                        select new { req, emp }; // Temporary anonymous object

            // २. ViewType नुसार Date/Month चे फिल्टर लावा (थेट Database Columns वर)
            if (viewType == "Daily" && date.HasValue)
            {
                var targetDate = date.Value.Date;

                // सुधारित Daily Filter: 
                query = query.Where(x =>
                    // जर एका दिवसाची सुट्टी असेल (ToDate null असेल), तर FromDate बरोबर TargetDate असायला हवी
                    (x.req.ToDate == null && x.req.FromDate == targetDate)
                    ||
                    // जर अनेक दिवसांची सुट्टी असेल, तर TargetDate त्या दोन तारखांच्या मध्ये असली पाहिजे
                    (x.req.ToDate != null && x.req.FromDate <= targetDate && x.req.ToDate >= targetDate)
                );
            }
            else if (viewType == "Monthly" && month.HasValue && year.HasValue)
            {
                query = query.Where(x => x.req.FromDate != null &&
                                         x.req.FromDate.Value.Month == month.Value &&
                                         x.req.FromDate.Value.Year == year.Value);
            }

            // ३. सगळ्यात शेवटी Select करून तुमच्या Model मध्ये मॅप करा
            var result = await query.OrderByDescending(x => x.req.FromDate)
                .Select(x => new LeaveRequestModel
                {
                    Id = x.req.Id,
                    EmpId = x.req.EmpId,
                    EmpName = x.emp.Name,
                    LeaveCategory = x.req.LeaveCategory,
                    LeaveType = x.req.LeaveType,
                    RequestType = x.req.RequestType,

                    // इथे null check करून default date सेट करा (Translation Issue टाळण्यासाठी)
                    FromDate = x.req.FromDate ?? DateTime.Today,

                    ToDate = x.req.ToDate,
                    OutTime = x.req.OutTime,
                    Subject = x.req.Subject,
                    Reason = x.req.Reason,
                    Status = x.req.Status,
                    TLStatus = x.req.Tlstatus,
                    TLComment = x.req.Tlcomment,
                    CreatedOn = x.req.CreatedOn // 👈 ADD THIS LINE
                })
                .ToListAsync();

            return Ok(result);
        }
        catch (Exception ex)
        {
            // एरर सविस्तर कळावा म्हणून InnerException पण ऍड केले आहे
            return BadRequest($"API Error: {ex.Message} | Inner: {ex.InnerException?.Message}");
        }
    }
    // ========================================================================
    // 2. TL APPROVE (फक्त TLStatus बदलण्यासाठी)
    // ========================================================================
    [HttpPut("TLApprove/{id}")]
    public async Task<IActionResult> TLApprove(int id)
    {
        try
        {
            var request = await _context.TblLeaveRequests.FindAsync(id);
            if (request == null)
                return NotFound("Leave request not found.");

            // फक्त TLStatus अपडेट करा, मेन 'Status' तसाच राहू द्या (तो HR नंतर 'Approved' करेल)
            request.Tlstatus = "Approved";

            _context.TblLeaveRequests.Update(request);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Leave approved by Team Leader" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    // ========================================================================
    // 3. TL REJECT (TLStatus आणि TLComment बदलण्यासाठी)
    // ========================================================================
    [HttpPut("TLReject/{id}")]
    public async Task<IActionResult> TLReject(int id, [FromBody] TLRejectRequestModel model)
    {
        try
        {
            var request = await _context.TblLeaveRequests.FindAsync(id);
            if (request == null)
                return NotFound("Leave request not found.");

            request.Tlstatus = "Rejected";
            request.Tlcomment = model.TLComment;

            // जर TL ने Reject केले, तर आपण मेन 'Status' पण 'Rejected' करू शकतो, 
            // जेणेकरून HR ला त्यावर ऍक्शन घ्यायची गरज पडणार नाही (तुमच्या बिझनेस लॉजिकनुसार ठरवा).
            // request.Status = "Rejected"; 

            _context.TblLeaveRequests.Update(request);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Leave rejected by Team Leader" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}