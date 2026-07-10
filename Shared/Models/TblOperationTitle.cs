using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblOperationTitle
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public int? CreatedById { get; set; }

    public int? UpdateById { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual ICollection<TblOperation> TblOperations { get; set; } = new List<TblOperation>();
}
