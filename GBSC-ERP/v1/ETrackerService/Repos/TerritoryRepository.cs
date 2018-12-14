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

        public IList<User> GetUsersByDistributor(long Distributorid) => Context.Users.OrderByDescending(a => a.UserId).Where(u => u.DistributorId == Distributorid).ToList();

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

        public void UpdateTerritory(Territory model)
        {
            Context.Territories.Update(model);
            SaveChanges();
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
    }
}
