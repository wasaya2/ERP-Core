using ErpCore.Entities.HR.Attendance.AttendanceAdmin;
using ErpCore.Entities.HR.Leave.LeaveAdmin;
using ErpCore.Entities.HR.Leave.LeaveSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.HR.Leave.LeaveSetup
{
    public class LeaveType : BaseClass
    {
        public LeaveType()
        {
            LeavePolicies = new HashSet<LeavePolicy>();
            LeavePolicyEmployees = new HashSet<LeavePolicyEmployee>();
            LeaveOpeningDetails = new HashSet<LeaveOpeningDetail>();
            LeaveRequestDetails = new HashSet<LeaveRequestDetail>(); 
            LeaveTypeBalances = new HashSet<LeaveTypeBalance>();
            AttendanceRuleLeaveTypes = new HashSet<AttendanceRuleLeaveType>();
        }

        [Key]
        public long LeaveTypeId { get; set; }
        public string Title { get; set; }
        public string Prefix { get; set; }
        public string SortIndex { get; set; }
        public bool? IsActive { get; set; }

        public double? DayCost { get; set; } //How much to subtract for one day leave
        public double? DayPrice { get; set; } //How much to pay if user has extra leaves left and wants encashment

        public long? LeaveSubTypeId { get; set; }
        public LeaveSubType LeaveSubType { get; set; }
        
        public IEnumerable<LeavePolicy> LeavePolicies { get; set; }
        public IEnumerable<LeavePolicyEmployee> LeavePolicyEmployees { get; set; }
        public IEnumerable<LeaveOpeningDetail> LeaveOpeningDetails { get; set; }
        public IEnumerable<LeaveRequestDetail> LeaveRequestDetails { get; set; } 
        public IEnumerable<LeaveTypeBalance> LeaveTypeBalances { get; set; }
        public IEnumerable<AttendanceRuleLeaveType> AttendanceRuleLeaveTypes { get; set; }
    }
}
