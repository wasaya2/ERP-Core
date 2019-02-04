using ErpCore.Entities;
using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.ViewModels
{
    public class GetGrnWithSupplierForPharmacyPurchaseReturn
    {
        public GRN GRN { get; set; }
        public Supplier  Supplier { get; set; }
    }
}
