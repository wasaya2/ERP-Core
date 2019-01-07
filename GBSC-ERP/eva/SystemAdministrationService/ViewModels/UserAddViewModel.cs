using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAdministrationService.ViewModels
{
    public class UserAddViewModel
    {
        public string Function { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? ConfirmationDueDate { get; set; }
        public DateTime? NextAppraisalDate { get; set; }
        public DateTime? AppraisalConfirmDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string LeavingReason { get; set; }
        public DateTime? ResignDate { get; set; }
        public string Approver { get; set; }
        public long? DesignationId { get; set; }
        public long? DepartmentId { get; set; }
        public long? BranchId { get; set; }
        public long? CountryId { get; set; }
        public long? CityId { get; set; }
        public long? CompanyId { get; set; }
        public long? ManagementLevelId { get; set; }
        public long? EmployeeTypeId { get; set; }
        public long? EmployeeStatusId { get; set; }
        public long? EmployeeGradeId { get; set; }
        public long? QualificationId { get; set; }
        public long? EmployeeShiftId { get; set; } 
         
    }
}
