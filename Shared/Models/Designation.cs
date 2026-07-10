using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class Designation
{
    public int Id { get; set; }

    public string? Designation1 { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdatedById { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual ICollection<TblKrakpi> TblKrakpis { get; set; } = new List<TblKrakpi>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
