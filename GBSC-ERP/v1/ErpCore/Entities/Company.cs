using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class Company
    {
        public Company()
        {
            Countries = new HashSet<Country>();
        }

        [Key]
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public long? NumberOfEmployees { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? EditedAt { get; set; } = DateTime.Now;

        public long? EditedBy { get; set; }

        public bool? Deleted { get; set; } = false;

        public IEnumerable<Country> Countries { get; set; }

        //For Finance

        public string NTN { get; set; }
        public long? AssetsAccountId { get; set; }
        public long? ExpenseAccountId { get; set; }
        public long? RevenueAccountId { get; set; }
        public long? LiabilitiesAccountId { get; set; }
        public long? EquityAccountId { get; set; }
    }
}
