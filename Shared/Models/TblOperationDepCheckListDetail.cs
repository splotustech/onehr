using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblOperationDepCheckListDetail
{
    public int Id { get; set; }

    public int? OperationDepCheckListMstId { get; set; }

    public int? TitleId { get; set; }

    public string? Title { get; set; }

    public bool? Status { get; set; }

    public string? Description { get; set; }

    public virtual TblOperationDepOnCheckListMst? OperationDepCheckListMst { get; set; }
}
