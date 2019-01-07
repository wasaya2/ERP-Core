using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eTrackerCore.Entities;
using eTrackerInfrastructure.Repos.Interfaces;
using eTrackerInfrastructure.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using eTrackerInfrastructure.Helpers;
using ErpCore.Entities;
using ETrackerService.ViewModels;

namespace eTrackerInfrastructure.Controllers
{

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _repo;
        private ITerritoryRepository _tRepo;

        public UserController(IUserRepository repo, ITerritoryRepository tRepo)
        {
            _repo = repo;
            _tRepo = tRepo;
        }

        [HttpGet("GetUser/{UserId}")]
        public User GetUser(long UserId)
        {
            var user = _repo.GetFirst(u => u.UserId == UserId, u => u.Section);

            return user;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _repo.Add(user);
                _repo.Update(user);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(new { result = e.Message });
            }

            return new OkObjectResult(user.UserId.ToString());
        }

        [HttpPost("AssignUserLevel")]
        public IActionResult AssignUserLevel([FromBody]AssignUserLevelViewModel model)
        {
            try
            {
                var user = _repo.Find(model.UserId);

                _repo.ClearAssignments(model.UserId);

                user.UserLevel = model.UserLevel;

                if (model.UserLevel == "Admin" || model.UserLevel == "NSM" || model.UserLevel == "RSM" || model.UserLevel == "HO")
                {
                    foreach (var id in model.RegionIds)
                    {
                        var region = _tRepo.FindRegion(id);
                        region.UserId = model.UserId;
                        _tRepo.UpdateRegion(region);
                    }
                }
                else if (model.UserLevel == "ZSM")
                {
                    foreach (var id in model.CityIds)
                    {
                        var city = _tRepo.FindCity(id);
                        city.UserId = model.UserId;
                        _tRepo.UpdateCity(city);
                    }
                }
                else if (model.UserLevel == "ASM")
                {
                    foreach (var id in model.AreaIds)
                    {
                        var area = _tRepo.FindArea(id);
                        area.UserId = model.UserId;
                        _tRepo.UpdateArea(area);
                    }
                }
                else if (model.UserLevel == "TSO/KPO")
                {
                    foreach (var id in model.TerritoryIds)
                    {
                        var territory = _tRepo.Find(id);
                        territory.UserId = model.UserId;
                        _tRepo.Update(territory);
                    }
                }
                else if (model.UserLevel == "DSF")
                {
                    var assignedSecUser = _repo.GetFirst(u => u.SectionId == model.SectionId);
                    if(assignedSecUser!=null)
                    {
                        assignedSecUser.SectionId = null;
                        _repo.Update(assignedSecUser);
                    }
                    var section = _tRepo.FindSection(model.SectionId);
                    section.UserId = model.UserId;
                    _tRepo.UpdateSection(section);

                    user.SectionId = model.SectionId;
                }

                _repo.Update(user);

                return new OkObjectResult(new { UserId = model.UserId });
            }
            catch (Exception e)
            {

                throw;
            }           
        }

        [HttpPost("AssignSubsections")]
        public IActionResult AssignSubsections([FromBody]IList<SectionAssignmentViewModel> model)
        {
            if (model == null)
                return new BadRequestObjectResult(new { result = "null object" });

            var result = _repo.AssignSubsections(model);

            return new OkObjectResult(new { result = result });

        }


        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _repo.Update(user);
            }
            catch (Exception e)
            {

                throw;
            }
            return new OkObjectResult("User updated");
        }

        [HttpGet("CheckCnic/{cnic}")]
        public bool CheckCnic(string cnic)
        {
            return _repo.CnicExists(cnic);
        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<User> GetAllUsers()
        {
            var _users = _repo.GetAll();
            _users = _users.OrderByDescending(u => u.UserId);
            return _users;
        }

        [HttpGet("GetSalesUsers")]
        public IEnumerable<User> GetSalesUsers()
        {
            var _users = _repo.GetSalesUsers();
            _users = _users.OrderByDescending(u => u.UserId).ToList();
            return _users;
        }

        [HttpGet("GetUsers/{UserId}")]
        public IEnumerable<UsersViewModel> GetUsers(long UserId) => _repo.GetUsers(UserId);

        [HttpGet("GetUsersByCompanyId/{CompanyId}")]
        public JsonResult GetUsersByCompanyId(long CompanyId)
        {
            try
            {
                var _users = _repo.GetList(c => c.CompanyId == CompanyId && (c.UserType == "Android" || c.UserType == "Both"), c => c.Section, c => c.Section.Territory)
                  .Select(u => new
                  {
                      UserId = u.UserId,
                      UserLevel = u.UserLevel,
                      FirstName = u.FirstName,
                      LastName = u.LastName,
                      Territory = u.Section?.Territory?.Name,
                      Section = u.Section?.Name,
                      SectionId = u.SectionId,
                      Email = u.Email,
                      Phone = u.Phone,
                      Cnic = u.CNIC,
                      DOB = u.DOB,
                      Address = u.Address
                  });

                return Json(_users);
            }
            catch (Exception e)
            {

                throw;
            }

        }

        [HttpGet("GetAllUsersWithRelationships")]
        public IEnumerable<User> GetAllUsersWithRelationships()
        {
            var _users = _repo.GetAllUsersWithRelationships();
            _users = _users.OrderByDescending(u => u.UserId).ToList();
            return _users;
        }

        //[HttpGet("GetUserIdentity/{id}")]
        //public IdentityUserViewModel GetUserIdentity(string id) => _repo.GetIdentityInfo(id);


        [HttpPost("UploadProfileImage/{id}")]
        public async Task<ActionResult> UploadUserImage(IFormFile file, long id)
        {

            // full path to file in temp location
            var filePath = "";
            string storePath = "User_" + id.ToString();
            string docFolder = Path.Combine("ProfileImages", storePath);

            try
            {
                if (file == null || file.Length == 0)
                    return Content("file not selected");

                var path = FileUploadHandler.GetFilePathForUpload(docFolder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            catch (Exception e)
            {
                return Json(new { result = "upload Failed", error = e.Message });
            }


            filePath = FileUploadHandler.FileReturnPath(docFolder, file.FileName);

            var user = _repo.Find(id);
            if (user != null)
            {
                user.PhotoFilePath = filePath;
                _repo.Update(user);
            }
            return Json(new { filepath = filePath, userid = id });
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(long id)
        {
            var user = _repo.Find(id);
            if (user == null)
                return NotFound();

            _repo.Delete(user);

            return Ok();
        }
    }
}