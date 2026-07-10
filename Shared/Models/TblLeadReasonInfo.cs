using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblLeadReasonInfo
{
    public int Id { get; set; }

    public int? LeadId { get; set; }

    public int? ReasonId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual TblLeadandOpportunitesinfo? Lead { get; set; }

    public virtual TblReasonInfoMaster? Reason { get; set; }
}
