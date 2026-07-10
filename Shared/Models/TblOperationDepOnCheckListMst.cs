using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblOperationDepOnCheckListMst
{
    public int Id { get; set; }

    public int? GramId { get; set; }

    public int? RevenueVillageId { get; set; }

    public string? GrampanchayatName { get; set; }

    public string? Taluka { get; set; }

    public string? District { get; set; }

    public string? ExcelCreatedBy { get; set; }

    public DateTime? ExcelCreatedDate { get; set; }

    public string? ExcelApprovedBy { get; set; }

    public DateTime? ExcelApprovedDate { get; set; }

    public string? ExcelUniqueKey { get; set; }

    public bool? IsActiveUniqueKey { get; set; }

    public string? NamunaType { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<TblOperationDepCheckListDetail> TblOperationDepCheckListDetails { get; set; } = new List<TblOperationDepCheckListDetail>();
}
