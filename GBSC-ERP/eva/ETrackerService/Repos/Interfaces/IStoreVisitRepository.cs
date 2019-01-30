using ErpCore.Entities.ETracker;
using ErpCore.Entities.InventorySetup;
using eTrackerCore.Entities;
using eTrackerInfrastructure.Models.JsonPostClasses;
using eTrackerInfrastructure.Repos.Base;
using ETrackerService.ViewModels;
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

        void AddInventoryTaking(InventoryTaking inventory);

        void AddMultipleInventoryTakings(InventoryTakings inventory);

        void AddMerchendize(Merchandising merch);

        void AddOutletStock(OutletStock stock);

        void AddMultipleStockItems(Stocks stocks);

        void AddCompetativeStock(CompetatorStock competativestock);

        void AddMultipleCompetativeStock(CompetativeStocks competativestocks);

        void UpdateStock(OutletStock stock);

        string GetNoOrderReason(long StoreVisitId);

        IEnumerable<GroupedItems> GetVisitOrders(long StoreVisitId);
    
        IEnumerable<InventoryTakingViewModel> GetVisitInventories(long StoreVisitId);

        IEnumerable<StoreVisit> GetVisitsByStoreId(long id);

        IEnumerable<OutletStock> GetOutletStocks(long storeVisitId);

        IEnumerable<OrderTaking> GetOrders(long storeVisitId);

        IEnumerable<CompetatorStock> CompetativeStocks(long storeVisitId);

        IEnumerable<Merchandising> GetMerchendiseList(long storeVisitId);

        IEnumerable<LastTwoVisits> GetLastTwoVisits(long StoreId);

        StoreVisit GetStoreVisitWithStore(long storevisitId);

        StoreVisit MostRecenetStoreVisit(long storeid);

        Store GetStoreByStoreVisitId(long storevisitid);

        OutletStock GetStockItemById(long OutletStockId);
    }
}
