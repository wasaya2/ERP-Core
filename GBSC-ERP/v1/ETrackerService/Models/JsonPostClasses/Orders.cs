using ErpCore.Entities.ETracker;
using eTrackerCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTrackerInfrastructure.Models.JsonPostClasses
{
    public class Orders
    {
        public OrderTaking[] Order { get; set; }
    }

    public class Stocks
    {
        public OutletStock[] Stock { get; set; }
    }

    public class CompetativeStocks
    {
        public CompetatorStock[] CompetatorStock { get; set; }
    }

    public class InventoryTakings
    {
        public InventoryTaking[] InventoryTaking { get; set; }
    }
}
