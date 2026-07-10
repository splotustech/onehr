using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblTaskTimeHistory
{
    public int Id { get; set; }

    public int? TaskId { get; set; }

    public int? AssignToEmpId { get; set; }

    public DateTime? StartDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public DateTime? PauseDate { get; set; }

    public TimeSpan? PauseTime { get; set; }

    public TimeSpan? TimerDisplay { get; set; }

    public string? Remark { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifyOn { get; set; }

    public virtual TblTaskManagementInfo? Task { get; set; }
}
