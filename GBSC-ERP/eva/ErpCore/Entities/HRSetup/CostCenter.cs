using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.HRSetup
{
    public class CostCenter : BaseClass
    {
        public CostCenter()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public long CostCenterId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? CostCenterCode { get; set; }
        public decimal? ProfitCenterCode { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
