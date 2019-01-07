using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eTrackerInfrastructure.Repos.Interfaces;
using eTrackerCore.Entities;
using eTrackerInfrastructure.Filters;
using Microsoft.AspNetCore.Http;
using eTrackerInfrastructure.Helpers;
using System.IO;
using eTrackerInfrastructure.Models.JsonPostClasses;
using ErpCore.Entities.ETracker;
using ETrackerService.ViewModels;
using ETrackerService.Repos.Interfaces;

namespace eTrackerInfrastructure.Controllers
{
    [Route("api/[controller]")]
    public class StoreVisitController : Controller
    {
        private IStoreVisitRepository Repo { get; set; }
        private INonproductiveVisitReasonRepository reason_repo;

        private IStoreRepository StoreRepo { get; set; }

        public StoreVisitController(IStoreVisitRepository repo, IStoreRepository storeRepo, INonproductiveVisitReasonRepository reasonrepo)
        {
            Repo = repo;
            StoreRepo = storeRepo;
            reason_repo = reasonrepo;
        }

        [HttpPost("AddStoreVisit")]
        [ValidateModelAttribute]
        public IActionResult AddStoreVisit([FromBody]StoreVisit visit)
        {
            Repo.Add(visit);

            return Ok(new { StoreVisitId = visit.StoreVisitId });
        }

        [HttpPost("UpdateStoreVisit")]
        [ValidateModelAttribute]
        public IActionResult UpdateStoreVisit([FromBody]StoreVisit visit)
        {
            Repo.Update(visit);

            return Ok(new { StoreVisitId = visit.StoreVisitId });
        }

        [HttpPost("AddOrder")]
        [ValidateModelAttribute]
        public IActionResult AddOrder([FromBody]OrderTaking order)
        {
            Repo.AddOrder(order);

            return Ok(new { OrderTakingId = order.OrderTakingId });
        }

        [HttpPost("AddMultipleOrders")]
        [ValidateModelAttribute]
        public IActionResult AddOrders([FromBody]Orders orders)
        {
            Repo.AddMultipleOrders(orders);
            if (orders.Order.Length > 0)
            {
                var order = orders.Order.FirstOrDefault();
                if (order != null)
                {
                    var orderTakings = Repo.GetList(s => s.StoreVisitId == order.StoreVisitId, s => s.OrderTakings);
                    return new OkObjectResult(new { Response = orderTakings });
                }
            }
            return new OkObjectResult(new { Response = "All Orders Successfully Added" });
        }


        [HttpPost("AddInventoryTaking")]
        [ValidateModelAttribute]
        public IActionResult AddInventoryTaking([FromBody]InventoryTaking inventory)
        {
            Repo.AddInventoryTaking(inventory);

            return Ok(new { InventoryTakingId = inventory.InventoryTakingId });
        }

        [HttpPost("AddMultipleInventoryTakings")]
        [ValidateModelAttribute]
        public IActionResult AddMultipleInventoryTakings([FromBody]InventoryTakings inventory)
        {
            Repo.AddMultipleInventoryTakings(inventory);

            return new OkObjectResult(new { response = "All Items Successfully Added" });
        }

        [HttpPost("AddMerchendise")]
        [ValidateModelAttribute]
        public IActionResult AddMerchendise([FromBody]Merchandising merch)
        {
            Repo.AddMerchendize(merch);

            return Ok(new { MerchandisingId = merch.MerchandisingId });
        }

        [HttpPost("AddCompetativeStock")]
        [ValidateModelAttribute]
        public IActionResult AddCompetativeStock([FromBody]CompetatorStock stock)
        {
            Repo.AddCompetativeStock(stock);

            return Ok(new { CompetativeStockId = stock.CompetatorStockId });
        }

        [HttpPost("AddMultipleCompetativeStock")]
        [ValidateModelAttribute]
        public IActionResult AddMultipleCompetativeStock([FromBody]CompetativeStocks stocks)
        {
            Repo.AddMultipleCompetativeStock(stocks);

            return new OkObjectResult(new { response = "All Competative Stocks Successfully Added" });
        }

        [HttpPost("AddOutletStock")]
        [ValidateModelAttribute]
        public IActionResult AddOutletStock([FromBody]OutletStock stock)
        {
            Repo.AddOutletStock(stock);

            return Ok(new { OutletStockId = stock.OutletStockId });
        }

        [HttpPost("AddMultipleStock")]
        [ValidateModelAttribute]
        public IActionResult AddMultipleStocks([FromBody]Stocks stocks)
        {
            Repo.AddMultipleStockItems(stocks);

            return new OkObjectResult(new { response = "All Stocks Successfully Added" });
        }

        [HttpGet("GetOutletStocks/{storeVisitId}")]
        public IEnumerable<OutletStock> GetOutletStockList(long storeVisitId) => Repo.GetOutletStocks(storeVisitId);

        [HttpGet("GetOrders/{storeVisitId}")]
        public IEnumerable<OrderTakingViewModel> GetOrders(long storeVisitId) => Repo.GetVisitOrders(storeVisitId);

        [HttpGet("GetInventories/{storeVisitId}")]
        public IEnumerable<OrderTakingViewModel> GetInventories(long storeVisitId) => Repo.GetVisitInventories(storeVisitId);

        [HttpGet("CompetativeStocks/{storeVisitId}")]
        public IEnumerable<CompetatorStock> CompetativeStockList(long storeVisitId) => Repo.CompetativeStocks(storeVisitId);

        [HttpGet("GetMerchendiseList/{storeVisitId}")]
        public IEnumerable<Merchandising> GetMerchendiseList(long storeVisitId) => Repo.GetMerchendiseList(storeVisitId);

        [HttpGet("GetStoreVisit/{id}")]
        public StoreVisit GetStoreVisit(long id) => Repo.Find(id);

        [HttpGet("GetStoreNoOrderReason/{storevisitid}")]
        public IActionResult GetStoreNoOrderReason(long storevisitid) => new OkObjectResult(new { Reason = Repo.GetNoOrderReason(storevisitid) });

        [HttpGet("GetMostRecenetStoreVisit/{storeid}")]
        public StoreVisit GetMostRecenetStoreVisit(long storeid)
        {
            return Repo.MostRecenetStoreVisit(storeid);
        }

        [HttpGet("GetStoreVisitWithStore/{id}/{companyid}")]
        public StoreVisit GetStoreVisitWithStore(long id, long companyid) => Repo.GetStoreVisitWithStore(id);

        [HttpGet("GetVisits/{id}")]
        public IEnumerable<StoreVisit> GetVisits(long id) => Repo.GetVisitsByStoreId(id);

        [HttpDelete("DeleteVisit/{id}")]
        public IActionResult DeleteVisit(long id)
        {
            var storeVisit = Repo.Find(id);
            if (storeVisit == null)
                return NotFound();

            Repo.Delete(storeVisit);

            return Ok();
        }

        [HttpGet("GetLastTwoVisits/{StoreId}")]
        public IEnumerable<LastTwoVisits> GetLastTwoVisits(long StoreId)
        {
            return Repo.GetLastTwoVisits(StoreId);
        }


        [HttpPost("UploadStockImage/{OutletStockId}")]
        public async Task<ActionResult> UploadStockImage(IFormFile file, long OutletStockId)
        {

            // full path to file in temp location
            var stockObj = Repo.GetStockItemById(OutletStockId);
            if (stockObj == null)
                return new NotFoundResult();

            var filePath = "";
            string storePath = "Store_" + stockObj.StoreVisit.StoreId;
            string docFolder = Path.Combine("StoreImages", storePath, "Stock");

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

            stockObj.ImageUrl = filePath;
            Repo.UpdateStock(stockObj);

            return Json(new { filepath = filePath, OutletStockId = OutletStockId });
        }

        #region Non Productive Visit Reason

        [HttpGet("GetNonproductiveVisitReasons", Name = "GetNonproductiveVisitReasons")]
        public IEnumerable<NonproductiveVisitReason> GetNonproductiveVisitReasons()
        {
            return reason_repo.GetAll().ToList().OrderByDescending(a => a.NonproductiveVisitReasonId);
        }

        [HttpGet("GetNonproductiveVisitReasonsByCompany/{companyid}", Name = "GetNonproductiveVisitReasonsByCompany")]
        public IEnumerable<NonproductiveVisitReason> GetNonproductiveVisitReasonsByCompany([FromRoute]long companyid)
        {
            return reason_repo.GetList(a => a.CompanyId != null && a.CompanyId == companyid).OrderByDescending(a => a.NonproductiveVisitReasonId);
        }

        [HttpGet("GetNonproductiveVisitReason/{id}", Name = "GetNonproductiveVisitReason")]
        public NonproductiveVisitReason GetNonproductiveVisitReason([FromRoute]long id)
        {
            return reason_repo.GetFirst(a => a.NonproductiveVisitReasonId == id);
        }

        [HttpPost("AddNonproductiveVisitReason", Name = "AddNonproductiveVisitReason")]
        [ValidateModelAttribute]
        public IActionResult AddNonproductiveVisitReason([FromBody]NonproductiveVisitReason model)
        {
            reason_repo.Add(model);
            return new OkObjectResult(new { NonproductiveVisitReasonId = model.NonproductiveVisitReasonId });
        }

        [HttpPut("UpdateNonproductiveVisitReason", Name = "UpdateNonproductiveVisitReason")]
        [ValidateModelAttribute]
        public IActionResult UpdateNonproductiveVisitReason([FromBody]NonproductiveVisitReason model)
        {
            reason_repo.Update(model);
            return new OkObjectResult(new { NonproductiveVisitReasonId = model.NonproductiveVisitReasonId });
        }

        [HttpDelete("DeleteNonproductiveVisitReason/{id}", Name = "DeleteNonproductiveVisitReason")]
        public IActionResult DeleteNonproductiveVisitReason([FromRoute]long id)
        {
            NonproductiveVisitReason reason = reason_repo.GetFirst(a => a.NonproductiveVisitReasonId == id);
            if (reason == null)
            {
                return BadRequest();
            }
            reason_repo.Delete(reason);
            return Ok();
        }

        #endregion
    }
}
