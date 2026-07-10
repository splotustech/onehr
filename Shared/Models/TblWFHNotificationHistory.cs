using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMART_HRMS_SYSTEM.Shared.Models;

[Table("tblWFHNotificationHistory")]
public class TblWFHNotificationHistory
{
    [Key]
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public int? AttendanceId { get; set; }
    public int? TrackingEventId { get; set; }
    public string? NotificationType { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }

    /// <summary>HR | Admin | Employee</summary>
    public string? SentTo { get; set; }

    public DateTime SentOn { get; set; } = DateTime.Now;
    public bool IsDelivered { get; set; } = false;
}
