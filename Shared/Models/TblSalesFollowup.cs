using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSalesFollowup
{
    public int Id { get; set; }

    public int? LeadAndOppId { get; set; }

    public int? FollowupTypeId { get; set; }

    public string? ConversationText { get; set; }

    public DateTime? FollowupDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? LeadOppoStatus { get; set; }

    public int? SaleFollowupTypeId { get; set; }

    public string? ClientType { get; set; }

    public int? LeadCancelReasonId { get; set; }

    public int? StategyId { get; set; }

    public virtual TblEmplyeeInfo? CreatedByNavigation { get; set; }

    public virtual TblFollowupTypeMaster? FollowupType { get; set; }

    public virtual TblLeadandOpportunitesinfo? LeadAndOpp { get; set; }

    public virtual TblLeadCancelReasonMst? LeadCancelReason { get; set; }

    public virtual TblSaleDepFollowUpTypeMaster? SaleFollowupType { get; set; }

    public virtual TblStategyMaster? Stategy { get; set; }

    public virtual TblEmplyeeInfo? UpdatedByNavigation { get; set; }
}
