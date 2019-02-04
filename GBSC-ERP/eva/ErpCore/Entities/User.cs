using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ErpCore.Entities.HRSetup;
using ErpCore.Entities.HR.Leave.LeaveAdmin;
using ErpCore.Entities.HR.Leave.LeaveSetup;
using ErpCore.Entities.HR.Leave;
using ErpCore.Entities.HR;
using ErpCore.Entities.HR.Payroll.TaxSetup;
using ErpCore.Entities.HR.Payroll.PayrollSetup;
using ErpCore.Entities.HR.Payroll.LoanSetup;
using ErpCore.Entities.HR.Attendance.AttendanceAdmin;
using ErpCore.Entities.HR.Attendance;
using ErpCore.Entities.HR.Attendance.AttendanceSetup;
using ErpCore.Entities.HR.Payroll;
using ErpCore.Entities.InventorySetup;
using ErpCore.Entities.ETracker;
using ErpCore.Entities.HR.Payroll.PayrollAdmin;

namespace ErpCore.Entities
{
    public class User : BaseClass
    {
        public User()
        {
            //Loan
            UserLoans = new HashSet<UserLoan>();

            //Payroll
            PaySlips = new HashSet<PaySlip>();
            CompensationTransactions = new HashSet<CompensationTransaction>();
            UserStopSalaries = new HashSet<UserStopSalary>();
            MasterPayrolls = new HashSet<MasterPayroll>();
            MonthlyUserSalaries = new HashSet<MonthlyUserSalary>();

            //Tax
            TaxableIncomeAdjustments = new HashSet<TaxableIncomeAdjustment>();
            TaxAdjustments = new HashSet<TaxAdjustment>();

            //Attendance
            UserAttendanceFlagExemptions = new HashSet<UserAttendanceFlagExemption>();
            OverTimeEntitlements = new HashSet<OverTimeEntitlement>();
            EmployeeOverTimeEntitlements = new HashSet<EmployeeOverTimeEntitlement>();
            UserRosterAttendances = new HashSet<UserRosterAttendance>();
            OfficialVisitEntries = new HashSet<OfficialVisitEntry>();
            AttendanceRequestApprovers = new HashSet<AttendanceRequestApprover>();
            AttendanceRequests = new HashSet<AttendanceRequest>();
            UserAssignRosters = new HashSet<UserAssignRoster>();

            //HIMS
            PatientInvoices = new HashSet<PatientInvoice>();
            Appointments = new HashSet<Appointment>();

            //Setup
            WorkExperiences = new HashSet<WorkExperience>();
            Relations = new HashSet<Relation>();
            UserLanguages = new HashSet<UserLanguage>();
            UserDocuments = new HashSet<UserDocument>();
            GazettedHolidays = new HashSet<GazettedHolidays>();

            //Leave
            LeavePolicyEmployees = new HashSet<LeavePolicyEmployee>();
            LeaveOpenings = new HashSet<LeaveOpening>();
            LeaveRequests = new HashSet<LeaveRequest>();
            LeaveTypeBalances = new HashSet<LeaveTypeBalance>();

            //Sales
            SalesIndents = new HashSet<SalesIndent>();
            SalesOrders = new HashSet<SalesOrder>();
            DeliveryOrders = new HashSet<DeliveryOrder>();

            //Purchase
            PurchaseIndents = new HashSet<PurchaseIndent>();
            PurchaseOrders = new HashSet<PurchaseOrder>();

            //Permissions
            Permissions = new HashSet<Permission>();

            Subsections = new HashSet<Subsection>();
            Stores = new HashSet<Store>();
            Regions = new HashSet<Region>();
            Cities = new HashSet<City>();
            Areas = new HashSet<Area>();
            Territories = new HashSet<Territory>();
            PJPs = new HashSet<PJP>();
        }

        [Key]
        public long UserId { get; set; }

        public string UserLevel { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string CNIC { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
        public string PhotoFilePath { get; set; }

        public string POB { get; set; }
        public string FatherName { get; set; }
        public DateTime? CNICExpiry { get; set; }
        public string BloodGroup { get; set; }
        public string MaritalStatus { get; set; }
        public string HomePhone { get; set; }
        public string Address { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime? DateCreated { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }

        //Social Networking
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string BloggerProfile { get; set; }
        public string LinkedinUrl { get; set; }
        public string GooglePlusUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string PinterestUrl { get; set; }
        public string YoutubeUrl { get; set; }

        //Payroll
        public long? PayrollId { get; set; }
        public Payroll Payroll { get; set; }

        //HIMS
        public IEnumerable<PatientInvoice> PatientInvoices { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }

        //Setup

        public long? UserPhotoId { get; set; }
        public UserPhoto UserPhoto { get; set; }

        public long? BankId { get; set; }
        public Bank Bank { get; set; }

        public long? CostCenterId { get; set; }
        public CostCenter CostCenter { get; set; }

        public long? UserCompanyId { get; set; }
        public UserCompany UserCompany { get; set; }

        public IEnumerable<GazettedHolidays> GazettedHolidays { get; set; }

        public long? GroupId { get; set; }
        public Group Group { get; set; }

        public IEnumerable<University> Universities { get; set; }

        public IEnumerable<Relation> Relations { get; set; }

        public long? ReligionId { get; set; }
        public Religion Religion { get; set; }

        public IEnumerable<WorkExperience> WorkExperiences { get; set; }

        public long? DepartmentId { get; set; }
        public Department Department { get; set; }

        public long? RoleId { get; set; }
        public Role Role { get; set; }

        public IEnumerable<UserLanguage> UserLanguages { get; set; }
        public IEnumerable<UserDocument> UserDocuments { get; set; }

        //Attendance
        public IEnumerable<UserAttendanceFlagExemption> UserAttendanceFlagExemptions { get; set; }
        public IEnumerable<OverTimeEntitlement> OverTimeEntitlements { get; set; }
        public IEnumerable<EmployeeOverTimeEntitlement> EmployeeOverTimeEntitlements { get; set; }
        public IEnumerable<UserRosterAttendance> UserRosterAttendances { get; set; }
        public IEnumerable<OfficialVisitEntry> OfficialVisitEntries { get; set; }
        public IEnumerable<AttendanceRequestApprover> AttendanceRequestApprovers { get; set; }
        public IEnumerable<AttendanceRequest> AttendanceRequests { get; set; }

        //Sales
        public IEnumerable<SalesIndent> SalesIndents { get; set; }
        public IEnumerable<SalesOrder> SalesOrders { get; set; }
        public IEnumerable<DeliveryOrder> DeliveryOrders { get; set; }

        //Purchase
        public IEnumerable<PurchaseIndent> PurchaseIndents { get; set; }
        public IEnumerable<PurchaseOrder> PurchaseOrders { get; set; }

        //Leave
        public IEnumerable<LeavePolicyEmployee> LeavePolicyEmployees { get; set; }
        public IEnumerable<LeaveOpening> LeaveOpenings { get; set; }
        public IEnumerable<LeaveRequest> LeaveRequests { get; set; }
        public IEnumerable<LeaveTypeBalance> LeaveTypeBalances { get; set; }

        //Permissions
        public IEnumerable<Permission> Permissions { get; set; }

        //Tax
        public IEnumerable<TaxableIncomeAdjustment> TaxableIncomeAdjustments { get; set; }
        public IEnumerable<TaxAdjustment> TaxAdjustments { get; set; }

        //Payroll
        public long? GratuityId { get; set; }
        public Gratuity Gratuity { get; set; }

        public long? PfPaymentId { get; set; }
        public PfPayment PfPayment { get; set; }

        public long? UserSalaryId { get; set; }
        public UserSalary UserSalary { get; set; }

        public IEnumerable<UserStopSalary> UserStopSalaries { get; set; }
        public IEnumerable<PaySlip> PaySlips { get; set; }
        public IEnumerable<CompensationTransaction> CompensationTransactions { get; set; }
        public IEnumerable<MasterPayroll> MasterPayrolls { get; set; }
        public IEnumerable<MonthlyUserSalary> MonthlyUserSalaries { get; set; }

        public IEnumerable<UserAssignRoster> UserAssignRosters { get; set; }

        //Loan
        public IEnumerable<UserLoan> UserLoans { get; set; }

        public long? SectionId { get; set; }
        public Section Section { get; set; }

        public IEnumerable<Subsection> Subsections { get; set; }
        public IEnumerable<Region> Regions { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public IEnumerable<Area> Areas { get; set; }
        public IEnumerable<Territory> Territories { get; set; }

        public IEnumerable<Store> Stores { get; set; }
        public IEnumerable<PJP> PJPs { get; set; }
    }
}

