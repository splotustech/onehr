using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblExpensesDetail
{
    public int Id { get; set; }

    public int? ExpensesMstId { get; set; }

    public string? ExpensesSubType { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblExpensesInfo? ExpensesMst { get; set; }

    public virtual ICollection<TblExpensesMaintain> TblExpensesMaintains { get; set; } = new List<TblExpensesMaintain>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
