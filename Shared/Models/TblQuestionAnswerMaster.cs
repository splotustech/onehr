using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblQuestionAnswerMaster
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public string? MensionEmpId { get; set; }

    public int? EmpId { get; set; }

    public DateTime? Date { get; set; }

    public string? QuestionTitle { get; set; }

    public string? ImageUrl { get; set; }

    public string? ImageName { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? Updated { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }

    public virtual ICollection<TblQuestionAnswerDetail> TblQuestionAnswerDetails { get; set; } = new List<TblQuestionAnswerDetail>();
}
