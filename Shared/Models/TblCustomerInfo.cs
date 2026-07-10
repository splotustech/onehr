using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblCustomerInfo
{
    public int Id { get; set; }

    public string? ClientName { get; set; }

    public string? FirmName { get; set; }

    public string? Address { get; set; }

    public string? State { get; set; }

    public string? District { get; set; }

    public string? Taluka { get; set; }

    public string? Mob1 { get; set; }

    public string? Mob2 { get; set; }

    public DateTime? InstallationDate { get; set; }

    public int? ProductId { get; set; }

    public int? PackageId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? GramId { get; set; }

    public int? FavouriteEmpId { get; set; }

    public int? EmpId { get; set; }

    public string? Gstno { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblEmplyeeInfo? FavouriteEmp { get; set; }

    public virtual TblPackageInfoMaster? Package { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }

    public virtual ICollection<QuatationInvoiceMstWithGst> QuatationInvoiceMstWithGsts { get; set; } = new List<QuatationInvoiceMstWithGst>();

    public virtual ICollection<QuotationMstWithoutGst> QuotationMstWithoutGsts { get; set; } = new List<QuotationMstWithoutGst>();

    public virtual ICollection<TaxInvoiceMstwithoutGst> TaxInvoiceMstwithoutGsts { get; set; } = new List<TaxInvoiceMstwithoutGst>();

    public virtual ICollection<TaxableInvoiceMaster> TaxableInvoiceMasters { get; set; } = new List<TaxableInvoiceMaster>();

    public virtual ICollection<TblBugRequirementInfoMaster> TblBugRequirementInfoMasters { get; set; } = new List<TblBugRequirementInfoMaster>();

    public virtual ICollection<TblExpensesMaintain> TblExpensesMaintains { get; set; } = new List<TblExpensesMaintain>();

    public virtual ICollection<TblFeedbackInfo> TblFeedbackInfos { get; set; } = new List<TblFeedbackInfo>();

    public virtual ICollection<TblInvoiceMaster> TblInvoiceMasters { get; set; } = new List<TblInvoiceMaster>();

    public virtual ICollection<TblOperation> TblOperations { get; set; } = new List<TblOperation>();

    public virtual ICollection<TblOtherIncome> TblOtherIncomes { get; set; } = new List<TblOtherIncome>();

    public virtual ICollection<TblPaymentFollowupInfo> TblPaymentFollowupInfos { get; set; } = new List<TblPaymentFollowupInfo>();

    public virtual ICollection<TblProformaInvoiceMaster> TblProformaInvoiceMasters { get; set; } = new List<TblProformaInvoiceMaster>();

    public virtual ICollection<TblProformaInvoiceMstWithoutGst> TblProformaInvoiceMstWithoutGsts { get; set; } = new List<TblProformaInvoiceMstWithoutGst>();

    public virtual ICollection<TblSecuriteDepositeReturn> TblSecuriteDepositeReturns { get; set; } = new List<TblSecuriteDepositeReturn>();

    public virtual ICollection<TblSupportInfo> TblSupportInfos { get; set; } = new List<TblSupportInfo>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
