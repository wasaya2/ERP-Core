using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollAdmin
{
    public class UserStopSalary
    {

        public long? StopSalaryId { get; set; } 
        public StopSalary StopSalary { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
