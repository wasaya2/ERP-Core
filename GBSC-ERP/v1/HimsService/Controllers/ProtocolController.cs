using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities.HimsSetup;
using ErpCore.Filters;
using HimsService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HimsService.Controllers
{
    [Produces("application/json")]
    [Route("api/Protocol")]
    public class ProtocolController : Controller
    {
        private IProtocolRepository _repo;

        public ProtocolController(IProtocolRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllProtocols")]
        public IEnumerable<Protocol> GetAllProtocols()
        {
            return _repo.GetAll();
        }

        [HttpGet("GetProtocol/{id}")]
        public Protocol GetProtocol(long id)
        {
            return _repo.Find(id);
        }

        [HttpPut("UpdateProtocol")]
        [ValidateModel]
        public IActionResult UpdateProtocol([FromBody]Protocol model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { ProtocolId = model.ProtocolId });
        }

        [HttpPost("AddProtocol")]
        [ValidateModel]
        public IActionResult AddProtocol([FromBody]Protocol model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { ProtocolId = model.ProtocolId });
        }

        [HttpDelete("DeleteProtocol/{id}")]
        public void DeleteProtocol(long id)
        {
            var Protocol = _repo.Find(id);

            _repo.Delete(Protocol);
        }
    }
}
