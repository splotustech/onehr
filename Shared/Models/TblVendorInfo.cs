using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblVendorInfo
{
    public int Id { get; set; }

    public string? VendorName { get; set; }

    public string? ContactPersonName { get; set; }

    public string? ContactNumber { get; set; }

    public string? EmailId { get; set; }

    public string? BussinessType { get; set; }

    public string? Address { get; set; }

    public string? Note { get; set; }

    public string? VendorId { get; set; }

    public string? Gstno { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<TblTdsmaster> TblTdsmasters { get; set; } = new List<TblTdsmaster>();

    public virtual ICollection<TblVendorInvoice> TblVendorInvoices { get; set; } = new List<TblVendorInvoice>();
}
