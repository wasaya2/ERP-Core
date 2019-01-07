using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ErpCore.Entities.HR.Payroll.LoanSetup;
using ErpCore.Entities.HR.Payroll.PayrollSetup;
using ErpCore.Entities.HR.Payroll.TaxSetup;
using ErpCore.Filters;
using Microsoft.AspNetCore.Mvc;
using SystemAdministrationService.Repos.Hr.PayrollRepos;
using SystemAdministrationService.Repos.Hr.PayrollRepos.Interfaces;

namespace SystemAdministrationService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    //[EnableCors("MyPolicy")]
    public class PayrollSetupController : Controller
    {
        private IAllowanceRepository Allowance_repo;
        private IAllowanceDeductionRepository AllowanceDeduction_repo;
        private IAllowanceCalculationTypeRepository AllowanceCalculationType_repo;
        private IAllowanceRateRepository AllowanceRate_repo;
        private IAllowanceArrearRepository AllowanceArrear_repo;
        private IBenefitRepository Benefit_repo;
        private IBankAdviceTemplateRepository BankAdviceTemplate_repo;
        private IChequeTemplateRepository ChequeTemplate_repo;
        private ICompensationTransactionRepository CompensationTransaction_repo;
        private ICurrencyRepository Currency_repo;
        private IFrequencyRepository Frequency_repo;
        private IFundSetupRepository FundSetup_repo;
        private IGratuitySlabRepository GratuitySlab_repo;
        private IGratuitySlabGratuityRepository GratuitySlabGratuity_repo;
        private IGratuityTypeRepository GratuityType_repo;
        private ILeavingReasonRepository LeavingReason_repo;
        private IMasterPayrollRepository MasterPayroll_repo;
        private IMasterPayrollDetailRepository MasterPayrollDetail_repo;
        private IPayrollRepository Payroll_repo;
        private IPayrollBankRepository PayrollBank_repo;
        private IPayrollTypeRepository PayrollType_repo;
        private IPayrollYearRepository PayrollYear_repo;
        private IPfPaymentRepository PfPayment_repo;
        private ISalaryCalculationTypeRepository SalaryCalculationType_repo;
        private ISalaryStructureRepository SalaryStructure_repo;
        private ISalaryStructureDetailRepository SalaryStructureDetail_repo;
        private IUserSalaryRepository UserSalary_repo;
        private IIncomeTaxRuleRepository IncomeTaxRule_repo;
        private ITaxableIncomeAdjustmentRepository TaxableIncomeAdjustment_repo; 
        private ITaxAdjustmentReasonRepository TaxAdjustmentReason_repo;
        private ITaxBenefitRepository TaxBenefit_repo;
        private ITaxReliefRepository TaxRelief_repo;
        private ITaxScheduleRepository TaxSchedule_repo;
        private ITaxYearRepository TaxYear_repo;
        private ILoanTypeRepository LoanType_repo;
        private IUserLoanRepository UserLoan_repo;


        public PayrollSetupController(
          IAllowanceRepository repo1,
          IAllowanceDeductionRepository repo2,
          IAllowanceCalculationTypeRepository repo3,
          IAllowanceRateRepository repo4,
          IAllowanceArrearRepository repo5,
          IBenefitRepository repo6,
          IBankAdviceTemplateRepository repo7,
          IChequeTemplateRepository repo8,
          ICompensationTransactionRepository repo9,
          ICurrencyRepository repo10,
          IFrequencyRepository repo11,
          IFundSetupRepository repo12,
          IGratuitySlabRepository repo13,
          IGratuitySlabGratuityRepository repo14,
          IGratuityTypeRepository repo15,
          ILeavingReasonRepository repo16,
          IMasterPayrollRepository repo17,
          IMasterPayrollDetailRepository repo18,
          IPayrollRepository repo19,
          IPayrollBankRepository repo20,
          IPayrollTypeRepository repo21,
          IPayrollYearRepository repo22,
          IPfPaymentRepository repo23,
          ISalaryCalculationTypeRepository repo24,
          ISalaryStructureRepository repo25,
          ISalaryStructureDetailRepository repo26,
          IUserSalaryRepository repo27,
          IIncomeTaxRuleRepository repo28,
          ITaxableIncomeAdjustmentRepository repo29,
          ITaxAdjustmentReasonRepository repo30,
          ITaxBenefitRepository repo31,
          ITaxReliefRepository repo32,
          ITaxScheduleRepository repo33,
          ITaxYearRepository repo34,
          ILoanTypeRepository repo35,
          IUserLoanRepository repo36  )
    {
            Allowance_repo = repo1;
            AllowanceDeduction_repo = repo2;
            AllowanceCalculationType_repo = repo3;
            AllowanceRate_repo = repo4;
            AllowanceArrear_repo = repo5;
            Benefit_repo = repo6;
            BankAdviceTemplate_repo = repo7;
            ChequeTemplate_repo = repo8;
            CompensationTransaction_repo = repo9;
            Currency_repo = repo10;
            Frequency_repo = repo11;
            FundSetup_repo = repo12;
            GratuitySlab_repo = repo13;
            GratuitySlabGratuity_repo = repo14;
            GratuityType_repo = repo15;
            LeavingReason_repo = repo16;
            MasterPayroll_repo = repo17;
            MasterPayrollDetail_repo = repo18;
            Payroll_repo = repo19;
            PayrollBank_repo = repo20;
            PayrollType_repo = repo21;
            PayrollYear_repo = repo22;
            PfPayment_repo = repo23;
            SalaryCalculationType_repo = repo24;
            SalaryStructure_repo = repo25;
            SalaryStructureDetail_repo = repo26;
            UserSalary_repo = repo27;
            IncomeTaxRule_repo = repo28;
            TaxableIncomeAdjustment_repo = repo29;
            TaxAdjustmentReason_repo = repo30;
            TaxBenefit_repo = repo31;
            TaxRelief_repo = repo32;
            TaxSchedule_repo = repo33;
            TaxYear_repo = repo34; 
            LoanType_repo = repo35; 
            UserLoan_repo = repo36; 
        }

        #region Allowance

        [HttpGet("GetAllowances", Name = "GetAllowances")]
        public IEnumerable<Allowance> GetAllowances()
        {
            return Allowance_repo.GetAll().OrderByDescending(a=>a.AllowanceId);
        }

        [HttpGet("GetAllowance/{id}", Name = "GetAllowance")]
        public Allowance GetAllowance(long id) => Allowance_repo.GetFirst(a => a.AllowanceId == id);

        [HttpPost("AddAllowance", Name = "AddAllowance")]
        [ValidateModelAttribute]
        public IActionResult AddAllowance([FromBody]Allowance model)
        {
            Allowance_repo.Add(model);
            return new OkObjectResult(new { AllowanceID = model.AllowanceId });
        }

        [HttpPut("UpdateAllowance", Name = "UpdateAllowance")]
        [ValidateModelAttribute]
        public IActionResult UpdateAllowance([FromBody]Allowance model)
        {
            Allowance_repo.Update(model);
            return new OkObjectResult(new { AllowanceID = model.AllowanceId });
        }

        [HttpDelete("DeleteAllowance/{id}")]
        public IActionResult DeleteAllowance(long id)
        {
            Allowance a = Allowance_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Allowance_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region AllowanceArrear

        [HttpGet("GetAllowanceArrears", Name = "GetAllowanceArrears")]
        public IEnumerable<AllowanceArrear> GetAllowanceArrears()
        {
            return AllowanceArrear_repo.GetAll().OrderByDescending(a=>a.ArrearAllowanceId);
        }

        [HttpGet("GetAllowanceArrear/{id}", Name = "GetAllowanceArrear")]
        public AllowanceArrear GetAllowanceArrear(long id) => AllowanceArrear_repo.GetFirst(a => a.ArrearAllowanceId == id);

        [HttpPost("AddAllowanceArrear", Name = "AddAllowanceArrear")]
        [ValidateModelAttribute]
        public IActionResult AddAllowanceArrear([FromBody]AllowanceArrear model)
        {
            AllowanceArrear_repo.Add(model);
            return new OkObjectResult(new { ArrearAllowanceID = model.ArrearAllowanceId });
        }

        [HttpPut("UpdateAllowanceArrear", Name = "UpdateAllowanceArrear")]
        [ValidateModelAttribute]
        public IActionResult UpdateAllowanceArrear([FromBody]AllowanceArrear model)
        {
            AllowanceArrear_repo.Update(model);
            return new OkObjectResult(new { ArrearAllowanceID = model.ArrearAllowanceId });
        }

        [HttpDelete("DeleteAllowanceArrear/{id}")]
        public IActionResult DeleteAllowanceArrear(long id)
        {
            AllowanceArrear a = AllowanceArrear_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            AllowanceArrear_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region AllowanceDeduction

        [HttpGet("GetAllowancedeductions", Name = "GetAllowancedeductions")]
        public IEnumerable<AllowanceDeduction> GetAllowancedeductions()
        {
            return AllowanceDeduction_repo.GetAll().OrderByDescending(a=>a.AllowanceDeductionId);
        }

        [HttpGet("GetAllowancededuction/{id}", Name = "GetAllowancededuction")]
        public AllowanceDeduction GetAllowancededuction(long id) => AllowanceDeduction_repo.GetFirst(a => a.AllowanceDeductionId == id);

        [HttpPost("AddAllowancededuction", Name = "AddAllowancededuction")]
        [ValidateModelAttribute]
        public IActionResult AddAllowancededuction([FromBody]AllowanceDeduction model)
        {
            AllowanceDeduction_repo.Add(model);
            return new OkObjectResult(new { AllowanceDeductionID = model.AllowanceDeductionId });
        }

        [HttpPut("UpdateAllowancededuction", Name = "UpdateAllowancededuction")]
        [ValidateModelAttribute]
        public IActionResult UpdateAllowancededuction([FromBody]AllowanceDeduction model)
        {
            AllowanceDeduction_repo.Update(model);
            return new OkObjectResult(new { AllowanceDeductionID = model.AllowanceDeductionId });
        }

        [HttpDelete("DeleteAllowancededuction/{id}")]
        public IActionResult DeleteAllowancededuction(long id)
        {
            AllowanceDeduction a = AllowanceDeduction_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            AllowanceDeduction_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region AllowanceCalculationType

        [HttpGet("GetAllowanceCalculationTypes", Name = "GetAllowanceCalculationTypes")]
        public IEnumerable<AllowanceCalculationType> GetAllowanceCalculationTypes()
        {
            return AllowanceCalculationType_repo.GetAll().OrderByDescending(a=>a.AllowanceCalculationTypeId);
        }

        [HttpGet("GetAllowanceCalculationType/{id}", Name = "GetAllowanceCalculationType")]
        public AllowanceCalculationType GetAllowanceCalculationType(long id) => AllowanceCalculationType_repo.GetFirst(a => a.AllowanceCalculationTypeId == id);

        [HttpPost("AddAllowanceCalculationType", Name = "AddAllowanceCalculationType")]
        [ValidateModelAttribute]
        public IActionResult AddAllowanceCalculationType([FromBody]AllowanceCalculationType model)
        {
            AllowanceCalculationType_repo.Add(model);
            return new OkObjectResult(new { AllowanceCalculationTypeID = model.AllowanceCalculationTypeId });
        }

        [HttpPut("UpdateAllowanceCalculationType", Name = "UpdateAllowanceCalculationType")]
        [ValidateModelAttribute]
        public IActionResult UpdateAllowanceCalculationType([FromBody]AllowanceCalculationType model)
        {
            AllowanceCalculationType_repo.Update(model);
            return new OkObjectResult(new { AllowanceCalculationTypeID = model.AllowanceCalculationTypeId });
        }

        [HttpDelete("DeleteAllowanceCalculationType/{id}")]
        public IActionResult DeleteAllowanceCalculationType(long id)
        {
            AllowanceCalculationType a = AllowanceCalculationType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            AllowanceCalculationType_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region AllowanceRate

        [HttpGet("GetAllowanceRates", Name = "GetAllowanceRates")]
        public IEnumerable<AllowanceRate> GetAllowanceRates()
        {
            return AllowanceRate_repo.GetAll().OrderByDescending(a=>a.AllowanceRateId);
        }

        [HttpGet("GetAllowanceRate/{id}", Name = "GetAllowanceRate")]
        public AllowanceRate GetAllowanceRate(long id) => AllowanceRate_repo.GetFirst(a => a.AllowanceRateId == id);

        [HttpPost("AddAllowanceRate", Name = "AddAllowanceRate")]
        [ValidateModelAttribute]
        public IActionResult AddAllowanceRate([FromBody]AllowanceRate model)
        {
            AllowanceRate_repo.Add(model);
            return new OkObjectResult(new { AllowanceRateID = model.AllowanceRateId });
        }

        [HttpPut("UpdateAllowanceRate", Name = "UpdateAllowanceRate")]
        [ValidateModelAttribute]
        public IActionResult UpdateAllowanceRate([FromBody]AllowanceRate model)
        {
            AllowanceRate_repo.Update(model);
            return new OkObjectResult(new { AllowanceRateID = model.AllowanceRateId });
        }

        [HttpDelete("DeleteAllowanceRate/{id}")]
        public IActionResult DeleteAllowanceRate(long id)
        {
            AllowanceRate a = AllowanceRate_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            AllowanceRate_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Benefit

        [HttpGet("GetBenefits", Name = "GetBenefits")]
        public IEnumerable<Benefit> GetBenefits()
        {
            return Benefit_repo.GetAll().OrderByDescending(a=>a.BenefitId);
        }

        [HttpGet("GetBenefit/{id}", Name = "GetBenefit")]
        public Benefit GetBenefit(long id) => Benefit_repo.GetFirst(a => a.BenefitId == id);

        [HttpPost("AddBenefit", Name = "AddBenefit")]
        [ValidateModelAttribute]
        public IActionResult AddBenefit([FromBody]Benefit model)
        {
            Benefit_repo.Add(model);
            return new OkObjectResult(new { BenefitID = model.BenefitId });
        }

        [HttpPut("UpdateBenefit", Name = "UpdateBenefit")]
        [ValidateModelAttribute]
        public IActionResult UpdateBenefit([FromBody]Benefit model)
        {
            Benefit_repo.Update(model);
            return new OkObjectResult(new { BenefitID = model.BenefitId });
        }

        [HttpDelete("DeleteBenefit/{id}")]
        public IActionResult DeleteBenefit(long id)
        {
            Benefit a = Benefit_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            SalaryStructureDetail_repo.DeleteRange(SalaryStructureDetail_repo.GetAll().Where(b => b.BenefitId == id));
            TaxBenefit_repo.DeleteRange(TaxBenefit_repo.GetAll().Where(b => b.BenefitId == id));
            Benefit_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region BankAdviceTemplate

        [HttpGet("GetBankAdviceTemplates", Name = "GetBankAdviceTemplates")]
        public IEnumerable<BankAdviceTemplate> GetBankAdviceTemplates()
        {
            return BankAdviceTemplate_repo.GetAll().OrderByDescending(a=>a.BankAdviceTemplateId);
        }

        [HttpGet("GetBankAdviceTemplate/{id}", Name = "GetBankAdviceTemplate")]
        public BankAdviceTemplate GetBankAdviceTemplate(long id) => BankAdviceTemplate_repo.GetFirst(a => a.BankAdviceTemplateId == id);

        [HttpPost("AddBankAdviceTemplate", Name = "AddBankAdviceTemplate")]
        [ValidateModelAttribute]
        public IActionResult AddBankAdviceTemplate([FromBody]BankAdviceTemplate model)
        {
            BankAdviceTemplate_repo.Add(model);
            return new OkObjectResult(new { BankAdviceTemplateID = model.BankAdviceTemplateId });
        }

        [HttpPut("UpdateBankAdviceTemplate", Name = "UpdateBankAdviceTemplate")]
        [ValidateModelAttribute]
        public IActionResult UpdateBankAdviceTemplate([FromBody]BankAdviceTemplate model)
        {
            BankAdviceTemplate_repo.Update(model);
            return new OkObjectResult(new { BankAdviceTemplateID = model.BankAdviceTemplateId });
        }

        [HttpDelete("DeleteBankAdviceTemplate/{id}")]
        public IActionResult DeleteBankAdviceTemplate(long id)
        {
            BankAdviceTemplate a = BankAdviceTemplate_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            BankAdviceTemplate_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region ChequeTemplate

        [HttpGet("GetChequeTemplates", Name = "GetChequeTemplates")]
        public IEnumerable<ChequeTemplate> GetChequeTemplates()
        {
            return ChequeTemplate_repo.GetAll().OrderByDescending(a=>a.ChequeTemplateId);
        }

        [HttpGet("GetChequeTemplate/{id}", Name = "GetChequeTemplate")]
        public ChequeTemplate GetChequeTemplate(long id) => ChequeTemplate_repo.GetFirst(a => a.ChequeTemplateId == id);

        [HttpPost("AddChequeTemplate", Name = "AddChequeTemplate")]
        [ValidateModelAttribute]
        public IActionResult AddChequeTemplate([FromBody]ChequeTemplate model)
        {
            ChequeTemplate_repo.Add(model);
            return new OkObjectResult(new { ChequeTemplateID = model.ChequeTemplateId });
        }

        [HttpPut("UpdateChequeTemplate", Name = "UpdateChequeTemplate")]
        [ValidateModelAttribute]
        public IActionResult UpdateChequeTemplate([FromBody]ChequeTemplate model)
        {
            ChequeTemplate_repo.Update(model);
            return new OkObjectResult(new { ChequeTemplateID = model.ChequeTemplateId });
        }

        [HttpDelete("DeleteChequeTemplate/{id}")]
        public IActionResult DeleteChequeTemplate(long id)
        {
            ChequeTemplate a = ChequeTemplate_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            ChequeTemplate_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region CompensationTransaction

        [HttpGet("GetCompensationTransactions", Name = "GetCompensationTransactions")]
        public IEnumerable<CompensationTransaction> GetCompensationTransactions()
        {
            return CompensationTransaction_repo.GetAll().OrderByDescending(a=>a.CompensationTransactionId);
        }

        [HttpGet("GetCompensationTransaction/{id}", Name = "GetCompensationTransaction")]
        public CompensationTransaction GetCompensationTransaction(long id) => CompensationTransaction_repo.GetFirst(a => a.CompensationTransactionId == id);

        [HttpPost("AddCompensationTransaction", Name = "AddCompensationTransaction")]
        [ValidateModelAttribute]
        public IActionResult AddCompensationTransaction([FromBody]CompensationTransaction model)
        {
            CompensationTransaction_repo.Add(model);
            return new OkObjectResult(new { CompensationTransactionID = model.CompensationTransactionId });
        }

        [HttpPut("UpdateCompensationTransaction", Name = "UpdateCompensationTransaction")]
        [ValidateModelAttribute]
        public IActionResult UpdateCompensationTransaction([FromBody]CompensationTransaction model)
        {
            CompensationTransaction_repo.Update(model);
            return new OkObjectResult(new { CompensationTransactionID = model.CompensationTransactionId });
        }

        [HttpDelete("DeleteCompensationTransaction/{id}")]
        public IActionResult DeleteCompensationTransaction(long id)
        {
            CompensationTransaction a = CompensationTransaction_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            CompensationTransaction_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region Currency

        [HttpGet("GetCurrencies", Name = "GetCurrencies")]
        public IEnumerable<Currency> GetCurrencies()
        {
            return Currency_repo.GetAll().OrderByDescending(a=>a.CurrencyId);
        }

        [HttpGet("GetCurrency/{id}", Name = "GetCurrency")]
        public Currency GetCurrency(long id) => Currency_repo.GetFirst(a => a.CurrencyId == id);

        [HttpPost("AddCurrency", Name = "AddCurrency")]
        [ValidateModelAttribute]
        public IActionResult AddCurrency([FromBody]Currency model)
        {
            Currency_repo.Add(model);
            return new OkObjectResult(new { CurrencyID = model.CurrencyId });
        }

        [HttpPut("UpdateCurrency", Name = "UpdateCurrency")]
        [ValidateModelAttribute]
        public IActionResult UpdateCurrency([FromBody]Currency model)
        {
            Currency_repo.Update(model);
            return new OkObjectResult(new { CurrencyID = model.CurrencyId });
        }

        [HttpDelete("DeleteCurrency/{id}")]
        public IActionResult DeleteCurrencyg(long id)
        {
            Currency a = Currency_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Currency_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region Frequency

        [HttpGet("GetFrequencies", Name = "GetFrequencies")]
        public IEnumerable<Frequency> GetFrequencies()
        {
            return Frequency_repo.GetAll().OrderByDescending(a=>a.FrequencyId);
        }

        [HttpGet("GetFrequency/{id}", Name = "GetFrequency")]
        public Frequency GetFrequency(long id) => Frequency_repo.GetFirst(a => a.FrequencyId == id);

        [HttpPost("AddFrequency", Name = "AddFrequency")]
        [ValidateModelAttribute]
        public IActionResult AddFrequency([FromBody]Frequency model)
        {
            Frequency_repo.Add(model);
            return new OkObjectResult(new { FrequencyID = model.FrequencyId });
        }

        [HttpPut("UpdateFrequency", Name = "UpdateFrequency")]
        [ValidateModelAttribute]
        public IActionResult UpdateFrequency([FromBody]Frequency model)
        {
            Frequency_repo.Update(model);
            return new OkObjectResult(new { FrequencyID = model.FrequencyId });
        }

        [HttpDelete("DeleteFrequency/{id}")]
        public IActionResult DeleteFrequency(long id)
        {
            Frequency a = Frequency_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Frequency_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region FundSetup

        [HttpGet("GetFundSetups", Name = "GetFundSetups")]
        public IEnumerable<FundSetup> GetFundSetups()
        {
            return FundSetup_repo.GetAll().OrderByDescending(a=>a.FundSetupId);
        }

        [HttpGet("GetFundSetup/{id}", Name = "GetFundSetup")]
        public FundSetup GetFundSetup(long id) => FundSetup_repo.GetFirst(a => a.FundSetupId == id);

        [HttpPost("AddFundSetup", Name = "AddFundSetup")]
        [ValidateModelAttribute]
        public IActionResult AddFundSetup([FromBody]FundSetup model)
        {
            FundSetup_repo.Add(model);
            return new OkObjectResult(new { FundSetupID = model.FundSetupId });
        }

        [HttpPut("UpdateFundSetup", Name = "UpdateFundSetup")]
        [ValidateModelAttribute]
        public IActionResult UpdateFundSetup([FromBody]FundSetup model)
        {
            FundSetup_repo.Update(model);
            return new OkObjectResult(new { FundSetupID = model.FundSetupId });
        }

        [HttpDelete("DeleteFundSetup/{id}")]
        public IActionResult DeleteFundSetup(long id)
        {
            FundSetup a = FundSetup_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            FundSetup_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region GratuitySlab

        [HttpGet("GetGratuitySlabs", Name = "GetGratuitySlabs")]
        public IEnumerable<GratuitySlab> GetGratuitySlabs()
        {
            return GratuitySlab_repo.GetAll().OrderByDescending(a=>a.GratuitySlabId);
        }

        [HttpGet("GetGratuitySlab/{id}", Name = "GetGratuitySlab")]
        public GratuitySlab GetGratuitySlab(long id) => GratuitySlab_repo.GetFirst(a => a.GratuitySlabId == id);

        [HttpPost("AddGratuitySlab", Name = "AddGratuitySlab")]
        [ValidateModelAttribute]
        public IActionResult AddGratuitySlab([FromBody]GratuitySlab model)
        {
            GratuitySlab_repo.Add(model);
            return new OkObjectResult(new { GratuitySlabID = model.GratuitySlabId });
        }

        [HttpPut("UpdateGratuitySlab", Name = "UpdateGratuitySlab")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveOpening([FromBody]GratuitySlab model)
        {
            GratuitySlab_repo.Update(model);
            return new OkObjectResult(new { GratuitySlabID = model.GratuitySlabId });
        }

        [HttpDelete("DeleteGratuitySlab/{id}")]
        public IActionResult DeleteGratuitySlab(long id)
        {
            GratuitySlab a = GratuitySlab_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            GratuitySlab_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region GratuityType

        [HttpGet("GetGratuityTypes", Name = "GetGratuityTypes")]
        public IEnumerable<GratuityType> GetGratuityTypes()
        {
            return GratuityType_repo.GetAll().OrderByDescending(a=>a.GratuityTypeId);
        }

        [HttpGet("GetGratuityType/{id}", Name = "GetGratuityType")]
        public GratuityType GetGratuityType(long id) => GratuityType_repo.GetFirst(a => a.GratuityTypeId == id);

        [HttpPost("AddGratuityType", Name = "AddGratuityType")]
        [ValidateModelAttribute]
        public IActionResult AddGratuityType([FromBody]GratuityType model)
        {
            GratuityType_repo.Add(model);
            return new OkObjectResult(new { GratuityTypeID = model.GratuityTypeId });
        }

        [HttpPut("UpdateGratuityType", Name = "UpdateGratuityType")]
        [ValidateModelAttribute]
        public IActionResult UpdateGratuityType([FromBody]GratuityType model)
        {
            GratuityType_repo.Update(model);
            return new OkObjectResult(new { GratuityTypeID = model.GratuityTypeId });
        }

        [HttpDelete("DeleteGratuityType/{id}")]
        public IActionResult DeleteGratuityType(long id)
        {
            GratuityType a = GratuityType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            GratuityType_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region GratuitySlabGratuity

        [HttpGet("GetGratuitySlabGratuities", Name = "GetGratuitySlabGratuities")]
        public IEnumerable<GratuitySlabGratuity> GetGratuitySlabGratuities()
        {
            return GratuitySlabGratuity_repo.GetAll().OrderByDescending(a=>a.GratuitySlabGratuityId);
        }

        [HttpGet("GetGratuitySlabGratuity/{id}", Name = "GetGratuitySlabGratuity")]
        public GratuitySlabGratuity GetGratuitySlabGratuity(long id) => GratuitySlabGratuity_repo.GetFirst(a => a.GratuitySlabGratuityId == id);

        [HttpPost("AddGratuitySlabGratuity", Name = "AddGratuitySlabGratuity")]
        [ValidateModelAttribute]
        public IActionResult AddGratuitySlabGratuity([FromBody]GratuitySlabGratuity model)
        {
            GratuitySlabGratuity_repo.Add(model);
            return new OkObjectResult(new { GratuitySlabGratuityID = model.GratuitySlabGratuityId });
        }

        [HttpPut("UpdateGratuitySlabGratuity", Name = "UpdateGratuitySlabGratuity")]
        [ValidateModelAttribute]
        public IActionResult UpdateGratuitySlabGratuity([FromBody]GratuitySlabGratuity model)
        {
            GratuitySlabGratuity_repo.Update(model);
            return new OkObjectResult(new { GratuitySlabGratuityID = model.GratuitySlabGratuityId });
        }

        [HttpDelete("DeleteGratuitySlabGratuity/{id}")]
        public IActionResult DeleteGratuitySlabGratuity(long id)
        {
            GratuitySlabGratuity a = GratuitySlabGratuity_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            GratuitySlabGratuity_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region LeavingReason

        [HttpGet("GetLeavingReasons", Name = "GetLeavingReasons")]
        public IEnumerable<LeavingReason> GetLeavingReasons()
        {
            return LeavingReason_repo.GetAll().OrderByDescending(a=>a.LeavingReasonId);
        }

        [HttpGet("GetLeavingReason/{id}", Name = "GetLeavingReason")]
        public LeavingReason GetLeavingReason(long id) => LeavingReason_repo.GetFirst(a => a.LeavingReasonId == id);

        [HttpPost("AddLeavingReason", Name = "AddLeavingReason")]
        [ValidateModelAttribute]
        public IActionResult AddLeavingReason([FromBody]LeavingReason model)
        {
            LeavingReason_repo.Add(model);
            return new OkObjectResult(new { LeavingReasonID = model.LeavingReasonId });
        }

        [HttpPut("UpdateLeavingReason", Name = "UpdateLeavingReason")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveOpening([FromBody]LeavingReason model)
        {
            LeavingReason_repo.Update(model);
            return new OkObjectResult(new { LeavingReasonID = model.LeavingReasonId });
        }

        [HttpDelete("DeleteLeavingReason/{id}")]
        public IActionResult DeleteLeavingReason(long id)
        {
            LeavingReason a = LeavingReason_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LeavingReason_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region MasterPayroll

        [HttpGet("GetMasterPayrolls", Name = "GetMasterPayrolls")]
        public IEnumerable<MasterPayroll> GetMasterPayrolls()
        {
            return MasterPayroll_repo.GetAll(a => a.MasterPayrollDetails).OrderByDescending(b => b.MasterPayrollId);
        }

        [HttpGet("GetMasterPayroll/{id}", Name = "GetMasterPayroll")]
        public MasterPayroll GetMasterPayroll(long id) => MasterPayroll_repo.GetFirst(a => a.MasterPayrollId == id);

        [HttpPost("AddMasterPayroll", Name = "AddMasterPayroll")]
        [ValidateModelAttribute]
        public IActionResult AddMasterPayroll([FromBody]MasterPayroll model)
        {
            MasterPayroll_repo.Add(model);
            return new OkObjectResult(new { MasterPayrollID = model.MasterPayrollId });
        }

        [HttpPut("UpdateMasterPayroll", Name = "UpdateMasterPayroll")]
        [ValidateModelAttribute]
        public IActionResult UpdateMasterPayroll([FromBody]MasterPayroll model)
        {
            MasterPayroll_repo.Update(model);
            return new OkObjectResult(new { MasterPayrollID = model.MasterPayrollId });
        }

        [HttpDelete("DeleteMasterPayroll/{id}")]
        public IActionResult DeleteMasterPayroll(long id)
        {
            MasterPayroll a = MasterPayroll_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            MasterPayroll_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region MasterPayrollDetail

        [HttpGet("GetMasterPayrollDetails", Name = "GetMasterPayrollDetails")]
        public IEnumerable<MasterPayrollDetails> GetMasterPayrollDetails()
        {
            return MasterPayrollDetail_repo.GetAll().OrderByDescending(a=>a.MasterPayrollDetailsId);
        }

        [HttpGet("GetMasterPayrollDetail/{id}", Name = "GetMasterPayrollDetail")]
        public MasterPayrollDetails GetMasterPayrollDetail(long id) => MasterPayrollDetail_repo.GetFirst(a => a.MasterPayrollDetailsId == id);

        [HttpPost("AddMasterPayrollDetail", Name = "AddMasterPayrollDetail")]
        [ValidateModelAttribute]
        public IActionResult AddMasterPayrollDetail([FromBody]MasterPayrollDetails model)
        {
            MasterPayrollDetail_repo.Add(model);
            return new OkObjectResult(new { MasterPayrollDetailID = model.MasterPayrollDetailsId });
        }

        [HttpPut("UpdateMasterPayrollDetail", Name = "UpdateMasterPayrollDetail")]
        [ValidateModelAttribute]
        public IActionResult UpdateMasterPayrollDetail([FromBody]MasterPayrollDetails model)
        {
            MasterPayrollDetail_repo.Update(model);
            return new OkObjectResult(new { MasterPayrollDetailID = model.MasterPayrollDetailsId });
        }

        [HttpDelete("DeleteMasterPayrollDetail/{id}")]
        public IActionResult DeleteMasterPayrollDetail(long id)
        {
            MasterPayrollDetails a = MasterPayrollDetail_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            MasterPayrollDetail_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region Payroll

        [HttpGet("GetPayrolls", Name = "GetPayrolls")]
        public IEnumerable<Payroll> GetPayrolls()
        {
            return Payroll_repo.GetAll().OrderByDescending(a=>a.PayrollId);
        }

        [HttpGet("GetPayroll/{id}", Name = "GetPayroll")]
        public Payroll GetPayroll(long id) => Payroll_repo.GetFirst(a => a.PayrollId == id);

        [HttpPost("AddPayroll", Name = "AddPayroll")]
        [ValidateModelAttribute]
        public IActionResult AddPayroll([FromBody]Payroll model)
        {
            Payroll_repo.Add(model);
            return new OkObjectResult(new { PayrollID = model.PayrollId });
        }

        [HttpPut("UpdatePayroll", Name = "UpdatePayroll")]
        [ValidateModelAttribute]
        public IActionResult UpdatePayroll([FromBody]Payroll model)
        {
            Payroll_repo.Update(model);
            return new OkObjectResult(new { PayrollID = model.PayrollId });
        }

        [HttpDelete("DeletePayroll/{id}")]
        public IActionResult DeletePayroll(long id)
        {
            Payroll a = Payroll_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            Payroll_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region PayrollBank

        [HttpGet("GetPayrollBanks", Name = "GetPayrollBanks")]
        public IEnumerable<PayrollBank> GetPayrollBanks()
        {
            return PayrollBank_repo.GetAll().OrderByDescending(a=>a.PayrollBankId);
        }

        [HttpGet("GetPayrollBank/{id}", Name = "GetPayrollBank")]
        public PayrollBank GetPayrollBank(long id) => PayrollBank_repo.GetFirst(a => a.PayrollBankId == id);

        public string GenPB()
        {
            
            try
            {
                string payrollbankuniqueid = PayrollBank_repo.GetLast().UniqueId;
                string uniqueid = Regex.Match(payrollbankuniqueid, "[0-9]+$").Value;

                return payrollbankuniqueid.Substring(0, payrollbankuniqueid.Length - uniqueid.Length) +
                       (long.Parse(uniqueid) + 1).ToString().PadLeft(uniqueid.Length, '0');
            }
            catch (NullReferenceException)
            {
                return "PB0000001";
            }
            catch (Exception)
            {
                return "PB0000001";
            }
        }

        [HttpPost("AddPayrollBank", Name = "AddPayrollBank")]
        [ValidateModelAttribute]
        public IActionResult AddPayrollBank([FromBody]PayrollBank model)
        {
            model.UniqueId = GenPB();
            PayrollBank_repo.Add(model);
            return new OkObjectResult(new { PayrollBankID = model.PayrollBankId });
        }

        [HttpPut("UpdatePayrollBank", Name = "UpdatePayrollBank")]
        [ValidateModelAttribute]
        public IActionResult UpdatePayrollBank([FromBody]PayrollBank model)
        {
            PayrollBank_repo.Update(model);
            return new OkObjectResult(new { PayrollBankID = model.PayrollBankId });
        }

        [HttpDelete("DeletePayrollBank/{id}")]
        public IActionResult DeletePayrollBank(long id)
        {
            PayrollBank a = PayrollBank_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            PayrollBank_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region PayrollType

        [HttpGet("GetPayrollTypes", Name = "GetPayrollTypes")]
        public IEnumerable<PayrollType> GetPayrollTypes()
        {
            return PayrollType_repo.GetAll().OrderByDescending(a=>a.PayrollTypeId);
        }

        [HttpGet("GetPayrollType/{id}", Name = "GetPayrollType")]
        public PayrollType GetPayrollType(long id) => PayrollType_repo.GetFirst(a => a.PayrollTypeId == id);

        [HttpPost("AddPayrollType", Name = "AddPayrollType")]
        [ValidateModelAttribute]
        public IActionResult AddPayrollType([FromBody]PayrollType model)
        {
            PayrollType_repo.Add(model);
            return new OkObjectResult(new { PayrollTypeID = model.PayrollTypeId });
        }

        [HttpPut("UpdatePayrollType", Name = "UpdatePayrollType")]
        [ValidateModelAttribute]
        public IActionResult UpdatePayrollType([FromBody]PayrollType model)
        {
            PayrollType_repo.Update(model);
            return new OkObjectResult(new { PayrollTypeID = model.PayrollTypeId });
        }

        [HttpDelete("DeletePayrollType/{id}")]
        public IActionResult DeletePayrollType(long id)
        {
            PayrollType a = PayrollType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            PayrollType_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region PayrollYear

        [HttpGet("GetPayrollYears", Name = "GetPayrollYears")]
        public IEnumerable<PayrollYear> GetPayrollYears()
        {
            return PayrollYear_repo.GetAll().OrderByDescending(a=>a.PayrollYearId);
        }

        [HttpGet("GetPayrollYear/{id}", Name = "GetPayrollYear")]
        public PayrollYear GetPayrollYear(long id) => PayrollYear_repo.GetFirst(a => a.PayrollYearId == id);

        [HttpPost("AddPayrollYear", Name = "AddPayrollYear")]
        [ValidateModelAttribute]
        public IActionResult AddPayrollYear([FromBody]PayrollYear model)
        {
            model.Name = model.From.Value.Year.ToString() + '-' + model.Till.Value.Year.ToString();
            PayrollYear_repo.Add(model);
            return new OkObjectResult(new { PayrollYearID = model.PayrollYearId });
        }

        [HttpPut("UpdatePayrollYear", Name = "UpdatePayrollYear")]
        [ValidateModelAttribute]
        public IActionResult UpdatePayrollYear([FromBody]PayrollYear model)
        {
            model.Name = model.From.Value.Year.ToString() + '-' + model.Till.Value.Year.ToString();
            PayrollYear_repo.Update(model);
            return new OkObjectResult(new { PayrollYearID = model.PayrollYearId });
        }

        [HttpDelete("DeletePayrollYear/{id}")]
        public IActionResult DeletePayrollYear(long id)
        {
            PayrollYear a = PayrollYear_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            PayrollYear_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region PfPayment

        [HttpGet("GetPfPayments", Name = "GetPfPayments")]
        public IEnumerable<PfPayment> GetPfPayments()
        {
            return PfPayment_repo.GetAll().OrderByDescending(a=>a.PfPaymentId);
        }

        [HttpGet("GetPfPayment/{id}", Name = "GetPfPayment")]
        public PfPayment GetPfPayment(long id) => PfPayment_repo.GetFirst(a => a.PfPaymentId == id);

        [HttpPost("AddPfPayment", Name = "AddPfPayment")]
        [ValidateModelAttribute]
        public IActionResult AddPfPayment([FromBody]PfPayment model)
        {
            PfPayment_repo.Add(model);
            return new OkObjectResult(new { PfPaymentID = model.PfPaymentId });
        }

        [HttpPut("UpdatePfPayment", Name = "UpdatePfPayment")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveOpening([FromBody]PfPayment model)
        {
            PfPayment_repo.Update(model);
            return new OkObjectResult(new { PfPaymentID = model.PfPaymentId });
        }

        [HttpDelete("DeletePfPayment/{id}")]
        public IActionResult DeletePfPayment(long id)
        {
            PfPayment a = PfPayment_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            } 
            PfPayment_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region SalaryCalculationType

        [HttpGet("GetSalaryCalculationTypes", Name = "GetSalaryCalculationTypes")]
        public IEnumerable<SalaryCalculationType> GetSalaryCalculationTypes()
        {
            return SalaryCalculationType_repo.GetAll().OrderByDescending(a=>a.SalaryCalculationTypeId);
        }

        [HttpGet("GetSalaryCalculationType/{id}", Name = "GetSalaryCalculationType")]
        public SalaryCalculationType GetSalaryCalculationType(long id) => SalaryCalculationType_repo.GetFirst(a => a.SalaryCalculationTypeId == id);

        [HttpPost("AddSalaryCalculationType", Name = "AddSalaryCalculationType")]
        [ValidateModelAttribute]
        public IActionResult AddSalaryCalculationType([FromBody]SalaryCalculationType model)
        {
            SalaryCalculationType_repo.Add(model);
            return new OkObjectResult(new { SalaryCalculationTypeID = model.SalaryCalculationTypeId });
        }

        [HttpPut("UpdateSalaryCalculationType", Name = "UpdateSalaryCalculationType")]
        [ValidateModelAttribute]
        public IActionResult UpdateSalaryCalculationType([FromBody]SalaryCalculationType model)
        {
            SalaryCalculationType_repo.Update(model);
            return new OkObjectResult(new { SalaryCalculationTypeID = model.SalaryCalculationTypeId });
        }

        [HttpDelete("DeleteSalaryCalculationType/{id}")]
        public IActionResult DeleteSalaryCalculationType(long id)
        {
            SalaryCalculationType a = SalaryCalculationType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            SalaryCalculationType_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region SalaryStructure

        [HttpGet("GetSalaryStructures", Name = "GetSalaryStructures")]
        public IEnumerable<SalaryStructure> GetSalaryStructures()
        {
            return SalaryStructure_repo.GetAll(g=>g.SalaryStructureDetails).OrderByDescending(a=>a.SalaryStructureId);
        }

        [HttpGet("GetSalaryStructure/{id}", Name = "GetSalaryStructure")]
        public SalaryStructure GetSalaryStructure(long id) => SalaryStructure_repo.GetFirst(a => a.SalaryStructureId == id, b=> b.SalaryStructureDetails);

        [HttpPost("AddSalaryStructure", Name = "AddSalaryStructure")]
        [ValidateModelAttribute]
        public IActionResult AddSalaryStructure([FromBody]SalaryStructure model)
        {
            SalaryStructure_repo.Add(model);
            return new OkObjectResult(new { SalaryStructureID = model.SalaryStructureId });
        }

        [HttpPut("UpdateSalaryStructure", Name = "UpdateSalaryStructure")]
        [ValidateModelAttribute]
        public IActionResult UpdateSalaryStructure([FromBody]SalaryStructure model)
        {
            try
            {
                SalaryStructureDetail_repo.DeleteRange(SalaryStructureDetail_repo.GetAll().Where(a => a.SalaryStructureId == model.SalaryStructureId));
                SalaryStructure_repo.Update(model);
                return new OkObjectResult(new { SalaryStructureID = model.SalaryStructureId });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("DeleteSalaryStructure/{id}")]
        public IActionResult DeleteSalaryStructure(long id)
        {
            SalaryStructure a = SalaryStructure_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            SalaryStructure_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region SalaryStructureDetail

        [HttpGet("GetSalaryStructureDetails", Name = "GetSalaryStructureDetails")]
        public IEnumerable<SalaryStructureDetail> GetSalaryStructureDetails()
        {
            return SalaryStructureDetail_repo.GetAll().OrderByDescending(a=>a.SalaryStructureDetailId);
        }

        [HttpGet("GetSalaryStructureDetail/{id}", Name = "GetSalaryStructureDetail")]
        public SalaryStructureDetail GetSalaryStructureDetail(long id) => SalaryStructureDetail_repo.GetFirst(a => a.SalaryStructureDetailId == id);

        [HttpPost("AddSalaryStructureDetail", Name = "AddSalaryStructureDetail")]
        [ValidateModelAttribute]
        public IActionResult AddSalaryStructureDetail([FromBody]SalaryStructureDetail model)
        {
            SalaryStructureDetail_repo.Add(model);
            return new OkObjectResult(new { SalaryStructureDetailID = model.SalaryStructureDetailId });
        }

        [HttpPut("UpdateSalaryStructureDetail", Name = "UpdateSalaryStructureDetail")]
        [ValidateModelAttribute]
        public IActionResult UpdateSalaryStructureDetail([FromBody]SalaryStructureDetail model)
        {
            SalaryStructureDetail_repo.Update(model);
            return new OkObjectResult(new { SalaryStructureDetailID = model.SalaryStructureDetailId });
        }

        [HttpDelete("DeleteSalaryStructureDetail/{id}")]
        public IActionResult DeleteSalaryStructureDetail(long id)
        {
            SalaryStructureDetail a = SalaryStructureDetail_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            SalaryStructureDetail_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region UserSalary

        [HttpGet("GetUserSalaries", Name = "GetUserSalaries")]
        public IEnumerable<UserSalary> GetUserSalaries()
        {
            return UserSalary_repo.GetAll().OrderByDescending(a=>a.UserSalaryId);
        }

        [HttpGet("GetUserSalary/{id}", Name = "GetUserSalary")]
        public UserSalary GetUserSalary(long id) => UserSalary_repo.GetFirst(a => a.UserSalaryId == id);

        [HttpPost("AddUserSalary", Name = "AddUserSalary")]
        [ValidateModelAttribute]
        public IActionResult AddUserSalary([FromBody]UserSalary model)
        {
            UserSalary_repo.Add(model);
            return new OkObjectResult(new { UserSalaryID = model.UserSalaryId });
        }

        [HttpPut("UpdateUserSalary", Name = "UpdateUserSalary")]
        [ValidateModelAttribute]
        public IActionResult UpdateUserSalary([FromBody]UserSalary model)
        {
            UserSalary_repo.Update(model);
            return new OkObjectResult(new { UserSalaryID = model.UserSalaryId });
        }

        [HttpDelete("DeleteUserSalary/{id}")]
        public IActionResult DeleteUserSalary(long id)
        {
            UserSalary a = UserSalary_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            UserSalary_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region TaxRelief

        [HttpGet("GetTaxReliefs", Name = "GetTaxReliefs")]
        public IEnumerable<TaxRelief> GetTaxReliefs()
        {
            return TaxRelief_repo.GetAll().OrderByDescending(a=>a.TaxReliefId);
        }

        [HttpGet("GetTaxRelief/{id}", Name = "GetTaxRelief")]
        public TaxRelief GetTaxRelief(long id) => TaxRelief_repo.GetFirst(a => a.TaxReliefId == id);

        [HttpPost("AddTaxRelief", Name = "AddTaxRelief")]
        [ValidateModelAttribute]
        public IActionResult AddTaxRelief([FromBody]TaxRelief model)
        {
            TaxRelief_repo.Add(model);
            return new OkObjectResult(new { TaxReliefID = model.TaxReliefId });
        }

        [HttpPut("UpdateTaxRelief", Name = "UpdateTaxRelief")]
        [ValidateModelAttribute]
        public IActionResult UpdateTaxRelief([FromBody]TaxRelief model)
        {
            TaxRelief_repo.Update(model);
            return new OkObjectResult(new { TaxReliefID = model.TaxReliefId });
        }

        [HttpDelete("DeleteTaxRelief/{id}")]
        public IActionResult DeleteTaxRelief(long id)
        {
            TaxRelief a = TaxRelief_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            TaxRelief_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region TaxSchedule

        [HttpGet("GetTaxSchedules", Name = "GetTaxSchedules")]
        public IEnumerable<TaxSchedule> GetTaxSchedules()
        {
            return TaxSchedule_repo.GetAll().OrderByDescending(a=>a.TaxScheduleId);
        }

        [HttpGet("GetTaxSchedule/{id}", Name = "GetTaxSchedule")]
        public TaxSchedule GetTaxSchedule(long id) => TaxSchedule_repo.GetFirst(a => a.TaxScheduleId == id);

        [HttpPost("AddTaxSchedule", Name = "AddTaxSchedule")]
        [ValidateModelAttribute]
        public IActionResult AddTaxSchedule([FromBody]TaxSchedule model)
        {
            TaxSchedule_repo.Add(model);
            return new OkObjectResult(new { TaxScheduleID = model.TaxScheduleId });
        }

        [HttpPut("UpdateTaxSchedule", Name = "UpdateTaxSchedule")]
        [ValidateModelAttribute]
        public IActionResult UpdateTaxSchedule([FromBody]TaxSchedule model)
        {
            TaxSchedule_repo.Update(model);
            return new OkObjectResult(new { TaxScheduleID = model.TaxScheduleId });
        }

        [HttpDelete("DeleteTaxSchedule/{id}")]
        public IActionResult DeleteTaxSchedule(long id)
        {
            TaxSchedule a = TaxSchedule_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            TaxSchedule_repo.Delete(a);
            return Ok();
        }

        #endregion 

        #region TaxYear

        [HttpGet("GetTaxYears", Name = "GetTaxYears")]
        public IEnumerable<TaxYear> GetTaxYears()
        {
            return TaxYear_repo.GetAll().OrderByDescending(a=>a.TaxYearId);
        }

        [HttpGet("GetTaxYear/{id}", Name = "GetTaxYear")]
        public TaxYear GetTaxYear(long id) => TaxYear_repo.GetFirst(a => a.TaxYearId == id);

        [HttpPost("AddTaxYear", Name = "AddTaxYear")]
        [ValidateModelAttribute]
        public IActionResult AddTaxYear([FromBody]TaxYear model)
        {
            model.Name = model.From.Value.Year.ToString() + '-' + model.Till.Value.Year.ToString();
            TaxYear_repo.Add(model);
            return new OkObjectResult(new { TaxYearID = model.TaxYearId });
        }

        [HttpPut("UpdateTaxYear", Name = "UpdateTaxYear")]
        [ValidateModelAttribute]
        public IActionResult UpdateTaxYear([FromBody]TaxYear model)
        {
            model.Name = model.From.Value.Year.ToString() + '-' + model.Till.Value.Year.ToString();
            TaxYear_repo.Update(model);
            return new OkObjectResult(new { TaxYearID = model.TaxYearId });
        }

        [HttpDelete("DeleteTaxYear/{id}")]
        public IActionResult DeleteTaxYear(long id)
        {
            TaxYear a = TaxYear_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            TaxYear_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region TaxAdjustmentReason

        [HttpGet("GetTaxAdjustmentReasons", Name = "GetTaxAdjustmentReasons")]
        public IEnumerable<TaxAdjustmentReason> GetTaxAdjustmentReasons()
        {
            return TaxAdjustmentReason_repo.GetAll().OrderByDescending(a=>a.taxAdjustmentReasonId);
        }

        [HttpGet("GetTaxAdjustmentReason/{id}", Name = "GetTaxAdjustmentReason")]
        public TaxAdjustmentReason GetTaxAdjustmentReason(long id) => TaxAdjustmentReason_repo.GetFirst(a => a.taxAdjustmentReasonId == id);

        [HttpPost("AddTaxAdjustmentReason", Name = "AddTaxAdjustmentReason")]
        [ValidateModelAttribute]
        public IActionResult AddTaxAdjustmentReason([FromBody]TaxAdjustmentReason model)
        {
            TaxAdjustmentReason_repo.Add(model);
            return new OkObjectResult(new { TaxAdjustmentReasonID = model.taxAdjustmentReasonId });
        }

        [HttpPut("UpdateTaxAdjustmentReason", Name = "UpdateTaxAdjustmentReason")]
        [ValidateModelAttribute]
        public IActionResult UpdateTaxAdjustmentReason([FromBody]TaxAdjustmentReason model)
        {
            TaxAdjustmentReason_repo.Update(model);
            return new OkObjectResult(new { TaxAdjustmentReasonID = model.taxAdjustmentReasonId });
        }

        [HttpDelete("DeleteTaxAdjustmentReason/{id}")]
        public IActionResult DeleteTaxAdjustmentReason(long id)
        {
            TaxAdjustmentReason a = TaxAdjustmentReason_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            TaxAdjustmentReason_repo.Delete(a);
            return Ok();
        }

        #endregion  

        #region TaxBenefit

        [HttpGet("GetTaxBenefits", Name = "GetTaxBenefits")]
        public IEnumerable<TaxBenefit> GetTaxBenefits()
        {
            return TaxBenefit_repo.GetAll().OrderByDescending(a=>a.TaxBenefitId);
        }

        [HttpGet("GetTaxBenefit/{id}", Name = "GetTaxBenefit")]
        public TaxBenefit GetTaxBenefit(long id) => TaxBenefit_repo.GetFirst(a => a.TaxBenefitId == id);

        [HttpPost("AddTaxBenefit", Name = "AddTaxBenefit")]
        [ValidateModelAttribute]
        public IActionResult AddTaxBenefit([FromBody]TaxBenefit model)
        {
            TaxBenefit_repo.Add(model);
            return new OkObjectResult(new { TaxBenefitID = model.TaxBenefitId });
        }

        [HttpPut("UpdateTaxBenefit", Name = "UpdateTaxBenefit")]
        [ValidateModelAttribute]
        public IActionResult UpdateLeaveOpening([FromBody]TaxBenefit model)
        {
            TaxBenefit_repo.Update(model);
            return new OkObjectResult(new { TaxBenefitID = model.TaxBenefitId });
        }

        [HttpDelete("DeleteTaxBenefit/{id}")]
        public IActionResult DeleteTaxBenefit(long id)
        {
            TaxBenefit a = TaxBenefit_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            TaxBenefit_repo.Delete(a);
            return Ok();
        }

        #endregion

        #region IncomeTaxRule

        [HttpGet("GetIncomeTaxRules", Name = "GetIncomeTaxRules")]
        public IEnumerable<IncomeTaxRule> GetIncomeTaxRules()
        {
            return IncomeTaxRule_repo.GetAll().OrderByDescending(a=>a.IncomeTaxRuleId);
        }

        [HttpGet("GetIncomeTaxRule/{id}", Name = "GetIncomeTaxRule")]
        public IncomeTaxRule GetIncomeTaxRule(long id) => IncomeTaxRule_repo.GetFirst(a => a.IncomeTaxRuleId == id);

        [HttpPost("AddIncomeTaxRule", Name = "AddIncomeTaxRule")]
        [ValidateModelAttribute]
        public IActionResult AddIncomeTaxRule([FromBody]IncomeTaxRule model)
        {
            IncomeTaxRule_repo.Add(model);
            return new OkObjectResult(new { IncomeTaxRuleID = model.IncomeTaxRuleId });
        }

        [HttpPut("UpdateIncomeTaxRule", Name = "UpdateIncomeTaxRule")]
        [ValidateModelAttribute]
        public IActionResult UpdateIncomeTaxRule([FromBody]IncomeTaxRule model)
        {
            IncomeTaxRule_repo.Update(model);
            return new OkObjectResult(new { IncomeTaxRuleID = model.IncomeTaxRuleId });
        }

        [HttpDelete("DeleteIncomeTaxRule/{id}")]
        public IActionResult DeleteIncomeTaxRule(long id)
        {
            IncomeTaxRule a = IncomeTaxRule_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            IncomeTaxRule_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region TaxableIncomeAdjustment

        [HttpGet("GetTaxableIncomeAdjustments", Name = "GetTaxableIncomeAdjustments")]
        public IEnumerable<TaxableIncomeAdjustment> GetTaxableIncomeAdjustments()
        {
            return TaxableIncomeAdjustment_repo.GetAll().OrderByDescending(a=>a.TaxableIncomeAdjustmentId);
        }

        [HttpGet("GetTaxableIncomeAdjustment/{id}", Name = "GetTaxableIncomeAdjustment")]
        public TaxableIncomeAdjustment GetTaxableIncomeAdjustment(long id) => TaxableIncomeAdjustment_repo.GetFirst(a => a.TaxableIncomeAdjustmentId == id);

        [HttpPost("AddTaxableIncomeAdjustment", Name = "AddTaxableIncomeAdjustment")]
        [ValidateModelAttribute]
        public IActionResult AddTaxableIncomeAdjustment([FromBody]TaxableIncomeAdjustment model)
        {
            TaxableIncomeAdjustment_repo.Add(model);
            return new OkObjectResult(new { TaxableIncomeAdjustmentID = model.TaxableIncomeAdjustmentId });
        }

        [HttpPut("UpdateTaxableIncomeAdjustment", Name = "UpdateTaxableIncomeAdjustment")]
        [ValidateModelAttribute]
        public IActionResult UpdateTaxableIncomeAdjustment([FromBody]TaxableIncomeAdjustment model)
        {
            TaxableIncomeAdjustment_repo.Update(model);
            return new OkObjectResult(new { TaxableIncomeAdjustmentID = model.TaxableIncomeAdjustmentId });
        }

        [HttpDelete("DeleteTaxableIncomeAdjustment/{id}")]
        public IActionResult DeleteTaxableIncomeAdjustment(long id)
        {
            TaxableIncomeAdjustment a = TaxableIncomeAdjustment_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            TaxableIncomeAdjustment_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region LoanType

        [HttpGet("GetLoanTypes", Name = "GetLoanTypes")]
        public IEnumerable<LoanType> GetLoanTypes()
        {
            return LoanType_repo.GetAll().OrderByDescending(a=>a.LoanTypeId);
        }

        [HttpGet("GetLoanType/{id}", Name = "GetLoanType")]
        public LoanType GetLoanType(long id) => LoanType_repo.GetFirst(a => a.LoanTypeId == id);

        [HttpPost("AddLoanType", Name = "AddLoanType")]
        [ValidateModelAttribute]
        public IActionResult AddLoanType([FromBody]LoanType model)
        {
            LoanType_repo.Add(model);
            return new OkObjectResult(new { LoanTypeID = model.LoanTypeId });
        }

        [HttpPut("UpdateLoanType", Name = "UpdateLoanType")]
        [ValidateModelAttribute]
        public IActionResult UpdateLoanType([FromBody]LoanType model)
        {
            LoanType_repo.Update(model);
            return new OkObjectResult(new { LoanTypeID = model.LoanTypeId });
        }

        [HttpDelete("DeleteLoanType/{id}")]
        public IActionResult DeleteLoanType(long id)
        {
            LoanType a = LoanType_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            LoanType_repo.Delete(a);
            return Ok();
        }
        #endregion

        #region UserLoan

        [HttpGet("GetUserLoans", Name = "GetUserLoans")]
        public IEnumerable<UserLoan> GetUserLoans()
        {
            return UserLoan_repo.GetAll().OrderByDescending(a=>a.UserLoanId);
        }

        [HttpGet("GetUserLoan/{id}", Name = "GetUserLoan")]
        public UserLoan GetUserLoan(long id) => UserLoan_repo.GetFirst(a => a.UserLoanId == id);

        [HttpPost("AddUserLoan", Name = "AddUserLoan")]
        [ValidateModelAttribute]
        public IActionResult AddUserLoan([FromBody]UserLoan model)
        {
            UserLoan_repo.Add(model);
            return new OkObjectResult(new { UserLoanID = model.UserLoanId });
        }

        [HttpPut("UpdateUserLoan", Name = "UpdateUserLoan")]
        [ValidateModelAttribute]
        public IActionResult UpdateUserLoan([FromBody]UserLoan model)
        {
            UserLoan_repo.Update(model);
            return new OkObjectResult(new { UserLoanID = model.UserLoanId });
        }

        [HttpPut("UpdateUserLoans", Name = "UpdateUserLoans")]
        [ValidateModelAttribute]
        public IActionResult UpdateUserLoans([FromBody]IList<UserLoan> model)
        {
            UserLoan_repo.UpdateRange(model);
            return Ok();
        }

        [HttpDelete("DeleteUserLoan/{id}")]
        public IActionResult DeleteUserLoan(long id)
        {
            UserLoan a = UserLoan_repo.Find(id);
            if (a == null)
            {
                return NotFound();
            }
            UserLoan_repo.Delete(a);
            return Ok();
        }
        #endregion
    }
}