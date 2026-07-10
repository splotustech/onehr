using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblOperation
{
    public int Id { get; set; }

    public int? GramId { get; set; }

    public int? ClientId { get; set; }

    public int? OperationTitleId { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public int? EmpId { get; set; }

    public string? Status { get; set; }

    public string? UnapproveDescription { get; set; }

    public virtual TblCustomerInfo? Client { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblOperationTitle? OperationTitle { get; set; }
}
