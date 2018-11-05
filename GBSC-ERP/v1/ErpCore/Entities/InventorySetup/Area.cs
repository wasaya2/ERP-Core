using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Area
    {
        public Area()
        {
            Territories = new HashSet<Territory>();
        }

        [Key]
        public long AreaId { get; set; }
        public string Name { get; set; }

        public IEnumerable<Territory> Territories { get; set; }

        public long? RegionId { get; set; }
        public Region Region { get; set; }
    }
}
