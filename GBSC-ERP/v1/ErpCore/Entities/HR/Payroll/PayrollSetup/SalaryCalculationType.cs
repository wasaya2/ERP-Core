using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class SalaryCalculationType : BaseClass
    {
        [Key]
        public long SalaryCalculationTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
