using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ErpCore.Entities.HR.Leave.LeaveAdmin;

namespace ErpCore.Entities.HR.Leave.LeaveSetup
{
    public class LeaveEligibility : BaseClass
    {
        public LeaveEligibility()
        {
            LeavePolicies = new HashSet<LeavePolicy>();
            LeavePolicyEmployees = new HashSet<LeavePolicyEmployee>();
        }

        [Key]
        public long LeaveEligibilityId { get; set; }
        public string Name { get; set; }

        public IEnumerable<LeavePolicy> LeavePolicies { get; set; }
        public IEnumerable<LeavePolicyEmployee> LeavePolicyEmployees { get; set; }
    }
}
