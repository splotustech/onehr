using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class AttendanceLog
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime Date { get; set; }

    public DateTime PunchInTime { get; set; }

    public DateTime? PunchOutTime { get; set; }

    public double PunchInLat { get; set; }

    public double PunchInLong { get; set; }

    public double? PunchOutLat { get; set; }

    public double? PunchOutLong { get; set; }

    public string WorkMode { get; set; } = null!;

    public string? SelfieData { get; set; }

    public string? Reason { get; set; }

    public virtual TblEmplyeeInfo Employee { get; set; } = null!;
}
