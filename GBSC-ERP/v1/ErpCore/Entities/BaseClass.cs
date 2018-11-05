using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ErpCore.Entities
{
    public abstract class BaseClass
    {
        public long? CompanyId { get; set; }

        public long? CountryId { get; set; }

        public long? CityId { get; set; }

        public long? BranchId { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? EditedAt { get; set; } = DateTime.Now;

        public long? EditedBy { get; set; }

        public bool? Deleted { get; set; } = false;
    }
}

