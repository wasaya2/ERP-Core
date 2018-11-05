using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PurchaseReturn : BaseClass
    {
        public PurchaseReturn()
        {
            PurchaseReturnItems = new HashSet<PurchaseReturnItem>();
        }

        [Key]
        public long PurchaseReturnId { get; set; }

        public string ReturnNumber { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Remarks { get; set; }
        public double? TotalReturnAmount { get; set; }

        public long? ReturnReasonId { get; set; }
        public ReturnReason ReturnReason { get; set; }

        public long? GRNId { get; set; }
        public GRN GRN { get; set; }

        public IEnumerable<PurchaseReturnItem> PurchaseReturnItems { get; set; }
    }
}
