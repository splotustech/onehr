using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSettingInfo
{
    public int Id { get; set; }

    public bool? AccountDeptSignature { get; set; }

    public string? AccountDeptSignatureImage { get; set; }

    public DateTime? AccountDeptSignatureImageDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? FirmId { get; set; }

    public virtual FrimInvoiceMaster? Firm { get; set; }
}
