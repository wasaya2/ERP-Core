using System;
using ErpCore.Entities.Finance;
using FinanceService.Repos.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceService.Repos.Interfaces
{
    public interface ITransactionAccountRepository : IRepo<TransactionAccount>
    {
    }
}
