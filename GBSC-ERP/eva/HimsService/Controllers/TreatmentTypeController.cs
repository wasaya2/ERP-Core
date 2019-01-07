using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities.HimsSetup;
using ErpCore.Filters;
using HimsService.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HimsService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class TreatmentTypeController : Controller
    {
        private ITreatmentTypeRepository _repo;

        public TreatmentTypeController(ITreatmentTypeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllTreatmentTypes")]
        public IEnumerable<TreatmentType> GetAllTreatmentTypes()
        {
            return _repo.GetAll();
        }

        [HttpGet("GetTreatmentType/{id}")]
        public TreatmentType GetTreatmentType(long id)
        {
            return _repo.Find(id);
        }

        [HttpPut("UpdateTreatmentType")]
        [ValidateModel]
        public IActionResult UpdateTreatmentType([FromBody]TreatmentType model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { TreatmentTypeId = model.TreatmentTypeId });
        }

        [HttpPost("AddTreatmentType")]
        [ValidateModel]
        public IActionResult AddTreatmentType([FromBody]TreatmentType model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { TreatmentTypeId = model.TreatmentTypeId });
        }

        [HttpDelete("DeleteTreatmentType/{id}")]
        public void DeleteTreatmentType(long id)
        {
            var treatmentType = _repo.Find(id);

            _repo.Delete(treatmentType);
        }
    }
}