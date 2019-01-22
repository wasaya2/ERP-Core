using InventoryService.Repos.Base;
using InventoryService.Repos.Interfaces;
using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Repos
{
    public class InventoryItemRepository : RepoBase<InventoryItem>, IInventoryItemRepository
    {
        public IEnumerable<InventoryItem> GetAllInventoryItems()
        {

            return Table.Include(a => a.Inventory).Include(b => b.InventoryItemCategory).Include(c => c.PackageType).
                        Include(d => d.PackCategory).Include(e => e.PackSize).
                        Include(f => f.PackType).Include(g => g.ProductType).
                        Include(h => h.MeasurementUnit).Select(x=> x);
        }

        public InventoryItem GetInventoryItemById(long id)
        {
            return Table.Where(i => i.InventoryItemId == id).Include(a => a.Inventory).
                        Include(b => b.InventoryItemCategory).Include(c => c.PackageType).
                        Include(d => d.PackCategory).Include(e => e.PackSize).
                        Include(f => f.PackType).Include(g => g.ProductType).
                        Include(h => h.MeasurementUnit).FirstOrDefault();
        }
    }
}
