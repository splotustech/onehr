using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblDeploymentOnLive
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public int? EmpId { get; set; }

    public DateTime? DeploymentDate { get; set; }

    public string? TaskSubject { get; set; }

    public string? TaskDescription { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblProjectMaster? Project { get; set; }
}
