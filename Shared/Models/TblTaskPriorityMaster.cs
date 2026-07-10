using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblTaskPriorityMaster
{
    public int Id { get; set; }

    public string? TaskPriority { get; set; }

    public virtual ICollection<TblTaskManagementInfo> TblTaskManagementInfos { get; set; } = new List<TblTaskManagementInfo>();
}
