using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities.ETracker;
using ErpCore.Filters;
using ETrackerService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETrackerService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PJPController : Controller
    {
        private IPJPRepository _repo;

        public PJPController(IPJPRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetPJPs" , Name = "GetPJPs")]
        public IEnumerable<PJP> GetPJPs()
        {
            return _repo.GetAll().OrderByDescending(a => a.PjpId);
        }
        
        [HttpGet("GetPJP/{id}", Name = "GetPJP")]
        public PJP GetPJP(long id)
        {
            return _repo.GetFirst(a => a.PjpId == id);
        }
        
        [HttpPost("AddPJP" , Name = "AddPJP")]
        [ValidateModelAttribute]
        public IActionResult AddPJP([FromBody]PJP model)
        {
            _repo.Add(model);
            return new OkObjectResult(new { PjpId = model.PjpId });
        }
        
        [HttpPut("UpdatePJP", Name = "UpdatePJP")]
        [ValidateModelAttribute]
        public IActionResult UpdatePJP([FromBody]PJP model)
        {
            _repo.Update(model);
            return new OkObjectResult(new { PjpId = model.PjpId });
        }
        
        [HttpDelete("DeletePJP/{id}", Name = "DeletePJP")]
        public IActionResult Delete(long id)
        {
            PJP pjp = _repo.Find(id);
            if(pjp == null)
            {
                return BadRequest();
            }
            _repo.Delete(pjp);
            return Ok("Deleted");
        }
    }
}
