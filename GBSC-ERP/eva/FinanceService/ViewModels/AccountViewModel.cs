using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceService.ViewModels
{
    public class AccountViewModel
    {
        public long? CompanyId { get; set; }
        public string ParentAccountCode { get; set; }
        public long? ParentAccountLevel { get; set; }
        public string AccountCode { get; set; } //AutoGenerate based on Parent Account
        public bool? IsGeneralOrDetail { get; set; } //True for General, False for Detail
        public long? AccountLevel { get; set; } //AutoGenerate based on Parent account
        public string Description { get; set; }
        public double? OpeningBalance { get; set; } // Only for detail accounts
        public long? FinancialYearId { get; set; }
    }
}
