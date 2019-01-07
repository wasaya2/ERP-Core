using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ErpCore.Entities
{
    public class PatientDocument : BaseClass
    {
        [Key]
        public long PatientDocumentId { get; set; }
        public string DocumentName { get; set; }
        public string FilePath { get; set; }
        public string Remarks { get; set; }

        public long? PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
