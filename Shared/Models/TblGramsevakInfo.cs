using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblGramsevakInfo
{
    public int Id { get; set; }

    public string? GramsevakName { get; set; }

    public string? MobileNo { get; set; }

    public string? District { get; set; }

    public string? Taluka { get; set; }

    public string? Village { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? DeleteStatus { get; set; }
}
