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
    public class GrnRepository : RepoBase<GRN>, IGrnRepository
    {
        public GRN GetGRNDetailsByCode(string code)
        {
            try
            {
                if (Table.Where(a => a.GrnNumber == code).Include(a => a.PurchaseInvoice).FirstOrDefault().PurchaseInvoice != null)
                    return null;

                return Table.Where(a => a.GrnNumber == code).Include(b => b.GrnItems).Include(c => c.PurchaseOrder).FirstOrDefault();
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public GetGrnWithSupplierForPharmacyPurchaseReturn GetGRNDetailsWithSupplierByCode(string code)
        {
            GetGrnWithSupplierForPharmacyPurchaseReturn newvm = new GetGrnWithSupplierForPharmacyPurchaseReturn();
            try
            {
                if (Table.Where(a => a.GrnNumber == code).Include(a => a.PurchaseInvoice).FirstOrDefault().PurchaseInvoice != null)
                    return null;

                newvm.GRN = Table.Where(a => a.GrnNumber == code).Include(b => b.GrnItems).FirstOrDefault();
                newvm.Supplier = Db.Suppliers.Where(a => a.SupplierId == Db.PurchaseOrders.Where(b => b.PurchaseOrderId == newvm.GRN.PurchaseOrderId).FirstOrDefault().SupplierId).FirstOrDefault();
                return newvm;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public GetGrnWithSupplierForPharmacyPurchaseReturn GetGRNDetailsWithSupplierByCodeAndCompany(string code, long companyid)
        {
            GetGrnWithSupplierForPharmacyPurchaseReturn newvm = new GetGrnWithSupplierForPharmacyPurchaseReturn();
            try
            {
                if (Table.Where(a => a.CompanyId != null && a.CompanyId == companyid && a.GrnNumber == code).Include(a => a.PurchaseInvoice).FirstOrDefault().PurchaseInvoice != null)
                    return null;

                newvm.GRN = Table.Where(a => a.CompanyId != null && a.CompanyId == companyid && a.GrnNumber == code).Include(b => b.GrnItems).FirstOrDefault();
                newvm.Supplier = Db.Suppliers.Where(a => a.CompanyId != null && a.CompanyId == companyid && a.SupplierId == Db.PurchaseOrders.Where(b => b.CompanyId != null && b.CompanyId == companyid && b.PurchaseOrderId == newvm.GRN.PurchaseOrderId).FirstOrDefault().SupplierId).FirstOrDefault();
                return newvm;
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public IEnumerable<GRN> GetGRNsByMonth(DateTime date)
        {
            return Table.Where(a => a.GrnDate.Value.Month == date.Month && a.GrnDate.Value.Year == date.Year)
                .Include(b => b.PurchaseOrder).Include(a => a.GrnItems)
                .Include("GrnItems.InventoryItem").Include("GrnItems.InventoryItem.Brand")
                .Include("GrnItems.InventoryItem.MeasurementUnit").Include("GrnItems.InventoryItem.PackType")
                .Include("GrnItems.InventoryItem.PackSize").Include("GrnItems.InventoryItem.PackCategory")
                .Include("GrnItems.InventoryItem.ProductType").Include("GrnItems.InventoryItem.InventoryItemCategory")
                .Include("GrnItems.InventoryItem.PackageType").Include("GrnItems.InventoryItem.Inventory")
                .ToList().OrderByDescending(a => a.PurchaseOrderId);
        }
    }
}
