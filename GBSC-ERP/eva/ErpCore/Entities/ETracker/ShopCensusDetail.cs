using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.ETracker
{
    public class ShopCensusDetail
    {
        [Key]
        public long SerialNumber { get; set; }
        public string StoreName { get; set; }
        public string ShopkeeperName { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
        public string CNIC { get; set; }
        public string Distributor { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Region { get; set; }
        public string Territory { get; set; }
        public string Section { get; set; }
        public string Subsection { get; set; }
        public string DSF { get; set; }
        public string Category { get; set; }
        public string Classification { get; set; }
        public string Day { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateUser { get; set; }
        public string ImageLink { get; set; }
    }
}
