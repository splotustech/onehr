using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblCompanyInfo
{
    public int Id { get; set; }

    public string? CompanyName { get; set; }

    public string? BuisnessType { get; set; }

    public string? Address { get; set; }

    public string? Pincode { get; set; }

    public string? MobileNo1 { get; set; }

    public string? MobileNo2 { get; set; }

    public string? EmailAddress1 { get; set; }

    public string? EmailAddress2 { get; set; }

    public string? GstNo { get; set; }

    public string? BankName { get; set; }

    public string? AccountNo { get; set; }

    public string? IfscNo { get; set; }

    public string? AccountHolderName { get; set; }

    public string? Branch { get; set; }

    public string? AccountType { get; set; }

    public string? BankAddress { get; set; }

    public string? CompanyLogoUrl { get; set; }

    public string? ComapnyLogoName { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

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

    public virtual ICollection<TblFacilityMaster> TblFacilityMasters { get; set; } = new List<TblFacilityMaster>();

    public virtual ICollection<TblFeedbackInfo> TblFeedbackInfos { get; set; } = new List<TblFeedbackInfo>();

    public virtual ICollection<TblFollowupTypeMaster> TblFollowupTypeMasters { get; set; } = new List<TblFollowupTypeMaster>();

    public virtual ICollection<TblLeadCancelReasonMst> TblLeadCancelReasonMsts { get; set; } = new List<TblLeadCancelReasonMst>();

    public virtual ICollection<TblOtherIncome> TblOtherIncomes { get; set; } = new List<TblOtherIncome>();

    public virtual ICollection<TblPackageInfoMaster> TblPackageInfoMasters { get; set; } = new List<TblPackageInfoMaster>();

    public virtual ICollection<TblProductTypeInfoMaster> TblProductTypeInfoMasters { get; set; } = new List<TblProductTypeInfoMaster>();

    public virtual ICollection<TblProformaInvoiceMaster> TblProformaInvoiceMasters { get; set; } = new List<TblProformaInvoiceMaster>();

    public virtual ICollection<TblProformaInvoiceMstWithoutGst> TblProformaInvoiceMstWithoutGsts { get; set; } = new List<TblProformaInvoiceMstWithoutGst>();

    public virtual ICollection<TblReasonInfoMaster> TblReasonInfoMasters { get; set; } = new List<TblReasonInfoMaster>();

    public virtual ICollection<TblRoleInfo> TblRoleInfos { get; set; } = new List<TblRoleInfo>();

    public virtual ICollection<TblSaleNewStrategy> TblSaleNewStrategies { get; set; } = new List<TblSaleNewStrategy>();

    public virtual ICollection<TblSecuriteDepositeReturn> TblSecuriteDepositeReturns { get; set; } = new List<TblSecuriteDepositeReturn>();

    public virtual ICollection<TblStategyMaster> TblStategyMasters { get; set; } = new List<TblStategyMaster>();

    public virtual ICollection<TblTdsmaster> TblTdsmasters { get; set; } = new List<TblTdsmaster>();

    public virtual ICollection<TblTitleMaster> TblTitleMasters { get; set; } = new List<TblTitleMaster>();

    public virtual ICollection<TblVendorInfoMaster> TblVendorInfoMasters { get; set; } = new List<TblVendorInfoMaster>();

    public virtual ICollection<TblfreelancerMaster> TblfreelancerMasters { get; set; } = new List<TblfreelancerMaster>();

    public virtual ICollection<TblfreelancerRatechartMst> TblfreelancerRatechartMsts { get; set; } = new List<TblfreelancerRatechartMst>();
}
