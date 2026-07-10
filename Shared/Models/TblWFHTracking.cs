using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMART_HRMS_SYSTEM.Shared.Models;

[Table("tblWFHTracking")]
public class TblWFHTracking
{
    [Key]
    public int Id { get; set; }
    public int AttendanceId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime TrackingDate { get; set; }
    public double AssignedLat { get; set; }
    public double AssignedLong { get; set; }
    public double AllowedRadius { get; set; } = 100;
    public DateTime TrackingStartTime { get; set; }
    public DateTime? TrackingEndTime { get; set; }
    public string CurrentStatus { get; set; } = "Inside";
    public double? CurrentLat { get; set; }
    public double? CurrentLong { get; set; }
    public double? CurrentDistance { get; set; }
    public string? CurrentAddress { get; set; }
    public DateTime? LastPingTime { get; set; }
    public int TotalAutoOutCount { get; set; } = 0;
    public int TotalOutsideDurationMinutes { get; set; } = 0;
    public string? DeviceName { get; set; }
    public string? Browser { get; set; }
    public string? IpAddress { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? UpdatedOn { get; set; }
}
