using ErpCore.Entities;
using ErpCore.Entities.HR.Leave.LeaveSetup;
using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave.LeaveAdmin
{
    public class LeaveOpening : BaseClass
    {
        public LeaveOpening()
        {
            LeaveOpeningDetails = new HashSet<LeaveOpeningDetail>();
        }

        [Key]
        public long LeaveOpeningId { get; set; }
        public string Remarks { get; set; }
        public bool? IsProcessed { get; set; } //True once processed

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? LeaveYearId { get; set; }
        public LeaveYear LeaveYear { get; set; }

        public IEnumerable<LeaveOpeningDetail> LeaveOpeningDetails { get; set; }

        public long? LeaveRequestId { get; set; }
        public LeaveRequest LeaveRequest { get; set; }
    }
}
