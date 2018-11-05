using ErpCore.Entities.HR.Leave.LeaveSetup;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave
{
    public class LeaveRequestDetail : BaseClass
    {
        [Key]
        public long LeaveRequestDetailId { get; set; }

        public string Description { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTill { get; set; }

        public bool? IsShortLeave { get; set; }// Yes or No
        //If not short leave then multiply number of days by 1
        //If short leave then multiply value by number of days to get value

        public double? Value { get; set; } //0.25, 0.5, 0.75, 1
        public string FirstSecondHalf { get; set; } //Short Leave for first half or second half
        public double? TotalLeaveDetailValue { get; set; } //Multiply value by number of days to get here

        public long? LeaveRequestId { get; set; }
        public LeaveRequest LeaveRequest { get; set; }

        public long? LeaveYearId { get; set; }
        public LeaveYear LeaveYear { get; set; }

        public long? LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }

    }
}
