using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblTitleMaster
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? SequenceNo { get; set; }

    public string? Title { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? TrainingDayCount { get; set; }

    public int? DepartmentId { get; set; }

    public string? SourceType { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblDepartmentInfo? Department { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }

    public virtual ICollection<TblCustomerOnboardingDetail> TblCustomerOnboardingDetails { get; set; } = new List<TblCustomerOnboardingDetail>();

    public virtual ICollection<TblSubTitle> TblSubTitles { get; set; } = new List<TblSubTitle>();

    public virtual ICollection<TblTitleSubProductDetail> TblTitleSubProductDetails { get; set; } = new List<TblTitleSubProductDetail>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
