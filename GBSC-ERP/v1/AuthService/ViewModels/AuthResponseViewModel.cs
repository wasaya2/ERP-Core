using ErpCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.ViewModels
{
    public class AuthResponseViewModel
    {
        public User User { get; set; }

        public UserAssignedIds AssignedId { get; set; }

        public List<string> Modules { get; set; }

        public List<string> Features { get; set; }

        public bool Status { get; set; }

        public bool IsSuperAdmin { get; set; }

        public string Message { get; set; }

        public Response Response { get; set; }
    }

    public class Response
    {
        public string Id { get; set; }

        public string AuthToken { get; set; }

        public int Expiry { get; set; }
    }

    public class UserAssignedIds
    {
        public long? CompanyId { get; set; }

        public long? CountryId { get; set; }
        
        public long? CityId { get; set; }

        public long? BranchId { get; set; }
    }
}
