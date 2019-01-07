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
    public class SalesOrderRepository : RepoBase<SalesOrder>, ISalesOrderRepository
    {
        public IEnumerable<SalesOrder> GetSalesOrdersByMonth(DateTime date)
        {
            return Table.Where(a => a.IssueDate.Value.Month == date.Month && a.IssueDate.Value.Year == date.Year).Include(a => a.SalesOrderItems)
                .Include("SalesOrderItems.Inventory").Include("SalesOrderItems.InventoryItem").Include("SalesOrderItems.InventoryItem.Brand")
                .Include("SalesOrderItems.InventoryItem.Unit").Include("SalesOrderItems.InventoryItem.PackType")
                .Include("SalesOrderItems.InventoryItem.PackSize").Include("SalesOrderItems.InventoryItem.PackCategory")
                .Include("SalesOrderItems.InventoryItem.ProductType").Include("SalesOrderItems.InventoryItem.InventoryItemCategory")
                .Include("SalesOrderItems.InventoryItem.PackageType").Include("SalesOrderItems.InventoryItem.Inventory")
                .Include(b => b.Customer).ToList().OrderByDescending(a => a.SalesOrderId);
        }

        public SalesOrder GetSalesOrderDetailsByCode(string code)
        {
            try
            {
                if (Table.Where(a => a.SalesOrderCode == code).Include(a => a.SalesReturn).FirstOrDefault().SalesReturn != null)
                    return null;

                return Table.Where(a => a.SalesOrderCode == code).Include(b => b.SalesOrderItems).Include("SalesOrderItems.InventoryItem")
                    .Include("SalesOrderItems.InventoryItem.PackType").Include("SalesOrderItems.InventoryItem.PackSize")
                    .Include("SalesOrderItems.InventoryItem.Unit").Include("SalesOrderItems.Inventory").Include(a => a.Customer)
                    .FirstOrDefault();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}
