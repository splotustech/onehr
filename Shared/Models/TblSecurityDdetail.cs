using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSecurityDdetail
{
    public int Id { get; set; }

    public int? SecurityDid { get; set; }

    public int? ProductId { get; set; }

    public int? PakageId { get; set; }

    public decimal? Amount { get; set; }

    public int? Quantity { get; set; }

    public decimal? Rate { get; set; }

    public virtual TblPackageInfoMaster? Pakage { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }

    public virtual TblOtherIncome? SecurityD { get; set; }
}
