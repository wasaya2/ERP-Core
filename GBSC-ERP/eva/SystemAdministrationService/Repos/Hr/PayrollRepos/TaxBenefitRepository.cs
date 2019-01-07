using ErpCore.Entities;
using ErpCore.Entities.HR.Payroll.TaxSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.Repos.Hr.PayrollRepos.Interfaces;

namespace PayrollService.Repos
{
    public class TaxBenefitRepository :RepoBase<TaxBenefit>, ITaxBenefitRepository
    {
    }
}
