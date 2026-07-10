using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMART_HRMS_SYSTEM.Shared.Models;

[Table("tblWFHGPSPing")]
public class TblWFHGPSPing
{
    [Key]
    public int Id { get; set; }
    public int TrackingId { get; set; }
    public int EmployeeId { get; set; }
    public int AttendanceId { get; set; }
    public DateTime PingTime { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Distance { get; set; }
    public bool IsInsideRadius { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
}
