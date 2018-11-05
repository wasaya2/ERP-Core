using SystemAdministrationService.Repos.Base;
using ErpCore.Entities;
using SystemAdministrationService.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAdministrationService.Repos
{
    public class CountryRepository : RepoBase<Country>, ICountryRepository
    {
    }
}
