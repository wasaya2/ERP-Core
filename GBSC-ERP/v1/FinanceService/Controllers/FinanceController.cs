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
    public class FinanceController : Controller
    {
        private IVoucherRepository Vou_repo;
        private IVoucherDetailRepository VouDetail_repo;

        public FinanceController(IVoucherRepository vourepo, IVoucherDetailRepository voudetailrepo)
        {
            Vou_repo = vourepo;
            VouDetail_repo = voudetailrepo;
        }

        [HttpGet("GetVoucherPermissions/{userid}/{roleid}/{featureid}", Name = "GetVoucherPermissions")]
        public IEnumerable<Permission> GetPurchassePermissions(long userid, long roleid, long featureid)
        {
            IEnumerable<Permission> per = Vou_repo.GetFeaturePermissions(userid, roleid, featureid).Permissions.ToList();
            return per;
        }


        #region Voucher

        [HttpGet("GetVouchers", Name = "GetVouchers")]
        public IEnumerable<Voucher> GetVouchers()
        {
            IEnumerable<Voucher> ap = Vou_repo.GetAll(a => a.VoucherDetails);
            ap = ap.OrderByDescending(a => a.VoucherId);
            return ap;
        }

        [HttpGet("GetVoucher/{id}", Name = "GetVoucher")]
        public Voucher GetVoucher(long id) => Vou_repo.GetFirst(a => a.VoucherId == id, b => b.VoucherDetails);

        [HttpPut("UpdateVoucher", Name = "UpdateVoucher")]
        [ValidateModelAttribute]
        public IActionResult UpdateVoucher([FromBody]Voucher model)
        {
            try
            {
                VouDetail_repo.DeleteRange(VouDetail_repo.GetAll().Where(a => a.VoucherId == model.VoucherId));
                Vou_repo.Update(model);
            return new OkObjectResult(new { VoucherID = model.VoucherId });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("AddVoucher", Name = "AddVoucher")]
        [ValidateModelAttribute]
        public IActionResult AddVoucher([FromBody]Voucher model)
        {
            Vou_repo.Add(model);
            return new OkObjectResult(new { VoucherID = model.VoucherId });
        }

        [HttpDelete("DeleteVoucher/{id}")]
        public IActionResult DeleteVoucher(long id)
        {
            Voucher fin = Vou_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            Vou_repo.Delete(fin);
            return Ok();
        }

        #endregion

        #region VoucherDetail

        [HttpGet("GetVoucherDetails", Name = "GetVoucherDetails")]
        public IEnumerable<VoucherDetail> GetVoucherDetails()
        {
            IEnumerable<VoucherDetail> ap = VouDetail_repo.GetAll();
            ap = ap.OrderByDescending(a => a.VoucherDetailId);
            return ap;
        }

        [HttpGet("GetVoucherDetail/{id}", Name = "GetVoucherDetail")]
        public VoucherDetail GetVoucherDetail(long id) => VouDetail_repo.GetFirst(a => a.VoucherDetailId == id);

        [HttpPut("UpdateVoucherDetail", Name = "UpdateVoucherDetail")]
        [ValidateModelAttribute]
        public IActionResult UpdateVoucherDetail([FromBody]VoucherDetail model)
        {
            try
            {
                VouDetail_repo.DeleteRange(VouDetail_repo.GetAll().Where(a => a.VoucherId == model.VoucherId));
                VouDetail_repo.Update(model);
            return new OkObjectResult(new { VoucherDetailID = model.VoucherDetailId });
        }
            catch(Exception e)
            {
                return BadRequest(e);
    }
}

        [HttpPost("AddVoucherDetail", Name = "AddVoucherDetail")]
        [ValidateModelAttribute]
        public IActionResult AddVoucherDetail([FromBody]VoucherDetail model)
        {
            VouDetail_repo.Add(model);
            return new OkObjectResult(new { VoucherDetailID = model.VoucherDetailId });
        }

        [HttpDelete("DeleteVoucherDetail/{id}")]
        public IActionResult DeleteVoucherDetail(long id)
        {
            VoucherDetail fin = VouDetail_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            VouDetail_repo.Delete(fin);
            return Ok();
        }

        #endregion
    }
}