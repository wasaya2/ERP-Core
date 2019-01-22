using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.ViewModels
{
    public class OrderTakingInventoryViewModel
    {
        public string BrandName { get; set; }

        public IEnumerable<GroupedItems> Items { get; set; }
    }

 

      public class GroupedItems
        {
            public string ProductType { get; set; }

            public IEnumerable<Item> Items { get; set; }
        }

    public class Item
    {
        public long InventoryItemId { get; set; }

        public string Name { get; set; }

        public string ProductType { get; set; }

        public string ItemCode { get; set; }

        public double? UnitPrice { get; set; }

        public double? TradeOfferAmount { get; set; }

        public string Unit { get; set; }

        public string PackType { get; set; }

        public double? PackSize { get; set; }

        public string PackageType { get; set; }

        public string MeasurementUnit { get; set; }

        public string SalesUnit { get; set; }

        public string RateUnit { get; set; }

        public int MuInRu { get; set; }

        public int MuInPu { get; set; }

        public int MuInSu { get; set; }

        public string PackageUnit { get; set; }

        public double? RegularDiscount { get; set; }
    }
}
