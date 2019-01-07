using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErpCore.Entities.ETracker
{
    public class Merchandising : BaseClass
    {
        [Key]
        public long MerchandisingId { get; set; }

        public bool? BeforeMerchandising { get; set; }

        public string ImageUrl { get; set; }

        public long? StoreVisitId { get; set; }

        public StoreVisit StoreVisit { get; set; }
    }
}