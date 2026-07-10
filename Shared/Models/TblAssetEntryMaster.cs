using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblAssetEntryMaster
{
    public int Id { get; set; }

    public int? AssetTypeId { get; set; }

    public string? AssetSource { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public string? ImeiSerialNo { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public DateTime? WarrantyExpiry { get; set; }

    public string? MobileNumber { get; set; }

    public string? SimProvider { get; set; }

    public string? BillPhotoUrl { get; set; }

    public string? PhotoName { get; set; }

    public string? AssetPhotoUrl { get; set; }

    public string? AssetPhotoName { get; set; }

    public bool? Status { get; set; }

    public int? CreatedbyId { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedbyId { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool? DeleteStatus { get; set; }

    public int? Quantity { get; set; }

    public decimal? Rate { get; set; }

    public string? Ram { get; set; }

    public string? Storage { get; set; }

    public string? Processor { get; set; }

    public string? AssetPhoto2Url { get; set; }

    public string? AssetPhoto2Name { get; set; }

    public string? AssetPhoto3Url { get; set; }

    public string? AssetPhoto3Name { get; set; }

    public string? AssetPhoto4Url { get; set; }

    public string? AssetPhoto4Name { get; set; }

    public string? AssetEntryId { get; set; }

    public virtual TblAssetTypeMaster? AssetType { get; set; }

    public virtual ICollection<TblAssetAssignDetail> TblAssetAssignDetails { get; set; } = new List<TblAssetAssignDetail>();

    public virtual ICollection<TblAssetReturnDetail> TblAssetReturnDetails { get; set; } = new List<TblAssetReturnDetail>();
}
