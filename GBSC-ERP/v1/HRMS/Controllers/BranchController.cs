using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ErpCore.Entities;
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
    public class BranchController : Controller
    {
        private IBranchRepository Repo;
        private readonly ClaimsPrincipal _caller;

        public BranchController(IHttpContextAccessor httpContextAccessor, IBranchRepository repo)
        {
            Repo = repo;
            _caller = httpContextAccessor.HttpContext.User;

        }

        //Get All Branches
        [HttpGet("GetBranches")]
        public IEnumerable<Branch> GetBranches()
        {
            return Repo.GetAll();
        }

       
        //Add Branch
        [HttpPost("AddBranch")]
        public IActionResult AddBranch([FromBody]Branch model)
        {
            Repo.Add(model);

            return new OkObjectResult(new { branchId = model.Id });
        }


        [HttpPut("UpdateBranch")]

        public IActionResult UpdateFeature([FromBody]Branch model)
        {
            Repo.Update(model);

            return new OkObjectResult(new { branchId = model.Id });
        }

        [HttpDelete("DeleteBranch")]
        public IActionResult DeleteBranch([FromBody]Branch model)
        {
            Repo.Delete(model);

            return new OkObjectResult(new { branchId = model.Id });
        }
    }
}