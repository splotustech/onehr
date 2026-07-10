using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblExportDataDetail
{
    public int Id { get; set; }

    public int? GramId { get; set; }

    public int? EmpId { get; set; }

    public string? ClientName { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? IssueDate { get; set; }

    public bool? KarDarYesNo { get; set; }

    public string? Data { get; set; }

    public string? ShereBy { get; set; }

    public string? DataType { get; set; }

    public string? Status { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? Reason { get; set; }
}
