using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblBugRequirementInfoMaster
{
    public int Id { get; set; }

    public int? GramId { get; set; }

    public int? CustomerId { get; set; }

    public int? EmpId { get; set; }

    public int? DeveloperId { get; set; }

    public string? BrowseUri { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? BrowseImage { get; set; }

    public string? RequirmentandBugTitle { get; set; }

    public string? Requirement { get; set; }

    public string? RequirementBugDetails { get; set; }

    public string? RequirementStatus { get; set; }

    public DateTime? RequirementDate { get; set; }

    public int? ProjectId { get; set; }

    public string? CommentofInvalid { get; set; }

    public DateTime? DeadLineDate { get; set; }

    public string? SeenEmpId { get; set; }

    public string? NoDeploymentDescription { get; set; }

    public virtual TblCustomerInfo? Customer { get; set; }

    public virtual TblEmplyeeInfo? Developer { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblProjectMaster? Project { get; set; }

    public virtual ICollection<TblTaskManagementInfo> TblTaskManagementInfos { get; set; } = new List<TblTaskManagementInfo>();
}
