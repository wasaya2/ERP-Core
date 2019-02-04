using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Brand : BaseClass
    {
        public Brand()
        {
            InventoryItems = new HashSet<InventoryItem>();
        }

        [Key]
        public long BrandId { get; set; }

        public string BrandCode { get; set; }

        public string Name { get; set; }

        public bool? IsGeneralBrand { get; set; }

        public bool? ShowInNsv { get; set; }

        public IEnumerable<InventoryItem> InventoryItems { get; set; }
    }
}
