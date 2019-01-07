using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave.LeaveSetup
{
    public class LeaveSubType : BaseClass
    {
        public LeaveSubType()
        {
            LeaveTypes = new HashSet<LeaveType>();
        }
        [Key]
        public long LeaveSubTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<LeaveType> LeaveTypes { get; set; }
    }
}
