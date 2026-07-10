using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TaxableInvoiceMaster
{
    public int Id { get; set; }

    public string? InvoiceNo { get; set; }

    public int? GramId { get; set; }

    public int? FirmId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? InvDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? CommissionAmt { get; set; }

    public decimal? NetAmount { get; set; }

    public int? EmpId { get; set; }

    public int? AgentId { get; set; }

    public int? StategyId { get; set; }

    public int? CreatedbyId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedbyId { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public decimal? PaidAmount { get; set; }

    public decimal? BaseCommissionAmt { get; set; }

    public decimal? GstonCommissionAmt { get; set; }

    public decimal? Tds { get; set; }

    public decimal? FinalCommissionAmt { get; set; }

    public int? Tdsid { get; set; }

    public decimal? OurInvoiceAmount { get; set; }

    public int? FreelancerId { get; set; }

    public bool? DeleteStatus { get; set; }

    public DateTime? GpInvDate { get; set; }

    public string? GpInvNo { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblAgentInfoMaster? Agent { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblCustomerInfo? Customer { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual FrimInvoiceMaster? Firm { get; set; }

    public virtual TblfreelancerMaster? Freelancer { get; set; }

    public virtual TblStategyMaster? Stategy { get; set; }

    public virtual ICollection<TaxableInvoiceDetail> TaxableInvoiceDetails { get; set; } = new List<TaxableInvoiceDetail>();

    public virtual ICollection<TblInvoiceMaster> TblInvoiceMasters { get; set; } = new List<TblInvoiceMaster>();

    public virtual ICollection<TblSddetailsForTaxInv> TblSddetailsForTaxInvs { get; set; } = new List<TblSddetailsForTaxInv>();

    public virtual TblTdsmaster? TdsNavigation { get; set; }

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
