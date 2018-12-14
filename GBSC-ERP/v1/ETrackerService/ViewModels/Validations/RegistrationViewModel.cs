using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.ViewModels.Validations
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
        public string ContactNumber { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string CNIC { get; set; }
        public string Organization { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Role { get; set; }
    }
}
