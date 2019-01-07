using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities.HRSetup;

namespace SystemAdministrationService.ViewModels
{
    public class UpdateUserViewModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string FullName { get; set; }
        public string POB { get; set; }
        public DateTime? DOB { get; set; }
        public string CNIC { get; set; }
        public DateTime? CNICExpiry { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserLanguage> UserLanguages { get; set; }
        public long? ReligionId { get; set; }
        public long? CityId { get; set; }
        public long? GroupId { get; set; }
        public long? DepartmentId { get; set; }
        public string BloodGroup { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string HomePhone { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PermanentAddress { get; set; }

  }
}
