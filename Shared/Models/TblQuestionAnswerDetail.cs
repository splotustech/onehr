using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblQuestionAnswerDetail
{
    public int Id { get; set; }

    public int? QueAnsMstId { get; set; }

    public int? EmpId { get; set; }

    public DateTime? Date { get; set; }

    public string? Answer { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? AnswerAccepted { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblQuestionAnswerMaster? QueAnsMst { get; set; }
}
