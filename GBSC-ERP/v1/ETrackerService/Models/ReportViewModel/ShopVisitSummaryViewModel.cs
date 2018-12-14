using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Models.ReportViewModel
{
    public class ShopVisitSummaryViewModel
    {
        public string SalesPerson { get; set; }

        public string Distributor { get; set; }

        public string Territory { get; set; }

        public int TargetStores { get; set; }

        public int StoresVisited { get; set; }
    }
}
