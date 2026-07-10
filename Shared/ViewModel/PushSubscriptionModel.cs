using SMART_HRMS_SYSTEM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMART_HRMS_SYSTEM.Shared.ViewModel
{
    // Model for saving token
    public class PushSubscriptionModel
    {
        public int EmpId { get; set; }
        public string Endpoint { get; set; }
        public string P256dh { get; set; }
        public string Auth { get; set; }
        public string Department { get; set; }
    }
}
