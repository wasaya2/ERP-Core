using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class DeliveryOrderItem : BaseClass
    {
        [Key]
        public long DeliveryOrderItemId { get; set; }
        public double? ShippedQuantity { get; set; } //Calculate all amounts against this quantity. Total quantity of each item that will be shipped


        public long? DeliveryOrderId { get; set; }
        public DeliveryOrder DeliveryOrder { get; set; }

        public long? InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public long? InventoryId { get; set; } //Subtract shipped quantity from inventory
        public Inventory Inventory { get; set; }
    }
}
