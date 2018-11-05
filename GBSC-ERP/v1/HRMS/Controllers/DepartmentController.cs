using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ErpCore.Entities.Setup;
using HRMS.Repos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Controllers
{
    //[Authorize(Policy = "ApiUser")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        private IDepartmentRepository Repo;
        private readonly ClaimsPrincipal _caller;

        public DepartmentController(IHttpContextAccessor httpContextAccessor, IDepartmentRepository repo)
        {
            Repo = repo;
            _caller = httpContextAccessor.HttpContext.User;

        }

        //Get All Departments
        [HttpGet("GetDepartments")]
        public IEnumerable<Department> GetDepartments()
        {
            var departments = Repo.GetAll();
            return departments;
        }


        //Add Department
        [HttpPost("AddDepartment")]
        public IActionResult AddDepartment([FromBody]Department model)
        {
            Repo.Add(model);

            return new OkObjectResult(new { depId = model.Id });
        }


        [HttpPut("UpdateDepartment")]

        public IActionResult UpdateDepartment([FromBody]Department model)
        {
            Repo.Update(model);

            return new OkObjectResult(new { depId = model.Id });
        }

        [HttpDelete("DeleteDepartment")]
        public IActionResult DeleteDepartment([FromBody]Department model)
        {
            Repo.Delete(model);

            return new OkObjectResult(new { depId = model.Id });
        }
    }
}