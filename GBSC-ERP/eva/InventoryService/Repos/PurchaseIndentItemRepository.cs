using InventoryService.Repos.Base;
using InventoryService.Repos.Interfaces;
using ErpCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos
{
    public class PurchaseIndentItemRepository : RepoBase<PurchaseIndentItem>, IPurchaseIndentItemRepository
    {
    }
}
