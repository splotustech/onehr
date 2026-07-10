using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblPunctuality
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public int? Mark { get; set; }

    public string? Note { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Month { get; set; }

    public string? Year { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }
}
