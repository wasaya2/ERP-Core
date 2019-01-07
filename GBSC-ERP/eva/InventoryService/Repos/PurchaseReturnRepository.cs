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
    public class PurchaseReturnRepository : RepoBase<PurchaseReturn>, IPurchaseReturnRepository
    {
        public IEnumerable<PurchaseReturn> GetPurchaseReturnsByMonth(DateTime date)
        {
            return Table.Where(a => a.ReturnDate.Value.Month == date.Month && a.ReturnDate.Value.Year == date.Year)
                .Include(a => a.ReturnReason).Include(b => b.PurchaseReturnItems).Include("PurchaseReturnItems.Inventory")
                .Include("PurchaseReturnItems.InventoryItem").Include("PurchaseReturnItems.InventoryItem.Brand")
                .Include("PurchaseReturnItems.InventoryItem.Unit").Include("PurchaseReturnItems.InventoryItem.PackType")
                .Include("PurchaseReturnItems.InventoryItem.PackSize").Include("PurchaseReturnItems.InventoryItem.PackCategory")
                .Include("PurchaseReturnItems.InventoryItem.ProductType").Include("PurchaseReturnItems.InventoryItem.InventoryItemCategory")
                .Include("PurchaseReturnItems.InventoryItem.PackageType").ToList().OrderByDescending(a => a.PurchaseReturnId);
        }
    }
}
