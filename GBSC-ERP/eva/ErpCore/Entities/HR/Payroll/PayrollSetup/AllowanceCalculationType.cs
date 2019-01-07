using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class AllowanceCalculationType : BaseClass
    {
        public AllowanceCalculationType()
        {
            AllowanceDeductions = new HashSet<AllowanceDeduction>();
        }

        [Key]
        public long AllowanceCalculationTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<AllowanceDeduction> AllowanceDeductions { get; set; }
    }
}
