using SMART_HRMS_SYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    public class HrAttendanceModel
    {
        public string EmpName { get; set; }
        public string Department { get; set; }
        public DateTime Date { get; set; }
        public DateTime? PunchInTime { get; set; }
        public DateTime? PunchOutTime { get; set; }
        public string TotalHours { get; set; }
        public string Status { get; set; }
        public string WorkMode { get; set; }
    }
}
