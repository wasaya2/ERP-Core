using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HR.Payroll.PayrollSetup
{
    public class PayrollBank : BaseClass
    {
        [Key]
        public long? PayrollBankId { get; set; }
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
        public string BranchEmplyeeName { get; set; }
        public string BranchEmplyeeDesignation { get; set; }
        public string BranchContactNumber { get; set; }
        public string BranchAddress { get; set; }
        public bool? CompanyBank { get; set; }
        public string FirstApproverName { get; set; }
        public string FirstApproverDesignation { get; set; }
        public string SecondApproverName { get; set; }
        public string SecondApproverDesignation { get; set; }

        public long? BankAdviceTemplateId { get; set; }
        public BankAdviceTemplate BankAdviceTemplate { get; set; }

        public long ChequeTemplateId { get; set; }
        public ChequeTemplate ChequeTemplate { get; set; }
        
        public string GlCode { get; set; }
        public string CostCentreCode { get; set; }
        public bool? Active { get; set; }

        public long? BankId { get; set; }
        public Bank Bank { get; set; }
    }
}
