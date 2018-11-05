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
    public class SalesOrderItemRepository : RepoBase<SalesOrderItem>, ISalesOrderItemRepository
    {
        public IList<SalesOrderItem> GetSalesOrderItemsBySalesOrderID(long salesorderid)
        {
            return Table.Where(a => a.SalesOrderId == salesorderid).Include(b => b.InventoryItem).Include("InventoryItem.PackType").Include("InventoryItem.PackSize")
                                .Include("InventoryItem.ProductType").Include("InventoryItem.PackageType").Include("InventoryItem.Unit").Include("InventoryItem.Brand")
                                .Include("InventoryItem.PackCategory").Include("InventoryItem.InventoryItemCategory").Include(c => c.Inventory).ToList();
        }
    }
}
