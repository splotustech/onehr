using SMART_HRMS_SYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{

    public class AttendanceRecordViewModel
    {
        public string Date { get; set; }
        public string DayName { get; set; }
        public string PunchIn { get; set; }
        public string PunchOut { get; set; }
        public string WorkMode { get; set; }
        public string TotalHours { get; set; }
    }


}
