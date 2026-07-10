using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblEmplyeeInfo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? MobileNo { get; set; }

    public string? FirmName { get; set; }

    public int? DepartmentId { get; set; }

    public string? EmployeeStatus { get; set; }

    public DateTime? JoiningDate { get; set; }

    public DateTime? BirthDate { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Email { get; set; }

    public string? Designation { get; set; }

    public string? MobileNo2 { get; set; }

    public string? Pincode { get; set; }

    public string? ProfileBrowseUri { get; set; }

    public string? ProfileBrowseImage { get; set; }

    public string? AdharcardBrowseUri { get; set; }

    public string? AdharcardBrowseImage { get; set; }

    public string? PancardBrowseUri { get; set; }

    public string? PancardBrowseImage { get; set; }

    public string? BankDocumentBrowseUri { get; set; }

    public string? BankDocumentBrowseImage { get; set; }

    public string? ExperienceCertificateBrowseUri { get; set; }

    public string? ExperienceCertificateBrowseImage { get; set; }

    public string? GraduationCertificateBrowseUri { get; set; }

    public string? GraduationCertificateBrowseImage { get; set; }

    public string? BankHolderName { get; set; }

    public string? BankAccountNo { get; set; }

    public string? Ifsccode { get; set; }

    public string? BankName { get; set; }

    public string? BranchName { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public string? EmpId { get; set; }

    public string? DefaultWorkMode { get; set; }

    public virtual ICollection<AttendanceLog> AttendanceLogs { get; set; } = new List<AttendanceLog>();

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblDepartmentInfo? Department { get; set; }

    public virtual ICollection<QuatationInvoiceMstWithGst> QuatationInvoiceMstWithGsts { get; set; } = new List<QuatationInvoiceMstWithGst>();

    public virtual ICollection<QuotationMstWithoutGst> QuotationMstWithoutGsts { get; set; } = new List<QuotationMstWithoutGst>();

    public virtual ICollection<TaxInvoiceMstwithoutGst> TaxInvoiceMstwithoutGsts { get; set; } = new List<TaxInvoiceMstwithoutGst>();

    public virtual ICollection<TaxableInvoiceMaster> TaxableInvoiceMasters { get; set; } = new List<TaxableInvoiceMaster>();

    public virtual ICollection<TblAgendaActionDetail> TblAgendaActionDetails { get; set; } = new List<TblAgendaActionDetail>();

    public virtual ICollection<TblAgentInfoMaster> TblAgentInfoMasters { get; set; } = new List<TblAgentInfoMaster>();

    public virtual ICollection<TblAssetAssignMaster> TblAssetAssignMasters { get; set; } = new List<TblAssetAssignMaster>();

    public virtual ICollection<TblBankInfo> TblBankInfos { get; set; } = new List<TblBankInfo>();

    public virtual ICollection<TblBugRequirementInfoMaster> TblBugRequirementInfoMasterDevelopers { get; set; } = new List<TblBugRequirementInfoMaster>();

    public virtual ICollection<TblBugRequirementInfoMaster> TblBugRequirementInfoMasterEmps { get; set; } = new List<TblBugRequirementInfoMaster>();

    public virtual ICollection<TblCompletedDeployment> TblCompletedDeployments { get; set; } = new List<TblCompletedDeployment>();

    public virtual ICollection<TblCoreTeamAgendaInfo> TblCoreTeamAgendaInfos { get; set; } = new List<TblCoreTeamAgendaInfo>();

    public virtual ICollection<TblCustOnboardFollowupConvDetail> TblCustOnboardFollowupConvDetails { get; set; } = new List<TblCustOnboardFollowupConvDetail>();

    public virtual ICollection<TblCustomerInfo> TblCustomerInfoEmps { get; set; } = new List<TblCustomerInfo>();

    public virtual ICollection<TblCustomerInfo> TblCustomerInfoFavouriteEmps { get; set; } = new List<TblCustomerInfo>();

    public virtual ICollection<TblCustomerOnboardingDetail> TblCustomerOnboardingDetails { get; set; } = new List<TblCustomerOnboardingDetail>();

    public virtual ICollection<TblCustomerOnboardingMst> TblCustomerOnboardingMstCompletedEmps { get; set; } = new List<TblCustomerOnboardingMst>();

    public virtual ICollection<TblCustomerOnboardingMst> TblCustomerOnboardingMstDeleteEmps { get; set; } = new List<TblCustomerOnboardingMst>();

    public virtual ICollection<TblCustomerTraining> TblCustomerTrainings { get; set; } = new List<TblCustomerTraining>();

    public virtual ICollection<TblDailyTaskManagementDetail> TblDailyTaskManagementDetails { get; set; } = new List<TblDailyTaskManagementDetail>();

    public virtual ICollection<TblDailyTaskManagementMst> TblDailyTaskManagementMsts { get; set; } = new List<TblDailyTaskManagementMst>();

    public virtual ICollection<TblDepartmentInfo> TblDepartmentInfoCreatedByNavigations { get; set; } = new List<TblDepartmentInfo>();

    public virtual ICollection<TblDepartmentInfo> TblDepartmentInfoUpdatedByNavigations { get; set; } = new List<TblDepartmentInfo>();

    public virtual ICollection<TblDeploymentOnLive> TblDeploymentOnLives { get; set; } = new List<TblDeploymentOnLive>();

    public virtual ICollection<TblEmployeeRechargeMaster> TblEmployeeRechargeMasters { get; set; } = new List<TblEmployeeRechargeMaster>();

    public virtual ICollection<TblExpensesInfo> TblExpensesInfos { get; set; } = new List<TblExpensesInfo>();

    public virtual ICollection<TblExpensesMaintain> TblExpensesMaintains { get; set; } = new List<TblExpensesMaintain>();

    public virtual ICollection<TblFeedbackInfo> TblFeedbackInfos { get; set; } = new List<TblFeedbackInfo>();

    public virtual ICollection<TblGramsevakFollowUpMobileApp> TblGramsevakFollowUpMobileApps { get; set; } = new List<TblGramsevakFollowUpMobileApp>();

    public virtual ICollection<TblInAppNotification> TblInAppNotifications { get; set; } = new List<TblInAppNotification>();

    public virtual ICollection<TblInOutPass> TblInOutPasses { get; set; } = new List<TblInOutPass>();

    public virtual ICollection<TblInvoiceMaster> TblInvoiceMasters { get; set; } = new List<TblInvoiceMaster>();

    public virtual ICollection<TblLeadandOpportunitesinfo> TblLeadandOpportunitesinfos { get; set; } = new List<TblLeadandOpportunitesinfo>();

    public virtual ICollection<TblLeaveRequest> TblLeaveRequests { get; set; } = new List<TblLeaveRequest>();

    public virtual ICollection<TblLoginInfo> TblLoginInfos { get; set; } = new List<TblLoginInfo>();

    public virtual ICollection<TblMettingDecision> TblMettingDecisionEmps { get; set; } = new List<TblMettingDecision>();

    public virtual ICollection<TblMettingDecision> TblMettingDecisionResponsiblePersonNavigations { get; set; } = new List<TblMettingDecision>();

    public virtual ICollection<TblNotificationMaster> TblNotificationMasters { get; set; } = new List<TblNotificationMaster>();

    public virtual ICollection<TblObjectionMst> TblObjectionMsts { get; set; } = new List<TblObjectionMst>();

    public virtual ICollection<TblOperation> TblOperations { get; set; } = new List<TblOperation>();

    public virtual ICollection<TblOtherExpenseSubtype> TblOtherExpenseSubtypes { get; set; } = new List<TblOtherExpenseSubtype>();

    public virtual ICollection<TblOtherIncome> TblOtherIncomes { get; set; } = new List<TblOtherIncome>();

    public virtual ICollection<TblPaymentFollowupInfo> TblPaymentFollowupInfoCreatedByNavigations { get; set; } = new List<TblPaymentFollowupInfo>();

    public virtual ICollection<TblPaymentFollowupInfo> TblPaymentFollowupInfoUpdatedByNavigations { get; set; } = new List<TblPaymentFollowupInfo>();

    public virtual ICollection<TblPendingDeployment> TblPendingDeployments { get; set; } = new List<TblPendingDeployment>();

    public virtual ICollection<TblProformaInvoiceMaster> TblProformaInvoiceMasters { get; set; } = new List<TblProformaInvoiceMaster>();

    public virtual ICollection<TblProformaInvoiceMstWithoutGst> TblProformaInvoiceMstWithoutGsts { get; set; } = new List<TblProformaInvoiceMstWithoutGst>();

    public virtual ICollection<TblPunctuality> TblPunctualities { get; set; } = new List<TblPunctuality>();

    public virtual ICollection<TblPushSubscription> TblPushSubscriptions { get; set; } = new List<TblPushSubscription>();

    public virtual ICollection<TblQuestionAnswerDetail> TblQuestionAnswerDetails { get; set; } = new List<TblQuestionAnswerDetail>();

    public virtual ICollection<TblQuestionAnswerMaster> TblQuestionAnswerMasters { get; set; } = new List<TblQuestionAnswerMaster>();

    public virtual ICollection<TblSaleNewStrategy> TblSaleNewStrategies { get; set; } = new List<TblSaleNewStrategy>();

    public virtual ICollection<TblSalesFollowup> TblSalesFollowupCreatedByNavigations { get; set; } = new List<TblSalesFollowup>();

    public virtual ICollection<TblSalesFollowup> TblSalesFollowupUpdatedByNavigations { get; set; } = new List<TblSalesFollowup>();

    public virtual ICollection<TblSalesTeamTarget> TblSalesTeamTargets { get; set; } = new List<TblSalesTeamTarget>();

    public virtual ICollection<TblSopdetail> TblSopdetails { get; set; } = new List<TblSopdetail>();

    public virtual ICollection<TblStategyMaster> TblStategyMasters { get; set; } = new List<TblStategyMaster>();

    public virtual ICollection<TblSupportCallDataHistory> TblSupportCallDataHistories { get; set; } = new List<TblSupportCallDataHistory>();

    public virtual ICollection<TblSupportInfo> TblSupportInfos { get; set; } = new List<TblSupportInfo>();

    public virtual ICollection<TblTaskManagementInfo> TblTaskManagementInfos { get; set; } = new List<TblTaskManagementInfo>();

    public virtual ICollection<TblTeamBonding> TblTeamBondings { get; set; } = new List<TblTeamBonding>();

    public virtual ICollection<TblTestcaseDetail> TblTestcaseDetails { get; set; } = new List<TblTestcaseDetail>();

    public virtual ICollection<TblVendorInvoice> TblVendorInvoices { get; set; } = new List<TblVendorInvoice>();

    public virtual ICollection<TblVendorLegder> TblVendorLegders { get; set; } = new List<TblVendorLegder>();

    public virtual ICollection<TblWarningNotificationMst> TblWarningNotificationMsts { get; set; } = new List<TblWarningNotificationMst>();

    public virtual ICollection<TblWorkFromHomeTrackingLog> TblWorkFromHomeTrackingLogs { get; set; } = new List<TblWorkFromHomeTrackingLog>();

    public virtual ICollection<TblYearEndingEnquiry> TblYearEndingEnquiries { get; set; } = new List<TblYearEndingEnquiry>();

    public virtual ICollection<TblYearEndingHold> TblYearEndingHolds { get; set; } = new List<TblYearEndingHold>();

    public virtual ICollection<TblYearEndingInfo> TblYearEndingInfos { get; set; } = new List<TblYearEndingInfo>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
