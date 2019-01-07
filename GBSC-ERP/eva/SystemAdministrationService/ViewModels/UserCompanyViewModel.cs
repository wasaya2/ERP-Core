using ErpCore.Entities.HRSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAdministrationService.ViewModels
{
    public class UserCompanyViewModel
    {
    public long? EmployeeStatusId { get; set; }
    public UserCompany UserCompany { get; set; }
    public long? GroupId { get; set; }
    public long? FunctionId { get; set; }
    public long? ManagementLevelId { get; set; }
    public long? EmployeeTypeId { get; set; }


    //public DateTime? ContractStartDate { get; set; }
    //public long? DesignationId { get; set; }
    
    //public DateTime? ContractEndDate { get; set; }
    //public DateTime? AppointmentDate { get; set; }
    //public DateTime? NextAppraisalDate { get; set; }
    //public DateTime? ConfirmationDueDate { get; set; }
    //public DateTime? LeavingDate { get; set; }
    //public DateTime? ResignDate { get; set; }
    //public string Approver { get; set; }

  }
}
