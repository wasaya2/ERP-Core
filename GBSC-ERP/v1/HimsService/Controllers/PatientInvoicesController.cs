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
        private IPatientInvoiceReturnRepository Return_repo;
        private IPatientInvoiceReturnItemRepository Returnitem_repo;

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
        public PatientInvoice GetPatientInvoice(long id) => _repo.GetFirst(a => a.PatientInvoiceId == id, b => b.PatientInvoiceItems);

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

        #region Patient Invoice Return
        [HttpGet("GetPatientInvoiceReturns", Name = "GetPatientInvoiceReturns")]
        public IEnumerable<PatientInvoiceReturn> GetPatientInvoiceReturns()
        {
            return Return_repo.GetAll().OrderByDescending(a => a.PatientInvoiceReturnId);
        }

        [HttpGet("GetPatientInvoiceReturn/{id}", Name = "GetPatientInvoiceReturn")]
        public PatientInvoiceReturn GetPatientInvoiceReturn(long id) => Return_repo.GetFirst(a => a.PatientInvoiceReturnId == id);

        [HttpPut("UpdatePatientInvoiceReturn", Name = "UpdatePatientInvoiceReturn")]
        [ValidateModelAttribute]
        public IActionResult UpdatePatientInvoiceReturn([FromBody]PatientInvoiceReturn model)
        {
            Return_repo.Update(model);
            return new OkObjectResult(new { PatientInvoiceReturnID = model.PatientInvoiceReturnId });
        }

        private string GenPIRN()
        {
            try
            {
                string value = Return_repo.GetLast().InvoiceReturnNumber;
                string number = Regex.Match(value, "[0-9]+$").Value;

                return value.Substring(0, value.Length - number.Length) +
                       (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch (ArgumentNullException)
            {
                return "PIRN0000000001";
            }
            catch (NullReferenceException)
            {
                return "PIRN0000000001";
            }
        }

        [HttpPost("AddPatientInvoiceReturn", Name = "AddPatientInvoiceReturn")]
        [ValidateModelAttribute]
        public IActionResult AddPatientInvoiceReturn([FromBody]PatientInvoiceReturn model)
        {
            if (model.ReturnDate == null)
            {
                model.ReturnDate = DateTime.Now;
            }
            model.InvoiceReturnNumber = GenPIRN();
            Return_repo.Add(model);
            return new OkObjectResult(new { PatientInvoiceID = model.PatientInvoiceId });
        }

        [HttpDelete("DeletePatientInvoiceReturn/{id}")]
        public IActionResult DeletePatientInvoiceReturn(long id)
        {
            PatientInvoiceReturn patientInvoiceReturn = Return_repo.Find(id);
            if (patientInvoiceReturn == null)
            {
                return NotFound();
            }

            Return_repo.Delete(patientInvoiceReturn);
            return Ok();
        }
        #endregion

        #region Patient Invoice Return Item

        [HttpGet("GetPatientInvoiceReturnItems", Name = "GetPatientInvoiceReturnItems")]
        public IEnumerable<PatientInvoiceReturnItem> GetPatientInvoiceReturnItems()
        {
            return Returnitem_repo.GetAll().OrderByDescending(a => a.PatientInvoiceReturnItemId);
        }

        [HttpGet("GetPatientInvoiceReturnItem/{id}", Name = "GetPatientInvoiceReturnItem")]
        public PatientInvoiceReturnItem GetPatientInvoiceReturnItem(long id) => Returnitem_repo.GetFirst(a => a.PatientInvoiceReturnItemId == id);

        [HttpPut("UpdatePatientInvoiceReturnItem", Name = "UpdatePatientInvoiceReturnItem")]
        [ValidateModelAttribute]
        public IActionResult UpdatePatientInvoiceReturnItem([FromBody]PatientInvoiceReturnItem model)
        {
            Returnitem_repo.Update(model);
            return new OkObjectResult(new { PatientInvoiceReturnItemID = model.PatientInvoiceReturnItemId });
        }

        [HttpPost("AddPatientInvoiceReturnItem", Name = "AddPatientInvoiceReturnItem")]
        [ValidateModelAttribute]
        public IActionResult AddPatientInvoiceReturnItem([FromBody] PatientInvoiceReturnItem model)
        {
            Returnitem_repo.Add(model);
            return new OkObjectResult(new { PatientInvoiceReturnItemID = model.PatientInvoiceReturnItemId });
        }

        [HttpDelete("DeletePatientInvoiceReturnItem/{id}")]
        public IActionResult DeletePatientInvoiceReturnItem(long id)
        {
            PatientInvoiceReturnItem patientInvoiceReturnItem = Returnitem_repo.Find(id);
            if (patientInvoiceReturnItem == null)
            {
                return NotFound();
            }

            Returnitem_repo.Delete(patientInvoiceReturnItem);
            return Ok();
        }
        #endregion

        [HttpGet("GetPatientInvoicesWithDetailsByPatientId/{patientid}", Name = "GetPatientInvoicesWithDetailsByPatientId")]
        public IEnumerable<PatientInvoice> GetPatientInvoicesWithDetailsByPatientId(long patientid)
        {
            return _repo.GetList(a => a.PatientId != null && a.PatientId == patientid, b => b.PatientInvoiceItems).OrderByDescending(a => a.PatientInvoiceId);
        }

        [HttpGet("GetPatientInvoicesWithDetailsByDate/{date}", Name = "GetPatientInvoicesWithDetailsByDate")]
        public IEnumerable<PatientInvoice> GetPatientInvoicesWithDetailsByDate(DateTime date)
        {
            return _repo.GetList(a => a.DateCreated != null && a.DateCreated.Value.Date == date.Date, b => b.PatientInvoiceItems).OrderByDescending(a => a.PatientInvoiceId);
        }

        [HttpGet("GetPatientInvoiceReturnsWithDetailsByPatientId/{patientid}", Name = "GetPatientInvoiceReturnsWithDetailsByPatientId")]
        public IEnumerable<PatientInvoiceReturn> GetPatientInvoiceReturnsWithDetailsByPatientId(long patientid)
        {
            return Return_repo.GetList(a => a.PatientId != null && a.PatientId == patientid, b => b.PatientInvoiceReturnItems, c => c.PatientInvoice).OrderByDescending(a => a.PatientInvoiceReturnId);
        }

        [HttpGet("GetPatientInvoiceReturnsWithDetailsByDate/{date}", Name = "GetPatientInvoiceReturnsWithDetailsByDate")]
        public IEnumerable<PatientInvoiceReturn> GetPatientInvoiceReturnsWithDetailsByDate(DateTime date)
        {
            return Return_repo.GetList(a => a.ReturnDate != null && a.ReturnDate.Value.Date == date.Date, b => b.PatientInvoiceReturnItems, c => c.PatientInvoice).OrderByDescending(a => a.PatientInvoiceReturnId);
        }

    }
}
