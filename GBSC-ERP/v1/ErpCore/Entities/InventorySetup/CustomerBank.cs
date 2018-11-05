using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErpCore.Entities.InventorySetup
{
    public class CustomerBank : BaseClass
    {
        [Key]
        public long? CustomerBankId { get; set; }
        public string Name { get; set; }
        public string BankCode { get; set; }
        public string BankTitle { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingCode { get; set; }
        public string SwiftCode { get; set; }
        public string RemitCode { get; set; }
        public string RemitKey { get; set; }
        public string UniqueId { get; set; }
        public string RemitType { get; set; }
        public string BranchCode { get; set; }
        public string Branch { get; set; }
        public string BranchContactNumber { get; set; }
        public string BranchAddress { get; set; }
        public string GlCode { get; set; }
        public bool? Active { get; set; }

        public long? CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
    }
}
