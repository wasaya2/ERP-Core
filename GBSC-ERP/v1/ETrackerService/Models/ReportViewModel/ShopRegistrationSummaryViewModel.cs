using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Models.ReportViewModel
{
    public class ShopRegistrationSummaryViewModel
    {
        public int UserId { get; set; }

        public string SalesPerson { get; set; }

        public string Distributor { get; set; }

        public string Territory { get; set; }

        public string Day { get; set; }

        public string ShopName { get; set; }

        public DateTime? CheckinTime { get; set; }

        public DateTime? CheckoutTime { get; set; }

        public string TotalTimeSpent { get; set; }
    }
}
