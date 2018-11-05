using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class Visit : BaseClass
    {
        [Key]
        public long VisitId { get; set; }
        public string Description { get; set; }

        public DateTime? VisitDate { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool? IsActive { get; set; }

        public long? PatientVitalId { get; set; }

        public PatientVital PatientVital { get; set; }

        public long? VisitNoteId { get; set; }

        public VisitNote VisitNote { get; set; }

        public long? PatientId { get; set; }

        public Patient Patient { get; set; }

        public IEnumerable<VisitDiagnosis> VisitDiagnoses  { get; set; }

        public IEnumerable<VisitTest> VisitTests { get; set; }

        //public long? AppointmentId { get; set; }
        //public Appointment Appointment { get; set; }
    }
}
