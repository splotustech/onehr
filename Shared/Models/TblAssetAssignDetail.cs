using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblAssetAssignDetail
{
    public int Id { get; set; }

    public int? MasterId { get; set; }

    public int? AssetId { get; set; }

    public string? AssetCoditionOnHandover { get; set; }

    public string? AcknowledgementUrl { get; set; }

    public string? AcknowledgementName { get; set; }

    public string? Status { get; set; }

    public DateTime? AssignedDate { get; set; }

    public virtual TblAssetEntryMaster? Asset { get; set; }

    public virtual TblAssetAssignMaster? Master { get; set; }
}
