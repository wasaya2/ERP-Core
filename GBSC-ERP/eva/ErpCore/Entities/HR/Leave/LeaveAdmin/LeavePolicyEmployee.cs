using ErpCore.Entities.HR.Attendance;
using ErpCore.Entities.HR.Leave.LeaveSetup;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave.LeaveAdmin
{
    public class LeavePolicyEmployee : BaseClass
    {
        public LeavePolicyEmployee()
        {
            UserRosterAttendances = new HashSet<UserRosterAttendance>();
            ProrateMatrices = new HashSet<ProrateMatrix>();
            DecimalRoundingMatrices = new HashSet<DecimalRoundingMatrix>();
        }

        [Key]
        public long LeavePolicyEmployeeWiseId { get; set; }
        public bool? IsProcessed { get; set; } //True once processed

        public bool? IsPeriodic { get; set; }
        public DateTime? PeriodicFrom { get; set; }
        public DateTime? PeriodicTill { get; set; }

        public double? EntitledQuantity { get; set; } //InDays
        public double? MaximumAllowedBalance { get; set; } //InDays

        public double? MaximumAtATime { get; set; } //InDays
        public double? MinimumAtATime { get; set; } //InDays
        public bool? DayContinuationRestriction { get; set; } //Yes or No
        public double? MinimumIntimationPeriod { get; set; } //InDays
        public bool? IsEncashable { get; set; }
        public double? EncashmentDays { get; set; }
        public double? EncashmentApplicationLimit { get; set; }

        public bool? IsMale { get; set; }
        public bool? IsFemale { get; set; }
        public bool? IsMarried { get; set; }
        public bool? IsBalanceBroughtForward { get; set; }
        public double? BalanceBroughtForwardQuantity { get; set; } //InDays
        public double? BalanceBroughtForwardValidity { get; set; } //InMonths
        public bool? IsFileAttachmentRequired { get; set; }
        public bool? IsShortLeaveAllowed { get; set; }
        public double? ShortLeaveLimit { get; set; } //InDays
        public bool? IsAllowedOnlyOnceInService { get; set; }
        public bool? IsJobPeriodBased { get; set; }
        public double? JobPeriodTime { get; set; } //InMonths
        public double? PaidDaysQuantity { get; set; } //InDays
        public double? HalfPaidDaysQuantity { get; set; } //InDays
        public double? UnPaidDaysQuantity { get; set; } //InDays
        
        public bool? IsProrated { get; set; }
        
        public IEnumerable<ProrateMatrix> ProrateMatrices { get; set; }
        public IEnumerable<DecimalRoundingMatrix> DecimalRoundingMatrices { get; set; }

        public long? LeaveYearId { get; set; }
        public LeaveYear LeaveYear { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }

        public long? LeaveDayTypeId { get; set; }
        public LeaveDayType LeaveDayType { get; set; }

        public long? LeaveEligibilityId { get; set; }
        public LeaveEligibility LeaveEligibility { get; set; }

        public IEnumerable<UserRosterAttendance> UserRosterAttendances { get; set; }
    }
}
