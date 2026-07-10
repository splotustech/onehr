namespace SMART_HRMS_SYSTEM.Shared.Models
{
    public class PunchRequestViewModel
    {
        public int EmployeeId { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string? WorkMode { get; set; } 
        public string? SelfieData { get; set; }  // Base64 Image String
    }
}