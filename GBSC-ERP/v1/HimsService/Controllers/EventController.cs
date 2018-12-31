using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities.HimsSetup;
using ErpCore.Filters;
using HimsService.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HimsService.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : Controller
    {
        private IEventRepository _repo;

        public EventController(IEventRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllEvents")]
        public IEnumerable<Event> GetAllEvents()
        {
            return _repo.GetAll();
        }

        [HttpGet("GetEvent/{id}")]
        public Event GetEvent(long id)
        {
            return _repo.Find(id);
        }

        [HttpPut("UpdateEvent")]
        [ValidateModel]
        public IActionResult UpdateEvent([FromBody]Event model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { EventId = model.EventId });
        }

        [HttpPost("AddEvent")]
        [ValidateModel]
        public IActionResult AddEvent([FromBody]Event model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { EventId = model.EventId });
        }

        [HttpDelete("DeleteEvent/{id}")]
        public void DeleteEvent(long id)
        {
            var Event = _repo.Find(id);

            _repo.Delete(Event);
        }
    }
}
