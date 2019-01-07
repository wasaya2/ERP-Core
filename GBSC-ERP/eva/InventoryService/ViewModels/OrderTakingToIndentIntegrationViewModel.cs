using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.ViewModels
{
    public class OrderTakingToIndentIntegrationViewModel
    {
        public long? OrderTakingId { get; set; }
        public long? InventoryItemId { get; set; }
        public double? Quantity { get; set; }
        public long? StoreVisitId { get; set; }
        public long? CompanyId { get; set; }
        public long? StoreId { get; set; }
    }
}
