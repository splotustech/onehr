using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSopdetail
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public string? DepartmentId { get; set; }

    public string? Soptitle { get; set; }

    public string? ExpectedOutput { get; set; }

    public string? Description { get; set; }

    public string? SopfileUploadUri { get; set; }

    public string? SopfileUploadImage { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }
}
