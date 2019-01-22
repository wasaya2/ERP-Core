using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class GeneralSKU : BaseClass
    {
        [Key]
        public long GeneralSKUId { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public string SKUCode { get; set; }
    }
}
