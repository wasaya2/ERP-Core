using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SystemAdministrationService.Repos.Interfaces;
using SystemAdministrationService.ViewModels;

namespace SystemAdministrationService.Controllers
{
    [Produces("application/json")]
    [Route("api/CompanySetup")]
    public class CompanySetupController : Controller
    {
        private IModuleRepository module_repo;
        private ICompanyRepository comp_repo;
        private IUserRepository user_repo;

        public CompanySetupController(IModuleRepository _module_repo, ICompanyRepository _comp_repo, IUserRepository _user_repo)
        {
            module_repo = _module_repo;
            comp_repo = _comp_repo;
            user_repo = _user_repo;
        }

        [HttpGet("GetCompanyInfo/{CompanyId}")]
        public CompanyInfoViewModel GetCompanyInfo(long CompanyId)
        {
            var company = comp_repo.Find(CompanyId);
            var modules = module_repo.GetList(m => m.CompanyId == CompanyId).Select(c => c.Name).ToList();

            return new CompanyInfoViewModel
            {
                Name = company.Name,
                NumberOfEmployees = company.NumberOfEmployees ?? 0,
                Modules = modules
            };
        }

        [HttpPost("AddModuleWithAllFeatures")]
        [ValidateModelAttribute]
        public IActionResult AddModuleWithAllFeatures([FromBody]Module module)
        {
            var AllFeatures = ReadJson();

            string[] features = null;

            if (module.Name == "Human Resource Management")
            {
                features = AllFeatures.HRMS;
            }
            if (module.Name == "Hospital Management System")
            {
                features = AllFeatures.HIMS;
            }
            if (module.Name == "Payroll Management System")
            {
                features = AllFeatures.Payroll;
            }
            if (module.Name == "Lab Information System")
            {
                features = AllFeatures.Lab;
            }
            if (module.Name == "Inventory")
            {
                features = AllFeatures.Inventory;
            }
            if (module.Name == "eTracker")
            {
                features = AllFeatures.ETracker;
            }
            if (module.Name == "Security Admin")
            {
                features = AllFeatures.Security;
            }


            List<Feature> featureList = new List<Feature>();

            if (features != null)
            {
                foreach (var feature in features)
                {

                    var feat = new Feature
                    {
                        ModuleId = module.ModuleId,
                        Name = feature
                    };

                    featureList.Add(feat);
                }

                module.Features = featureList;
            }

            module_repo.Add(module);

            return new OkObjectResult(new { ModuleID = module.ModuleId });
        }

        internal FeaturesViewModel ReadJson()
        {
            var rootPath = System.IO.Directory.GetCurrentDirectory();

            DirectoryInfo d = new DirectoryInfo(Path.Combine(rootPath, "JsonFiles"));

            FileInfo[] Files = d.GetFiles("Features.json"); //Getting JSON files

            foreach (var file in Files)
            {
                using (StreamReader r = new StreamReader(file.FullName))
                {
                    var json = r.ReadToEnd();
                    var jobj = JObject.Parse(json);
                    var result = jobj.ToString();

                    var featurs = Newtonsoft.Json.JsonConvert.DeserializeObject<FeaturesViewModel>(result);

                    return featurs;
                }
            }

            return null;
        }
    }
}