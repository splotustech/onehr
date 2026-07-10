using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblGramsevakFollowUpMobileApp
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public int? GramsevakId { get; set; }

    public string? FollowUpNote { get; set; }

    public DateTime? NextFollowUpDate { get; set; }

    public string? Gpname { get; set; }

    public string? Talukha { get; set; }

    public string? District { get; set; }

    public string? Gsname { get; set; }

    public string? ContectNo { get; set; }

    public int? GramId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }
}
