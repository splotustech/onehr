using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSupportTypeInfoMaster
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public bool? Status { get; set; }

    public virtual ICollection<TblSupportInfo> TblSupportInfos { get; set; } = new List<TblSupportInfo>();
}
