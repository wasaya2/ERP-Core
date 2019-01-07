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
    public class SalesReturnRepository : RepoBase<SalesReturn>, ISalesReturnRepository
    {
        public IList<SalesReturn> GetSalesReturns()
        {
            return Table.Include(a => a.SalesReturnItems).Include("SalesReturnItems.InventoryItem").Include("SalesReturnItems.InventoryItem.PackType").Include("SalesReturnItems.InventoryItem.PackSize")
                                .Include("SalesReturnItems.InventoryItem.Unit").Include(b => b.ReturnReason).Include(c => c.SalesOrder).OrderByDescending(a => a.SalesReturnId).ToList();
        }

        public IList<SalesReturn> GetSalesReturnsForMonth(DateTime date)
        {
            return Table.Where(a => a.ReturnDate.Value.Month == date.Month && a.ReturnDate.Value.Year == date.Year).Include(a => a.SalesReturnItems)
                                .Include("SalesReturnItems.InventoryItem").Include("SalesReturnItems.InventoryItem.PackType")
                                .Include("SalesReturnItems.InventoryItem.PackSize").Include("SalesReturnItems.InventoryItem.Unit")
                                .Include(b => b.ReturnReason).Include(c => c.SalesOrder).OrderByDescending(a => a.SalesReturnId).ToList();
        }

        public IEnumerable<SalesReturn> GetSalesReturnsByMonth(DateTime date)
        {
            return Table.Where(a => a.ReturnDate.Value.Month == date.Month && a.ReturnDate.Value.Year == date.Year).Include(a => a.SalesReturnItems)
                                .Include("SalesReturnItems.InventoryItem.Brand")
                                .Include("SalesReturnItems.InventoryItem.Unit").Include("SalesReturnItems.InventoryItem.PackType")
                                .Include("SalesReturnItems.InventoryItem.PackSize").Include("SalesReturnItems.InventoryItem.PackCategory")
                                .Include("SalesReturnItems.InventoryItem.ProductType").Include("SalesReturnItems.InventoryItem.InventoryItemCategory")
                                .Include("SalesReturnItems.InventoryItem.PackageType").Include("SalesReturnItems.InventoryItem.Inventory")
                                .Include(b => b.ReturnReason).Include(c => c.SalesOrder).OrderByDescending(a => a.SalesReturnId)
                                .ToList().OrderByDescending(a => a.SalesReturnId);
        }
    }
}
