using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblInvoiceMaster
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime? ReceiptDate { get; set; }

    public long? ReceiptNo { get; set; }

    public decimal? NetAmount { get; set; }

    public decimal? InvoiceAmount { get; set; }

    public decimal? PendingAmount { get; set; }

    public decimal? PaidAmount { get; set; }

    public int? GramId { get; set; }

    public string? PaymentType { get; set; }

    public int? BankId { get; set; }

    public string? Chequeno { get; set; }

    public DateTime? Chequedate { get; set; }

    public string? Status { get; set; }

    public decimal? Commission { get; set; }

    public decimal? BalanceAmount { get; set; }

    public string? Utrno { get; set; }

    public string? Narration { get; set; }

    public string? BillType { get; set; }

    public int? BillId { get; set; }

    public int? BillIdWithoutGst { get; set; }

    public string? ReceiptType { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? UpiId { get; set; }

    public string? Neftrtgsref1 { get; set; }

    public string? Neftrtgsref2 { get; set; }

    public int? FirmId { get; set; }

    public int? EmpId { get; set; }

    public int? FreelancerId { get; set; }

    public bool? DeleteStatus { get; set; }

    public virtual TaxableInvoiceMaster? Bill { get; set; }

    public virtual TaxInvoiceMstwithoutGst? BillIdWithoutGstNavigation { get; set; }

    public virtual TblCustomerInfo Customer { get; set; } = null!;

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual FrimInvoiceMaster? Firm { get; set; }

    public virtual TblfreelancerMaster? Freelancer { get; set; }

    public virtual ICollection<TblBalanceMaintain> TblBalanceMaintains { get; set; } = new List<TblBalanceMaintain>();

    public virtual ICollection<TblInvoiceDetail> TblInvoiceDetails { get; set; } = new List<TblInvoiceDetail>();
}
