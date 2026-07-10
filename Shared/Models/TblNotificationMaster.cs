using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblNotificationMaster
{
    public int Id { get; set; }

    public int? ProjectId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public DateTime? NotificationStartDate { get; set; }

    public DateTime? NotificationStopDate { get; set; }

    public string? NotificationType { get; set; }

    public string? Status { get; set; }

    public string? TargetAudienceType { get; set; }

    public string? NotificationBrowseUri { get; set; }

    public string? NotificationBrowseImage { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? EmpId { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblProjectMaster? Project { get; set; }
}
