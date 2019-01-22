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
                .Include("InventoryItems.MeasurementUnit")
                .Include("InventoryItems.SalesUnit")
                .Include("InventoryItems.RateUnit")
                .Include("InventoryItems.PackageUnit")
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
                        MeasurementUnit = i.MeasurementUnit.Name,
                        PackageUnit = i.PackageUnit.Name,
                        RateUnit = i.PackageUnit.Name,
                        RegularDiscount = i.RegularDiscount,
                        SalesUnit = i.SalesUnit.Name,
                        ProductType = i.ProductType.Name,
                        ItemCode = i.ItemCode,
                        PackageType = i.PackageType.Name,
                        PackSize = i.PackSize.Size,
                        PackType = i.PackType.Name,
                        TradeOfferAmount = i.TradeOfferAmount,
                        Unit = i.MeasurementUnit.Name,
                        UnitPrice = i.UnitPrice,
                        MuInPu = i.MuInPu,
                        MuInRu = i.MuInRu,
                        MuInSu = i.MuInSu
                    }, (key, g) => new GroupedItems { ProductType = key, Items = g.ToList() }
                    )
                });

            return items;
        }
    }
}
