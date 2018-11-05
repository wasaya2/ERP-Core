using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.ViewModels.Validation
{

    public class AuthResponseViewModel
    {
        public object User { get; set; }
        public string[] Features { get; set; }
        public string[] Modules { get; set; }
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

}
