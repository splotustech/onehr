using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    public partial class OfficeSettingViewModel
    {
        public int Id { get; set; }

        public string OfficeName { get; set; } = null!;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double AllowedRadiusInMeters { get; set; }
    }
}
