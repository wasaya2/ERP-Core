using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrackerService.ViewModels
{
    public class InventoryTakingViewModel
    {
        public string Brand { get; set; }

        public IEnumerable<InventoryTakingItem> Items { get; set; }


    }

    public class InventoryTakingItem
    {
        public string SkuItem { get; set; }

        public int? Quantity { get; set; }
    }
}
