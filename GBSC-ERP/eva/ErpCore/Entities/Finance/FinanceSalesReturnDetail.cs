using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.Finance
{
    public class FinanceSalesReturnDetail
    {
        [Key]
        public long? FinanceSalesReturnDetailId { get; set; }
        public string ItemDescription { get; set; }
        public double? Amount { get; set; }

        public long? FinanceSalesReturnId { get; set; }
        public FinanceSalesReturn FinanceSalesReturn { get; set; }
    }
}
