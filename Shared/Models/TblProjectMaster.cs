using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblProjectMaster
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string? ProjectName { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<TblBugRequirementInfoMaster> TblBugRequirementInfoMasters { get; set; } = new List<TblBugRequirementInfoMaster>();

    public virtual ICollection<TblDailyTaskManagementDetail> TblDailyTaskManagementDetails { get; set; } = new List<TblDailyTaskManagementDetail>();

    public virtual ICollection<TblDeploymentOnLive> TblDeploymentOnLives { get; set; } = new List<TblDeploymentOnLive>();

    public virtual ICollection<TblNotificationMaster> TblNotificationMasters { get; set; } = new List<TblNotificationMaster>();

    public virtual ICollection<TblTaskManagementInfo> TblTaskManagementInfos { get; set; } = new List<TblTaskManagementInfo>();

    public virtual ICollection<TblTestcaseDetail> TblTestcaseDetails { get; set; } = new List<TblTestcaseDetail>();
}
