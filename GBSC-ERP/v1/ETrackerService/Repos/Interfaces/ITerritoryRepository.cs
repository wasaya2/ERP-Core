using ErpCore.Entities;
using ErpCore.Entities.InventorySetup;
using eTrackerCore.Entities;
using eTrackerInfrastructure.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Repos.Interfaces
{
    public interface ITerritoryRepository : IRepo<Territory>
    {
        IList<Region> GetRegions();

        IList<Area> GetAreasByCity(long cityid);

        IList<Territory> GetTerritoriesByArea(long areaid);

        IList<Territory> GetTerritoriesWithArea();

        IList<User> GetUsersByDistributor(long Distributorid);

        long? GetSectionIdByUser(long userid);

        IList<Section> GetSectionsByTerritoryId(long territoryid);

        IList<Subsection> GetSubsectionsBySectionId(long sectionid);

        IList<Subsection> GetSubsectionsByDistributorId(long Distributorid);

        IList<Section> GetSections();

        IList<Section> GetSectionsByDistributor(long Distributorid);

        IList<Section> GetUnassignedSectionsByDistributor(long Distributorid);

        IList<Subsection> GetSubsections();

        IList<Subsection> GetSubsectionsByUserId(long userid);

        IList<Area> GetAreas();

        void AddRegion(Region model);

        void AddArea(Area model);

        void AddTerritory(Territory territory);

        void AddSection(Section model);

        void AddSubsection(Subsection model);

        void UpdateRegion(Region model);

        void UpdateArea(Area model);

        void UpdateTerritory(Territory model);

        void UpdateSection(Section model);

        void UpdateSubsection(Subsection model);

        void DeleteRegion(long id);

        void DeleteArea(long id);

        void DeleteSection(long id);

        void DeleteSubsection(long id);
    }
}
