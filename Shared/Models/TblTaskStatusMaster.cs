using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblTaskStatusMaster
{
    public int Id { get; set; }

    public string? TaskStatus { get; set; }

    public string? TaskStatusStyling { get; set; }

    public virtual ICollection<TblGpWebsiteInternalStatus> TblGpWebsiteInternalStatuses { get; set; } = new List<TblGpWebsiteInternalStatus>();

    public virtual ICollection<TblTaskManagementInfo> TblTaskManagementInfos { get; set; } = new List<TblTaskManagementInfo>();
}
