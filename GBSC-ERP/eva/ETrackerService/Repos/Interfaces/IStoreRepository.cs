using ErpCore.Entities;
using ErpCore.Entities.ETracker;
using ErpCore.Entities.InventorySetup;
using eTrackerCore.Entities;
using eTrackerCore.Entities.ViewModels;
using eTrackerInfrastructure.Models.JsonPostClasses;
using eTrackerInfrastructure.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Repos.Interfaces
{
    public interface IStoreRepository : IRepo<Store>
    {
        IEnumerable<Store> GetUserStores(long id);

        IEnumerable<StoreViewModel> GetStoresForAccountRegistration(long id);

        IList<StoreViewModel> GetStoresWithChildren(long CompanyId);

        IList<StoreViewModel> GetStoresWithChildren();

        IList<Store> GetStoresBySubsection(long subsectionid);

        Store GetStoreByIdWithChildren(long id);

        void AddStoreOrder(OrderTaking order);

        void AddMultipleStoreOrders(Orders orders);

        IEnumerable<Store> GetStoresByRegionId(long regionid);

        IEnumerable<Store> GetStoresByCityId(long cityId);

        IEnumerable<Store> GetStoresByAreaId(long areaId);

        IEnumerable<Store> GetStoresByTerritoryId(long territoryId);

        IEnumerable<Store> GetStoresBySectionId(long sectionid);

        IEnumerable<Store> GetStoresByUserId(long userid);

        IEnumerable<Store> GetStoreByUserId(long UserId);
    }
}
