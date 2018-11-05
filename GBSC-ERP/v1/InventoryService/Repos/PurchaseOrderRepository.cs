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
    public class PurchaseOrderRepository : RepoBase<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrder GetPurchaseOrderDetailsByCode(string code)
        {
            try
            {
                if (Table.Where(a => a.OrderNumber == code).Include(a => a.GRN).FirstOrDefault().GRN != null)
                    return null;

                return Table.Where(a => a.OrderNumber == code).Include(b => b.PurchaseOrderItems).Include("PurchaseOrderItems.InventoryItem")
                    .Include("PurchaseOrderItems.InventoryItem.PackType").Include("PurchaseOrderItems.InventoryItem.PackSize")
                    .Include("PurchaseOrderItems.InventoryItem.Unit").Include("PurchaseOrderItems.Inventory").Include(a => a.Supplier)
                    .Include(a => a.InventoryCurrency).FirstOrDefault();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public IEnumerable<PurchaseOrder> GetPurchaseOrdersByMonth(DateTime date)
        {
            return Table.Where(a => a.OrderDate.Value.Month == date.Month && a.OrderDate.Value.Year == date.Year)
                .Include(a => a.PurchaseOrderItems).Include("PurchaseOrderItems.Inventory")
                .Include("PurchaseOrderItems.InventoryItem").Include("PurchaseOrderItems.InventoryItem.Brand")
                .Include("PurchaseOrderItems.InventoryItem.Unit").Include("PurchaseOrderItems.InventoryItem.PackType")
                .Include("PurchaseOrderItems.InventoryItem.PackSize").Include("PurchaseOrderItems.InventoryItem.PackCategory")
                .Include("PurchaseOrderItems.InventoryItem.ProductType").Include("PurchaseOrderItems.InventoryItem.InventoryItemCategory")
                .Include("PurchaseOrderItems.InventoryItem.PackageType").Include(a => a.Supplier).Include(a => a.InventoryCurrency)
                .ToList().OrderByDescending(a => a.PurchaseOrderId);
        }
    }
}
