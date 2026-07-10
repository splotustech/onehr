using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblWarningNotificationMst
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public string? WarningType { get; set; }

    public string? Description { get; set; }

    public string? WarningMode { get; set; }

    public string? BrowseImage { get; set; }

    public string? BrowseUri { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public DateTime? Date { get; set; }

    public int? WarningTypeId { get; set; }

    public string? CcIdList { get; set; }

    public string? Subject { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblWarningType? WarningTypeNavigation { get; set; }
}
