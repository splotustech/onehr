using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblOtherIncome
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public long? RecieptNo { get; set; }

    public int? GramId { get; set; }

    public int? FirmId { get; set; }

    public int? CustomerId { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentMode { get; set; }

    public int? Bankid { get; set; }

    public string? ChequeNo { get; set; }

    public DateTime? ChequeDate { get; set; }

    public string? UtrNo { get; set; }

    public string? Upiid { get; set; }

    public string? Narration { get; set; }

    public string? NeftRtgsref1 { get; set; }

    public string? NeftRtgsref2 { get; set; }

    public int? CreatedById { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? EmpId { get; set; }

    public string? Status { get; set; }

    public int? FreelancerId { get; set; }

    public bool? AdvancePayment { get; set; }

    public int? CompanyId { get; set; }

    public decimal? InvoiceAmount { get; set; }

    public decimal? BalanceAmount { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblCustomerInfo? Customer { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual FrimInvoiceMaster? Firm { get; set; }

    public virtual TblfreelancerMaster? Freelancer { get; set; }

    public virtual ICollection<TblBalanceMaintain> TblBalanceMaintains { get; set; } = new List<TblBalanceMaintain>();

    public virtual ICollection<TblSddetailsForTaxInv> TblSddetailsForTaxInvs { get; set; } = new List<TblSddetailsForTaxInv>();

    public virtual ICollection<TblSecuriteDepositeReturn> TblSecuriteDepositeReturns { get; set; } = new List<TblSecuriteDepositeReturn>();

    public virtual ICollection<TblSecurityDdetail> TblSecurityDdetails { get; set; } = new List<TblSecurityDdetail>();
}
