using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrackerService.ViewModels
{
    public class LastTwoVisits
    {
        public long SalesIndentId { get; set; }

        public string VisitedBy { get; set; }

        public DateTime? VisitDateTime { get; set; }

        public string BilledTo { get; set; }

        public DateTime? BillDate { get; set; }

        public List<LastvisitOrderItem> Items { get; set; }

        public double? Total { get; set; }

    }

    public class LastvisitOrderItem
    {
        public string ItemName { get; set; }

        public double? Quantity { get; set; }

        public string PackType { get; set; }

        public double? UnitPrice { get; set; }

    }
}
