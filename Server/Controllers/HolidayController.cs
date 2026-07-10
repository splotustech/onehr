using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMART_HRMS_SYSTEM.Shared.Models;

namespace SMART_HRMS_SYSTEM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly LotusTechCrmliveContext _context;

        public HolidayController(LotusTechCrmliveContext context)
        {
            _context = context;
        }

        [HttpGet("GetByYear")]
        public async Task<IActionResult> GetByYear(int year)
        {
            var holidays = await _context.TblHolidayCalenders
                .Where(h => h.Date.HasValue && h.Date.Value.Year == year)
                .OrderBy(h => h.Date)
                .Select(h => new
                {
                    h.Id,
                    Date        = h.Date!.Value,
                    Name        = h.HolidayName  ?? "",
                    Description = h.HolidayDesc  ?? "",
                    Department  = h.DepartmentId ?? "All"
                })
                .ToListAsync();

            return Ok(holidays);
        }
    }
}
