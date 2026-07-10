using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMART_HRMS_SYSTEM.Shared;
using SMART_HRMS_SYSTEM.Shared.Models;
using SMART_HRMS_SYSTEM.Shared.ViewModel;

namespace SMART_HRMS_SYSTEM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InOutPassController : ControllerBase
    {
        private readonly LotusTechCrmliveContext _context;

        public InOutPassController(LotusTechCrmliveContext context)
        {
            _context = context;
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] TblInOutPass request)
        {
            try
            {
                if (request == null)
                    return BadRequest("Invalid request");

                request.CreatedOn = DateTime.Now;

                // ✅ FIXED: await properly
                var login = await _context.TblLoginInfos
                    .FirstOrDefaultAsync(t => t.EmployeeId == request.Empid);

                request.CreatedBy = login?.Id;

                _context.TblInOutPasses.Add(request);

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = "Out Pass saved successfully"
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
        

        [HttpGet("GetTodayPass/{empId}")]
        public async Task<IActionResult> GetTodayPass(int empId)
        {
            var today = DateTime.Now.Date;

            var result = await _context.TblInOutPasses
                .Where(t => t.Empid == empId
                         && t.Date >= today
                         && t.Date < today.AddDays(1))
                .OrderByDescending(t => t.Id)
                .FirstOrDefaultAsync();

            return Ok(result); // ✅ NO wrapper
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TblInOutPass model)
        {
            try
            {
                if (model == null || id != model.Id)
                    return BadRequest("Invalid data");

                var existing = await _context.TblInOutPasses
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (existing == null)
                    return NotFound("Record not found");

                // ✅ Get UpdatedBy properly (await)
                var updatedBy = await _context.TblLoginInfos
                    .Where(t => t.EmployeeId == model.Empid)
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();

                // ✅ Update fields
                existing.IsReturned = model.IsReturned;
                existing.ReturnedTime = model.ReturnedTime;
                existing.BufferTime = model.BufferTime;
                existing.ReturnedTimeReason = model.ReturnedTimeReason;
                existing.UpdatedOn = DateTime.Now;
                existing.UpdatedBy = updatedBy;
                existing.Status = model.Status;

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = "Return updated successfully"
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

        [HttpGet("GetPassRequests")]
        public async Task<IActionResult> GetPassRequests([FromQuery] string filterType, [FromQuery] DateTime? date, [FromQuery] int? month, [FromQuery] int? year)
        {
            try
            {
                // 1. Query the table and Include the Employee info to get the name
                var query = _context.TblInOutPasses
                    .Include(t => t.Emp)
                    .AsQueryable();

                // 2. Apply the correct date filtering based on UI selection
                if (filterType == "Daily" && date.HasValue)
                {
                    var targetDate = date.Value.Date;
                    query = query.Where(t => t.Date >= targetDate && t.Date < targetDate.AddDays(1));
                }
                else if (filterType == "Monthly" && month.HasValue && year.HasValue)
                {
                    query = query.Where(t => t.Date.HasValue && t.Date.Value.Month == month.Value && t.Date.Value.Year == year.Value);
                }

                // 3. Map to ViewModel and return as a List
                var result = await query
                    .OrderByDescending(t => t.Date).ThenByDescending(t => t.Id)
                    .Select(t => new InOutPassViewModel
                    {
                        Id = t.Id,
                        Empid = t.Empid,
                        EmpName = t.Emp != null ? t.Emp.Name : "Unknown", // Fetches Name from DB Relation
                        Designation = t.Designation,
                        Date = t.Date,
                        OutTime = t.OutTime,
                        InTime = t.InTime,
                        ApproxTime = t.ApproxTime,
                        Reason = t.Reason,
                        Status = t.Status,
                        IsReturned = t.IsReturned,
                        Comment = t.Comment
                    })
                    .ToListAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Reject/{id}")]
        public async Task<IActionResult> Reject(int id, [FromBody] TblInOutPass model)
        {
            var existing = await _context.TblInOutPasses
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existing == null)
                return NotFound();

            existing.Status = "Rejected";
            existing.Comment = model.Comment;
            existing.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _context.TblInOutPasses
                .FirstOrDefaultAsync(x => x.Id == id && x.Status == "Pending");

            if (existing == null)
                return NotFound();

            _context.TblInOutPasses.Remove(existing);
            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }

        [HttpPut("Approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            try
            {
                var existing = await _context.TblInOutPasses
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (existing == null)
                    return NotFound("Record not found");

                // ✅ Get Logged-in user (adjust as per your login system)
                var updatedBy = await _context.TblLoginInfos
                    .Where(x => x.EmployeeId == existing.Empid)
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();

                // ✅ Approve Logic
                existing.Status = "Approved";
                existing.UpdatedOn = DateTime.Now;
                existing.UpdatedBy = updatedBy;

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    success = true,
                    message = "Request approved successfully"
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
    }
}