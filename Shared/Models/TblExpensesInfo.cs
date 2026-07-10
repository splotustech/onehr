using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblExpensesInfo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? EmpId { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual ICollection<TblExpensesDetail> TblExpensesDetails { get; set; } = new List<TblExpensesDetail>();

    public virtual ICollection<TblExpensesMaintain> TblExpensesMaintains { get; set; } = new List<TblExpensesMaintain>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
