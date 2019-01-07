using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Territory : BaseClass
    {
        public Territory()
        {
            Sections = new HashSet<Section>();
        }
        [Key]
        public long TerritoryId { get; set; }
        public string Name { get; set; }
        public bool? IsAssigned { get; set; }

        public long? AreaId { get; set; }
        public Area Area { get; set; }

        public long? DistributorId { get; set; }

        public Distributor Distributor { get; set; }

        public IEnumerable<Section> Sections { get; set; }

        public long? UserId { get; set; }

        public User User { get; set; }

    }
}
