using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemAdministrationService.Repos.Interfaces;

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

        [HttpGet("FeaturePermissions/{userid}/{RoleId}/{featureid}")]
        public IEnumerable<Permission> FeaturePermissions(long userid, long RoleId, long featureid)
        {
            IEnumerable<Permission> per = permissionRepo.GetFeaturePermissions(userid, RoleId, featureid).Permissions.ToList();
            return per;
        }


    }
}