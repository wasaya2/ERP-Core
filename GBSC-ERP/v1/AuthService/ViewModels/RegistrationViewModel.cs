using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.ViewModels
{
    public class RegistrationViewModel
    {
        public long UserId { get; set; }
        public long? CompanyId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public long? CityId { get; set; }
        public long? RoleId { get; set; }
        public string CNIC { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsSystemAdmin { get; set; }
        public bool UserExists { get; set; }
    }
}
