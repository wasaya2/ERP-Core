using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PurchaseReturnItem : BaseClass
    {
        [Key]
        public long PurchaseReturnItemId { get; set; }
        public double? ReturnQuantity { get; set; }
        public double? ReturnAmount { get; set; }

        public long? InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public long? PurchaseReturnId { get; set; }
        public PurchaseReturn PurchaseReturn { get; set; }

        public long? InventoryId { get; set; } //Subtract quantity of returned item in inventory if returned
        public Inventory Inventory { get; set; }
    }
}
