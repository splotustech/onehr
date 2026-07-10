using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblPolicyDetail
{
    public int Id { get; set; }

    public int? PolicyId { get; set; }

    public string? Subtitle { get; set; }

    public string? BrowseUri { get; set; }

    public string? BrowseImage { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual TblPolicyInfo? Policy { get; set; }
}
