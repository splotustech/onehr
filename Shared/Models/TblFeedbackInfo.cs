using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblFeedbackInfo
{
    public int Id { get; set; }

    public string? FeedbackImagevideoUrl { get; set; }

    public string? FeedbackImagevideo { get; set; }

    public int? GramId { get; set; }

    public int? CustomerId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? EmpId { get; set; }

    public string? FeedbackOn { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorId { get; set; }

    public string? Description { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblCustomerInfo? Customer { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblVendorInfoMaster? Vendor { get; set; }
}
