using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Entities.HRSetup;
using ErpCore.Filters;
using ErpCore.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemAdministrationService.Repos.HrSetupRepos.HrSetupInterfaces;
using SystemAdministrationService.Repos.Interfaces;
using SystemAdministrationService.ViewModels;

namespace SystemAdministrationService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserRepository _repo;
        private IUserDocumentRepository doc_repo;
        private IUserCompanyRepository userCompany_repo;
        private IBankRepository userBank_repo;
        private IRelationRepository relation_repo;
        private IWorkExperienceRepository exp_repo; 
        private IUniversityRepository uni_repo;
        private IUserLanguageRepository usrlang_repo;

        public UsersController(IUserRepository repo, IUserLanguageRepository usrlangrepo, IUserDocumentRepository docrepo, IUniversityRepository unirepo, IUserCompanyRepository usercomrepo, IBankRepository userbankrepo,IRelationRepository relationrepo, IWorkExperienceRepository exprepo)
        {
            _repo = repo;
            doc_repo = docrepo;
            uni_repo = unirepo;
            userCompany_repo = usercomrepo;
            userBank_repo = userbankrepo;
            relation_repo = relationrepo;
            exp_repo = exprepo;
            usrlang_repo = usrlangrepo;
        }

        #region User
        [HttpGet("GetUsers", Name = "GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            IEnumerable<User> us = _repo.GetAll(a => a.Relations);
            us = us.OrderByDescending(a => a.UserId);
            return us;
        }

        [HttpGet("GetUser/{id}", Name = "GetUser")]
        public User GetUser(long id) => _repo.Find(id);

        [HttpPut("UpdateUser", Name = "UpdateUser")]
        [ValidateModelAttribute]
        public IActionResult UpdateUser([FromBody]User model)
        { 
            _repo.Update(model);
            return new OkObjectResult(new { UserID = model.UserId });
        }

        [HttpPut("UpdateUserBasicInfo", Name = "UpdateUserBasicInfo")]
        [ValidateModelAttribute]
        public IActionResult UpdateUserBasicInfo([FromBody]UpdateUserViewModel model)
        {
            User usr = _repo.Find(model.UserId);
            usrlang_repo.DeleteRange(usrlang_repo.GetList(a => a.UserId == model.UserId));
            usr.FirstName = model.FirstName;
            usr.LastName = model.LastName;
            usr.FullName = (string)(model.FirstName + " " + model.LastName);
            usr.FatherName = model.FatherName;
            usr.POB = model.POB;
            usr.DOB = model.DOB;
            usr.CNIC = model.CNIC;
            usr.CNICExpiry = model.CNICExpiry;
            usr.Email = model.Email;
            usr.BloodGroup = model.BloodGroup;
            usr.Gender = model.Gender;
            usr.MaritalStatus = model.MaritalStatus;
            usr.HomePhone = model.HomePhone;
            usr.Phone = model.Phone;
            usr.Address = model.Address;
            usr.PermanentAddress = model.PermanentAddress;
            usr.UserLanguages = model.UserLanguages;
            usr.ReligionId = model.ReligionId;
            usr.CityId = model.CityId;
            usr.DepartmentId = model.DepartmentId;
            usr.GroupId = model.GroupId;
            _repo.Update(usr);
            return new OkObjectResult(new { UserID = model.UserId });
        }

        [HttpPost("AddUser", Name = "AddUser")]
        [ValidateModelAttribute]
        public IActionResult AddUser([FromBody]UpdateUserViewModel model)
        {
            User usr = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = (string)(model.FirstName + " " + model.LastName),
                FatherName = model.FatherName,
                POB = model.POB,
                DOB = model.DOB,
                CNIC = model.CNIC,
                CNICExpiry = model.CNICExpiry,
                Email = model.Email,
                BloodGroup = model.BloodGroup,
                Gender = model.Gender,
                MaritalStatus = model.MaritalStatus,
                HomePhone = model.HomePhone,
                Phone = model.Phone,
                Address = model.Address,
                PermanentAddress = model.PermanentAddress,
                UserLanguages = model.UserLanguages,
                ReligionId = model.ReligionId,
                DepartmentId = model.DepartmentId,
                CityId = model.CityId,
                GroupId = model.GroupId
            };

            _repo.Add(usr);
            return new OkObjectResult(new { UserID = usr.UserId });
        }

        [HttpDelete]
        public IActionResult DeleteUser(long id)
        {
            User user = _repo.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            _repo.Delete(user);
            return Ok();
        }
        #endregion

        #region User Features and Modules

        [HttpGet("GetUserFeatures/{id}", Name = "GetUserFeatures")]
        public List<UserFeaturesViewModel> GetUserApplicationFeature(long id)
        {
            return _repo.GetUserFeatures(id);
        }


        [HttpGet("GetUserModules/{id}", Name = "GetUserModules")]
        public List<UserModulesViewModel> GetUserModules(long id)
        {
            return _repo.GetUserModules(id);
        }

        [HttpGet("GetUserFeaturesAndModules/{id}", Name = "GetUserFeaturesAndModules")]
        public UserFeaturesAndModulesViewModel GetUserFeaturesAndModules(long id)
        {
            return _repo.GetUserFeaturesAndModules(id);
        }
        #endregion

        #region User Documents

        [HttpGet("GetDocumentsByUserId/{userId}", Name = "GetDocumentsByUserId")]
        public IEnumerable<UserDocument> GetDocumentsByUserId(long userId)
        {
            var a = doc_repo.GetAll().OrderByDescending(b => b.UserDocumentId);
            return a.Where(c => c.UserId == userId);
        }

        #endregion

        #region User Company

        [HttpGet("GetUserCompany/{UserId}")]
        public UserCompany GetUserCompany(long UserId)
        {
            var userCompany = userCompany_repo.GetFirst(c => c.UserId == UserId);

            if (userCompany != null)
            {
                return userCompany;
            }
            else
            {
                return new UserCompany();
            }
        }

        [HttpPost("AddUserCompany")]
        [ValidateModel]
        public IActionResult AddUserCompany([FromBody]UserCompany model)
        {
            userCompany_repo.Add(model);

            return new OkObjectResult(new { UserCompanyId = model.UserCompanyId });
        }

        [HttpPost("UpdateUserCompany")]
        [ValidateModel]
        public IActionResult UpdateUserCompany([FromBody]UserCompany model)
        {
            userCompany_repo.Update(model);

            return new OkObjectResult(new { UserCompanyId = model.UserCompanyId });
        }

        #endregion

        #region Get By Company, Country, City or Branch

        [HttpGet("GetUsersByCompany/{CompanyId}")]
        public IActionResult GetUsersByCompany(long CompanyId)
        {
            var users = _repo.GetList(u => u.CompanyId == CompanyId).Select(s => new
            {
                UserId = s.UserId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Phone = s.Phone,
                Email = s.Email,
                HasAccount = s.IdentityId != null ? true : false
            });

            return new JsonResult(users);
        }

        [HttpGet("GetUsersByCountry/{id}", Name = "GetUsersByCountry")]
        public IEnumerable<User> GetUsersByCountry(long id)
        {

            //IEnumerable<User> us = _repo.GetAll();
            //us = us.Where(a => a.CountryId == id);
            //return us;
            return _repo.GetList(a => a.CountryId == id);
        }

        [HttpGet("GetUsersByCity/{id}", Name = "GetUsersByCity")]
        public IEnumerable<User> GetUsersByCity(long id)
        {
            //IEnumerable<User> us = _repo.GetAll();
            //us = us.Where(a => a.CityId == id);
            //return us;
            return _repo.GetList(a => a.CityId == id);
        }

        [HttpGet("GetUsersByBranch/{id}", Name = "GetUsersByBranch")]
        public IEnumerable<User> GetUsersByBranch(long id)
        {
            //IEnumerable<User> us = _repo.GetAll();
            //us = us.Where(a => a.BranchId == id);
            //return us;
            return _repo.GetList(a => a.BranchId == id);
        }

        [HttpGet("GetUsersByDepartment/{id}", Name = "GetUsersByDepartment")]
        public IEnumerable<User> GetUsersByDepartment(long id)
        {
            //IEnumerable<User> us = _repo.GetAll();
            //us = us.Where(a => a.BranchId == id);
            //return us;
            return _repo.GetList(a => a.DepartmentId == id);
        }
        #endregion

        #region User Relations

        [HttpGet("GetRelationsByUserId/{UserId}")]
        public IEnumerable<Relation> GetRelationsByUserId(long UserId)
        {
            return relation_repo.GetList(r => r.UserId == UserId);
        }


        [HttpPost("AddRelation")]
        [ValidateModel]
        public IActionResult AddRelation([FromBody]Relation model)
        {
            relation_repo.Add(model);

            return new OkObjectResult(new { RelationId = model.RelationId });
        }

        [HttpPost("UpdateRelation")]
        [ValidateModel]
        public IActionResult UpdateRelation([FromBody]Relation model)
        {
            relation_repo.Update(model);

            return new OkObjectResult(new { RelationId = model.RelationId });
        }


        #endregion

        #region User Qualification

        [HttpGet("GetUserQualification/{UserId}")]
        public IEnumerable<University> GetUserQualification(long UserId)
        {
            return uni_repo.GetList(u => u.UserId == UserId);
        }

        [HttpPost("AddQualification")]
        [ValidateModel]
        public IActionResult AddQualification([FromBody]University model)
        {
            uni_repo.Add(model);

            return new OkObjectResult(new { UniversityId = model.UniversityId });
        }

        [HttpPost("UpdateQualification")]
        [ValidateModel]
        public IActionResult UpdateQualification([FromBody]University model)
        {
            uni_repo.Update(model);

            return new OkObjectResult(new { UniversityId = model.UniversityId });
        }

        #endregion

        #region User Work Experience

        [HttpGet("GetworkExperienceByUserId/{userid}", Name = "GetworkExperienceByUserId")]
        public IEnumerable<WorkExperience> GetworkExperienceByUserId(long userid)
        {
            return exp_repo.GetList(u => u.UserId == userid);
        }

        [HttpPost("AddWorkExperience")]
        [ValidateModel]
        public IActionResult AddWorkExperience([FromBody]WorkExperience model)
        {
            exp_repo.Add(model);

            return new OkObjectResult(new { WorkExperienceId = model.WorkExperienceId });
        }

        [HttpPost("UpdateWorkExperience")]
        [ValidateModel]
        public IActionResult UpdateWorkExperience([FromBody]WorkExperience model)
        {
            exp_repo.Update(model);

            return new OkObjectResult(new { WorkExperienceId = model.WorkExperienceId });
        }

        #endregion

        #region User Bank

        [HttpGet("GetUserBanksByUserId/{UserId}")]
        public IEnumerable<Bank> GetUserBanksByUserId(long UserId)
        {
            return userBank_repo.GetList(u => u.UserId == UserId);
        }

        [HttpPost("AddUserBank")]
        [ValidateModel]
        public IActionResult AddUserBank([FromBody]Bank model)
        {
            userBank_repo.Add(model);

            return new OkObjectResult(new { BankId = model.BankId });
        }

        [HttpPost("UpdateUserBank")]
        [ValidateModel]
        public IActionResult UpdateUserBank([FromBody]Bank model)
        {
            userBank_repo.Update(model);

            return new OkObjectResult(new { BankId = model.BankId });
        }


        #endregion

        #region Add by User ID

        [HttpPost("UpdateUserSocial/{userid}", Name = "UpdateUserSocial")]
        public IActionResult UpdateUserSocial([FromRoute]long userid, [FromBody]UserSocialViewModel model)
        {
            User usr = _repo.Find(userid);
            if (usr == null)
            {
                return BadRequest("User Not Found");
            }

            usr.FacebookUrl = model.FacebookUrl;
            usr.TwitterUrl = model.TwitterUrl;
            usr.LinkedinUrl = model.LinkedinUrl;
            usr.YoutubeUrl = model.YoutubeUrl;
            usr.BloggerProfile = model.BloggerProfile;
            usr.InstagramUrl = model.InstagramUrl;
            usr.PinterestUrl = model.PinterestUrl;
            usr.GooglePlusUrl = model.GooglePlusUrl;

            _repo.Update(usr);
            return Ok("User Details Saved Successfully");
        }

        [HttpPost("UpdateUserCompany/{userid}", Name = "UpdateUserCompany")]
        public IActionResult UpdateUserCompany([FromRoute]long userid, [FromBody]UserCompany model)
        {

            try
            {
                userCompany_repo.Update(model);
            }
            catch (Exception)
            {

                throw;
            }

            return Ok("User Details Saved Successfully");
        }


        [HttpPost("AddUserPhotoById/{userid}", Name = "AddUserPhotoById")]
        [ValidateModelAttribute]
        public IActionResult AddUserPhotoById([FromRoute]long userid, IFormFile file)
        {

            User mod = _repo.Find(userid);
            if (mod == null)
            {
                return NotFound("Incorrect UserId");
            }

            string userPath = userid.ToString() + "_Photo_" + file.FileName;
            string docFolder = Path.Combine("EmployeesImages", userPath);

            try
            {
                if (file == null || file.Length == 0)
                {
                    return Content("File Not Selected");
                }

                string path = FileUploadHandler.GetFilePathForUpload(docFolder, file.FileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            catch (Exception e)
            {
                return Json(new { result = "upload Failed", error = e.Message });
            }

            string filePath = FileUploadHandler.FileReturnPath(docFolder, file.FileName);


            mod.UserPhoto = new UserPhoto { FilePath = filePath, UserId = userid };
            _repo.Update(mod);

            return new OkObjectResult(new { UserPhotoID = mod.UserPhotoId });
        }

        [HttpPost("AddUserDocumentsById/{userid}", Name = "AddUserDocumentsById")]
        [ValidateModelAttribute]
        public async Task<IActionResult> AddUserDocumentsById([FromRoute]long userid, IList<IFormFile> models)
        {
            User usr = _repo.Find(userid);
            if(usr == null)
            {
                return BadRequest("Invalid User");
            }

            IList<string> filepaths = new List<string>();
            IList<UserDocument> docs = new List<UserDocument>();

            foreach (IFormFile f in models)
            {
                string storePath = userid.ToString() + "_" + f.Name;
                string docFolder = Path.Combine("UserDocuments", storePath);

                try
                {
                    if (f == null || f.Length == 0)
                    {
                        return Content("File not selected");
                    }

                    string path = FileUploadHandler.GetFilePathForUpload(docFolder, f.FileName);

                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await f.CopyToAsync(stream);
                    }
                }
                catch (Exception e)
                {
                    return Json(new { result = "Upload Failed", error = e.Message });
                }

                string filePath = FileUploadHandler.FileReturnPath(docFolder, f.FileName);

                UserDocument doc = new UserDocument
                {
                    UserId = userid,
                    FilePath = filePath,
                    DocumentName = f.FileName
                };

                docs.Add(doc);
                filepaths.Add(filePath);
            }

            doc_repo.AddRange(docs);

            return Json(new { FilePaths = filepaths, UserID = userid });
        }

        [HttpPost("UpdateUserDocumentById/{userid}", Name = "UpdateUserDocumentById")]
        [ValidateModelAttribute]
        async public Task<IActionResult> UpdateUserDocumentById([FromRoute]long userid, [FromBody]List<IFormFile> models)
        {
            if (DeleteUserDocumentById(userid) == Ok())
            {
                return await AddUserDocumentsById(userid, models);
            }
            return BadRequest("Failed");
        }

        [HttpDelete("DeleteUserDocumentById/{id}")]
        public IActionResult DeleteUserDocumentById(long id)
        {
            UserDocument doc = doc_repo.Find(id);
            if (doc == null)
            {
                return BadRequest("Invalid Document");
            }

            doc_repo.Delete(doc);
            return Ok();
        }


        #endregion

    }
}
