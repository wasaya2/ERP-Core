using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAdministrationService.ViewModels
{
    public class CompanyInfoViewModel
    {
        public string Name { get; set; }

        public long? NumberOfEmployees { get; set; }

        public List<string> Modules { get; set; }

        public List<long> ModuleIds { get; set; }
    }
}
