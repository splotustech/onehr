using SMART_HRMS_SYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    public class MonthlySummaryModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }

        public decimal Present { get; set; }
        public decimal Absent { get; set; }
        public decimal LateMark { get; set; }
        public decimal WeekOff { get; set; }
        public decimal HalfDay { get; set; }
        public decimal EarlyDeparture { get; set; }
        public decimal PaidLeave { get; set; }
    }
}
