using eTrackerInfrastructure.Auth;
using eTrackerInfrastructure.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using eTrackerInfrastructure.ViewModels;
using ErpInfrastructure.Data;

namespace eTrackerInfrastructure.Helpers
{
    public class Tokens
    {

        public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var id = identity.Claims.Single(a => a.Type == "id").Value;
            var user1 = db.Users.Include(u => u.Identity).FirstOrDefault(u => u.IdentityId == id);

            var userfeatures = (from user in db.Users
                                join rolefeatures in db.RoleFeatures on user.RoleId equals rolefeatures.RoleId
                                join features in db.Features on rolefeatures.FeatureId equals features.FeatureId
                                join modules in db.Modules on features.ModuleId equals modules.ModuleId
                                where user.UserId == user1.UserId
                                group features.Name by features.Module.Name into g
                                select new FeatureModule()
                                {
                                    ModuleName = g.Key,
                                    Features = g.ToList()
                                }).ToList();

            var loggeduser = db.Users
                .Where(u => u.IdentityId == id)
                .Select(u => new
                {
                    userid = u.UserId != 0 ? u.UserId : 0,
                    roleid = u.RoleId,
                    territoryid = u.Section != null ? u.Section.TerritoryId : 0,
                    companyid = u.CompanyId,
                    email = u.Email,
                    firstname = u.FirstName,
                    userType = u.UserType,
                    lastname = u.LastName
                }).FirstOrDefault();

            var result = new
            {
                status = true,
                message = "Login Success",
                response = new
                {
                    id = identity.Claims.Single(c => c.Type == "id").Value,
                    auth_token = await jwtFactory.GenerateEncodedToken(userName, identity),
                    expires_in = (int)jwtOptions.ValidFor.TotalSeconds
                },
                user = loggeduser,
                moduleFeatures = userfeatures
            };

            return JsonConvert.SerializeObject(result, serializerSettings);
        }


    }
}
