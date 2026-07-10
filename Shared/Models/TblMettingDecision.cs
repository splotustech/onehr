using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblMettingDecision
{
    public int Id { get; set; }

    public string? MettingType { get; set; }

    public DateTime? MettingDate { get; set; }

    public string? Priority { get; set; }

    public string? DecisionTitle { get; set; }

    public string? DecisionDescription { get; set; }

    public string? MettingAttendees { get; set; }

    public string? AttachmentFile { get; set; }

    public int? ResponsiblePerson { get; set; }

    public string? DepartmentName { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? EmpId { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblEmplyeeInfo? ResponsiblePersonNavigation { get; set; }
}
