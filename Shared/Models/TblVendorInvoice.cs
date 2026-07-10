using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblVendorInvoice
{
    public int Id { get; set; }

    public int? VendorMstId { get; set; }

    public int? EmpId { get; set; }

    public string? InvNo { get; set; }

    public DateTime? InvDate { get; set; }

    public DateTime? PaymentDueDate { get; set; }

    public decimal? InvAmt { get; set; }

    public string? Remark { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual ICollection<TblVendorLegder> TblVendorLegders { get; set; } = new List<TblVendorLegder>();

    public virtual TblVendorInfo? VendorMst { get; set; }
}
