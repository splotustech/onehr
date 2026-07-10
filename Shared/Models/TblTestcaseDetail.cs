using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblTestcaseDetail
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public int? TestcaseNo { get; set; }

    public string? TestcaseTitle { get; set; }

    public string? TestcaseDescription { get; set; }

    public string? TestcaseUrl { get; set; }

    public string? ImageName { get; set; }

    public string? ImageUrl { get; set; }

    public string? Status { get; set; }

    public int? CreatedById { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? ExpectedResult { get; set; }

    public int? EmployeeId { get; set; }

    public string? Comment { get; set; }

    public int? TaskNo { get; set; }

    public DateTime? Date { get; set; }

    public string? TestCaseStatus { get; set; }

    public virtual TblEmplyeeInfo? Employee { get; set; }

    public virtual TblProjectMaster? Project { get; set; }

    public virtual TblTaskManagementInfo? TaskNoNavigation { get; set; }
}
