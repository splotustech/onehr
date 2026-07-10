using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMART_HRMS_SYSTEM.Shared;
using SMART_HRMS_SYSTEM.Shared.Models;
using SMART_HRMS_SYSTEM.Shared.ViewModel;
using static SMART_HRMS_SYSTEM.Client.Pages.ManualAttendance;

namespace SMART_HRMS_SYSTEM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly LotusTechCrmliveContext _context;

        public EmployeeController(LotusTechCrmliveContext context)
        {
            _context = context;
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> GetEmployeeList()
        {
            var result = await _context.TblEmplyeeInfos.Where(t => t.EmployeeStatus == "Active" && t.CompanyId != null && t.VendorMstId == null)
                .Select(x => new EmployeeDropdownModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();

            return Ok(result); // ✅ correct
        }

    }
}