using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Models.ReportViewModel
{
    public class MileageReportViewModel
    {
        public long UserId { get; set; }

        public string SalesPerson { get; set; }

        public string Distributor { get; set; }

        public string Territory { get; set; }

        public string Area { get; set; }

        public string Region { get; set; }

        public double DistanceTravelled { get; set; }
    }
}
