using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblMovementRegister
{
    public int Id { get; set; }

    public int EmpId { get; set; }

    public DateTime LogDate { get; set; }

    public TimeSpan? ExitTime { get; set; }

    public TimeSpan? EntryTime { get; set; }

    public string? Reason { get; set; }

    public int? DurationMinutes { get; set; }

    public DateTime? CreatedDate { get; set; }
}
