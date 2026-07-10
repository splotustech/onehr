using System;
using System.Collections.Generic;

namespace SMART_HRMS_SYSTEM.Shared.Models;

public partial class OfficeSetting
{
    public int Id { get; set; }

    public string OfficeName { get; set; } = null!;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public double AllowedRadiusInMeters { get; set; }

    public double? WfhallowedRadiusInMeters { get; set; }
}
