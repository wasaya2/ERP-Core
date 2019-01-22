using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemAdministrationService.Repos.Interfaces;
using SystemAdministrationService.ViewModels;

namespace SystemAdministrationService.Controllers
{
    [Produces("application/json")]
    [Route("api/UserPermissions")]
    public class UserPermissionsController : Controller
    {
        private IPermissionRepository permissionRepo;

        public UserPermissionsController(IPermissionRepository _permissionRepo)
        {
            permissionRepo = _permissionRepo;
        }

        [HttpGet("FeaturePermissions/{userid}/{feature}/{module}")]
        public IList<string> FeaturePermissions(long userid, string feature, string module)
        {
            return permissionRepo.GetFeaturePermissions(userid, feature, module);
        }


    }
}