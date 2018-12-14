using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ErpCore.Entities.HRSetup
{
    public class UserCompany : BaseClass
    {
        [Key]
        public long UserCompanyId { get; set; } 
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? ConfirmationDueDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? NextAppraisalDate { get; set; }
        public DateTime? AppraisalConfirmDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string LeavingReason { get; set; }
        public DateTime? ResignDate { get; set; }
        public string Approver { get; set; }

        public long? DesignationId { get; set; }
        public Designation Designation { get; set; }

        public long? DepartmentId { get; set; }
        public Department Department { get; set; }

        public long? FunctionId { get; set; }
        public Function Function { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public long? EmployeeTypeId { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public long? EmployeeStatusId { get; set; }
        public EmployeeStatus EmployeeStatus { get; set; }

        public long? ManagementLevelId { get; set; }
        public ManagementLevel ManagementLevel { get; set; }
    }
}
