using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblfreelancerRatechartDetail
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? PackageId { get; set; }

    public int? FreelancerRatechartId { get; set; }

    public decimal? FromAmount { get; set; }

    public decimal? ToAmount { get; set; }

    public decimal? Percentage { get; set; }

    public virtual TblfreelancerRatechartMst? FreelancerRatechart { get; set; }

    public virtual TblPackageInfoMaster? Package { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }
}
