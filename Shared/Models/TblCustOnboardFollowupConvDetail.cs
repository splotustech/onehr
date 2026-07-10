using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblCustOnboardFollowupConvDetail
{
    public int Id { get; set; }

    public int? CustOnboardingDetailsid { get; set; }

    public DateTime? FollowupDate { get; set; }

    public string? Converstion { get; set; }

    public int? Empid { get; set; }

    public DateTime? CreatedOndate { get; set; }

    public bool? DeleteStatus { get; set; }

    public virtual TblCustomerOnboardingDetail? CustOnboardingDetails { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }
}
