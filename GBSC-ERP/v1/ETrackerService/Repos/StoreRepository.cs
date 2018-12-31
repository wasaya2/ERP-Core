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
        public Store GetStoreByIdWithChildren(long id) => Table.Include(s => s.StoreVisits).Include(s => s.User).FirstOrDefault(s => s.StoreId == id);

        public IList<Store> GetStoresBySubsection(long subsectionid) => Table.OrderByDescending(a => a.StoreId).Where(s => s.SubsectionId == subsectionid).ToList();

        public IList<StoreViewModel> GetStoresWithChildren()
        {
            return GetAll(s => s.Subsection, s => s.Subsection.Section, u => u.User)
                                        .OrderByDescending(s => s.StoreId)
                                        .Select(s => new StoreViewModel
                                        {
                                            ShopName = s.ShopName,
                                            Address = s.Address,
                                            Cnic = s.Cnic,
                                            ContactNumber = s.ContactNo,
                                            Section = s.Subsection?.Section?.Name,
                                            Subsection = s.Subsection?.Name,
                                            Landline = s.Landline,
                                            SalesPerson = s.User?.FirstName + " " + s.User?.LastName,
                                            Latitude = s.Latitude,
                                            Longitude = s.Longitude,
                                            ShopKeeper = s.ShopKeeper,
                                            StoreId = s.StoreId,
                                            StartTime = s.StartTime,
                                            EndTime = s.EndTime
                                        }).ToList();

        }

        public IList<StoreViewModel> GetStoresWithChildren(long CompanyId)
        {

            return GetList(s => s.CompanyId == CompanyId, s => s.Subsection, s => s.Subsection.Section, u => u.User)
                                        .OrderByDescending(s => s.StoreId)
                                        .Select(s => new StoreViewModel
                                        {
                                            ShopName = s.ShopName,
                                            Address = s.Address,
                                            Cnic = s.Cnic,
                                            ContactNumber = s.ContactNo,
                                            Section = s.Subsection?.Section?.Name,
                                            Subsection = s.Subsection?.Name,
                                            Landline = s.Landline,
                                            SalesPerson = s.User?.FirstName + " " + s.User?.LastName,
                                            Latitude = s.Latitude,
                                            Longitude = s.Longitude,
                                            ShopKeeper = s.ShopKeeper,
                                            StoreId = s.StoreId,
                                            StartTime = s.StartTime,
                                            EndTime = s.EndTime
                                        }).ToList();

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
