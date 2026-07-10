using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblCustomerOnboardingMst
{
    public int Id { get; set; }

    public int? GramId { get; set; }

    public int? ClientId { get; set; }

    public int? ProjectId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public string? Status { get; set; }

    public DateTime? CompleteDate { get; set; }

    public int? CompletedEmpId { get; set; }

    public string? MilkatSankya { get; set; }

    public string? NamplateSankya { get; set; }

    public decimal? Orderamount { get; set; }

    public string? ExportDataTypes { get; set; }

    public string? Description { get; set; }

    public bool? DeleteStatus { get; set; }

    public string? DeleteDescription { get; set; }

    public DateTime? DeleteDate { get; set; }

    public int? DeleteEmpId { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public bool? HoldStatus { get; set; }

    public DateTime? HoldDate { get; set; }

    public string? HoldDescription { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblEmplyeeInfo? CompletedEmp { get; set; }

    public virtual TblEmplyeeInfo? DeleteEmp { get; set; }

    public virtual TblProductTypeInfoMaster? Project { get; set; }

    public virtual ICollection<TblCustomerOnboardingDetail> TblCustomerOnboardingDetails { get; set; } = new List<TblCustomerOnboardingDetail>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
