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
            var user = db.Users.Include("Distributor")
                .Where(u => u.IdentityId == identity.Claims.Single(c => c.Type == "id").Value)
                .Select(u => new AuthResponseViewModel
                {
                    userid = u.UserId != 0 ? u.UserId : 0,
                    territoryid = u.Distributor != null ? u.Distributor.TerritoryId : 0,
                    email = u.Email,
                    firstname = u.FirstName,
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
                user = user
            };

            return JsonConvert.SerializeObject(result, serializerSettings);
        }


    }
}
