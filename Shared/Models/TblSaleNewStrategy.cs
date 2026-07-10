using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSaleNewStrategy
{
    public int Id { get; set; }

    public string? StrategyName { get; set; }

    public string? Description { get; set; }

    public bool? IsApplyToCustomer { get; set; }

    public string? NewStatergyImageUrl { get; set; }

    public string? NewStatergyImage { get; set; }

    public int? EmpId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblVendorInfoMaster? Vendor { get; set; }
}
