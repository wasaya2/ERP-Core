using ErpCore.Entities;
using InventoryService.Repos.Base;
using InventoryService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos.Interfaces
{
    public interface IGrnRepository : IRepo<GRN>
    {
        IEnumerable<GRN> GetGRNsByMonth(DateTime date);
        GRN GetGRNDetailsByCode(string code);
        GetGrnWithSupplierForPharmacyPurchaseReturn GetGRNDetailsWithSupplierByCode(string code);
        GetGrnWithSupplierForPharmacyPurchaseReturn GetGRNDetailsWithSupplierByCodeAndCompany(string code, long companyid);
    }
}
