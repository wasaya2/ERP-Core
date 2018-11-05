﻿using ErpCore.Entities;
using InventoryService.Repos.Base;
using InventoryService.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos
{
    public class DeliveryOrderRepository : RepoBase<DeliveryOrder>, IDeliveryOrderRepository
    {
    }
}
