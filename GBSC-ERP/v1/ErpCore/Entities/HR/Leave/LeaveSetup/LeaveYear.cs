using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Leave.LeaveSetup
{
    public class LeaveYear : BaseClass
    {
        [Key]
        public long LeaveYearId { get; set; }
        public string Name { get; set; }
        public string Year { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsCurrentYear { get; set; }
    }
}
