using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.ViewModels
{
    public class DistributorWithTerritoriesViewModel
    {
        public Distributor Distributor { get; set; }

        public int[] TerritoryIds { get; set; }
    }
}
