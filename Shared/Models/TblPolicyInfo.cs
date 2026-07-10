using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblPolicyInfo
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? DepartmentId { get; set; }

    public DateTime? Date { get; set; }

    public string? Description { get; set; }

    public string? BrowseImage { get; set; }

    public string? BrowseUri { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<TblPolicyDetail> TblPolicyDetails { get; set; } = new List<TblPolicyDetail>();
}
