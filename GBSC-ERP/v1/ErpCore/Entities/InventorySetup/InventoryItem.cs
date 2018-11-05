using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ErpCore.Entities.InventorySetup
{
    public class InventoryItem : BaseClass
    {
        public InventoryItem()
        {
            //sales
            SalesIndentItems = new HashSet<SalesIndentItem>();
            SalesOrderItems = new HashSet<SalesOrderItem>();
            DeliveryOrderItems = new HashSet<DeliveryOrderItem>();
            SalesReturnItems = new HashSet<SalesReturnItem>();
            //purchase
            PurchaseIndentItems = new HashSet<PurchaseIndentItem>();
            PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
            PurchaseReturnItems = new HashSet<PurchaseReturnItem>();
            GrnItems = new HashSet<GrnItem>();
        }

        [Key]
        public long InventoryItemId { get; set; }
        public string Name { get; set; }
        public string ItemCode { get; set; }
        public string Description { get; set; }

        public double? UnitPrice { get; set; }
        public double? PackTypeInPackageType { get; set; } //How many pouches in one carton //How many tablets in one box 

        public string Dose { get; set; }
        public double? MinLevel { get; set; }
        public double? CostPrice { get; set; }
        public double? RetailPrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public double? TradeOfferAmount { get; set; }


        public long? BrandId { get; set; }
        public Brand Brand { get; set; }

        public long? UnitId { get; set; }
        public Units Unit { get; set; }
        
        public long? PackTypeId { get; set; }
        public PackType PackType { get; set; }

        public long? PackSizeId { get; set; }
        public PackSize PackSize { get; set; }

        public long? PackCategoryId { get; set; }
        public PackCategory PackCategory { get; set; }

        public long? ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }

        public long? InventoryItemCategoryId { get; set; }
        public InventoryItemCategory InventoryItemCategory { get; set; }

        public long? PackageTypeId { get; set; }
        public PackageType PackageType { get; set; }

        public long? InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        //Sales
        public IEnumerable<SalesIndentItem> SalesIndentItems { get; set; }
        public IEnumerable<SalesOrderItem> SalesOrderItems { get; set; }
        public IEnumerable<SalesReturnItem> SalesReturnItems { get; set; }
        public IEnumerable<DeliveryOrderItem> DeliveryOrderItems { get; set; }

        //Purchase
        public IEnumerable<PurchaseIndentItem> PurchaseIndentItems { get; set; }
        public IEnumerable<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public IEnumerable<PurchaseReturnItem> PurchaseReturnItems { get; set; }
        public IEnumerable<GrnItem> GrnItems { get; set; }
    }
}
