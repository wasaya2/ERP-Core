using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eTrackerInfrastructure.Repos.Interfaces;
using eTrackerCore.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using eTrackerInfrastructure.Helpers;
using eTrackerInfrastructure.Models.JsonPostClasses;
using eTrackerInfrastructure.Filters;
using eTrackerCore.Entities.ViewModels;
using ErpCore.Entities.InventorySetup;

namespace eTrackerInfrastructure.Controllers
{
    [Route("api/[controller]")]
    public class StoreController : Controller
    {
        private IStoreRepository Repo { get; set; }

        public StoreController(IStoreRepository repo)
        {
            Repo = repo;
        }

        [HttpGet("GetStoreWithRelations/{id}", Name = "GetStoreWithRelations")]
        public Store GetStoreWithRelations(int id) => Repo.GetStoreByIdWithChildren(id);

        [HttpGet("GetStore/{id}", Name = "GetStore")]
        public Store GetStore(int id) => Repo.Find(id);


        [HttpGet("GetStore/{storeid}/{companyid}")]
        public Store GetStore(long storeid, long companyid) => Repo.GetFirst(c => c.StoreId == storeid && c.CompanyId == companyid);

        [HttpGet("GetAllStores")]
        public IEnumerable<Store> GetAllStores() => Repo.GetAll();

        [HttpGet("GetAllStoresForAccountRegistration/{id}")]
        public IEnumerable<StoreViewModel> GetAllStoresForAccountRegistration(long id) => Repo.GetStoresForAccountRegistration(id);

        [HttpGet("GetStoresWithChildren")]
        public IEnumerable<StoreViewModel> GetStoresWithChildren() => Repo.GetStoresWithChildren();

        [HttpGet("GetStoresWithChildren/{CompanyId}")]
        public IEnumerable<StoreViewModel> GetStoresWithChildren(long CompanyId) => Repo.GetStoresWithChildren(CompanyId);

        [HttpGet("GetAllUserStores/{id}")]
        public IEnumerable<Store> GetAllUserStores(long id) => Repo.GetUserStores(id);

        [HttpPost("CreateStore")]
        public IActionResult CreateStore([FromBody]Store store)
        {
            if (store == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var oldStore = Repo.GetFirst(s => s.StartTime == store.StartTime && s.ShopName == store.ShopName && s.ContactNo == store.ContactNo);
            if (oldStore == null)
                Repo.Add(store);

            return new OkObjectResult(new { id = store.StoreId });
        }

        [HttpPost("AddMultipleOrders")]
        [ValidateModelAttribute]
        public IActionResult AddOrders([FromBody]Orders orders)
        {
            Repo.AddMultipleStoreOrders(orders);

            return new OkObjectResult(new { response = "All Orders Successfully Added" });
        }

        [HttpPost("UploadFiles/{id}")]
        public async Task<ActionResult> UploadStoreImageAndUpdateStore(IFormFile file, long id)
        {

            // full path to file in temp location
            var filePath = "";
            string storePath = "Store_" + id.ToString();
            string docFolder = Path.Combine("StoreImages", storePath);

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

            var store = Repo.Find(id);
            if(store!=null)
            {
                store.ImageUrl = filePath;
                Repo.Update(store);
            }
            return Json(new {filepath = filePath, storeId = id });
        }

        [HttpDelete("DeleteStore/{id}")]
        public IActionResult DeleteStore(long id)
        {
            var store = Repo.Find(id);
            if (store == null)
                return NotFound();

            Repo.Delete(store);

            return Ok();
        }

        //public IActionResult GetVisitHistory(int customerId)
        //{
        //    var orderWithTotals = Repo.GetOrderHistory(customerId);

        //    return orderWithTotals == null ?
        //        (IActionResult)NotFound()
        //        : new ObjectResult(orderWithTotals);
        //}

        //[HttpGet("{orderId}", Name = "GetOrderDetails")]
        //public IActionResult GetOrderForCustomer(int customerId, int orderId)
        //{
        //    var orderWithDetails = Repo.GetOneWithDetails(customerId, orderId);

        //    return orderWithDetails == null ?
        //        (IActionResult)NotFound()
        //        : new ObjectResult(orderWithDetails);
        //}
    }
}