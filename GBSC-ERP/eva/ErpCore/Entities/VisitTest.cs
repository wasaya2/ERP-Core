using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class VisitTest
    {
        [Key]
        public long VisitTestId { get; set; }

        public bool? IsPaid { get; set; }

        public string Remarks { get; set; }

        public long? TestId { get; set; }

        public Test  Test { get; set; }

        public long? VisitId { get; set; }

        public Visit Visit { get; set; }
    }
}
