using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eTrackerInfrastructure.Repos.Interfaces;
using eTrackerCore.Entities;
using eTrackerInfrastructure.Filters;
using ErpCore.Entities.InventorySetup;

namespace eTrackerInfrastructure.Controllers
{
    [Route("api/[controller]")]
    public class DistributorController : Controller
    {
        private IDistributorRepository _repo;

        public DistributorController(IDistributorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetDistributors")]
        public IEnumerable<Distributor> GetDistributors()
        {
            var dist = _repo.GetAll();
            dist = dist.OrderByDescending(s => s.DistributorId);
            return dist;
        }

        [HttpPost("AddDistributor")]
        [ValidateModelAttribute]
        public IActionResult AddDistributor([FromBody]Distributor model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { Distributorid = model.DistributorId });
        }

        [HttpPost("UpdateDistributor")]
        [ValidateModelAttribute]
        public IActionResult UpdateDistributor([FromBody]Distributor model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { Distributorid = model.DistributorId });
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(long id)
        {
            var Distributor = _repo.Find(id);
            if (Distributor == null)
                return NotFound();

            _repo.Delete(Distributor);

            return Ok();
        }
    }
}