using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblOtherExpenseSubtype
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public string? OtherExpenseSubTypename { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }
}
