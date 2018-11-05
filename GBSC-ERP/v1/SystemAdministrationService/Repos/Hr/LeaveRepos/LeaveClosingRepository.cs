using ErpCore.Entities.HR.Leave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.Repos.Hr.LeaveRepos.Interfaces;

namespace SystemAdministrationService.Repos.Hr.LeaveRepos
{
    public class LeaveClosingRepository : RepoBase<LeaveClosing>, ILeaveClosingRepository
    {
    }
}
