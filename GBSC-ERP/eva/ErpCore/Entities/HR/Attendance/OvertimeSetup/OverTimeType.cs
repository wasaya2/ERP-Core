using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.OvertimeSetup
{
    public class OverTimeType : BaseClass
    {
        public OverTimeType()
        {
            OverTimeEntitlements = new HashSet<OverTimeEntitlement>();
        }

        public long OverTimeTypeId { get; set; }
        public string Title { get; set; }
        public bool? Active { get; set; }

        public long? OvertimeFlagId { get; set; }
        public OverTimeFlag OverTimeFlag { get; set; }

        public IEnumerable<OverTimeEntitlement> OverTimeEntitlements { get; set; }
    }
}
