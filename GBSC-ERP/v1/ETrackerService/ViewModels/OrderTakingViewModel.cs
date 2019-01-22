using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrackerService.ViewModels
{
    public class OrderTakingViewModel
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

        public string Description { get; set; }

        public double? Quantity { get; set; }

        public double? UnitPrice { get; set; }

        public double? PackTypeInPackageType { get; set; } //How many pouches in one carton //How many tablets in one box 

        public double? CostPrice { get; set; }

        public double? RetailPrice { get; set; }

        public DateTime? PurchaseDate { get; set; }

        public double? TradeOfferAmount { get; set; }

        public string Unit { get; set; }

        public string PackType { get; set; }

        public double? PackSize { get; set; }

        public string PackageType { get; set; }
    }
}
