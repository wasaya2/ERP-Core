using System;
using System.Collections.Generic;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    public class ProtocolwiseEvent
    {
        public long ProtocolwiseEventId { get; set; }

        public string EventType { get; set; }

        public string Description { get; set; }

        public string Phase { get; set; }

        public bool? M { get; set; }

        public bool? T { get; set; }

        public bool? U { get; set; }

        public string YearDays { get; set; }

        public string PhaseOneDays { get; set; }

        public string PhaseTwoDays { get; set; }

        public string PhasethreeDays { get; set; }

        public string Weeks { get; set; }

        public int Sequence { get; set; }
    }
}
