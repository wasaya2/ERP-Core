using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class Currency : BaseClass
    {
        [Key]
        public long CurrencyId { get; set; }
        public string Name { get; set; }
        public double? ExchangeRate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool? IsBase { get; set; }
        public bool? IsActive { get; set; }
        public long? RoundOff { get; set; }
    }
}
