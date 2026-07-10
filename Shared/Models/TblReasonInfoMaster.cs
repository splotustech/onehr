using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblReasonInfoMaster
{
    public int Id { get; set; }

    public string? Reason { get; set; }

    public int? CompanyId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual ICollection<TblLeadReasonInfo> TblLeadReasonInfos { get; set; } = new List<TblLeadReasonInfo>();
}
