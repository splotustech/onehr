using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblProformaInvoiceDetail
{
    public int Id { get; set; }

    public int? ProformaInvoiceMasterId { get; set; }

    public int? ProductId { get; set; }

    public int? PakageId { get; set; }

    public decimal? Quantity { get; set; }

    public decimal? Rate { get; set; }

    public decimal? Amount { get; set; }

    public decimal? Discount { get; set; }

    public decimal? TexableAmount { get; set; }

    public decimal? Gst { get; set; }

    public decimal? NetAmount { get; set; }

    public bool? FreeProduct { get; set; }

    public string? FreeProductIds { get; set; }

    public virtual TblPackageInfoMaster? Pakage { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }

    public virtual TblProformaInvoiceMaster? ProformaInvoiceMaster { get; set; }
}
