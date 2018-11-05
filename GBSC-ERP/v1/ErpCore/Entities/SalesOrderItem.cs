using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class SalesOrderItem : BaseClass
    {
        [Key]
        public long SalesOrderItemId { get; set; }
        public double? ComissionAmount { get; set; }
        public double? TaxAmount { get; set; }
        public double? TradeOfferAmountPerUnit { get; set; }
        public double? TotalTradeOfferAmountPerItem { get; set; }
        public double? ItemTotalAmount { get; set; }
        public double? BasicAmount { get; set; }
        public double? OrderUnitQuantity { get; set; }

        public double? EquivalentUnitQuantity { get; set; } //Calculated From PackType

        public long? PackTypeId { get; set; }
        public PackType PackType { get; set; }
        
        public long? SalesOrderId { get; set; }
        public SalesOrder SalesOrder { get; set; }

        public long? InventoryItemId { get; set; }
        public InventoryItem InventoryItem { get; set; }

        public long? InventoryId { get; set; } //Check if item in in inventory but dont subtract inventory here
        public Inventory Inventory { get; set; }

        public long? ComissionId { get; set; }
        public Comission Comission { get; set; }
    }
}
