using ErpCore.Entities.ETracker;
using ErpCore.Entities.InventorySetup;
using eTrackerCore.Entities;
using eTrackerInfrastructure.Models.JsonPostClasses;
using eTrackerInfrastructure.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Repos.Interfaces
{
    public interface IStoreVisitRepository : IRepo<StoreVisit>
    {
        
        void AddOrder(OrderTaking order);

        void AddMultipleOrders(Orders orders);

        void AddMerchendize(Merchandising merch);

        void AddOutletStock(OutletStock stock);

        void AddMultipleStockItems(Stocks stocks);

        void AddCompetativeStock(CompetatorStock competativestock);

        void AddMultipleCompetativeStock(CompetativeStocks competativestocks);

        void UpdateStock(OutletStock stock);


        IEnumerable<StoreVisit> GetVisitsByStoreId(long id);

        IEnumerable<OutletStock> GetOutletStocks(long storeVisitId);

        IEnumerable<OrderTaking> GetOrders(long storeVisitId);

        IEnumerable<CompetatorStock> CompetativeStocks(long storeVisitId);

        IEnumerable<Merchandising> GetMerchendiseList(long storeVisitId);

        StoreVisit GetStoreVisitWithStore(long storevisitId);

        StoreVisit MostRecenetStoreVisit(long storeid);

        Store GetStoreByStoreVisitId(long storevisitid);

        OutletStock GetStockItemById(long OutletStockId);
    }
}
