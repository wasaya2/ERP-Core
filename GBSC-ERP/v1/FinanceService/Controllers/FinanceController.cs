using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.Finance;
using ErpCore.Filters;
using FinanceService.Repos.Interfaces;
using FinanceService.Repos.Interfaces.SetupInterfaces;
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
        private IUnprocessedAccountsLedgerRepository UAL_Repo;
        private IProcessedAccountsLedgerRepository PAL_Repo;

        private IVoucherRepository Vou_repo;
        private IVoucherDetailRepository VouDetail_repo;
        private IPostedVoucherRepository PostedVou_repo;
        private IUnpostedVoucherRepository UnpostedVou_repo;

        private IFinancialYearRepository FinancialYear_Repo;
        private IVoucherTypeRepository VoucherType_Repo;

        public FinanceController(IAccountRepository accountrepo, IVoucherRepository vourepo, IVoucherDetailRepository voudetailrepo,
                                    IUnprocessedAccountsLedgerRepository ualrepo, IProcessedAccountsLedgerRepository palrepo,
                                    IPostedVoucherRepository postvourepo, IUnpostedVoucherRepository unpostvourepo,
                                    IFinancialYearRepository financeyearrepo, IVoucherTypeRepository vouchertyperepo)
        {
            Account_Repo = accountrepo;
            UAL_Repo = ualrepo;
            PAL_Repo = palrepo;

            Vou_repo = vourepo;
            VouDetail_repo = voudetailrepo;
            PostedVou_repo = postvourepo;
            UnpostedVou_repo = unpostvourepo;

            FinancialYear_Repo = financeyearrepo;
            VoucherType_Repo = vouchertyperepo;
        }

        [HttpGet("GetVoucherPermissions/{userid}/{RoleId}/{featureid}", Name = "GetVoucherPermissions")]
        public IEnumerable<Permission> GetPurchassePermissions(long userid, long RoleId, long featureid)
        {
            IEnumerable<Permission> per = Vou_repo.GetFeaturePermissions(userid, RoleId, featureid).Permissions.ToList();
            return per;
        }

        #region Account

        [HttpGet("GetAccounts", Name = "GetAccounts")]
        public IEnumerable<Account> GetAccounts()
        {
            return Account_Repo.GetAll(a => a.FinancialYear).OrderByDescending(a => a.FinancialYearId).ThenBy(a => a.AccountCode);
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
            if (model.ParentAccountCode != null)
            {
                try
                {
                    string LastAccountCode = Account_Repo.GetList(a => a.ParentAccountCode == model.ParentAccountCode).OrderByDescending(a => a.AccountId).FirstOrDefault().AccountCode;
                    string number = Regex.Match(LastAccountCode, "[0-9]+$").Value;
                    return LastAccountCode.Substring(0, LastAccountCode.Length - number.Length) + (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
                }
                catch (NullReferenceException)
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
                catch (NullReferenceException)
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
            catch (NullReferenceException)
            {

            }


            if (model.ParentAccountLevel == null)
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

            UnprocessedAccountsLedger newUAL = new UnprocessedAccountsLedger()
            {
                AccountId = newAccount.AccountId,
                FinancialYearId = newAccount.FinancialYearId,
                AccountCode = newAccount.AccountCode,
                ParentAccountCode = newAccount.ParentAccountCode,
                IsGeneralOrDetail = newAccount.IsGeneralOrDetail,
                AccountLevel = newAccount.AccountLevel,
                Description = newAccount.Description,
                OpeningBalance = newAccount.OpeningBalance,
                TotalCredit = 0,
                TotalDebit = 0,
                CurrentBalance = newAccount.OpeningBalance
            };

            UAL_Repo.Add(newUAL);

            return new OkObjectResult(new { AccountId = newAccount.AccountId });
        }

        [HttpDelete("DeleteAccount/{id}")]
        public IActionResult DeleteAccount(long id)
        {
            return BadRequest("Restricted");
        }

        [HttpPost("ProcessAccountsForLedger", Name = "ProcessAccountsForLedger")]
        public IActionResult ProcessAccountsForLedger(EndYearProcessRequestViewModel model)
        {
            try
            {
                //GEt all unprocessed accounts for year to be processed
                IEnumerable<UnprocessedAccountsLedger> UALs = UAL_Repo.GetList(a => a.FinancialYearId == model.FinancialYearProcessId);

                IList<UnprocessedAccountsLedger> newUALs = new List<UnprocessedAccountsLedger>();
                IList<ProcessedAccountsLedger> PALs = new List<ProcessedAccountsLedger>();
                IList<Account> Accounts = new List<Account>();

                foreach (UnprocessedAccountsLedger UAL in UALs)
                {
                    //AddToProcessedLedger
                    ProcessedAccountsLedger PAL = new ProcessedAccountsLedger()
                    {
                        AccountId = UAL.AccountId,
                        FinancialYearId = UAL.FinancialYearId,
                        AccountCode = UAL.AccountCode,
                        ParentAccountCode = UAL.ParentAccountCode,
                        IsGeneralOrDetail = UAL.IsGeneralOrDetail,
                        AccountLevel = UAL.AccountLevel,
                        Description = UAL.Description,
                        OpeningBalance = UAL.OpeningBalance,
                        TotalCredit = UAL.TotalCredit,
                        TotalDebit = UAL.TotalDebit,
                        ClosingBalance = UAL.CurrentBalance
                    };

                    PALs.Add(PAL);

                    Account acc = new Account()
                    {
                        AccountCode = UAL.AccountCode,
                        ParentAccountCode = UAL.ParentAccountCode,
                        IsGeneralOrDetail = UAL.IsGeneralOrDetail,
                        AccountLevel = UAL.AccountLevel,
                        Description = UAL.Description,
                        OpeningBalance = UAL.CurrentBalance,
                        IsBankAccount = UAL.IsBankAccount,
                        IsProcessed = false,
                        FinancialYearId = model.NewFinancialYearCoaId
                    };

                    //Add new account with new opneing balance = PAL.closingBalance = UAL.CurrentBalance && financialyearId = Id of the new financial year to start
                    Account_Repo.Add(acc);

                    //Now create new UALs based on Accounts where new accounts are created with total credit && total debit == 0
                    UnprocessedAccountsLedger newUAL = new UnprocessedAccountsLedger()
                    {
                        AccountId = acc.AccountId,
                        FinancialYearId = model.NewFinancialYearCoaId,
                        AccountCode = acc.AccountCode,
                        ParentAccountCode = acc.ParentAccountCode,
                        IsGeneralOrDetail = acc.IsGeneralOrDetail,
                        AccountLevel = acc.AccountLevel,
                        Description = acc.Description,
                        IsBankAccount = acc.IsBankAccount,
                        OpeningBalance = acc.OpeningBalance,
                        TotalCredit = 0,
                        TotalDebit = 0,
                        CurrentBalance = acc.OpeningBalance
                    };

                    newUALs.Add(newUAL);

                }

                //Add newly processed PALs
                PAL_Repo.AddRange(PALs);
                //delete the old UALs
                UAL_Repo.DeleteRange(UALs);
                //Add new UALs
                UAL_Repo.AddRange(newUALs);


                //UpdateAccountInAccountWhereFinancialID=IdOfTheYearBeingProcessed
                IEnumerable<Account> UpdateAccounts = Account_Repo.GetList(a => a.FinancialYearId == model.FinancialYearProcessId);
                IEnumerable<ProcessedAccountsLedger> NewlyAddedPALs = PAL_Repo.GetList(a => a.FinancialYearId == model.FinancialYearProcessId);
                IList<Account> UpdatedAccounts = new List<Account>();

                foreach (Account acc in UpdateAccounts)
                {
                    acc.UnprocessedAccountsLedgeId = UALs.FirstOrDefault(a => a.FinancialYearId == acc.FinancialYearId && a.AccountId == acc.AccountId && a.AccountCode == acc.AccountCode).UnprocessedAccountsLedgerId;
                    acc.ProcessedAccountsLedgerId = NewlyAddedPALs.FirstOrDefault(a => a.FinancialYearId == acc.FinancialYearId && a.AccountId == acc.AccountId && a.AccountCode == acc.AccountCode).ProcessedAccountsLedgerId;
                    acc.IsProcessed = true;

                    UpdatedAccounts.Add(acc);
                }
                //Update processed accounts
                Account_Repo.UpdateRange(UpdatedAccounts);

                return Ok("Processed");
            }
            catch (Exception)
            {
                return BadRequest("Unable to process");
            }
        }

        #endregion

        #region Processed Account

        [HttpGet("GetProcessedAccountsLedgers", Name = "GetProcessedAccountsLedgers")]
        public IEnumerable<ProcessedAccountsLedger> GetProcessedAccountsLedgers()
        {
            return PAL_Repo.GetAll().OrderByDescending(a => a.FinancialYearId).ThenBy(a => a.AccountCode);
        }

        [HttpGet("GetProcessedAccountsLedger/{id}", Name = "GetProcessedAccountsLedger")]
        public ProcessedAccountsLedger GetProcessedAccountsLedger(long id) => PAL_Repo.GetFirst(a => a.ProcessedAccountsLedgerId == id);

        [HttpPut("UpdateProcessedAccountsLedger", Name = "UpdateProcessedAccountsLedger")]
        [ValidateModelAttribute]
        public IActionResult UpdateProcessedAccountsLedger([FromBody]ProcessedAccountsLedger model)
        {
            PAL_Repo.Update(model);
            return new OkObjectResult(new { ProcessedAccountsLedgerId = model.ProcessedAccountsLedgerId });
        }

        [HttpPost("AddProcessedAccountsLedgers", Name = "AddProcessedAccountsLedgers")]
        [ValidateModelAttribute]
        public IActionResult AddProcessedAccountsLedgers([FromBody]IEnumerable<ProcessedAccountsLedger> models)
        {
            PAL_Repo.AddRange(models);
            return Ok("Success");
        }

        [HttpDelete("DeleteProcessedAccountsLedger/{id}")]
        public IActionResult DeleteProcessedAccountsLedger(long id)
        {
            return Ok();
        }

        #endregion

        #region Unprocessed Account

        [HttpGet("GetUnprocessedAccountsLedgers", Name = "GetUnprocessedAccountsLedgers")]
        public IEnumerable<UnprocessedAccountsLedger> GetUnprocessedAccountsLedgers()
        {
            return UAL_Repo.GetAll().OrderBy(a => a.AccountCode);
        }

        [HttpGet("GetUnprocessedAccountsLedger/{id}", Name = "GetUnprocessedAccountsLedger")]
        public UnprocessedAccountsLedger GetUnprocessedAccountsLedger(long id) => UAL_Repo.GetFirst(a => a.UnprocessedAccountsLedgerId == id);

        [HttpPut("UpdateUnprocessedAccountsLedger", Name = "UpdateUnprocessedAccountsLedger")]
        [ValidateModelAttribute]
        public IActionResult UpdateUnprocessedAccountsLedger([FromBody]UnprocessedAccountsLedger model)
        {
            UAL_Repo.Update(model);
            return new OkObjectResult(new { UnprocessedAccountsLedgerId = model.UnprocessedAccountsLedgerId });
        }

        [HttpPost("AddUnprocessedAccountsLedgers", Name = "AddUnprocessedAccountsLedgers")]
        [ValidateModelAttribute]
        public IActionResult AddUnprocessedAccountsLedgers([FromBody]IEnumerable<UnprocessedAccountsLedger> models)
        {
            UAL_Repo.AddRange(models);
            return Ok("Success");
        }

        [HttpDelete("DeleteUnprocessedAccountsLedger/{id}")]
        public IActionResult DeleteUnprocessedAccountsLedger(long id)
        {
            try
            {
                UAL_Repo.Delete(UAL_Repo.Find(id));
                return Ok("Deleted");
            }
            catch (NullReferenceException)
            {
                return BadRequest("Invalid Id");
            }
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
            if (model.IsFinal == true)
            {
                PostedVoucher PV = new PostedVoucher()
                {
                    VoucherId = model.VoucherId,
                    VoucherCode = model.VoucherCode,
                    Date = model.Date,
                    Description = model.Description,
                    TotalCreditAmount = model.TotalCreditAmount,
                    TotalDebitAmount = model.TotalDebitAmount,
                    FinancialYearId = model.FinancialYearId,
                    VoucherTypeId = model.VoucherTypeId
                };

                IEnumerable<UnprocessedAccountsLedger> UALs = UAL_Repo.GetList(a => a.IsGeneralOrDetail == false);
                IList<UnprocessedAccountsLedger> UpdateUALs = new List<UnprocessedAccountsLedger>();
                IList<VoucherDetail> UpdateVoucherDetails = new List<VoucherDetail>();

                foreach (VoucherDetail VD in model.VoucherDetails)
                {
                    UnprocessedAccountsLedger UL = UALs.FirstOrDefault(a => a.AccountId == VD.AccountId);
                    VD.AccountBalanceAmountBeforePosting = UL.CurrentBalance;
                    UL.TotalDebit += VD.DebitAmount;
                    UL.TotalCredit += VD.CreditAmount;
                    UL.CurrentBalance = UL.CurrentBalance - VD.DebitAmount + VD.CreditAmount;
                    VD.AccountBalanceAmountAfterPosting = UL.CurrentBalance;

                    UpdateUALs.Add(UL);
                    UpdateVoucherDetails.Add(VD);
                }

                UAL_Repo.UpdateRange(UpdateUALs);

                PostedVou_repo.Add(PV);
                model.PostedVoucherId = PV.PostedVoucherId;

                VouDetail_repo.UpdateRange(UpdateVoucherDetails);
                model.VoucherDetails = null;
            }
            else if (model.IsFinal == false)
            {
                UnpostedVoucher UV = new UnpostedVoucher()
                {
                    VoucherId = model.VoucherId,
                    VoucherCode = model.VoucherCode,
                    Date = model.Date,
                    Description = model.Description,
                    TotalCreditAmount = model.TotalCreditAmount,
                    TotalDebitAmount = model.TotalDebitAmount,
                    FinancialYearId = model.FinancialYearId,
                    VoucherTypeId = model.VoucherTypeId
                };

                UnpostedVou_repo.Add(UV);
                model.UnpostedVoucherId = UV.UnpostedVoucherId;
            }
            Vou_repo.Update(model);
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
            else if (fin.IsFinal == true)
            {
                return BadRequest("Can't delete posted vouchers");
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
            catch (Exception e)
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

        #region Unposted Voucher

        [HttpGet("GetUnpostedVouchers", Name = "GetUnpostedVouchers")]
        public IEnumerable<UnpostedVoucherViewModel> GetUnpostedVouchers()
        {
            IList<UnpostedVoucherViewModel> ViewModels = new List<UnpostedVoucherViewModel>();
            foreach (UnpostedVoucher UV in UnpostedVou_repo.GetAll())
            {
                UnpostedVoucherViewModel UVVM = new UnpostedVoucherViewModel()
                {
                    UnpostedVoucherId = UV.UnpostedVoucherId,
                    VoucherId = UV.VoucherId,
                    Date = UV.Date,
                    Description = UV.Description,
                    TotalCreditAmount = UV.TotalCreditAmount,
                    TotalDebitAmount = UV.TotalDebitAmount,
                    FinancialYear = FinancialYear_Repo.GetFirst(a => a.FinancialYearId == UV.FinancialYearId),
                    VoucherType = VoucherType_Repo.GetFirst(a => a.VoucherTypeId == UV.VoucherTypeId),
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == UV.VoucherId, b => b.Account)
                };
                ViewModels.Add(UVVM);
            }
            return ViewModels;
        }

        [HttpGet("GetUnpostedVoucher/{id}", Name = "GetUnpostedVoucher")]
        public IActionResult GetUnpostedVoucher(long id)
        {
            try
            {
                UnpostedVoucher UV = UnpostedVou_repo.Find(id);
                return Json(new UnpostedVoucherViewModel()
                    {
                        UnpostedVoucherId = UV.UnpostedVoucherId,
                        VoucherId = UV.VoucherId,
                        Date = UV.Date,
                        Description = UV.Description,
                        TotalCreditAmount = UV.TotalCreditAmount,
                        TotalDebitAmount = UV.TotalDebitAmount,
                        FinancialYear = FinancialYear_Repo.GetFirst(a => a.FinancialYearId == UV.FinancialYearId),
                        VoucherType = VoucherType_Repo.GetFirst(a => a.VoucherTypeId == UV.VoucherTypeId),
                        VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == UV.VoucherId, b => b.Account)
                    }
                );
            }
            catch (NullReferenceException)
            {
                return BadRequest("Invalid Id");
            }
        }

        [HttpPut("UpdateUnpostedVoucher", Name = "UpdateUnpostedVoucher")]
        public IActionResult UpdateUnpostedVoucher(UnpostedVoucherViewModel model)
        {
            Voucher V = Vou_repo.GetFirst(a => a.VoucherId == model.VoucherId);
            V.Date = model.Date;
            V.Description = model.Description;
            V.TotalCreditAmount = model.TotalCreditAmount;
            V.TotalDebitAmount = model.TotalDebitAmount;
            V.IsFinal = model.Posted;
            V.FinancialYearId = model.FinancialYearId;
            V.VoucherType = model.VoucherType;
            VouDetail_repo.DeleteRange(VouDetail_repo.GetList(a => a.VoucherId == V.VoucherId));
            V.VoucherDetails = model.VoucherDetails;

            UnpostedVoucher UV = UnpostedVou_repo.GetFirst(a => a.VoucherId == model.VoucherId && a.UnpostedVoucherId == model.UnpostedVoucherId);
            V.UnpostedVoucherId = UV.UnpostedVoucherId;

            if (model.Posted == true)
            {
                PostedVoucher PV = new PostedVoucher()
                {
                    VoucherId = UV.VoucherId,
                    VoucherCode = UV.VoucherCode,
                    Date = model.Date,
                    Description = model.Description,
                    TotalCreditAmount = model.TotalCreditAmount,
                    TotalDebitAmount = model.TotalDebitAmount,
                    FinancialYearId = model.FinancialYearId,
                    VoucherTypeId = model.VoucherTypeId
                };

                PostedVou_repo.Add(PV);
                V.IsFinal = true;
                V.PostedVoucherId = PV.PostedVoucherId;

                IEnumerable<UnprocessedAccountsLedger> UALs = UAL_Repo.GetList(a => a.IsGeneralOrDetail == false);
                IList<UnprocessedAccountsLedger> UpdateUALs = new List<UnprocessedAccountsLedger>();
                IList<VoucherDetail> updateVoucherDetails = new List<VoucherDetail>();

                foreach (VoucherDetail VD in V.VoucherDetails)
                {
                    UnprocessedAccountsLedger UL = UALs.FirstOrDefault(a => a.AccountId == VD.AccountId);
                    VD.AccountBalanceAmountBeforePosting = UL.CurrentBalance;
                    UL.TotalDebit += VD.DebitAmount;
                    UL.TotalCredit += VD.CreditAmount;
                    UL.CurrentBalance = UL.CurrentBalance - VD.DebitAmount + VD.CreditAmount;
                    VD.AccountBalanceAmountAfterPosting = UL.CurrentBalance;

                    UpdateUALs.Add(UL);
                    updateVoucherDetails.Add(VD);
                };
                UAL_Repo.UpdateRange(UpdateUALs);
                UnpostedVou_repo.Delete(UV);

                V.VoucherDetails = null;
                VouDetail_repo.UpdateRange(updateVoucherDetails);
            }
            else if(model.Posted == false)
            {
                UV.Date = model.Date;
                UV.Description = model.Description;
                UV.TotalDebitAmount = model.TotalDebitAmount;
                UV.TotalCreditAmount = model.TotalCreditAmount;
                UV.FinancialYearId = model.FinancialYearId;
                UV.VoucherTypeId = model.VoucherTypeId;

                UnpostedVou_repo.Update(UV);
                V.UnpostedVoucherId = UV.UnpostedVoucherId;
                V.IsFinal = false;
            }
            
            Vou_repo.Update(V);
            return Ok("Updated");
        }

        [HttpDelete("DeleteUnpostedVoucher/{id}", Name = "DeleteUnpostedVoucher")]
        public IActionResult DeleteUnpostedVoucher(long id)
        {
            try
            {
                UnpostedVoucher UV = UnpostedVou_repo.GetFirst(a => a.UnpostedVoucherId == id);
                Voucher V = Vou_repo.GetFirst(a => a.VoucherId == UV.VoucherId);
                if (V.IsFinal == true)
                {
                    return BadRequest("Posted Vouchers can't be deleted");
                }
                UnpostedVou_repo.Delete(UV);
                Vou_repo.Delete(V);
                VouDetail_repo.DeleteRange(VouDetail_repo.GetList(a => a.VoucherId == V.VoucherId));
                return Ok("Deleted");
            }
            catch(NullReferenceException)
            {
                return BadRequest("Invalid Voucher");
            }
        }

        #endregion

        #region Posted Voucher

        [HttpGet("GetPostedVouchers", Name = "GetPostedVouchers")]
        public IEnumerable<PostedVoucherViewModel> GetPostedVouchers()
        {
            IList<PostedVoucherViewModel> PVVMs = new List<PostedVoucherViewModel>();
            foreach (PostedVoucher PV in PostedVou_repo.GetAll())
            {
                PostedVoucherViewModel PVVM = new PostedVoucherViewModel()
                {
                    PostedVoucherId = PV.PostedVoucherId,
                    VoucherId = PV.VoucherId,
                    Date = PV.Date,
                    Description = PV.Description,
                    TotalCreditAmount = PV.TotalCreditAmount,
                    TotalDebitAmount = PV.TotalDebitAmount,
                    FinancialYear = FinancialYear_Repo.GetFirst(a => a.FinancialYearId == PV.FinancialYearId),
                    VoucherType = VoucherType_Repo.GetFirst(a => a.VoucherTypeId == PV.VoucherTypeId),
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == PV.VoucherId)
                };
                PVVMs.Add(PVVM);
            }
            return PVVMs;
        }

        [HttpGet("GetPostedVouchersByFinancialYear/{id}", Name = "GetPostedVouchersByFinancialYear")]
        public IEnumerable<PostedVoucherViewModel> GetPostedVouchersByFinancialYear(long id)
        {
            IList<PostedVoucherViewModel> PVVMs = new List<PostedVoucherViewModel>();
            foreach (PostedVoucher PV in PostedVou_repo.GetList(a => a.FinancialYearId == id))
            {
                PostedVoucherViewModel PVVM = new PostedVoucherViewModel()
                {
                    PostedVoucherId = PV.PostedVoucherId,
                    VoucherId = PV.VoucherId,
                    Date = PV.Date,
                    Description = PV.Description,
                    TotalCreditAmount = PV.TotalCreditAmount,
                    TotalDebitAmount = PV.TotalDebitAmount,
                    FinancialYear = FinancialYear_Repo.GetFirst(a => a.FinancialYearId == PV.FinancialYearId),
                    VoucherType = VoucherType_Repo.GetFirst(a => a.VoucherTypeId == PV.VoucherTypeId),
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == PV.VoucherId)
                };
                PVVMs.Add(PVVM);
            }
            return PVVMs;
        }

        [HttpGet("GetPostedVouchersByDateRange/{fromdate}/{todate}", Name = "GetPostedVouchersByDateRange")]
        public IEnumerable<PostedVoucherViewModel> GetPostedVouchersByDateRange(DateTime fromdate, DateTime todate)
        {
            IList<PostedVoucherViewModel> PVVMs = new List<PostedVoucherViewModel>();
            foreach (PostedVoucher PV in PostedVou_repo.GetList(a => a.Date >= fromdate && a.Date <= todate))
            {
                PostedVoucherViewModel PVVM = new PostedVoucherViewModel()
                {
                    PostedVoucherId = PV.PostedVoucherId,
                    VoucherId = PV.VoucherId,
                    Date = PV.Date,
                    Description = PV.Description,
                    TotalCreditAmount = PV.TotalCreditAmount,
                    TotalDebitAmount = PV.TotalDebitAmount,
                    FinancialYear = FinancialYear_Repo.GetFirst(a => a.FinancialYearId == PV.FinancialYearId),
                    VoucherType = VoucherType_Repo.GetFirst(a => a.VoucherTypeId == PV.VoucherTypeId),
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == PV.VoucherId)
                };
                PVVMs.Add(PVVM);
            }
            return PVVMs;
        }

        #endregion
    }
}