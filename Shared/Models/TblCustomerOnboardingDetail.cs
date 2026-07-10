using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblCustomerOnboardingDetail
{
    public int Id { get; set; }

    public int? CustOnboardingMstId { get; set; }

    public int? TitleMstId { get; set; }

    public bool? DoneorNot { get; set; }

    public DateTime? CompletedDate { get; set; }

    public int? EmpId { get; set; }

    public bool? DeleteStatus { get; set; }

    public bool? SkipStatus { get; set; }

    public string? SkipReason { get; set; }

    public virtual TblCustomerOnboardingMst? CustOnboardingMst { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual ICollection<TblCustOnboardFollowupConvDetail> TblCustOnboardFollowupConvDetails { get; set; } = new List<TblCustOnboardFollowupConvDetail>();

    public virtual TblTitleMaster? TitleMst { get; set; }
}
