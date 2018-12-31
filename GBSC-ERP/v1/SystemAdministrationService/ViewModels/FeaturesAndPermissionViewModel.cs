using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAdministrationService.ViewModels
{
    public class FeaturesAndPermissionViewModel
    {
        public string FeatureName { get; set; }

        public IEnumerable<string> Permissions { get; set; }
    }
}
