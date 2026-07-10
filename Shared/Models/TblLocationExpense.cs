using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblLocationExpense
{
    public int Id { get; set; }

    public int BusinessTourExpenseMstId { get; set; }

    public DateTime? Date { get; set; }

    public string? FromLocation { get; set; }

    public string? ToLocation { get; set; }

    public string? Distance { get; set; }

    public string? TravelMode { get; set; }

    public decimal? Amount { get; set; }

    public string? Remark { get; set; }

    public virtual TblBusinessTourExpenseMst BusinessTourExpenseMst { get; set; } = null!;
}
