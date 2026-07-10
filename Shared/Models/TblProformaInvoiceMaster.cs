using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblProformaInvoiceMaster
{
    public int Id { get; set; }

    public string? InvoiceNo { get; set; }

    public int? CustomerId { get; set; }

    public int? GramId { get; set; }

    public DateTime? InvoiceDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public decimal? CommisisonAmount { get; set; }

    public decimal? NetAmount { get; set; }

    public int? AgentId { get; set; }

    public int? StategyId { get; set; }

    public int? EmpId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? FirmId { get; set; }

    public int? FreelancerId { get; set; }

    public bool? DeleteStatus { get; set; }

    public bool? CancleStatus { get; set; }

    public int? CompanyId { get; set; }

    public int? VendorMstId { get; set; }

    public virtual TblAgentInfoMaster? Agent { get; set; }

    public virtual TblCompanyInfo? Company { get; set; }

    public virtual TblCustomerInfo? Customer { get; set; }

    public virtual TblEmplyeeInfo? Emp { get; set; }

    public virtual FrimInvoiceMaster? Firm { get; set; }

    public virtual TblfreelancerMaster? Freelancer { get; set; }

    public virtual ICollection<QuatationInvoiceMstWithGst> QuatationInvoiceMstWithGsts { get; set; } = new List<QuatationInvoiceMstWithGst>();

    public virtual TblStategyMaster? Stategy { get; set; }

    public virtual ICollection<TblProformaInvoiceDetail> TblProformaInvoiceDetails { get; set; } = new List<TblProformaInvoiceDetail>();

    public virtual TblVendorInfoMaster? VendorMst { get; set; }
}
