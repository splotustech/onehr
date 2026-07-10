using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblMomdetail
{
    public int Id { get; set; }

    public DateTime? MeetingDate { get; set; }

    public TimeSpan? MeetingStartTime { get; set; }

    public TimeSpan? MeetingEndTime { get; set; }

    public string? MeetingLocation { get; set; }

    public string? MeetingType { get; set; }

    public string? MeetingAvailableEmpId { get; set; }

    public string? MeetingAvailableDeptId { get; set; }

    public string? Subject { get; set; }

    public string? GeneratedPrompt { get; set; }

    public string? MomdraftDetails { get; set; }

    public string? Objective { get; set; }

    public string? ExpectedOutcome { get; set; }

    public string? ActiontblId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }
}
