using ErpCore.Entities;
using InventoryService.Repos.Base;
using InventoryService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos.Interfaces
{
    public interface IPurchaseInvoiceRepository : IRepo<PurchaseInvoice>
    {
        IEnumerable<PurchaseInvoicePharmacyViewModel> GetPurchaseInvoicesByMonth(DateTime date);
        IEnumerable<PurchaseInvoicePharmacyViewModel> GetPurchaseInvoicesByMonthAndCompany(DateTime date, long companyid);
    }
}
