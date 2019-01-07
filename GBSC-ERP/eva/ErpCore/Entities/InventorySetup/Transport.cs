using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Transport : BaseClass
    {
        public Transport()
        {
            DeliveryChallans = new HashSet<DeliveryChallan>();
        }

        [Key]
        public long TransportId { get; set; }
        public string VehicleNumber { get; set; }
        public double? BookFreight { get; set; }
        public double? BuiltyNumber { get; set; }
        public string Driver { get; set; }
        public string DriverContactNumber { get; set; }
        public double? BookWeight { get; set; }

        public IEnumerable<DeliveryChallan> DeliveryChallans { get; set; }
    }
}
