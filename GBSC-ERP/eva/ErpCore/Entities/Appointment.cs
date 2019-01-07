using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ErpCore.Entities
{
    public class Appointment : BaseClass
    {
        public Appointment()
        {
          AppointmentTests = new HashSet<AppointmentTest>();
        }

        [Key]
        public long AppointmentId { get; set; }
        public string PatientType { get; set; }
        public DateTime? TentativeTime { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? FinalTime { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public string VisitStatus { get; set; }
        public string AppointmentDay { get; set; }
        public string Remarks { get; set; }
        public bool? IsFinalAppointment { get; set; }
        public bool? IsCancelled { get; set; }

        public bool? IsPaid { get; set; }

        public IEnumerable<AppointmentTest> AppointmentTests { get; set; }
         

        public long? PatientId { get; set; }
        public Patient Patient { get; set; }

        public long?  ConsultantId { get; set; }
        public Consultant Consultant { get; set; }

        public long? VisitNatureId { get; set; }
        public VisitNature VisitNature { get; set; }

        public long? VisitId { get; set; }
        public Visit Visit { get; set; }

        public long? PatientInvoiceId { get; set; }
        public PatientInvoice PatientInvoice { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

  }
}
