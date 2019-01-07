using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class DeliveryOrder : BaseClass
    {
        public DeliveryOrder()
        {
            DeliveryOrderItems = new HashSet<DeliveryOrderItem>();
        }

        [Key]
        public long DeliveryOrderId { get; set; }
        public string DeliveryOrderCode { get; set; }

        public DateTime? DateNow { get; set; }
        public DateTime? SalesOrderReceiveDate { get; set; }

        public DateTime? IssueDate { get; set; }
        public bool? IsIssued { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public bool? IsProcessed { get; set; }

        public string NewDescription { get; set; }
        
        public long? SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }

        public long? DeliveryChallanId { get; set; }
        public DeliveryChallan DeliveryChallan { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<DeliveryOrderItem> DeliveryOrderItems { get; set; }
    }
}
