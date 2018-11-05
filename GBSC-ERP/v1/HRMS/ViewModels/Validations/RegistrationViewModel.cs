using ErpCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.ViewModels.Validations
{
    public class RegistrationViewModel
    {
        public long UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string CNIC { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public DateTime DateCreated { get; set; }
        public string Organization { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }
        public string Role { get; set; }
    }
}
