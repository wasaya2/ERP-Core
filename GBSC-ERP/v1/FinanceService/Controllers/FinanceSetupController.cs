using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.FinanceSetup;
using ErpCore.Filters;
using FinanceService.Repos.Interfaces;
using FinanceService.Repos.Interfaces.SetupInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FinanceSetupController : ControllerBase
    {
        private IFinancialYearRepository fin_repo;
        private IVoucherTypeRepository vou_repo;
        private IMasterAccountRepository Master_repo;
        private IDetailAccountRepository Detail_repo;
        private ISubAccountRepository SubAccount_repo;
        private ISecondSubAccountRepository SecondSubAccount_repo;

        public FinanceSetupController(
            IFinancialYearRepository finrepo, 
            IVoucherTypeRepository vourepo,
            IMasterAccountRepository masterrepo,
            IDetailAccountRepository detailrepo,
            ISubAccountRepository subrepo,
            ISecondSubAccountRepository secondsubrepo
            )
        {
            fin_repo = finrepo;
            vou_repo = vourepo;
            Master_repo = masterrepo;
            Detail_repo = detailrepo;
            SubAccount_repo =  subrepo;
            SecondSubAccount_repo = secondsubrepo;
        }

        //[HttpGet("GetFinanceSetupPermissions/{userid}/{RoleId}/{featureid}", Name = "GetFinanceSetupPermissions")]
        //public IEnumerable<Permission> GetFinanceSetupPermissions(long userid, long RoleId, long featureid)
        //{
        //    IEnumerable<Permission> per = fin_repo.GetFeaturePermissions(userid, RoleId, featureid).Permissions.ToList();
        //    return per;
        //}

        #region Financial Year

        [HttpGet("GetFinancialYears", Name = "GetFinancialYears")]
        public IEnumerable<FinancialYear> GetFinancialYears()
        {
            return fin_repo.GetAll().OrderByDescending(a => a.FinancialYearId);
        }

        [HttpGet("GetFinancialYear/{id}", Name = "GetFinancialYear")]
        public FinancialYear GetFinancialYear(long id) => fin_repo.GetFirst(a => a.FinancialYearId == id);

        [HttpPut("UpdateFinancialYear", Name = "UpdateFinancialYear")]
        [ValidateModelAttribute]
        public IActionResult UpdateFinancialYear([FromBody]FinancialYear model)
        {
            if(model.IsActive == true)
            {
                try
                {
                    if (model.FinancialYearId == fin_repo.GetFirst(a => a.IsActive == true).FinancialYearId)
                        model.IsActive = true;
                    else
                        model.IsActive = false;
                }
                catch(NullReferenceException)
                {
                    model.IsActive = true;
                }
            }
            model.Name = model.StartDate.Value.Year.ToString() + '-' + model.EndDate.Value.Year.ToString();
            fin_repo.Update(model);
            return new OkObjectResult(new { FinancialYearID = model.FinancialYearId });
        }

        [HttpPost("AddFinancialYear", Name = "AddFinancialYear")]
        [ValidateModelAttribute]
        public IActionResult AddFinancialYear([FromBody]FinancialYear model)
        {
            if(model.IsActive == true)
            {
                try
                {
                    if (fin_repo.GetFirst(a => a.IsActive == true) == null)
                        model.IsActive = true;
                    else
                        model.IsActive = false;
                }
                catch(NullReferenceException)
                {
                    model.IsActive = true;
                }
            }
            model.Name = model.StartDate.Value.Year.ToString() + '-' + model.EndDate.Value.Year.ToString();
            fin_repo.Add(model);
            return new OkObjectResult(new { FinancialYearID = model.FinancialYearId });
        }

        [HttpDelete("DeleteFinancialYear/{id}")]
        public IActionResult DeleteFinancialYear(long id)
        {
            FinancialYear fin = fin_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            fin_repo.Delete(fin);
            return Ok();
        }

        #endregion

        #region Voucher Type
        
        [HttpGet("GetVoucherTypes", Name = "GetVoucherTypes")]
        public IEnumerable<VoucherType> GetVoucherTypes()
        {
            IEnumerable<VoucherType> ap = vou_repo.GetAll();
            ap = ap.OrderByDescending(a => a.VoucherTypeId);
            return ap;
        }

        [HttpGet("GetVoucherType/{id}", Name = "GetVoucherType")]
        public VoucherType GetVoucherType(long id) => vou_repo.GetFirst(a => a.VoucherTypeId == id);

        [HttpPut("UpdateVoucherType", Name = "UpdateVoucherType")]
        [ValidateModelAttribute]
        public IActionResult UpdateVoucherType([FromBody]VoucherType model)
        {
            vou_repo.Update(model);
            return new OkObjectResult(new { VoucherTypeID = model.VoucherTypeId });
        }

        [HttpPost("AddVoucherType", Name = "AddVoucherType")]
        [ValidateModelAttribute]
        public IActionResult AddVoucherType([FromBody]VoucherType model)
        {
            vou_repo.Add(model);
            return new OkObjectResult(new { VoucherTypeID = model.VoucherTypeId });
        }

        [HttpDelete("DeleteVoucherType/{id}")]
        public IActionResult DeleteVoucherType(long id)
        {
            VoucherType vou = vou_repo.Find(id);
            if (vou == null)
            {
                return NotFound();
            }

            vou_repo.Delete(vou);
            return Ok();
        }

        #endregion

        #region Master Account


        [HttpGet("GetMasterAccounts", Name = "GetMasterAccounts")]
        public IEnumerable<MasterAccount> GetMasterAccounts()
        {
            IEnumerable<MasterAccount> ap = Master_repo.GetAll();
            ap = ap.OrderByDescending(a => a.MasterAccountId);
            return ap;
        }

        [HttpGet("GetMasterAccount/{id}", Name = "GetMasterAccount")]
        public MasterAccount GetMasterAccount(long id) => Master_repo.GetFirst(a => a.MasterAccountId == id);

        [HttpPut("UpdateMasterAccount", Name = "UpdateMasterAccount")]
        [ValidateModelAttribute]
        public IActionResult UpdateMasterAccount([FromBody]MasterAccount model)
        {
            Master_repo.Update(model);
            return new OkObjectResult(new { MasterAccountID = model.MasterAccountId });
        }

        [HttpPost("AddMasterAccount", Name = "AddMasterAccount")]
        [ValidateModelAttribute]
        public IActionResult AddMasterAccount([FromBody]MasterAccount model)
        {
            Master_repo.Add(model);
            return new OkObjectResult(new { MasterAccountID = model.MasterAccountId });
        }

        [HttpDelete("DeleteMasterAccount/{id}")]
        public IActionResult DeleteMasterAccount(long id)
        {
            MasterAccount fin = Master_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            Master_repo.Delete(fin);
            return Ok();
        }

        #endregion
        
        #region Detail Account


        [HttpGet("GetDetailAccounts", Name = "GetDetailAccounts")]
        public IEnumerable<DetailAccount> GetDetailAccounts()
        {
            IEnumerable<DetailAccount> ap = Detail_repo.GetAll();
            ap = ap.OrderByDescending(a => a.DetailAccountId);
            return ap;
        }

        [HttpGet("GetDetailAccount/{id}", Name = "GetDetailAccount")]
        public DetailAccount GetDetailAccount(long id) => Detail_repo.GetFirst(a => a.DetailAccountId == id);

        [HttpPut("UpdateDetailAccount", Name = "UpdateDetailAccount")]
        [ValidateModelAttribute]
        public IActionResult UpdateDetailAccount([FromBody]DetailAccount model)
        {
            Detail_repo.Update(model);
            return new OkObjectResult(new { DetailAccountID = model.DetailAccountId });
        }

        [HttpPost("AddDetailAccount", Name = "AddDetailAccount")]
        [ValidateModelAttribute]
        public IActionResult AddDetailAccount([FromBody]DetailAccount model)
        {
            Detail_repo.Add(model);
            return new OkObjectResult(new { DetailAccountID = model.DetailAccountId });
        }

        [HttpDelete("DeleteDetailAccount/{id}")]
        public IActionResult DeleteDetailAccount(long id)
        {
            DetailAccount fin = Detail_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            Detail_repo.Delete(fin);
            return Ok();
        }

        #endregion

        #region SubAccount


        [HttpGet("GetSubAccounts", Name = "GetSubAccounts")]
        public IEnumerable<SubAccount> GetSubAccounts()
        {
            IEnumerable<SubAccount> ap = SubAccount_repo.GetAll();
            ap = ap.OrderByDescending(a => a.SubAccountId);
            return ap;
        }

        [HttpGet("GetSubAccount/{id}", Name = "GetSubAccount")]
        public SubAccount GetSubAccount(long id) => SubAccount_repo.GetFirst(a => a.SubAccountId == id);

        [HttpPut("UpdateSubAccount", Name = "UpdateSubAccount")]
        [ValidateModelAttribute]
        public IActionResult UpdateSubAccount([FromBody]SubAccount model)
        {
            SubAccount_repo.Update(model);
            return new OkObjectResult(new { SubAccountID = model.SubAccountId });
        }

        [HttpPost("AddSubAccount", Name = "AddSubAccount")]
        [ValidateModelAttribute]
        public IActionResult AddSubAccount([FromBody]SubAccount model)
        {
            SubAccount_repo.Add(model);
            return new OkObjectResult(new { SubAccountID = model.SubAccountId });
        }

        [HttpDelete("DeleteSubAccount/{id}")]
        public IActionResult DeleteSubAccount(long id)
        {
            SubAccount fin = SubAccount_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            SubAccount_repo.Delete(fin);
            return Ok();
        }

        #endregion

        #region SecondSub Account

        [HttpGet("GetSecondSubAccounts", Name = "GetSecondSubAccounts")]
        public IEnumerable<SecondSubAccount> GetSecondSubAccounts()
        {
            IEnumerable<SecondSubAccount> ap = SecondSubAccount_repo.GetAll();
            ap = ap.OrderByDescending(a => a.SecondSubAccountId);
            return ap;
        }

        [HttpGet("GetSecondSubAccount/{id}", Name = "GetSecondSubAccount")]
        public SecondSubAccount GetSecondSubAccount(long id) => SecondSubAccount_repo.GetFirst(a => a.SecondSubAccountId == id);

        [HttpPut("UpdateSecondSubAccount", Name = "UpdateSecondSubAccount")]
        [ValidateModelAttribute]
        public IActionResult UpdateSecondSubAccount([FromBody]SecondSubAccount model)
        {
            SecondSubAccount_repo.Update(model);
            return new OkObjectResult(new { SecondSubAccountID = model.SecondSubAccountId });
        }

        [HttpPost("AddSecondSubAccount", Name = "AddSecondSubAccount")]
        [ValidateModelAttribute]
        public IActionResult AddSecondSubAccount([FromBody]SecondSubAccount model)
        {
            SecondSubAccount_repo.Add(model);
            return new OkObjectResult(new { SecondSubAccountID = model.SecondSubAccountId });
        }

        [HttpDelete("DeleteSecondSubAccount/{id}")]
        public IActionResult DeleteSecondSubAccount(long id)
        {
            SecondSubAccount fin = SecondSubAccount_repo.Find(id);
            if (fin == null)
            {
                return NotFound();
            }

            SecondSubAccount_repo.Delete(fin);
            return Ok();
        }

        #endregion
    }
}