using ErpCore.Entities;
using InventoryService.Repos.Base;
using InventoryService.Repos.Interfaces;
using InventoryService.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos
{
    public class PurchaseInvoiceRepository : RepoBase<PurchaseInvoice>, IPurchaseInvoiceRepository
    {
        public IEnumerable<PurchaseInvoicePharmacyViewModel> GetPurchaseInvoicesByMonth(DateTime date)
        {
            IEnumerable<PurchaseInvoice> Invoices = Table.Where(a => a.GRNId != null && a.PurchaseOrderId != null && a.InvoiceDate != null && a.InvoiceDate.Value.Month == date.Month && a.InvoiceDate.Value.Year == date.Year).OrderByDescending(a => a.PurchaseInvoiceId);
            IList<PurchaseInvoicePharmacyViewModel> InvoiceViews = new List<PurchaseInvoicePharmacyViewModel>();

            foreach (PurchaseInvoice Invoice in Invoices)
            {
                GRN SelGRN = Db.GRNs.Where(a => a.GRNId == Invoice.GRNId).Include(a => a.GrnItems).FirstOrDefault();

                PurchaseInvoicePharmacyViewModel InvoiceView = new PurchaseInvoicePharmacyViewModel()
                {
                    InvoiceNumber = Invoice.InvoiceNumber,
                    GRNCode = SelGRN.GrnNumber,
                    GRNDate = SelGRN.GrnDate,
                    GRNRemarks = SelGRN.Remarks,
                    InvoiceDate = Invoice.InvoiceDate,
                    TotalPayable = SelGRN.TotalPaymentAmount,
                    TotalQuantity = SelGRN.TotalReceivedQuantity,
                    VendorBillNumber = SelGRN.VendorBillNumber,
                    GrnItems = SelGRN.GrnItems
                };

                InvoiceViews.Add(InvoiceView);
            }

            return InvoiceViews.OrderByDescending(a => a.InvoiceNumber);
        }

        public IEnumerable<PurchaseInvoicePharmacyViewModel> GetPurchaseInvoicesByMonthAndCompany(DateTime date, long companyid)
        {
            IEnumerable<PurchaseInvoice> Invoices = Table.Where(a => a.CompanyId != null && a.CompanyId == companyid && a.GRNId != null && a.PurchaseOrderId != null && a.InvoiceDate != null && a.InvoiceDate.Value.Month == date.Month && a.InvoiceDate.Value.Year == date.Year).OrderByDescending(a => a.PurchaseInvoiceId);
            IList<PurchaseInvoicePharmacyViewModel> InvoiceViews = new List<PurchaseInvoicePharmacyViewModel>();

            foreach (PurchaseInvoice Invoice in Invoices)
            {
                GRN SelGRN = Db.GRNs.Where(a => a.GRNId == Invoice.GRNId).Include(a => a.GrnItems).FirstOrDefault();

                PurchaseInvoicePharmacyViewModel InvoiceView = new PurchaseInvoicePharmacyViewModel()
                {
                    InvoiceNumber = Invoice.InvoiceNumber,
                    GRNCode = SelGRN.GrnNumber,
                    GRNDate = SelGRN.GrnDate,
                    GRNRemarks = SelGRN.Remarks,
                    InvoiceDate = Invoice.InvoiceDate,
                    TotalPayable = SelGRN.TotalPaymentAmount,
                    TotalQuantity = SelGRN.TotalReceivedQuantity,
                    VendorBillNumber = SelGRN.VendorBillNumber,
                    GrnItems = SelGRN.GrnItems
                };

                InvoiceViews.Add(InvoiceView);
            }

            return InvoiceViews.OrderByDescending(a => a.InvoiceNumber);
        }
    }
}
