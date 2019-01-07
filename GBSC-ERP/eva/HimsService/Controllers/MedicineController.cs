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
    public class MedicineController : Controller
    {
        private IMedicineRepository _repo;

        public MedicineController(IMedicineRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllMedicines")]
        public IEnumerable<Medicine> GetAllMedicines()
        {
            return _repo.GetAll();
        }

        [HttpGet("GetMedicine/{id}")]
        public Medicine GetMedicine(long id)
        {
            return _repo.Find(id);
        }

        [HttpPut("UpdateMedicine")]
        [ValidateModel]
        public IActionResult UpdateMedicine([FromBody]Medicine model)
        {
            _repo.Update(model);

            return new OkObjectResult(new { MedicineId = model.MedicineId });
        }

        [HttpPost("AddMedicine")]
        [ValidateModel]
        public IActionResult AddMedicine([FromBody]Medicine model)
        {
            _repo.Add(model);

            return new OkObjectResult(new { MedicineId = model.MedicineId });
        }

        [HttpDelete("DeleteMedicine/{id}")]
        public void DeleteMedicine(long id)
        {
            var Medicine = _repo.Find(id);

            _repo.Delete(Medicine);
        }
    }
}