using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class Inventory : BaseClass
    {
        public Inventory()
        {
            //Sales
            SalesOrderItems = new HashSet<SalesOrderItem>();
            DeliveryOrderItems = new HashSet<DeliveryOrderItem>();
            SalesReturnItems = new HashSet<SalesReturnItem>();
            //Purchase
            PurchaseIndentItems = new HashSet<PurchaseIndentItem>();
            PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
            PurchaseReturnItems = new HashSet<PurchaseReturnItem>();
        }

        [Key]
        public long InventoryId { get; set; }
        public double? StockQuantity { get; set; }

        public long? InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        //Sales
        public IEnumerable<SalesOrderItem> SalesOrderItems { get; set; }
        public IEnumerable<DeliveryOrderItem> DeliveryOrderItems { get; set; }
        public IEnumerable<SalesReturnItem> SalesReturnItems { get; set; }
        //Purchase
        public IEnumerable<PurchaseIndentItem> PurchaseIndentItems { get; set; }
        public IEnumerable<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public IEnumerable<PurchaseReturnItem> PurchaseReturnItems { get; set; }
    }
}
