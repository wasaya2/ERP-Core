using ErpCore.Entities;
using ErpInfrastructure.Data;
using eTrackerInfrastructure.Repos.Base;
using eTrackerInfrastructure.Repos.Interfaces;
using eTrackerInfrastructure.ViewModels;
using ETrackerService.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Repos
{
    public class UserRepository : RepoBase<User>, IUserRepository
    {

        public string AssignSubsections(IList<SectionAssignmentViewModel> model)
        {
            try
            {
                foreach (var item in model)
                {
                    var subsection = Context.Subsections.FirstOrDefault(m => m.SubsectionId == item.SubsectionId);
                    if (subsection != null)
                    {
                        if ((subsection.UserId != null && item.UserId == subsection.UserId && !item.IsAssigned) || item.UserId < 1)
                        {
                            subsection.UserId = null;
                        }
                        else
                        {
                            subsection.UserId = item.UserId;
                        }

                        Context.Subsections.Update(subsection);
                    }
                }

                Context.SaveChanges();
                return "Subsections assigned";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }

        public void ClearAssignments(long UserId)
        {
            var regions = Context.Regions.Where(u => u.UserId == UserId).ToList();
            var cities = Context.Cities.Where(u => u.UserId == UserId).ToList();
            var areas = Context.Areas.Where(u => u.UserId == UserId).ToList();
            var territories = Context.Territories.Where(u => u.UserId == UserId).ToList();
            var section = Context.Sections.FirstOrDefault(u => u.UserId == UserId);

            for (int i = 0; i < regions.Count; i++)
            {
                regions[i].UserId = null;
            }

            for (int i = 0; i < cities.Count; i++)
            {
                cities[i].UserId = null;
            }

            for (int i = 0; i < areas.Count; i++)
            {
                areas[i].UserId = null;
            }

            for (int i = 0; i < territories.Count; i++)
            {
                territories[i].UserId = null;
            }

            if (section != null)
            {
                section.UserId = null;
                Context.Sections.Update(section);
            }

            if (regions.Count > 0)
                Context.Regions.UpdateRange(regions);
            if (cities.Count > 0)
                Context.Cities.UpdateRange(cities);
            if (areas.Count > 0)
                Context.Areas.UpdateRange(areas);
            if (territories.Count > 0)
                Context.Territories.UpdateRange(territories);

            SaveChanges();
        }

        public bool CnicExists(string cnic)
        {
            return Table.FirstOrDefault(u => u.CNIC == cnic) != null ? true : false;
        }

        public IList<User> GetAllUsersWithRelationships()
        {
            return Table.ToList();
        }

        public IEnumerable<UsersViewModel> GetUsers(long userId)
        {
            var _user = Find(userId);

            var users = new List<UsersViewModel>();

            var commandText = "";

            if (_user.UserLevel == "Admin" || _user.UserLevel == "NSM" || _user.UserLevel == "RSM" || _user.UserLevel == "HO")
            {
                var regions = Context.Regions.Where(r => r.UserId == userId);

                foreach (var region in regions)
                {
                    commandText = $"select * from fn_etracker_getusersbyregion({region.RegionId})";

                    users.AddRange(ReadSqlUser(commandText));
                }
            }
            else if (_user.UserLevel == "ZSM")
            {
                var cities = Context.Cities.Where(u => u.UserId == userId);

                foreach (var city in cities)
                {
                    commandText = $"select * from fn_etracker_getusersbycity({city.CityId})";

                    users.AddRange(ReadSqlUser(commandText));
                }
            }
            else if (_user.UserLevel == "ASM")
            {
                var areas = Context.Areas.Where(a => a.UserId == userId);

                foreach (var area in areas)
                {
                    commandText = $"select * from fn_etracker_getusersbyarea({area.AreaId})";

                    users.AddRange(ReadSqlUser(commandText));
                }
            }
            else if (_user.UserLevel == "TSO/KPO")
            {
                var territories = Context.Territories.Where(u => u.UserId == userId);

                foreach (var territory in territories)
                {
                    commandText = $"select * from fn_etracker_getusersbyterritory({territory.TerritoryId})";

                    users.AddRange(ReadSqlUser(commandText));
                }
            }
            else if (_user.UserLevel == "DSF")
            {
                var section = Context.Sections.FirstOrDefault(u => u.UserId == userId);

                commandText = $"select * from fn_etracker_getusersbysection({section.SectionId})";

                users.AddRange(ReadSqlUser(commandText));
            }

            return users;
        }

        private List<UsersViewModel> ReadSqlUser(string commandText)
        {
            List<UsersViewModel> users = new List<UsersViewModel>();

            using (var context = new ApplicationDbContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = commandText;
                    context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        if (result.HasRows)
                        {
                            while (result.Read())
                            {
                                users.Add(ReadSqlUserRow(result));

                            }
                        }
                    }
                }

                return users;
            }
        }

        private static UsersViewModel ReadSqlUserRow(IDataRecord result)
        {
            try
            {
                return new UsersViewModel
                {
                    UserId = result.GetValueOrDefault<long>(0),
                    UserLevel = result.GetValueOrDefault<string>(1),
                    FirstName = result.GetValueOrDefault<string>(2),
                    LastName = result.GetValueOrDefault<string>(3),
                    Territory = result.GetValueOrDefault<string>(4),
                    Section = result.GetValueOrDefault<string>(5),
                    SectionId = result.GetValueOrDefault<long>(6),
                    Email = result.GetValueOrDefault<string>(7),
                    Phone = result.GetValueOrDefault<string>(8),
                    Cnic = result.GetValueOrDefault<string>(9),
                    DOB = result.GetValueOrDefault<DateTime?>(10),
                    Address = result.GetValueOrDefault<string>(11),
                };
            }
            catch (System.Exception e)
            {

                throw;
            }
        }



        public IList<User> GetSalesUsers()
        {

            return Table.Where(u => u.SectionId > 0)
                .OrderByDescending(u => u.UserId)
                .ToList();
        }

        public User GetUserByIdentityId(string id) => Table.FirstOrDefault(u => u.IdentityId == id);


    }
}
