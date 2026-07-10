using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblFollowupTypeMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CompanyId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual ICollection<TblSalesFollowup> TblSalesFollowups { get; set; } = new List<TblSalesFollowup>();
}
