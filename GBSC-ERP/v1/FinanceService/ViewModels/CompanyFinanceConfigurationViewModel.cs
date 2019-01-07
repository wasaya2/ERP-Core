using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceService.ViewModels
{
    public class CompanyFinanceConfigurationViewModel
    {
        public long? CompanyId { get; set; }
        public string NTN { get; set; }
        public long? AssestsAccountId { get; set; }
        public long? ExpenseAccountId { get; set; }
        public long? RevenueAccountId { get; set; }
        public long? LiabilitiesAccountId { get; set; }
        public long? EquityAccountId { get; set; }
    }
}
