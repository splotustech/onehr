using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblCompletedDeployment
{
    public int Id { get; set; }

    public int? PendingDeploymentId { get; set; }

    public int? TaskId { get; set; }

    public DateTime? DeploymentDate { get; set; }

    public int? DeploymentEmpId { get; set; }

    public string? DeploymentEnvironment { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual TblEmplyeeInfo? DeploymentEmp { get; set; }

    public virtual TblPendingDeployment? PendingDeployment { get; set; }

    public virtual TblTaskManagementInfo? Task { get; set; }
}
