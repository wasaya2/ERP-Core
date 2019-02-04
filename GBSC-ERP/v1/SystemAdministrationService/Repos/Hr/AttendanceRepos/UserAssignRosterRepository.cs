using ErpCore.Entities.HR.Attendance.AttendanceSetup;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.Repos.Hr.AttendanceRepos.Interfaces;

namespace SystemAdministrationService.Repos.Hr.AttendanceRepos
{
    public class UserAssignRosterRepository : RepoBase<UserAssignRoster>, IUserAssignRosterRepository
    {
        public IEnumerable<UserAssignRoster> GetAssignedRostersByUser(long userid, DateTime fromdate, DateTime todate)
        {
            var c = Table.Where(a => a.UserId == userid).Include(a => a.AssignRoster).Include("AssignRoster.Daysoffs").ToList().OrderByDescending(a => a.AssignRosterId);
            return c.Where(a => a.AssignRoster.FromDate.Value.Date >= fromdate.Date
                    && a.AssignRoster.FromDate.Value.Month >= fromdate.Month
                    && a.AssignRoster.FromDate.Value.Year >= fromdate.Year
                    && a.AssignRoster.ToDate.Value.Date <= todate.Date
                    && a.AssignRoster.ToDate.Value.Month <= todate.Month
                    && a.AssignRoster.ToDate.Value.Year <= todate.Year).ToList();
        }
    }
}
