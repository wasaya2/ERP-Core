using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class PayrollYear : BaseClass
    {
        [Key]
        public long PayrollYearId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? Till { get; set; }
        public string Name { get; set; }
        public bool? IsCurrent { get; set; }
    }
}
