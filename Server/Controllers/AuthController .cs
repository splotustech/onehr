using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMART_HRMS_SYSTEM.Shared.Models;
using SMART_HRMS_SYSTEM.Shared.ViewModel;
using System;
using System.Linq;

namespace SmartHRMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LotusTechCrmliveContext _context;

        public AuthController(LotusTechCrmliveContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestViewModel request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return BadRequest("Username aani Password aavashyak ahe.");

            // Database madhye user check kara
            var user = _context.TblLoginInfos.Include(t=>t.Employee).ThenInclude(t=>t.Department).FirstOrDefault(e =>
                            e.UserName == request.Username &&
                            e.Password == request.Password);

            if (user == null)
            {
                return Unauthorized("Chukicha Username kiva Password!");
            }

            // Login successful jhalya var EmployeeId aani Name return kara
            return Ok(new
            {
                EmployeeId = user.EmployeeId,
                Name = user.Employee.Name,
                Role = user.Role,
                Department = user.Employee.Department.Name,
                MobileNo = user.Employee.MobileNo,
                BirthDay = user.Employee.BirthDate
            });
        }
    }

   
}