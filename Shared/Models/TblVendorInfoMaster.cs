using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblVendorInfoMaster
{
    public int Id { get; set; }

    public string? VendorName { get; set; }

    public string? VendorGstnumber { get; set; }

    public string? VendorMobileNo { get; set; }

    public string? VendorFirmName { get; set; }

    public string? VendorMail { get; set; }

    public string? VendorAddress { get; set; }

    public string? VendorNote { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? PinCode { get; set; }

    public string? VendorMobileNo2 { get; set; }

    public bool? IsGstRegister { get; set; }

    public string? BankAddress { get; set; }

    public string? BankName { get; set; }

    public string? Ifsccode { get; set; }

    public string? AccountNo { get; set; }

    public string? BranchName { get; set; }

    public string? AccountType { get; set; }

    public string? CompanyLogoUrl { get; set; }

    public string? ComplanyLogoName { get; set; }

    public string? VendorMail2 { get; set; }

    public int? CompanyId { get; set; }

    public string? AccountHolderName { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual ICollection<Designation> Designations { get; set; } = new List<Designation>();

    public virtual ICollection<FrimInvoiceMaster> FrimInvoiceMasters { get; set; } = new List<FrimInvoiceMaster>();

    public virtual ICollection<QuatationInvoiceMstWithGst> QuatationInvoiceMstWithGsts { get; set; } = new List<QuatationInvoiceMstWithGst>();

    public virtual ICollection<QuotationMstWithoutGst> QuotationMstWithoutGsts { get; set; } = new List<QuotationMstWithoutGst>();

    public virtual ICollection<TaxInvoiceMstwithoutGst> TaxInvoiceMstwithoutGsts { get; set; } = new List<TaxInvoiceMstwithoutGst>();

    public virtual ICollection<TaxableInvoiceMaster> TaxableInvoiceMasters { get; set; } = new List<TaxableInvoiceMaster>();

    public virtual ICollection<TblAgentInfoMaster> TblAgentInfoMasters { get; set; } = new List<TblAgentInfoMaster>();

    public virtual ICollection<TblBankInfo> TblBankInfos { get; set; } = new List<TblBankInfo>();

    public virtual ICollection<TblCustomerInfo> TblCustomerInfos { get; set; } = new List<TblCustomerInfo>();

    public virtual ICollection<TblCustomerOnboardingMst> TblCustomerOnboardingMsts { get; set; } = new List<TblCustomerOnboardingMst>();

    public virtual ICollection<TblDepartmentInfo> TblDepartmentInfos { get; set; } = new List<TblDepartmentInfo>();

    public virtual ICollection<TblEmplyeeInfo> TblEmplyeeInfos { get; set; } = new List<TblEmplyeeInfo>();

    public virtual ICollection<TblExpensesDetail> TblExpensesDetails { get; set; } = new List<TblExpensesDetail>();

    public virtual ICollection<TblExpensesInfo> TblExpensesInfos { get; set; } = new List<TblExpensesInfo>();

    public virtual ICollection<TblFeedbackInfo> TblFeedbackInfos { get; set; } = new List<TblFeedbackInfo>();

    public virtual ICollection<TblLeadCancelReasonMst> TblLeadCancelReasonMsts { get; set; } = new List<TblLeadCancelReasonMst>();

    public virtual ICollection<TblProformaInvoiceMaster> TblProformaInvoiceMasters { get; set; } = new List<TblProformaInvoiceMaster>();

    public virtual ICollection<TblProformaInvoiceMstWithoutGst> TblProformaInvoiceMstWithoutGsts { get; set; } = new List<TblProformaInvoiceMstWithoutGst>();

    public virtual ICollection<TblSaleNewStrategy> TblSaleNewStrategies { get; set; } = new List<TblSaleNewStrategy>();

    public virtual ICollection<TblStategyMaster> TblStategyMasters { get; set; } = new List<TblStategyMaster>();

    public virtual ICollection<TblTitleMaster> TblTitleMasters { get; set; } = new List<TblTitleMaster>();

    public virtual ICollection<TblfreelancerMaster> TblfreelancerMasters { get; set; } = new List<TblfreelancerMaster>();

    public virtual ICollection<TblfreelancerRatechartMst> TblfreelancerRatechartMsts { get; set; } = new List<TblfreelancerRatechartMst>();
}
