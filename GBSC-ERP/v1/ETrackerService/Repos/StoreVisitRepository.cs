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

        public IEnumerable<GroupedItems> GetVisitOrders(long StoreVisitId)
        {

            var items = (from order in Db.OrderTakings
                         join item in Db.InventoryItems on order.InventoryItemId equals item.InventoryItemId
                         where order.StoreVisitId == StoreVisitId
                         select new Item
                         {
                             ProductType = order.inventoryItem.ProductType.Name,
                             InventoryItemId = item.InventoryItemId,
                             Name = item.Name,
                             Quantity = order.Quantity,
                             Description = item.Description,
                             CostPrice = item.CostPrice,
                             ItemCode = item.ItemCode,
                             PackageType = item.PackageType.Name,
                             PackSize = item.PackSize.Size,
                             PackType = item.PackType.Name,
                             PackTypeInPackageType = item.PackTypeInPackageType,
                             PurchaseDate = item.PurchaseDate,
                             RetailPrice = item.RetailPrice,
                             TradeOfferAmount = item.TradeOfferAmount,
                             Unit = item.MeasurementUnit.Name,
                             UnitPrice = item.UnitPrice
                         }).ToList();

            var grouped = (from product in items
                           group product by product.ProductType into g
                           select new GroupedItems
                           {
                               ProductType = g.Key,
                               Items = g.ToList()
                           });


            return grouped;
        }

        public IEnumerable<LastTwoVisits> GetLastTwoVisits(long StoreId)
        {
            var visitHistory = (from
                                indent in Db.SalesIndents
                                join user in Db.Users on indent.UserId equals user.UserId
                                join storevisit in Db.StoreVisits on indent.StoreVisitId equals storevisit.StoreVisitId
                                where indent.StoreId == StoreId
                                orderby indent.ProcessedDate
                                select new LastTwoVisits
                                {
                                    SalesIndentId = indent.SalesIndentId,
                                    BillDate = indent.ProcessedDate,
                                    BilledTo = indent.CustomerCode,
                                    VisitDateTime = storevisit.StartTime,
                                    VisitedBy = user.FullName,
                                    Total = indent.TotalTradePrice,
                                    Items = (from
                                             indentItem in Db.SalesIndentItems
                                             where indentItem.SalesIndentId == indent.SalesIndentId
                                             select new LastvisitOrderItem
                                             {
                                                 ItemName = indentItem.InventoryItem.Name,
                                                 PackType = indentItem.InventoryItem.PackType.Name,
                                                 Quantity = indentItem.Quantity,
                                                 UnitPrice = indentItem.InventoryItem.UnitPrice,
                                                 GrossAmount = indentItem.ItemGrossAmount,
                                                 NetAmount = indentItem.ItemNetAmount
                                             }).ToList()
                                }).ToList().TakeLast(2);


            return visitHistory.Reverse();
        }

        public IEnumerable<InventoryTakingViewModel> GetVisitInventories(long StoreVisitId)
        {

            var items = (from storevisit in Db.StoreVisits
                         join inventorytaking in Db.InventoryTakings on storevisit.StoreVisitId equals inventorytaking.StoreVisitId
                         where storevisit.StoreVisitId == StoreVisitId  
                         group inventorytaking by inventorytaking.BrandName into g
                         select new InventoryTakingViewModel {
                             Brand = g.Key,
                             Items = g.Select(s=> new InventoryTakingItem {  Quantity = s.Quantity, SkuItem = s.SKUItem.ItemName})
                         }).ToList();

            return items;
        }

    }
}


