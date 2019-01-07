using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eTrackerInfrastructure.Repos.Interfaces;
using eTrackerCore.Entities;
using eTrackerInfrastructure.Filters;
using ErpCore.Entities.InventorySetup;
using ETrackerService.ViewModels;
using ErpCore.Entities;

namespace eTrackerInfrastructure.Controllers
{
    [Route("api/[controller]")]
    public class TerritoryController : Controller
    {
        private ITerritoryRepository _repo;

        public TerritoryController(ITerritoryRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetTerritories")]
        public IEnumerable<Territory> GetTerritories() => _repo.GetAll();

        [HttpGet("GetTerritoriesWithArea")]
        public IEnumerable<Territory> GetTerritoriesWithArea() => _repo.GetTerritoriesWithArea();

        [HttpGet("GetRegions")]
        public IEnumerable<Region> GetRegions() => _repo.GetRegions();

        [HttpGet("GetAreas")]
        public IEnumerable<Area> GetAreas() => _repo.GetAreas();

        [HttpGet("GetAreasByCity/{cityid}")]
        public IEnumerable<Area> GetAreasByCity(long cityid) => _repo.GetAreasByCity(cityid);

        [HttpGet("GetSections")]
        public IEnumerable<Section> GetSections() => _repo.GetSections();

        [HttpGet("GetUsersBySection/{sectionid}")]
        public IEnumerable<User> GetUsersBySection([FromRoute]long sectionid)
        {
            return _repo.GetUsersBySection(sectionid);
        }

        [HttpGet("GetSectionsByDistributor/{Distributorid}")]
        public IEnumerable<Section> GetSections(long Distributorid) => _repo.GetSectionsByDistributor(Distributorid);

        [HttpGet("GetUnassignedSectionsByDistributor/{Distributorid}")]
        public IEnumerable<Section> GetUnassignedSectionsByDistributor(long Distributorid) => _repo.GetUnassignedSectionsByDistributor(Distributorid);

        [HttpGet("GetSubsectionsByUser/{userid}")]
        public IEnumerable<Subsection> GetSubsectionsByUser(long userid) => _repo.GetSubsectionsByUserId(userid);

        [HttpGet("GetSubsections")]
        public IEnumerable<Subsection> GetSubsections() => _repo.GetSubsections();

        [HttpGet("GetSubsectionsByDistributor/{Distributorid}")]
        public IEnumerable<Subsection> GetSubsections(long Distributorid) => _repo.GetSubsectionsByDistributorId(Distributorid);

        [HttpGet("GetSubsectionsBySection/{sectionid}")]
        public IEnumerable<Subsection> GetSubsectionsBySection(long sectionid) => _repo.GetSubsectionsBySectionId(sectionid);

        [HttpGet("GetAssignedSubsectionsBySection/{sectionid}/{userid}")]
        public IEnumerable<AssignedSubsectionsViewModel> GetAssignedSubsectionsBySection(long sectionid, long userid)
        {
            var subsections = _repo.GetSubsectionsBySectionId(sectionid)
                .Select(s => new AssignedSubsectionsViewModel
                {
                    SubsectionId = s.SubsectionId,
                    Name = s.Name,
                    IsAssigned = false,
                    UserId = s.UserId ?? 0
                }).ToList();

            for (int i = 0; i < subsections.Count(); i++)
            {
                if (subsections[i].UserId == userid)
                    subsections[i].IsAssigned = true;
            }

            return subsections;
        }

        [HttpGet("GetRegionsByUser/{id}")]
        public IEnumerable<Region> GetRegionsByUser(long id) => _repo.GetRegionsByUser(id);

        [HttpGet("GetCitiesByUser/{id}")]
        public IEnumerable<City> GetCitiesByUser(long id) => _repo.GetCitiesByUser(id);

        [HttpGet("GetAreasByUser/{id}")]
        public IEnumerable<Area> GetAreasByUser(long id) => _repo.GetAreasByUser(id);

        [HttpGet("GetTerritoriesByUser/{id}")]
        public IEnumerable<Territory> GetTerritoriesByUser(long id) => _repo.GetTerritoriesByUser(id);

        [HttpGet("GetSectionIdByUser/{userid}")]
        public long? GetSectionIdByUser(long userid) => _repo.GetSectionIdByUser(userid);

        [HttpGet("GetSectionsByTerritory/{id}")]
        public IEnumerable<Section> GetSectionsByTerritory(long id) => _repo.GetSectionsByTerritoryId(id);

        [HttpPost("AddTerritory")]
        [ValidateModelAttribute]
        public IActionResult AddTerritory([FromBody]Territory model)
        {
            _repo.Add(model);
            return new OkObjectResult(new { territoryid = model.TerritoryId });
        }

        [HttpPost("AddRegion")]
        [ValidateModelAttribute]
        public IActionResult AddRegion([FromBody]Region model)
        {
            _repo.AddRegion(model);
            return new OkObjectResult(new { regionid = model.RegionId });
        }

        [HttpPost("AddSection")]
        [ValidateModelAttribute]
        public IActionResult AddSection([FromBody]Section model)
        {
            _repo.AddSection(model);
            return new OkObjectResult(new { sectionid = model.SectionId });
        }

        [HttpPost("AddSubsection")]
        [ValidateModelAttribute]
        public IActionResult AddSubsection([FromBody]Subsection model)
        {
            _repo.AddSubsection(model);
            return new OkObjectResult(new { subsectionsectionid = model.SubsectionId });
        }

        [HttpPost("AddArea")]
        [ValidateModelAttribute]
        public IActionResult AddArea([FromBody]Area model)
        {
            _repo.AddArea(model);
            return new OkObjectResult(new { areaid = model.AreaId });
        }

        [HttpPost("UpdateTerritory")]
        [ValidateModelAttribute]
        public IActionResult UpdateTerritory([FromBody]Territory model)
        {
            _repo.Update(model);
            return new OkObjectResult(new { territoryid = model.TerritoryId });
        }

        [HttpPost("UpdateRegion")]
        [ValidateModelAttribute]
        public IActionResult UpdateRegion([FromBody]Region model)
        {
            _repo.UpdateRegion(model);
            return new OkObjectResult(new { regionid = model.RegionId });
        }

        [HttpPost("UpdateSection")]
        [ValidateModelAttribute]
        public IActionResult UpdateSection([FromBody]Section model)
        {
            _repo.UpdateSection(model);
            return new OkObjectResult(new { sectionid = model.SectionId });
        }

        [HttpPost("UpdateSubsection")]
        [ValidateModelAttribute]
        public IActionResult UpdateSubsection([FromBody]Subsection model)
        {
            _repo.UpdateSubsection(model);
            return new OkObjectResult(new { subsectionid = model.SubsectionId });
        }

        [HttpPost("UpdateArea")]
        [ValidateModelAttribute]
        public IActionResult UpdateArea([FromBody]Area model)
        {
            _repo.UpdateArea(model);
            return new OkObjectResult(new { areaid = model.AreaId });
        }

        [HttpDelete("DeleteTerritory/{id}")]
        public IActionResult DeleteTerritory(long id)
        {
            var territory = _repo.Find(id);
            if (territory == null)
                return new NotFoundObjectResult(new { result = "Object with the given id does not exist" });

            _repo.Delete(territory);

            return new OkObjectResult(new { status = "Object deleted" });
        }

        [HttpDelete("DeleteRegion/{id}")]
        public IActionResult DeleteRegion(long id)
        {
            _repo.DeleteRegion(id);

            return Ok();
        }

        [HttpDelete("DeleteArea/{id}")]
        public IActionResult DeleteArea(long id)
        {
            _repo.DeleteArea(id);

            return Ok();
        }

        [HttpDelete("DeleteSection/{id}")]
        public IActionResult DeleteSection(long id)
        {
            _repo.DeleteSection(id);

            return Ok();
        }

        [HttpDelete("DeleteSubsection/{id}")]
        public IActionResult DeleteSubsection(long id)
        {
            _repo.DeleteSubsection(id);

            return Ok();
        }

        [HttpGet("GetRegionByCity/{cityid}")]
        public Region GetRegionByCity([FromRoute]long cityid)
        {
            return _repo.GetRegionByCity(cityid);
        }

        [HttpGet("GetCityByArea/{areaid}")]
        public City GetCityByArea([FromRoute]long areaid)
        {
            return _repo.GetCityByArea(areaid);
        }

        [HttpGet("GetCitiesByUserAndRegion/{regionid}/{userid}")]
        public IEnumerable<City> GetCitiesByUserAndRegion([FromRoute]long regionid, [FromRoute]long userid)
        {
            return _repo.GetCitiesByUserAndRegion(regionid, userid);
        }

        [HttpGet("GetCitiesByRegion/{regionid}")]
        public IEnumerable<City> GetCitiesByRegion([FromRoute]long regionid)
        {
            return _repo.GetCitiesByRegion(regionid);
        }

        [HttpGet("GetAreasByUserAndCity/{cityid}/{userid}")]
        public IEnumerable<Area> GetAreasByUserAndCity([FromRoute]long cityid, [FromRoute]long userid)
        {
            return _repo.GetAreasByUserAndCity(cityid, userid);
        }

        [HttpGet("GetDistributorsByUserAndArea/{areaid}/{userid}")]
        public IEnumerable<Distributor> GetDistributorsByUserAndArea([FromRoute]long areaid, [FromRoute]long userid)
        {
            return _repo.GetDistributorsByUserAndArea(areaid, userid);
        }

        [HttpGet("GetDistributorsByArea/{areaid}")]
        public IEnumerable<Distributor> GetDistributorsByArea([FromRoute]long areaid)
        {
            return _repo.GetDistributorsByArea(areaid);
        }

        [HttpGet("GetTerritoriesByUserAndDistributor/{distributorid}/{userid}")]
        public IEnumerable<Territory> GetTerritoriesByUserAndDistributor([FromRoute]long distributorid, [FromRoute]long userid)
        {
            return _repo.GetTerritoriesByUserAndDistributor(distributorid, userid);
        }

        [HttpGet("GetTerritoriesByDistributor/{distributorid}")]
        public IEnumerable<Territory> GetTerritoriesByDistributor([FromRoute]long distributorid)
        {
            return _repo.GetTerritoriesByDistributor(distributorid);
        }

        [HttpGet("GetSectionsByUserAndTerritory/{territoryid}/{userid}")]
        public IEnumerable<Section> GetSectionsByUserAndTerritory([FromRoute]long territoryid, [FromRoute]long userid)
        {
            return _repo.GetSectionsByUserAndTerritory(territoryid, userid);
        }
    }
}