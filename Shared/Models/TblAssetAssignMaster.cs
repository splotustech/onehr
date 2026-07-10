using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblAssetAssignMaster
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public DateTime? AssignedDate { get; set; }

    public int? CreatedbyId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedbyId { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? DeleteStatus { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual ICollection<TblAssetAssignDetail> TblAssetAssignDetails { get; set; } = new List<TblAssetAssignDetail>();

    public virtual ICollection<TblAssetReturnDetail> TblAssetReturnDetails { get; set; } = new List<TblAssetReturnDetail>();
}
