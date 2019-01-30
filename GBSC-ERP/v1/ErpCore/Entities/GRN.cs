using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class GRN : BaseClass
    {
        public GRN()
        {
            GrnItems = new HashSet<GrnItem>();
        }

        [Key]
        public long GRNId { get; set; }
        public string GrnNumber { get; set; }
        public DateTime? GrnDate { get; set; }
        public string Remarks { get; set; }
        public string VendorBillNumber { get; set; }

        public double? TotalExpectedAmount { get; set; }
        public double? TotalPaymentAmount { get; set; }
        public double? TotalDifferenceAmount { get; set; }

        public double? TotalExpectedQuantity { get; set; }
        public double? TotalReceivedQuantity { get; set; }
        public double? TotalDifferenceQuantity { get; set; }

        public long? PurchaseInvoiceId { get; set; }
        public PurchaseInvoice PurchaseInvoice { get; set; }

        public long? PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        public long? PurchaseReturnId { get; set; }
        public PurchaseReturn PurchaseReturn { get; set; }

        public IEnumerable<GrnItem> GrnItems { get; set; }
    }
}