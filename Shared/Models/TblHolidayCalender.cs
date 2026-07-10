using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class TblHolidayCalender
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public string? HolidayName { get; set; }

    public string? HolidayDesc { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public string? DepartmentId { get; set; }
}
