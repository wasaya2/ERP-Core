using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETrackerService.ViewModels
{
    public class UsersViewModel
    {
        public long UserId { get; set; }

        public string UserLevel { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Territory { get; set; }

        public string Section { get; set; }

        public long? SectionId { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Cnic { get; set; }

        public DateTime? DOB { get; set; }

        public string Address { get; set; }


    }
}
