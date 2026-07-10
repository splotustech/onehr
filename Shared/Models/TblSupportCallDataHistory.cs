using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSupportCallDataHistory
{
    public int Id { get; set; }

    public TimeSpan? CallPickTime { get; set; }

    public TimeSpan? CallCloseTime { get; set; }

    public DateTime? PickCallDate { get; set; }

    public int? SupportId { get; set; }

    public int? EmpId { get; set; }

    public DateTime? CloseCallDate { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }
}
