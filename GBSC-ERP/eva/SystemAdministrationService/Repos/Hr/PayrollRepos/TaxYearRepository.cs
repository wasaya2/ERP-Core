using ErpCore.Entities.HR.Payroll.TaxSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.Repos.Hr.PayrollRepos.Interfaces;

namespace SystemAdministrationService.Repos.Hr.PayrollRepos
{
    public class TaxYearRepository : RepoBase<TaxYear> , ITaxYearRepository
  {
    }
}
