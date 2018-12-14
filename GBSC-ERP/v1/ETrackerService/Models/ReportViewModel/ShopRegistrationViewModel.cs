using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Models.ReportViewModel
{
    public class ShopRegistrationViewModel
    {
        public string SalesPerson { get; set; }

        public string Distributor { get; set; }

        public string Territory { get; set; }

        public int TotalStoresRegistered { get; set; }
    }
}
