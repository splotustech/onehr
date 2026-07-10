using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblYearEndingInfo
{
    public int Id { get; set; }

    public int? GramId { get; set; }

    public string? YearEndingFirst { get; set; }

    public string? YearEndingSecond { get; set; }

    public string? Amount { get; set; }

    public string? PaymentStatus { get; set; }

    public string? PaymentMode { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? EmpId { get; set; }

    public int? AgentId { get; set; }

    public string? Description { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }
}
