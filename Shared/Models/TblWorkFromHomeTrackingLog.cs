using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblWorkFromHomeTrackingLog
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? WentOutTime { get; set; }

    public DateTime? ReturnTime { get; set; }

    public double? MaxDistance { get; set; }

    public virtual TblEmplyeeInfo? Employee { get; set; }
}
