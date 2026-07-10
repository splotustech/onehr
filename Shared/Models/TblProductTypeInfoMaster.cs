using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblProductTypeInfoMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Hsnno { get; set; }

    public bool? Status { get; set; }

    public int? CompanyId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual ICollection<QuatationInvoiceDetailWithGst> QuatationInvoiceDetailWithGsts { get; set; } = new List<QuatationInvoiceDetailWithGst>();

    public virtual ICollection<QuotationInvDetialWithoutGst> QuotationInvDetialWithoutGsts { get; set; } = new List<QuotationInvDetialWithoutGst>();

    public virtual ICollection<TaxInvoiceDetailWithoutGst> TaxInvoiceDetailWithoutGsts { get; set; } = new List<TaxInvoiceDetailWithoutGst>();

    public virtual ICollection<TaxableInvoiceDetail> TaxableInvoiceDetails { get; set; } = new List<TaxableInvoiceDetail>();

    public virtual ICollection<TblCustomerInfo> TblCustomerInfos { get; set; } = new List<TblCustomerInfo>();

    public virtual ICollection<TblCustomerOnboardingMst> TblCustomerOnboardingMsts { get; set; } = new List<TblCustomerOnboardingMst>();

    public virtual ICollection<TblCustomerTraining> TblCustomerTrainings { get; set; } = new List<TblCustomerTraining>();

    public virtual ICollection<TblInvoiceDetail> TblInvoiceDetails { get; set; } = new List<TblInvoiceDetail>();

    public virtual ICollection<TblLeadandOpportunitesinfo> TblLeadandOpportunitesinfos { get; set; } = new List<TblLeadandOpportunitesinfo>();

    public virtual ICollection<TblObjectionMst> TblObjectionMsts { get; set; } = new List<TblObjectionMst>();

    public virtual ICollection<TblPackageInfoMaster> TblPackageInfoMasters { get; set; } = new List<TblPackageInfoMaster>();

    public virtual ICollection<TblProformaInvoiceDetailWithoutGst> TblProformaInvoiceDetailWithoutGsts { get; set; } = new List<TblProformaInvoiceDetailWithoutGst>();

    public virtual ICollection<TblProformaInvoiceDetail> TblProformaInvoiceDetails { get; set; } = new List<TblProformaInvoiceDetail>();

    public virtual ICollection<TblQuestionAnswerMaster> TblQuestionAnswerMasters { get; set; } = new List<TblQuestionAnswerMaster>();

    public virtual ICollection<TblSaleTeamTargetDetail> TblSaleTeamTargetDetails { get; set; } = new List<TblSaleTeamTargetDetail>();

    public virtual ICollection<TblSalesTeamTarget> TblSalesTeamTargets { get; set; } = new List<TblSalesTeamTarget>();

    public virtual ICollection<TblSecurityDdetail> TblSecurityDdetails { get; set; } = new List<TblSecurityDdetail>();

    public virtual ICollection<TblTitleMaster> TblTitleMasters { get; set; } = new List<TblTitleMaster>();

    public virtual ICollection<TblfreelancerRatechartDetail> TblfreelancerRatechartDetails { get; set; } = new List<TblfreelancerRatechartDetail>();
}
