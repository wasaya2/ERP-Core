using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PatientInvoice : BaseClass
    {
        public PatientInvoice()
        {
            PatientInvoiceItems = new HashSet<PatientInvoiceItem>();
        }

        [Key]
        public long PatientInvoiceId { get; set; }
        public string SlipNumber { get; set; }
        //public string Gender { get; set; }
        //public string PatientName { get; set; }
        //public string PartnerName { get; set; }
        public DateTime? DateCreated { get; set; }
        public string InvoiceType { get; set; }
        //public string FileNumber { get; set; }
        public double? AmountToPay { get; set; }
        public double? PreviousAmout { get; set; }
        public double? PaidAmount { get; set; }
        public double? BalanceAmount { get; set; }
        public string InvoiceRemarks { get; set; }
        public string Consultant { get; set; }
        public string PaymentMethod { get; set; }
        public string ChequeNumber { get; set; }
        public string Bank { get; set; }

        public long? PatientId { get; set; }
        public Patient Patient { get; set; }

        public long? AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<PatientInvoiceItem> PatientInvoiceItems { get; set; }
    }
}
