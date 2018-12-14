using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.Finance;
using ErpCore.Filters;
using FinanceService.Repos.Interfaces;
using FinanceService.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FinanceController : Controller
    {
        private IAccountRepository Account_Repo;
        private IVoucherRepository Vou_repo;
        private IVoucherDetailRepository VouDetail_repo;

        public FinanceController(IAccountRepository accountrepo, IVoucherRepository vourepo, IVoucherDetailRepository voudetailrepo)
        {
            Account_Repo = accountrepo;
            Vou_repo = vourepo;
            VouDetail_repo = voudetailrepo;
        }

        [HttpGet("GetVoucherPermissions/{userid}/{roleid}/{featureid}", Name = "GetVoucherPermissions")]
        public IEnumerable<Permission> GetPurchassePermissions(long userid, long roleid, long featureid)
        {
            IEnumerable<Permission> per = Vou_repo.GetFeaturePermissions(userid, roleid, featureid).Permissions.ToList();
            return per;
        }

        #region Account

        [HttpGet("GetAccounts", Name = "GetAccounts")]
        public IEnumerable<Account> GetAccounts()
        {
            return Account_Repo.GetAll(a => a.FinancialYear).OrderBy(a => a.AccountCode);
        }

        [HttpGet("GetAccount/{id}", Name = "GetAccount")]
        public Account GetAccount(long id) => Account_Repo.GetFirst(a => a.AccountId == id);

        [HttpPut("UpdateAccount", Name = "UpdateAccount")]
        [ValidateModelAttribute]
        public IActionResult UpdateAccount([FromBody]Account model)
        {
            Account updateAccount = Account_Repo.Find(model.AccountId);
            updateAccount.OpeningBalance = model.OpeningBalance;
            updateAccount.Description = model.Description;
            Account_Repo.Update(updateAccount);
            return new OkObjectResult(new { AccountId = model.AccountId });
        }

        public string GenerateAccountCode(AccountViewModel model)
        {
            if(model.ParentAccountCode != null)
            {
                try
                {
                    string LastAccountCode = Account_Repo.GetList(a => a.ParentAccountCode == model.ParentAccountCode).OrderByDescending(a => a.AccountId).FirstOrDefault().AccountCode;
                    string number = Regex.Match(LastAccountCode, "[0-9]+$").Value;
                    return LastAccountCode.Substring(0, LastAccountCode.Length - number.Length) + (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
                }
                catch(NullReferenceException)
                {
                    return model.ParentAccountCode + "-01";
                }
            }
            else
            {
                try
                {
                    string LastAccountCode = Account_Repo.GetList(a => a.AccountCode.Length == 2).OrderByDescending(a => a.AccountId).FirstOrDefault().AccountCode;
                    string number = Regex.Match(LastAccountCode, "[0-9]+$").Value;
                    return LastAccountCode.Substring(0, LastAccountCode.Length - number.Length) + (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
                }
                catch(NullReferenceException)
                {
                    return "01";
                }
            }
        }

        [HttpPost("AddAccount", Name = "AddAccount")]
        [ValidateModelAttribute]
        public IActionResult AddAccount([FromBody]AccountViewModel model)
        {
            try
            {
                if (Account_Repo.GetFirst(a => a.AccountCode == model.ParentAccountCode).IsGeneralOrDetail == false)
                {
                    return BadRequest("Can't create a child account for detail accounts");
                }
            }
            catch(NullReferenceException)
            {

            }
            

            if(model.ParentAccountLevel == null)
            {
                model.ParentAccountLevel = 0;
            }

            Account newAccount = new Account()
            {
                ParentAccountCode = model.ParentAccountCode,
                AccountCode = GenerateAccountCode(model),
                AccountLevel = model.ParentAccountLevel + 1,
                Description = model.Description,
                IsGeneralOrDetail = model.IsGeneralOrDetail,
                FinancialYearId = model.FinancialYearId,
                OpeningBalance = model.OpeningBalance
            };

            Account_Repo.Add(newAccount);
            return new OkObjectResult(new { AccountId = newAccount.AccountId });
        }

        [HttpDelete("DeleteAccount/{id}")]
        public IActionResult DeleteAccount(long id)
        {
            return Ok();
        }

        #endregion


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
                VouDetail_repo.Update(model);
                return new OkObjectResult(new { VoucherDetailID = model.VoucherDetailId });
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("UpdateVoucherDetails", Name = "UpdateVoucherDetails")]
        [ValidateModelAttribute]
        public IActionResult UpdateVoucherDetails([FromBody]IList<VoucherDetail> models)
        {
            try
            {
                VouDetail_repo.UpdateRange(models);
                return Ok();
            }
            catch (Exception e)
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