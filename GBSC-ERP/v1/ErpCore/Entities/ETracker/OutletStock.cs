using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErpCore.Entities.ETracker
{
    public class OutletStock : BaseClass
    {
        [Key]
        public long OutletStockId { get; set; }

        [Required]
        public string Item { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [StringLength(30)]
        public string Type { get; set; }

        public long? StoreVisitId { get; set; }

        public StoreVisit StoreVisit { get; set; }

    }
}
