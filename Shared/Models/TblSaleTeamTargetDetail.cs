using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSaleTeamTargetDetail
{
    public int Id { get; set; }

    public int? SaleTeamTargetMstId { get; set; }

    public int? ProductId { get; set; }

    public decimal? TargetInRs { get; set; }

    public int? TargetInvoice { get; set; }

    public string? NamePlateNo { get; set; }

    public int? GramId { get; set; }

    public int? CustomerId { get; set; }

    public virtual TblProductTypeInfoMaster? Product { get; set; }

    public virtual TblSalesTeamTarget? SaleTeamTargetMst { get; set; }
}
