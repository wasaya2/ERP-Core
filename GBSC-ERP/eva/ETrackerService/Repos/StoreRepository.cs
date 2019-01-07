using ErpCore.Entities;
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

        public IEnumerable<Store> GetStoresByRegionId(long regionid)
        {
            List<Store> Stores = new List<Store>();
            IList<City> cities = Db.Cities.Where(a => a.RegionId == regionid).ToList();
            foreach (City city in cities)
            {
                Stores.AddRange(GetStoresByCityId(city.CityId));
            }
            return Stores.OrderByDescending(a => a.StoreId);
        }

        public IEnumerable<Store> GetStoresByCityId(long cityId)
        {
            List<Store> Stores = new List<Store>();
            IList<Area> areas = Db.Areas.Where(a => a.CityId == cityId).ToList();
            foreach (Area area in areas)
            {
                Stores.AddRange(GetStoresByAreaId(area.AreaId));
            }
            return Stores.OrderByDescending(a => a.StoreId);
        }

        public IEnumerable<Store> GetStoresByAreaId(long areaId)
        {
            List<Store> Stores = new List<Store>();
            IList<Territory> territories = Db.Territories.Where(a => a.AreaId == areaId).ToList();
            foreach (Territory ter in territories)
            {
                Stores.AddRange(GetStoresByTerritoryId(ter.TerritoryId));
            }
            return Stores.OrderByDescending(a => a.StoreId);
        }

        public IEnumerable<Store> GetStoresByTerritoryId(long territoryId)
        {
            List<Store> Stores = new List<Store>();
            IList<Section> sections = Db.Sections.Where(a => a.TerritoryId == territoryId).ToList();
            foreach(Section sec in sections)
            {
                Stores.AddRange(GetStoresBySectionId(sec.SectionId));
            }
            return Stores.OrderByDescending(a => a.StoreId);
        }

        public IEnumerable<Store> GetStoresBySectionId(long sectionid)
        {
            List<Store> Stores = new List<Store>();

            IList<Subsection> subsections = Db.Subsections.Where(a => a.SectionId == sectionid).ToList();
            foreach(Subsection sub in subsections)
            {
                Stores.AddRange(Table.Where(a => a.SubsectionId == sub.SubsectionId).ToList());
            }
            return Stores.OrderByDescending(a => a.StoreId);
        }

        public IEnumerable<Store> GetStoresByUserId(long userid)
        {
            return Table.Where(a => a.UserId == userid).ToList().OrderByDescending(a => a.StoreId);
        }

        public IEnumerable<Store> GetStoreByUserId(long UserId)
        {
            User user = Db.Users.Where(a => a.UserId == UserId).FirstOrDefault();
            List<Store> Stores = new List<Store>();

            if (user.UserLevel.ToUpper() == "ADMIN")
            {
                return Table.Where(a => a.CompanyId != null && a.CompanyId == user.CompanyId).ToList().OrderByDescending(a => a.StoreId);
            }
            else if (user.UserLevel.ToUpper() == "NSM" || user.UserLevel.ToUpper() == "RSM" || user.UserLevel.ToUpper() == "HO")
            {
                foreach (Region region in Db.Regions.Where(a => a.UserId == UserId).ToList())
                {
                    Stores.AddRange(GetStoresByRegionId(region.RegionId));
                }
                return Stores;
            }
            else if (user.UserLevel.ToUpper() == "ZSM")
            {
                foreach (City city in Db.Cities.Where(a => a.UserId == UserId).ToList())
                {
                    Stores.AddRange(GetStoresByCityId(city.CityId));
                }
                return Stores;
            }
            else if (user.UserLevel.ToUpper() == "ASM")
            {
                foreach (Area area in Db.Areas.Where(a => a.UserId == UserId).ToList())
                {
                    Stores.AddRange(GetStoresByAreaId(area.AreaId));
                }
                return Stores;
            }
            else if (user.UserLevel.ToUpper() == "TSO" || user.UserLevel.ToUpper() == "KPO")
            {
                foreach (Territory territory in Db.Territories.Where(a => a.UserId == UserId).ToList())
                {
                    Stores.AddRange(GetStoresByTerritoryId(territory.TerritoryId));
                }
                return Stores;
            }
            else if (user.UserLevel.ToUpper() == "DSF")
            {  
                foreach(Section sec in Db.Sections.Where(a => a.UserId == UserId).ToList())
                {
                    Stores.AddRange(GetStoresBySectionId(sec.SectionId));
                }
                return Stores;
            }
            else
            {
                return null;
            }
        }
    }
}
