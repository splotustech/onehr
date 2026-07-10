using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblPackageInfoMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? Validity { get; set; }

    public int? ProductId { get; set; }

    public int? CompanyId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }

    public virtual ICollection<QuatationInvoiceDetailWithGst> QuatationInvoiceDetailWithGsts { get; set; } = new List<QuatationInvoiceDetailWithGst>();

    public virtual ICollection<QuotationInvDetialWithoutGst> QuotationInvDetialWithoutGsts { get; set; } = new List<QuotationInvDetialWithoutGst>();

    public virtual ICollection<TaxInvoiceDetailWithoutGst> TaxInvoiceDetailWithoutGsts { get; set; } = new List<TaxInvoiceDetailWithoutGst>();

    public virtual ICollection<TaxableInvoiceDetail> TaxableInvoiceDetails { get; set; } = new List<TaxableInvoiceDetail>();

    public virtual ICollection<TblCustomerInfo> TblCustomerInfos { get; set; } = new List<TblCustomerInfo>();

    public virtual ICollection<TblInvoiceDetail> TblInvoiceDetails { get; set; } = new List<TblInvoiceDetail>();

    public virtual ICollection<TblLeadandOpportunitesinfo> TblLeadandOpportunitesinfos { get; set; } = new List<TblLeadandOpportunitesinfo>();

    public virtual ICollection<TblProformaInvoiceDetailWithoutGst> TblProformaInvoiceDetailWithoutGsts { get; set; } = new List<TblProformaInvoiceDetailWithoutGst>();

    public virtual ICollection<TblProformaInvoiceDetail> TblProformaInvoiceDetails { get; set; } = new List<TblProformaInvoiceDetail>();

    public virtual ICollection<TblSecurityDdetail> TblSecurityDdetails { get; set; } = new List<TblSecurityDdetail>();

    public virtual ICollection<TblfreelancerRatechartDetail> TblfreelancerRatechartDetails { get; set; } = new List<TblfreelancerRatechartDetail>();
}
