using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.FinanceSetup
{
    public class FinancialYear : BaseClass
    {
        [Key]
        public long FinancialYearId { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
