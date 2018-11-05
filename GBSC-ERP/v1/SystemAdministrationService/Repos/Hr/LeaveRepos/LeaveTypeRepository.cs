using SystemAdministrationService.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities.HR.Leave.LeaveSetup; 
using SystemAdministrationService.Repos.Hr.LeaveRepos.Interfaces;

namespace SystemAdministrationService.Repos.Hr.LeaveRepos
{
    public class LeaveTypeRepository : RepoBase<LeaveType>, ILeaveTypeRepository
    {
    }
}
