using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.InventorySetup
{
    public class Area : BaseClass
    {
        public Area()
        {
            Territories = new HashSet<Territory>();
        }

        [Key]
        public long AreaId { get; set; }

        public string Name { get; set; }

        public IEnumerable<Territory> Territories { get; set; }

        public City City { get; set; }

        public long? UserId { get; set; }

        public User User { get; set; }
    }
}
