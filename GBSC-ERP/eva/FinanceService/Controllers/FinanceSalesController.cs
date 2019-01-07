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
    public class FinanceSalesController : Controller
    {
        private IFinanceSalesInvoiceRepository Inv_repo;
        private IFinanceSalesInvoiceDetailRepository InvDetail_repo;
        private IFinanceSalesReturnRepository Ret_repo;
        private IFinanceSalesReturnDetailRepository RetDetail_repo;

        public FinanceSalesController(
            IFinanceSalesInvoiceRepository invrepo,
            IFinanceSalesInvoiceDetailRepository invdetailrepo,
            IFinanceSalesReturnRepository retrepo,
            IFinanceSalesReturnDetailRepository retdetailrepo
            )
        {
            Inv_repo = invrepo;
            InvDetail_repo = invdetailrepo;
            Ret_repo = retrepo;
            RetDetail_repo = retdetailrepo;
        }

        //[HttpGet("GetFinanceSalesPermissions/{userid}/{RoleId}/{featureid}", Name = "GetFinanceSalesPermissions")]
        //public IEnumerable<Permission> GetFinancePurchassePermissions(long userid, long RoleId, long featureid)
        //{
        //    IEnumerable<Permission> per = Inv_repo.GetFeaturePermissions(userid, RoleId, featureid).Permissions.ToList();
        //    return per;
        //}


        #region FinanceSalesInvoice

        [HttpGet("GetFinanceSalesInvoices", Name = "GetFinanceSalesInvoices")]
        public IEnumerable<FinanceSalesInvoice> GetFinanceSalesInvoices()
        {
            IEnumerable<FinanceSalesInvoice> ap = Inv_repo.GetAll(a => a.FinanceSalesInvoiceDetails);
            ap = ap.OrderByDescending(a => a.FinanceSalesInvoiceId);
            return ap;
        }

        [HttpGet("GetFinanceSalesInvoice/{id}", Name = "GetFinanceSalesInvoice")]
        public FinanceSalesInvoice GetFinanceSalesInvoice(long id) => Inv_repo.GetFirst(a => a.FinanceSalesInvoiceId == id,b=> b.FinanceSalesInvoiceDetails);

        //[HttpPut("UpdateFinanceSalesInvoice", Name = "UpdateFinanceSalesInvoice")]
        //[ValidateModelAttribute]
        //public IActionResult UpdateFinanceSalesInvoice([FromBody]FinanceSalesInvoice model)
        //{
        //    Inv_repo.Update(model);
        //    return new OkObjectResult(new { FinanceSalesInvoiceID = model.FinanceSalesInvoiceId });
        //}

        [HttpPut("UpdateFinanceSalesInvoice", Name = "UpdateFinanceSalesInvoice")]
        [ValidateModelAttribute]
        public IActionResult UpdateFinanceSalesInvoice([FromBody]FinanceSalesInvoice model)
        {
            try
            {
                InvDetail_repo.DeleteRange(InvDetail_repo.GetAll().Where(a => a.FinanceSalesInvoiceId == model.FinanceSalesInvoiceId));
                Inv_repo.Update(model);
                return new OkObjectResult(new { FinanceSalesInvoiceID = model.FinanceSalesInvoiceId });
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("AddFinanceSalesInvoice", Name = "AddFinanceSalesInvoice")]
        [ValidateModelAttribute]
        public IActionResult AddFinanceSalesInvoice([FromBody]FinanceSalesInvoice model)
        {
            Inv_repo.Add(model);
            return new OkObjectResult(new { FinanceSalesInvoiceID = model.FinanceSalesInvoiceId });
        }

        [HttpDelete("DeleteFinanceSalesInvoice/{id}")]
        public IActionResult DeleteFinanceSalesInvoice(long id)
        {
            FinanceSalesInvoice fin = Inv_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            Inv_repo.Delete(fin);
            return Ok();
        }

        #endregion

        #region FinanceSalesInvoiceDetail

        [HttpGet("GetFinanceSalesInvoiceDetails", Name = "GetFinanceSalesInvoiceDetails")]
        public IEnumerable<FinanceSalesInvoiceDetail> GetFinanceSalesInvoiceDetails()
        {
            IEnumerable<FinanceSalesInvoiceDetail> ap = InvDetail_repo.GetAll();
            ap = ap.OrderByDescending(a => a.FinanceSalesInvoiceDetailId);
            return ap;
        }

        [HttpGet("GetFinanceSalesInvoiceDetail/{id}", Name = "GetFinanceSalesInvoiceDetail")]
        public FinanceSalesInvoiceDetail GetFinanceSalesInvoiceDetail(long id) => InvDetail_repo.GetFirst(a => a.FinanceSalesInvoiceDetailId == id);

        [HttpPut("UpdateFinanceSalesInvoiceDetail", Name = "UpdateFinanceSalesInvoiceDetail")]
        [ValidateModelAttribute]
        public IActionResult UpdateFinanceSalesInvoiceDetail([FromBody]FinanceSalesInvoiceDetail model)
        {
            InvDetail_repo.Update(model);
            return new OkObjectResult(new { FinanceSalesInvoiceDetailID = model.FinanceSalesInvoiceDetailId });
        }

        [HttpPost("AddFinanceSalesInvoiceDetail", Name = "AddFinanceSalesInvoiceDetail")]
        [ValidateModelAttribute]
        public IActionResult AddFinanceSalesInvoiceDetail([FromBody]FinanceSalesInvoiceDetail model)
        {
            InvDetail_repo.Add(model);
            return new OkObjectResult(new { FinanceSalesInvoiceDetailID = model.FinanceSalesInvoiceDetailId });
        }

        [HttpDelete("DeleteFinanceSalesInvoiceDetail/{id}")]
        public IActionResult DeleteFinanceSalesInvoiceDetail(long id)
        {
            FinanceSalesInvoiceDetail fin = InvDetail_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            InvDetail_repo.Delete(fin);
            return Ok();
        }

        #endregion

        #region FinanceSalesReturn

        [HttpGet("GetFinanceSalesReturns", Name = "GetFinanceSalesReturns")]
        public IEnumerable<FinanceSalesReturn> GetFinanceSalesReturns()
        {
            IEnumerable<FinanceSalesReturn> ap = Ret_repo.GetAll(a => a.FinanceSalesReturnDetails);
            ap = ap.OrderByDescending(a => a.FinanceSalesReturnId);
            return ap;
        }

        [HttpGet("GetFinanceSalesReturn/{id}", Name = "GetFinanceSalesReturn")]
        public FinanceSalesReturn GetFinanceSalesReturn(long id) => Ret_repo.GetFirst(a => a.FinanceSalesReturnId == id, b=> b.FinanceSalesReturnDetails);

        //[HttpPut("UpdateFinanceSalesReturn", Name = "UpdateFinanceSalesReturn")]
        //[ValidateModelAttribute]
        //public IActionResult UpdateFinanceSalesReturn([FromBody]FinanceSalesReturn model)
        //{
        //    Ret_repo.Update(model);
        //    return new OkObjectResult(new { FinanceSalesReturnID = model.FinanceSalesReturnId });
        //}

        [HttpPut("UpdateFinanceSalesReturn", Name = "UpdateFinanceSalesReturn")]
        [ValidateModelAttribute]
        public IActionResult UpdateFinanceSalesReturn([FromBody]FinanceSalesReturn model)
        {
            try
            {
                RetDetail_repo.DeleteRange(RetDetail_repo.GetAll().Where(a => a.FinanceSalesReturnId == model.FinanceSalesReturnId));
                Ret_repo.Update(model);
                return new OkObjectResult(new { FinanceSalesReturnID = model.FinanceSalesReturnId });
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("AddFinanceSalesReturn", Name = "AddFinanceSalesReturn")]
        [ValidateModelAttribute]
        public IActionResult AddFinanceSalesReturn([FromBody]FinanceSalesReturn model)
        {
            Ret_repo.Add(model);
            return new OkObjectResult(new { FinanceSalesReturnID = model.FinanceSalesReturnId });
        }

        [HttpDelete("DeleteFinanceSalesReturn/{id}")]
        public IActionResult DeleteFinanceSalesReturn(long id)
        {
            FinanceSalesReturn fin = Ret_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            Ret_repo.Delete(fin);
            return Ok();
        }

        #endregion

        #region FinanceSalesReturnDetail

        [HttpGet("GetFinanceSalesReturnDetails", Name = "GetFinanceSalesReturnDetails")]
        public IEnumerable<FinanceSalesReturnDetail> GetFinanceSalesReturnDetails()
        {
            IEnumerable<FinanceSalesReturnDetail> ap = RetDetail_repo.GetAll();
            ap = ap.OrderByDescending(a => a.FinanceSalesReturnDetailId);
            return ap;
        }

        [HttpGet("GetFinanceSalesReturnDetail/{id}", Name = "GetFinanceSalesReturnDetail")]
        public FinanceSalesReturnDetail GetFinanceSalesReturnDetail(long id) => RetDetail_repo.GetFirst(a => a.FinanceSalesReturnDetailId == id);

        [HttpPut("UpdateFinanceSalesReturnDetail", Name = "UpdateFinanceSalesReturnDetail")]
        [ValidateModelAttribute]
        public IActionResult UpdateFinanceSalesReturnDetail([FromBody]FinanceSalesReturnDetail model)
        {
            RetDetail_repo.Update(model);
            return new OkObjectResult(new { FinanceSalesReturnDetailID = model.FinanceSalesReturnDetailId });
        }

        [HttpPost("AddFinanceSalesReturnDetail", Name = "AddFinanceSalesReturnDetail")]
        [ValidateModelAttribute]
        public IActionResult AddFinanceSalesReturnDetail([FromBody]FinanceSalesReturnDetail model)
        {
            RetDetail_repo.Add(model);
            return new OkObjectResult(new { FinanceSalesReturnDetailID = model.FinanceSalesReturnDetailId });
        }

        [HttpDelete("DeleteFinanceSalesReturnDetail/{id}")]
        public IActionResult DeleteFinanceSalesReturnDetail(long id)
        {
            FinanceSalesReturnDetail fin = RetDetail_repo.Find(id);
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