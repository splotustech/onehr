using SMART_HRMS_SYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    public class LeaveRequestModel
    {
        public int? Id { get; set; }
        public int EmpId { get; set; }
        public string EmpName { get; set; } = ""; // To show who applied
        public string RequestType { get; set; } = "Full Day Leave";
        public string LeaveCategory { get; set; } = "Casual";
        public string LeaveType { get; set; } = "Paid";
        public DateTime FromDate { get; set; } = DateTime.Today;
        public DateTime? ToDate { get; set; } = DateTime.Today;
        public TimeSpan? OutTime { get; set; }
        public string Subject { get; set; } = "";
        public string Reason { get; set; } = "";
        public string Status { get; set; } = "Pending";
        public DateTime? CreatedOn { get; set; }
        public string? DocumentAttachament { get; set; }
        public string? HRComment
        {
            get; set;
        }
        // नवीन Properties ऍड करा:
        public string? TLStatus { get; set; } = "Pending";
        public string? TLComment { get; set; }
    }
}
