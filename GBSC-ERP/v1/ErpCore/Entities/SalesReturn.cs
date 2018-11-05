using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class SalesReturn : BaseClass
    {
        public SalesReturn()
        {
            SalesReturnItems = new HashSet<SalesReturnItem>();
        }

        [Key]
        public long SalesReturnId { get; set; }
        public string ReturnNumber { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Remarks { get; set; }
        public double? TotalReturnAmount { get; set; }
        
        public long? ReturnReasonId { get; set; }
        public ReturnReason ReturnReason { get; set; }

        public long? SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }

        public long? SalesInvoiceId { get; set; } //check items from sales invoice to see which ones need o be returned
        public SalesInvoice SalesInvoice { get; set; }

        public IEnumerable<SalesReturnItem> SalesReturnItems { get; set; }
    }
}
