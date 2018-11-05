using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErpCore.Entities;
using ErpInfrastructure.Data;
using HimsService.Repos.Interfaces;
using System.Text.RegularExpressions;
using ErpCore.Filters;

namespace HimsService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PatientInvoicesController : Controller
    {
        private IPatientInvoiceRepository _repo;
        private IPatientInvoiceItemRepository item_repo;

        public PatientInvoicesController(IPatientInvoiceRepository repo, IPatientInvoiceItemRepository itemrepo)
        {
            _repo = repo;
            item_repo = itemrepo;
        }

        [HttpGet("GetPatientInvoicePermissions/{userid}/{roleid}/{featureid}", Name = "GetPatientInvoicePermissions")]
        public IEnumerable<Permission> GetPatientInvoicePermissions(long userid, long roleid, long featureid)
        {
            IEnumerable<Permission> per = _repo.GetFeaturePermissions(userid, roleid, featureid).Permissions.ToList();
            return per;
        }

        #region Patient Invoice
        [HttpGet("GetPatientInvoices", Name = "GetPatientInvoices")]
        public IEnumerable<PatientInvoice> GetPatientInvoices()
        {
            IEnumerable<PatientInvoice> pi = _repo.GetAll();
            pi = pi.OrderByDescending(a => a.PatientInvoiceId);
            return pi;
        }

        [HttpGet("GetPatientInvoice/{id}", Name = "GetPatientInvoice")]
        public PatientInvoice GetPatientInvoice(long id) => _repo.GetFirst(a => a.PatientInvoiceId == id);

        [HttpPut("UpdatePatientInvoice", Name = "UpdatePatientInvoice")]
        [ValidateModelAttribute]
        public IActionResult UpdatePatientInvoice([FromBody]PatientInvoice model)
        {
            _repo.Update(model);
            return new OkObjectResult(new { PatientInvoiceID = model.PatientInvoiceId });
        }

        private string GenPSN()
        {
            try
            {
                PatientInvoice lastPatientInvoice = _repo.GetLast();
                string value = lastPatientInvoice.SlipNumber;
                string number = Regex.Match(value, "[0-9]+$").Value;

                return value.Substring(0, value.Length - number.Length) +
                       (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(ArgumentNullException)
            {
                return "PSN0000000001";
            }
            catch (NullReferenceException)
            {
                return "PSN0000000001";
            }
         }

        [HttpPost("AddPatientInvoice", Name = "AddPatientInvoice")]
        [ValidateModelAttribute]
        public IActionResult AddPatientInvoice([FromBody]PatientInvoice model)
        {
            if(model.DateCreated == null)
            {
                model.DateCreated = DateTime.Now;
            }
            model.SlipNumber = GenPSN();
            _repo.Add(model);
            return new OkObjectResult(new { PatientInvoiceID = model.PatientInvoiceId });
        }

        [HttpDelete("DeletePatientInvoice/{id}")]
        public IActionResult DeletePatientInvoice(long id)
        {
            PatientInvoice patientInvoice = _repo.Find(id);
            if (patientInvoice == null)
            {
                return NotFound();
            }

            _repo.Delete(patientInvoice);
            return Ok();
        }
        #endregion

        #region Patient Invoice Item

        [HttpGet("GetPatientInvoiceItems", Name = "GetPatientInvoiceItems")]
        public IEnumerable<PatientInvoiceItem> GetPatientInvoiceItems()
        {
            IEnumerable<PatientInvoiceItem> pii = item_repo.GetAll();
            pii = pii.OrderByDescending(a => a.PatientInvoiceItemId);
            return pii;
        }

        [HttpGet("GetPatientInvoiceItem/{id}", Name = "GetPatientInvoiceItem")]
        public PatientInvoiceItem GetPatientInvoiceItem(long id) => item_repo.GetFirst(a => a.PatientInvoiceItemId == id);

        [HttpPut("UpdatePatientInvoiceItem", Name = "UpdatePatientInvoiceItem")]
        [ValidateModelAttribute]
        public IActionResult UpdatePatientInvoiceItem([FromBody]PatientInvoiceItem model)
        {
            item_repo.Update(model);
            return new OkObjectResult(new { PatientInvoiceItemID = model.PatientInvoiceItemId });
        }
        
        [HttpPost("AddPatientInvoiceItem", Name = "AddPatientInvoiceItem")]
        [ValidateModelAttribute]
        public IActionResult AddPatientInvoiceItem([FromBody] PatientInvoiceItem model)
        {
            item_repo.Add(model);
            return new OkObjectResult(new { PatientInvoiceItemID = model.PatientInvoiceItemId });
        }

        [HttpDelete("DeletePatientInvoiceItem/{id}")]
        public IActionResult DeletePatientInvoiceItem(long id)
        {
            PatientInvoiceItem patientInvoiceItem = item_repo.Find(id);
            if (patientInvoiceItem == null)
            {
                return NotFound();
            }

            item_repo.Delete(patientInvoiceItem);
            return Ok();
        }
        #endregion

    }
}
