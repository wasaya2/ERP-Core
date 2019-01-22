﻿using InventoryService.Repos.Base;
using InventoryService.Repos.Interfaces;
using ErpCore.Entities.InventorySetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Repos
{
    public class TransportRepository : RepoBase<Transport>, ITransportRepository
    {
    }
}