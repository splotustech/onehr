using SMART_HRMS_SYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    public class DayWiseModel
    {
        public string EmployeeName { get; set; }
        public List<string> Days { get; set; }
    }
}
