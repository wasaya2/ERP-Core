using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.ETracker
{
    public class NoOrderReason : BaseClass
    {
        public long NoOrderReasonId { get; set; }

        public string Reason { get; set; }

        public long? OrderTakingId { get; set; }

        public OrderTaking OrderTaking { get; set; }
    }
}
