using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblLeadandOpportunitesinfo
{
    public int Id { get; set; }

    public string? ClientName { get; set; }

    public string? FirmName { get; set; }

    public string? Address { get; set; }

    public string? State { get; set; }

    public string? District { get; set; }

    public string? Taluka { get; set; }

    public string? Mob1 { get; set; }

    public string? Mob2 { get; set; }

    public string? Mob3 { get; set; }

    public string? Mob4 { get; set; }

    public string? RefrenceBy { get; set; }

    public string? ClientType { get; set; }

    public int? Productid { get; set; }

    public int? PackageId { get; set; }

    public string? Status { get; set; }

    public string? OrderStatus { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? GramId { get; set; }

    public int? EmpId { get; set; }

    public int? LeadCancelReasonId { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblLeadCancelReasonMst? LeadCancelReason { get; set; }

    public virtual TblPackageInfoMaster? Package { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }

    public virtual ICollection<TblLeadReasonInfo> TblLeadReasonInfos { get; set; } = new List<TblLeadReasonInfo>();

    public virtual ICollection<TblSalesFollowup> TblSalesFollowups { get; set; } = new List<TblSalesFollowup>();

    public virtual ICollection<TblSupportInfo> TblSupportInfos { get; set; } = new List<TblSupportInfo>();
}
