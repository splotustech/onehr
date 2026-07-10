using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class LotusTechCrmliveContext : DbContext
{
    public LotusTechCrmliveContext()
    {
    }

    public LotusTechCrmliveContext(DbContextOptions<LotusTechCrmliveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AttendanceLog> AttendanceLogs { get; set; }

    public virtual DbSet<AutoWebsiteLinkInfo> AutoWebsiteLinkInfos { get; set; }

    public virtual DbSet<Designation> Designations { get; set; }

    public virtual DbSet<FrimInvoiceMaster> FrimInvoiceMasters { get; set; }

    public virtual DbSet<OfficeSetting> OfficeSettings { get; set; }

    public virtual DbSet<QuatationInvoiceDetailWithGst> QuatationInvoiceDetailWithGsts { get; set; }

    public virtual DbSet<QuatationInvoiceMstWithGst> QuatationInvoiceMstWithGsts { get; set; }

    public virtual DbSet<QuotationInvDetialWithoutGst> QuotationInvDetialWithoutGsts { get; set; }

    public virtual DbSet<QuotationMstWithoutGst> QuotationMstWithoutGsts { get; set; }

    public virtual DbSet<TaxInvoiceDetailWithoutGst> TaxInvoiceDetailWithoutGsts { get; set; }

    public virtual DbSet<TaxInvoiceMstwithoutGst> TaxInvoiceMstwithoutGsts { get; set; }

    public virtual DbSet<TaxableInvoiceDetail> TaxableInvoiceDetails { get; set; }

    public virtual DbSet<TaxableInvoiceMaster> TaxableInvoiceMasters { get; set; }

    public virtual DbSet<TblAgendaActionDetail> TblAgendaActionDetails { get; set; }

    public virtual DbSet<TblAgentInfoMaster> TblAgentInfoMasters { get; set; }

    public virtual DbSet<TblAssetAssignDetail> TblAssetAssignDetails { get; set; }

    public virtual DbSet<TblAssetAssignMaster> TblAssetAssignMasters { get; set; }

    public virtual DbSet<TblAssetEntryMaster> TblAssetEntryMasters { get; set; }

    public virtual DbSet<TblAssetReturnDetail> TblAssetReturnDetails { get; set; }

    public virtual DbSet<TblAssetTypeMaster> TblAssetTypeMasters { get; set; }

    public virtual DbSet<TblBalanceMaintain> TblBalanceMaintains { get; set; }

    public virtual DbSet<TblBankInfo> TblBankInfos { get; set; }

    public virtual DbSet<TblBugRequirementInfoMaster> TblBugRequirementInfoMasters { get; set; }

    public virtual DbSet<TblBusinessTourExpenseMst> TblBusinessTourExpenseMsts { get; set; }

    public virtual DbSet<TblCompanyInfo> TblCompanyInfos { get; set; }

    public virtual DbSet<TblCompletedDeployment> TblCompletedDeployments { get; set; }

    public virtual DbSet<TblCoreTeamAgendaInfo> TblCoreTeamAgendaInfos { get; set; }

    public virtual DbSet<TblCustOnboardFollowupConvDetail> TblCustOnboardFollowupConvDetails { get; set; }

    public virtual DbSet<TblCustomerInfo> TblCustomerInfos { get; set; }

    public virtual DbSet<TblCustomerOnboardingDetail> TblCustomerOnboardingDetails { get; set; }

    public virtual DbSet<TblCustomerOnboardingMst> TblCustomerOnboardingMsts { get; set; }

    public virtual DbSet<TblCustomerTraining> TblCustomerTrainings { get; set; }

    public virtual DbSet<TblDailyTaskManagementDetail> TblDailyTaskManagementDetails { get; set; }

    public virtual DbSet<TblDailyTaskManagementMst> TblDailyTaskManagementMsts { get; set; }

    public virtual DbSet<TblDepartmentInfo> TblDepartmentInfos { get; set; }

    public virtual DbSet<TblDeploymentOnLive> TblDeploymentOnLives { get; set; }

    public virtual DbSet<TblDomain> TblDomains { get; set; }

    public virtual DbSet<TblEmployeeRechargeMaster> TblEmployeeRechargeMasters { get; set; }

    public virtual DbSet<TblEmplyeeInfo> TblEmplyeeInfos { get; set; }

    public virtual DbSet<TblExpensesDetail> TblExpensesDetails { get; set; }

    public virtual DbSet<TblExpensesInfo> TblExpensesInfos { get; set; }

    public virtual DbSet<TblExpensesMaintain> TblExpensesMaintains { get; set; }

    public virtual DbSet<TblExportDataDetail> TblExportDataDetails { get; set; }

    public virtual DbSet<TblFacilityMaster> TblFacilityMasters { get; set; }

    public virtual DbSet<TblFeedbackInfo> TblFeedbackInfos { get; set; }

    public virtual DbSet<TblFollowupTypeMaster> TblFollowupTypeMasters { get; set; }

    public virtual DbSet<TblGalleryForWebsite> TblGalleryForWebsites { get; set; }

    public virtual DbSet<TblGpRegistrationWebsite> TblGpRegistrationWebsites { get; set; }

    public virtual DbSet<TblGpWebsiteInternalStatus> TblGpWebsiteInternalStatuses { get; set; }

    public virtual DbSet<TblGramSevakExcelReportTracking> TblGramSevakExcelReportTrackings { get; set; }

    public virtual DbSet<TblGramsevakFollowUpMobileApp> TblGramsevakFollowUpMobileApps { get; set; }

    public virtual DbSet<TblGramsevakInfo> TblGramsevakInfos { get; set; }

    public virtual DbSet<TblHolidayCalender> TblHolidayCalenders { get; set; }

    public virtual DbSet<TblImageTypeMst> TblImageTypeMsts { get; set; }

    public virtual DbSet<TblInAppNotification> TblInAppNotifications { get; set; }

    public virtual DbSet<TblInOutPass> TblInOutPasses { get; set; }

    public virtual DbSet<TblInvoiceDetail> TblInvoiceDetails { get; set; }

    public virtual DbSet<TblInvoiceMaster> TblInvoiceMasters { get; set; }

    public virtual DbSet<TblKrakpi> TblKrakpis { get; set; }

    public virtual DbSet<TblLeadCancelReasonMst> TblLeadCancelReasonMsts { get; set; }

    public virtual DbSet<TblLeadReasonInfo> TblLeadReasonInfos { get; set; }

    public virtual DbSet<TblLeadandOpportunitesinfo> TblLeadandOpportunitesinfos { get; set; }

    public virtual DbSet<TblLeaveRequest> TblLeaveRequests { get; set; }

    public virtual DbSet<TblLocationExpense> TblLocationExpenses { get; set; }

    public virtual DbSet<TblLoginAnalysis> TblLoginAnalyses { get; set; }

    public virtual DbSet<TblLoginInfo> TblLoginInfos { get; set; }

    public virtual DbSet<TblLoginServerDetail> TblLoginServerDetails { get; set; }

    public virtual DbSet<TblMettingDecision> TblMettingDecisions { get; set; }

    public virtual DbSet<TblModelMaster> TblModelMasters { get; set; }

    public virtual DbSet<TblMomdetail> TblMomdetails { get; set; }

    public virtual DbSet<TblMovementRegister> TblMovementRegisters { get; set; }

    public virtual DbSet<TblNotificationMaster> TblNotificationMasters { get; set; }

    public virtual DbSet<TblObjectionMst> TblObjectionMsts { get; set; }

    public virtual DbSet<TblOperation> TblOperations { get; set; }

    public virtual DbSet<TblOperationDepCheckListDetail> TblOperationDepCheckListDetails { get; set; }

    public virtual DbSet<TblOperationDepOnCheckListMst> TblOperationDepOnCheckListMsts { get; set; }

    public virtual DbSet<TblOperationTitle> TblOperationTitles { get; set; }

    public virtual DbSet<TblOperatorDetail> TblOperatorDetails { get; set; }

    public virtual DbSet<TblOtherExpense> TblOtherExpenses { get; set; }

    public virtual DbSet<TblOtherExpenseSubtype> TblOtherExpenseSubtypes { get; set; }

    public virtual DbSet<TblOtherIncome> TblOtherIncomes { get; set; }

    public virtual DbSet<TblPackageInfoMaster> TblPackageInfoMasters { get; set; }

    public virtual DbSet<TblPageNavigation> TblPageNavigations { get; set; }

    public virtual DbSet<TblPaymentFollowupInfo> TblPaymentFollowupInfos { get; set; }

    public virtual DbSet<TblPendingDeployment> TblPendingDeployments { get; set; }

    public virtual DbSet<TblPolicyDetail> TblPolicyDetails { get; set; }

    public virtual DbSet<TblPolicyInfo> TblPolicyInfos { get; set; }

    public virtual DbSet<TblProductTypeInfoMaster> TblProductTypeInfoMasters { get; set; }

    public virtual DbSet<TblProformaInvoiceDetail> TblProformaInvoiceDetails { get; set; }

    public virtual DbSet<TblProformaInvoiceDetailWithoutGst> TblProformaInvoiceDetailWithoutGsts { get; set; }

    public virtual DbSet<TblProformaInvoiceMaster> TblProformaInvoiceMasters { get; set; }

    public virtual DbSet<TblProformaInvoiceMstWithoutGst> TblProformaInvoiceMstWithoutGsts { get; set; }

    public virtual DbSet<TblProjectMaster> TblProjectMasters { get; set; }

    public virtual DbSet<TblPunctuality> TblPunctualities { get; set; }

    public virtual DbSet<TblPushSubscription> TblPushSubscriptions { get; set; }

    public virtual DbSet<TblQuestionAnswerDetail> TblQuestionAnswerDetails { get; set; }

    public virtual DbSet<TblQuestionAnswerMaster> TblQuestionAnswerMasters { get; set; }

    public virtual DbSet<TblReasonInfoMaster> TblReasonInfoMasters { get; set; }

    public virtual DbSet<TblRoleInfo> TblRoleInfos { get; set; }

    public virtual DbSet<TblSaleDepFollowUpTypeMaster> TblSaleDepFollowUpTypeMasters { get; set; }

    public virtual DbSet<TblSaleNewStrategy> TblSaleNewStrategies { get; set; }

    public virtual DbSet<TblSaleTeamTargetDetail> TblSaleTeamTargetDetails { get; set; }

    public virtual DbSet<TblSalesFollowup> TblSalesFollowups { get; set; }

    public virtual DbSet<TblSalesTeamTarget> TblSalesTeamTargets { get; set; }

    public virtual DbSet<TblSddetailsForTaxInv> TblSddetailsForTaxInvs { get; set; }

    public virtual DbSet<TblSecuriteDepositeReturn> TblSecuriteDepositeReturns { get; set; }

    public virtual DbSet<TblSecurityDdetail> TblSecurityDdetails { get; set; }

    public virtual DbSet<TblSettingInfo> TblSettingInfos { get; set; }

    public virtual DbSet<TblSopdetail> TblSopdetails { get; set; }

    public virtual DbSet<TblStategyMaster> TblStategyMasters { get; set; }

    public virtual DbSet<TblSubTitle> TblSubTitles { get; set; }

    public virtual DbSet<TblSupportCallDataHistory> TblSupportCallDataHistories { get; set; }

    public virtual DbSet<TblSupportInfo> TblSupportInfos { get; set; }

    public virtual DbSet<TblSupportTimeHistory> TblSupportTimeHistories { get; set; }

    public virtual DbSet<TblSupportTypeInfoMaster> TblSupportTypeInfoMasters { get; set; }

    public virtual DbSet<TblTaskManagementInfo> TblTaskManagementInfos { get; set; }

    public virtual DbSet<TblTaskPriorityMaster> TblTaskPriorityMasters { get; set; }

    public virtual DbSet<TblTaskStatusMaster> TblTaskStatusMasters { get; set; }

    public virtual DbSet<TblTaskTimeHistory> TblTaskTimeHistories { get; set; }

    public virtual DbSet<TblTaskTypeMaster> TblTaskTypeMasters { get; set; }

    public virtual DbSet<TblTdsmaster> TblTdsmasters { get; set; }

    public virtual DbSet<TblTeamBonding> TblTeamBondings { get; set; }

    public virtual DbSet<TblTestcaseDetail> TblTestcaseDetails { get; set; }

    public virtual DbSet<TblThoughtPractice> TblThoughtPractices { get; set; }

    public virtual DbSet<TblTitleMaster> TblTitleMasters { get; set; }

    public virtual DbSet<TblTitleSubProductDetail> TblTitleSubProductDetails { get; set; }

    public virtual DbSet<TblVendorInfo> TblVendorInfos { get; set; }

    public virtual DbSet<TblVendorInfoMaster> TblVendorInfoMasters { get; set; }

    public virtual DbSet<TblVendorInvoice> TblVendorInvoices { get; set; }

    public virtual DbSet<TblVendorLegder> TblVendorLegders { get; set; }

    public virtual DbSet<TblWarningNotificationMst> TblWarningNotificationMsts { get; set; }

    public virtual DbSet<TblWarningType> TblWarningTypes { get; set; }

    public virtual DbSet<TblWorkFromHomeTrackingLog> TblWorkFromHomeTrackingLogs { get; set; }

    public virtual DbSet<TblYearEndingEnquiry> TblYearEndingEnquiries { get; set; }

    public virtual DbSet<TblYearEndingHold> TblYearEndingHolds { get; set; }

    public virtual DbSet<TblYearEndingInfo> TblYearEndingInfos { get; set; }

    public virtual DbSet<TblfreelancerMaster> TblfreelancerMasters { get; set; }

    public virtual DbSet<TblfreelancerRatechartDetail> TblfreelancerRatechartDetails { get; set; }

    public virtual DbSet<TblfreelancerRatechartMst> TblfreelancerRatechartMsts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=184.168.120.203;Database=LotusTechCRMLive;User ID=sa;Password=splotustech@dmin#321;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AttendanceLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attendan__3214EC07D6672568");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.PunchInTime).HasColumnType("datetime");
            entity.Property(e => e.PunchOutTime).HasColumnType("datetime");
            entity.Property(e => e.WorkMode).HasDefaultValueSql("('Office')");

            entity.HasOne(d => d.Employee).WithMany(p => p.AttendanceLogs)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AttendanceLogs_tblEmplyeeInfo");
        });

        modelBuilder.Entity<AutoWebsiteLinkInfo>(entity =>
        {
            entity.ToTable("AutoWebsiteLinkInfo");
        });

        modelBuilder.Entity<Designation>(entity =>
        {
            entity.ToTable("Designation");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.Designations)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_Designation_tblCompanyInfo");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.Designations)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_Designation_tblVendorInfoMaster");
        });

        modelBuilder.Entity<FrimInvoiceMaster>(entity =>
        {
            entity.ToTable("FrimInvoiceMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Gstno).HasColumnName("GSTNo");
            entity.Property(e => e.LogoImageName).HasColumnName("Logo_Image_Name");
            entity.Property(e => e.Prefix).HasMaxLength(10);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.FrimInvoiceMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_FrimInvoiceMaster_tblCompanyInfo");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.FrimInvoiceMasters)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_FrimInvoiceMaster_tblVendorInfoMaster");
        });

        modelBuilder.Entity<OfficeSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OfficeSe__3214EC0756CD1E36");

            entity.Property(e => e.OfficeName).HasMaxLength(100);
            entity.Property(e => e.WfhallowedRadiusInMeters).HasColumnName("WFHAllowedRadiusInMeters");
        });

        modelBuilder.Entity<QuatationInvoiceDetailWithGst>(entity =>
        {
            entity.ToTable("QuatationInvoiceDetailWithGST");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Gst)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GST");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.QuatationInvId).HasColumnName("QuatationInv_Id");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxableAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Package).WithMany(p => p.QuatationInvoiceDetailWithGsts)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_QuatationInvoiceDetailWithGST_tblPackageInfoMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.QuatationInvoiceDetailWithGsts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_QuatationInvoiceDetailWithGST_tblProductTypeInfoMaster");

            entity.HasOne(d => d.QuatationInv).WithMany(p => p.QuatationInvoiceDetailWithGsts)
                .HasForeignKey(d => d.QuatationInvId)
                .HasConstraintName("FK_QuatationInvoiceDetailWithGST_QuatationInvoiceMstWithGST");
        });

        modelBuilder.Entity<QuatationInvoiceMstWithGst>(entity =>
        {
            entity.ToTable("QuatationInvoiceMstWithGST");

            entity.Property(e => e.CommissionAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Commission_Amt");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InvDate)
                .HasColumnType("datetime")
                .HasColumnName("Inv_Date");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProformaWithGstid).HasColumnName("ProformaWithGSTId");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Agent).WithMany(p => p.QuatationInvoiceMstWithGsts)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK_QuatationInvoiceMstWithGST_tblAgentInfoMaster");

            entity.HasOne(d => d.Company).WithMany(p => p.QuatationInvoiceMstWithGsts)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_QuatationInvoiceMstWithGST_tblCompanyInfo");

            entity.HasOne(d => d.Customer).WithMany(p => p.QuatationInvoiceMstWithGsts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_QuatationInvoiceMstWithGST_tblCustomerInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.QuatationInvoiceMstWithGsts)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_QuatationInvoiceMstWithGST_tblEmplyeeInfo");

            entity.HasOne(d => d.Firm).WithMany(p => p.QuatationInvoiceMstWithGsts)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_QuatationInvoiceMstWithGST_QuatationInvoiceMstWithGST");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.QuatationInvoiceMstWithGsts)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK_QuatationInvoiceMstWithGST_tblfreelancer_master");

            entity.HasOne(d => d.ProformaWithGst).WithMany(p => p.QuatationInvoiceMstWithGsts)
                .HasForeignKey(d => d.ProformaWithGstid)
                .HasConstraintName("FK_QuatationInvoiceMstWithGST_tblProformaInvoiceMaster");

            entity.HasOne(d => d.Stategy).WithMany(p => p.QuatationInvoiceMstWithGsts)
                .HasForeignKey(d => d.StategyId)
                .HasConstraintName("FK_QuatationInvoiceMstWithGST_tblStategyMaster");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.QuatationInvoiceMstWithGsts)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_QuatationInvoiceMstWithGST_tblVendorInfoMaster");
        });

        modelBuilder.Entity<QuotationInvDetialWithoutGst>(entity =>
        {
            entity.ToTable("QuotationInvDetialWithoutGST");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.QuotationInvId).HasColumnName("QuotationInv_Id");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxableAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Package).WithMany(p => p.QuotationInvDetialWithoutGsts)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_QuotationInvDetialWithoutGST_tblPackageInfoMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.QuotationInvDetialWithoutGsts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_QuotationInvDetialWithoutGST_tblProductTypeInfoMaster");

            entity.HasOne(d => d.QuotationInv).WithMany(p => p.QuotationInvDetialWithoutGsts)
                .HasForeignKey(d => d.QuotationInvId)
                .HasConstraintName("FK_QuotationInvDetialWithoutGST_QuotationMstWithoutGST");
        });

        modelBuilder.Entity<QuotationMstWithoutGst>(entity =>
        {
            entity.ToTable("QuotationMstWithoutGST");

            entity.Property(e => e.CommissionAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Commission_Amt");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InvDate)
                .HasColumnType("datetime")
                .HasColumnName("Inv_Date");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProformaWithoutGstinvId).HasColumnName("ProformaWithoutGSTInvId");
            entity.Property(e => e.TotalAmoun).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Agent).WithMany(p => p.QuotationMstWithoutGsts)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK_QuotationMstWithoutGST_tblAgentInfoMaster");

            entity.HasOne(d => d.Company).WithMany(p => p.QuotationMstWithoutGsts)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_QuotationMstWithoutGST_tblCompanyInfo");

            entity.HasOne(d => d.Customer).WithMany(p => p.QuotationMstWithoutGsts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_QuotationMstWithoutGST_QuotationMstWithoutGST");

            entity.HasOne(d => d.Emp).WithMany(p => p.QuotationMstWithoutGsts)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_QuotationMstWithoutGST_tblEmplyeeInfo");

            entity.HasOne(d => d.Firm).WithMany(p => p.QuotationMstWithoutGsts)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_QuotationMstWithoutGST_FrimInvoiceMaster");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.QuotationMstWithoutGsts)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK_QuotationMstWithoutGST_tblfreelancer_master");

            entity.HasOne(d => d.ProformaWithoutGstinv).WithMany(p => p.QuotationMstWithoutGsts)
                .HasForeignKey(d => d.ProformaWithoutGstinvId)
                .HasConstraintName("FK_QuotationMstWithoutGST_tblProformaInvoiceMstWithoutGST");

            entity.HasOne(d => d.Stategy).WithMany(p => p.QuotationMstWithoutGsts)
                .HasForeignKey(d => d.StategyId)
                .HasConstraintName("FK_QuotationMstWithoutGST_tblStategyMaster");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.QuotationMstWithoutGsts)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_QuotationMstWithoutGST_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TaxInvoiceDetailWithoutGst>(entity =>
        {
            entity.ToTable("TaxInvoiceDetailWithoutGST");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxableAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxableInvId).HasColumnName("TaxableInv_Id");

            entity.HasOne(d => d.Package).WithMany(p => p.TaxInvoiceDetailWithoutGsts)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_TaxInvoiceDetailWithoutGST_tblPackageInfoMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.TaxInvoiceDetailWithoutGsts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_TaxInvoiceDetailWithoutGST_tblProductTypeInfoMaster");

            entity.HasOne(d => d.TaxableInv).WithMany(p => p.TaxInvoiceDetailWithoutGsts)
                .HasForeignKey(d => d.TaxableInvId)
                .HasConstraintName("FK_TaxInvoiceDetailWithoutGST_TaxInvoiceWithoutGST");
        });

        modelBuilder.Entity<TaxInvoiceMstwithoutGst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TaxInvoiceWithoutGST");

            entity.ToTable("TaxInvoiceMSTWithoutGST");

            entity.Property(e => e.CommissionAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Commission_Amt");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FinalCommissionAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FreelancerId).HasColumnName("freelancer_id");
            entity.Property(e => e.InvDate)
                .HasColumnType("datetime")
                .HasColumnName("Inv_Date");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OurInvoiceAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("our_invoice_amount");
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tds)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TDS");
            entity.Property(e => e.Tdsid).HasColumnName("TDSId");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Agent).WithMany(p => p.TaxInvoiceMstwithoutGsts)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK_TaxInvoiceWithoutGST_tblAgentInfoMaster");

            entity.HasOne(d => d.Company).WithMany(p => p.TaxInvoiceMstwithoutGsts)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_TaxInvoiceMSTWithoutGST_tblCompanyInfo");

            entity.HasOne(d => d.Customer).WithMany(p => p.TaxInvoiceMstwithoutGsts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_TaxInvoiceWithoutGST_TaxInvoiceWithoutGST");

            entity.HasOne(d => d.Emp).WithMany(p => p.TaxInvoiceMstwithoutGsts)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TaxInvoiceWithoutGST_tblEmplyeeInfo");

            entity.HasOne(d => d.Firm).WithMany(p => p.TaxInvoiceMstwithoutGsts)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_TaxInvoiceMSTWithoutGST_FrimInvoiceMaster");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.TaxInvoiceMstwithoutGsts)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK_TaxInvoiceMSTWithoutGST_tblfreelancer_master");

            entity.HasOne(d => d.Stategy).WithMany(p => p.TaxInvoiceMstwithoutGsts)
                .HasForeignKey(d => d.StategyId)
                .HasConstraintName("FK_TaxInvoiceWithoutGST_tblStategyMaster");

            entity.HasOne(d => d.TdsNavigation).WithMany(p => p.TaxInvoiceMstwithoutGsts)
                .HasForeignKey(d => d.Tdsid)
                .HasConstraintName("FK_TaxInvoiceMSTWithoutGST_tblTDSMaster");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TaxInvoiceMstwithoutGsts)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_TaxInvoiceMSTWithoutGST_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TaxableInvoiceDetail>(entity =>
        {
            entity.ToTable("TaxableInvoiceDetail");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Gst)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GST");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxableAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxableInvId).HasColumnName("TaxableInv_Id");

            entity.HasOne(d => d.Package).WithMany(p => p.TaxableInvoiceDetails)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_TaxableInvoiceDetail_tblPackageInfoMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.TaxableInvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_TaxableInvoiceDetail_tblProductTypeInfoMaster");

            entity.HasOne(d => d.TaxableInv).WithMany(p => p.TaxableInvoiceDetails)
                .HasForeignKey(d => d.TaxableInvId)
                .HasConstraintName("FK_TaxableInvoiceDetail_TaxableInvoiceMaster");
        });

        modelBuilder.Entity<TaxableInvoiceMaster>(entity =>
        {
            entity.ToTable("TaxableInvoiceMaster");

            entity.Property(e => e.BaseCommissionAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CommissionAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Commission_Amt");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FinalCommissionAmt).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FreelancerId).HasColumnName("freelancer_id");
            entity.Property(e => e.GpInvDate).HasColumnType("datetime");
            entity.Property(e => e.GstonCommissionAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GSTOnCommissionAmt");
            entity.Property(e => e.InvDate)
                .HasColumnType("datetime")
                .HasColumnName("Inv_Date");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OurInvoiceAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("our_invoice_amount");
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tds)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TDS");
            entity.Property(e => e.Tdsid).HasColumnName("TDSId");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Agent).WithMany(p => p.TaxableInvoiceMasters)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK_TaxableInvoiceMaster_tblAgentInfoMaster");

            entity.HasOne(d => d.Company).WithMany(p => p.TaxableInvoiceMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_TaxableInvoiceMaster_tblCompanyInfo");

            entity.HasOne(d => d.Customer).WithMany(p => p.TaxableInvoiceMasters)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_TaxableInvoiceMaster_tblCustomerInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TaxableInvoiceMasters)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TaxableInvoiceMaster_tblEmplyeeInfo");

            entity.HasOne(d => d.Firm).WithMany(p => p.TaxableInvoiceMasters)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_TaxableInvoiceMaster_FrimInvoiceMaster");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.TaxableInvoiceMasters)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK_TaxableInvoiceMaster_tblfreelancer_master");

            entity.HasOne(d => d.Stategy).WithMany(p => p.TaxableInvoiceMasters)
                .HasForeignKey(d => d.StategyId)
                .HasConstraintName("FK_TaxableInvoiceMaster_tblStategyMaster");

            entity.HasOne(d => d.TdsNavigation).WithMany(p => p.TaxableInvoiceMasters)
                .HasForeignKey(d => d.Tdsid)
                .HasConstraintName("FK_TaxableInvoiceMaster_tblTDSMaster");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TaxableInvoiceMasters)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_TaxableInvoiceMaster_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblAgendaActionDetail>(entity =>
        {
            entity.ToTable("tblAgendaActionDetails");

            entity.Property(e => e.ActionTakenDate).HasColumnType("datetime");
            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeadlineDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.AgendaCreatedMember).WithMany(p => p.TblAgendaActionDetails)
                .HasForeignKey(d => d.AgendaCreatedMemberId)
                .HasConstraintName("FK_tblAgendaActionDetails_tblEmplyeeInfo");

            entity.HasOne(d => d.Agenda).WithMany(p => p.TblAgendaActionDetails)
                .HasForeignKey(d => d.AgendaId)
                .HasConstraintName("FK_tblAgendaActionDetails_tblCoreTeamAgendaInfo");
        });

        modelBuilder.Entity<TblAgentInfoMaster>(entity =>
        {
            entity.ToTable("tblAgentInfoMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.MobileNo).HasMaxLength(30);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblAgentInfoMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblAgentInfoMaster_tblCompanyInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblAgentInfoMasters)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblAgentInfoMaster_tblEmplyeeInfo");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblAgentInfoMasters)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblAgentInfoMaster_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblAssetAssignDetail>(entity =>
        {
            entity.ToTable("tblAssetAssignDetails");

            entity.Property(e => e.AcknowledgementUrl).HasColumnName("AcknowledgementURL");
            entity.Property(e => e.AssignedDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Asset).WithMany(p => p.TblAssetAssignDetails)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK_tblAssetAssignDetails_tblAssetEntryMaster");

            entity.HasOne(d => d.Master).WithMany(p => p.TblAssetAssignDetails)
                .HasForeignKey(d => d.MasterId)
                .HasConstraintName("FK_tblAssetAssignDetails_tblAssetAssignMaster");
        });

        modelBuilder.Entity<TblAssetAssignMaster>(entity =>
        {
            entity.ToTable("tblAssetAssignMaster");

            entity.Property(e => e.AssignedDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblAssetAssignMasters)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblAssetAssignMaster_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblAssetEntryMaster>(entity =>
        {
            entity.ToTable("tblAssetEntryMaster");

            entity.Property(e => e.AssetEntryId).HasMaxLength(250);
            entity.Property(e => e.AssetPhoto2Url).HasColumnName("AssetPhoto2URL");
            entity.Property(e => e.AssetPhoto3Url).HasColumnName("AssetPhoto3URL");
            entity.Property(e => e.AssetPhoto4Url).HasColumnName("AssetPhoto4URL");
            entity.Property(e => e.AssetSource).HasMaxLength(25);
            entity.Property(e => e.BillPhotoUrl).HasColumnName("BillPhotoURL");
            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ImeiSerialNo)
                .HasMaxLength(100)
                .HasColumnName("IMEI_SerialNo");
            entity.Property(e => e.MobileNumber).HasMaxLength(25);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.Ram).HasColumnName("RAM");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SimProvider).HasMaxLength(100);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.WarrantyExpiry).HasColumnType("datetime");

            entity.HasOne(d => d.AssetType).WithMany(p => p.TblAssetEntryMasters)
                .HasForeignKey(d => d.AssetTypeId)
                .HasConstraintName("FK_tblAssetEntryMaster_tblAssetTypeMaster");
        });

        modelBuilder.Entity<TblAssetReturnDetail>(entity =>
        {
            entity.ToTable("tblAssetReturnDetail");

            entity.Property(e => e.ReturnAcknowledgeUrl).HasColumnName("ReturnAcknowledgeURL");
            entity.Property(e => e.ReturnDate).HasColumnType("datetime");

            entity.HasOne(d => d.Asset).WithMany(p => p.TblAssetReturnDetails)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK_tblAssetReturnDetail_tblAssetEntryMaster");

            entity.HasOne(d => d.AssignMaser).WithMany(p => p.TblAssetReturnDetails)
                .HasForeignKey(d => d.AssignMaserId)
                .HasConstraintName("FK_tblAssetReturnDetail_tblAssetAssignMaster");
        });

        modelBuilder.Entity<TblAssetTypeMaster>(entity =>
        {
            entity.ToTable("tblAssetTypeMaster");

            entity.Property(e => e.AssetId).HasMaxLength(50);
            entity.Property(e => e.AssetName).HasMaxLength(500);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblBalanceMaintain>(entity =>
        {
            entity.ToTable("tblBalanceMaintain");

            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.CreditAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Credit_Amt");
            entity.Property(e => e.DebitAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Debit_Amt");
            entity.Property(e => e.OtherIncomeId).HasColumnName("OtherIncomeID");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("Transaction_Date");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Expense).WithMany(p => p.TblBalanceMaintains)
                .HasForeignKey(d => d.ExpenseId)
                .HasConstraintName("FK_tblBalanceMaintain_tblExpensesMaintan");

            entity.HasOne(d => d.Firm).WithMany(p => p.TblBalanceMaintains)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_tblBalanceMaintain_tblBankInfo");

            entity.HasOne(d => d.Ledger).WithMany(p => p.TblBalanceMaintains)
                .HasForeignKey(d => d.LedgerId)
                .HasConstraintName("FK_tblBalanceMaintain_tblInvoiceMaster");

            entity.HasOne(d => d.OtherIncome).WithMany(p => p.TblBalanceMaintains)
                .HasForeignKey(d => d.OtherIncomeId)
                .HasConstraintName("FK_tblBalanceMaintain_tblOtherIncome");

            entity.HasOne(d => d.SecuriteDepoReturn).WithMany(p => p.TblBalanceMaintains)
                .HasForeignKey(d => d.SecuriteDepoReturnId)
                .HasConstraintName("FK_tblBalanceMaintain_tblSecuriteDepositeReturn");
        });

        modelBuilder.Entity<TblBankInfo>(entity =>
        {
            entity.ToTable("tblBankInfo");

            entity.Property(e => e.BankQr).HasColumnName("BankQR");
            entity.Property(e => e.BankQrurl).HasColumnName("BankQRUrl");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Ifsccode).HasColumnName("IFSCCode");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblBankInfos)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblBankInfo_tblCompanyInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblBankInfos)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblBankInfo_tblEmplyeeInfo");

            entity.HasOne(d => d.Firm).WithMany(p => p.TblBankInfos)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_tblBankInfo_FrimInvoiceMaster");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblBankInfos)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblBankInfo_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblBugRequirementInfoMaster>(entity =>
        {
            entity.ToTable("TblBugRequirementInfoMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeadLineDate).HasColumnType("datetime");
            entity.Property(e => e.Requirement).HasMaxLength(50);
            entity.Property(e => e.RequirementDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblBugRequirementInfoMasters)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_TblBugRequirementInfoMaster_tblCustomerInfo");

            entity.HasOne(d => d.Developer).WithMany(p => p.TblBugRequirementInfoMasterDevelopers)
                .HasForeignKey(d => d.DeveloperId)
                .HasConstraintName("FK_TblBugRequirementInfoMaster_tblEmplyeeInfo1");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblBugRequirementInfoMasterEmps)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TblBugRequirementInfoMaster_tblEmplyeeInfo");

            entity.HasOne(d => d.Project).WithMany(p => p.TblBugRequirementInfoMasters)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_TblBugRequirementInfoMaster_tblProjectMaster");
        });

        modelBuilder.Entity<TblBusinessTourExpenseMst>(entity =>
        {
            entity.ToTable("TblBusinessTourExpenseMst");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DateOfTravel).HasColumnType("datetime");
            entity.Property(e => e.FormNo).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblCompanyInfo>(entity =>
        {
            entity.ToTable("tblCompanyInfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountHolderName).HasColumnName("account_Holder_Name");
            entity.Property(e => e.AccountNo).HasColumnName("account_No");
            entity.Property(e => e.AccountType)
                .HasMaxLength(100)
                .HasColumnName("account_Type");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.BankAddress).HasColumnName("bank_Address");
            entity.Property(e => e.BankName).HasColumnName("bank_Name");
            entity.Property(e => e.Branch).HasColumnName("branch");
            entity.Property(e => e.BuisnessType).HasColumnName("buisness_Type");
            entity.Property(e => e.ComapnyLogoName).HasColumnName("comapny_Logo_Name");
            entity.Property(e => e.CompanyLogoUrl).HasColumnName("company_Logo_URL");
            entity.Property(e => e.CompanyName).HasColumnName("company_Name");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_On");
            entity.Property(e => e.EmailAddress1).HasColumnName("email_Address_1");
            entity.Property(e => e.EmailAddress2).HasColumnName("email_Address_2");
            entity.Property(e => e.GstNo).HasColumnName("gst_No");
            entity.Property(e => e.IfscNo).HasColumnName("ifsc_No");
            entity.Property(e => e.MobileNo1)
                .HasMaxLength(20)
                .HasColumnName("mobile_No_1");
            entity.Property(e => e.MobileNo2)
                .HasMaxLength(20)
                .HasColumnName("mobile_No_2");
            entity.Property(e => e.Pincode)
                .HasMaxLength(20)
                .HasColumnName("pincode");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_On");
        });

        modelBuilder.Entity<TblCompletedDeployment>(entity =>
        {
            entity.ToTable("tblCompletedDeployments");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeploymentDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.DeploymentEmp).WithMany(p => p.TblCompletedDeployments)
                .HasForeignKey(d => d.DeploymentEmpId)
                .HasConstraintName("FK_tblCompletedDeployments_tblEmplyeeInfo");

            entity.HasOne(d => d.PendingDeployment).WithMany(p => p.TblCompletedDeployments)
                .HasForeignKey(d => d.PendingDeploymentId)
                .HasConstraintName("FK_tblCompletedDeployments_tblPendingDeployments");

            entity.HasOne(d => d.Task).WithMany(p => p.TblCompletedDeployments)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_tblCompletedDeployments_tblTaskManagementInfo");
        });

        modelBuilder.Entity<TblCoreTeamAgendaInfo>(entity =>
        {
            entity.ToTable("tblCoreTeamAgendaInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.TakeActionDate).HasColumnType("datetime");
            entity.Property(e => e.TargetSolutionDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.CoreTeamMem).WithMany(p => p.TblCoreTeamAgendaInfos)
                .HasForeignKey(d => d.CoreTeamMemId)
                .HasConstraintName("FK_tblCoreTeamAgendaInfo_tblEmplyeeInfo");

            entity.HasOne(d => d.Department).WithMany(p => p.TblCoreTeamAgendaInfos)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_tblCoreTeamAgendaInfo_tblDepartmentInfo");
        });

        modelBuilder.Entity<TblCustOnboardFollowupConvDetail>(entity =>
        {
            entity.ToTable("tblCustOnboardFollowupConvDetails");

            entity.Property(e => e.CreatedOndate).HasColumnType("datetime");
            entity.Property(e => e.FollowupDate).HasColumnType("datetime");

            entity.HasOne(d => d.CustOnboardingDetails).WithMany(p => p.TblCustOnboardFollowupConvDetails)
                .HasForeignKey(d => d.CustOnboardingDetailsid)
                .HasConstraintName("FK_tblCustOnboardFollowupConvDetails_tblCustomerOnboardingDetails1");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblCustOnboardFollowupConvDetails)
                .HasForeignKey(d => d.Empid)
                .HasConstraintName("FK_tblCustOnboardFollowupConvDetails_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblCustomerInfo>(entity =>
        {
            entity.ToTable("tblCustomerInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Gstno).HasColumnName("GSTNo");
            entity.Property(e => e.InstallationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblCustomerInfos)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblCustomerInfo_tblCompanyInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblCustomerInfoEmps)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblCustomerInfo_tblEmplyeeInfo1");

            entity.HasOne(d => d.FavouriteEmp).WithMany(p => p.TblCustomerInfoFavouriteEmps)
                .HasForeignKey(d => d.FavouriteEmpId)
                .HasConstraintName("FK_tblCustomerInfo_tblEmplyeeInfo");

            entity.HasOne(d => d.Package).WithMany(p => p.TblCustomerInfos)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_tblCustomerInfo_tblPackageInfoMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.TblCustomerInfos)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblCustomerInfo_tblProductTypeInfoMaster");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblCustomerInfos)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblCustomerInfo_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblCustomerOnboardingDetail>(entity =>
        {
            entity.ToTable("tblCustomerOnboardingDetails");

            entity.Property(e => e.CompletedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CustOnboardingMst).WithMany(p => p.TblCustomerOnboardingDetails)
                .HasForeignKey(d => d.CustOnboardingMstId)
                .HasConstraintName("FK_tblCustomerOnboardingDetails_tblCustomerOnboardingMST");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblCustomerOnboardingDetails)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblCustomerOnboardingDetails_tblEmplyeeInfo");

            entity.HasOne(d => d.TitleMst).WithMany(p => p.TblCustomerOnboardingDetails)
                .HasForeignKey(d => d.TitleMstId)
                .HasConstraintName("FK_tblCustomerOnboardingDetails_tblTitleMaster");
        });

        modelBuilder.Entity<TblCustomerOnboardingMst>(entity =>
        {
            entity.ToTable("tblCustomerOnboardingMST");

            entity.Property(e => e.CompleteDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeleteDate).HasColumnType("datetime");
            entity.Property(e => e.HoldDate).HasColumnType("datetime");
            entity.Property(e => e.MilkatSankya).HasMaxLength(50);
            entity.Property(e => e.NamplateSankya).HasMaxLength(50);
            entity.Property(e => e.Orderamount)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("orderamount");
            entity.Property(e => e.UpdatedBy).HasColumnName("UpdatedBY");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblCustomerOnboardingMsts)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblCustomerOnboardingMST_tblCompanyInfo");

            entity.HasOne(d => d.CompletedEmp).WithMany(p => p.TblCustomerOnboardingMstCompletedEmps)
                .HasForeignKey(d => d.CompletedEmpId)
                .HasConstraintName("FK_tblCustomerOnboardingMST_tblEmplyeeInfo");

            entity.HasOne(d => d.DeleteEmp).WithMany(p => p.TblCustomerOnboardingMstDeleteEmps)
                .HasForeignKey(d => d.DeleteEmpId)
                .HasConstraintName("FK_tblCustomerOnboardingMST_tblEmplyeeInfo1");

            entity.HasOne(d => d.Project).WithMany(p => p.TblCustomerOnboardingMsts)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_tblCustomerOnboardingMST_tblProductTypeInfoMaster");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblCustomerOnboardingMsts)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblCustomerOnboardingMST_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblCustomerTraining>(entity =>
        {
            entity.ToTable("TblCustomerTraining");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblCustomerTrainings)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TblCustomerTraining_tblEmplyeeInfo");

            entity.HasOne(d => d.Project).WithMany(p => p.TblCustomerTrainings)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_TblCustomerTraining_tblProductTypeInfoMaster");
        });

        modelBuilder.Entity<TblDailyTaskManagementDetail>(entity =>
        {
            entity.ToTable("tblDailyTaskManagementDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndTime).HasColumnName("end_time");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.StartTime).HasColumnName("start_time");
            entity.Property(e => e.TaskDescription).HasColumnName("task_description");
            entity.Property(e => e.TaskTitle).HasColumnName("task_title");
            entity.Property(e => e.TaskTypeId).HasColumnName("task_type_id");
            entity.Property(e => e.TblDailyTaskMstId).HasColumnName("tblDailyTaskMst_id");

            entity.HasOne(d => d.Developer).WithMany(p => p.TblDailyTaskManagementDetails)
                .HasForeignKey(d => d.DeveloperId)
                .HasConstraintName("FK_tblDailyTaskManagementDetail_tblEmplyeeInfo");

            entity.HasOne(d => d.Project).WithMany(p => p.TblDailyTaskManagementDetails)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_tblDailyTaskManagementDetail_tblProjectMaster");

            entity.HasOne(d => d.TaskType).WithMany(p => p.TblDailyTaskManagementDetails)
                .HasForeignKey(d => d.TaskTypeId)
                .HasConstraintName("FK_tblDailyTaskManagementDetail_tblTaskTypeMaster");

            entity.HasOne(d => d.TblDailyTaskMst).WithMany(p => p.TblDailyTaskManagementDetails)
                .HasForeignKey(d => d.TblDailyTaskMstId)
                .HasConstraintName("FK_tblDailyTaskManagementDetail_tblDailyTaskManagementMst");
        });

        modelBuilder.Entity<TblDailyTaskManagementMst>(entity =>
        {
            entity.ToTable("tblDailyTaskManagementMst");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblDailyTaskManagementMsts)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblDailyTaskManagementMst_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblDepartmentInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblDepartement");

            entity.ToTable("tblDepartmentInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblDepartmentInfos)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblDepartmentInfo_tblCompanyInfo");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblDepartmentInfoCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_tblDepartmentInfo_tblEmplyeeInfo");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblDepartmentInfoUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_tblDepartmentInfo_tblEmplyeeInfo1");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblDepartmentInfos)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblDepartmentInfo_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblDeploymentOnLive>(entity =>
        {
            entity.ToTable("tblDeploymentOnLive");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeploymentDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblDeploymentOnLives)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblDeploymentOnLive_tblEmplyeeInfo");

            entity.HasOne(d => d.Project).WithMany(p => p.TblDeploymentOnLives)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_tblDeploymentOnLive_tblProjectMaster");
        });

        modelBuilder.Entity<TblDomain>(entity =>
        {
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblEmployeeRechargeMaster>(entity =>
        {
            entity.ToTable("tblEmployeeRechargeMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LastRechargeDate).HasColumnType("datetime");
            entity.Property(e => e.RechargeAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Validity).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblEmployeeRechargeMasters)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblEmployeeRechargeMaster_tblEmplyeeInfo");

            entity.HasOne(d => d.Firm).WithMany(p => p.TblEmployeeRechargeMasters)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_tblEmployeeRechargeMaster_FrimInvoiceMaster");
        });

        modelBuilder.Entity<TblEmplyeeInfo>(entity =>
        {
            entity.ToTable("tblEmplyeeInfo");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmpId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeStatus).HasMaxLength(50);
            entity.Property(e => e.Ifsccode).HasColumnName("IFSCCode");
            entity.Property(e => e.JoiningDate).HasColumnType("datetime");
            entity.Property(e => e.Pincode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblEmplyeeInfos)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblEmplyeeInfo_tblCompanyInfo");

            entity.HasOne(d => d.Department).WithMany(p => p.TblEmplyeeInfos)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_tblEmplyeeInfo_tblDepartementInfo");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblEmplyeeInfos)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblEmplyeeInfo_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblExpensesDetail>(entity =>
        {
            entity.ToTable("tblExpensesDetail");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblExpensesDetails)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblExpensesDetail_tblCompanyInfo");

            entity.HasOne(d => d.ExpensesMst).WithMany(p => p.TblExpensesDetails)
                .HasForeignKey(d => d.ExpensesMstId)
                .HasConstraintName("FK_tblExpensesDetail_tblExpensesInfo");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblExpensesDetails)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblExpensesDetail_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblExpensesInfo>(entity =>
        {
            entity.ToTable("tblExpensesInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblExpensesInfos)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblExpensesInfo_tblCompanyInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblExpensesInfos)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblExpensesInfo_tblEmplyeeInfo");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblExpensesInfos)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblExpensesInfo_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblExpensesMaintain>(entity =>
        {
            entity.ToTable("tblExpensesMaintain");

            entity.Property(e => e.AdvanceAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CheckDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ExpensesDate).HasColumnType("datetime");
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionType).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Upiid).HasColumnName("UPIid");
            entity.Property(e => e.UtrNo).HasColumnName("UtrNO");

            entity.HasOne(d => d.Bank).WithMany(p => p.TblExpensesMaintains)
                .HasForeignKey(d => d.BankId)
                .HasConstraintName("FK_tblExpensesMaintain_tblBankInfo");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblExpensesMaintains)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tblExpensesMaintain_tblCustomerInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblExpensesMaintains)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblExpensesMaintain_tblEmplyeeInfo");

            entity.HasOne(d => d.Expenses).WithMany(p => p.TblExpensesMaintains)
                .HasForeignKey(d => d.ExpensesId)
                .HasConstraintName("FK_tblExpensesMaintain_tblExpensesInfo");

            entity.HasOne(d => d.ExpensesSubType).WithMany(p => p.TblExpensesMaintains)
                .HasForeignKey(d => d.ExpensesSubTypeId)
                .HasConstraintName("FK_tblExpensesMaintain_tblExpensesDetail");

            entity.HasOne(d => d.Firm).WithMany(p => p.TblExpensesMaintains)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_tblExpensesMaintain_FrimInvoiceMaster");
        });

        modelBuilder.Entity<TblExportDataDetail>(entity =>
        {
            entity.ToTable("tblExportDataDetails");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblFacilityMaster>(entity =>
        {
            entity.ToTable("tblFacilityMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblFacilityMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblFacilityMaster_tblCompanyInfo");
        });

        modelBuilder.Entity<TblFeedbackInfo>(entity =>
        {
            entity.ToTable("tblFeedbackInfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.FeedbackImagevideo).HasColumnName("feedback_imagevideo");
            entity.Property(e => e.FeedbackImagevideoUrl).HasColumnName("feedback_imagevideo_url");
            entity.Property(e => e.FeedbackOn).HasColumnName("feedback_on");
            entity.Property(e => e.GramId).HasColumnName("gram_id");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");

            entity.HasOne(d => d.Company).WithMany(p => p.TblFeedbackInfos)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblFeedbackInfo_tblCompanyInfo");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblFeedbackInfos)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tblFeedbackInfo_tblCustomerInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblFeedbackInfos)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblFeedbackInfo_tblEmplyeeInfo");

            entity.HasOne(d => d.Vendor).WithMany(p => p.TblFeedbackInfos)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK_tblFeedbackInfo_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblFollowupTypeMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblFollowupType");

            entity.ToTable("tblFollowupTypeMaster");

            entity.HasOne(d => d.Company).WithMany(p => p.TblFollowupTypeMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblFollowupTypeMaster_tblCompanyInfo");
        });

        modelBuilder.Entity<TblGalleryForWebsite>(entity =>
        {
            entity.ToTable("tblGalleryForWebsite");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblGpRegistrationWebsite>(entity =>
        {
            entity.ToTable("TblGpRegistrationWebsite");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.MobileNo).HasMaxLength(50);
            entity.Property(e => e.ReferenceByMobileNo).HasMaxLength(50);
            entity.Property(e => e.SelesAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblGpWebsiteInternalStatus>(entity =>
        {
            entity.ToTable("tblGpWebsiteInternalStatus");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.TaskStatus).WithMany(p => p.TblGpWebsiteInternalStatuses)
                .HasForeignKey(d => d.TaskStatusId)
                .HasConstraintName("FK_tblGpWebsiteInternalStatus_tblTaskStatusMaster");
        });

        modelBuilder.Entity<TblGramSevakExcelReportTracking>(entity =>
        {
            entity.ToTable("tblGramSevakExcelReportTracking");

            entity.Property(e => e.ExportedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblGramsevakFollowUpMobileApp>(entity =>
        {
            entity.ToTable("tblGramsevakFollowUpMobileApp");

            entity.Property(e => e.ContectNo).HasMaxLength(100);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.District).HasMaxLength(100);
            entity.Property(e => e.Gpname)
                .HasMaxLength(100)
                .HasColumnName("GPName");
            entity.Property(e => e.Gsname)
                .HasMaxLength(100)
                .HasColumnName("GSName");
            entity.Property(e => e.NextFollowUpDate).HasColumnType("datetime");
            entity.Property(e => e.Talukha).HasMaxLength(100);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblGramsevakFollowUpMobileApps)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblGramsevakFollowUpMobileApp_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblGramsevakInfo>(entity =>
        {
            entity.ToTable("tblGramsevakInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblHolidayCalender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblHoliday");

            entity.ToTable("tblHolidayCalender");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblImageTypeMst>(entity =>
        {
            entity.ToTable("tblImageTypeMst");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblInAppNotification>(entity =>
        {
            entity.ToTable("TblInAppNotification");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblInAppNotifications)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TblInAppNotification_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblInOutPass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblInOut__3214EC0786A115D5");

            entity.ToTable("tblInOutPass");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.MobileNo).HasMaxLength(15);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblInOutPasses)
                .HasForeignKey(d => d.Empid)
                .HasConstraintName("FK_tblInOutPass_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblInvoiceDetail>(entity =>
        {
            entity.ToTable("tblInvoiceDetail");

            entity.Property(e => e.Qty).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Invoice).WithMany(p => p.TblInvoiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblInvoiceDetail_tblInvoiceMaster");

            entity.HasOne(d => d.Package).WithMany(p => p.TblInvoiceDetails)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_tblInvoiceDetail_tblPackageInfoMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.TblInvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblInvoiceDetail_tblProductTypeInfoMaster");
        });

        modelBuilder.Entity<TblInvoiceMaster>(entity =>
        {
            entity.ToTable("tblInvoiceMaster");

            entity.Property(e => e.BalanceAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BankId).HasColumnName("BankID");
            entity.Property(e => e.Chequedate).HasColumnType("datetime");
            entity.Property(e => e.Chequeno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Commission).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Neftrtgsref1).HasColumnName("NEFTRTGSRef1");
            entity.Property(e => e.Neftrtgsref2).HasColumnName("NEFTRTGSRef2");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PendingAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReceiptDate).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Utrno).HasColumnName("UTRNo");

            entity.HasOne(d => d.Bill).WithMany(p => p.TblInvoiceMasters)
                .HasForeignKey(d => d.BillId)
                .HasConstraintName("FK_tblInvoiceMaster_TaxableInvoiceMaster");

            entity.HasOne(d => d.BillIdWithoutGstNavigation).WithMany(p => p.TblInvoiceMasters)
                .HasForeignKey(d => d.BillIdWithoutGst)
                .HasConstraintName("FK_tblInvoiceMaster_TaxInvoiceMSTWithoutGST");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblInvoiceMasters)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblInvoiceMaster_tblCustomerInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblInvoiceMasters)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblInvoiceMaster_tblEmplyeeInfo");

            entity.HasOne(d => d.Firm).WithMany(p => p.TblInvoiceMasters)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_tblInvoiceMaster_FrimInvoiceMaster");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.TblInvoiceMasters)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK_tblInvoiceMaster_tblfreelancer_master");
        });

        modelBuilder.Entity<TblKrakpi>(entity =>
        {
            entity.ToTable("tblKRAKPI");

            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.UploadedOn).HasColumnType("datetime");

            entity.HasOne(d => d.DesignationNavigation).WithMany(p => p.TblKrakpis)
                .HasForeignKey(d => d.Designation)
                .HasConstraintName("FK_tblKRAKPI_Designation");
        });

        modelBuilder.Entity<TblLeadCancelReasonMst>(entity =>
        {
            entity.ToTable("tblLeadCancelReasonMst");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientType).HasColumnName("client_type");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.LeadCancelReason).HasColumnName("lead_cancel_reason");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");

            entity.HasOne(d => d.Company).WithMany(p => p.TblLeadCancelReasonMsts)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblLeadCancelReasonMst_tblCompanyInfo");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblLeadCancelReasonMsts)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblLeadCancelReasonMst_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblLeadReasonInfo>(entity =>
        {
            entity.ToTable("tblLeadReasonInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Lead).WithMany(p => p.TblLeadReasonInfos)
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("FK_tblLeadReasonInfo_tblLeadandOpportunitesinfo");

            entity.HasOne(d => d.Reason).WithMany(p => p.TblLeadReasonInfos)
                .HasForeignKey(d => d.ReasonId)
                .HasConstraintName("FK_tblLeadReasonInfo_tblReasonInfoMaster");
        });

        modelBuilder.Entity<TblLeadandOpportunitesinfo>(entity =>
        {
            entity.ToTable("tblLeadandOpportunitesinfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.LeadCancelReasonId).HasColumnName("lead_cancel_reason_id");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblLeadandOpportunitesinfos)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblLeadandOpportunitesinfo_tblEmplyeeInfo");

            entity.HasOne(d => d.LeadCancelReason).WithMany(p => p.TblLeadandOpportunitesinfos)
                .HasForeignKey(d => d.LeadCancelReasonId)
                .HasConstraintName("FK_tblLeadandOpportunitesinfo_tblLeadCancelReasonMst");

            entity.HasOne(d => d.Package).WithMany(p => p.TblLeadandOpportunitesinfos)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_tblLeadandOpportunitesinfo_tblPackageInfoMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.TblLeadandOpportunitesinfos)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("FK_tblLeadandOpportunitesinfo_tblProductTypeInfoMaster");
        });

        modelBuilder.Entity<TblLeaveRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblLeave__3214EC0747FFBFDF");

            entity.ToTable("TblLeaveRequest");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.Hrcomment).HasColumnName("HRComment");
            entity.Property(e => e.LeaveCategory).HasMaxLength(50);
            entity.Property(e => e.LeaveType).HasMaxLength(50);
            entity.Property(e => e.RequestType).HasMaxLength(50);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValueSql("('Pending')");
            entity.Property(e => e.Subject).HasMaxLength(200);
            entity.Property(e => e.Tlcomment).HasColumnName("TLComment");
            entity.Property(e => e.Tlstatus).HasColumnName("TLStatus");
            entity.Property(e => e.ToDate).HasColumnType("date");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblLeaveRequests)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblLeaveRequest_Employee");
        });

        modelBuilder.Entity<TblLocationExpense>(entity =>
        {
            entity.ToTable("TblLocationExpense");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.BusinessTourExpenseMst).WithMany(p => p.TblLocationExpenses)
                .HasForeignKey(d => d.BusinessTourExpenseMstId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblLocationExpense_TblBusinessTourExpenseMst");
        });

        modelBuilder.Entity<TblLoginAnalysis>(entity =>
        {
            entity.ToTable("tblLoginAnalysis");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblLoginInfo>(entity =>
        {
            entity.ToTable("tblLoginInfo");

            entity.Property(e => e.Role).HasMaxLength(50);

            entity.HasOne(d => d.Employee).WithMany(p => p.TblLoginInfos)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_tblLoginInfo_tblEmplyeeInfo");

            entity.HasOne(d => d.RoleNavigation).WithMany(p => p.TblLoginInfos)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_tblLoginInfo_tblLoginInfo");
        });

        modelBuilder.Entity<TblLoginServerDetail>(entity =>
        {
            entity.ToTable("tblLoginServerDetails");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Ipaddress).HasColumnName("IPAddress");
        });

        modelBuilder.Entity<TblMettingDecision>(entity =>
        {
            entity.ToTable("TblMettingDecision");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.MettingDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblMettingDecisionEmps)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TblMettingDecision_tblEmplyeeInfo1");

            entity.HasOne(d => d.ResponsiblePersonNavigation).WithMany(p => p.TblMettingDecisionResponsiblePersonNavigations)
                .HasForeignKey(d => d.ResponsiblePerson)
                .HasConstraintName("FK_TblMettingDecision_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblModelMaster>(entity =>
        {
            entity.ToTable("tblModelMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblMomdetail>(entity =>
        {
            entity.ToTable("tblMOMDetails");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.MeetingDate).HasColumnType("datetime");
            entity.Property(e => e.MomdraftDetails).HasColumnName("MOMDraftDetails");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblMovementRegister>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblMovem__3214EC07FD739CE3");

            entity.ToTable("TblMovementRegister");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LogDate).HasColumnType("date");
            entity.Property(e => e.Reason).HasMaxLength(100);
        });

        modelBuilder.Entity<TblNotificationMaster>(entity =>
        {
            entity.ToTable("tblNotificationMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.NotificationStartDate).HasColumnType("datetime");
            entity.Property(e => e.NotificationStopDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblNotificationMasters)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblNotificationMaster_tblEmplyeeInfo");

            entity.HasOne(d => d.Project).WithMany(p => p.TblNotificationMasters)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_tblNotificationMaster_tblProjectMaster");
        });

        modelBuilder.Entity<TblObjectionMst>(entity =>
        {
            entity.ToTable("tblObjectionMst");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblObjectionMsts)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblObjectionMst_tblEmplyeeInfo");

            entity.HasOne(d => d.Product).WithMany(p => p.TblObjectionMsts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblObjectionMst_tblProductTypeInfoMaster");
        });

        modelBuilder.Entity<TblOperation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblOpera__3214EC07626B1A18");

            entity.ToTable("tblOperation");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.TblOperations)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_tblOperation_tblCustomerInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblOperations)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblOperation_tblEmplyeeInfo");

            entity.HasOne(d => d.OperationTitle).WithMany(p => p.TblOperations)
                .HasForeignKey(d => d.OperationTitleId)
                .HasConstraintName("FK_tblOperation_tblOperationTitle");
        });

        modelBuilder.Entity<TblOperationDepCheckListDetail>(entity =>
        {
            entity.ToTable("tblOperationDepCheckListDetails");

            entity.HasOne(d => d.OperationDepCheckListMst).WithMany(p => p.TblOperationDepCheckListDetails)
                .HasForeignKey(d => d.OperationDepCheckListMstId)
                .HasConstraintName("FK_tblOperationDepCheckListDetails_tblOperationDepOnCheckListMst");
        });

        modelBuilder.Entity<TblOperationDepOnCheckListMst>(entity =>
        {
            entity.ToTable("tblOperationDepOnCheckListMst");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ExcelApprovedDate).HasColumnType("datetime");
            entity.Property(e => e.ExcelCreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExcelUniqueKey).HasMaxLength(50);
            entity.Property(e => e.NamunaType).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblOperationTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblOperation");

            entity.ToTable("tblOperationTitle");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblOperatorDetail>(entity =>
        {
            entity.ToTable("tblOperatorDetails");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblOtherExpense>(entity =>
        {
            entity.ToTable("TblOtherExpense");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.BusinessTourExpenseMst).WithMany(p => p.TblOtherExpenses)
                .HasForeignKey(d => d.BusinessTourExpenseMstId)
                .HasConstraintName("FK_TblOtherExpense_TblBusinessTourExpenseMst");
        });

        modelBuilder.Entity<TblOtherExpenseSubtype>(entity =>
        {
            entity.ToTable("TblOtherExpenseSubtype");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblOtherExpenseSubtypes)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TblOtherExpenseSubtype_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblOtherIncome>(entity =>
        {
            entity.ToTable("tblOtherIncome");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BalanceAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ChequeDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.FirmId).HasColumnName("firmId");
            entity.Property(e => e.InvoiceAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Upiid).HasColumnName("UPIid");
            entity.Property(e => e.UtrNo).HasColumnName("UtrNO");

            entity.HasOne(d => d.Company).WithMany(p => p.TblOtherIncomes)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblOtherIncome_tblCompanyInfo");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblOtherIncomes)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tblOtherIncome_tblCustomerInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblOtherIncomes)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblOtherIncome_tblEmplyeeInfo");

            entity.HasOne(d => d.Firm).WithMany(p => p.TblOtherIncomes)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_tblOtherIncome_FrimInvoiceMaster");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.TblOtherIncomes)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK_tblOtherIncome_tblfreelancer_master");
        });

        modelBuilder.Entity<TblPackageInfoMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblPackageInfo");

            entity.ToTable("tblPackageInfoMaster");

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Company).WithMany(p => p.TblPackageInfoMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblPackageInfoMaster_tblCompanyInfo");

            entity.HasOne(d => d.Product).WithMany(p => p.TblPackageInfoMasters)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblPackageInfoMaster_tblProductTypeInfoMaster");
        });

        modelBuilder.Entity<TblPageNavigation>(entity =>
        {
            entity.ToTable("tblPageNavigation");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblPaymentFollowupInfo>(entity =>
        {
            entity.ToTable("tblPaymentFollowupInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FollowupDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblPaymentFollowupInfoCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_tblPaymentFollowupInfo_tblEmplyeeInfo");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblPaymentFollowupInfos)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPaymentFollowupInfo_tblCustomerInfo");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblPaymentFollowupInfoUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_tblPaymentFollowupInfo_tblEmplyeeInfo1");
        });

        modelBuilder.Entity<TblPendingDeployment>(entity =>
        {
            entity.ToTable("tblPendingDeployments");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.TaskCompleteDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblPendingDeployments)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblPendingDeployments_tblEmplyeeInfo");

            entity.HasOne(d => d.Task).WithMany(p => p.TblPendingDeployments)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_tblPendingDeployments_tblTaskManagementInfo");
        });

        modelBuilder.Entity<TblPolicyDetail>(entity =>
        {
            entity.ToTable("tblPolicyDetails");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Policy).WithMany(p => p.TblPolicyDetails)
                .HasForeignKey(d => d.PolicyId)
                .HasConstraintName("FK_tblPolicyDetails_tblPolicyInfo");
        });

        modelBuilder.Entity<TblPolicyInfo>(entity =>
        {
            entity.ToTable("tblPolicyInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblProductTypeInfoMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblProductTypeInfo");

            entity.ToTable("tblProductTypeInfoMaster");

            entity.Property(e => e.Hsnno).HasColumnName("HSNNo");

            entity.HasOne(d => d.Company).WithMany(p => p.TblProductTypeInfoMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblProductTypeInfoMaster_tblCompanyInfo");
        });

        modelBuilder.Entity<TblProformaInvoiceDetail>(entity =>
        {
            entity.ToTable("tblProformaInvoiceDetail");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Gst).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TexableAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Pakage).WithMany(p => p.TblProformaInvoiceDetails)
                .HasForeignKey(d => d.PakageId)
                .HasConstraintName("FK_tblProformaInvoiceDetail_tblPackageInfoMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.TblProformaInvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblProformaInvoiceDetail_tblProductTypeInfoMaster");

            entity.HasOne(d => d.ProformaInvoiceMaster).WithMany(p => p.TblProformaInvoiceDetails)
                .HasForeignKey(d => d.ProformaInvoiceMasterId)
                .HasConstraintName("FK_tblProformaInvoiceDetail_tblProformaInvoiceMaster");
        });

        modelBuilder.Entity<TblProformaInvoiceDetailWithoutGst>(entity =>
        {
            entity.ToTable("tblProformaInvoiceDetailWithoutGST");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProformaMasterWithoutGstid).HasColumnName("ProformaMasterWithoutGSTId");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Pakage).WithMany(p => p.TblProformaInvoiceDetailWithoutGsts)
                .HasForeignKey(d => d.PakageId)
                .HasConstraintName("FK_tblProformaInvoiceDetailWithoutGST_tblPackageInfoMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.TblProformaInvoiceDetailWithoutGsts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblProformaInvoiceDetailWithoutGST_tblProductTypeInfoMaster");

            entity.HasOne(d => d.ProformaMasterWithoutGst).WithMany(p => p.TblProformaInvoiceDetailWithoutGsts)
                .HasForeignKey(d => d.ProformaMasterWithoutGstid)
                .HasConstraintName("FK_tblProformaInvoiceDetailWithoutGST_tblProformaInvoiceMstWithoutGST");
        });

        modelBuilder.Entity<TblProformaInvoiceMaster>(entity =>
        {
            entity.ToTable("tblProformaInvoiceMaster");

            entity.Property(e => e.CommisisonAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Agent).WithMany(p => p.TblProformaInvoiceMasters)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK_tblProformaInvoiceMaster_tblAgentInfoMaster");

            entity.HasOne(d => d.Company).WithMany(p => p.TblProformaInvoiceMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblProformaInvoiceMaster_tblCompanyInfo");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblProformaInvoiceMasters)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tblProformaInvoiceMaster_tblCustomerInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblProformaInvoiceMasters)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblProformaInvoiceMaster_tblEmplyeeInfo");

            entity.HasOne(d => d.Firm).WithMany(p => p.TblProformaInvoiceMasters)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_tblProformaInvoiceMaster_FrimInvoiceMaster");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.TblProformaInvoiceMasters)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK_tblProformaInvoiceMaster_tblfreelancer_master");

            entity.HasOne(d => d.Stategy).WithMany(p => p.TblProformaInvoiceMasters)
                .HasForeignKey(d => d.StategyId)
                .HasConstraintName("FK_tblProformaInvoiceMaster_tblStategyMaster");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblProformaInvoiceMasters)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblProformaInvoiceMaster_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblProformaInvoiceMstWithoutGst>(entity =>
        {
            entity.ToTable("tblProformaInvoiceMstWithoutGST");

            entity.Property(e => e.CommisisonAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.NetAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Agent).WithMany(p => p.TblProformaInvoiceMstWithoutGsts)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK_tblProformaInvoiceMstWithoutGST_tblAgentInfoMaster");

            entity.HasOne(d => d.Company).WithMany(p => p.TblProformaInvoiceMstWithoutGsts)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblProformaInvoiceMstWithoutGST_tblCompanyInfo");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblProformaInvoiceMstWithoutGsts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tblProformaInvoiceMstWithoutGST_tblCustomerInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblProformaInvoiceMstWithoutGsts)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblProformaInvoiceMstWithoutGST_tblEmplyeeInfo");

            entity.HasOne(d => d.Firm).WithMany(p => p.TblProformaInvoiceMstWithoutGsts)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_tblProformaInvoiceMstWithoutGST_FrimInvoiceMaster");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.TblProformaInvoiceMstWithoutGsts)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK_tblProformaInvoiceMstWithoutGST_tblfreelancer_master");

            entity.HasOne(d => d.Stategy).WithMany(p => p.TblProformaInvoiceMstWithoutGsts)
                .HasForeignKey(d => d.StategyId)
                .HasConstraintName("FK_tblProformaInvoiceMstWithoutGST_tblStategyMaster");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblProformaInvoiceMstWithoutGsts)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblProformaInvoiceMstWithoutGST_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblProjectMaster>(entity =>
        {
            entity.ToTable("tblProjectMaster");

            entity.Property(e => e.Date).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblPunctuality>(entity =>
        {
            entity.ToTable("tblPunctuality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblPunctualities)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblPunctuality_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblPushSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblPushS__3214EC0749CCBBBF");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblPushSubscriptions)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TblPushSubscriptions_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblQuestionAnswerDetail>(entity =>
        {
            entity.ToTable("tblQuestionAnswerDetail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer).HasColumnName("answer");
            entity.Property(e => e.AnswerAccepted).HasColumnName("answer_accepted");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.QueAnsMstId).HasColumnName("que_ans_mst_id");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblQuestionAnswerDetails)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblQuestionAnswerDetail_tblEmplyeeInfo");

            entity.HasOne(d => d.QueAnsMst).WithMany(p => p.TblQuestionAnswerDetails)
                .HasForeignKey(d => d.QueAnsMstId)
                .HasConstraintName("FK_tblQuestionAnswerDetail_tblQuestionAnswerMaster");
        });

        modelBuilder.Entity<TblQuestionAnswerMaster>(entity =>
        {
            entity.ToTable("tblQuestionAnswerMaster");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.ImageName).HasColumnName("image_name");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url");
            entity.Property(e => e.MensionEmpId).HasColumnName("mension_emp_Id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.QuestionTitle).HasColumnName("question_title");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Updated)
                .HasColumnType("datetime")
                .HasColumnName("updated");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblQuestionAnswerMasters)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblQuestionAnswerMaster_tblEmplyeeInfo1");

            entity.HasOne(d => d.Product).WithMany(p => p.TblQuestionAnswerMasters)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblQuestionAnswerMaster_tblProductTypeInfoMaster");
        });

        modelBuilder.Entity<TblReasonInfoMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblReasonInfo");

            entity.ToTable("tblReasonInfoMaster");

            entity.HasOne(d => d.Company).WithMany(p => p.TblReasonInfoMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblReasonInfoMaster_tblCompanyInfo");
        });

        modelBuilder.Entity<TblRoleInfo>(entity =>
        {
            entity.ToTable("tblRoleInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblRoleInfos)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblRoleInfo_tblCompanyInfo");
        });

        modelBuilder.Entity<TblSaleDepFollowUpTypeMaster>(entity =>
        {
            entity.ToTable("tblSaleDepFollowUpTypeMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblSaleNewStrategy>(entity =>
        {
            entity.ToTable("tblSaleNewStrategy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.IsApplyToCustomer).HasColumnName("is_apply_to_customer");
            entity.Property(e => e.NewStatergyImage).HasColumnName("new_statergy_image");
            entity.Property(e => e.NewStatergyImageUrl).HasColumnName("new_statergy_image_url");
            entity.Property(e => e.StrategyName).HasColumnName("strategy_name");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");

            entity.HasOne(d => d.Company).WithMany(p => p.TblSaleNewStrategies)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblSaleNewStrategy_tblCompanyInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblSaleNewStrategies)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblSaleNewStrategy_tblEmplyeeInfo");

            entity.HasOne(d => d.Vendor).WithMany(p => p.TblSaleNewStrategies)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK_tblSaleNewStrategy_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblSaleTeamTargetDetail>(entity =>
        {
            entity.ToTable("TblSaleTeamTargetDetail");

            entity.Property(e => e.NamePlateNo).HasMaxLength(50);
            entity.Property(e => e.TargetInRs).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.TblSaleTeamTargetDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_TblSaleTeamTargetDetail_tblProductTypeInfoMaster");

            entity.HasOne(d => d.SaleTeamTargetMst).WithMany(p => p.TblSaleTeamTargetDetails)
                .HasForeignKey(d => d.SaleTeamTargetMstId)
                .HasConstraintName("FK_TblSaleTeamTargetDetail_tblSalesTeamTarget");
        });

        modelBuilder.Entity<TblSalesFollowup>(entity =>
        {
            entity.ToTable("tblSalesFollowup");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FollowupDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblSalesFollowupCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_tblSalesFollowup_tblEmplyeeInfo");

            entity.HasOne(d => d.FollowupType).WithMany(p => p.TblSalesFollowups)
                .HasForeignKey(d => d.FollowupTypeId)
                .HasConstraintName("FK_tblSalesFollowup_tblFollowupTypeMaster");

            entity.HasOne(d => d.LeadAndOpp).WithMany(p => p.TblSalesFollowups)
                .HasForeignKey(d => d.LeadAndOppId)
                .HasConstraintName("FK_tblSalesFollowup_tblLeadandOpportunitesinfo");

            entity.HasOne(d => d.LeadCancelReason).WithMany(p => p.TblSalesFollowups)
                .HasForeignKey(d => d.LeadCancelReasonId)
                .HasConstraintName("FK_tblSalesFollowup_tblLeadCancelReasonMst");

            entity.HasOne(d => d.SaleFollowupType).WithMany(p => p.TblSalesFollowups)
                .HasForeignKey(d => d.SaleFollowupTypeId)
                .HasConstraintName("FK_tblSalesFollowup_tblSaleDepFollowUpTypeMaster");

            entity.HasOne(d => d.Stategy).WithMany(p => p.TblSalesFollowups)
                .HasForeignKey(d => d.StategyId)
                .HasConstraintName("FK_tblSalesFollowup_tblStategyMaster");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblSalesFollowupUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_tblSalesFollowup_tblEmplyeeInfo1");
        });

        modelBuilder.Entity<TblSalesTeamTarget>(entity =>
        {
            entity.ToTable("tblSalesTeamTarget");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.TargetEndDate).HasColumnType("datetime");
            entity.Property(e => e.TargetInInvoice).HasColumnName("target_in_invoice");
            entity.Property(e => e.TargetInRs)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("target_in_rs");
            entity.Property(e => e.TargetStartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblSalesTeamTargets)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblSalesTeamTarget_tblEmplyeeInfo");

            entity.HasOne(d => d.Product).WithMany(p => p.TblSalesTeamTargets)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblSalesTeamTarget_tblProductTypeInfoMaster");
        });

        modelBuilder.Entity<TblSddetailsForTaxInv>(entity =>
        {
            entity.ToTable("TblSDDetailsForTaxInv");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.TaxInvoiceWithGstid).HasColumnName("TaxInvoiceWithGSTId");
            entity.Property(e => e.TaxInvoiceWithoutGstid).HasColumnName("TaxInvoiceWithoutGSTId");

            entity.HasOne(d => d.SecurityDeposite).WithMany(p => p.TblSddetailsForTaxInvs)
                .HasForeignKey(d => d.SecurityDepositeId)
                .HasConstraintName("FK_TblSDDetailsForTaxInv_tblOtherIncome");

            entity.HasOne(d => d.TaxInvoiceWithGst).WithMany(p => p.TblSddetailsForTaxInvs)
                .HasForeignKey(d => d.TaxInvoiceWithGstid)
                .HasConstraintName("FK_TblSDDetailsForTaxInv_TaxableInvoiceMaster");

            entity.HasOne(d => d.TaxInvoiceWithoutGst).WithMany(p => p.TblSddetailsForTaxInvs)
                .HasForeignKey(d => d.TaxInvoiceWithoutGstid)
                .HasConstraintName("FK_TblSDDetailsForTaxInv_TaxInvoiceMSTWithoutGST");
        });

        modelBuilder.Entity<TblSecuriteDepositeReturn>(entity =>
        {
            entity.ToTable("tblSecuriteDepositeReturn");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ChequeDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.Upiid).HasColumnName("UPIId");
            entity.Property(e => e.Utrno).HasColumnName("UTRNo");

            entity.HasOne(d => d.Client).WithMany(p => p.TblSecuriteDepositeReturns)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_tblSecuriteDepositeReturn_tblCustomerInfo");

            entity.HasOne(d => d.Company).WithMany(p => p.TblSecuriteDepositeReturns)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblSecuriteDepositeReturn_tblCompanyInfo");

            entity.HasOne(d => d.Firm).WithMany(p => p.TblSecuriteDepositeReturns)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_tblSecuriteDepositeReturn_FrimInvoiceMaster1");

            entity.HasOne(d => d.SecuriteDepositeNoNavigation).WithMany(p => p.TblSecuriteDepositeReturns)
                .HasForeignKey(d => d.SecuriteDepositeNo)
                .HasConstraintName("FK_tblSecuriteDepositeReturn_tblOtherIncome");
        });

        modelBuilder.Entity<TblSecurityDdetail>(entity =>
        {
            entity.ToTable("tblSecurityDDetails");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SecurityDid).HasColumnName("SecurityDId");

            entity.HasOne(d => d.Pakage).WithMany(p => p.TblSecurityDdetails)
                .HasForeignKey(d => d.PakageId)
                .HasConstraintName("FK_tblSecurityDDetails_tblPackageInfoMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.TblSecurityDdetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblSecurityDDetails_tblProductTypeInfoMaster");

            entity.HasOne(d => d.SecurityD).WithMany(p => p.TblSecurityDdetails)
                .HasForeignKey(d => d.SecurityDid)
                .HasConstraintName("FK_tblSecurityDDetails_tblOtherIncome");
        });

        modelBuilder.Entity<TblSettingInfo>(entity =>
        {
            entity.ToTable("tblSettingInfo");

            entity.Property(e => e.AccountDeptSignatureImageDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Firm).WithMany(p => p.TblSettingInfos)
                .HasForeignKey(d => d.FirmId)
                .HasConstraintName("FK_tblSettingInfo_FrimInvoiceMaster");
        });

        modelBuilder.Entity<TblSopdetail>(entity =>
        {
            entity.ToTable("TblSOPDetail");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.SopfileUploadImage).HasColumnName("SOPFileUploadImage");
            entity.Property(e => e.SopfileUploadUri).HasColumnName("SOPFileUploadUri");
            entity.Property(e => e.Soptitle).HasColumnName("SOPTitle");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblSopdetails)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TblSOPDetail_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblStategyMaster>(entity =>
        {
            entity.ToTable("tblStategyMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblStategyMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblStategyMaster_tblCompanyInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblStategyMasters)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblStategyMaster_tblEmplyeeInfo");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblStategyMasters)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblStategyMaster_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblSubTitle>(entity =>
        {
            entity.ToTable("tblSubTitle");

            entity.Property(e => e.ContentDetails).HasMaxLength(50);
            entity.Property(e => e.LableName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.TitlelMaster).WithMany(p => p.TblSubTitles)
                .HasForeignKey(d => d.TitlelMasterId)
                .HasConstraintName("FK_tblSubTitle_tblTitleMaster");
        });

        modelBuilder.Entity<TblSupportCallDataHistory>(entity =>
        {
            entity.ToTable("tblSupportCallDataHistory");

            entity.Property(e => e.CloseCallDate).HasColumnType("date");
            entity.Property(e => e.PickCallDate).HasColumnType("date");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblSupportCallDataHistories)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblSupportCallDataHistory_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblSupportInfo>(entity =>
        {
            entity.ToTable("tblSupportInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.FollowupDate).HasColumnType("datetime");
            entity.Property(e => e.Priority).HasMaxLength(20);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.TblSupportInfos)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_tblSupportInfo_tblCustomerInfo");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblSupportInfos)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblSupportInfo_tblEmplyeeInfo2");

            entity.HasOne(d => d.LeadAndOpp).WithMany(p => p.TblSupportInfos)
                .HasForeignKey(d => d.LeadAndOppId)
                .HasConstraintName("FK_tblSupportInfo_tblLeadandOpportunitesinfo");

            entity.HasOne(d => d.SupportType).WithMany(p => p.TblSupportInfos)
                .HasForeignKey(d => d.SupportTypeId)
                .HasConstraintName("FK_tblSupportInfo_tblSupportTypeInfoMaster");
        });

        modelBuilder.Entity<TblSupportTimeHistory>(entity =>
        {
            entity.ToTable("tblSupportTimeHistory");

            entity.Property(e => e.CompleteDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifyOn).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Support).WithMany(p => p.TblSupportTimeHistories)
                .HasForeignKey(d => d.SupportId)
                .HasConstraintName("FK_tblSupportTimeHistory_tblSupportInfo");
        });

        modelBuilder.Entity<TblSupportTypeInfoMaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblSupportTypeInfo");

            entity.ToTable("tblSupportTypeInfoMaster");
        });

        modelBuilder.Entity<TblTaskManagementInfo>(entity =>
        {
            entity.ToTable("tblTaskManagementInfo");

            entity.Property(e => e.AdminStatus).HasMaxLength(50);
            entity.Property(e => e.CompleteDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DeadLine).HasColumnType("datetime");
            entity.Property(e => e.TaskDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.AssignToEmp).WithMany(p => p.TblTaskManagementInfos)
                .HasForeignKey(d => d.AssignToEmpId)
                .HasConstraintName("FK_tblTaskManagementInfo_tblEmplyeeInfo");

            entity.HasOne(d => d.BugRequirement).WithMany(p => p.TblTaskManagementInfos)
                .HasForeignKey(d => d.BugRequirementId)
                .HasConstraintName("FK_tblTaskManagementInfo_TblBugRequirementInfoMaster");

            entity.HasOne(d => d.Project).WithMany(p => p.TblTaskManagementInfos)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_tblTaskManagementInfo_tblProjectMaster");

            entity.HasOne(d => d.Status).WithMany(p => p.TblTaskManagementInfos)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_tblTaskManagementInfo_tblTaskStatusMaster");

            entity.HasOne(d => d.TaskPriority).WithMany(p => p.TblTaskManagementInfos)
                .HasForeignKey(d => d.TaskPriorityId)
                .HasConstraintName("FK_tblTaskManagementInfo_tblTaskPriorityMaster");

            entity.HasOne(d => d.TaskType).WithMany(p => p.TblTaskManagementInfos)
                .HasForeignKey(d => d.TaskTypeId)
                .HasConstraintName("FK_tblTaskManagementInfo_tblTaskTypeMaster");
        });

        modelBuilder.Entity<TblTaskPriorityMaster>(entity =>
        {
            entity.ToTable("tblTaskPriorityMaster");
        });

        modelBuilder.Entity<TblTaskStatusMaster>(entity =>
        {
            entity.ToTable("tblTaskStatusMaster");
        });

        modelBuilder.Entity<TblTaskTimeHistory>(entity =>
        {
            entity.ToTable("tblTaskTimeHistory");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifyOn).HasColumnType("datetime");
            entity.Property(e => e.PauseDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Task).WithMany(p => p.TblTaskTimeHistories)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_tblTaskTimeHistory_tblTaskManagementInfo");
        });

        modelBuilder.Entity<TblTaskTypeMaster>(entity =>
        {
            entity.ToTable("tblTaskTypeMaster");
        });

        modelBuilder.Entity<TblTdsmaster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TDSMaster");

            entity.ToTable("tblTDSMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.MobNo).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblTdsmasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblTDSMaster_tblCompanyInfo");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblTdsmasters)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblTDSMaster_tblVendorInfo");
        });

        modelBuilder.Entity<TblTeamBonding>(entity =>
        {
            entity.ToTable("tblTeamBonding");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.Mark).HasColumnName("mark");
            entity.Property(e => e.Month).HasColumnName("month");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblTeamBondings)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblTeamBonding_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblTestcaseDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TestcaseDetails");

            entity.ToTable("tblTestcaseDetails");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TestcaseUrl).HasColumnName("TestcaseURL");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.TblTestcaseDetails)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_tblTestcaseDetails_tblEmplyeeInfo");

            entity.HasOne(d => d.Project).WithMany(p => p.TblTestcaseDetails)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_tblTestcaseDetails_tblProjectMaster");

            entity.HasOne(d => d.TaskNoNavigation).WithMany(p => p.TblTestcaseDetails)
                .HasForeignKey(d => d.TaskNo)
                .HasConstraintName("FK_tblTestcaseDetails_tblTaskManagementInfo");
        });

        modelBuilder.Entity<TblThoughtPractice>(entity =>
        {
            entity.ToTable("TblThoughtPractice");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.TblThoughtPractices)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_TblThoughtPractice_tblDepartmentInfo");
        });

        modelBuilder.Entity<TblTitleMaster>(entity =>
        {
            entity.ToTable("tblTitleMaster");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.SourceType).HasMaxLength(50);
            entity.Property(e => e.TrainingDayCount).HasColumnName("trainingDayCount");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Company).WithMany(p => p.TblTitleMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblTitleMaster_tblCompanyInfo");

            entity.HasOne(d => d.Department).WithMany(p => p.TblTitleMasters)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_tblTitleMaster_tblDepartmentInfo");

            entity.HasOne(d => d.Product).WithMany(p => p.TblTitleMasters)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblTitleMaster_tblProductTypeInfoMaster");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblTitleMasters)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblTitleMaster_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblTitleSubProductDetail>(entity =>
        {
            entity.ToTable("tblTitleSubProductDetails");

            entity.HasOne(d => d.TitleMst).WithMany(p => p.TblTitleSubProductDetails)
                .HasForeignKey(d => d.TitleMstId)
                .HasConstraintName("FK_tblTitleSubProductDetails_tblTitleMaster");
        });

        modelBuilder.Entity<TblVendorInfo>(entity =>
        {
            entity.ToTable("tblVendorInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Gstno).HasColumnName("GSTNo");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblVendorInfoMaster>(entity =>
        {
            entity.ToTable("tblVendorInfoMaster");

            entity.Property(e => e.AccountNo).HasMaxLength(50);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Ifsccode).HasColumnName("IFSCCode");
            entity.Property(e => e.PinCode).HasMaxLength(50);
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            entity.Property(e => e.VendorGstnumber).HasColumnName("VendorGSTNumber");
            entity.Property(e => e.VendorMobileNo2).HasMaxLength(50);

            entity.HasOne(d => d.Company).WithMany(p => p.TblVendorInfoMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblVendorInfoMaster_tblCompanyInfo");
        });

        modelBuilder.Entity<TblVendorInvoice>(entity =>
        {
            entity.ToTable("tblVendorInvoice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_By");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_On");
            entity.Property(e => e.EmpId).HasColumnName("emp_Id");
            entity.Property(e => e.InvAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("inv_Amt");
            entity.Property(e => e.InvDate)
                .HasColumnType("datetime")
                .HasColumnName("inv_Date");
            entity.Property(e => e.InvNo)
                .HasMaxLength(50)
                .HasColumnName("inv_No");
            entity.Property(e => e.PaymentDueDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_Due_Date");
            entity.Property(e => e.Remark).HasColumnName("remark");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_By");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_On");
            entity.Property(e => e.VendorMstId).HasColumnName("vendor_Mst_Id");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblVendorInvoices)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblVendorInvoice_tblEmplyeeInfo");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblVendorInvoices)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblVendorInvoice_tblVendorInfo");
        });

        modelBuilder.Entity<TblVendorLegder>(entity =>
        {
            entity.ToTable("tblVendorLegder");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BalanceAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("balance_Amt");
            entity.Property(e => e.BillType)
                .HasMaxLength(50)
                .HasColumnName("bill_Type");
            entity.Property(e => e.CreatedBy).HasColumnName("created_By");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_On");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EmpId).HasColumnName("emp_Id");
            entity.Property(e => e.PaidAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("paid_Amt");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_By");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_On");
            entity.Property(e => e.VendorInvId).HasColumnName("vendor_Inv_Id");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblVendorLegders)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblVendorLegder_tblEmplyeeInfo");

            entity.HasOne(d => d.VendorInv).WithMany(p => p.TblVendorLegders)
                .HasForeignKey(d => d.VendorInvId)
                .HasConstraintName("FK_tblVendorLegder_tblVendorInvoice");
        });

        modelBuilder.Entity<TblWarningNotificationMst>(entity =>
        {
            entity.ToTable("TblWarningNotificationMst");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblWarningNotificationMsts)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_TblWarningNotificationMst_tblEmplyeeInfo");

            entity.HasOne(d => d.WarningTypeNavigation).WithMany(p => p.TblWarningNotificationMsts)
                .HasForeignKey(d => d.WarningTypeId)
                .HasConstraintName("FK_TblWarningNotificationMst_TblWarningType");
        });

        modelBuilder.Entity<TblWarningType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_WarningType");

            entity.ToTable("TblWarningType");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblWorkFromHomeTrackingLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TblWorkF__3214EC07529E2EC2");

            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.ReturnTime).HasColumnType("datetime");
            entity.Property(e => e.WentOutTime).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.TblWorkFromHomeTrackingLogs)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_TblWorkFromHomeTrackingLogs_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblYearEndingEnquiry>(entity =>
        {
            entity.ToTable("tblYearEndingEnquiry");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblYearEndingEnquiries)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblYearEndingEnquiry_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblYearEndingHold>(entity =>
        {
            entity.ToTable("tblYearEndingHold");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblYearEndingHolds)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblYearEndingHold_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblYearEndingInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_YearEndingInfo");

            entity.ToTable("tblYearEndingInfo");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.TblYearEndingInfos)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblYearEndingInfo_tblEmplyeeInfo");
        });

        modelBuilder.Entity<TblfreelancerMaster>(entity =>
        {
            entity.ToTable("tblfreelancer_master");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.FreelancerName).HasColumnName("freelancer_name");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .HasColumnName("mobile_no");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");

            entity.HasOne(d => d.Company).WithMany(p => p.TblfreelancerMasters)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblfreelancer_master_tblCompanyInfo");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblfreelancerMasters)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblfreelancer_master_tblVendorInfoMaster");
        });

        modelBuilder.Entity<TblfreelancerRatechartDetail>(entity =>
        {
            entity.ToTable("tblfreelancer_ratechart_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FreelancerRatechartId).HasColumnName("freelancer_ratechart_id");
            entity.Property(e => e.FromAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("from_amount");
            entity.Property(e => e.PackageId).HasColumnName("package_id");
            entity.Property(e => e.Percentage)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("percentage");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ToAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("to_amount");

            entity.HasOne(d => d.FreelancerRatechart).WithMany(p => p.TblfreelancerRatechartDetails)
                .HasForeignKey(d => d.FreelancerRatechartId)
                .HasConstraintName("FK_tblfreelancer_ratechart_detail_tblfreelancer_ratechart_mst");

            entity.HasOne(d => d.Package).WithMany(p => p.TblfreelancerRatechartDetails)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("FK_tblfreelancer_ratechart_detail_tblPackageInfoMaster");

            entity.HasOne(d => d.Product).WithMany(p => p.TblfreelancerRatechartDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_tblfreelancer_ratechart_detail_tblProductTypeInfoMaster");
        });

        modelBuilder.Entity<TblfreelancerRatechartMst>(entity =>
        {
            entity.ToTable("tblfreelancer_ratechart_mst");

            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("created_on");
            entity.Property(e => e.FreelancerId).HasColumnName("freelancer_id");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UpdatedOn)
                .HasColumnType("datetime")
                .HasColumnName("updated_on");

            entity.HasOne(d => d.Company).WithMany(p => p.TblfreelancerRatechartMsts)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK_tblfreelancer_ratechart_mst_tblCompanyInfo");

            entity.HasOne(d => d.Freelancer).WithMany(p => p.TblfreelancerRatechartMsts)
                .HasForeignKey(d => d.FreelancerId)
                .HasConstraintName("FK_tblfreelancer_ratechart_mst_tblfreelancer_master");

            entity.HasOne(d => d.VendorMst).WithMany(p => p.TblfreelancerRatechartMsts)
                .HasForeignKey(d => d.VendorMstId)
                .HasConstraintName("FK_tblfreelancer_ratechart_mst_tblVendorInfoMaster");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
