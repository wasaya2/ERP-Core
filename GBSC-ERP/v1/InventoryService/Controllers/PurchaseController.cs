using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ErpCore.Entities;
using ErpCore.Filters;
using ErpInfrastructure.Data;
using InventoryService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    [Produces("application/json")]
    [Route("api/Purchase")]
    public class PurchaseController : Controller
    {
        private IPurchaseIndentRepository Indent_repo;
        private IPurchaseIndentItemRepository IndentItem_repo;

        private IPurchaseOrderRepository order_repo;
        private IPurchaseOrderItemRepository orderitem_repo;

        private IPurchaseInvoiceRepository invoice_repo;

        private IGrnRepository grn_repo;
        private IGrnItemRepository grnItem_repo;

        private IPurchaseReturnRepository return_repo;
        private IPurchaseReturnItemRepository returnitem_repo;

        public PurchaseController(IPurchaseIndentRepository indentrepo, 
            IPurchaseIndentItemRepository indentitem,
            IPurchaseOrderRepository orderrepo, 
            IPurchaseOrderItemRepository orderitemrepo,
            IPurchaseInvoiceRepository invoicerepo, 
            IGrnRepository grnrepo,
            IGrnItemRepository grnitemrepo,
            IPurchaseReturnRepository rtnrepo,
            IPurchaseReturnItemRepository rtnitemrepo)
        {
            Indent_repo = indentrepo;
            IndentItem_repo = indentitem;

            order_repo = orderrepo;
            orderitem_repo = orderitemrepo;

            invoice_repo = invoicerepo;

            grn_repo = grnrepo;
            grnItem_repo = grnitemrepo;

            return_repo = rtnrepo;
            returnitem_repo = rtnitemrepo;
        }

        //[HttpGet("GetPurchasePermissions/{userid}/{RoleId}/{featureid}", Name = "GetPurchasePermissions")]
        //public IEnumerable<Permission> GetPurchasePermissions(long userid, long RoleId, long featureid)
        //{
        //    IEnumerable<Permission> per = Indent_repo.GetFeaturePermissions(userid, RoleId, featureid).Permissions.ToList();
        //    return per;
        //}
        
        #region Purchase Indent
        [HttpGet("GetPurchaseIndents", Name = "GetPurchaseIndents")]
        public IEnumerable<PurchaseIndent> GetPurchaseIndents()
        {
            IEnumerable<PurchaseIndent> po = Indent_repo.GetAll();
            po = po.OrderByDescending(p => p.PurchaseIndentId);
            return po;
        }

        [HttpGet("GetPurchaseIndent/{id}", Name = "GetPurchaseIndent")]
        public PurchaseIndent GetPurchaseIndent(long id) => Indent_repo.GetFirst(o => o.PurchaseIndentId == id);

        [HttpPut("UpdatePurchaseIndent", Name = "UpdatePurchaseIndent")]
        [ValidateModelAttribute]
        public IActionResult UpdatePurchaseIndent([FromBody]PurchaseIndent model)
        {
            Indent_repo.Update(model);
            return new OkObjectResult(new { PurchaseIndentID = model.PurchaseIndentId });
        }

        private string GenPIN()
        {
            try
            {
                PurchaseIndent lastIndent = Indent_repo.GetLast();
                string value = lastIndent.PurchaseIndentNumber;
                string number = Regex.Match(value, "[0-9]+$").Value;

                return value.Substring(0, value.Length - number.Length) +
                        (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException e)
            {
                return "PIN000001";
            }
        }

        [HttpPost("AddPurchaseIndent", Name = "AddPurchaseIndent")]
        [ValidateModelAttribute]
        public IActionResult AddPurchaseIndent([FromBody]PurchaseIndent model)
        {
            model.PurchaseIndentNumber = GenPIN();
            Indent_repo.Add(model);
            return new OkObjectResult(new { PurchaseIndentID = model.PurchaseIndentId });
        }

        [HttpDelete("DeletePurchaseIndent/{id}")]
        public IActionResult DeletePurchaseIndent(long id)
        {
            PurchaseIndent purchaseIndent = Indent_repo.Find(id);
            if (purchaseIndent == null)
            {
                return NotFound();
            }

            Indent_repo.Delete(purchaseIndent);
            return Ok();
        }
        #endregion

        #region Purchase Indent Item
        [HttpGet("GetPurchaseIndentItems", Name = "GetPurchaseIndentItems")]
        public IEnumerable<PurchaseIndentItem> GetPurchaseIndentItems()
        {
            IEnumerable<PurchaseIndentItem> poi = IndentItem_repo.GetAll();
            poi = poi.OrderByDescending(p => p.PurchaseIndentItemId);
            return poi;
        }

        [HttpGet("GetPurchaseIndentItem/{id}", Name = "GetPurchaseIndentItem")]
        public PurchaseIndentItem GetPurchaseIndentItem(long id) => IndentItem_repo.GetFirst(o => o.PurchaseIndentItemId == id);

        [HttpPut("UpdatePurchaseIndentItem", Name = "UpdatePurchaseIndentItem")]
        [ValidateModelAttribute]
        public IActionResult UpdatePurchaseIndentItem([FromBody]PurchaseIndentItem model)
        {
            IndentItem_repo.Update(model);
            return new OkObjectResult(new { PurchaseIndentItemID = model.PurchaseIndentItemId });
        }

        [HttpPost("AddPurchaseIndentItem", Name = "AddPurchaseIndentItem")]
        [ValidateModelAttribute]
        public IActionResult AddPurchaseIndentItem([FromBody]PurchaseIndentItem model)
        {
            IndentItem_repo.Add(model);
            return new OkObjectResult(new { PurchaseIndentItemID = model.PurchaseIndentItemId });
        }

        [HttpDelete("DeletePurchaseIndentItem/{id}")]
        public IActionResult DeletePurchaseIndentItem(long id)
        {
            PurchaseIndentItem purchaseIndentItem = IndentItem_repo.Find(id);
            if (purchaseIndentItem == null)
            {
                return NotFound();
            }

            IndentItem_repo.Delete(purchaseIndentItem);
            return Ok();
        }
        #endregion

        #region Purchase Order
        [HttpGet("GetPurchaseOrders", Name = "GetPurchaseOrders")]
        public IEnumerable<PurchaseOrder> GetPurchaseOrders()
        {
            IEnumerable<PurchaseOrder> po = order_repo.GetAll(a => a.PurchaseOrderItems, b => b.GRN);
            po = po.OrderByDescending(p => p.PurchaseOrderId);
            return po;
        }

        [HttpGet("GetPurchaseOrder/{id}", Name = "GetPurchaseOrder")]
        public PurchaseOrder GetPurchaseOrder(long id) => order_repo.GetFirst(o => o.PurchaseOrderId == id, b => b.PurchaseOrderItems, c => c.GRN);

        [HttpPut("UpdatePurchaseOrder", Name = "UpdatePurchaseOrder")]
        [ValidateModelAttribute]
        public IActionResult UpdatePurchaseOrder([FromBody]PurchaseOrder model)
        {
            order_repo.Update(model);
            return new OkObjectResult(new { PurchaseOrderID = model.PurchaseOrderId });
        }

        private string GenON()
        {
            try
            {
                PurchaseOrder lastOrder = order_repo.GetLast();
                string value = lastOrder.OrderNumber;
                string number = Regex.Match(value, "[0-9]+$").Value;

                return value.Substring(0, value.Length - number.Length) +
                   (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException e)
            {
                return "PON00000001";
            }
        }

        [HttpPost("AddPurchaseOrder", Name = "AddPurchaseOrder")]
        [ValidateModelAttribute]
        public IActionResult AddPurchaseOrder([FromBody]PurchaseOrder model)
        {
            model.OrderNumber = GenON();
            order_repo.Add(model);
            return new OkObjectResult(new { PurchaseOrderID = model.PurchaseOrderId });
        }

        [HttpDelete("DeletePurchaseOrder/{id}")]
        public IActionResult DeletePurchaseOrder(long id)
        {
            PurchaseOrder purchaseOrder = order_repo.Find(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            order_repo.Delete(purchaseOrder);
            return Ok();
        }
        #endregion

        #region Purchase Order Item
        [HttpGet("GetPurchaseOrderItems", Name = "GetPurchaseOrderItems")]
        public IEnumerable<PurchaseOrderItem> GetPurchaseOrderItems()
        {
            IEnumerable<PurchaseOrderItem> poi = orderitem_repo.GetAll();
            poi = poi.OrderByDescending(p => p.PurchaseOrderItemId);
            return poi;
        }

        [HttpGet("GetPurchaseOrderItem/{id}", Name = "GetPurchaseOrderItem")]
        public PurchaseOrderItem GetPurchaseOrderItem(long id) => orderitem_repo.GetFirst(o => o.PurchaseOrderItemId == id);

        [HttpPut("UpdatePurchaseOrderItem", Name = "UpdatePurchaseOrderItem")]
        [ValidateModelAttribute]
        public IActionResult UpdatePurchaseOrderItem([FromBody]PurchaseOrderItem model)
        {
            orderitem_repo.Update(model);
            return new OkObjectResult(new { PurchaseOrderItemID = model.PurchaseOrderItemId });
        }

        [HttpPost("AddPurchaseOrderItem", Name = "AddPurchaseOrderItem")]
        [ValidateModelAttribute]
        public IActionResult AddPurchaseOrderItem([FromBody]PurchaseOrderItem model)
        {
            orderitem_repo.Add(model);
            return new OkObjectResult(new { PurchaseOrderItemID = model.PurchaseOrderItemId });
        }

        [HttpDelete("DeletePurchaseOrderItem/{id}")]
        public IActionResult DeletePurchaseOrderItem(long id)
        {
            PurchaseOrderItem purchaseOrderItem = orderitem_repo.Find(id);
            if (purchaseOrderItem == null)
            {
                return NotFound();
            }

            orderitem_repo.Delete(purchaseOrderItem);
            return Ok();
        }
        #endregion

        #region Purchase Invoice
        [HttpGet("GetPurchaseInvoices", Name = "GetPurchaseInvoices")]
        public IEnumerable<PurchaseInvoice> GetPurchaseInvoices()
        {
            IEnumerable<PurchaseInvoice> pi = invoice_repo.GetAll();
            pi = pi.OrderByDescending(p => p.PurchaseInvoiceId);
            return pi;
        }

        [HttpGet("GetPurchaseInvoice/{id}", Name = "GetPurchaseInvoice")]
        public PurchaseInvoice GetPurchaseInvoice(long id) => invoice_repo.GetFirst(o => o.PurchaseInvoiceId == id);

        [HttpPut("UpdatePurchaseInvoice", Name = "UpdatePurchaseInvoice")]
        [ValidateModelAttribute]
        public IActionResult UpdatePurchaseInvoice([FromBody]PurchaseInvoice model)
        {
            invoice_repo.Update(model);
            return new OkObjectResult(new { PurchaseInvoiceID = model.PurchaseInvoiceId });
        }

        private string GenIN()
        {
            try
            {
                PurchaseInvoice lastInvoice = invoice_repo.GetLast();
                //PurchaseInvoice lastInvoice = context.PurchaseInvoices.LastOrDefault();
                string value = lastInvoice.InvoiceNumber;
                string number = Regex.Match(value, "[0-9]+$").Value;

                return value.Substring(0, value.Length - number.Length) +
                       (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException)
            {
                return "PINV000000001";
            }
        }

        [HttpPost("AddPurchaseInvoice", Name = "AddPurchaseInvoice")]
        [ValidateModelAttribute]
        public IActionResult AddPurchaseInvoice([FromBody]PurchaseInvoice model)
        {
            model.CreatedAt = DateTime.Now;
            model.InvoiceNumber = GenIN();
            invoice_repo.Add(model);
            return new OkObjectResult(new { PurchaseInvoiceID = model.PurchaseInvoiceId });
        }

        [HttpDelete("DeletePurchaseInvoice/{id}")]
        public IActionResult DeletePurchaseInvoice(long id)
        {
            PurchaseInvoice purchaseInvoice = invoice_repo.Find(id);
            if (purchaseInvoice == null)
            {
                return NotFound();
            }

            invoice_repo.Delete(purchaseInvoice);
            return Ok();
        }
        #endregion
        
        #region GRN

        [HttpGet("GetGRNs", Name = "GetGRNs")]
        public IEnumerable<GRN> GetGRNs()
        {
            IEnumerable<GRN> g = grn_repo.GetAll(a => a.PurchaseOrder);
            g = g.OrderByDescending(a => a.GRNId);
            return g;
        }

        [HttpGet("GetGRN/{id}", Name = "GetGRN")]
        public GRN GetGRN(long id) => grn_repo.GetFirst(g => g.GRNId == id, b => b.PurchaseOrder);

        private string GenGRN()
        {
            try
            {
                GRN lastGRN = grn_repo.GetLast();
                //GRN lastGRN = context.GRNs.LastOrDefault();
                string value = lastGRN.GrnNumber;
                string number = Regex.Match(value, "[0-9]+$").Value;
                return value.Substring(0, value.Length - number.Length) +
                        (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException e)
            {
                return "GRN00000001";
            }
        }

        [HttpPost("AddGRN", Name = "AddGRN")]
        [ValidateModelAttribute]
        public IActionResult AddGRN([FromBody]GRN model)
        {
            model.GrnNumber = GenGRN();
            grn_repo.Add(model);
            return new OkObjectResult(new { GRNId = model.GRNId });
        }

        [HttpPut("UpdateGRN", Name = "UpdateGRN")]
        [ValidateModelAttribute]
        public IActionResult UpdateGRN([FromBody]GRN model)
        {
            grn_repo.Update(model);
            return new OkObjectResult(new { GRNID = model.GRNId });
        }

        [HttpDelete("DeleteGRN/{id}")]
        public IActionResult DeleteGRN(long id)
        {
            GRN grn = grn_repo.Find(id);
            if (grn == null)
            {
                return NotFound();
            }

            grn_repo.Delete(grn);
            return Ok();
        }

        #endregion

        #region GRN Item

        [HttpGet("GetGRNItems", Name = "GetGRNItems")]
        public IEnumerable<GrnItem> GetGRNItems()
        {
            return grnItem_repo.GetAll(a => a.GRN).OrderByDescending(a => a.GrnItemId);
        }

        [HttpGet("GetGRNItem/{id}", Name = "GetGRNItem")]
        public GrnItem GetGRNItem(long id) => grnItem_repo.GetFirst(g => g.GrnItemId == id, b => b.GRN);

        [HttpPost("AddGRNItem", Name = "AddGRNItem")]
        [ValidateModelAttribute]
        public IActionResult AddGRNItem([FromBody]GrnItem model)
        {
            grnItem_repo.Add(model);
            return new OkObjectResult(new { GRNItemID = model.GRNId });
        }

        [HttpPut("UpdateGRNItem", Name = "UpdateGRNItem")]
        [ValidateModelAttribute]
        public IActionResult UpdateGRNItem([FromBody]GrnItem model)
        {
            grnItem_repo.Update(model);
            return new OkObjectResult(new { GRNItemID = model.GRNId });
        }

        [HttpDelete("DeleteGRNItem/{id}")]
        public IActionResult DeleteGRNItem(long id)
        {
            GrnItem grn = grnItem_repo.Find(id);
            if (grn == null)
            {
                return NotFound();
            }

            grnItem_repo.Delete(grn);
            return Ok();
        }

        #endregion

        #region Purchase Return
        [HttpGet("GetPurchaseReturns", Name = "GetPurchaseReturns")]
        public IEnumerable<PurchaseReturn> GetPurchaseReturns()
        {
            IEnumerable<PurchaseReturn> sr = return_repo.GetAll();
            sr = sr.OrderByDescending(p => p.PurchaseReturnId);
            return sr;
        }

        [HttpGet("GetPurchaseReturn/{id}", Name = "GetPurchaseReturn")]
        public PurchaseReturn GetPurchaseReturn(long id) => return_repo.GetFirst(o => o.PurchaseReturnId == id);

        [HttpPut("UpdatePurchaseReturn", Name = "UpdatePurchaseReturn")]
        [ValidateModelAttribute]
        public IActionResult UpdatePurchaseReturn([FromBody]PurchaseReturn model)
        {
            return_repo.Update(model);
            return new OkObjectResult(new { PurchaseReturnID = model.PurchaseReturnId });
        }

        private string GenRN()
        {
            try
            {
                PurchaseReturn lastReturn = return_repo.GetLast();
                //PurchaseReturn lastReturn = context.PurchaseReturns.LastOrDefault();
                string value = lastReturn.ReturnNumber;
                string number = Regex.Match(value, "[0-9]+$").Value;

                return value.Substring(0, value.Length - number.Length) +
                       (long.Parse(number) + 1).ToString().PadLeft(number.Length, '0');
            }
            catch(NullReferenceException e)
            {
                return "PRN0000001";
            }
        }

        [HttpPost("AddPurchaseReturn", Name = "AddPurchaseReturn")]
        [ValidateModelAttribute]
        public IActionResult AddPurchaseReturn([FromBody]PurchaseReturn model)
        {
            model.ReturnNumber = GenRN();
            return_repo.Add(model);
            return new OkObjectResult(new { PurchaseReturnID = model.PurchaseReturnId });
        }

        [HttpDelete("DeletePurchaseReturn/{id}")]
        public IActionResult DeletePurchaseReturn(long id)
        {
            PurchaseReturn PurchaseReturn = return_repo.Find(id);
            if (PurchaseReturn == null)
            {
                return NotFound();
            }

            return_repo.Delete(PurchaseReturn);
            return Ok();
        }
        #endregion

        #region Purchase Return Item
        [HttpGet("GetPurchaseReturnItems", Name = "GetPurchaseReturnItems")]
        public IEnumerable<PurchaseReturnItem> GetPurchaseReturnItems()
        {
            IEnumerable<PurchaseReturnItem> sri = returnitem_repo.GetAll();
            sri = sri.OrderByDescending(p => p.PurchaseReturnItemId);
            return sri;
        }

        [HttpGet("GetPurchaseReturnItem/{id}", Name = "GetPurchaseReturnItem")]
        public PurchaseReturnItem GetPurchaseReturnItem(long id) => returnitem_repo.GetFirst(o => o.PurchaseReturnItemId == id);

        [HttpPut("UpdatePurchaseReturnItem", Name = "UpdatePurchaseReturnItem")]
        [ValidateModelAttribute]
        public IActionResult UpdatePurchaseReturnItem([FromBody]PurchaseReturnItem model)
        {
            returnitem_repo.Update(model);
            return new OkObjectResult(new { PurchaseReturnItemID = model.PurchaseReturnItemId });
        }

        [HttpPost("AddPurchaseReturnItem", Name = "AddPurchaseReturnItem")]
        [ValidateModelAttribute]
        public IActionResult AddPurchaseReturnItem([FromBody]PurchaseReturnItem model)
        {
            returnitem_repo.Add(model);
            return new OkObjectResult(new { PurchaseReturnItemID = model.PurchaseReturnItemId });
        }

        [HttpDelete("DeletePurchaseReturnItem/{id}")]
        public IActionResult DeletePurchaseReturnItem(long id)
        {
            PurchaseReturnItem PurchaseReturnItem = returnitem_repo.Find(id);
            if (PurchaseReturnItem == null)
            {
                return NotFound();
            }

            returnitem_repo.Delete(PurchaseReturnItem);
            return Ok();
        }
        #endregion

        #region Get Details By Code

        [HttpGet("GetPurchaseIndentDetailsByCode/{code}", Name = "GetPurchaseIndentDetailsByCode")]
        public PurchaseIndent GetPurchaseIndentDetailsByCode([FromRoute]string code)
        {
            return Indent_repo.GetFirst(a => a.PurchaseIndentNumber == code, b => b.PurchaseIndentItems);
        }

        [HttpGet("GetPurchaseOrderDetailsByCode/{code}", Name = "GetPurchaseOrderDetailsByCode")]
        public PurchaseOrder GetPurchaseOrderDetailsByCode([FromRoute]string code)
        {
            return order_repo.GetPurchaseOrderDetailsByCode(code);
            //return order_repo.GetFirst(a => a.OrderNumber == code, b => b.PurchaseOrderItems, c => c.PurchaseIndent, d => d.Supplier);
        }

        [HttpGet("GetPurchaseInvoiceDetailsByCode/{code}", Name = "GetPurchaseInvoiceDetailsByCode")]
        public PurchaseInvoice GetPurchaseInvoiceDetailsByCode([FromRoute]string code)
        {
            return invoice_repo.GetFirst(a => a.InvoiceNumber == code, b => b.PurchaseOrder);
        }

        [HttpGet("GetGrnDetailsByCode/{code}", Name = "GetGrnDetailsByCode")]
        public GRN GetGrnDetailsByCode([FromRoute]string code)
        {
            return grn_repo.GetFirst(a => a.GrnNumber == code, b => b.PurchaseInvoice);
        }

        [HttpGet("GetPurchaseReturnDetailsByCode/{code}", Name = "GetPurchaseReturnDetailsByCode")]
        public PurchaseReturn GetPurchaseReturnDetailsByCode([FromRoute]string code)
        {
            return return_repo.GetFirst(a => a.ReturnNumber == code, b => b.PurchaseReturnItems, c => c.GRN, d => d.ReturnReason);
        }

        #endregion

        #region Get By Date

        
        [HttpGet("GetPurchaseOrdersByMonth/{date}", Name = "GetPurchaseOrdersByMonth")]
        public IEnumerable<PurchaseOrder> GetPurchaseOrdersByMonth([FromRoute]DateTime date)
        {
            return order_repo.GetPurchaseOrdersByMonth(date);
        }

        [HttpGet("GetPurchaseReturnsByMonth/{date}", Name = "GetPurchaseReturnsByMonth")]
        public IEnumerable<PurchaseReturn> GetPurchaseReturnsByMonth([FromRoute]DateTime date)
        {
            return return_repo.GetPurchaseReturnsByMonth(date);
        }

        [HttpGet("GetGRNsByMonth/{date}", Name = "GetGRNsByMonth")]
        public IEnumerable<GRN> GetGRNsByMonth([FromRoute]DateTime date)
        {
            return grn_repo.GetGRNsByMonth(date);
        }

        [HttpGet("GetPurchaseInvoicesByMonth/{date}", Name = "GetPurchaseInvoicesByMonth")]
        public IEnumerable<PurchaseInvoice> GetPurchaseInvoicesByMonth([FromRoute]DateTime date)
        {
            return invoice_repo.GetList(a => a.CreatedAt.Value.Month == date.Month && a.CreatedAt.Value.Year == date.Year, b => b.GRN).OrderByDescending(a => a.PurchaseInvoiceId);
        }

        #endregion

    }
}