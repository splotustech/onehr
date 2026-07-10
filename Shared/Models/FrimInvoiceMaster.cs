using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class FrimInvoiceMaster
{
    public int Id { get; set; }

    public string? FirmName { get; set; }

    public string? Address { get; set; }

    public string? MobileNo1 { get; set; }

    public string? MobileNo2 { get; set; }

    public string? Gstno { get; set; }

    public string? Website { get; set; }

    public string? LogoUrl { get; set; }

    public string? LogoImageName { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdateById { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public string? Prefix { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual ICollection<QuatationInvoiceMstWithGst> QuatationInvoiceMstWithGsts { get; set; } = new List<QuatationInvoiceMstWithGst>();

    public virtual ICollection<QuotationMstWithoutGst> QuotationMstWithoutGsts { get; set; } = new List<QuotationMstWithoutGst>();

    public virtual ICollection<TaxInvoiceMstwithoutGst> TaxInvoiceMstwithoutGsts { get; set; } = new List<TaxInvoiceMstwithoutGst>();

    public virtual ICollection<TaxableInvoiceMaster> TaxableInvoiceMasters { get; set; } = new List<TaxableInvoiceMaster>();

    public virtual ICollection<TblBalanceMaintain> TblBalanceMaintains { get; set; } = new List<TblBalanceMaintain>();

    public virtual ICollection<TblBankInfo> TblBankInfos { get; set; } = new List<TblBankInfo>();

    public virtual ICollection<TblEmployeeRechargeMaster> TblEmployeeRechargeMasters { get; set; } = new List<TblEmployeeRechargeMaster>();

    public virtual ICollection<TblExpensesMaintain> TblExpensesMaintains { get; set; } = new List<TblExpensesMaintain>();

    public virtual ICollection<TblInvoiceMaster> TblInvoiceMasters { get; set; } = new List<TblInvoiceMaster>();

    public virtual ICollection<TblOtherIncome> TblOtherIncomes { get; set; } = new List<TblOtherIncome>();

    public virtual ICollection<TblProformaInvoiceMaster> TblProformaInvoiceMasters { get; set; } = new List<TblProformaInvoiceMaster>();

    public virtual ICollection<TblProformaInvoiceMstWithoutGst> TblProformaInvoiceMstWithoutGsts { get; set; } = new List<TblProformaInvoiceMstWithoutGst>();

    public virtual ICollection<TblSecuriteDepositeReturn> TblSecuriteDepositeReturns { get; set; } = new List<TblSecuriteDepositeReturn>();

    public virtual ICollection<TblSettingInfo> TblSettingInfos { get; set; } = new List<TblSettingInfo>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
