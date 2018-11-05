using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class SalesInvoice : BaseClass
    {
        [Key]
        public long SalesInvoiceId { get; set; }
        public string SalesInvoiceCode { get; set; }
        public DateTime? Date { get; set; }

        //public DateTime? IssueDate { get; set; }
        //public bool? IsIssued { get; set; }
        //public DateTime? ApprovedDate { get; set; }
        //public bool? IsApproved { get; set; }
        //public DateTime? ProcessedDate { get; set; }
        //public bool? IsProcessed { get; set; }

        public long? DeliveryChallanId { get; set; } //All data from here
        public DeliveryChallan DeliveryChallan { get; set; }

        public long? SalesReturnId { get; set; }
        public SalesReturn SalesReturn { get; set; }
    }
}
