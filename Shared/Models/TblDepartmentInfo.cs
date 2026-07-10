using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblDepartmentInfo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblEmplyeeInfo? CreatedByNavigation { get; set; }

    public virtual ICollection<TblCoreTeamAgendaInfo> TblCoreTeamAgendaInfos { get; set; } = new List<TblCoreTeamAgendaInfo>();

    public virtual ICollection<TblEmplyeeInfo> TblEmplyeeInfos { get; set; } = new List<TblEmplyeeInfo>();

    public virtual ICollection<TblThoughtPractice> TblThoughtPractices { get; set; } = new List<TblThoughtPractice>();

    public virtual ICollection<TblTitleMaster> TblTitleMasters { get; set; } = new List<TblTitleMaster>();

    public virtual TblEmplyeeInfo? UpdatedByNavigation { get; set; }

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
