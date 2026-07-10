using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblOtherExpense
{
    public int Id { get; set; }

    public int? BusinessTourExpenseMstId { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? Time { get; set; }

    public string? Description { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentMode { get; set; }

    public string? Remark { get; set; }

    public virtual TblBusinessTourExpenseMst? BusinessTourExpenseMst { get; set; }
}
