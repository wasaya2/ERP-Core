﻿using ErpCore.Entities;
using InventoryService.Repos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos.Interfaces
{
    public interface IPurchaseOrderRepository : IRepo<PurchaseOrder>
    {
        PurchaseOrder GetPurchaseOrderDetailsByCode(string code);
        IEnumerable<PurchaseOrder> GetPurchaseOrdersByMonth(DateTime date);
    }
}
