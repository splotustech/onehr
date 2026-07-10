using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblDailyTaskManagementDetail
{
    public int Id { get; set; }

    public int? TblDailyTaskMstId { get; set; }

    public int? ProjectId { get; set; }

    public int? TaskTypeId { get; set; }

    public string? TaskTitle { get; set; }

    public string? TaskDescription { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public int? DeveloperId { get; set; }

    public virtual TblEmplyeeInfo? Developer { get; set; }

    public virtual TblProjectMaster? Project { get; set; }

    public virtual TblTaskTypeMaster? TaskType { get; set; }

    public virtual TblDailyTaskManagementMst? TblDailyTaskMst { get; set; }
}
