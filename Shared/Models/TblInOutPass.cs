using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblInOutPass
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

    public int? Empid { get; set; }

    public bool? IsReturned { get; set; }

    public TimeSpan? BufferTime { get; set; }

    public TimeSpan? ReturnedTime { get; set; }

    public string? ReturnedTimeReason { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }
}
