using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblDailyTaskManagementMst
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual ICollection<TblDailyTaskManagementDetail> TblDailyTaskManagementDetails { get; set; } = new List<TblDailyTaskManagementDetail>();
}
