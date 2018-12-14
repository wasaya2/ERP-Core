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

        [Required]
        public string Item { get; set; }

        [Required]
        public int Quantity { get; set; }

        public long? StoreVisitId { get; set; }

        public StoreVisit StoreVisit { get; set; }

        public long? StoreId { get; set; }

        public Store Store { get; set; }
    }
}
