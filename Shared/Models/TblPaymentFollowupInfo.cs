using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblPaymentFollowupInfo
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime? FollowupDate { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public virtual TblEmplyeeInfo? CreatedByNavigation { get; set; }

    public virtual TblCustomerInfo Customer { get; set; } = null!;

    public virtual TblEmplyeeInfo? UpdatedByNavigation { get; set; }
}
