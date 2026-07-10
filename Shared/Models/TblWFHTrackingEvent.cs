using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMART_HRMS_SYSTEM.Shared.Models;

[Table("tblWFHTrackingEvents")]
public class TblWFHTrackingEvent
{
    [Key]
    public int Id { get; set; }
    public int TrackingId { get; set; }
    public int AttendanceId { get; set; }
    public int EmployeeId { get; set; }

    /// <summary>"AutoOut" or "AutoReturn"</summary>
    public string EventType { get; set; } = null!;

    public DateTime EventTime { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Distance { get; set; }
    public string? Address { get; set; }
    public string? DeviceName { get; set; }
    public string? Browser { get; set; }
    public string? IpAddress { get; set; }
    public string? Reason { get; set; }
    public DateTime? ReturnTime { get; set; }
    public int? OutsideDurationMinutes { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
