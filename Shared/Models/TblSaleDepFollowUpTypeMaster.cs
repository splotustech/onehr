using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSaleDepFollowUpTypeMaster
{
    public int Id { get; set; }

    public string? ClientType { get; set; }

    public string? FollowUpTypeName { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? EmpId { get; set; }

    public virtual ICollection<TblSalesFollowup> TblSalesFollowups { get; set; } = new List<TblSalesFollowup>();
}
