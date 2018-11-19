using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class PatientInvoiceReturn : BaseClass
    {
        public PatientInvoiceReturn()
        {
            PatientInvoiceReturnItems = new HashSet<PatientInvoiceReturnItem>();
        }

        [Key]
        public long PatientInvoiceReturnId { get; set; }
        public string InvoiceReturnNumber { get; set; } //AutoGenerate

        public DateTime? ReturnDate { get; set; }
        public string Remarks { get; set; }
        public double? TotalReturnAmount { get; set; }

        public long? PatientInvoiceId { get; set; }
        public PatientInvoice PatientInvoice { get; set; }

        public long? PatientId { get; set; }
        public Patient Patient { get; set; }

        public IEnumerable<PatientInvoiceReturnItem> PatientInvoiceReturnItems { get; set; }
    }
}
