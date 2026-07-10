using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblStategyMaster
{
    public int Id { get; set; }

    public string? StategyName { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? EmpId { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual ICollection<QuatationInvoiceMstWithGst> QuatationInvoiceMstWithGsts { get; set; } = new List<QuatationInvoiceMstWithGst>();

    public virtual ICollection<QuotationMstWithoutGst> QuotationMstWithoutGsts { get; set; } = new List<QuotationMstWithoutGst>();

    public virtual ICollection<TaxInvoiceMstwithoutGst> TaxInvoiceMstwithoutGsts { get; set; } = new List<TaxInvoiceMstwithoutGst>();

    public virtual ICollection<TaxableInvoiceMaster> TaxableInvoiceMasters { get; set; } = new List<TaxableInvoiceMaster>();

    public virtual ICollection<TblProformaInvoiceMaster> TblProformaInvoiceMasters { get; set; } = new List<TblProformaInvoiceMaster>();

    public virtual ICollection<TblProformaInvoiceMstWithoutGst> TblProformaInvoiceMstWithoutGsts { get; set; } = new List<TblProformaInvoiceMstWithoutGst>();

    public virtual ICollection<TblSalesFollowup> TblSalesFollowups { get; set; } = new List<TblSalesFollowup>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
