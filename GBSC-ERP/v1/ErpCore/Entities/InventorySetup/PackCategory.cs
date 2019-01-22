using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class PackCategory : BaseClass
    {
        public PackCategory()
        {
        }

        [Key]
        public long PackCategoryId { get; set; }
        public string PackCategoryCode { get; set; }
        public string Name { get; set; }

    }
}
