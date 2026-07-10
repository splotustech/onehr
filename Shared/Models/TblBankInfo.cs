using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblBankInfo
{
    public int Id { get; set; }

    public string? BankName { get; set; }

    public string? BankAddress { get; set; }

    public string? AccountNo { get; set; }

    public string? Ifsccode { get; set; }

    public string? AccountHolderName { get; set; }

    public string? BankQrurl { get; set; }

    public string? BankQr { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public int? EmpId { get; set; }

    public string? BankBranch { get; set; }

    public int? FirmId { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual FrimInvoiceMaster? Firm { get; set; }

    public virtual ICollection<TblExpensesMaintain> TblExpensesMaintains { get; set; } = new List<TblExpensesMaintain>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
