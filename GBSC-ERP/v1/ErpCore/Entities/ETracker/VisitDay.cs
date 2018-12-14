using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErpCore.Entities.ETracker
{
    public class VisitDay : BaseClass
    {
        [Key]
        public long VisitDayId { get; set; }

        public int Day { get; set; }

        public long? StoreId { get; set; }

        public Store Store { get; set; }
    }
}
