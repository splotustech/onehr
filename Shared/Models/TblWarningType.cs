using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblWarningType
{
    public int Id { get; set; }

    public string? WarningType { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<TblWarningNotificationMst> TblWarningNotificationMsts { get; set; } = new List<TblWarningNotificationMst>();
}
