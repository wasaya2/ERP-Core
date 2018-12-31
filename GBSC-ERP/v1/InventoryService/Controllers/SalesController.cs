using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Filters;
using ErpInfrastructure.Data;
using InventoryService.Repos.Interfaces;
using InventoryService.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SalesController : Controller
    {
        private ISalesIndentRepository ind_repo;
        private ISalesIndentItemRepository ind_item_repo;

        private ISalesOrderRepository order_repo;
        private ISalesOrderItemRepository orderitem_repo;

        private IDeliveryOrderRepository Deliveryorder_repo;
        private IDeliveryOrderItemRepository Deliveryorderitem_repo;

        private IDeliveryChallanRepository challan_repo;

        private ISalesInvoiceRepository Invoice_repo;

        private ISalesReturnRepository return_repo;
        private ISalesReturnItemRepository returnitem_repo;

        public SalesController(ISalesIndentRepository indrepo,
            ISalesIndentItemRepository inditemrepo,
            ISalesOrderRepository order,
            ISalesOrderItemRepository orderitem,
            IDeliveryOrderRepository Deliveryorder,
            IDeliveryOrderItemRepository Deliveryorderitem,
            IDeliveryChallanRepository challan,
            ISalesInvoiceRepository invoicerepo,
            ISalesReturnRepository retrn, 
            ISalesReturnItemRepository returnitem)
        {
            ind_repo = indrepo;
            ind_item_repo = inditemrepo;
            order_repo = order;
            orderitem_repo = orderitem;
            Deliveryorder_repo = Deliveryorder;
            Deliveryorderitem_repo = Deliveryorderitem;
            challan_repo = challan;
            Invoice_repo = invoicerepo;
            return_repo = retrn;
            returnitem_repo = returnitem;
        }

        //[HttpGet("GetSalesPermissions/{userid}/{RoleId}/{featureid}", Name = "GetSalesPermissions")]
        //public IEnumerable<Permission> GetSalesPermissions(long userid, long RoleId, long featureid)
        //{
        //    IEnumerable<Permission> per = ind_repo.GetFeaturePermissions(userid, RoleId, featureid).Permissions.ToList();
        //    return per;
        //}

        #region Sales Indent

        [HttpGet("GetSalesIndents", Name = "GetSalesIndents")]
        public IEnumerable<SalesIndent> GetSalesIndents()
        {
            IEnumerable<SalesIndent> so = ind_repo.GetAll();
            so = so.OrderByDescending(p => p.SalesIndentId);
            return so;
        }

        [HttpGet("GetSalesIndent/{id}", Name = "GetSalesIndent")]
        public SalesIndent GetSalesIndent(long id) => ind_repo.GetFirst(o => o.SalesIndentId == id);

        [HttpPut("UpdateSalesIndent", Name = "UpdateSalesIndent")]
        [ValidateModelAttribute]
        public IActionResult UpdateSalesIndent([FromBody]SalesIndent model)
        {
            ind_repo.Update(model);
            return new OkObjectResult(new { SalesIndentID = model.SalesIndentId });
        }

        private string GenSIN()
        {
            try
            {
                //var context = new ApplicationDbContext();
                //SalesIndent lastOrder = context.SalesIndents.LastOrDefault();
                SalesIndent lastOrder = ind_repo.GetLast();
                string value = lastOrder.SalesIndentNumber;
                string number = Regex.Match(value, "[0-9]+$").Value;

                return value.Substring(0, value.Length - number.Length) +
                       (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException)
            {
                return "SIN00000001";
            }
        }

        [HttpPost("AddSalesIndent", Name = "AddSalesIndent")]
        [ValidateModelAttribute]
        public IActionResult AddSalesIndent([FromBody]SalesIndent model)
        {
            model.SalesIndentNumber = GenSIN();
            ind_repo.Add(model);
            return new OkObjectResult(new { SalesIndentID = model.SalesIndentId });
        }

        [HttpDelete("DeleteSalesIndent/{id}")]
        public IActionResult DeleteSalesIndent(long id)
        {
            SalesIndent SalesIndent = ind_repo.Find(id);
            if (SalesIndent == null)
            {
                return NotFound();
            }

            ind_repo.Delete(SalesIndent);
            return Ok();
        }

        #endregion

        #region Sales Indent Item

        [HttpGet("GetSalesIndentItems", Name = "GetSalesIndentItems")]
        public IEnumerable<SalesIndentItem> GetSalesIndentItems()
        {
            IEnumerable<SalesIndentItem> so = ind_item_repo.GetAll();
            so = so.OrderByDescending(p => p.SalesIndentItemId);
            return so;
        }

        [HttpGet("GetSalesIndentItem/{id}", Name = "GetSalesIndentItem")]
        public SalesIndentItem GetSalesIndentItem(long id) => ind_item_repo.GetFirst(o => o.SalesIndentItemId == id);

        [HttpPut("UpdateSalesIndentItem", Name = "UpdateSalesIndentItem")]
        [ValidateModelAttribute]
        public IActionResult UpdateSalesIndentItem([FromBody]SalesIndentItem model)
        {
            ind_item_repo.Update(model);
            return new OkObjectResult(new { SalesIndentID = model.SalesIndentItemId });
        }
        
        [HttpPost("AddSalesIndentItem", Name = "AddSalesIndentItem")]
        [ValidateModelAttribute]
        public IActionResult AddSalesIndentItem([FromBody]SalesIndentItem model)
        {
            ind_item_repo.Add(model);
            return new OkObjectResult(new { SalesIndentItemID = model.SalesIndentItemId });
        }

        [HttpDelete("DeleteSalesIndentItem/{id}")]
        public IActionResult DeleteSalesIndentItem(long id)
        {
            SalesIndentItem SalesIndentItem = ind_item_repo.Find(id);
            if (SalesIndentItem == null)
            {
                return NotFound();
            }

            ind_item_repo.Delete(SalesIndentItem);
            return Ok();
        }

        #endregion

        #region Sales Order
        [HttpGet("GetSalesOrders", Name = "GetSalesOrders")]
        public IEnumerable<SalesOrder> GetSalesOrders()
        {
            IEnumerable<SalesOrder> so = order_repo.GetAll(a => a.SalesOrderItems);
            so = so.OrderByDescending(p => p.SalesOrderId);
            return so;
        }

        [HttpGet("GetSalesOrder/{id}", Name = "GetSalesOrder")]
        public SalesOrder GetSalesOrder(long id) => order_repo.GetFirst(o => o.SalesOrderId == id, b => b.SalesOrderItems);

        [HttpGet("GetSalesOrderbyCode/{code}", Name = "GetSalesOrderbyCode")]
        public SalesOrder GetSalesOrderbyCode([FromRoute]string code)
        {
            return order_repo.GetFirst(a => a.SalesOrderCode == code, b => b.SalesOrderItems);
        }

        [HttpPut("UpdateSalesOrder", Name = "UpdateSalesOrder")]
        [ValidateModelAttribute]
        public IActionResult UpdateSalesOrder([FromBody]SalesOrder model)
        {
            order_repo.Update(model);
            return new OkObjectResult(new { SalesOrderID = model.SalesOrderId });
        }

        private string GenSC()
        {
            try
            {
                //var context = new ApplicationDbContext();
                //SalesOrder lastOrder = context.SalesOrders.LastOrDefault();
                SalesOrder lastOrder = order_repo.GetLast();
                string value = lastOrder.SalesOrderCode;
                string number = Regex.Match(value, "[0-9]+$").Value;

              return value.Substring(0, value.Length - number.Length) +
                     (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException)
            {
              return "SO000001";
            }
        }

        [HttpPost("AddSalesOrder", Name = "AddSalesOrder")]
        [ValidateModelAttribute]
        public IActionResult AddSalesOrder([FromBody]SalesOrder model)
        {
            model.SalesOrderCode = GenSC();
            order_repo.Add(model);
            return new OkObjectResult(new { SalesOrderID = model.SalesOrderId });
        }

        [HttpDelete("DeleteSalesOrder/{id}")]
        public IActionResult DeleteSalesOrder(long id)
        {
            SalesOrder SalesOrder = order_repo.Find(id);
            if (SalesOrder == null)
            {
                return NotFound();
            }

            order_repo.Delete(SalesOrder);
            return Ok();
        }
        #endregion

        #region Sales Order Item
        [HttpGet("GetSalesOrderItems", Name = "GetSalesOrderItems")]
        public IEnumerable<SalesOrderItem> GetSalesOrderItems()
        {
            IEnumerable<SalesOrderItem> soi = orderitem_repo.GetAll(a =>a.InventoryItem);
            soi = soi.OrderByDescending(p => p.SalesOrderItemId);
            return soi;
        }

        [HttpGet("GetSalesOrderItem/{id}", Name = "GetSalesOrderItem")]
        public SalesOrderItem GetSalesOrderItem(long id) => orderitem_repo.GetFirst(o => o.SalesOrderItemId == id, b => b.InventoryItem);

        [HttpPut("UpdateSalesOrderItem", Name = "UpdateSalesOrderItem")]
        [ValidateModelAttribute]
        public IActionResult UpdateSalesOrderItem([FromBody]SalesOrderItem model)
        {
            orderitem_repo.Update(model);
            return new OkObjectResult(new { SalesOrderItemID = model.SalesOrderItemId });
        }

        [HttpPost("AddSalesOrderItem", Name = "AddSalesOrderItem")]
        [ValidateModelAttribute]
        public IActionResult AddSalesOrderItem([FromBody]SalesOrderItem model)
        {
            orderitem_repo.Add(model);
            return new OkObjectResult(new { SalesOrderItemID = model.SalesOrderItemId });
        }

        [HttpDelete("DeleteSalesOrderItem/{id}")]
        public IActionResult DeleteSalesOrderItem(long id)
        {
            SalesOrderItem SalesOrderItem = orderitem_repo.Find(id);
            if (SalesOrderItem == null)
            {
                return NotFound();
            }

            orderitem_repo.Delete(SalesOrderItem);
            return Ok();
        }
        #endregion
        
        #region Delivery Order
        [HttpGet("GetDeliveryOrders", Name = "GetDeliveryOrders")]
        public IEnumerable<DeliveryOrder> GetDeliveryOrders()
        {
            IEnumerable<DeliveryOrder> so = Deliveryorder_repo.GetAll();
            so = so.OrderByDescending(p => p.DeliveryOrderId);
            return so;
        }

        [HttpGet("GetDeliveryOrder/{id}", Name = "GetDeliveryOrder")]
        public DeliveryOrder GetDeliveryOrder(long id) => Deliveryorder_repo.GetFirst(o => o.DeliveryOrderId == id);

        [HttpPut("UpdateDeliveryOrder", Name = "UpdateDeliveryOrder")]
        [ValidateModelAttribute]
        public IActionResult UpdateDeliveryOrder([FromBody]DeliveryOrder model)
        {
            Deliveryorder_repo.Update(model);
            return new OkObjectResult(new { DeliveryOrderID = model.DeliveryOrderId });
        }

        private string GenDON()
        {
            //var context = new ApplicationDbContext();
            try
            {
                //DeliveryOrder lastOrder = context.DeliveryOrders.LastOrDefault();
                DeliveryOrder lastOrder = Deliveryorder_repo.GetLast();
                string value = lastOrder.DeliveryOrderCode;
                string number = Regex.Match(value, "[0-9]+$").Value;

                return value.Substring(0, value.Length - number.Length) +
                       (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException)
            {
                return "DON00000000001";
            }
        }

        [HttpPost("AddDeliveryOrder", Name = "AddDeliveryOrder")]
        [ValidateModelAttribute]
        public IActionResult AddDeliveryOrder([FromBody]DeliveryOrder model)
        {
            model.DeliveryOrderCode = GenDON();
            Deliveryorder_repo.Add(model);
            return new OkObjectResult(new { DeliveryOrderID = model.DeliveryOrderId });
        }

        [HttpDelete("DeleteSalesOrder/{id}")]
        public IActionResult DeleteDeliveryOrder(long id)
        {
            DeliveryOrder DeliveryOrder = Deliveryorder_repo.Find(id);
            if (DeliveryOrder == null)
            {
                return NotFound();
            }

            Deliveryorder_repo.Delete(DeliveryOrder);
            return Ok();
        }
        #endregion

        #region Delivery Order Item
        [HttpGet("GetDeliveryOrderItems", Name = "GetDeliveryOrderItems")]
        public IEnumerable<DeliveryOrderItem> GetDeliveryOrderItems()
        {
            IEnumerable<DeliveryOrderItem> soi = Deliveryorderitem_repo.GetAll();
            soi = soi.OrderByDescending(p => p.DeliveryOrderItemId);
            return soi;
        }

        [HttpGet("GetDeliveryOrderItem/{id}", Name = "GetDeliveryOrderItem")]
        public DeliveryOrderItem GetDeliveryOrderItem(long id) => Deliveryorderitem_repo.GetFirst(o => o.DeliveryOrderItemId == id);

        [HttpPut("UpdateDeliveryOrderItem", Name = "UpdateDeliveryOrderItem")]
        [ValidateModelAttribute]
        public IActionResult UpdateDeliveryOrderItem([FromBody]DeliveryOrderItem model)
        {
            Deliveryorderitem_repo.Update(model);
            return new OkObjectResult(new { DeliveryOrderItemID = model.DeliveryOrderItemId });
        }

        [HttpPost("AddDeliveryOrderItem", Name = "AddDeliveryOrderItem")]
        [ValidateModelAttribute]
        public IActionResult AddDeliveryOrderItem([FromBody]DeliveryOrderItem model)
        {
            Deliveryorderitem_repo.Add(model);
            return new OkObjectResult(new { DeliveryOrderItemID = model.DeliveryOrderItemId });
        }

        [HttpDelete("DeleteDeliveryOrderItem/{id}")]
        public IActionResult DeleteDeliveryOrderItem(long id)
        {
            DeliveryOrderItem DeliveryOrderItem = Deliveryorderitem_repo.Find(id);
            if (DeliveryOrderItem == null)
            {
                return NotFound();
            }

            Deliveryorderitem_repo.Delete(DeliveryOrderItem);
            return Ok();
        }
        #endregion

        #region Delivery Challan
        [HttpGet("GetDeliveryChallans", Name = "GetDeliveryChallans")]
        public IEnumerable<DeliveryChallan> GetDeliveryChallans()
        {
            IEnumerable<DeliveryChallan> g = challan_repo.GetAll();
            g = g.OrderByDescending(a => a.DeliveryChallanId);
            return g;
        }

        [HttpGet("GetDeliveryChallan/{id}", Name = "GetDeliveryChallan")]
        public DeliveryChallan GetDeliveryChallan(long id) => challan_repo.GetFirst(g => g.DeliveryChallanId == id);

        private string GenCN()
        {
            //var context = new ApplicationDbContext();
            try
            {
                //DeliveryChallan lastDeliveryChallan = context.DeliveryChallans.LastOrDefault();
                DeliveryChallan lastDeliveryChallan = challan_repo.GetLast();
                string value = lastDeliveryChallan.ChallanNumber;
                string number = Regex.Match(value, "[0-9]+$").Value;
                return value.Substring(0, value.Length - number.Length) +
                       (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException)
            {
                return "DCN0000000000001";
            }
        }

        [HttpPost("AddDeliveryChallan", Name = "AddDeliveryChallan")]
        [ValidateModelAttribute]
        public IActionResult AddDeliveryChallan([FromBody]DeliveryChallan model)
        {
            model.ChallanNumber = GenCN();
            challan_repo.Add(model);
            return new OkObjectResult(new { DeliveryChallanId = model.DeliveryChallanId });
        }

        [HttpPut("UpdateDeliveryChallan", Name = "UpdateDeliveryChallan")]
        [ValidateModelAttribute]
        public IActionResult UpdateDeliveryChallan([FromBody]DeliveryChallan model)
        {
            challan_repo.Update(model);
            return new OkObjectResult(new { DeliveryChallanID = model.DeliveryChallanId });
        }

        [HttpDelete("DeleteDeliveryChallan/{id}")]
        public IActionResult DeleteDeliveryChallan(long id)
        {
            DeliveryChallan DeliveryChallan = challan_repo.Find(id);
            if (DeliveryChallan == null)
            {
                return NotFound();
            }

            challan_repo.Delete(DeliveryChallan);
            return Ok();
        }
        #endregion

        #region Sales Invoice
        [HttpGet("GetSalesInvoices", Name = "GetSalesInvoices")]
        public IEnumerable<SalesInvoice> GetSalesInvoices()
        {
            IEnumerable<SalesInvoice> so = Invoice_repo.GetAll();
            so = so.OrderByDescending(p => p.SalesInvoiceId);
            return so;
        }

        [HttpGet("GetSalesInvoice/{id}", Name = "GetSalesInvoice")]
        public SalesInvoice GetSalesInvoice(long id) => Invoice_repo.GetFirst(o => o.SalesInvoiceId == id);

        [HttpPut("UpdateSalesInvoice", Name = "UpdateSalesInvoice")]
        [ValidateModelAttribute]
        public IActionResult UpdateSalesInvoice([FromBody]SalesInvoice model)
        {
            Invoice_repo.Update(model);
            return new OkObjectResult(new { SalesInvoiceID = model.SalesInvoiceId });
        }

        private string GenSIC()
        {
            //var context = new ApplicationDbContext();
            try
            {
                //SalesInvoice lastOrder = context.SalesInvoices.LastOrDefault();
                SalesInvoice lastOrder = Invoice_repo.GetLast();
                string value = lastOrder.SalesInvoiceCode;
                string number = Regex.Match(value, "[0-9]+$").Value;

                return value.Substring(0, value.Length - number.Length) +
                       (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException)
            {
                return "SINN0000000001";
            }
        }

        [HttpPost("AddSalesInvoice", Name = "AddSalesInvoice")]
        [ValidateModelAttribute]
        public IActionResult AddSalesInvoice([FromBody]SalesInvoice model)
        {
            model.SalesInvoiceCode = GenSIC();
            Invoice_repo.Add(model);
            return new OkObjectResult(new { SalesInvoiceID = model.SalesInvoiceId });
        }

        [HttpDelete("DeleteSalesInvoice/{id}")]
        public IActionResult DeleteSalesInvoice(long id)
        {
            SalesInvoice SalesInvoice = Invoice_repo.Find(id);
            if (SalesInvoice == null)
            {
                return NotFound();
            }

            Invoice_repo.Delete(SalesInvoice);
            return Ok();
        }
        #endregion

        #region Sales Return
        [HttpGet("GetSalesReturns", Name = "GetSalesReturns")]
        public IEnumerable<SalesReturn> GetSalesReturns()
        {
            return return_repo.GetSalesReturns();
        }

        //[HttpGet("GetSalesReturnsForMonth/{date}", Name = "GetSalesReturnsForMonth")]
        //public IEnumerable<SalesReturn> GetSalesReturnsForMonth(DateTime date)
        //{
        //    return return_repo.GetSalesReturnsForMonth(date);
        //}
        
        [HttpGet("GetSalesReturn/{id}", Name = "GetSalesReturn")]
        public SalesReturn GetSalesReturn(long id) => return_repo.GetFirst(o => o.SalesReturnId == id, b => b.SalesReturnItems, c => c.SalesOrder, d => d.ReturnReason);

        [HttpPut("UpdateSalesReturn", Name = "UpdateSalesReturn")]
        [ValidateModelAttribute]
        public IActionResult UpdateSalesReturn([FromBody]SalesReturn model)
        {
            return_repo.Update(model);
            return new OkObjectResult(new { SalesReturnID = model.SalesReturnId });
        }

        private string GenRN()
        {
            //var context = new ApplicationDbContext();
            try
            {
                //SalesReturn lastReturn = context.SalesReturns.LastOrDefault();
                SalesReturn lastReturn = return_repo.GetLast();
                string value = lastReturn.ReturnNumber;
                string number = Regex.Match(value, "[0-9]+$").Value;

                return value.Substring(0, value.Length - number.Length) +
                       (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException)
            {
                return "SRN0000000001";
            }
        }

        [HttpPost("AddSalesReturn", Name = "AddSalesReturn")]
        [ValidateModelAttribute]
        public IActionResult AddSalesReturn([FromBody]SalesReturn model)
        {
            model.ReturnNumber = GenRN();
            return_repo.Add(model);
            return new OkObjectResult(new { SalesReturnID = model.SalesReturnId });
        }

        [HttpDelete("DeleteSalesReturn/{id}")]
        public IActionResult DeleteSalesReturn(long id)
        {
            SalesReturn SalesReturn = return_repo.Find(id);
            if (SalesReturn == null)
            {
                return NotFound();
            }

            return_repo.Delete(SalesReturn);
            return Ok();
        }
        #endregion

        #region Sales Return Item
        [HttpGet("GetSalesReturnItems", Name = "GetSalesReturnItems")]
        public IEnumerable<SalesReturnItem> GetSalesReturnItems()
        {
            IEnumerable<SalesReturnItem> sri = returnitem_repo.GetAll();
            sri = sri.OrderByDescending(p => p.SalesReturnItemId);
            return sri;
        }

        [HttpGet("GetSalesReturnItem/{id}", Name = "GetSalesReturnItem")]
        public SalesReturnItem GetSalesReturnItem(long id) => returnitem_repo.GetFirst(o => o.SalesReturnItemId == id);

        [HttpPut("UpdateSalesReturnItem", Name = "UpdateSalesReturnItem")]
        [ValidateModelAttribute]
        public IActionResult UpdateSalesReturnItem([FromBody]SalesReturnItem model)
        {
            returnitem_repo.Update(model);
            return new OkObjectResult(new { SalesReturnItemID = model.SalesReturnItemId });
        }

        [HttpPost("AddSalesReturnItem", Name = "AddSalesReturnItem")]
        [ValidateModelAttribute]
        public IActionResult AddSalesReturnItem([FromBody]SalesReturnItem model)
        {
            returnitem_repo.Add(model);
            return new OkObjectResult(new { SalesReturnItemID = model.SalesReturnItemId });
        }

        [HttpDelete("DeleteSalesReturnItem/{id}")]
        public IActionResult DeleteSalesReturnItem(long id)
        {
            SalesReturnItem SalesReturnItem = returnitem_repo.Find(id);
            if (SalesReturnItem == null)
            {
                return NotFound();
            }

            returnitem_repo.Delete(SalesReturnItem);
            return Ok();
        }
        #endregion

        #region Get Details by Code

        //[HttpGet("GetSalesIndentDetailsByCode/{id}", Name = "GetSalesIndentDetailsByCode")]
        //public SalesIndent GetSalesIndentDetailsByCode(string code)
        //{
        //    return ind_repo.GetFirst(a => a.SalesIndentNumber == code, b => b.SalesIndentItems);
        //}

        //[HttpGet("GetSalesOrderItemsBySalesOrderID/{id}", Name = "GetSalesOrderItemsBySalesOrderID")]
        //public IList<SalesOrderItem> GetSalesOrderItemsBySalesOrderID(long id)
        //{
        //    try
        //    {
        //        return orderitem_repo.GetSalesOrderItemsBySalesOrderID(id);
        //        //return orderitem_repo.GetAll(b => b.InventoryItem, c => c.Inventory, d => d.PackType).Where(a => a.SalesOrderId == id);
        //    }
        //    catch(NullReferenceException)
        //    {
        //        return null;
        //    }
        //}

        [HttpGet("GetDeliveryOrderDetailsByCode/{Code}", Name = "GetDeliveryOrderDetailsByCode")]
        public DeliveryOrder GetDeliveryOrderDetailsByCode(string code)
        {
            return Deliveryorder_repo.GetFirst(a => a.DeliveryOrderCode == code, b => b.DeliveryOrderItems, c => c.SalesOrder);
        }

        [HttpGet("GetDeliveryChallanDetailsByCode/{code}", Name = "GetDeliveryChallanDetailsByCode")]
        public DeliveryChallan GetDeliveryChallanDetailsByCode(string code)
        {
            return challan_repo.GetFirst(a => a.ChallanNumber == code, b => b.DeliveryOrder, c => c.Transport);
        }

        [HttpGet("GetSalesInvoiceDetailsByCode/{code}", Name = "GetSalesInvoiceDetailsByCode")]
        public SalesInvoice GetSalesInvoiceDetailsByCode(string code)
        {
            return Invoice_repo.GetFirst(a => a.SalesInvoiceCode == code, b => b.DeliveryChallan);
        }

        [HttpGet("GetSalesReturnDetailsByCode/{code}", Name = "GetSalesReturnDetailsByCode")]
        public SalesReturn GetSalesReturnDetailsByCode(string code)
        {
            return return_repo.GetFirst(a => a.ReturnNumber == code, b => b.SalesInvoice, c => c.SalesReturnItems);
        }

        #endregion

        [HttpGet("GetSalesIndentDetailsByCode/{code}", Name = "GetSalesIndentDetailsByCode")]
        public SalesIndent GetSalesIndentDetailsByCode([FromRoute]string code)
        {
            return ind_repo.GetSalesIndentDetailsByCode(code);
        }

        [HttpGet("GetSalesOrderDetailsByCode/{code}", Name = "GetSalesOrderDetailsByCode")]
        public SalesOrder GetSalesOrderDetailsByCode([FromRoute]string code)
        {
            return order_repo.GetSalesOrderDetailsByCode(code);
        }

        #region Get By Month

        [HttpGet("GetSalesIndentsByDay/{date}", Name = "GetSalesIndentsByDay")]
        public IEnumerable<SalesIndent> GetSalesIndentsByDay(DateTime date)
        {
            return ind_repo.GetAll().Where(a => a.IssueDate.Value.Date == date.Date).OrderByDescending(a => a.IssueDate);
        }

        [HttpGet("GetSalesIndentDetailsByDay/{date}", Name = "GetSalesIndentDetailsByDay")]
        public IEnumerable<SalesIndentPharmacyViewModel> GetSalesIndentDetailsByDay(DateTime date)
        {
            return ind_repo.GetSalesIndentsByDay(date);
        }



        [HttpGet("GetSalesIndentsByMonth/{date}", Name = "GetSalesIndentsByMonth")]
        public IEnumerable<SalesIndent> GetSalesIndentsByMonth(DateTime date)
        {
            return ind_repo.GetAll().Where(a => a.IssueDate.Value.Month == date.Month && a.IssueDate.Value.Year == date.Year).OrderByDescending(a => a.IssueDate);
        }

        [HttpGet("GetSalesIndentDetailsByMonth/{date}", Name = "GetSalesIndentDetailsByMonth")]
        public IEnumerable<SalesIndentPharmacyViewModel> GetSalesIndentDetailsByMonth(DateTime date)
        {
            return ind_repo.GetSalesIndentsByMonth(date);
        }

        [HttpGet("GetSalesOrdersByMonth/{date}", Name = "GetSalesOrdersByMonth")]
        public IEnumerable<SalesOrder> GetSalesOrdersByMonth(DateTime date)
        {
            return order_repo.GetSalesOrdersByMonth(date);
        }

        [HttpGet("GetSalesReturnsByMonth/{date}", Name = "GetSalesReturnsByMonth")]
        public IEnumerable<SalesReturn> GetSalesReturnsByMonth(DateTime date)
        {
            return return_repo.GetSalesReturnsByMonth(date);
        }

        #endregion

        [HttpGet("GetSalesOrderItemsBySalesOrderID/{id}", Name = "GetSalesOrderItemsBySalesOrderID")]
        public IList<SalesOrderItem> GetSalesOrderItemsBySalesOrderID(long id)
        {
            try
            {
                if (order_repo.Find(id).SalesReturn == null && order_repo.Find(id).SalesReturnId == null)
                    return orderitem_repo.GetSalesOrderItemsBySalesOrderID(id);
                    //return orderitem_repo.GetAll(b => b.InventoryItem, c => c.Inventory, d => d.PackType).Where(a => a.SalesOrderId == id);
                else
                    return null;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }
    }
}
