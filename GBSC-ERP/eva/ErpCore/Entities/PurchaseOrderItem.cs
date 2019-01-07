using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PurchaseOrderItem : BaseClass
    {
        [Key]
        public long PurchaseOrderItemId { get; set; }
        //public string NumberPackType { get; set; }
        //public double? OrderQuantity { get; set; }
        //public double? Rate { get; set; }
        //public double? GrossAmount { get; set; }
        //public double? DiscountPercentage { get; set; }
        //public double? DiscountAmount { get; set; }
        //public double? SalesTaxPercentage { get; set; }
        //public double? SalesTaxAmount { get; set; }
        //public double? NetAmount { get; set; }
        //public double? GrandTotal { get; set; }
        
        public string PackType { get; set; }
        public string PackSize { get; set; }
        public string NumberPackType { get; set; }
        public string BatchNumber { get; set; }
        public int? Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public double? Rate { get; set; }
        public double? ExchangeRate { get; set; }
        public double? GrossAmount { get; set; }

        public double? DiscountPercentage { get; set; }
        public double? DiscountAmount { get; set; }
        public double? AfterDiscountAmount { get; set; }

        public double? GstPercentage { get; set; }
        public double? GstAmount { get; set; }
        public double? AfterGstAmount { get; set; }

        public double? FreightPercentage { get; set; }
        public double? FreightAmount { get; set; }
        public double? DeliveryPercentage { get; set; }
        public double? DeliveryAmount { get; set; }
        public double? OtherPercentage { get; set; }
        public double? OtherAmount { get; set; }
        public double? NetAmount { get; set; }

        public double? CostPrice { get; set; }
        public double? RetailPrice { get; set; }
        public double? GrandTotal { get; set; }

        public long? InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public long? InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public long? PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
    }
}
