using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblTaskTypeMaster
{
    public int Id { get; set; }

    public string? TaskType { get; set; }

    public virtual ICollection<TblDailyTaskManagementDetail> TblDailyTaskManagementDetails { get; set; } = new List<TblDailyTaskManagementDetail>();

    public virtual ICollection<TblTaskManagementInfo> TblTaskManagementInfos { get; set; } = new List<TblTaskManagementInfo>();
}
