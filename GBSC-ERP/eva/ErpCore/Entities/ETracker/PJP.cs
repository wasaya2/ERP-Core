using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.ETracker
{
    public class PJP : BaseClass
    {
        [Key]
        public long PjpId { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public long? PjpShops { get; set; }

        public long? PjpVisited { get; set; }

        public long? OutOfPjpVisited { get; set; }

        public long? VisitedShop { get; set; }

        public long? Productive { get; set; }

        public long? NotProductive { get; set; }

        public long? NotVisited { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? SubsectionId { get; set; }
        public Subsection Subsection { get; set; } 
    }
}
