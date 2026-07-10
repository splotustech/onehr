using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblGalleryForWebsite
{
    public int Id { get; set; }

    public int? ImgTypeId { get; set; }

    public string? ImgName { get; set; }

    public string? ImgUrl { get; set; }

    public bool? Status { get; set; }

    public string? ImgTitle { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? UpdatedBy { get; set; }
}
