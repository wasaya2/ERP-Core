using ErpInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ErpCore.Models;
using ErpInfrastructure.Auth;
using ErpInfrastructure.ViewModels;

namespace ErpInfrastructure.Helpers
{
    public class Tokens
    {
        public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            try
            {
                ApplicationDbContext Db = new ApplicationDbContext();

                var usr = Db.Users.Include(i => i.Identity)
                    .FirstOrDefault(u => u.Identity.UserName == userName);

                var userfeatures = (from user in Db.Users
                                    join rolefeatures in Db.RoleFeatures on user.RoleId equals rolefeatures.RoleId
                                    join features in Db.Features on rolefeatures.FeatureId equals features.FeatureId
                                    select features.Name).ToList();

                var usermodules = (from user in Db.Users
                                   join rolemodules in Db.RoleModules on user.RoleId equals rolemodules.RoleId
                                   join modules in Db.Modules on rolemodules.ModuleId equals modules.ModuleId
                                   select modules.Name).ToList();

                AuthResponseViewModel ar = new AuthResponseViewModel
                {
                    User = usr,
                    Features = userfeatures,
                    Modules = usermodules,
                    Response = new Response
                    {
                        Id = identity.Claims.Single(a => a.Type == "id").Value,
                        AuthToken = await jwtFactory.GenerateEncodedToken(userName, identity),
                        Expiry = (int)jwtOptions.ValidFor.TotalMinutes,
                    },
                    Status = true,
                    Message = "Login Successful"
                };

                return JsonConvert.SerializeObject(ar, serializerSettings);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
