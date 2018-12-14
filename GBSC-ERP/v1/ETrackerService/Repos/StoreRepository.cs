using ErpCore.Entities.ETracker;
using ErpCore.Entities.InventorySetup;
using eTrackerCore.Entities.ViewModels;
using eTrackerInfrastructure.Models.JsonPostClasses;
using eTrackerInfrastructure.Repos.Base;
using eTrackerInfrastructure.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Repos
{
    public class StoreRepository : RepoBase<Store>, IStoreRepository
    {
        public Store GetStoreByIdWithChildren(long id) => Table.Include(s => s.StoreVisits).Include(s => s.User).ThenInclude(u => u.Distributor).FirstOrDefault(s => s.StoreId == id);

        public IList<Store> GetStoresBySubsection(long subsectionid) => Table.OrderByDescending(a => a.StoreId).Where(s => s.SubsectionId == subsectionid).ToList();

        public IList<StoreViewModel> GetStoresWithDistributors()
        {

            var innerJoinQuery = from s in Table
                                 join u in Db.Users on s.UserId equals u.UserId
                                 join d in Db.Distributors on u.DistributorId equals d.DistributorId
                                 join t in Db.Territories on d.TerritoryId equals t.TerritoryId
                                 orderby s.StoreId descending
                                 select new StoreViewModel
                                 {
                                     ShopName = s.ShopName,
                                     Address = s.Address,
                                     Cnic = s.Cnic,
                                     ContactNumber = s.ContactNo,
                                     Distributor = d.Name,
                                     Territory = t.Name,
                                     Landline = s.Landline,
                                     SalesPerson = u.FirstName+" "+u.LastName,
                                     Latitude = s.Latitude,
                                     Longitude = s.Longitude,
                                     ShopKeeper = s.ShopKeeper,
                                     StoreId = s.StoreId,
                                     StartTime = s.StartTime,
                                     EndTime = s.EndTime
                                 };

            var stores = innerJoinQuery.ToList();

            return stores;

        }

        public IEnumerable<Store> GetUserStores(long id) => Table.OrderByDescending(a => a.StoreId).Include(s => s.VisitDays).Where(s => s.UserId == id).ToList();

        public void AddStoreOrder(OrderTaking order)
        {
            var store = Table.Find(order.StoreId);
            if (store != null)
            {
                store.Orders.Add(order);
                Update(store);
            }
        }

        public void AddMultipleStoreOrders(Orders orders)
        {
            foreach (var order in orders.Order)
            {
                AddStoreOrder(order);
            }
        }

        public IEnumerable<StoreViewModel> GetStoresForAccountRegistration(long id)
        {
            var stores = Table.Where(st => st.UserId == id).Select(t => new StoreViewModel
            {
                Address = t.Address,
                Cnic = t.Cnic,
                ContactNumber = t.ContactNo,
                StartTime = t.StartTime,
                EndTime = t.EndTime,
                Latitude = t.Latitude,
                Longitude = t.Longitude,
                ShopKeeper = t.ShopKeeper,
                ShopName = t.ShopName,
                Landline = t.Landline,
                StoreId = t.StoreId
            });

            return stores;
        }
    }
}
