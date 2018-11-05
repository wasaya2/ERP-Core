using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.HRSetup
{
    public class ManagementLevel : BaseClass
    {
        public ManagementLevel()
        {
            UserCompanies = new HashSet<UserCompany>();
        }

        [Key]
        public long ManagementLevelId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<UserCompany> UserCompanies { get; set; }
    }
}
