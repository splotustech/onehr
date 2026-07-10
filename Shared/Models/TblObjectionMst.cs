using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblObjectionMst
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? EmpId { get; set; }

    public string? ObjectionTitle { get; set; }

    public string? ObjectionDescription { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }
}
