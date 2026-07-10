using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblGramSevakExcelReportTracking
{
    public int Id { get; set; }

    public string? District { get; set; }

    public string? Taluka { get; set; }

    public DateTime? ExportedOn { get; set; }
}
