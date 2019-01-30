using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.ETracker
{
    public class InventoryTaking : BaseClass
    {
        [Key]
        public long InventoryTakingId { get; set; }

        public int? Quantity { get; set; }

        public long? StoreVisitId { get; set; }

        public StoreVisit StoreVisit { get; set; }

        public long? StoreId { get; set; }

        public Store Store { get; set; }

        public string BrandName { get; set; }

        public long? GeneralSKUId { get; set; }

        public GeneralSKU SKUItem { get; set; }
    }
}
