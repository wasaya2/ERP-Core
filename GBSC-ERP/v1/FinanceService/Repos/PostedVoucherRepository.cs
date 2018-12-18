using ErpCore.Entities.Finance;
using FinanceService.Repos.Base;
using FinanceService.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceService.Repos
{
    public class PostedVoucherRepository : RepoBase<PostedVoucher>, IPostedVoucherRepository
    {
    }
}
