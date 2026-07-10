using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblCoreTeamAgendaInfo
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? DepartmentId { get; set; }

    public string? Subject { get; set; }

    public string? ProblemStatement { get; set; }

    public string? Details { get; set; }

    public int? CoreTeamMemId { get; set; }

    public bool? ActionStatus { get; set; }

    public DateTime? TakeActionDate { get; set; }

    public string? Priority { get; set; }

    public string? ResponsibleEmpId { get; set; }

    public string? ExpectedSolution { get; set; }

    public DateTime? TargetSolutionDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual TblEmplyeeInfo? CoreTeamMem { get; set; }

    public virtual TblDepartmentInfo? Department { get; set; }

    public virtual ICollection<TblAgendaActionDetail> TblAgendaActionDetails { get; set; } = new List<TblAgendaActionDetail>();
}
