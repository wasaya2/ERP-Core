using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.Finance;
using ErpCore.Filters;
using FinanceService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FinancePurchaseController : Controller
    {
        private IFinancePurchaseInvoiceRepository Inv_repo;
        private IFinancePurchaseInvoiceDetailRepository InvDetail_repo;
        private IFinancePurchaseReturnRepository Ret_repo;
        private IFinancePurchaseReturnDetailRepository RetDetail_repo;

        public FinancePurchaseController(
            IFinancePurchaseInvoiceRepository invrepo,
            IFinancePurchaseInvoiceDetailRepository invdetailrepo,
            IFinancePurchaseReturnRepository retrepo,
            IFinancePurchaseReturnDetailRepository retdetailrepo
            )
        {
            Inv_repo = invrepo;
            InvDetail_repo = invdetailrepo;
            Ret_repo = retrepo;
            RetDetail_repo = retdetailrepo;
        }

        [HttpGet("GetFinancePurchasePermissions/{userid}/{RoleId}/{featureid}", Name = "GetFinancePurchasePermissions")]
        public IEnumerable<Permission> GetFinancePurchassePermissions(long userid, long RoleId, long featureid)
        {
            IEnumerable<Permission> per = Inv_repo.GetFeaturePermissions(userid, RoleId, featureid).Permissions.ToList();
            return per;
        }


        #region FinancePurchaseInvoice
        
        [HttpGet("GetFinancePurchaseInvoices", Name = "GetFinancePurchaseInvoices")]
        public IEnumerable<FinancePurchaseInvoice> GetFinancePurchaseInvoices()
        {
            IEnumerable<FinancePurchaseInvoice> ap = Inv_repo.GetAll(a => a.FinancePurchaseInvoiceDetails);
            ap = ap.OrderByDescending(a => a.FinancePurchaseInvoiceId);
            return ap;
        }

        [HttpGet("GetFinancePurchaseInvoice/{id}", Name = "GetFinancePurchaseInvoice")]
        public FinancePurchaseInvoice GetFinancePurchaseInvoice(long id) => Inv_repo.GetFirst(a => a.FinancePurchaseInvoiceId == id,b => b.FinancePurchaseInvoiceDetails);

        //[HttpPut("UpdateFinancePurchaseInvoice", Name = "UpdateFinancePurchaseInvoice")]
        //[ValidateModelAttribute]
        //public IActionResult UpdateFinancePurchaseInvoice([FromBody]FinancePurchaseInvoice model)
        //{
        //    Inv_repo.Update(model);
        //    return new OkObjectResult(new { FinancePurchaseInvoiceID = model.FinancePurchaseInvoiceId });
        //}

        [HttpPut("UpdateFinancePurchaseInvoice", Name = "UpdateFinancePurchaseInvoice")]
        [ValidateModelAttribute]
        public IActionResult UpdateFinancePurchaseInvoice([FromBody]FinancePurchaseInvoice model)
        {
            try
            {
                InvDetail_repo.DeleteRange(InvDetail_repo.GetAll().Where(a => a.FinancePurchaseInvoiceId == model.FinancePurchaseInvoiceId));
                Inv_repo.Update(model);
                return new OkObjectResult(new { FinancePurchaseInvoiceID = model.FinancePurchaseInvoiceId });
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("AddFinancePurchaseInvoice", Name = "AddFinancePurchaseInvoice")]
        [ValidateModelAttribute]
        public IActionResult AddFinancePurchaseInvoice([FromBody]FinancePurchaseInvoice model)
        {
            Inv_repo.Add(model);
            return new OkObjectResult(new { FinancePurchaseInvoiceID = model.FinancePurchaseInvoiceId });
        }

        [HttpDelete("DeleteFinancePurchaseInvoice/{id}")]
        public IActionResult DeleteFinancePurchaseInvoice(long id)
        {
            FinancePurchaseInvoice fin = Inv_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            Inv_repo.Delete(fin);
            return Ok();
        }

        #endregion

        #region FinancePurchaseInvoiceDetail

        [HttpGet("GetFinancePurchaseInvoiceDetails", Name = "GetFinancePurchaseInvoiceDetails")]
        public IEnumerable<FinancePurchaseInvoiceDetail> GetFinancePurchaseInvoiceDetails()
        {
            IEnumerable<FinancePurchaseInvoiceDetail> ap = InvDetail_repo.GetAll();
            ap = ap.OrderByDescending(a => a.FinancePurchaseInvoiceDetailId);
            return ap;
        }

        [HttpGet("GetFinancePurchaseInvoiceDetail/{id}", Name = "GetFinancePurchaseInvoiceDetail")]
        public FinancePurchaseInvoiceDetail GetFinancePurchaseInvoiceDetail(long id) => InvDetail_repo.GetFirst(a => a.FinancePurchaseInvoiceDetailId == id);

        [HttpPut("UpdateFinancePurchaseInvoiceDetail", Name = "UpdateFinancePurchaseInvoiceDetail")]
        [ValidateModelAttribute]
        public IActionResult UpdateFinancePurchaseInvoiceDetail([FromBody]FinancePurchaseInvoiceDetail model)
        {
            InvDetail_repo.Update(model);
            return new OkObjectResult(new { FinancePurchaseInvoiceDetailID = model.FinancePurchaseInvoiceDetailId });
        }

        [HttpPost("AddFinancePurchaseInvoiceDetail", Name = "AddFinancePurchaseInvoiceDetail")]
        [ValidateModelAttribute]
        public IActionResult AddFinancePurchaseInvoiceDetail([FromBody]FinancePurchaseInvoiceDetail model)
        {
            InvDetail_repo.Add(model);
            return new OkObjectResult(new { FinancePurchaseInvoiceDetailID = model.FinancePurchaseInvoiceDetailId });
        }

        [HttpDelete("DeleteFinancePurchaseInvoiceDetail/{id}")]
        public IActionResult DeleteFinancePurchaseInvoiceDetail(long id)
        {
            FinancePurchaseInvoiceDetail fin = InvDetail_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            InvDetail_repo.Delete(fin);
            return Ok();
        }

        #endregion

        #region FinancePurchaseReturn

        [HttpGet("GetFinancePurchaseReturns", Name = "GetFinancePurchaseReturns")]
        public IEnumerable<FinancePurchaseReturn> GetFinancePurchaseReturns()
        {
            IEnumerable<FinancePurchaseReturn> ap = Ret_repo.GetAll(a => a.FinancePurchaseReturnDetails);
            ap = ap.OrderByDescending(a => a.FinancePurchaseReturnId);
            return ap;
        }

        [HttpGet("GetFinancePurchaseReturn/{id}", Name = "GetFinancePurchaseReturn")]
        public FinancePurchaseReturn GetFinancePurchaseReturn(long id) => Ret_repo.GetFirst(a => a.FinancePurchaseReturnId == id, b=> b.FinancePurchaseReturnDetails);

        //[HttpPut("UpdateFinancePurchaseReturn", Name = "UpdateFinancePurchaseReturn")]
        //[ValidateModelAttribute]
        //public IActionResult UpdateFinancePurchaseReturn([FromBody]FinancePurchaseReturn model)
        //{
        //    Ret_repo.Update(model);
        //    return new OkObjectResult(new { FinancePurchaseReturnID = model.FinancePurchaseReturnId });
        //}

        [HttpPut("UpdateFinancePurchaseReturn", Name = "UpdateFinancePurchaseReturn")]
        [ValidateModelAttribute]
        public IActionResult UpdateFinancePurchaseReturn([FromBody]FinancePurchaseReturn model)
        {
            try
            {
                RetDetail_repo.DeleteRange(RetDetail_repo.GetAll().Where(a => a.FinancePurchaseReturnId == model.FinancePurchaseReturnId));
                Ret_repo.Update(model);
                return new OkObjectResult(new { FinancePurchaseReturnID = model.FinancePurchaseReturnId });
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("AddFinancePurchaseReturn", Name = "AddFinancePurchaseReturn")]
        [ValidateModelAttribute]
        public IActionResult AddFinancePurchaseReturn([FromBody]FinancePurchaseReturn model)
        {
            Ret_repo.Add(model);
            return new OkObjectResult(new { FinancePurchaseReturnID = model.FinancePurchaseReturnId });
        }

        [HttpDelete("DeleteFinancePurchaseReturn/{id}")]
        public IActionResult DeleteFinancePurchaseReturn(long id)
        {
            FinancePurchaseReturn fin = Ret_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            Ret_repo.Delete(fin);
            return Ok();
        }

        #endregion

        #region FinancePurchaseReturnDetail

        [HttpGet("GetFinancePurchaseReturnDetails", Name = "GetFinancePurchaseReturnDetails")]
        public IEnumerable<FinancePurchaseReturnDetail> GetFinancePurchaseReturnDetails()
        {
            IEnumerable<FinancePurchaseReturnDetail> ap = RetDetail_repo.GetAll();
            ap = ap.OrderByDescending(a => a.FinancePurchaseReturnDetailId);
            return ap;
        }

        [HttpGet("GetFinancePurchaseReturnDetail/{id}", Name = "GetFinancePurchaseReturnDetail")]
        public FinancePurchaseReturnDetail GetFinancePurchaseReturnDetail(long id) => RetDetail_repo.GetFirst(a => a.FinancePurchaseReturnDetailId == id);

        [HttpPut("UpdateFinancePurchaseReturnDetail", Name = "UpdateFinancePurchaseReturnDetail")]
        [ValidateModelAttribute]
        public IActionResult UpdateFinancePurchaseReturnDetail([FromBody]FinancePurchaseReturnDetail model)
        {
            RetDetail_repo.Update(model);
            return new OkObjectResult(new { FinancePurchaseReturnDetailID = model.FinancePurchaseReturnDetailId });
        }

        [HttpPost("AddFinancePurchaseReturnDetail", Name = "AddFinancePurchaseReturnDetail")]
        [ValidateModelAttribute]
        public IActionResult AddFinancePurchaseReturnDetail([FromBody]FinancePurchaseReturnDetail model)
        {
            RetDetail_repo.Add(model);
            return new OkObjectResult(new { FinancePurchaseReturnDetailID = model.FinancePurchaseReturnDetailId });
        }

        [HttpDelete("DeleteFinancePurchaseReturnDetail/{id}")]
        public IActionResult DeleteFinancePurchaseReturnDetail(long id)
        {
            FinancePurchaseReturnDetail fin = RetDetail_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            RetDetail_repo.Delete(fin);
            return Ok();
        }

        #endregion

    }
}
