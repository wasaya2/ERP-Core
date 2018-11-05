using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities
{

    public class Partner : BaseClass
    {
        [Key]
        public long PartnerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Occupation { get; set; }
        public string NIC { get; set; }
        public string PhoneNumber { get; set; }

        public string Display { get; set; }

        public long? PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
