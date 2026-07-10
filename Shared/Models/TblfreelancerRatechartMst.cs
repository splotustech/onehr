using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblfreelancerRatechartMst
{
    public int Id { get; set; }

    public int? FreelancerId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblfreelancerMaster? Freelancer { get; set; }

    public virtual ICollection<TblfreelancerRatechartDetail> TblfreelancerRatechartDetails { get; set; } = new List<TblfreelancerRatechartDetail>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
