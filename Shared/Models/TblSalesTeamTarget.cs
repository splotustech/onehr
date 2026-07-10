using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSalesTeamTarget
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public decimal? TargetInRs { get; set; }

    public int? TargetInInvoice { get; set; }

    public string? Month { get; set; }

    public string? Year { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public int? ProductId { get; set; }

    public string? TargetType { get; set; }

    public DateTime? TargetStartDate { get; set; }

    public DateTime? TargetEndDate { get; set; }

    public string? Remarks { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }

    public virtual ICollection<TblSaleTeamTargetDetail> TblSaleTeamTargetDetails { get; set; } = new List<TblSaleTeamTargetDetail>();
}
