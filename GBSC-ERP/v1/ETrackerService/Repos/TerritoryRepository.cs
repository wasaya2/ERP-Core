using ErpCore.Entities;
using ErpCore.Entities.InventorySetup;
using eTrackerCore.Entities;
using eTrackerInfrastructure.Repos.Base;
using eTrackerInfrastructure.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Repos
{
    public class TerritoryRepository : RepoBase<Territory>, ITerritoryRepository
    {
        public void AddArea(Area model)
        {
            Context.Areas.Add(model);
            SaveChanges();

        }

        public void AddRegion(Region model)
        {
            Context.Regions.Add(model);
            SaveChanges();
        }

        public void AddSection(Section model)
        {
            Context.Sections.Add(model);
            SaveChanges();
        }

        public void AddSubsection(Subsection model)
        {
            Context.Subsections.Add(model);
            SaveChanges();
        }

        public void AddTerritory(Territory territory) => Table.Add(territory);

        public IList<Area> GetAreas() => Context.Areas.OrderByDescending(a=>a.AreaId).Include(t=>t.City).ToList();

        public IList<Area> GetAreasByCity(long cityid) => Context.Areas.OrderByDescending(a => a.AreaId).Where(a => a.CityId == cityid).ToList();

        public IList<Region> GetRegions() => Context.Regions.OrderByDescending(a => a.RegionId).ToList();

        public IList<Section> GetSections() => Context.Sections.OrderByDescending(a => a.SectionId).Include(s=>s.Territory).ThenInclude(s=>s.Area).ToList();

        public IList<User> GetUsersBySection(long sectionid) => Context.Users.Where(a => a.SectionId == sectionid).OrderByDescending(a => a.UserId).ToList();

        public IList<Subsection> GetSubsections() => Context.Subsections.OrderByDescending(a => a.SubsectionId).Include(s=>s.Section).ThenInclude(s=>s.Territory).ThenInclude(s=>s.Area).ToList();

        public IList<Section> GetSectionsByTerritoryId(long territoryid) => Context.Sections.OrderByDescending(a => a.SectionId).Where(t => t.TerritoryId == territoryid).ToList();

        public IList<Subsection> GetSubsectionsBySectionId(long sectionid) => Context.Subsections.OrderByDescending(a => a.SubsectionId).Where(s => s.SectionId == sectionid).ToList();

        public IList<Subsection> GetSubsectionsByDistributorId(long Distributorid)
        {
            return Context.Subsections.OrderByDescending(a => a.SubsectionId).Where(s => s.Section.Territory.Distributor.DistributorId == Distributorid).ToList();
        }

        public IList<Subsection> GetSubsectionsByUserId(long userid)
        {
            return Context.Subsections.OrderByDescending(a => a.SubsectionId).Where(s => s.UserId == userid).ToList();
        }

        public IList<Territory> GetTerritoriesByArea(long areaid) => Table.OrderByDescending(a => a.TerritoryId).Where(t => t.AreaId == areaid).ToList();

        public IList<Territory> GetTerritoriesWithArea() => Table.OrderByDescending(a => a.TerritoryId).Include(t => t.Area).ThenInclude(a=>a.City).ToList();

        public long? GetSectionIdByUser(long userid) => Context.Users.FirstOrDefault(s => s.UserId == userid)?.SectionId;

        public void UpdateArea(Area model)
        {
            Context.Areas.Update(model);
            SaveChanges();
        }

        public void UpdateRegion(Region model)
        {
            Context.Regions.Update(model);
            SaveChanges();
        }

        public void UpdateCity(City model)
        {
            Context.Cities.Update(model);
            SaveChanges();
        }

        public void UpdateSection(Section model)
        {
            Context.Sections.Update(model);
            SaveChanges();
        }

        public void UpdateSubsection(Subsection model)
        {
            var subsection = Context.Subsections.Find(model.SubsectionId);

            subsection.Name = model.Name;
            subsection.SectionId = model.SectionId;
            subsection.UserId = model.UserId;

            Context.Subsections.Update(subsection);
            Context.SaveChanges();

        }

        public IList<Section> GetSectionsByDistributor(long Distributorid) => Context.Sections.OrderByDescending(a => a.SectionId).Where(s => s.Territory.Distributor.DistributorId == Distributorid).ToList();

        public IList<Section> GetUnassignedSectionsByDistributor(long Distributorid) => Context.Sections.OrderByDescending(a => a.SectionId).Where(s => s.Territory.Distributor.DistributorId == Distributorid && s.User == null).ToList();

        public void DeleteRegion(long id)
        {
            var region = Context.Regions.Find(id);
            Context.Regions.Remove(region);
            Context.SaveChanges();
        }

        public void DeleteArea(long id)
        {
            var area = Context.Areas.Find(id);
            Context.Areas.Remove(area);
            Context.SaveChanges();
        }

        public void DeleteSection(long id)
        {
            var section = Context.Sections.Find(id);
            Context.Sections.Remove(section);
            Context.SaveChanges();
        }

        public void DeleteSubsection(long id)
        {
            var subsection = Context.Subsections.Find(id);
            Context.Subsections.Remove(subsection);
            Context.SaveChanges();
        }

        public Region FindRegion(long RegionId)
        {
            return Context.Regions.Find(RegionId);
        }

        public City FindCity(long CityId)
        {
            return Context.Cities.Find(CityId);
        }

        public Area FindArea(long AreaId)
        {
            return Context.Areas.Find(AreaId);
        }

        public Section FindSection(long SectionId)
        {
            return Context.Sections.Find(SectionId);
        }

        public IList<Region> GetRegionsByUser(long userid)
        {
            return Context.Regions.Where(u => u.UserId == userid).ToList();
        }

        public IList<City> GetCitiesByUser(long userid)
        {
            return Context.Cities.Where(u => u.UserId == userid).ToList();
        }

        public IList<Area> GetAreasByUser(long userid)
        {
            return Context.Areas.Where(u => u.UserId == userid).ToList();
        }

        public IList<Territory> GetTerritoriesByUser(long userid)
        {
            return Context.Territories.Where(u => u.UserId == userid).ToList();
        }

        //

        public Region GetRegionByCity(long cityid)
        {
           return Context.Cities.Where(a => a.CityId == cityid).Include(a => a.Region).FirstOrDefault().Region;
        }

        public City GetCityByArea(long areaid)
        {
            return Context.Areas.Where(a => a.AreaId == areaid).Include(a => a.City).FirstOrDefault().City;
        }

        public IEnumerable<City> GetCitiesByUserAndRegion(long regionid, long userid)
        {
            return Context.Cities.Where(a => a.UserId == userid && a.RegionId == regionid).ToList().OrderByDescending(a => a.CityId);
        }

        public IEnumerable<City> GetCitiesByRegion(long regionid)
        {
            return Context.Cities.Where(a => a.RegionId == regionid).ToList().OrderByDescending(a => a.CityId);
        }

        public IEnumerable<Area> GetAreasByUserAndCity(long cityid, long userid)
        {
            return Context.Areas.Where(a => a.UserId == userid && a.CityId == cityid).ToList().OrderByDescending(a => a.AreaId);
        }

        public IEnumerable<Distributor> GetDistributorsByUserAndArea(long areaid, long userid)
        {
            IList<Distributor> Distributors = new List<Distributor>();
            IEnumerable<Territory> territories = Context.Territories.Where(a => a.AreaId == areaid && a.UserId == userid).Include(a => a.Distributor).ToList().OrderByDescending(a => a.DistributorId);
            foreach(Territory territory in territories)
            {
                Distributors.Add(territory.Distributor);
            }

            return Distributors;
        }

        public IEnumerable<Distributor> GetDistributorsByArea(long areaid)
        {
            IList<Distributor> Distributors = new List<Distributor>();
            IEnumerable<Territory> territories = Context.Territories.Where(a => a.AreaId == areaid).Include(a => a.Distributor).ToList().OrderByDescending(a => a.DistributorId);
            foreach (Territory territory in territories)
            {
                Distributors.Add(territory.Distributor);
            }

            return Distributors;
        }

        public IEnumerable<Territory> GetTerritoriesByUserAndDistributor(long distributorid, long userid)
        {
            return Context.Territories.Where(a => a.DistributorId == distributorid && a.UserId == userid).ToList().OrderByDescending(a => a.TerritoryId);
        }

        public IEnumerable<Territory> GetTerritoriesByDistributor(long distributorid)
        {
            return Context.Territories.Where(a => a.DistributorId == distributorid).ToList().OrderByDescending(a => a.TerritoryId);
        }

        public IEnumerable<Section> GetSectionsByUserAndTerritory(long territoryid, long userid)
        {
            return Context.Sections.Where(a => a.TerritoryId == territoryid && a.UserId == userid).ToList().OrderByDescending(a => a.SectionId);
        }

        public IEnumerable<Section> GetSectionsByTerritory(long territoryid)
        {
            return Context.Sections.Where(a => a.TerritoryId == territoryid).ToList().OrderByDescending(a => a.SectionId);
        }
    }
}
