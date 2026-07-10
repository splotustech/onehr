using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class QuatationInvoiceDetailWithGst
{
    public int Id { get; set; }

    public int? QuatationInvId { get; set; }

    public int? ProductId { get; set; }

    public int? PackageId { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Rate { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Discount { get; set; }

    public decimal? TaxableAmount { get; set; }

    public decimal? Gst { get; set; }

    public decimal? NetAmount { get; set; }

    public bool? FreeProduct { get; set; }

    public string? FreeProductIds { get; set; }

    public virtual TblPackageInfoMaster? Package { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }

    public virtual QuatationInvoiceMstWithGst? QuatationInv { get; set; }
}
