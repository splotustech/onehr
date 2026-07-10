using SMART_HRMS_SYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    public partial class AttendanceLogViewModel
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public DateTime? PunchInTime { get; set; }

        public DateTime? PunchOutTime { get; set; }

        public double PunchInLat { get; set; }

        public double PunchInLong { get; set; }

        public double? PunchOutLat { get; set; }

        public double? PunchOutLong { get; set; }

        public string WorkMode { get; set; } = null!;

        public virtual TblEmplyeeInfo Employee { get; set; } = null!;
    }
}
