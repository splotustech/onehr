using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblTdsmaster
{
    public int Id { get; set; }

    public string? PartyName { get; set; }

    public string? MobNo { get; set; }

    public string? PanNo { get; set; }

    public string? Address { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual ICollection<TaxInvoiceMstwithoutGst> TaxInvoiceMstwithoutGsts { get; set; } = new List<TaxInvoiceMstwithoutGst>();

    public virtual ICollection<TaxableInvoiceMaster> TaxableInvoiceMasters { get; set; } = new List<TaxableInvoiceMaster>();

    public virtual TblVendorInfo? VendorMst { get; set; }
}
