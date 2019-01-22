using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceService.ViewModels
{
    public class EndYearProcessRequestViewModel
    {
        public long? CompanyId { get; set; }
        public long? FinancialYearProcessId { get; set; }
        public long? NewFinancialYearCoaId { get; set; }
    }
}
