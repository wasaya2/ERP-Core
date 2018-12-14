using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class SalesOrder : BaseClass
    {
        public SalesOrder()
        {
            SalesOrderItems = new HashSet<SalesOrderItem>();
        }

        [Key]
        public long SalesOrderId { get; set; }
        public string SalesOrderCode { get; set; }

        public DateTime? IssueDate { get; set; }
        public bool? IsIssued { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public bool? IsProcessed { get; set; }

        public string Remarks { get; set; }
        public string SlipNumber { get; set; } //For Clinic { Get Patient Invoice Number as Slip Number here }
        public bool? Status { get; set; }

        public string ContactPerson { get; set; }
        public string ContactPersonNumber { get; set; }
        public string AgainstLotNumber { get; set; }
        public DateTime? DeliveryDate { get; set; }
        //public string CustomerName { get; set; }

        public double? TotalQuantity { get; set; }
        public double? ExtendedAmount { get; set; }
        public double? DiscountedAmount { get; set; }
        public bool? Shipped { get; set; }
        public double? DiscountAmount { get; set; }
        public double? SalesTaxAmount { get; set; }
        //public double? GrossAmount { get; set; } //Get from Sales Indent
        //public double? TradeOfferTotal { get; set; } //Get from Sales Indent
        public double? OrderAmount { get; set; }

        public double? SpecialDiscountPercentage { get; set; }
        public double? SpecialDiscountAmount { get; set; }

        public double? ExtraDiscountPercentage { get; set; }
        public double? ExtraDiscountAmount { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<SalesOrderItem> SalesOrderItems { get; set; }
        
        public long? DeliveryOrderId { get; set; }
        public DeliveryOrder DeliveryOrder { get; set; }

        public long? SalesReturnId { get; set; }
        public SalesReturn SalesReturn { get; set; }

        //Inventory Addon
        public long? SalesIndentId { get; set; }
        public SalesIndent SalesIndent { get; set; }

        public long? ModeOfPaymentId { get; set; }
        public ModeOfPayment ModeOfPayment { get; set; }

        public long? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public long? TaxId { get; set; }
        public Tax Tax { get; set; }

    }
}