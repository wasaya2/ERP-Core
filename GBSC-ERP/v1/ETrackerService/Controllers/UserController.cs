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

namespace eTrackerInfrastructure.Controllers
{

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserRepository _repo;

        public UserController(IUserRepository repo)
        {
            _repo = repo;
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
                user.Distributor = null;
                _repo.Add(user);
                _repo.Update(user);
            }
            catch (Exception e)
            {

                return new BadRequestObjectResult(new { result = e.Message });
            }

            return new OkObjectResult(user.UserId.ToString());
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