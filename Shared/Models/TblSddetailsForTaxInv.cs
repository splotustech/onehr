using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblSddetailsForTaxInv
{
    public int Id { get; set; }

    public int? SecurityDepositeId { get; set; }

    public int? TaxInvoiceWithGstid { get; set; }

    public int? GramId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? Date { get; set; }

    public int? TaxInvoiceWithoutGstid { get; set; }

    public virtual TblOtherIncome? SecurityDeposite { get; set; }

    public virtual TaxableInvoiceMaster? TaxInvoiceWithGst { get; set; }

    public virtual TaxInvoiceMstwithoutGst? TaxInvoiceWithoutGst { get; set; }
}
