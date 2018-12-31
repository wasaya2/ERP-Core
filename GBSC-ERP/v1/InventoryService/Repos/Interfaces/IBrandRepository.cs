using ErpCore.Entities.InventorySetup;
using InventoryService.Repos.Base;
using InventoryService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos.Interfaces
{
    public interface IBrandRepository : IRepo<Brand>
    {
        IEnumerable<OrderTakingInventoryViewModel> GetInventoryItems(long CompanyId);
   }
}
