using ErpCore.Entities.Finance;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.FinanceSetup
{
    public class DetailAccount : BaseClass
    {
        public DetailAccount()
        {
            FinancePurchaseInvoices = new HashSet<FinancePurchaseInvoice>();
            FinancePurchaseReturns = new HashSet<FinancePurchaseReturn>();
            FinanceSalesInvoices = new HashSet<FinanceSalesInvoice>();
            FinanceSalesReturns = new HashSet<FinanceSalesReturn>();
        }

        [Key]
        public long DetailAccountId { get; set; }
        public string DetailAccountCode { get; set; }
        public string Name { get; set; }

        public double? OpeningBalance { get; set; }
        public double? TotalCreditAmount { get; set; }
        public double? CurrentCreditAmount { get; set; }
        public double? TotalDeitAmount { get; set; }
        public double? CurrentDebitAmount { get; set; }

        public long? SecondSubAccountId { get; set; }
        public SecondSubAccount SecondSubAccount { get; set; }

        public IEnumerable<FinancePurchaseInvoice> FinancePurchaseInvoices { get; set; }
        public IEnumerable<FinancePurchaseReturn> FinancePurchaseReturns { get; set; }
        public IEnumerable<FinanceSalesInvoice> FinanceSalesInvoices { get; set; }
        public IEnumerable<FinanceSalesReturn> FinanceSalesReturns { get; set; }
    }
}
