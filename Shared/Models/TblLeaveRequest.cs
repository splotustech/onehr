using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblLeaveRequest
{
    public int Id { get; set; }

    public int EmpId { get; set; }

    public string LeaveCategory { get; set; } = null!;

    public string LeaveType { get; set; } = null!;

    public string RequestType { get; set; } = null!;

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public TimeSpan? OutTime { get; set; }

    public string? Subject { get; set; }

    public string? Reason { get; set; }

    public string Status { get; set; } = null!;

    public string? Hrcomment { get; set; }

    public DateTime CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public string? DocumentAttachament { get; set; }

    public string? Tlstatus { get; set; }

    public string? Tlcomment { get; set; }

    public virtual TblEmplyeeInfo Emp { get; set; } = null!;
}
