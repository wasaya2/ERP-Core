using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class CustomerPricePickLevel
    {
        [Key]
        public long CustomerPricePickLevelId { get; set; }
        public string Name { get; set; }
        public double? Value { get; set; }

        public long? CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; } 
    }
}
