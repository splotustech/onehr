using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblAssetReturnDetail
{
    public int Id { get; set; }

    public int? AssignMaserId { get; set; }

    public DateTime? ReturnDate { get; set; }

    public int? AssetId { get; set; }

    public string? ReturnAcknowledgeUrl { get; set; }

    public string? ReturnAcknowledgeName { get; set; }

    public virtual TblAssetEntryMaster? Asset { get; set; }

    public virtual TblAssetAssignMaster? AssignMaser { get; set; }
}
