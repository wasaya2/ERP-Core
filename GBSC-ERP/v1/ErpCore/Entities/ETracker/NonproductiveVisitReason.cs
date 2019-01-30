using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.ETracker
{
    public class NonproductiveVisitReason :  BaseClass
    {
        [Key]
        public long NonproductiveVisitReasonId { get; set; }
        public string Reason { get; set; }
        public string ShopStatusSummary { get; set; }
        public long? Priority { get; set; }
    }
}
