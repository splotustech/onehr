using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblThoughtPractice
{
    public int Id { get; set; }

    public int? DepartmentId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool? DeleteStatus { get; set; }

    public bool? Status { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TblDepartmentInfo? Department { get; set; }
}
