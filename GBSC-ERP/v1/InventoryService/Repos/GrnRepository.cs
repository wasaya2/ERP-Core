using ErpCore.Entities;
using InventoryService.Repos.Base;
using InventoryService.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos
{
    public class GrnRepository : RepoBase<GRN>, IGrnRepository
    {
        public IEnumerable<GRN> GetGRNsByMonth(DateTime date)
        {
            return Table.Where(a => a.GrnDate.Value.Month == date.Month && a.GrnDate.Value.Year == date.Year)
                .Include(b => b.PurchaseOrder).Include(a => a.GrnItems)
                .Include("GrnItems.InventoryItem").Include("GrnItems.InventoryItem.Brand")
                .Include("GrnItems.InventoryItem.Unit").Include("GrnItems.InventoryItem.PackType")
                .Include("GrnItems.InventoryItem.PackSize").Include("GrnItems.InventoryItem.PackCategory")
                .Include("GrnItems.InventoryItem.ProductType").Include("GrnItems.InventoryItem.InventoryItemCategory")
                .Include("GrnItems.InventoryItem.PackageType").Include("GrnItems.InventoryItem.Inventory")
                .ToList().OrderByDescending(a => a.PurchaseOrderId);
        }
    }
}
