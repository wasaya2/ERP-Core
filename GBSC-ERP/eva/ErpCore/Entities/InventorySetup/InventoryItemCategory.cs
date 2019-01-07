using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class InventoryItemCategory : BaseClass
    {
        public InventoryItemCategory()
        {
        }

        [Key]
        public long InventoryItemCategoryId { get; set; }
        public string Name { get; set; }

    }
}
