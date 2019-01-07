using ErpCore.Entities;
using InventoryService.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos.Interfaces
{
    public interface ISalesReturnRepository : IRepo<SalesReturn>
    {
        IList<SalesReturn> GetSalesReturns();
        IList<SalesReturn> GetSalesReturnsForMonth(DateTime date);
        IEnumerable<SalesReturn> GetSalesReturnsByMonth(DateTime date);
    }
}
