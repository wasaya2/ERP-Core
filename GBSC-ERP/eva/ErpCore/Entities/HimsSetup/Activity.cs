using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErpCore.Entities.HimsSetup
{
    [Table("Activity")]
    public class Activity
    {
        public long ActivityId { get; set; }

        public string Name { get; set; }

        public string Abbrv { get; set; }

        public string Dose { get; set; }

        public string Unit { get; set; }

        public string Nature { get; set; }
    }
}
