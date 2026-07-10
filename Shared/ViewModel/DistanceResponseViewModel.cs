using SMART_HRMS_SYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    public class DistanceResponseViewModel
    {
        public double Distance { get; set; }
        public bool IsWithinRange { get; set; }
    }
}
