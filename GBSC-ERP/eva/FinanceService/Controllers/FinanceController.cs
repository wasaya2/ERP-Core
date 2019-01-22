using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.Finance;
using ErpCore.Entities.FinanceSetup;
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
        private ITransactionAccountRepository UAL_Repo;

        private IVoucherRepository Vou_repo;
        private IVoucherDetailRepository VouDetail_repo;
        private IPostedVoucherRepository PostedVou_repo;
        private IUnpostedVoucherRepository UnpostedVou_repo;

        private IFinancialYearRepository FinancialYear_Repo;
        private IVoucherTypeRepository VoucherType_Repo;

        public FinanceController(IAccountRepository accountrepo, IVoucherRepository vourepo, IVoucherDetailRepository voudetailrepo,
                                    ITransactionAccountRepository ualrepo,
                                    IPostedVoucherRepository postvourepo, IUnpostedVoucherRepository unpostvourepo,
                                    IFinancialYearRepository financeyearrepo, IVoucherTypeRepository vouchertyperepo)
        {
            Account_Repo = accountrepo;
            UAL_Repo = ualrepo;

            Vou_repo = vourepo;
            VouDetail_repo = voudetailrepo;
            PostedVou_repo = postvourepo;
            UnpostedVou_repo = unpostvourepo;

            FinancialYear_Repo = financeyearrepo;
            VoucherType_Repo = vouchertyperepo;
        }

        //[HttpGet("GetVoucherPermissions/{userid}/{RoleId}/{featureid}", Name = "GetVoucherPermissions")]
        //public IEnumerable<Permission> GetPurchassePermissions(long userid, long RoleId, long featureid)
        //{
        //    IEnumerable<Permission> per = Vou_repo.GetFeaturePermissions(userid, RoleId, featureid).Permissions.ToList();
        //    return per;
        //}

        #region Account

        [HttpGet("GetAccounts", Name = "GetAccounts")]
        public IEnumerable<Account> GetAccounts()
        {
            return Account_Repo.GetAll(a => a.FinancialYear).OrderByDescending(a => a.FinancialYearId).ThenBy(a => a.AccountCode);
        }

        [HttpGet("GetAccountsByCompany/{companyid}", Name = "GetAccountsByCompany")]
        public IEnumerable<Account> GetAccountsByCompany([FromRoute]long companyid)
        {
            return Account_Repo.GetList(a => a.CompanyId == companyid, b => b.FinancialYear).OrderByDescending(a => a.FinancialYearId).ThenBy(a => a.AccountCode);
        }

        [HttpGet("GetAccount/{id}", Name = "GetAccount")]
        public Account GetAccount(long id) => Account_Repo.GetFirst(a => a.AccountId == id);

        [HttpPut("UpdateAccount", Name = "UpdateAccount")]
        [ValidateModelAttribute]
        public IActionResult UpdateAccount([FromBody]Account model)
        {
            Account updateAccount = Account_Repo.Find(model.AccountId);
            if (updateAccount.IsGeneralOrDetail == false)
            {
                updateAccount.OpeningBalance = model.OpeningBalance;
                TransactionAccount UAL = UAL_Repo.GetFirst(a => a.AccountId == model.AccountId);
                UAL.Description = model.Description;
                UAL.OpeningBalance = model.OpeningBalance;
                UAL_Repo.Update(UAL);
            }
            updateAccount.Description = model.Description;
            Account_Repo.Update(updateAccount);
            return new OkObjectResult(new { AccountId = model.AccountId });
        }

        public string GenerateAccountCode(AccountViewModel model)
        {
            if (model.ParentAccountCode != null && model.ParentAccountCode != "" && model.ParentAccountCode != " ")
            {
                try
                {
                    string LastAccountCode = Account_Repo.GetList(a => a.CompanyId == model.CompanyId && a.ParentAccountCode == model.ParentAccountCode).OrderByDescending(a => a.AccountId).FirstOrDefault().AccountCode;
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
                    string LastAccountCode = Account_Repo.GetList(a => a.CompanyId == model.CompanyId && a.AccountCode.Length == 2).OrderByDescending(a => a.AccountId).FirstOrDefault().AccountCode;
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
                CompanyId = model.CompanyId,
                OldAccountId = null,
                FinancialYearId = model.FinancialYearId,
                AccountCode = GenerateAccountCode(model),
                ParentAccountCode = model.ParentAccountCode,
                IsGeneralOrDetail = model.IsGeneralOrDetail,
                AccountLevel = model.ParentAccountLevel + 1,
                Description = model.Description,
                OpeningBalance = model.OpeningBalance,
                TotalCredit = null,
                TotalDebit = null,
                TotalTransactionsAgainstThisAccount = null,
                ClosingBalance = null,
                IsProcessed = false
            };

            Account_Repo.Add(newAccount);

            if(model.IsGeneralOrDetail == false)
            {
                TransactionAccount newUAL = new TransactionAccount()
                {
                    CompanyId = newAccount.CompanyId,
                    AccountId = newAccount.AccountId,
                    FinancialYearId = newAccount.FinancialYearId,
                    AccountCode = newAccount.AccountCode,
                    ParentAccountCode = newAccount.ParentAccountCode,
                    AccountLevel = newAccount.AccountLevel,
                    Description = newAccount.Description,
                    OpeningBalance = newAccount.OpeningBalance,
                    TotalCredit = 0,
                    TotalDebit = 0,
                    CurrentBalance = newAccount.OpeningBalance,
                    TotalTransactionsAgainstThisAccount = 0
                };

                UAL_Repo.Add(newUAL);
            }

            return new OkObjectResult(new { AccountId = newAccount.AccountId });
        }

        [HttpDelete("DeleteAccount/{id}")]
        public IActionResult DeleteAccount(long id)
        {
            return BadRequest("Restricted");
        }

        [HttpGet("GetCurrentlyActiveAccounts", Name = "GetCurrentlyActiveAccounts")]
        public IEnumerable<Account> GetCurrentlyActiveAccounts()
        {
            return Account_Repo.GetList(a => a.FinancialYearId != null && a.IsProcessed != true && a.FinancialYearId == FinancialYear_Repo.GetFirst(b => b.IsActive == true).FinancialYearId); 
        }


        [HttpGet("GetCurrentlyActiveAccountsByCompany/{companyid}", Name = "GetCurrentlyActiveAccountsByCompany")]
        public IEnumerable<Account> GetCurrentlyActiveAccountsByCompany([FromRoute]long companyid)
        {
            return Account_Repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid && a.FinancialYearId != null && a.IsProcessed != true && a.FinancialYearId == FinancialYear_Repo.GetFirst(b => b.IsActive == true).FinancialYearId);
        }

        [HttpPost("ProcessAccountsForLedger", Name = "ProcessAccountsForLedger")]
        public IActionResult ProcessAccountsForLedger([FromBody]EndYearProcessRequestViewModel model)
        {
            try
            {
                //Get all unprocessed accounts and transaction accounts for year to be processed
                IEnumerable<Account> UnprocessedAccounts = Account_Repo.GetList(a => a.CompanyId != null && a.CompanyId == model.CompanyId && a.FinancialYearId != null && a.IsProcessed != true && a.FinancialYearId == FinancialYear_Repo.GetFirst(b => b.IsActive == true).FinancialYearId);
                IEnumerable<TransactionAccount> OldTransactionAccounts = UAL_Repo.GetList(a => a.CompanyId != null && a.CompanyId == model.CompanyId && a.FinancialYearId != null && a.FinancialYearId == FinancialYear_Repo.GetFirst(b => b.IsActive == true).FinancialYearId);

                //Add new Accounts
                IList<Account> newAccounts = new List<Account>();
                foreach (Account UnprocessedAccount in UnprocessedAccounts)
                {
                    Account NewAccount = new Account()
                    {
                        CompanyId = model.CompanyId,
                        OldAccountId = UnprocessedAccount.AccountId,
                        FinancialYearId = model.NewFinancialYearCoaId,
                        AccountCode = UnprocessedAccount.AccountCode,
                        ParentAccountCode = UnprocessedAccount.ParentAccountCode,
                        IsGeneralOrDetail = UnprocessedAccount.IsGeneralOrDetail,
                        AccountLevel = UnprocessedAccount.AccountLevel,
                        Description = UnprocessedAccount.Description,
                        OpeningBalance = OldTransactionAccounts.FirstOrDefault(a => a.AccountId == UnprocessedAccount.AccountId).CurrentBalance,
                        TotalCredit = null,
                        TotalDebit = null,
                        TotalTransactionsAgainstThisAccount = null,
                        ClosingBalance = null,
                        IsProcessed = false
                    };
                    newAccounts.Add(NewAccount);
                }
                Account_Repo.AddRange(newAccounts);

                //Add new Transaction Accounts
                IList<TransactionAccount> newTransactionAccounts = new List<TransactionAccount>();
                foreach (Account account in newAccounts.Where(a => a.IsGeneralOrDetail == false).ToList())
                {
                    TransactionAccount newTransactionAccount = new TransactionAccount()
                    {
                        CompanyId = model.CompanyId,
                        AccountId = account.AccountId,
                        FinancialYearId = model.NewFinancialYearCoaId,
                        AccountCode = account.AccountCode,
                        ParentAccountCode = account.ParentAccountCode,
                        AccountLevel = account.AccountLevel,
                        Description = account.Description,
                        OpeningBalance = account.OpeningBalance,
                        TotalCredit = 0,
                        TotalDebit = 0,
                        CurrentBalance = account.OpeningBalance,
                        TotalTransactionsAgainstThisAccount = 0
                    };
                    newTransactionAccounts.Add(newTransactionAccount);
                }
                UAL_Repo.AddRange(newTransactionAccounts);

                //Update processed accounts
                IList<Account> UpdateOldAccounts = new List<Account>();
                foreach (Account acc in UnprocessedAccounts)
                {
                    acc.IsProcessed = true;
                    acc.TotalCredit = OldTransactionAccounts.FirstOrDefault(a => a.AccountId == acc.AccountId).TotalCredit;
                    acc.TotalDebit = OldTransactionAccounts.FirstOrDefault(a => a.AccountId == acc.AccountId).TotalDebit;
                    acc.TotalTransactionsAgainstThisAccount = OldTransactionAccounts.FirstOrDefault(a => a.AccountId == acc.AccountId).TotalTransactionsAgainstThisAccount;
                    acc.ClosingBalance = OldTransactionAccounts.FirstOrDefault(a => a.AccountId == acc.AccountId).CurrentBalance;
                    UpdateOldAccounts.Add(acc);
                }
                Account_Repo.UpdateRange(UpdateOldAccounts);

                //Delete Old Transaction Accounts
                UAL_Repo.DeleteRange(OldTransactionAccounts);

                //Update the financial year and set the new year as active
                FinancialYear OldYear = FinancialYear_Repo.GetFirst(b => b.IsActive == true);
                OldYear.IsActive = false;
                FinancialYear NewYear = FinancialYear_Repo.GetFirst(c => c.FinancialYearId == model.NewFinancialYearCoaId);
                NewYear.IsActive = true;
                IList<FinancialYear> UpdateYears = new List<FinancialYear>() { OldYear, NewYear };
                FinancialYear_Repo.UpdateRange(UpdateYears);

                return Ok("Processed");
            }
            catch (Exception)
            {
                return BadRequest("Unable to process");
            }
        }

        [HttpGet("GetMasterAccountsByCompany/{companyid}", Name = "GetMasterAccountsByCompany")]
        public IEnumerable<Account> GetMasterAccountsByCompany([FromRoute]long companyid)
        {
            return Account_Repo.GetList(a => a.CompanyId == companyid && a.AccountCode.Length == 2 && a.AccountLevel == 1).ToList().OrderBy(a => a.AccountCode);
        }

        #endregion

        #region Transaction Account

        [HttpGet("GetTransactionAccounts", Name = "GetTransactionAccounts")]
        public IEnumerable<TransactionAccount> GetTransactionAccounts()
        {
            return UAL_Repo.GetAll().OrderBy(a => a.AccountCode);
        }

        [HttpGet("GetTransactionAccountsByCompany/{companyid}", Name = "GetTransactionAccountsByCompany")]
        public IEnumerable<TransactionAccount> GetTransactionAccountsByCompany([FromRoute]long companyid)
        {
            return UAL_Repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid).OrderBy(a => a.AccountCode);
        }

        [HttpGet("GetTransactionAccount/{id}", Name = "GetTransactionAccount")]
        public TransactionAccount GetTransactionAccount(long id) => UAL_Repo.GetFirst(a => a.TransactionAccountId == id);

        [HttpPut("UpdateTransactionAccount", Name = "UpdateTransactionAccount")]
        [ValidateModelAttribute]
        public IActionResult UpdateTransactionAccount([FromBody]TransactionAccount model)
        {
            UAL_Repo.Update(model);
            return new OkObjectResult(new { UnprocessedAccountsLedgerId = model.TransactionAccountId });
        }

        [HttpPost("AddTransactionAccounts", Name = "AddTransactionAccounts")]
        [ValidateModelAttribute]
        public IActionResult AddTransactionAccounts([FromBody]IEnumerable<TransactionAccount> models)
        {
            UAL_Repo.AddRange(models);
            return Ok("Success");
        }

        [HttpDelete("DeleteTransactionAccount/{id}")]
        public IActionResult DeleteTransactionAccount(long id)
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

        [HttpGet("GetVouchersByCompany/{companyid}", Name = "GetVouchersByCompany")]
        public IEnumerable<Voucher> GetVouchersByCompany([FromRoute]long companyid)
        {
            return Vou_repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid).OrderByDescending(a => a.VoucherId);
        }

        [HttpGet("GetVoucher/{id}", Name = "GetVoucher")]
        public Voucher GetVoucher([FromRoute]long id) => Vou_repo.GetFirst(a => a.VoucherId == id, b => b.VoucherDetails);

        [HttpPut("UpdateVoucher", Name = "UpdateVoucher")]
        [ValidateModelAttribute]
        public IActionResult UpdateVoucher([FromBody]Voucher model)
        {
            try
            {
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
                    CompanyId = model.CompanyId,
                    VoucherId = model.VoucherId,
                    VoucherCode = model.VoucherCode,
                    Date = model.Date,
                    Description = model.Description,
                    TotalCreditAmount = model.TotalCreditAmount,
                    TotalDebitAmount = model.TotalDebitAmount,
                    FinancialYearId = model.FinancialYearId,
                    VoucherTypeId = model.VoucherTypeId,
                    CreatedAt = DateTime.Now
                };

                IEnumerable<TransactionAccount> UALs = UAL_Repo.GetAll();
                IList<TransactionAccount> UpdateUALs = new List<TransactionAccount>();
                IList<VoucherDetail> UpdateVoucherDetails = new List<VoucherDetail>();

                foreach (VoucherDetail VD in model.VoucherDetails)
                {
                    TransactionAccount UL = UALs.FirstOrDefault(a => a.AccountId == VD.AccountId);
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
                model.VoucherDetails = UpdateVoucherDetails;
            }
            else if (model.IsFinal == false || model.IsFinal == null)
            {
                UnpostedVoucher UV = new UnpostedVoucher()
                {
                    CompanyId = model.CompanyId,
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
        public IActionResult DeleteVoucher([FromRoute]long id)
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
            VouDetail_repo.DeleteRange(VouDetail_repo.GetList(a => a.VoucherId == fin.VoucherId));
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

        [HttpGet("GetVoucherDetailsByCompany/{companyid}", Name = "GetVoucherDetailsByCompany")]
        public IEnumerable<VoucherDetail> GetVoucherDetailsByCompany([FromRoute]long companyid)
        {
            return VouDetail_repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid).OrderByDescending(a => a.VoucherDetailId);
        }

        [HttpGet("GetVoucherDetail/{id}", Name = "GetVoucherDetail")]
        public VoucherDetail GetVoucherDetail([FromRoute]long id) => VouDetail_repo.GetFirst(a => a.VoucherDetailId == id);

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
        public IActionResult DeleteVoucherDetail([FromRoute]long id)
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

        [HttpGet("GetUnpostedVouchersByCompany/{companyid}", Name = "GetUnpostedVouchersByCompany")]
        public IEnumerable<UnpostedVoucherViewModel> GetUnpostedVouchersByCompany([FromRoute]long companyid)
        {
            IList<UnpostedVoucherViewModel> ViewModels = new List<UnpostedVoucherViewModel>();
            foreach (UnpostedVoucher UV in UnpostedVou_repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid))
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
        public IActionResult GetUnpostedVoucher([FromRoute]long id)
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
        public IActionResult UpdateUnpostedVoucher([FromBody]UnpostedVoucherViewModel model)
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
                    VoucherTypeId = model.VoucherTypeId,
                    CreatedAt = DateTime.Now
                };

                PostedVou_repo.Add(PV);
                V.IsFinal = true;
                V.PostedVoucherId = PV.PostedVoucherId;

                IEnumerable<TransactionAccount> UALs = UAL_Repo.GetAll();
                IList<TransactionAccount> UpdateUALs = new List<TransactionAccount>();
                IList<VoucherDetail> updateVoucherDetails = new List<VoucherDetail>();

                foreach (VoucherDetail VD in V.VoucherDetails)
                {
                    TransactionAccount UL = UALs.FirstOrDefault(a => a.AccountId == VD.AccountId);
                    VD.AccountBalanceAmountBeforePosting = UL.CurrentBalance;
                    UL.TotalTransactionsAgainstThisAccount += 1;
                    UL.TotalDebit += VD.DebitAmount;
                    UL.TotalCredit += VD.CreditAmount;
                    UL.CurrentBalance = UL.CurrentBalance - VD.DebitAmount + VD.CreditAmount;
                    VD.AccountBalanceAmountAfterPosting = UL.CurrentBalance;

                    UpdateUALs.Add(UL);
                    updateVoucherDetails.Add(VD);
                };
                UAL_Repo.UpdateRange(UpdateUALs);
                UnpostedVou_repo.Delete(UV);

                V.VoucherDetails = updateVoucherDetails;
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
        public IActionResult DeleteUnpostedVoucher([FromRoute]long id)
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
                VouDetail_repo.DeleteRange(VouDetail_repo.GetList(a => a.VoucherId == V.VoucherId));
                Vou_repo.Delete(V);
                return Ok("Deleted");
            }
            catch(NullReferenceException)
            {
                return BadRequest("Invalid Voucher");
            }
        }

        [HttpPost("PostUnpostedVouchers", Name = "PostUnpostedVouchers")]
        public IActionResult PostUnpostedVouchers ([FromBody]IEnumerable<UnpostedVoucherViewModel> models)
        {
            IList<Voucher> Vs = new List<Voucher>();
            IList<UnpostedVoucher> UVs = new List<UnpostedVoucher>();

            IList<TransactionAccount> UpdateUALs = new List<TransactionAccount>();
            IList<VoucherDetail> updateVoucherDetails = new List<VoucherDetail>();

            IEnumerable<TransactionAccount> UALs = UAL_Repo.GetAll();

            foreach (UnpostedVoucherViewModel model in models)
            {
                PostedVoucher PV = new PostedVoucher()
                {
                    CompanyId = model.CompanyId,
                    VoucherId = model.VoucherId,
                    VoucherCode = model.VoucherCode,
                    Date = model.Date,
                    Description = model.Description,
                    TotalCreditAmount = model.TotalCreditAmount,
                    TotalDebitAmount = model.TotalDebitAmount,
                    FinancialYearId = model.FinancialYearId,
                    VoucherTypeId = model.VoucherTypeId,
                    CreatedAt = DateTime.Now
                };
                PostedVou_repo.Add(PV);

                Voucher V = Vou_repo.GetFirst(a => a.VoucherId == model.VoucherId);
                V.PostedVoucherId = PV.PostedVoucherId;
                V.IsFinal = true;

                foreach (VoucherDetail VD in model.VoucherDetails)
                {
                    TransactionAccount UL = UALs.FirstOrDefault(a => a.AccountId == VD.AccountId);
                    VD.AccountBalanceAmountBeforePosting = UL.CurrentBalance;
                    UL.TotalTransactionsAgainstThisAccount += 1;
                    UL.TotalDebit += VD.DebitAmount;
                    UL.TotalCredit += VD.CreditAmount;
                    UL.CurrentBalance = UL.CurrentBalance - VD.DebitAmount + VD.CreditAmount;
                    VD.AccountBalanceAmountAfterPosting = UL.CurrentBalance;

                    UpdateUALs.Add(UL);
                    updateVoucherDetails.Add(VD);
                };

                V.VoucherDetails = updateVoucherDetails;
                Vs.Add(V);
                UVs.Add(UnpostedVou_repo.Find(model.UnpostedVoucherId));
            }

            Vou_repo.UpdateRange(Vs);
            UAL_Repo.UpdateRange(UpdateUALs);

            UnpostedVou_repo.DeleteRange(UVs);
            return Ok("Posted");
        }

        [HttpPost("PostUnpostedVoucher", Name = "PostUnpostedVoucher")]
        public IActionResult PostUnpostedVoucher([FromBody]UnpostedVoucherViewModel model)
        {
            IList<TransactionAccount> UpdateUALs = new List<TransactionAccount>();
            IList<VoucherDetail> updateVoucherDetails = new List<VoucherDetail>();
            
            PostedVoucher PV = new PostedVoucher()
            {
                CompanyId = model.CompanyId,
                VoucherId = model.VoucherId,
                VoucherCode = model.VoucherCode,
                Date = model.Date,
                Description = model.Description,
                TotalCreditAmount = model.TotalCreditAmount,
                TotalDebitAmount = model.TotalDebitAmount,
                FinancialYearId = model.FinancialYearId,
                VoucherTypeId = model.VoucherTypeId,
                CreatedAt = DateTime.Now
            };
            PostedVou_repo.Add(PV);

            Voucher V = Vou_repo.GetFirst(a => a.VoucherId == model.VoucherId, b => b.VoucherDetails);
            V.PostedVoucherId = PV.PostedVoucherId;
            V.IsFinal = true;

            IEnumerable<TransactionAccount> UALs = UAL_Repo.GetAll();
            foreach (VoucherDetail VD in V.VoucherDetails)
            {
                TransactionAccount UL = UALs.FirstOrDefault(a => a.AccountId == VD.AccountId);
                VD.AccountBalanceAmountBeforePosting = UL.CurrentBalance;
                UL.TotalTransactionsAgainstThisAccount += 1;
                UL.TotalDebit += VD.DebitAmount;
                UL.TotalCredit += VD.CreditAmount;
                UL.CurrentBalance = UL.CurrentBalance - VD.DebitAmount + VD.CreditAmount;
                VD.AccountBalanceAmountAfterPosting = UL.CurrentBalance;

                UpdateUALs.Add(UL);
                updateVoucherDetails.Add(VD);
            };
            V.VoucherDetails = updateVoucherDetails;
            Vou_repo.Update(V);
            UAL_Repo.UpdateRange(UpdateUALs);

            UnpostedVou_repo.Delete(UnpostedVou_repo.Find(model.UnpostedVoucherId));
            return Ok("Posted");
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
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == PV.VoucherId, b => b.Account)
                };
                PVVMs.Add(PVVM);
            }
            return PVVMs;
        }

        [HttpGet("GetPostedVouchersByCompany/{companyid}", Name = "GetPostedVouchersByCompany")]
        public IEnumerable<PostedVoucherViewModel> GetPostedVouchersByCompany([FromRoute]long companyid)
        {
            IList<PostedVoucherViewModel> PVVMs = new List<PostedVoucherViewModel>();
            foreach (PostedVoucher PV in PostedVou_repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid))
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
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == PV.VoucherId, b => b.Account)
                };
                PVVMs.Add(PVVM);
            }
            return PVVMs;
        }

        [HttpGet("GetPostedVouchersByFinancialYear/{id}", Name = "GetPostedVouchersByFinancialYear")]
        public IEnumerable<PostedVoucherViewModel> GetPostedVouchersByFinancialYear([FromRoute]long id)
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
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == PV.VoucherId, b => b.Account)
                };
                PVVMs.Add(PVVM);
            }
            return PVVMs;
        }

        [HttpGet("GetPostedVouchersByFinancialYearAndCompany/{id}/{companyid}", Name = "GetPostedVouchersByFinancialYearAndCompany")]
        public IEnumerable<PostedVoucherViewModel> GetPostedVouchersByFinancialYearAndCompany([FromRoute]long id, [FromRoute]long companyid)
        {
            IList<PostedVoucherViewModel> PVVMs = new List<PostedVoucherViewModel>();
            foreach (PostedVoucher PV in PostedVou_repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid && a.FinancialYearId != null && a.FinancialYearId == id))
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
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == PV.VoucherId, b => b.Account)
                };
                PVVMs.Add(PVVM);
            }
            return PVVMs;
        }

        [HttpGet("GetPostedVouchersByDateRange", Name = "GetPostedVouchersByDateRange")]
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
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == PV.VoucherId, b => b.Account)
                };
                PVVMs.Add(PVVM);
            }
            return PVVMs;
        }

        [HttpGet("GetPostedVouchersByDateRangeAndCompany/{companyid}", Name = "GetPostedVouchersByDateRangeAndCompany")]
        public IEnumerable<PostedVoucherViewModel> GetPostedVouchersByDateRangeAndCompany(DateTime fromdate, DateTime todate, [FromRoute]long companyid)
        {
            IList<PostedVoucherViewModel> PVVMs = new List<PostedVoucherViewModel>();
            foreach (PostedVoucher PV in PostedVou_repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid && a.Date.Value.Day >= fromdate.Day && a.Date.Value.Month >= fromdate.Month && a.Date.Value.Year >= fromdate.Year && a.Date.Value.Day >= todate.Day && a.Date.Value.Month >= todate.Month && a.Date.Value.Year >= todate.Year))
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
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == PV.VoucherId, b => b.Account)
                };
                PVVMs.Add(PVVM);
            }
            return PVVMs;
        }

        [HttpGet("GetPostedVouchersByDate", Name = "GetPostedVouchersByDate")]
        public IEnumerable<PostedVoucherViewModel> GetPostedVouchersByDate(DateTime date)
        {
            IList<PostedVoucherViewModel> PVVMs = new List<PostedVoucherViewModel>();
            foreach (PostedVoucher PV in PostedVou_repo.GetList(a => a.Date.Value.Year == date.Year && a.Date.Value.Month == date.Month && a.Date.Value.Day == date.Day))
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
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == PV.VoucherId, b => b.Account)
                };
                PVVMs.Add(PVVM);
            }
            return PVVMs;
        }

        [HttpGet("GetPostedVouchersByDateAndCompany/{companyid}", Name = "GetPostedVouchersByDateAndCompany")]
        public IEnumerable<PostedVoucherViewModel> GetPostedVouchersByDateAndCompany(DateTime date, [FromRoute]long companyid)
        {
            IList<PostedVoucherViewModel> PVVMs = new List<PostedVoucherViewModel>();
            foreach (PostedVoucher PV in PostedVou_repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid && a.Date.Value.Year == date.Year && a.Date.Value.Month == date.Month && a.Date.Value.Day == date.Day))
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
                    VoucherDetails = VouDetail_repo.GetList(a => a.VoucherId == PV.VoucherId, b => b.Account)
                };
                PVVMs.Add(PVVM);
            }
            return PVVMs;
        }

        #endregion

        #region Configure Company Finance Details

        [HttpPost("ConfigureCompanyFinanceDetails", Name = "ConfigureCompanyFinanceDetails")]
        public IActionResult ConfigureCompanyFinanceDetails([FromBody]CompanyFinanceConfigurationViewModel model)
        {
            return Ok(Account_Repo.ConfigureComanyFinanceDetails(model));
        }

        #endregion
    }
}