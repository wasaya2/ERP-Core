using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class GrnItem : BaseClass
    {
        [Key]
        public long GrnItemId { get; set; }
        public double? Quantity { get; set; }

        public string PackType { get; set; }
        public double? PackSize { get; set; }
        public string NumberPackType { get; set; }
        public string BatchNumber { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public double? Rate { get; set; }

        //For Pharmacy
        public double? ExpectedAmount { get; set; }
        public double? PaymentAmount { get; set; }
        public double? DifferenceAmount { get; set; }
        //For Pharmacy
        public double? ExpectedQuantity { get; set; }
        public double? ReceivedQuantity { get; set; }
        public double? DifferenceQuantity { get; set; }

        public long? InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public long? GRNId { get; set; }
        public GRN GRN { get; set; }
    }
}
