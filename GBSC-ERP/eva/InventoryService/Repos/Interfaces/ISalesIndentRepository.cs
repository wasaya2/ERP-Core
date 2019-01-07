using ErpCore.Entities;
using InventoryService.Repos.Base;
using InventoryService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos.Interfaces
{
    public interface ISalesIndentRepository : IRepo<SalesIndent>
    {
        IList<SalesIndentPharmacyViewModel> GetSalesIndentsByMonth(DateTime date);
        IList<SalesIndentPharmacyViewModel> GetSalesIndentsByDay(DateTime date);
        SalesIndent GetSalesIndentDetailsByCode(string code);
    }
}
