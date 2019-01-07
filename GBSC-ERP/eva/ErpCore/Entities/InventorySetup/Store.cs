using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErpCore.Entities;
using ErpCore.Entities.ETracker;

namespace ErpCore.Entities.InventorySetup
{
    public class Store : BaseClass
    {
        public Store()
        {
            StoreVisits = new HashSet<StoreVisit>();

            VisitDays = new HashSet<VisitDay>();

            Orders = new HashSet<OrderTaking>();
        }

        [Key]
        public long StoreId { get; set; }

        [StringLength(30)]
        public string ShopName { get; set; }

        public string ShopKeeper { get; set; }

        public string ContactNo { get; set; }

        public string Address { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Landline { get; set; }

        public string Cnic { get; set; }

        public string Category { get; set; }

        public bool? ActiveStatus { get; set; }

        public string Classification { get; set; }

        public string ImageUrl { get; set; }

        public string LandMark { get; set; }

        public int DayRegistered { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public DateTime? NextScheduledVisit { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public long SubsectionId { get; set; }

        public Subsection Subsection { get; set; }

        public ICollection<StoreVisit> StoreVisits { get; set; }

        public ICollection<VisitDay> VisitDays { get; set; }

        public ICollection<OrderTaking> Orders { get; set; }
    }
}
