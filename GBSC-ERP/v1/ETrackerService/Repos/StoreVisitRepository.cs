using System.Collections.Generic;
using eTrackerCore.Entities;
using eTrackerInfrastructure.Repos.Base;
using eTrackerInfrastructure.Repos.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eTrackerInfrastructure.Models.JsonPostClasses;
using ErpCore.Entities.ETracker;
using ErpCore.Entities.InventorySetup;
using ETrackerService.ViewModels;

namespace eTrackerInfrastructure.Repos
{
    public class StoreVisitRepository : RepoBase<StoreVisit>, IStoreVisitRepository
    {
        public StoreVisitRepository()
        {
            Table = Context.StoreVisits;
        }

        public void AddCompetativeStock(CompetatorStock competativestock)
        {
            var _storevisit = Table.FirstOrDefault(o => o.StoreVisitId == competativestock.StoreVisitId);
            _storevisit.CompetatorStocks.Add(competativestock);
            Update(_storevisit);
        }

        public void AddMultipleCompetativeStock(CompetativeStocks competativestocks)
        {
            foreach (var stock in competativestocks.CompetatorStock)
            {
                AddCompetativeStock(stock);
            }
        }

        public void AddMerchendize(Merchandising merch)
        {
            var _storevisit = Table.FirstOrDefault(o => o.StoreVisitId == merch.StoreVisitId);
            _storevisit.Merchandisings.Add(merch);
            Update(_storevisit);
        }

        public void AddOrder(OrderTaking order)
        {
            var _storevisit = Table.FirstOrDefault(o => o.StoreVisitId == order.StoreVisitId);
            _storevisit.OrderTakings.Add(order);
            Update(_storevisit);
        }


        public void AddMultipleOrders(Orders orders)
        {
            foreach (var order in orders.Order)
            {
                AddOrder(order);
            }
        }

        public void AddInventoryTaking(InventoryTaking inventory)
        {
            var _storevisit = Table.FirstOrDefault(o => o.StoreVisitId == inventory.StoreVisitId);
            _storevisit.InventoryTakings.Add(inventory);
            Update(_storevisit);
        }

        public void AddMultipleInventoryTakings(InventoryTakings inventory)
        {
            foreach (var inv in inventory.InventoryTaking)
            {
                AddInventoryTaking(inv);
            }
        }

        public void AddOutletStock(OutletStock stock)
        {
            var _storevisit = Table.FirstOrDefault(o => o.StoreVisitId == stock.StoreVisitId);
            _storevisit.OutletStocks.Add(stock);
            Update(_storevisit);
        }

        public void AddMultipleStockItems(Stocks stocks)
        {
            foreach (var stock in stocks.Stock)
            {
                AddOutletStock(stock);
            }
        }

        public void UpdateStock(OutletStock stock)
        {
            Context.OutletStocks.Update(stock);
            Context.SaveChanges();
        }

        public IEnumerable<CompetatorStock> CompetativeStocks(long storeVisitId)
        {
            return Context.CompetatorStocks.OrderByDescending(a => a.CompetatorStockId).Where(s => s.StoreVisitId == storeVisitId);
        }

        public IEnumerable<Merchandising> GetMerchendiseList(long storeVisitId)
        {
            return Context.Merchandisings.OrderByDescending(a => a.MerchandisingId).Where(s => s.StoreVisitId == storeVisitId);
        }

        public string GetNoOrderReason(long StoreVisitId)
        {
            var order = Context.OrderTakings.FirstOrDefault(c => c.StoreVisitId == StoreVisitId);

            return order != null ? order.NoOrderReason : "";
        }

        public IEnumerable<OrderTaking> GetOrders(long storeVisitId)
        {
            return Context.OrderTakings.OrderByDescending(a => a.OrderTakingId).Where(s => s.StoreVisitId == storeVisitId);
        }

        public IEnumerable<OutletStock> GetOutletStocks(long storeVisitId)
        {
            return Context.OutletStocks.OrderByDescending(a => a.OutletStockId).Where(s => s.StoreVisitId == storeVisitId);
        }

        public IEnumerable<StoreVisit> GetVisitsByStoreId(long id)
        {
            return Table.OrderByDescending(a => a.StoreVisitId).Where(v => v.StoreId == id).ToList();
        }

        public OutletStock GetStockItemById(long OutletStockId)
        {
            return Context.OutletStocks
                .Include("StoreVisit")
                .FirstOrDefault(s => s.OutletStockId == OutletStockId);
        }

        public StoreVisit GetStoreVisitWithStore(long storevisitId)
        {
            return Context.StoreVisits
                .Include(s => s.Store)
                .Include(s => s.CompetatorStocks)
                .Include(s => s.Merchandisings)
                .Include(s => s.OrderTakings)
                .Include(s => s.OutletStocks)
                .FirstOrDefault(s => s.StoreVisitId == storevisitId);
        }

        public Store GetStoreByStoreVisitId(long storevisitid)
        {
            return Table.Include(s => s.Store).FirstOrDefault(s => s.StoreVisitId == storevisitid)?.Store;
        }

        public StoreVisit MostRecenetStoreVisit(long storeid)
        {
            return Table.Where(s => s.StoreId == storeid).OrderByDescending(s => s.StoreVisitId).FirstOrDefault();
        }

        public IEnumerable<OrderTakingViewModel> GetVisitOrders(long StoreVisitId)
        {

            var items = (from storevisit in Db.StoreVisits
                         join order in Db.OrderTakings on storevisit.StoreVisitId equals order.StoreVisitId
                         join item in Db.InventoryItems on order.InventoryItemId equals item.InventoryItemId
                         join brand in Db.Brands on item.BrandId equals brand.BrandId
                         join unit in Db.Units on item.UnitId equals unit.UnitId
                         join packtype in Db.PackTypes on item.PackageTypeId equals packtype.PackTypeId
                         join packsize in Db.PackSizes on item.PackSizeId equals packsize.PackSizeId
                         join producttype in Db.ProductTypes on item.ProductTypeId equals producttype.ProductTypeId
                         where storevisit.StoreVisitId == StoreVisitId
                         group item by item.Brand.Name into g
                         select new OrderTakingViewModel
                         {
                             BrandName = g.Key,
                             Items = g.GroupBy(f => f.ProductType.Name, i => new Item
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
                             }, (key, s) => new GroupedItems { ProductType = key, Items = s.ToList() })
                         });

            return items;
        }

            public IEnumerable<OrderTakingViewModel> GetVisitInventories(long StoreVisitId)
        {

            var items = (from storevisit in Db.StoreVisits
                         join inventorytaking in Db.InventoryTakings on storevisit.StoreVisitId equals inventorytaking.StoreVisitId
                         join item in Db.InventoryItems on inventorytaking.InventoryItemId equals item.InventoryItemId
                         join brand in Db.Brands on item.BrandId equals brand.BrandId
                         join unit in Db.Units on item.UnitId equals unit.UnitId
                         join packtype in Db.PackTypes on item.PackageTypeId equals packtype.PackTypeId
                         join packsize in Db.PackSizes on item.PackSizeId equals packsize.PackSizeId
                         join producttype in Db.ProductTypes on item.ProductTypeId equals producttype.ProductTypeId
                         where storevisit.StoreVisitId == StoreVisitId
                         group item by item.Brand.Name into g
                         select new OrderTakingViewModel
                         {
                             BrandName = g.Key,
                             Items = g.GroupBy(f => f.ProductType.Name, i => new Item
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
                             }, (key, s) => new GroupedItems { ProductType = key, Items = s.ToList() })
                         });

            return items;
        }

    }
}


