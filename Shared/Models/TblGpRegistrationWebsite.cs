using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblGpRegistrationWebsite
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public int? GramId { get; set; }

    public string? District { get; set; }

    public string? Taluka { get; set; }

    public string? GpNameMarathi { get; set; }

    public string? GpNameEnglish { get; set; }

    public string? TemNo { get; set; }

    public string? MobileNo { get; set; }

    public decimal? SelesAmount { get; set; }

    public string? ReferenceBy { get; set; }

    public string? ReferenceByName { get; set; }

    public string? ReferenceByMobileNo { get; set; }

    public string? DataWokingBy { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public string? DomainMaster { get; set; }
}
