using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    [Table("Event")]
    public class Event
    {
        public long EventId { get; set; }

        public string Name { get; set; }

        public bool? IsActive { get; set; }

        public string Days { get; set; }

        public string Weeks { get; set; }

        public int Sequence { get; set; }
    }
}
