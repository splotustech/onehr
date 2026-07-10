using SMART_HRMS_SYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    public class ManualAttendanceModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateTime AttendanceDate { get; set; }

        // Nullable कारण कधी punch-in/out नसू शकतो
        public DateTime? PunchInTime { get; set; }

        public DateTime? PunchOutTime { get; set; }

        public string? WorkMode { get; set; } // Office / WFH / Field

        public string? Remarks { get; set; }

        public bool IsManualEntry { get; set; } = true;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
