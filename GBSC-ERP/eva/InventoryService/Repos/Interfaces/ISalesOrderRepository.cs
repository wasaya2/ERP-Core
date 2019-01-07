using ErpCore.Entities;
using InventoryService.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos.Interfaces
{
    public interface ISalesOrderRepository : IRepo<SalesOrder>
    {
        IEnumerable<SalesOrder> GetSalesOrdersByMonth(DateTime date);
        SalesOrder GetSalesOrderDetailsByCode(string code);
    }
}
