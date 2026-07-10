using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMART_HRMS_SYSTEM.Shared.Models;

[Table("tblWFHCurrentStatus")]
public class TblWFHCurrentStatus
{
    [Key]
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int? AttendanceId { get; set; }
    public int? TrackingId { get; set; }
    public DateTime? TrackingDate { get; set; }

    /// <summary>Inside | Outside | Returned | NotTracking</summary>
    public string? CurrentStatus { get; set; } = "NotTracking";

    public double? CurrentLat { get; set; }
    public double? CurrentLong { get; set; }
    public double? CurrentDistance { get; set; }
    public string? CurrentAddress { get; set; }
    public DateTime? OutsideSince { get; set; }
    public DateTime? ReturnedTime { get; set; }
    public int TotalOutsideDurationMinutes { get; set; } = 0;
    public int TotalAutoOutCount { get; set; } = 0;
    public DateTime? LastPingTime { get; set; }
    public string? DeviceName { get; set; }
    public string? Browser { get; set; }
    public string? IpAddress { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
