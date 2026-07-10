using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblRoleInfo
{
    public int Id { get; set; }

    public string? Role { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CompanyId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual ICollection<TblLoginInfo> TblLoginInfos { get; set; } = new List<TblLoginInfo>();
}
