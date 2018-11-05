using ErpCore.Entities.HR.Payroll.TaxSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities
{
    public class Branch
    {
        public Branch()
        {
            Departments = new HashSet<Department>();
            TaxBenefits = new HashSet<TaxBenefit>();
        }

        [Key]
        public long BranchId { get; set; }
        public string Name { get; set; }
        public string BranchCode { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
         
        public long? CityId { get; set; }
        public City City { get; set; }

        public long? CountryId { get; set; }
        public Country Country { get; set; }

        public long? CompanyId { get; set; }
        public Company Company { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? EditedAt { get; set; } = DateTime.Now;

        public long? EditedBy { get; set; }

        public bool? Deleted { get; set; } = false;


        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<TaxBenefit> TaxBenefits { get; set; }
    }
}
