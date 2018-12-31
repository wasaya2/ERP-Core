using InventoryService.Repos.Base;
using InventoryService.Repos.Interfaces;
using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryService.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace InventoryService.Repos
{
    public class BrandRepository : RepoBase<Brand>, IBrandRepository
    {
        public IEnumerable<OrderTakingInventoryViewModel> GetInventoryItems(long CompanyId)
        {
            var items = Table.Include(c => c.InventoryItems)
                .Include("InventoryItems.Unit")
                .Include("InventoryItems.PackType")
                .Include("InventoryItems.PackageType")
                .Include("InventoryItems.PackSize")
                .Include("InventoryItems.ProductType")
                .Where(b => b.CompanyId == CompanyId)
                .Select(c => new OrderTakingInventoryViewModel
                {
                    BrandName = c.Name,
                    Items = c.InventoryItems.GroupBy(f => f.ProductType.Name, i => new Item
                    {
                        InventoryItemId = i.InventoryItemId,
                        Name = i.Name,
                        ProductType = i.ProductType.Name,
                        Description = i.Description,
                        CostPrice = i.CostPrice,
                        Dose = i.Dose,
                        ItemCode = i.ItemCode,
                        MinLevel = i.MinLevel,
                        PackageType = i.PackageType.Name,
                        PackSize = i.PackSize.Size,
                        PackType = i.PackType.Name,
                        PackTypeInPackageType = i.PackTypeInPackageType,
                        PurchaseDate = i.PurchaseDate,
                        RetailPrice = i.RetailPrice,
                        TradeOfferAmount = i.TradeOfferAmount,
                        Unit = i.Unit.Name,
                        UnitPrice = i.UnitPrice
                    }, (key, g) => new GroupedItems { ProductType = key, Items = g.ToList() }
                    )
                });

            return items;
        }
    }
}
