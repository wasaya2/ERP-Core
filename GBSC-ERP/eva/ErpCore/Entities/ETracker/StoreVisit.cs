using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErpCore.Entities.InventorySetup;

namespace ErpCore.Entities.ETracker
{
    public class StoreVisit : BaseClass
    {
        public StoreVisit(){

            OutletStocks = new HashSet<OutletStock>();
            Merchandisings = new HashSet<Merchandising>();
            CompetatorStocks = new HashSet<CompetatorStock>();
            OrderTakings = new HashSet<OrderTaking>();
            InventoryTakings = new HashSet<InventoryTaking>();
        }

        [Key]
        public long StoreVisitId { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }

        [StringLength(60)]
        public string ContactPersonName { get; set; }

        [StringLength(20)]
        public string ContactNo { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        public bool? PJP { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Status { get; set; }

        public long? StoreId { get; set; }

        public Store Store { get; set; }

        public ICollection<OutletStock> OutletStocks { get; set; }

        public ICollection<Merchandising> Merchandisings { get; set; }

        public ICollection<CompetatorStock> CompetatorStocks { get; set; }

        public ICollection<OrderTaking> OrderTakings { get; set; }

        public ICollection<InventoryTaking> InventoryTakings { get; set; }

    }
}