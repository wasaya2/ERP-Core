using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class MasterPayroll : BaseClass
    {
        public MasterPayroll()
        { 
            MasterPayrollDetails = new HashSet<MasterPayrollDetails>();
            Payrolls = new HashSet<Payroll>();
        }

        [Key]
        public long MasterPayrollId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string BankTransferCode { get; set; } //Autogenerate

        public double? Salary { get; set; }
        public long? CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public long? BankId { get; set; }
        public Bank Bank { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<MasterPayrollDetails> MasterPayrollDetails { get; set; }
        public IEnumerable<Payroll> Payrolls { get; set; }
    }
}
