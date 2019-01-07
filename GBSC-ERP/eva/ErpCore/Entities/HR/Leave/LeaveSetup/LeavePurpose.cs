using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave.LeaveSetup
{
    public class LeavePurpose : BaseClass
    {
        [Key]
        public long LeavePurposeId { get; set; }
        public string Title { get; set; }
        public bool? IsActive { get; set; }
    }
}
