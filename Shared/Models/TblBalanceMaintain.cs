using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblBalanceMaintain
{
    public int Id { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string? Particular { get; set; }

    public int? ExpenseId { get; set; }

    public int? LedgerId { get; set; }

    public int? FirmId { get; set; }

    public int? OtherIncomeId { get; set; }

    public decimal? CreditAmt { get; set; }

    public decimal? DebitAmt { get; set; }

    public decimal? Balance { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Type { get; set; }

    public int? SecuriteDepoReturnId { get; set; }

    public bool? DeleteStatus { get; set; }

    public string? PaymentType { get; set; }

    public virtual TblExpensesMaintain? Expense { get; set; }

    public virtual FrimInvoiceMaster? Firm { get; set; }

    public virtual TblInvoiceMaster? Ledger { get; set; }

    public virtual TblOtherIncome? OtherIncome { get; set; }

    public virtual TblSecuriteDepositeReturn? SecuriteDepoReturn { get; set; }
}
