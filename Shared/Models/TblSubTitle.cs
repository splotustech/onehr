using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSubTitle
{
    public int Id { get; set; }

    public int? TitlelMasterId { get; set; }

    public string? Name { get; set; }

    public string? LableName { get; set; }

    public string? ContentDetails { get; set; }

    public virtual TblTitleMaster? TitlelMaster { get; set; }
}
