using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.ViewModels
{

    public class AuthResponseViewModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Response response { get; set; }
        public AuthUser user { get; set; }
        public List<FeatureModule> ModuleFeatures { get; set; }

    }

    public class Response
    {
        public string id { get; set; }
        public string auth_token { get; set; }
        public int expires_in { get; set; }
    }

    public class AuthUser
    {
        public int userid { get; set; }
        public int roleid { get; set; }
        public int territoryid { get; set; }
        public string userType { get; set; }
        public int companyid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
    }

    public class FeatureModule
    {
        public long ModuleId { get; set; }
        public string ModuleName { get; set; }
        public IList<string> Features { get; set; }
    }

}
