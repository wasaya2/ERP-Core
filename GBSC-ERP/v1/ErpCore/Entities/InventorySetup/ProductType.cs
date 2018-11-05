using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class ProductType : BaseClass
    {
        public ProductType()
        {
        }

        [Key]
        public long ProductTypeId { get; set; }
        public string Name { get;set;}
        public string Class { get; set; }

    }
}
