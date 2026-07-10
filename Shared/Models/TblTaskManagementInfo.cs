using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblTaskManagementInfo
{
    public int Id { get; set; }

    public DateTime? TaskDate { get; set; }

    public int? ProjectId { get; set; }

    public int? TaskTypeId { get; set; }

    public string? TaskTitle { get; set; }

    public string? TaskDescription { get; set; }

    public int? AssignToEmpId { get; set; }

    public DateTime? DeadLine { get; set; }

    public int? StatusId { get; set; }

    public string? AdminStatus { get; set; }

    public int? TaskPriorityId { get; set; }

    public DateTime? CompleteDate { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedById { get; set; }

    public int? ModifyById { get; set; }

    public int? BugRequirementId { get; set; }

    public bool? IsSeenByAssignee { get; set; }

    public string? DeploymentStatus { get; set; }

    public string? TaskBrowseUri { get; set; }

    public string? TaskBrowseImage { get; set; }

    public virtual TblEmplyeeInfo? AssignToEmp { get; set; }

    public virtual TblBugRequirementInfoMaster? BugRequirement { get; set; }

    public virtual TblProjectMaster? Project { get; set; }

    public virtual TblTaskStatusMaster? Status { get; set; }

    public virtual TblTaskPriorityMaster? TaskPriority { get; set; }

    public virtual TblTaskTypeMaster? TaskType { get; set; }

    public virtual ICollection<TblCompletedDeployment> TblCompletedDeployments { get; set; } = new List<TblCompletedDeployment>();

    public virtual ICollection<TblPendingDeployment> TblPendingDeployments { get; set; } = new List<TblPendingDeployment>();

    public virtual ICollection<TblTaskTimeHistory> TblTaskTimeHistories { get; set; } = new List<TblTaskTimeHistory>();

    public virtual ICollection<TblTestcaseDetail> TblTestcaseDetails { get; set; } = new List<TblTestcaseDetail>();
}
