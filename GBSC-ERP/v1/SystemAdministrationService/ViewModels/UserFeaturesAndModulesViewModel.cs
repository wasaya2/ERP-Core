using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAdministrationService.ViewModels
{
    public class UserFeaturesAndModulesViewModel
    {
        public long UserId { get; set; }
        public List<string> Features { get; set; }
        public List<string> Modules { get; set; }
    }
}
