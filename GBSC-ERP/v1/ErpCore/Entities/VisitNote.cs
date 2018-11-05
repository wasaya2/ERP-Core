using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class VisitNote
    {
        [Key]
        public long VisitNoteId { get; set; }
        public string ClinicalNote { get; set; }
        
        public long? VisitId { get; set; }
        public Visit Visit { get; set; }
    }
}
