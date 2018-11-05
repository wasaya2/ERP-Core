using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PurchaseIndent : BaseClass
    {
        public PurchaseIndent()
        {
            PurchaseIndentItems = new HashSet<PurchaseIndentItem>();
        }

        [Key]
        public long PurchaseIndentId { get; set; }

        public DateTime? Date { get; set; }
        public string PurchaseIndentNumber { get; set; }

        public DateTime? IssueDate { get; set; }
        public bool? IsIssued { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public bool? IsProcessed { get; set; }

        public long? PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }

        public IEnumerable<PurchaseIndentItem> PurchaseIndentItems { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
