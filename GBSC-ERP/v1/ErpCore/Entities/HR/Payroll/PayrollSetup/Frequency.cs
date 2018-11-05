using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class Frequency : BaseClass
    {
        public Frequency()
        {
            MasterPayrollDetails = new HashSet<MasterPayrollDetails>();
        }

        [Key]
        public long FrequencyId { get; set; }
        public DateTime? Days { get; set; }
        public string Name { get; set; }

        public IEnumerable<MasterPayrollDetails> MasterPayrollDetails { get; set; }
    }
}
