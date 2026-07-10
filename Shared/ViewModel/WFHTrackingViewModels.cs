namespace SMART_HRMS_SYSTEM.Shared.ViewModel;

// ─── Request Models ────────────────────────────────────────────────────────────

public class WFHStartTrackingRequest
{
    public int EmployeeId { get; set; }
    public string? DeviceName { get; set; }
    public string? Browser { get; set; }
    public string? IpAddress { get; set; }
}

public class WFHLocationPingRequest
{
    public int EmployeeId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? DeviceName { get; set; }
    public string? Browser { get; set; }
    public string? IpAddress { get; set; }
}

public class WFHStopTrackingRequest
{
    public int EmployeeId { get; set; }
}

// ─── Response Models ───────────────────────────────────────────────────────────

public class WFHStartTrackingResponse
{
    public bool Success { get; set; }
    public int TrackingId { get; set; }
    public int AttendanceId { get; set; }
    public double AssignedLat { get; set; }
    public double AssignedLong { get; set; }
    public double AllowedRadius { get; set; }
    public string? Message { get; set; }
}

public class WFHLocationPingResponse
{
    public bool Success { get; set; }
    public double Distance { get; set; }
    public bool IsInsideRadius { get; set; }
    public string? CurrentStatus { get; set; }
    public string? EventTriggered { get; set; }
    public string? Message { get; set; }
}

// ─── Dashboard ─────────────────────────────────────────────────────────────────

public class WFHDashboardStats
{
    public int TotalWFHEmployees { get; set; }
    public int CurrentlyWorking { get; set; }
    public int CurrentlyOutside { get; set; }
    public int ReturnedEmployees { get; set; }
    public int TotalAutoOutEvents { get; set; }
    public int TotalAutoReturnEvents { get; set; }
    public double AverageOutsideDuration { get; set; }
    public List<WFHOutsideEmployeeSummary> EmployeesCurrentlyOutside { get; set; } = new();
}

public class WFHOutsideEmployeeSummary
{
    public int EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public string? Department { get; set; }
    public DateTime? OutsideSince { get; set; }
    public double? CurrentDistance { get; set; }
    public double? CurrentLat { get; set; }
    public double? CurrentLong { get; set; }
}

// ─── List / Grid ───────────────────────────────────────────────────────────────

public class WFHMonitoringListItem
{
    public int EmployeeId { get; set; }
    public string? EmployeeCode { get; set; }
    public string? EmployeeName { get; set; }
    public string? Department { get; set; }
    public string? Designation { get; set; }
    public DateTime? AttendanceDate { get; set; }
    public DateTime? PunchIn { get; set; }
    public DateTime? PunchOut { get; set; }
    public string? CurrentStatus { get; set; }
    public double? CurrentDistance { get; set; }
    public string? CurrentAddress { get; set; }
    public DateTime? OutsideSince { get; set; }
    public DateTime? ReturnedTime { get; set; }
    public int? OutsideDurationMinutes { get; set; }
    public int TotalAutoOutCount { get; set; }
    public double? CurrentLat { get; set; }
    public double? CurrentLong { get; set; }
    public string? DeviceName { get; set; }
    public string? Browser { get; set; }
    public DateTime? LastUpdatedTime { get; set; }
    public string? TrackingStatus { get; set; }
}

// ─── Detail View ───────────────────────────────────────────────────────────────

public class WFHEmployeeDetail
{
    public int EmployeeId { get; set; }
    public string? EmployeeCode { get; set; }
    public string? EmployeeName { get; set; }
    public string? Department { get; set; }
    public string? Designation { get; set; }
    public DateTime? AttendanceDate { get; set; }
    public DateTime? PunchIn { get; set; }
    public DateTime? PunchOut { get; set; }
    public double? AssignedLat { get; set; }
    public double? AssignedLong { get; set; }
    public double AllowedRadius { get; set; }
    public string? CurrentStatus { get; set; }
    public double? CurrentDistance { get; set; }
    public double? CurrentLat { get; set; }
    public double? CurrentLong { get; set; }
    public DateTime? OutsideSince { get; set; }
    public DateTime? ReturnedTime { get; set; }
    public int TotalAutoOutCount { get; set; }
    public int TotalOutsideDurationMinutes { get; set; }
    public string? DeviceName { get; set; }
    public string? Browser { get; set; }
    public string? IpAddress { get; set; }
    public List<WFHGPSPingItem> GpsPings { get; set; } = new();
    public List<WFHEventItem> Events { get; set; } = new();
    public List<WFHNotificationHistoryItem> Notifications { get; set; } = new();
    public List<WFHTimelineItem> Timeline { get; set; } = new();
}

public class WFHGPSPingItem
{
    public DateTime PingTime { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Distance { get; set; }
    public bool IsInsideRadius { get; set; }
}

public class WFHEventItem
{
    public int Id { get; set; }
    public string? EventType { get; set; }
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
}

public class WFHNotificationHistoryItem
{
    public string? NotificationType { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public string? SentTo { get; set; }
    public DateTime SentOn { get; set; }
    public bool IsDelivered { get; set; }
}

public class WFHTimelineItem
{
    public DateTime Time { get; set; }
    public string? EventType { get; set; }
    public string? Description { get; set; }
    public string? IconClass { get; set; }
    public string? BadgeClass { get; set; }
}

// ─── Export ────────────────────────────────────────────────────────────────────

public class WFHExportRow
{
    public string? EmployeeCode { get; set; }
    public string? EmployeeName { get; set; }
    public string? Department { get; set; }
    public string? AttendanceDate { get; set; }
    public string? PunchIn { get; set; }
    public string? PunchOut { get; set; }
    public string? CurrentStatus { get; set; }
    public string? AssignedLatitude { get; set; }
    public string? AssignedLongitude { get; set; }
    public string? CurrentLatitude { get; set; }
    public string? CurrentLongitude { get; set; }
    public string? Distance { get; set; }
    public string? AutoOutTime { get; set; }
    public string? AutoReturnTime { get; set; }
    public string? OutsideDuration { get; set; }
    public string? OutsideCount { get; set; }
    public string? Remarks { get; set; }
}

// ─── Filter ────────────────────────────────────────────────────────────────────

public class WFHListFilter
{
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public string? Department { get; set; }
    public string? Designation { get; set; }
    public int? EmployeeId { get; set; }
    public string? CurrentStatus { get; set; }
    public string? TrackingStatus { get; set; }
    public string? EmployeeCode { get; set; }
}
