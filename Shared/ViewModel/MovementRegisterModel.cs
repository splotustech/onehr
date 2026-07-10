using SMART_HRMS_SYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    public class MovementRegisterModel
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public DateTime LogDate { get; set; } = DateTime.Today;

        public TimeSpan? ExitTime { get; set; }
        public TimeSpan? EntryTime { get; set; }

        public string? Reason { get; set; } // उदा: "Tea Break", "Lunch", "Quick Work"

        public int? DurationMinutes { get; set; } // Calculation साठी

        // UI साठी Helper Property
        public string DurationFormatted => DurationMinutes.HasValue
            ? $"{DurationMinutes / 60}h {DurationMinutes % 60}m"
            : "---";
    }
}
