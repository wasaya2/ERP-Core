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
        public IEnumerable<OrderTakingInventoryViewModel> GetGeneralInventoryItems(long CompanyId)
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
                .Include("InventoryItems.InventoryItemCategory")
                .Where(b => b.CompanyId == CompanyId && b.IsGeneralBrand == true)
                .Select(c => new OrderTakingInventoryViewModel
                {
                    BrandName = c.Name,
                    Items = c.InventoryItems.GroupBy(f => f.InventoryItemCategory.Name, i => new Item
                    {
                        InventoryItemId = i.InventoryItemId,
                        Name = i.Name,
                        MeasurementUnit = i.MeasurementUnit.Name,
                        PackageUnit = i.PackageUnit.Name,
                        RateUnit = i.PackageUnit.Name,
                        RegularDiscount = i.RegularDiscount,
                        SalesUnit = i.SalesUnit.Name,
                        ProductType = i.InventoryItemCategory.Name,
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

        public IEnumerable<OrderTakingInventoryViewModel> GetNonGeneralInventoryItems(long CompanyId)
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
                .Include("InventoryItems.InventoryItemCategory")
                .Where(b => b.CompanyId == CompanyId && b.IsGeneralBrand == false)
                .Select(c => new OrderTakingInventoryViewModel
                {
                    BrandName = c.Name,
                    Items = c.InventoryItems.GroupBy(f => f.InventoryItemCategory.Name, i => new Item
                    {
                        InventoryItemId = i.InventoryItemId,
                        Name = i.Name,
                        MeasurementUnit = i.MeasurementUnit.Name,
                        PackageUnit = i.PackageUnit.Name,
                        RateUnit = i.PackageUnit.Name,
                        RegularDiscount = i.RegularDiscount,
                        SalesUnit = i.SalesUnit.Name,
                        ProductType = i.InventoryItemCategory.Name,
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
