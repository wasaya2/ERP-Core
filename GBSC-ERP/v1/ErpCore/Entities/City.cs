﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities
{
    public class City
    {
        public City()
        {
            Branches = new HashSet<Branch>();
        }

        [Key]
        public long CityId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public long? CompanyId { get; set; }
        public Company Company { get; set; }

        public long? CountryId { get; set; }
        public Country Country { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? EditedAt { get; set; } = DateTime.Now;

        public long? EditedBy { get; set; }

        public bool? Deleted { get; set; } = false;

        public IEnumerable<Branch> Branches { get; set; }
    }
}
