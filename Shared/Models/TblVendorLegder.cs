using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblVendorLegder
{
    public int Id { get; set; }

    public int? VendorInvId { get; set; }

    public int? EmpId { get; set; }

    public DateTime? Date { get; set; }

    public decimal? PaidAmt { get; set; }

    public decimal? BalanceAmt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? BillType { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblVendorInvoice? VendorInv { get; set; }
}
