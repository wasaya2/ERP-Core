using ErpCore.Entities.FinanceSetup;
using FinanceService.Repos.Base;
using FinanceService.Repos.Interfaces.SetupInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceService.Repos.SetupRepos
{
    public class MasterAccountRepository : RepoBase<MasterAccount>, IMasterAccountRepository
    {
    }
}
