using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Region : BaseClass
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        public long RegionId { get; set; }
        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}
