using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class PackSize : BaseClass
    {
        public PackSize()
        {
        }

        [Key]
        public long PackSizeId { get; set; }
        public double? Size { get; set; }

    }
}
