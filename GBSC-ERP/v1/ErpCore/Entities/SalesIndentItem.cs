using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class SalesIndentItem : BaseClass
    {
        [Key]
        public long SalesIndentItemId { get; set; }
        public double? Quantity { get; set; }

        public double? TradeOfferPricePerUnit { get; set; }

        public double? TotalTradeOfferPerItem { get; set; }
        public double? TotalTradePricePerItem { get; set; }
        
        //For integration with HIMS Patient Invoice
        public double? Dosage { get; set; }
        public DateTime? TreatmentStart { get; set; }
        public DateTime? TreatmentEnd { get; set; }
        public double? TreatmentTimeInDays { get; set; }
        public bool? IsPaid { get; set; }
        /********************************************/

        public long? SalesIndentId { get; set; }
        public SalesIndent SalesIndent { get; set; }

        public long? InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public long? InventoryId { get; set; } //Check if item in in inventory but dont subtract inventory here
        public Inventory Inventory { get; set; }
    }
}
