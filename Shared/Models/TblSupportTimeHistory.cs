using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSupportTimeHistory
{
    public int Id { get; set; }

    public int? SupportId { get; set; }

    public int? EmpId { get; set; }

    public DateTime? StartDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public DateTime? CompleteDate { get; set; }

    public TimeSpan? CompleteTime { get; set; }

    public string? Remark { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifyOn { get; set; }

    public virtual TblSupportInfo? Support { get; set; }
}
