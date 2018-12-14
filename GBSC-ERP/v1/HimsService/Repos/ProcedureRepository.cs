using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ErpCore.Entities.HimsSetup;
using HimsService.Repos.Base;
using HimsService.Repos.Interfaces;

namespace HimsService.Repos
{
    public class ProcedureRepository : RepoBase<Procedure>, IProcedureRepository
    {
    }
}
