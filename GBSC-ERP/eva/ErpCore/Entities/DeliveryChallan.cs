using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class DeliveryChallan : BaseClass
    {
        [Key]
        public long DeliveryChallanId { get; set; }
        public string ChallanNumber { get; set; }
        public DateTime? Date { get; set; }
        public string Remarks { get; set; }

        public long? DeliveryOrderId { get; set; } //All data from here
        public DeliveryOrder DeliveryOrder { get; set; }

        public long? TransportId { get; set; }
        public Transport Transport { get; set; }

        public long? SalesInvoiceId { get; set; }
        public SalesInvoice SalesInvoice { get; set; }
    }
}
