﻿using ErpCore.Entities.HR.Attendance.AttendanceAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemAdministrationService.Repos.Base;
using SystemAdministrationService.Repos.Hr.AttendanceRepos.Interfaces;

namespace SystemAdministrationService.Repos.Hr.AttendanceRepos
{
    public class AttendanceFlagExemptionRepository :RepoBase<AttendanceFlagExemption>, IAttendanceFlagExemptionRepository
    {
    }
}
