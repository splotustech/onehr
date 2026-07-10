using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblPendingDeployment
{
    public int Id { get; set; }

    public int? TaskId { get; set; }

    public int? EmpId { get; set; }

    public DateTime? TaskCompleteDate { get; set; }

    public string? BranchName { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? Environment { get; set; }

    public int? ResponsibleEmpforLiveDeployment { get; set; }

    public string? Note { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblTaskManagementInfo? Task { get; set; }

    public virtual ICollection<TblCompletedDeployment> TblCompletedDeployments { get; set; } = new List<TblCompletedDeployment>();
}
