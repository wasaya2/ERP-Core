using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class SalesIndent : BaseClass
    {
        public SalesIndent()
        {
            SalesIndentItems = new HashSet<SalesIndentItem>();
        }

        [Key]
        public long SalesIndentId { get; set; }
        public DateTime? Date { get; set; }
        public string SalesIndentNumber { get; set; }

        public double? TotalQuantity { get; set; }
        public double? TotalTradePrice { get; set; }
        public double? TotalTradeOfferDiscount { get; set; }
        public double? TotalTradeOffer { get; set; }

        //For integration with HIMS Patient Invoice
        public string ConsultantName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSecondName { get; set; }
        public string CustomerCode { get; set; }
        /*******************************************/


        //For integration with eTracker OrderTaking
        public long? StoreId { get; set; }
        public long? StoreVisitId { get; set; }

        public long? DistributorId { get; set; }
        public Distributor Distributor { get; set; }
        /*****************************************/

        public DateTime? IssueDate { get; set; }
        public bool? IsIssued { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public bool? IsProcessed { get; set; }

        //Shop setup?

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }

        public long? DeliveryOrderId { get; set; }
        public DeliveryOrder DeliveryOrder { get; set; }

        public long? SalesInvoiceId { get; set; }
        public SalesInvoice SalesInvoice { get; set; }

        public long? DeliveryChallanId { get; set; }
        public DeliveryChallan DeliveryChallan { get; set; }

        public IEnumerable<SalesIndentItem> SalesIndentItems { get; set; }

    }
}
