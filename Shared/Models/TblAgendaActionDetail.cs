using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblAgendaActionDetail
{
    public int Id { get; set; }

    public int? AgendaCreatedMemberId { get; set; }

    public int? AgendaId { get; set; }

    public DateTime? ActionTakenDate { get; set; }

    public string? ActionTakenType { get; set; }

    public string? TakeActionDepartments { get; set; }

    public string? ResponsibleEmployees { get; set; }

    public string? Priority { get; set; }

    public DateTime? DeadlineDate { get; set; }

    public string? ExpectedSolution { get; set; }

    public string? AssignedEmployees { get; set; }

    public string? TaskTitle { get; set; }

    public string? Status { get; set; }

    public DateTime? CompletedDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual TblCoreTeamAgendaInfo? Agenda { get; set; }

    public virtual TblEmplyeeInfo? AgendaCreatedMember { get; set; }
}
