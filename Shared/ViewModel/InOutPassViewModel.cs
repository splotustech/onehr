using SMART_HRMS_SYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    public class InOutPassViewModel
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string? Designation { get; set; }

        public string? MobileNo { get; set; }

        public TimeSpan? ApproxTime { get; set; }

        public TimeSpan? OutTime { get; set; }

        public TimeSpan? InTime { get; set; }

        public string? Reason { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string? Status { get; set; }

        public string? Comment { get; set; }
        public string? EmpName { get; set; }

        public int? Empid { get; set; }

        public bool? IsReturned { get; set; }

        public TimeSpan? BufferTime { get; set; }

        public TimeSpan? ReturnedTime { get; set; }

        public string? ReturnedTimeReason { get; set; }

        public virtual TblEmplyeeInfo? Emp { get; set; }
    }
}
