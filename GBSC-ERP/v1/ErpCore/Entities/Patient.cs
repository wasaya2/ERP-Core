using ErpCore.Entities.HimsSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities
{

    public class Patient : BaseClass
    {
        public Patient()
        {
            Visits = new HashSet<Visit>();
            Appointments = new HashSet<Appointment>();
            PatientInvoices = new HashSet<PatientInvoice>();
            PatientDocuments = new HashSet<PatientDocument>();
        }

        [Key]
        public long PatientId { get; set; }
        public DateTime Date { get; set; }
        public string RegCity { get; set; }
        public string MRN { get; set; }
       // public string VisitNature { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Occupation { get; set; }
        public string NIC { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Remarks { get; set; }
        public string ResidenceAddress { get; set; }
        public string OfficeAddress { get; set; }
        public string OfficeTel { get; set; }
        public string ForeignAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Initial { get; set; }
        public string PrivatePatientCons { get; set; }
        public string PrivateHospital { get; set; }
        public string AuthorizedPerson { get; set; }
        public long? TotalVisitsToDate { get; set; }

        public string Display { get; set; }

        public long? PatientReferenceId { get; set; }
        public PatientReference PatientReference { get; set; }
        public string Reference { get; set; }

 
        public Partner Partner { get; set; }

        public long? VisitNatureId { get; set; }
        public VisitNature VisitNature { get; set; }
        
        public IEnumerable<PatientDocument> PatientDocuments { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<PatientInvoice> PatientInvoices { get; set; }
        public IEnumerable<Visit> Visits { get; set; }


    }
}
