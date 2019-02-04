using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PurchaseInvoice : BaseClass
    {
        [Key]
        public long PurchaseInvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public string VendorBillNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        //public string Status { get; set; }
        //public DateTime? BillDate { get; set; }
        //public string Remarks { get; set; }
        //public string Origin { get; set; } //Imported or local
        //public string Currency { get; set; }
        public double? ExchangeRate { get; set; }

        public long? PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        public long? InventoryCurrencyId { get; set; }
        public InventoryCurrency InventoryCurrency { get; set; }

        public long? GRNId { get; set; }
        public GRN GRN { get; set; }
    }
}
