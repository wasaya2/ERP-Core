using System;
using System.Collections.Generic;
using System.Text;

namespace eTrackerCore.Entities.ViewModels
{
    public class StoreViewModel
    {
        public long StoreId { get; set; }

        public string ShopName { get; set; }

        public string ShopKeeper { get; set; }

        public string ContactNumber { get; set; }

        public string Section { get; set; }

        public string Subsection { get; set; }

        public string Address { get; set; }

        public string Cnic { get; set; }

        public string Landline { get; set; }

        public string SalesPerson { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public bool? hasShopKeeperAccount { get; set; }
    }
}
