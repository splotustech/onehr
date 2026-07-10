using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class AutoWebsiteLinkInfo
{
    public int Id { get; set; }

    public string? PageLink { get; set; }

    public string? LogoUrl { get; set; }

    public string? ContactNo { get; set; }
}
