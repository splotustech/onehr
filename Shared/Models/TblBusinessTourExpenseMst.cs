using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblBusinessTourExpenseMst
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public int? ExpenseId { get; set; }

    public string? Designation { get; set; }

    public DateTime? DateOfTravel { get; set; }

    public string? PurposeOfTravel { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? FormNo { get; set; }

    public virtual ICollection<TblLocationExpense> TblLocationExpenses { get; set; } = new List<TblLocationExpense>();

    public virtual ICollection<TblOtherExpense> TblOtherExpenses { get; set; } = new List<TblOtherExpense>();
}
