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
        private IFeatureRepository fea_repo;

        public CompanySetupController(IModuleRepository _module_repo, ICompanyRepository _comp_repo, IUserRepository _user_repo, IFeatureRepository fearepo)
        {
            module_repo = _module_repo;
            comp_repo = _comp_repo;
            user_repo = _user_repo;
            fea_repo = fearepo;
        }

        [HttpGet("GetCompanyInfo/{CompanyId}")]
        public CompanyInfoViewModel GetCompanyInfo(long CompanyId)
        {
            var company = comp_repo.Find(CompanyId);
            var modules = module_repo.GetList(m => m.CompanyId == CompanyId);
            var modulenames = modules.Select(a => a.Name).ToList();
            var moduleids = modules.Select(a => a.ModuleId).ToList();

            return new CompanyInfoViewModel
            {
                Name = company.Name,
                NumberOfEmployees = company.NumberOfEmployees ?? 0,
                Modules = modulenames,
                ModuleIds = moduleids
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
            if (module.Name == "eTrackerMobile")
            {
                features = AllFeatures.ETrackerMobile;
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
                        CompanyId = module.CompanyId,
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

        [HttpPost("GetAllModuleFeatures", Name = "GetAllModuleFeatures")]
        public IEnumerable<Feature> GetAllModuleFeatures([FromBody]IList<long> moduleids)
        {
            var AllFeatures = ReadJson();

            List<string> features = new List<string>();
            IList<Feature> featureList = new List<Feature>();

            foreach (long moduleid in moduleids)
            {
                Module module = module_repo.Find(moduleid);

                if (module.Name == "Human Resource Management")
                {
                    features.AddRange(AllFeatures.HRMS);
                }
                if (module.Name == "Hospital Management System")
                {
                    features.AddRange(AllFeatures.HIMS);
                }
                if (module.Name == "Payroll Management System")
                {
                    features.AddRange(AllFeatures.Payroll);
                }
                if (module.Name == "Lab Information System")
                {
                    features.AddRange(AllFeatures.Lab);
                }
                if (module.Name == "Inventory")
                {
                    features.AddRange(AllFeatures.Inventory);
                }
                if (module.Name == "eTracker")
                {
                    features.AddRange(AllFeatures.ETracker);
                }
                if (module.Name == "eTrackerMobile")
                {
                    features.AddRange(AllFeatures.ETrackerMobile);
                }
                if (module.Name == "Security Admin")
                {
                    features.AddRange(AllFeatures.Security);
                }

                if (features != null)
                {
                    foreach (var feature in features)
                    {

                        var feat = new Feature
                        {
                            CompanyId = module.CompanyId,
                            ModuleId = module.ModuleId,
                            Name = feature
                        };

                        featureList.Add(feat);
                    }
                }
            }
            return featureList;
        }

        [HttpPost("AddCompanyFeatures", Name = "AddCompanyFeatures")]
        public IActionResult AddCompanyFeature([FromBody]IEnumerable<Feature> features)
        {
            try
            {
                fea_repo.AddRange(features);
                return Ok("Company Features Updated");
            }
            catch (Exception)
            {
                return BadRequest("Unable to update company features");
            }
        }


    }
}