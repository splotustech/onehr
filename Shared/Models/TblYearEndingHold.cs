using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblYearEndingHold
{
    public int Id { get; set; }

    public int? GramId { get; set; }

    public string? Description { get; set; }

    public string? Reason { get; set; }

    public int? EmpId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }
}
