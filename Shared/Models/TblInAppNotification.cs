using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblInAppNotification
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public TimeSpan? Time { get; set; }

    public DateTime? Date { get; set; }

    public string? Message { get; set; }

    public bool? IsSeenNotification { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }
}
