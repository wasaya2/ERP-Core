using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class ItemPriceStructure : BaseClass
    {
        [Key]
        public long ItemPriceStructureId { get; set; }
        public string Name { get; set; }
    }
}
