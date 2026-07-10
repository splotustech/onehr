using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSupportInfo
{
    public int Id { get; set; }

    public int? LeadAndOppId { get; set; }

    public int? CustomerId { get; set; }

    public int? SupportTypeId { get; set; }

    public TimeSpan? FollowupTime { get; set; }

    public DateTime? FollowupDate { get; set; }

    public string? Status { get; set; }

    public string? Description { get; set; }

    public bool? PickedSupportStatus { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Priority { get; set; }

    public int? GramId { get; set; }

    public int? EmpId { get; set; }

    public string? SupportMode { get; set; }

    public string? PendingType { get; set; }

    public virtual TblCustomerInfo? Customer { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblLeadandOpportunitesinfo? LeadAndOpp { get; set; }

    public virtual TblSupportTypeInfoMaster? SupportType { get; set; }

    public virtual ICollection<TblSupportTimeHistory> TblSupportTimeHistories { get; set; } = new List<TblSupportTimeHistory>();
}
