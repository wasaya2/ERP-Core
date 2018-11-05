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
            Areas = new HashSet<Area>();
        }

        [Key]
        public long RegionId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Area> Areas { get; set; }
    }
}
