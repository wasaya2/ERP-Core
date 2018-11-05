using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class SalesReturnItem : BaseClass
    {
        [Key]
        public long SalesReturnItemId { get; set; }
        public double? ReturnQuantity { get; set; }
        public double? ReturnAmount { get; set; }

        public long? SalesReturnId { get; set; }
        public SalesReturn SalesReturn { get; set; }

        public long? InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }
        
        public long? InventoryId { get; set; } //Add quantity of returned item in inventory if returned
        public Inventory Inventory { get; set; }
    }
}
