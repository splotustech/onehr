using Microsoft.EntityFrameworkCore;

namespace SMART_HRMS_SYSTEM.Shared.Models;

/// <summary>
/// Partial extension of the main DbContext to add WFH GPS Tracking DbSets.
/// Keeps generated scaffolded code untouched.
/// </summary>
public partial class LotusTechCrmliveContext
{
    public virtual DbSet<TblWFHTracking> TblWFHTrackings { get; set; }
    public virtual DbSet<TblWFHGPSPing> TblWFHGPSPings { get; set; }
    public virtual DbSet<TblWFHTrackingEvent> TblWFHTrackingEvents { get; set; }
    public virtual DbSet<TblWFHCurrentStatus> TblWFHCurrentStatuses { get; set; }
    public virtual DbSet<TblWFHNotificationHistory> TblWFHNotificationHistories { get; set; }
}
