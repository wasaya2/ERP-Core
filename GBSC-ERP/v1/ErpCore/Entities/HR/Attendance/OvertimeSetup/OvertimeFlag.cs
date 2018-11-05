using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ErpCore.Entities.HR.Attendance.OvertimeSetup
{
    public class OverTimeFlag : BaseClass
    {
        public OverTimeFlag()
        {
            OverTimeTypes = new HashSet<OverTimeType>();
        }

        [Key]
        public long OvertimeFlagId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<OverTimeType> OverTimeTypes { get; set; }
    }
}
