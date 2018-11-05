using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PurchaseIndentItem : BaseClass
    {
        [Key]
        public long PurchaseIndentItemId { get; set; }
        public double? Quantity { get; set; }

        public long? PurchaseIndentId { get; set; }
        public PurchaseIndent PurchaseIndent { get; set; }

        public long? InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public long? InventoryId { get; set; } //Check item quantity in stock but don't add here
        public Inventory Inventory { get; set; }
    }
}
