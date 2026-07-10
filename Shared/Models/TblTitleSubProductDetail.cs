using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblTitleSubProductDetail
{
    public int Id { get; set; }

    public int? TitleMstId { get; set; }

    public string? SubProductId { get; set; }

    public int? CompleteSequenceNo { get; set; }

    public virtual TblTitleMaster? TitleMst { get; set; }
}
