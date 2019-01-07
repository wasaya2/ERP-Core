using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.ViewModels.Validations
{
    public class ShopkeeperRegistrationViewModel
    {
        public long ShopkeeperId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Cnic { get; set; }

        public DateTime? Dob { get; set; }

        public string ContactNumber { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public long StoreId { get; set; }
    }
}
