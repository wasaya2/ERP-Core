using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.TaxSetup
{
    public class TaxYear : BaseClass
    {
        [Key]
        public long TaxYearId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? Till { get; set; }
        public string Name { get; set; }
        public bool? IsCurrent { get; set; }
    }
}
