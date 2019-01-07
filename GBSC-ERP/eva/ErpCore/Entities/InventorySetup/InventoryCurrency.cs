using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class InventoryCurrency
    {
        [Key]
        public long InventoryCurrencyId { get; set; }
        public string Name { get; set; }
        public double? ExchangeRate { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
