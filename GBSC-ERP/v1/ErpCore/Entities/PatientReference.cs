using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PatientReference : BaseClass
    {
    public PatientReference()
    {
       Patients = new HashSet<Patient>();
    }
        [Key]
        public long PatientReferenceId { get; set; }
        public string ReferredBy { get; set; }
        public string Initial { get; set; }
        public string PersonName { get; set; }
        public string RefAddress { get; set; }
        public string ReferenceTel { get; set; }

        //public long? PatientId { get; set; }
        //public Patient Patient { get; set; }

         public IEnumerable<Patient> Patients { get; set; }
    }
}
