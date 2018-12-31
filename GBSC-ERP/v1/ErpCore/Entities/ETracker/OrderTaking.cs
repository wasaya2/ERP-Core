using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErpCore.Entities.InventorySetup;

namespace ErpCore.Entities.ETracker
{
    public class OrderTaking : BaseClass
    {
        [Key]
        public long OrderTakingId { get; set; }

        public int? Quantity { get; set; }

        public string NoOrderReason { get; set; }

        public long? StoreVisitId { get; set; }

        public StoreVisit StoreVisit { get; set; }

        public long? StoreId { get; set; }

        public Store Store { get; set; }

        public long? InventoryItemId { get; set; }

        public InventoryItem inventoryItem { get; set; }
    }
}
