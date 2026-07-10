using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSecuriteDepositeReturn
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? VoucherNo { get; set; }

    public int? SecuriteDepositeNo { get; set; }

    public int? GramId { get; set; }

    public int? ClientId { get; set; }

    public int? FirmId { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentMode { get; set; }

    public string? ChequeNo { get; set; }

    public DateTime? ChequeDate { get; set; }

    public string? Utrno { get; set; }

    public string? Upiid { get; set; }

    public string? Narrition { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? EmpId { get; set; }

    public int? CompanyId { get; set; }

    public virtual TblCustomerInfo? Client { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual FrimInvoiceMaster? Firm { get; set; }

    public virtual TblOtherIncome? SecuriteDepositeNoNavigation { get; set; }

    public virtual ICollection<TblBalanceMaintain> TblBalanceMaintains { get; set; } = new List<TblBalanceMaintain>();
}
