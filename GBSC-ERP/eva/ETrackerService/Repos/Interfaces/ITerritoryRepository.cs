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

        Region FindRegion(long RegionId);

        City FindCity(long CityId);

        Area FindArea(long AreaId);

        Section FindSection(long SectionId);

        IList<Area> GetAreasByCity(long cityid);

        IList<Region> GetRegionsByUser(long userid);

        IList<City> GetCitiesByUser(long userid);

        IList<Area> GetAreasByUser(long userid);

        IList<Territory> GetTerritoriesByArea(long areaid);

        IList<Territory> GetTerritoriesByUser(long userid);

        IList<Territory> GetTerritoriesWithArea();

        long? GetSectionIdByUser(long userid);

        IList<User> GetUsersBySection(long sectionid);

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

        void UpdateSection(Section model);

        void UpdateCity(City model);

        void UpdateSubsection(Subsection model);

        void DeleteRegion(long id);

        void DeleteArea(long id);

        void DeleteSection(long id);

        void DeleteSubsection(long id);

        //

        Region GetRegionByCity(long cityid);

        City GetCityByArea(long areaid);

        IEnumerable<City> GetCitiesByUserAndRegion(long regionid, long userid);

        IEnumerable<Area> GetAreasByUserAndCity(long cityid, long userid);

        IEnumerable<Distributor> GetDistributorsByUserAndArea(long areaid, long userid);

        IEnumerable<Territory> GetTerritoriesByUserAndDistributor(long distributorid, long userid);

        IEnumerable<Section> GetSectionsByUserAndTerritory(long territoryid, long userid);

        IEnumerable<City> GetCitiesByRegion(long regionid);

        IEnumerable<Distributor> GetDistributorsByArea(long areaid);

        IEnumerable<Territory> GetTerritoriesByDistributor(long distributorid);

        IEnumerable<Section> GetSectionsByTerritory(long territoryid);
    }
}
