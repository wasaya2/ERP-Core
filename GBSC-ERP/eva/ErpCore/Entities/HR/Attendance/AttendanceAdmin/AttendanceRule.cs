using ErpCore.Entities.HR.Attendance.AttendanceSetup;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Attendance.AttendanceAdmin
{
    public class AttendanceRule : BaseClass
    { 
        public AttendanceRule()
        {
            AttendanceRuleLeaveTypes = new HashSet<AttendanceRuleLeaveType>();
        }

        [Key]
        public long AttendanceRuleId { get; set; }
        public string Action { get; set; }
        public string EffectFrequency { get; set; }
        public string FlagCount { get; set; }
        public string ExemptFlagCount { get; set; }
        public string ExemptMinutes { get; set; }
        public string ConditionalExemption { get; set; }
        public string EffectQuantity { get; set; }
        public string EffectType { get; set; }
        
        public IEnumerable<AttendanceRuleLeaveType> AttendanceRuleLeaveTypes { get; set;}

        public long? AttendanceFlagId { get; set; }
        public AttendanceFlag AttendanceFlag { get; set; }

        public long? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
