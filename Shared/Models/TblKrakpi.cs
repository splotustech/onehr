using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblKrakpi
{
    public int Id { get; set; }

    public int? Designation { get; set; }

    public string? BrowseUri { get; set; }

    public string? BrowseImage { get; set; }

    public DateTime? UploadedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual Designation? DesignationNavigation { get; set; }
}
