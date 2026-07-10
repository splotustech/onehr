using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblEmployeeRechargeMaster
{
    public int Id { get; set; }

    public string? MobileNumber { get; set; }

    public int? EmpId { get; set; }

    public DateTime? LastRechargeDate { get; set; }

    public decimal? RechargeAmount { get; set; }

    public DateTime? Validity { get; set; }

    public string? NoofDays { get; set; }

    public string? RechargeType { get; set; }

    public string? PlanNameAndRemarks { get; set; }

    public string? Status { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? FirmId { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual FrimInvoiceMaster? Firm { get; set; }
}
