using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblOperatorDetail
{
    public int Id { get; set; }

    public string? Zone { get; set; }

    public string? District { get; set; }

    public string? Block { get; set; }

    public string? Village { get; set; }

    public string? MobNo { get; set; }

    public string? Name { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
