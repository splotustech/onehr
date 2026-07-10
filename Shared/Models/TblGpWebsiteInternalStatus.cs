using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblGpWebsiteInternalStatus
{
    public int Id { get; set; }

    public int? GpRegistrationWebsiteId { get; set; }

    public int? TaskStatusId { get; set; }

    public string? Note { get; set; }

    public int? EmpId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual TblTaskStatusMaster? TaskStatus { get; set; }
}
