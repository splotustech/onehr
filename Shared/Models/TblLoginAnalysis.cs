using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblLoginAnalysis
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public long? Count { get; set; }

    public DateTime? CreatedOn { get; set; }
}
