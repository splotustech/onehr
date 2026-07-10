using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblLeadCancelReasonMst
{
    public int Id { get; set; }

    public string? ClientType { get; set; }

    public string? LeadCancelReason { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual ICollection<TblLeadandOpportunitesinfo> TblLeadandOpportunitesinfos { get; set; } = new List<TblLeadandOpportunitesinfo>();

    public virtual ICollection<TblSalesFollowup> TblSalesFollowups { get; set; } = new List<TblSalesFollowup>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
