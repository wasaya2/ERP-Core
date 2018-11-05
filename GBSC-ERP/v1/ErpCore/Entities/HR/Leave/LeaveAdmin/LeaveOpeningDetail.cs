using ErpCore.Entities.HR.Leave.LeaveSetup;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave.LeaveAdmin
{
    public class LeaveOpeningDetail : BaseClass
    {
        [Key]
        public long LeaveOpeningDetailId { get; set; }
        public double? Quantity { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public long? LeaveOpeningId { get; set; }
        public LeaveOpening LeaveOpening { get; set; }

        public long? LeaveTypeId { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}
