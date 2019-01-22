using ErpCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAdministrationService.ViewModels
{
    public class UserPermissionsViewModel
    {
        public long? FeatureId { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
