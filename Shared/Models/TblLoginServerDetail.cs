using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblLoginServerDetail
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? BrowserId { get; set; }

    public string? ComputerName { get; set; }

    public string? Ipaddress { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }
}
