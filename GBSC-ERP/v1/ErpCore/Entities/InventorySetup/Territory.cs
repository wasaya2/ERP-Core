using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Territory
    {
        [Key]
        public long TerritoryId { get; set; }
        public string Name { get; set; }
        public bool? IsAssigned { get; set; }

        public long? AreaId { get; set; }
        public Area Area { get; set; }
        
        public Distributor Distributor { get; set; }

    }
}
