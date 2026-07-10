using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblAssetTypeMaster
{
    public int Id { get; set; }

    public string? AssetId { get; set; }

    public string? AssetName { get; set; }

    public int? CreatedbyId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedbyId { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? DeleteStatus { get; set; }

    public virtual ICollection<TblAssetEntryMaster> TblAssetEntryMasters { get; set; } = new List<TblAssetEntryMaster>();
}
