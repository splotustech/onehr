using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblInvoiceDetail
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int? ProductId { get; set; }

    public int? PackageId { get; set; }

    public decimal? Qty { get; set; }

    public decimal? Rate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual TblInvoiceMaster Invoice { get; set; } = null!;

    public virtual TblPackageInfoMaster? Package { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }
}
