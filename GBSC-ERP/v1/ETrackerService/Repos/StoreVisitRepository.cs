using System.Collections.Generic;
using eTrackerCore.Entities;
using eTrackerInfrastructure.Repos.Base;
using eTrackerInfrastructure.Repos.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using eTrackerInfrastructure.Models.JsonPostClasses;
using ErpCore.Entities.ETracker;
using ErpCore.Entities.InventorySetup;

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
                .Include(s=>s.Store)
                .Include(s=>s.CompetatorStocks)
                .Include(s=>s.Merchandisings)
                .Include(s=>s.OrderTakings)
                .Include(s=>s.OutletStocks)
                .FirstOrDefault(s => s.StoreVisitId == storevisitId);
        }

        public Store GetStoreByStoreVisitId(long storevisitid)
        {
            return Table.Include(s=>s.Store).FirstOrDefault(s=> s.StoreVisitId == storevisitid)?.Store;
        }

        public StoreVisit MostRecenetStoreVisit(long storeid)
        {
            return Table.Where(s => s.StoreId == storeid).OrderByDescending(s=>s.StoreVisitId).FirstOrDefault();
        }
    }
}
