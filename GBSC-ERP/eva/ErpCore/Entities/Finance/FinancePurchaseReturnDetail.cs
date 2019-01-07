using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.Finance
{
    public class FinancePurchaseReturnDetail
    {
        [Key]
        public long? FinancePurchaseReturnDetailId { get; set; }
        public string ItemDescription { get; set; }
        public double? Amount { get; set; }

        public long? FinancePurchaseReturnId { get; set; }
        public FinancePurchaseReturn FinancePurchaseReturn { get; set; }
    }
}
