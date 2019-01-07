using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.ViewModels
{
    public class SalesIndentPharmacyViewModel
    {
        public long? SalesIndentId { get; set; }
        public long? SalesIndentItemId { get; set; }
        public DateTime? IssueDate { get; set; }
        public double? Quantity { get; set; }
        public double? TotalTradeOfferPerItem { get; set; }
        public double? TotalTradePricePerItem { get; set; }
        public double? TradeOfferPricePerUnit { get; set; }
        public double? Dosage { get; set; }
        public bool? IsPaid { get; set; }
        public double? TreatmentTimeInDays { get; set; }
        public DateTime? TreatmentStart { get; set; }
        public DateTime? TreatmentEnd { get; set; }
        public string InventoryItemName { get; set; }
        public double? CostPrice { get; set; }
        public double? RetailPrice { get; set; }
        public string ItemCode { get; set; }
        public string UnitName { get; set; }
        public string PackTypeName { get; set; }
        public double? PackSize { get; set; }
        public string ProductTypeName { get; set; }
    }
}
