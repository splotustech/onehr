using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblPushSubscription
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public string? Endpoint { get; set; }

    public string? P256dh { get; set; }

    public string? Auth { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? Department { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }
}
