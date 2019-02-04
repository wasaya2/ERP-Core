using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PurchaseOrder : BaseClass
    {
        public PurchaseOrder()
        {
            PurchaseOrderItems = new HashSet<PurchaseOrderItem>();
        }

        [Key]
        public long PurchaseOrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public string OrderType { get; set; }
        public string OrderRemarks { get; set; }

        public DateTime? IssueDate { get; set; }
        public bool? IsIssued { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public bool? IsProcessed { get; set; }

        public string VendorBillNumber { get; set; }
        public DateTime? BillDate { get; set; }
        public string Origin { get; set; } //Imported or local
        //public string Currency { get; set; }
        public double? ExchangeRate { get; set; }
        public string Remarks { get; set; }
        public bool? Status { get; set; }

        public long? SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        
        public long? PurchaseIndentId { get; set; }
        public PurchaseIndent PurchaseIndent { get; set; }

        //public long? PurchaseInvoiceId { get; set; }
        public PurchaseInvoice PurchaseInvoice { get; set; }

        public long? InventoryCurrencyId { get; set; }
        public InventoryCurrency InventoryCurrency { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? GRNId { get; set; }
        public GRN GRN { get; set; }

        public IEnumerable<PurchaseOrderItem> PurchaseOrderItems { get; set; }
    }
}
