using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblExpensesMaintain
{
    public int Id { get; set; }

    public long? ExpensesNo { get; set; }

    public DateTime? ExpensesDate { get; set; }

    public string? GroupName { get; set; }

    public int? ExpensesId { get; set; }

    public string? FromPersonName { get; set; }

    public string? ToPersonName { get; set; }

    public string? Reason { get; set; }

    public string? PaymentType { get; set; }

    public int? BankId { get; set; }

    public string? ChequeNo { get; set; }

    public DateTime? CheckDate { get; set; }

    public string? UtrNo { get; set; }

    public string? Upiid { get; set; }

    public string? NeftRtgsref1 { get; set; }

    public string? NeftRtgsref2 { get; set; }

    public string? TransactionYear { get; set; }

    public decimal? PaidAmount { get; set; }

    public string? Narration { get; set; }

    public int? EmpId { get; set; }

    public int? GramId { get; set; }

    public int? CustomerId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? FirmId { get; set; }

    public string? TransactionType { get; set; }

    public int? ExpensesSubTypeId { get; set; }

    public bool? AdvancePayment { get; set; }

    public decimal? AdvanceAmount { get; set; }

    public bool? AdvExpensesStatus { get; set; }

    public string? AdvExpensesIds { get; set; }

    public virtual TblBankInfo? Bank { get; set; }

    public virtual TblCustomerInfo? Customer { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblExpensesInfo? Expenses { get; set; }

    public virtual TblExpensesDetail? ExpensesSubType { get; set; }

    public virtual FrimInvoiceMaster? Firm { get; set; }

    public virtual ICollection<TblBalanceMaintain> TblBalanceMaintains { get; set; } = new List<TblBalanceMaintain>();
}
