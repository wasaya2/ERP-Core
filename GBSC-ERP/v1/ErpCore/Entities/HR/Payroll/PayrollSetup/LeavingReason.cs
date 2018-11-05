using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class LeavingReason : BaseClass
    {
        public LeavingReason()
        {
            PfPayments = new HashSet<PfPayment>();
        }

        [Key]
        public long LeavingReasonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<PfPayment> PfPayments { get; set; }
    }
}
