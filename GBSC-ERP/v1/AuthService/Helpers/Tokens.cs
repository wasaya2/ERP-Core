using AuthService.ViewModels;
using AuthService.Auth;
using ErpInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ErpCore.Models;

namespace AuthService.Helpers
{
    public class Tokens
    {
        public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            try
            {
                ApplicationDbContext Db = new ApplicationDbContext();

                var id = identity.Claims.Single(a => a.Type == "id").Value;

                var user1 = Db.Users.Include(u => u.Identity).FirstOrDefault(u => u.IdentityId == id);

                var userfeatures = (from user in Db.Users
                                    join rolefeatures in Db.RoleFeatures on user.RoleId equals rolefeatures.RoleId
                                    join features in Db.Features on rolefeatures.FeatureId equals features.FeatureId
                                    join modules in Db.Modules on features.ModuleId equals modules.ModuleId
                                    where user.UserId == user1.UserId
                                    group features.Name by features.Module.Name into g
                                    select new FeatureModule()
                                    {
                                        ModuleName = g.Key,
                                        Features = g.ToList()
                                    }).ToList();

                AuthResponseViewModel ar = new AuthResponseViewModel
                {
                    UserLevel = user1?.UserLevel,
                    FullName = user1.FullName,
                    UserId = user1.UserId,
                    ModuleFeatures = userfeatures,
                    AssignedId = new UserAssignedIds
                    {
                        CompanyId = user1.CompanyId,
                        BranchId = user1.BranchId,
                        CityId = user1.CityId,
                        CountryId = user1.CountryId
                    },
                    Response = new Response
                    {
                        Id = id,
                        AuthToken = await jwtFactory.GenerateEncodedToken(userName, identity),
                        Expiry = (int)jwtOptions.ValidFor.TotalMinutes,
                    },
                    IsSuperAdmin = false,
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

        public static async Task<string> GenerateJwtForSuperAdmin(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            try
            {

                AuthResponseViewModel ar = new AuthResponseViewModel
                {
                    Response = new Response
                    {
                        Id = identity.Claims.Single(a => a.Type == "id").Value,
                        AuthToken = await jwtFactory.GenerateEncodedToken(userName, identity),
                        Expiry = (int)jwtOptions.ValidFor.TotalMinutes,
                    },
                    IsSuperAdmin = true,
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
