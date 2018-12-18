using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ErpCore.Entities;
using ErpCore.Entities.HRSetup;
using ErpCore.Entities.HimsSetup;
using ErpCore.Entities.InventorySetup;
using ErpCore.Entities.FinanceSetup;
using ErpCore.Entities.HR.Attendance.AttendanceAdmin;
using ErpCore.Entities.HR.Attendance;
using ErpCore.Entities.HR.Attendance.OvertimeSetup;
using ErpCore.Entities.HR.Attendance.AttendanceSetup;
using ErpCore.Entities.HR.Leave.LeaveSetup;
using ErpCore.Entities.HR.Leave.LeaveAdmin;
using ErpCore.Entities.HR.Leave;
using ErpCore.Entities.HR.Payroll.PayrollSetup;
using ErpCore.Entities.HR;
using ErpCore.Entities.HR.Payroll.TaxSetup;
using ErpCore.Entities.HR.Payroll;
using ErpCore.Entities.HR.Payroll.PayrollAdmin;
using ErpCore.Entities.HR.Payroll.LoanSetup;
using ErpCore.Entities.Finance;
using System;
using ErpCore.Entities.ETracker;

namespace ErpInfrastructure.Data
{


    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Finance Setup
            modelBuilder.Entity<MasterAccount>().ToTable("Finance_Setup_MasterAccount");
            modelBuilder.Entity<DetailAccount>().ToTable("Finance_Setup_DetailAccount");
            modelBuilder.Entity<SubAccount>().ToTable("Finance_Setup_SubAccount");
            modelBuilder.Entity<SecondSubAccount>().ToTable("Finance_Setup_SecondSubAccount");
            modelBuilder.Entity<FinancialYear>().ToTable("Finance_Setup_FinancialYear");
            modelBuilder.Entity<VoucherType>().ToTable("Finance_Setup_VoucherType");

            //Finance
            modelBuilder.Entity<Account>().ToTable("Finance_Account");
            modelBuilder.Entity<UnprocessedAccountsLedger>().ToTable("Finance_UnprocessedAccountsLedger");
            modelBuilder.Entity<ProcessedAccountsLedger>().ToTable("Finance_ProcessedAccountsLedger");

            modelBuilder.Entity<Voucher>().ToTable("Finance_Voucher");
            modelBuilder.Entity<VoucherDetail>().ToTable("Finance_VoucherDetail");

            modelBuilder.Entity<UnpostedVoucher>().ToTable("Finance_UnpostedVoucher");
            modelBuilder.Entity<PostedVoucher>().ToTable("Finance_PostedVoucher");

            modelBuilder.Entity<FinanceSalesInvoice>().ToTable("Finance_SalesInvoice");
            modelBuilder.Entity<FinanceSalesInvoiceDetail>().ToTable("Finance_SalesInvoiceDetail");
            modelBuilder.Entity<FinanceSalesReturn>().ToTable("Finance_SalesReturn");
            modelBuilder.Entity<FinanceSalesReturnDetail>().ToTable("Finance_SalesReturnDetail");
            modelBuilder.Entity<FinancePurchaseInvoice>().ToTable("Finance_PurchaseInvoice");
            modelBuilder.Entity<FinancePurchaseInvoiceDetail>().ToTable("Finance_PurchaseInvoiceDetail");
            modelBuilder.Entity<FinancePurchaseReturn>().ToTable("Finance_PurchaseReturn");
            modelBuilder.Entity<FinancePurchaseReturnDetail>().ToTable("Finance_PurchaseReturnDetail");

            //HIMS
            modelBuilder.Entity<Patient>().ToTable("Hims_Patient");
            modelBuilder.Entity<Partner>().ToTable("Hims_Partner");
            modelBuilder.Entity<Appointment>().ToTable("Hims_Appointment");
            modelBuilder.Entity<PatientInvoice>().ToTable("Hims_PatientInvoice");
            modelBuilder.Entity<PatientInvoiceItem>().ToTable("Hims_PatientInvoiceItem");
            modelBuilder.Entity<PatientInvoiceReturn>().ToTable("Hims_PatientInvoiceReturn");
            modelBuilder.Entity<PatientInvoiceReturnItem>().ToTable("Hims_PatientInvoiceReturnItem");
            modelBuilder.Entity<PatientReference>().ToTable("Hims_PatientReference");
            modelBuilder.Entity<PatientDocument>().ToTable("Hims_PatientDocument");
            modelBuilder.Entity<SemenAnalysis>().ToTable("Hims_SemenAnalysis");
            modelBuilder.Entity<DailyProcedure>().ToTable("Hims_DailyProcedure");
            modelBuilder.Entity<DailySemenAnalysis>().ToTable("Hims_DailySemenAnalysis");
            //Visit
            modelBuilder.Entity<PatientVital>().ToTable("Hims_PatientVital");
            modelBuilder.Entity<Diagnosis>().ToTable("Hims_Diagnosis");
            modelBuilder.Entity<Visit>().ToTable("Hims_Visit");
            modelBuilder.Entity<VisitNote>().ToTable("Hims_VisitNote");
            modelBuilder.Entity<VisitDiagnosis>().ToTable("Hims_VisitDiagnosis");
            modelBuilder.Entity<VisitTest>().ToTable("Hims_VisitTest");

            //Laboratory
            modelBuilder.Entity<TestUnit>().ToTable("Hims_TestUnit");
            modelBuilder.Entity<ReferenceRange>().ToTable("Hims_ReferenceRange");
            modelBuilder.Entity<BioChemistryTest>().ToTable("Hims_BioChemistryTest");
            modelBuilder.Entity<BioChemistryTestOnTreatment>().ToTable("Hims_BioChemistryTestOnTreatment");
            modelBuilder.Entity<BioChemistryTestOutsider>().ToTable("Hims_BioChemistryTestOutsider");
            modelBuilder.Entity<BioChemistryTestDetails>().ToTable("Hims_BioChemistryTestDetails");
            modelBuilder.Entity<InseminationPrep>().ToTable("Hims_InseminationPrep");
            modelBuilder.Entity<Tvopu>().ToTable("Hims_Tvopu");
            modelBuilder.Entity<PatientInsemenation>().ToTable("Hims_PatientInsemenation");
            modelBuilder.Entity<PatientClinicalRecord>().ToTable("Hims_PatientClinicalRecord");
            modelBuilder.Entity<ClinicalRecordDrugs>().ToTable("Hims_ClinicalRecordDrugs");
            modelBuilder.Entity<PatientEmbryology>().ToTable("Hims_PatientEmbryology");
            modelBuilder.Entity<PatientEmbryologyDetails>().ToTable("Hims_PatientEmbryologyDetails");
            modelBuilder.Entity<EmbryoFreezeThawed>().ToTable("Hims_EmbryoFreezeThawed");
            modelBuilder.Entity<EmbryoFreezeUnthawed>().ToTable("Hims_EmbryoFreezeUnthawed");
            modelBuilder.Entity<ThawAssessment>().ToTable("Hims_ThawAssessment");
            modelBuilder.Entity<Biopsy>().ToTable("Hims_Biopsy");
            modelBuilder.Entity<FreezePrepration>().ToTable("Hims_FreezePrepration");

            //Hims Setup
            modelBuilder.Entity<Consultant>().ToTable("Hims_Consultant");
            modelBuilder.Entity<Package>().ToTable("Hims_Package");
            modelBuilder.Entity<PatientPackage>().ToTable("Hims_PatientPackage");
            modelBuilder.Entity<Test>().ToTable("Hims_Test");
            modelBuilder.Entity<VisitNature>().ToTable("Hims_VisitNature");
            modelBuilder.Entity<AppointmentTest>().ToTable("Hims_AppointmentTest");
            //modelBuilder.Entity<TestUnit>().ToTable("Hims_TestUnit");
            //modelBuilder.Entity<BioChemistryTest>().ToTable("Hims_BioChemistryTest");
            //modelBuilder.Entity<ReferenceRange>().ToTable("Hims_ReferenceRange");
            modelBuilder.Entity<Embryologist>().ToTable("Hims_Embryologist");
            modelBuilder.Entity<EmbryologyCode>().ToTable("Hims_EmbryologyCode");
            modelBuilder.Entity<Medicine>().ToTable("Hims_Medicine");
            modelBuilder.Entity<Protocol>().ToTable("Hims_Protocol");
            modelBuilder.Entity<TreatmentType>().ToTable("Hims_TreatmentType");
            modelBuilder.Entity<Event>().ToTable("Hims_Event");
            modelBuilder.Entity<TestType>().ToTable("Hims_TestType");
            modelBuilder.Entity<TestCategory>().ToTable("Hims_TestCategory");
            modelBuilder.Entity<Procedure>().ToTable("Hims_Procedure");

            //ETracker
            modelBuilder.Entity<CompetatorStock>().ToTable("ETracker_CompetatorStocks");
            modelBuilder.Entity<Merchandising>().ToTable("ETracker_Merchandising");
            modelBuilder.Entity<OrderTaking>().ToTable("ETracker_OrderTaking");
            modelBuilder.Entity<OutletStock>().ToTable("ETracker_OutletStock");
            modelBuilder.Entity<StoreVisit>().ToTable("ETracker_StoreVisit");
            modelBuilder.Entity<VisitDay>().ToTable("ETracker_VisitDay");

            //Inventory
            modelBuilder.Entity<Inventory>().ToTable("Inv_Inventory");

            //Inventory Setup
            modelBuilder.Entity<Brand>().ToTable("Inv_Setup_Brand");
            modelBuilder.Entity<Comission>().ToTable("Inv_Setup_Comission");
            modelBuilder.Entity<Customer>().ToTable("Inv_Setup_Customer");
            modelBuilder.Entity<CustomerBank>().ToTable("Inv_Setup_CustomerBank");
            modelBuilder.Entity<Distributor>().ToTable("Inv_Setup_Distributor");
            modelBuilder.Entity<InventoryItem>().ToTable("Inv_Setup_InventoryItem");
            modelBuilder.Entity<InventoryItemCategory>().ToTable("Inv_Setup_Category");
            modelBuilder.Entity<ItemPriceStructure>().ToTable("Inv_Setup_ItemPriceStructure");
            modelBuilder.Entity<ModeOfPayment>().ToTable("Inv_Setup_ModeOfPayment");
            modelBuilder.Entity<PackCategory>().ToTable("Inv_Setup_PackCategory");
            modelBuilder.Entity<PackSize>().ToTable("Inv_Setup_PackSize");
            modelBuilder.Entity<PackType>().ToTable("Inv_Setup_PackType");
            modelBuilder.Entity<PackageType>().ToTable("Inv_Setup_PackageType");
            modelBuilder.Entity<ProductType>().ToTable("Inv_Setup_ProductType");
            modelBuilder.Entity<Tax>().ToTable("Inv_Setup_Tax");
            modelBuilder.Entity<Transport>().ToTable("Inv_Setup_Transport");
            modelBuilder.Entity<Units>().ToTable("Inv_Setup_Units");
            modelBuilder.Entity<Supplier>().ToTable("Inv_Setup_Supplier");
            modelBuilder.Entity<Area>().ToTable("Inv_Setup_Area");
            modelBuilder.Entity<CustomerWarehouse>().ToTable("Inv_Setup_CustomerWarehouse");
            modelBuilder.Entity<CustomerAccount>().ToTable("Inv_Setup_CustomerAccount");
            modelBuilder.Entity<CustomerPricePickLevel>().ToTable("Inv_Setup_CustomerPricePickLevel");
            modelBuilder.Entity<CustomerType>().ToTable("Inv_Setup_CustomerType");
            modelBuilder.Entity<Region>().ToTable("Inv_Setup_Region");
            modelBuilder.Entity<Territory>().ToTable("Inv_Setup_Territory");
            modelBuilder.Entity<Section>().ToTable("Inv_Setup_Section");
            modelBuilder.Entity<Subsection>().ToTable("Inv_Setup_Subsection");
            modelBuilder.Entity<Store>().ToTable("Inv_Store");
            modelBuilder.Entity<ReturnReason>().ToTable("Inv_Setup_ReturnReason");
            modelBuilder.Entity<InventoryCurrency>().ToTable("Inv_Setup_InventoryCurrency");

            //Purchase
            modelBuilder.Entity<PurchaseIndent>().ToTable("Inv_PurchaseIndent");
            modelBuilder.Entity<PurchaseIndentItem>().ToTable("Inv_PurchaseIndentItem");
            modelBuilder.Entity<PurchaseOrder>().ToTable("Inv_PurchaseOrder");
            modelBuilder.Entity<PurchaseOrderItem>().ToTable("Inv_PurchaseOrderItem");
            modelBuilder.Entity<PurchaseInvoice>().ToTable("Inv_PurchaseInvoice");
            modelBuilder.Entity<GRN>().ToTable("Inv_GRN");
            modelBuilder.Entity<GrnItem>().ToTable("Inv_GRNItem");
            modelBuilder.Entity<PurchaseReturn>().ToTable("Inv_PurchaseReturn");
            modelBuilder.Entity<PurchaseReturnItem>().ToTable("Inv_PurchaseReturnItem");

            //Sales
            modelBuilder.Entity<SalesIndent>().ToTable("Inv_SalesIndent");
            modelBuilder.Entity<SalesIndentItem>().ToTable("Inv_SalesIndentItem");
            modelBuilder.Entity<SalesOrder>().ToTable("Inv_SalesOrder");
            modelBuilder.Entity<SalesOrderItem>().ToTable("Inv_SalesOrderItem");
            modelBuilder.Entity<DeliveryOrder>().ToTable("Inv_DeliveryOrder");
            modelBuilder.Entity<DeliveryOrderItem>().ToTable("Inv_DeliveryOrderItem");
            modelBuilder.Entity<DeliveryChallan>().ToTable("Inv_DeliveryChallan");
            modelBuilder.Entity<SalesInvoice>().ToTable("Inv_SalesInvoice");
            modelBuilder.Entity<SalesReturn>().ToTable("Inv_SalesReturn");
            modelBuilder.Entity<SalesReturnItem>().ToTable("Inv_SalesReturnItem");

            //SystemAdministration
            modelBuilder.Entity<Company>().ToTable("Sys_Company");
            modelBuilder.Entity<Branch>().ToTable("Sys_Branch");
            modelBuilder.Entity<Department>().ToTable("Sys_Department");
            modelBuilder.Entity<Role>().ToTable("Sys_Role");
            modelBuilder.Entity<User>().ToTable("Sys_User");
            modelBuilder.Entity<Module>().ToTable("Sys_Module");
            modelBuilder.Entity<RoleModule>().ToTable("Sys_RoleModule");
            modelBuilder.Entity<Feature>().ToTable("Sys_Feature");
            modelBuilder.Entity<RoleFeature>().ToTable("Sys_RoleFeature");
            modelBuilder.Entity<Permission>().ToTable("Sys_Permission");
            modelBuilder.Entity<Country>().ToTable("Sys_Country");
            modelBuilder.Entity<City>().ToTable("Sys_City");

            //SystemAministration/HRSetup
            modelBuilder.Entity<Bank>().ToTable("Hr_Bank");
            modelBuilder.Entity<CostCenter>().ToTable("Hr_CostCenter");
            modelBuilder.Entity<Degree>().ToTable("Hr_Degree");
            modelBuilder.Entity<Designation>().ToTable("Hr_Designation");
            modelBuilder.Entity<EmployeeStatus>().ToTable("Hr_EmployeeStatus");
            modelBuilder.Entity<EmployeeType>().ToTable("Hr_EmployeeType");
            modelBuilder.Entity<Function>().ToTable("Hr_Function");
            modelBuilder.Entity<GazettedHolidays>().ToTable("Hr_GazettedHolidays");
            modelBuilder.Entity<Group>().ToTable("Hr_Group");
            modelBuilder.Entity<Language>().ToTable("Hr_Language");
            modelBuilder.Entity<ManagementLevel>().ToTable("Hr_ManagementLevel");
            modelBuilder.Entity<Relation>().ToTable("Hr_Relation");
            modelBuilder.Entity<Religion>().ToTable("Hr_Religion");
            modelBuilder.Entity<SkillLevel>().ToTable("Hr_SkillLevel");
            modelBuilder.Entity<University>().ToTable("Hr_University");
            modelBuilder.Entity<UserCompany>().ToTable("Hr_UserCompany");
            modelBuilder.Entity<WorkExperience>().ToTable("Hr_WorkExperience");
            modelBuilder.Entity<UserLanguage>().ToTable("Hr_UserLanguage");
            modelBuilder.Entity<UserPhoto>().ToTable("Hr_UserPhoto");
            modelBuilder.Entity<UserDocument>().ToTable("Hr_UserDocument");
            modelBuilder.Entity<DependantsRelation>().ToTable("Hr_UserDependantRelation");

            //HrAttendance
            modelBuilder.Entity<AttendanceFlagExemption>().ToTable("Hr_Attendance_AttendanceFlagExemption");
            modelBuilder.Entity<AttendanceRule>().ToTable("Hr_Attendance_AttendanceRule");
            modelBuilder.Entity<AttendanceRuleLeaveType>().ToTable("Hr_Attendance_AttendanceRuleLeaveType");
            modelBuilder.Entity<UserAttendanceFlagExemption>().ToTable("Hr_Attendance_UserAttendanceFlagExemption");

            modelBuilder.Entity<AssignRoster>().ToTable("Hr_Attendance_AssignRoster");
            modelBuilder.Entity<AttendanceFlag>().ToTable("Hr_Attendance_AttendanceFlag");
            modelBuilder.Entity<AttendanceRequestApprover>().ToTable("Hr_Attendance_AttendanceRequestApprover");
            modelBuilder.Entity<AttendanceRequestType>().ToTable("Hr_Attendance_AttendanceRequestType");
            modelBuilder.Entity<FlagCategory>().ToTable("Hr_Attendance_FlagCategory");
            modelBuilder.Entity<FlagEffectType>().ToTable("Hr_Attendance_FlagEffectType");
            modelBuilder.Entity<FlagType>().ToTable("Hr_Attendance_FlagType");
            modelBuilder.Entity<FlagValue>().ToTable("Hr_Attendance_FlagValue");
            modelBuilder.Entity<Roster>().ToTable("Hr_Attendance_Roster");
            modelBuilder.Entity<Shift>().ToTable("Hr_Attendance_Shift");
            modelBuilder.Entity<ShiftAttendanceFlag>().ToTable("Hr_Attendance_ShiftAttendanceFlag");
            modelBuilder.Entity<UserRosterAttendanceAttendanceFlag>().ToTable("Hr_Attendance_UserRosterAttendanceAttendanceFlag");
            modelBuilder.Entity<UserAssignRoster>().ToTable("Hr_Attendance_UserAssignRoster");

            modelBuilder.Entity<OverTimeFlag>().ToTable("Hr_Attendance_OverTimeFlag");
            modelBuilder.Entity<OverTimeType>().ToTable("Hr_Attendance_OverTimeType");
            modelBuilder.Entity<EmployeeIncomingOt>().ToTable("Hr_Attendance_EmployeeIncomingOt");
            modelBuilder.Entity<EmployeeOutgoingOt>().ToTable("Hr_Attendance_EmployeeOutgoingOt");
            modelBuilder.Entity<EmployeeWorkingDayOt>().ToTable("Hr_Attendance_EmployeeWorkingDayOt");
            modelBuilder.Entity<EmployeeOffDayOt>().ToTable("Hr_Attendance_EmployeeOffDayOt");

            modelBuilder.Entity<AttendanceRequest>().ToTable("Hr_Attendance_AttendanceRequest");
            modelBuilder.Entity<EmployeeOverTimeEntitlement>().ToTable("Hr_Attendance_EmployeeOverTimeEntitlement");
            modelBuilder.Entity<OfficialVisitEntry>().ToTable("Hr_Attendance_OfficialVisitEntry");
            modelBuilder.Entity<OverTimeEntitlement>().ToTable("Hr_Attendance_OverTimeEntitlement");
            modelBuilder.Entity<UserRosterAttendance>().ToTable("Hr_Attendance_UserRosterAttendance");


            //Leave

            modelBuilder.Entity<LeaveOpening>().ToTable("Hr_Leave_LeaveOpening");
            modelBuilder.Entity<LeaveOpeningDetail>().ToTable("Hr_Leave_LeaveOpeningDetail");
            modelBuilder.Entity<LeavePolicyEmployee>().ToTable("Hr_Leave_LeavePolicyEmployee");

            modelBuilder.Entity<DecimalRoundingMatrix>().ToTable("Hr_Leave_DecimalRoundingMatrix");
            modelBuilder.Entity<LeaveApprover>().ToTable("Hr_Leave_LeaveApprover");
            modelBuilder.Entity<LeaveDayType>().ToTable("Hr_Leave_LeaveDayType");
            modelBuilder.Entity<LeaveEligibility>().ToTable("Hr_Leave_LeaveEligibility");
            modelBuilder.Entity<LeavePolicy>().ToTable("Hr_Leave_LeavePolicy");
            modelBuilder.Entity<LeavePurpose>().ToTable("Hr_Leave_LeavePurpose");
            modelBuilder.Entity<LeaveSubType>().ToTable("Hr_Leave_LeaveSubType");
            modelBuilder.Entity<LeaveType>().ToTable("Hr_Leave_LeaveType");
            modelBuilder.Entity<LeaveTypeBalance>().ToTable("Hr_Leave_LeaveTypeBalance");
            modelBuilder.Entity<LeaveYear>().ToTable("Hr_Leave_LeaveYear");
            modelBuilder.Entity<ProrateMatrix>().ToTable("Hr_Leave_ProrateMatrix");

            modelBuilder.Entity<LeaveApproval>().ToTable("Hr_Leave_LeaveApproval");
            modelBuilder.Entity<LeaveClosing>().ToTable("Hr_Leave_LeaveClosing");
            modelBuilder.Entity<LeaveRequest>().ToTable("Hr_Leave_LeaveRequest");
            modelBuilder.Entity<LeaveRequestDetail>().ToTable("Hr_Leave_LeaveRequestDetail");

            //Payroll

            modelBuilder.Entity<LoanType>().ToTable("Hr_Loan_LoanType");
            modelBuilder.Entity<UserLoan>().ToTable("Hr_Loan_UserLoan");
            modelBuilder.Entity<UserLoanPayslip>().ToTable("Hr_Loan_UserLoanPayslip");

            modelBuilder.Entity<StopSalary>().ToTable("Hr_Payroll_StopSalary");

            modelBuilder.Entity<Allowance>().ToTable("Hr_Payroll_Allowance");
            modelBuilder.Entity<AllowanceArrear>().ToTable("Hr_Payroll_AllowanceArrear");
            modelBuilder.Entity<AllowanceCalculationType>().ToTable("Hr_Payroll_AllowanceCalculationType");
            modelBuilder.Entity<AllowanceDeduction>().ToTable("Hr_Payroll_AllowanceDeduction");
            modelBuilder.Entity<AllowanceRate>().ToTable("Hr_Payroll_AllowanceRate");
            modelBuilder.Entity<BankAdviceTemplate>().ToTable("Hr_Payroll_BankAdviceTemplate");
            modelBuilder.Entity<Benefit>().ToTable("Hr_Payroll_Benefit");
            modelBuilder.Entity<ChequeTemplate>().ToTable("Hr_Payroll_ChequeTemplate");
            modelBuilder.Entity<CompensationTransaction>().ToTable("Hr_Payroll_CompensationTransaction");
            modelBuilder.Entity<Currency>().ToTable("Hr_Payroll_Currency");
            modelBuilder.Entity<Frequency>().ToTable("Hr_Payroll_Frequency");
            modelBuilder.Entity<FundSetup>().ToTable("Hr_Payroll_FundSetup");
            modelBuilder.Entity<GratuitySlab>().ToTable("Hr_Payroll_GratuitySlab");
            modelBuilder.Entity<GratuitySlabGratuity>().ToTable("Hr_Payroll_GratuitySlabGratuity");
            modelBuilder.Entity<GratuityType>().ToTable("Hr_Payroll_GratuityType");
            modelBuilder.Entity<LeavingReason>().ToTable("Hr_Payroll_LeavingReason");
            modelBuilder.Entity<MasterPayroll>().ToTable("Hr_Payroll_MasterPayroll");
            modelBuilder.Entity<MasterPayrollDetails>().ToTable("Hr_Payroll_MasterPayrollDetails");
            modelBuilder.Entity<Payroll>().ToTable("Hr_Payroll_Payroll");
            modelBuilder.Entity<PayrollBank>().ToTable("Hr_Payroll_PayrollBank");
            modelBuilder.Entity<PayrollType>().ToTable("Hr_Payroll_PayrollType");
            modelBuilder.Entity<PayrollYear>().ToTable("Hr_Payroll_PayrollYear");
            modelBuilder.Entity<PfPayment>().ToTable("Hr_Payroll_PfPayment");
            modelBuilder.Entity<SalaryCalculationType>().ToTable("Hr_Payroll_SalaryCalculationType");
            modelBuilder.Entity<SalaryStructure>().ToTable("Hr_Payroll_SalaryStructure");
            modelBuilder.Entity<SalaryStructureDetail>().ToTable("Hr_Payroll_SalaryStructureDetail");
            modelBuilder.Entity<UserSalary>().ToTable("Hr_Payroll_UserSalary");

            modelBuilder.Entity<IncomeTaxRule>().ToTable("Hr_Payroll_IncomeTaxRule");
            modelBuilder.Entity<TaxableIncomeAdjustment>().ToTable("Hr_Payroll_TaxableIncomeAdjustment");
            modelBuilder.Entity<TaxAdjustmentReason>().ToTable("Hr_Payroll_TaxAdjustmentReason");
            modelBuilder.Entity<TaxBenefit>().ToTable("Hr_Payroll_TaxBenefit");
            modelBuilder.Entity<TaxRelief>().ToTable("Hr_Payroll_TaxRelief");
            modelBuilder.Entity<TaxSchedule>().ToTable("Hr_Payroll_TaxSchedule");
            modelBuilder.Entity<TaxYear>().ToTable("Hr_Payroll_TaxYear");

            modelBuilder.Entity<Gratuity>().ToTable("Hr_Payroll_Gratuity");
            modelBuilder.Entity<MonthlyUserSalary>().ToTable("Hr_Payroll_MonthlyUserSalary");

            modelBuilder.Entity<PaySlip>().ToTable("Hr_Payroll_PaySlip");
            modelBuilder.Entity<TaxAdjustment>().ToTable("Hr_Payroll_TaxAdjustment");


            //Finance
            //Account
            modelBuilder.Entity<Account>()
                .HasOne(a => a.FinancialYear)
                .WithMany()
                .HasForeignKey(c => c.FinancialYearId);

            //Finance Setup

            modelBuilder.Entity<Voucher>()
                .HasOne(a => a.FinancialYear)
                .WithMany()
                .HasForeignKey(c => c.FinancialYearId);

            modelBuilder.Entity<DetailAccount>()
                .HasOne(a => a.SecondSubAccount)
                .WithMany(b => b.DetailAccounts)
                .HasForeignKey(c => c.SecondSubAccountId);

            modelBuilder.Entity<SecondSubAccount>()
                .HasOne(a => a.SubAccount)
                .WithMany(b => b.SecondSubAccounts)
                .HasForeignKey(c => c.SubAccountId);

            modelBuilder.Entity<SubAccount>()
                .HasOne(a => a.MasterAccount)
                .WithMany(b => b.SubAccounts)
                .HasForeignKey(c => c.MasterAccountId);

            modelBuilder.Entity<Voucher>()
                .HasOne(a => a.VoucherType)
                .WithMany(b => b.Vouchers)
                .HasForeignKey(c => c.VoucherTypeId);

            modelBuilder.Entity<VoucherDetail>()
                .HasOne(a => a.Voucher)
                .WithMany(b => b.VoucherDetails)
                .HasForeignKey(c => c.VoucherId);

            modelBuilder.Entity<VoucherDetail>()
                .HasOne(a => a.DetailAccount)
                .WithMany()
                .HasForeignKey(b => b.DetailAccountId);

            modelBuilder.Entity<VoucherDetail>()
                .HasOne(a => a.Account)
                .WithMany(b => b.VoucherDetails)
                .HasForeignKey(c => c.AccountId);

            modelBuilder.Entity<Voucher>()
                .HasOne(a => a.FinancialYear)
                .WithMany()
                .HasForeignKey(b => b.FinancialYearId);

            //Fianance Sales

            modelBuilder.Entity<FinanceSalesInvoice>()
                .HasOne(a => a.FinanceSalesReturn)
                .WithOne(b => b.FinanceSalesInvoice)
                .HasForeignKey<FinanceSalesInvoice>(c => c.FinanceSalesReturnId);

            modelBuilder.Entity<FinanceSalesInvoice>()
                .HasOne(a => a.DetailAccount)
                .WithMany(b => b.FinanceSalesInvoices)
                .HasForeignKey(c => c.DetailAccountId);

            modelBuilder.Entity<FinanceSalesInvoiceDetail>()
                .HasOne(a => a.FinanceSalesInvoice)
                .WithMany(b => b.FinanceSalesInvoiceDetails)
                .HasForeignKey(c => c.FinanceSalesInvoiceId);

            //modelBuilder.Entity<FinanceSalesReturn>()
            //    .HasOne(a => a.FinanceSalesInvoice)
            //    .WithOne(b => b.FinanceSalesReturn)
            //    .HasForeignKey<FinanceSalesReturn>(c => c.FinanceSalesInvoiceId);

            modelBuilder.Entity<FinanceSalesReturn>()
                .HasOne(a => a.DetailAccount)
                .WithMany(b => b.FinanceSalesReturns)
                .HasForeignKey(c => c.DetailAccountId);

            modelBuilder.Entity<FinanceSalesReturnDetail>()
                .HasOne(a => a.FinanceSalesReturn)
                .WithMany(b => b.FinanceSalesReturnDetails)
                .HasForeignKey(c => c.FinanceSalesReturnId);

            //Finance Purchase

            modelBuilder.Entity<FinancePurchaseInvoice>()
                .HasOne(a => a.FinancePurchaseReturn)
                .WithOne(b => b.FinancePurchaseInvoice)
                .HasForeignKey<FinancePurchaseInvoice>(c => c.FinancePurchaseReturnId);

            modelBuilder.Entity<FinancePurchaseInvoice>()
                .HasOne(a => a.DetailAccount)
                .WithMany(b => b.FinancePurchaseInvoices)
                .HasForeignKey(c => c.DetailAccountId);

            modelBuilder.Entity<FinancePurchaseInvoiceDetail>()
                .HasOne(a => a.FinancePurchaseInvoice)
                .WithMany(b => b.FinancePurchaseInvoiceDetails)
                .HasForeignKey(c => c.FinancePurchaseInvoiceId);

            //modelBuilder.Entity<FinanceSalesReturn>()
            //    .HasOne(a => a.FinanceSalesInvoice)
            //    .WithOne(b => b.FinanceSalesReturn)
            //    .HasForeignKey<FinanceSalesReturn>(c => c.FinanceSalesInvoiceId);

            modelBuilder.Entity<FinancePurchaseReturn>()
                .HasOne(a => a.DetailAccount)
                .WithMany(b => b.FinancePurchaseReturns)
                .HasForeignKey(c => c.DetailAccountId);

            modelBuilder.Entity<FinancePurchaseReturnDetail>()
                .HasOne(a => a.FinancePurchaseReturn)
                .WithMany(b => b.FinancePurchaseReturnDetails)
                .HasForeignKey(c => c.FinancePurchaseReturnId);

            //HIMS
            //Visit
            modelBuilder.Entity<Visit>()
                .HasOne(a => a.Patient)
                .WithMany(b => b.Visits)
                .HasForeignKey(c => c.PatientId);

            modelBuilder.Entity<Visit>()
                .HasOne(a => a.VisitNote)
                .WithOne(b => b.Visit)
                .HasForeignKey<VisitNote>(c => c.VisitId);

            modelBuilder.Entity<VisitTest>()
                .HasOne(v => v.Visit)
                .WithMany(v => v.VisitTests)
                .HasForeignKey(v => v.VisitId);

            modelBuilder.Entity<VisitTest>()
                .HasOne(v => v.Test)
                .WithMany()
                .HasForeignKey(v => v.TestId);

            modelBuilder.Entity<VisitDiagnosis>()
                .HasOne(v => v.Visit)
                .WithMany(v => v.VisitDiagnoses)
                .HasForeignKey(v => v.VisitId);

            modelBuilder.Entity<VisitDiagnosis>()
                .HasOne(v => v.Diagnosis)
                .WithMany()
                .HasForeignKey(v => v.DiagnosisId);

            //modelBuilder.Entity<VisitNote>()
            //  .HasOne(a => a.Visit)
            //  .WithOne(b => b.VisitNote)
            //  .HasForeignKey<VisitNote>(c => c.VisitId);

            modelBuilder.Entity<Appointment>()
              .HasOne(a => a.Visit)
              .WithOne()
              .HasForeignKey<Appointment>(a => a.VisitId);

            //modelBuilder.Entity<Visit>()
            //    .HasOne(a => a.PatientVital)
            //    .WithOne(b => b.Visit)
            //    .HasForeignKey<PatientVital>(c => c.VisitId);

            modelBuilder.Entity<PatientVital>()
                      .HasOne(a => a.Visit)
                      .WithOne(b => b.PatientVital)
                      .HasForeignKey<Visit>(c => c.PatientVitalId);

      //Laboratory



            modelBuilder.Entity<PatientClinicalRecord>()
                .HasOne(i => i.Tvopu)
                .WithOne(c => c.PatientClinicalRecord)
                .HasForeignKey<Tvopu>(c => c.PatientClinicalRecordId);

            modelBuilder.Entity<PatientClinicalRecord>()
                .HasOne(i => i.PatientInsemenation)
                .WithOne(c => c.PatientClinicalRecord)
                .HasForeignKey<PatientInsemenation>(c => c.PatientClinicalRecordId);

            modelBuilder.Entity<PatientClinicalRecord>()
                .HasOne(i => i.InseminationPrep)
                .WithOne(c => c.PatientClinicalRecord)
                .HasForeignKey<InseminationPrep>(c => c.PatientClinicalRecordId);

            modelBuilder.Entity<PatientClinicalRecord>()
                .HasOne(i => i.ThawAssessment)
                .WithOne(c => c.PatientClinicalRecord)
                .HasForeignKey<ThawAssessment>(c => c.PatientClinicalRecordId);

            modelBuilder.Entity<PatientClinicalRecord>()
                .HasOne(i => i.Biopsy)
                .WithOne(c => c.PatientClinicalRecord)
                .HasForeignKey<Biopsy>(c => c.PatientClinicalRecordId);

            modelBuilder.Entity<PatientClinicalRecord>()
                .HasOne(i => i.FreezePrepration)
                .WithOne(c => c.PatientClinicalRecord)
                .HasForeignKey<FreezePrepration>(c => c.PatientClinicalRecordId);


            modelBuilder.Entity<PatientClinicalRecord>()
                .HasOne(i => i.BioChemistryTestOnTreatment)
                .WithOne(c => c.PatientClinicalRecord)
                .HasForeignKey<BioChemistryTestOnTreatment>(c => c.PatientClinicalRecordId);

            modelBuilder.Entity<Tvopu>()
                .HasOne(b => b.Embryologist)
                .WithMany(b => b.Tvopus)
                .HasForeignKey(b => b.EmbryologistId);

            modelBuilder.Entity<BioChemistryTestDetails>()
                .HasOne(a => a.BioChemistryTest)
                .WithMany(b => b.BioChemistryTestDetails)
                .HasForeignKey(c => c.BioChemistryTestId);

            modelBuilder.Entity<BioChemistryTestDetails>()
                .HasOne(a => a.TestUnit)
                .WithMany()
                .HasForeignKey(b => b.TestUnitId);


      //Patient
  
        modelBuilder.Entity<DailySemenAnalysisProcedure>()
               .HasKey(ds => new { ds.ProcedureId, ds.DailySemenAnalysisId });

        modelBuilder.Entity<DailySemenAnalysisProcedure>()
             .HasOne(pc => pc.Procedure)
             .WithMany(p => p.DailySemenAnalysisProcedures)
             .HasForeignKey(pc => pc.ProcedureId);

        modelBuilder.Entity<DailySemenAnalysisProcedure>()
        .HasOne(pc => pc.DailySemenAnalysis)
        .WithMany(p => p.DailySemenAnalysisProcedures)
        .HasForeignKey(pc => pc.DailySemenAnalysisId);
 
         modelBuilder.Entity<DailySemenAnalysis>()
            .HasOne(a => a.Patient)
            .WithMany()
            .HasForeignKey(c => c.PatientId);

        modelBuilder.Entity<DailySemenAnalysis>()
          .HasOne(a => a.Consultant)
          .WithMany()
          .HasForeignKey(c => c.ConsultantId);


         modelBuilder.Entity<DailyProcedure>()
              .HasOne(a => a.AssignedConsultant)
              .WithMany(b => b.AssignedDailyProcedures)
              .HasForeignKey(c => c.AssignedConsultantId);

        modelBuilder.Entity<DailyProcedure>()
                .HasOne(a => a.PerformedByConsultant)
                .WithMany(b => b.PerformedDailyProcedures)
                .HasForeignKey(c => c.PerformedByConsultantId);

            modelBuilder.Entity<DailyProcedure>()
                .HasOne(a => a.Patient)
                .WithMany(b => b.DailyProcedures)
                .HasForeignKey(c => c.PatientId);

            modelBuilder.Entity<DailyProcedure>()
              .HasOne(a => a.Procedure)
              .WithMany()
              .HasForeignKey(c => c.ProcedureId);
            modelBuilder.Entity<Patient>()
                .HasOne(a => a.Partner)
                .WithOne(p => p.Patient)
                .HasForeignKey<Partner>(b => b.PatientId);

            modelBuilder.Entity<Patient>()
                .HasOne(a => a.PatientReference)
                .WithMany(b => b.Patients)
                .HasForeignKey(c => c.PatientReferenceId);

            modelBuilder.Entity<PatientDocument>()
                .HasOne(a => a.Patient)
                .WithMany(b => b.PatientDocuments)
                .HasForeignKey(c => c.PatientId);

            modelBuilder.Entity<Patient>()
                .HasOne(a => a.VisitNature)
                .WithMany(b => b.Patients)
                .HasForeignKey(c => c.VisitNatureId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.VisitNature)
                .WithMany(b => b.Appointments)
                .HasForeignKey(c => c.VisitNatureId);

            modelBuilder.Entity<AppointmentTest>()
               .HasKey(pc => new { pc.AppointmentId, pc.TestId });

            modelBuilder.Entity<AppointmentTest>()
              .HasOne(pc => pc.Appointment)
              .WithMany(p => p.AppointmentTests)
              .HasForeignKey(pc => pc.AppointmentId);

            modelBuilder.Entity<AppointmentTest>()
              .HasOne(pc => pc.Test)
              .WithMany(c => c.AppointmentTests)
              .HasForeignKey(pc => pc.TestId);

            modelBuilder.Entity<Appointment>()
                .HasOne(p => p.Patient)
                .WithMany(a => a.Appointments)
                .HasForeignKey(b => b.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany(b => b.Appointments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Consultant)
                .WithMany(b => b.Appointments)
                .HasForeignKey(d => d.ConsultantId);

            modelBuilder.Entity<EmbryoFreezeThawed>()
                .HasOne(p => p.Patient)
                .WithMany(i => i.EmbryoFreezeThaweds)
                .HasForeignKey(j => j.PatientId);

            modelBuilder.Entity<EmbryoFreezeUnthawed>()
                .HasOne(p => p.Patient)
                .WithMany(i => i.EmbryoFreezeUnthaweds)
                .HasForeignKey(j => j.PatientId);

            modelBuilder.Entity<PatientInvoice>()
                .HasOne(p => p.Patient)
                .WithMany(i => i.PatientInvoices)
                .HasForeignKey(j => j.PatientId);

            modelBuilder.Entity<PatientInvoice>()
                .HasOne(p => p.Patient)
                .WithMany(i => i.PatientInvoices)
                .HasForeignKey(j => j.PatientId);

            modelBuilder.Entity<PatientInvoice>()
                .HasOne(u => u.User)
                .WithMany(i => i.PatientInvoices)
                .HasForeignKey(j => j.UserId);

            modelBuilder.Entity<PatientInvoiceItem>()
                .HasOne(a => a.PatientInvoice)
                .WithMany(b => b.PatientInvoiceItems)
                .HasForeignKey(c => c.PatientInvoiceId);

            modelBuilder.Entity<PatientInvoice>()
                .HasOne(a => a.Appointment)
                .WithOne(b => b.PatientInvoice)
                .HasForeignKey<PatientInvoice>(c => c.AppointmentId);

            modelBuilder.Entity<PatientInvoiceReturn>()
                .HasOne(a => a.Patient)
                .WithMany(b => b.PatientInvoiceReturns)
                .HasForeignKey(c => c.PatientId);

            modelBuilder.Entity<PatientInvoice>()
                .HasOne(a => a.PatientInvoiceReturn)
                .WithOne(b => b.PatientInvoice)
                .HasForeignKey<PatientInvoiceReturn>(c => c.PatientInvoiceId);

            modelBuilder.Entity<PatientInvoiceReturnItem>()
                .HasOne(a => a.PatientInvoiceReturn)
                .WithMany(b => b.PatientInvoiceReturnItems)
                .HasForeignKey(c => c.PatientInvoiceReturnId);

            modelBuilder.Entity<PatientPackage>()
                .HasOne(a => a.Package)
                .WithMany(b => b.PatientPackages)
                .HasForeignKey(c => c.PackageId);

            modelBuilder.Entity<Patient>()
                .HasOne(a => a.PatientPackage)
                .WithOne(b => b.Patient)
                .HasForeignKey<PatientPackage>(c => c.PatientId);

            //HIMS Setup
            modelBuilder.Entity<Test>()
                .HasOne(a => a.TestType)
                .WithMany()
                .HasForeignKey(b => b.TestTypeId);

            modelBuilder.Entity<Test>()
                .HasOne(a => a.TestCategory)
                .WithMany()
                .HasForeignKey(b => b.TestCategoryId);

            //Inventory
            //Setup
            modelBuilder.Entity<InventoryItem>()
                .HasOne(a => a.Inventory)
                .WithOne(b => b.InventoryItem)
                .HasForeignKey<Inventory>(c => c.InventoryItemId);


            //Customer
            modelBuilder.Entity<CustomerBank>()
                .HasOne(a => a.CustomerType)
                .WithMany(b => b.CustomerBanks)
                .HasForeignKey(c => c.CustomerTypeId);

            modelBuilder.Entity<CustomerAccount>()
                .HasOne(a => a.CustomerType)
                .WithMany(b => b.CustomerAccounts)
                .HasForeignKey(c => c.CustomerTypeId);

            modelBuilder.Entity<CustomerPricePickLevel>()
                .HasOne(a => a.CustomerType)
                .WithMany(b => b.CustomerPricePickLevels)
                .HasForeignKey(c => c.CustomerTypeId);

            modelBuilder.Entity<CustomerWarehouse>()
                .HasOne(a => a.CustomerType)
                .WithMany(b => b.CustomerWarehouses)
                .HasForeignKey(c => c.CustomerTypeId);

            modelBuilder.Entity<Customer>()
                .HasOne(a => a.CustomerType)
                .WithMany(b => b.Customers)
                .HasForeignKey(c => c.CustomerTypeId);

            modelBuilder.Entity<Customer>()
                .HasOne(a => a.ModeOfPayment)
                .WithMany(b => b.Customers)
                .HasForeignKey(c => c.ModeOfPaymentId);

            //end

            modelBuilder.Entity<Territory>()
                .HasOne(a => a.Area)
                .WithMany(b => b.Territories)
                .HasForeignKey(c => c.AreaId);

            modelBuilder.Entity<City>()
                .HasOne(a => a.Region)
                .WithMany(b => b.Cities)
                .HasForeignKey(c => c.RegionId);

            modelBuilder.Entity<Territory>()
                .HasOne(a => a.Distributor)
                .WithOne(b => b.Territory)
                .HasForeignKey<Distributor>(c => c.TerritoryId);

            //Inventory and Etracker
            modelBuilder.Entity<Store>()
                .HasOne(c => c.User)
                .WithMany(e => e.Stores)
                .HasForeignKey(c => c.UserId)
                .IsRequired();

            modelBuilder.Entity<OrderTaking>()
                .HasOne(c => c.Store)
                .WithMany(e => e.Orders)
                .HasForeignKey(c => c.StoreId);


            modelBuilder.Entity<StoreVisit>()
                .HasOne(c => c.Store)
                .WithMany(e => e.StoreVisits)
                .HasForeignKey(c => c.StoreId)
                .IsRequired();

            modelBuilder.Entity<OrderTaking>()
                .HasOne(c => c.StoreVisit)
                .WithMany(e => e.OrderTakings)
                .HasForeignKey(c => c.StoreVisitId)
                .IsRequired();

            modelBuilder.Entity<Merchandising>()
                .HasOne(c => c.StoreVisit)
                .WithMany(e => e.Merchandisings)
                .HasForeignKey(c => c.StoreVisitId)
                .IsRequired();

            modelBuilder.Entity<OutletStock>()
                .HasOne(c => c.StoreVisit)
                .WithMany(e => e.OutletStocks)
                .HasForeignKey(c => c.StoreVisitId)
                .IsRequired();

            modelBuilder.Entity<CompetatorStock>()
                .HasOne(c => c.StoreVisit)
                .WithMany(e => e.CompetatorStocks)
                .HasForeignKey(c => c.StoreVisitId)
                .IsRequired();

            modelBuilder.Entity<Territory>()
               .HasOne(c => c.Area)
               .WithMany(e => e.Territories)
               .HasForeignKey(c => c.AreaId)
               .IsRequired();

            modelBuilder.Entity<Section>()
               .HasOne(c => c.Territory)
               .WithMany(e => e.Sections)
               .HasForeignKey(c => c.TerritoryId)
               .IsRequired();

            modelBuilder.Entity<Subsection>()
               .HasOne(c => c.Section)
               .WithMany(e => e.Subsections)
               .HasForeignKey(c => c.SectionId)
               .IsRequired();

            modelBuilder.Entity<Store>()
               .HasOne(c => c.Subsection)
               .WithMany(e => e.Stores)
               .HasForeignKey(c => c.SubsectionId)
               .IsRequired();

            modelBuilder.Entity<VisitDay>()
               .HasOne(c => c.Store)
               .WithMany(e => e.VisitDays)
               .HasForeignKey(c => c.StoreId);

            modelBuilder.Entity<Subsection>()
               .HasOne(c => c.User)
               .WithMany(e => e.Subsections)
               .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<User>()
                .HasOne(c => c.Distributor)
                .WithMany(e => e.Users)
                .HasForeignKey(c => c.DistributorId);


            modelBuilder.Entity<Section>()
                .HasOne(a => a.User)
                .WithOne(b => b.Section)
                .HasForeignKey<User>(b => b.SectionId);

            modelBuilder.Entity<Territory>()
                .HasOne(a => a.Distributor)
                .WithOne(b => b.Territory)
                .HasForeignKey<Distributor>(b => b.TerritoryId);



            //Purchase
            //Purchase Indent

            modelBuilder.Entity<PurchaseIndent>()
                .HasOne(a => a.User)
                .WithMany(b => b.PurchaseIndents)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<PurchaseIndentItem>()
                .HasOne(a => a.PurchaseIndent)
                .WithMany(b => b.PurchaseIndentItems)
                .HasForeignKey(c => c.PurchaseIndentId);

            modelBuilder.Entity<PurchaseIndentItem>()
                .HasOne(a => a.InventoryItem)
                .WithMany(b => b.PurchaseIndentItems)
                .HasForeignKey(c => c.InventoryItemId);

            modelBuilder.Entity<PurchaseIndentItem>()
                .HasOne(a => a.Inventory)
                .WithMany(b => b.PurchaseIndentItems)
                .HasForeignKey(c => c.InventoryId);

            //modelBuilder.Entity<PurchaseOrder>()
            //    .HasOne(p => p.PurchaseInvoice)
            //    .WithOne(g => g.PurchaseOrder)
            //    .HasForeignKey<PurchaseOrder>(i => i.PurchaseInvoiceId);

            //Purchase Order
            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(a => a.User)
                .WithMany(b => b.PurchaseOrders)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(s => s.Supplier)
                .WithMany(p => p.PurchaseOrders)
                .HasForeignKey(i => i.SupplierId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(a => a.PurchaseIndent)
                .WithOne(b => b.PurchaseOrder)
                .HasForeignKey<PurchaseOrder>(c => c.PurchaseIndentId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(a => a.InventoryCurrency)
                .WithMany()
                .HasForeignKey(b => b.InventoryCurrencyId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(a => a.GRN)
                .WithOne(b => b.PurchaseOrder)
                .HasForeignKey<GRN>(c => c.PurchaseOrderId);

            modelBuilder.Entity<PurchaseOrderItem>()
                .HasOne(a => a.InventoryItem)
                .WithMany(b => b.PurchaseOrderItems)
                .HasForeignKey(c => c.InventoryItemId);

            modelBuilder.Entity<PurchaseOrderItem>()
                .HasOne(a => a.PurchaseOrder)
                .WithMany(b => b.PurchaseOrderItems)
                .HasForeignKey(c => c.PurchaseOrderId);

            //Purchase Invoice
            modelBuilder.Entity<PurchaseInvoice>()
                .HasOne(a => a.PurchaseOrder)
                .WithOne(b => b.PurchaseInvoice)
                .HasForeignKey<PurchaseInvoice>(c => c.PurchaseOrderId);

            //GRN    
            modelBuilder.Entity<GRN>()
                .HasOne(a => a.PurchaseInvoice)
                .WithOne(b => b.GRN)
                .HasForeignKey<GRN>(c => c.PurchaseInvoiceId);

            modelBuilder.Entity<GRN>()
                .HasOne(a => a.PurchaseReturn)
                .WithOne(b => b.GRN)
                .HasForeignKey<GRN>(c => c.PurchaseReturnId);

            modelBuilder.Entity<GrnItem>()
                .HasOne(a => a.GRN)
                .WithMany(b => b.GrnItems)
                .HasForeignKey(c => c.GRNId);

            modelBuilder.Entity<GrnItem>()
                .HasOne(a => a.InventoryItem)
                .WithMany(b => b.GrnItems)
                .HasForeignKey(c => c.InventoryItemId);

            //PurchaseReturn
            modelBuilder.Entity<PurchaseReturn>()
                .HasOne(a => a.GRN)
                .WithOne(b => b.PurchaseReturn)
                .HasForeignKey<PurchaseReturn>(c => c.GRNId);

            modelBuilder.Entity<PurchaseReturn>()
                .HasOne(a => a.ReturnReason)
                .WithMany()
                .HasForeignKey(c => c.ReturnReasonId);

            modelBuilder.Entity<PurchaseReturnItem>()
                .HasOne(a => a.PurchaseReturn)
                .WithMany(b => b.PurchaseReturnItems)
                .HasForeignKey(c => c.PurchaseReturnId);

            modelBuilder.Entity<PurchaseReturnItem>()
                .HasOne(a => a.Inventory)
                .WithMany(b => b.PurchaseReturnItems)
                .HasForeignKey(c => c.InventoryId);

            //Inventory Item

            modelBuilder.Entity<InventoryItem>()
                .HasOne(a => a.Brand)
                .WithMany(b => b.InventoryItems)
                .HasForeignKey(c => c.BrandId);

            //Sales Indent
            modelBuilder.Entity<SalesIndent>()
                .HasOne(a => a.User)
                .WithMany(b => b.SalesIndents)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<SalesIndentItem>()
                .HasOne(a => a.SalesIndent)
                .WithMany(b => b.SalesIndentItems)
                .HasForeignKey(c => c.SalesIndentId);

            //modelBuilder.Entity<SalesIndentItem>()
            //    .HasOne(a => a.Inventory)
            //    .WithMany(b => b.SalesIndentItems)
            //    .HasForeignKey(c => c.InventoryId);

            modelBuilder.Entity<SalesIndentItem>()
                .HasOne(a => a.InventoryItem)
                .WithMany(b => b.SalesIndentItems)
                .HasForeignKey(c => c.InventoryItemId);

            //Sales Order

            modelBuilder.Entity<SalesOrder>()
                .HasOne(a => a.User)
                .WithMany(b => b.SalesOrders)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<SalesOrderItem>()
                .HasOne(a => a.SalesOrder)
                .WithMany(b => b.SalesOrderItems)
                .HasForeignKey(c => c.SalesOrderId);

            modelBuilder.Entity<SalesOrderItem>()
                .HasOne(a => a.InventoryItem)
                .WithMany(b => b.SalesOrderItems)
                .HasForeignKey(c => c.InventoryItemId);

            modelBuilder.Entity<SalesOrderItem>()
                .HasOne(a => a.Inventory)
                .WithMany(b => b.SalesOrderItems)
                .HasForeignKey(c => c.InventoryId);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(a => a.Customer)
                .WithMany(b => b.SalesOrders)
                .HasForeignKey(c => c.CustomerId);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(a => a.Tax)
                .WithMany(b => b.SalesOrders)
                .HasForeignKey(c => c.TaxId);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(a => a.ModeOfPayment)
                .WithMany(b => b.SalesOrders)
                .HasForeignKey(c => c.ModeOfPaymentId);

            modelBuilder.Entity<SalesOrderItem>()
                .HasOne(a => a.Comission)
                .WithMany(b => b.SalesOrderItems)
                .HasForeignKey(c => c.ComissionId);

            //modelBuilder.Entity<SalesOrderItem>()
            //    .HasOne(a => a.Tax)
            //    .WithMany(b => b.SalesOrderItems)
            //    .HasForeignKey(c => c.TaxId);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(a => a.SalesReturn)
                .WithOne(b => b.SalesOrder)
                .HasForeignKey<SalesReturn>(c => c.SalesOrderId);


            modelBuilder.Entity<SalesOrder>()
                .HasOne(a => a.DeliveryOrder)
                .WithOne(b => b.SalesOrder)
                .HasForeignKey<DeliveryOrder>(c => c.SalesOrderId);

            modelBuilder.Entity<SalesOrder>()
                .HasOne(a => a.SalesIndent)
                .WithOne(b => b.SalesOrder)
                .HasForeignKey<SalesOrder>(c => c.SalesIndentId);

            modelBuilder.Entity<SalesOrderItem>()
                .HasOne(a => a.PackType)
                .WithMany(b => b.SalesOrderItems)
                .HasForeignKey(c => c.PackTypeId);

            //Delivery Order

            modelBuilder.Entity<DeliveryOrder>()
                .HasOne(a => a.SalesOrder)
                .WithOne(b => b.DeliveryOrder)
                .HasForeignKey<DeliveryOrder>(c => c.SalesOrderId);

            modelBuilder.Entity<DeliveryOrder>()
                .HasOne(a => a.User)
                .WithMany(b => b.DeliveryOrders)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<DeliveryOrderItem>()
                .HasOne(a => a.DeliveryOrder)
                .WithMany(b => b.DeliveryOrderItems)
                .HasForeignKey(c => c.DeliveryOrderId);

            modelBuilder.Entity<DeliveryOrderItem>()
                .HasOne(a => a.Inventory)
                .WithMany(b => b.DeliveryOrderItems)
                .HasForeignKey(c => c.InventoryId);

            modelBuilder.Entity<DeliveryOrderItem>()
                .HasOne(a => a.InventoryItem)
                .WithMany(b => b.DeliveryOrderItems)
                .HasForeignKey(c => c.InventoryItemId);

            //modelBuilder.Entity<DeliveryOrder>()
            //    .HasOne(a => a.SalesOrder)
            //    .WithOne(b => b.DeliveryOrder)
            //    .HasForeignKey<SalesOrder>(c => c.DeliveryOrderId);

            //Delivery Challan

            //modelBuilder.Entity<DeliveryChallan>()
            //    .HasOne(a => a.SalesOrder)
            //    .WithOne(b => b.DeliveryChallan)
            //    .HasForeignKey<SalesOrder>(c => c.DeliveryChallanId);

            modelBuilder.Entity<DeliveryChallan>()
                .HasOne(a => a.DeliveryOrder)
                .WithOne(b => b.DeliveryChallan)
                .HasForeignKey<DeliveryChallan>(c => c.DeliveryOrderId);

            modelBuilder.Entity<DeliveryChallan>()
                .HasOne(a => a.Transport)
                .WithMany(b => b.DeliveryChallans)
                .HasForeignKey(c => c.TransportId);

            //SalesInvoice

            modelBuilder.Entity<SalesInvoice>()
                .HasOne(a => a.DeliveryChallan)
                .WithOne(b => b.SalesInvoice)
                .HasForeignKey<SalesInvoice>(c => c.DeliveryChallanId);

            //SalesReturn

            modelBuilder.Entity<SalesReturn>()
                .HasOne(a => a.SalesInvoice)
                .WithOne(b => b.SalesReturn)
                .HasForeignKey<SalesReturn>(c => c.SalesInvoiceId);

            modelBuilder.Entity<SalesReturn>()
                .HasOne(a => a.ReturnReason)
                .WithMany()
                .HasForeignKey(c => c.ReturnReasonId);

            modelBuilder.Entity<SalesReturnItem>()
                .HasOne(a => a.SalesReturn)
                .WithMany(b => b.SalesReturnItems)
                .HasForeignKey(c => c.SalesReturnId);

            modelBuilder.Entity<SalesReturnItem>()
                .HasOne(a => a.Inventory)
                .WithMany(b => b.SalesReturnItems)
                .HasForeignKey(c => c.InventoryId);

            modelBuilder.Entity<SalesReturnItem>()
                .HasOne(a => a.InventoryItem)
                .WithMany(b => b.SalesReturnItems)
                .HasForeignKey(c => c.InventoryItemId);

            //SystemAdministration
            //Company->Country->City->Branch->Department->Roles & Users
            modelBuilder.Entity<Country>()
                .HasOne(a => a.Company)
                .WithMany(b => b.Countries)
                .HasForeignKey(c => c.CompanyId);

            modelBuilder.Entity<City>()
                .HasOne(a => a.Country)
                .WithMany(b => b.Cities)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Area>()
               .HasOne(a => a.City)
               .WithMany(b => b.Areas)
               .HasForeignKey(c => c.CityId);

            modelBuilder.Entity<Branch>()
            .HasOne(a => a.City)
            .WithMany(b => b.Branches)
            .HasForeignKey(c => c.CityId);

            modelBuilder.Entity<Department>()
                .HasOne(a => a.Branch)
                .WithMany(b => b.Departments)
                .HasForeignKey(c => c.BranchId);

            modelBuilder.Entity<Role>()
                .HasOne(a => a.Department)
                .WithMany(b => b.Roles)
                .HasForeignKey(c => c.DepartmentId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Role)
                .WithMany(b => b.Users)
                .HasForeignKey(c => c.RoleId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Department)
                .WithMany(b => b.Users)
                .HasForeignKey(c => c.DepartmentId);
            //end

            //Role, Feature, Permission and Module

            modelBuilder.Entity<Feature>()
                .HasOne(a => a.Module)
                .WithMany(b => b.Features)
                .HasForeignKey(c => c.ModuleId);

            modelBuilder.Entity<RoleFeature>()
                .HasKey(i => new { i.RoleId, i.FeatureId });

            modelBuilder.Entity<RoleFeature>()
                .HasOne(a => a.Role)
                .WithMany(b => b.RoleFeatures)
                .HasForeignKey(c => c.RoleId);

            modelBuilder.Entity<RoleFeature>()
                .HasOne(a => a.Feature)
                .WithMany(b => b.RoleFeatures)
                .HasForeignKey(c => c.FeatureId);

            modelBuilder.Entity<RoleModule>()
                .HasKey(i => new { i.RoleId, i.ModuleId });

            modelBuilder.Entity<RoleModule>()
                .HasOne(a => a.Role)
                .WithMany(b => b.RoleModules)
                .HasForeignKey(c => c.RoleId);

            modelBuilder.Entity<RoleModule>()
                .HasOne(a => a.Module)
                .WithMany(b => b.RoleModules)
                .HasForeignKey(c => c.ModuleId);

            modelBuilder.Entity<Permission>()
                .HasOne(a => a.Feature)
                .WithMany(b => b.Permissions)
                .HasForeignKey(c => c.FeatureId);

            modelBuilder.Entity<Permission>()
                .HasOne(a => a.Role)
                .WithMany(b => b.Permissions)
                .HasForeignKey(c => c.RoleId);

            modelBuilder.Entity<Permission>()
                .HasOne(a => a.User)
                .WithMany(b => b.Permissions)
                .HasForeignKey(c => c.UserId);

            //HRUserCreation


            modelBuilder.Entity<SkillLevel>()
                .HasOne(a => a.University)
                .WithMany(b => b.SkillLevels)
                .HasForeignKey(c => c.UniversityId);

            modelBuilder.Entity<WorkExperience>()
                .HasOne(a => a.User)
                .WithMany(b => b.WorkExperiences)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Religion)
                .WithMany(b => b.Users)
                .HasForeignKey(c => c.ReligionId);

            modelBuilder.Entity<UserLanguage>()
                .HasKey(i => new { i.LanguageId, i.UserId });

            modelBuilder.Entity<UserLanguage>()
                .HasOne(a => a.User)
                .WithMany(b => b.UserLanguages)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<UserLanguage>()
                .HasOne(a => a.Language)
                .WithMany(b => b.UserLanguages)
                .HasForeignKey(c => c.LanguageId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Bank)
                .WithOne(b => b.User)
                .HasForeignKey<Bank>(c => c.UserId);

            modelBuilder.Entity<Bank>()
                .HasOne(a => a.User)
                .WithOne(b => b.Bank)
                .HasForeignKey<User>(c => c.BankId);

            modelBuilder.Entity<UserCompany>()
                .HasOne(a => a.User)
                .WithOne(b => b.UserCompany)
                .HasForeignKey<User>(c => c.UserCompanyId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.UserCompany)
                .WithOne(b => b.User)
                .HasForeignKey<UserCompany>(c => c.UserId);

            modelBuilder.Entity<UserCompany>()
                .HasOne(a => a.Designation)
                .WithMany(b => b.UserCompanies)
                .HasForeignKey(c => c.DesignationId);

            modelBuilder.Entity<UserCompany>()
                .HasOne(a => a.EmployeeStatus)
                .WithMany(b => b.UserCompanies)
                .HasForeignKey(c => c.EmployeeStatusId);

            modelBuilder.Entity<UserCompany>()
                .HasOne(a => a.EmployeeType)
                .WithMany(b => b.UserCompanies)
                .HasForeignKey(c => c.EmployeeTypeId);

            modelBuilder.Entity<UserCompany>()
                .HasOne(a => a.Function)
                .WithMany(b => b.UserCompanies)
                .HasForeignKey(c => c.FunctionId);

            modelBuilder.Entity<GazettedHolidays>()
                .HasOne(a => a.User)
                .WithMany(b => b.GazettedHolidays)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Group)
                .WithMany(b => b.Users)
                .HasForeignKey(c => c.GroupId);

            modelBuilder.Entity<University>()
                .HasOne(a => a.User)
                .WithMany(b => b.Universities)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<University>()
                .HasOne(a => a.Degree)
                .WithMany()
                .HasForeignKey(b => b.DegreeId);

            modelBuilder.Entity<Relation>()
                .HasOne(a => a.User)
                .WithMany(b => b.Relations)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Relation>()
                .HasOne(a => a.DependantsRelation)
                .WithMany()
                .HasForeignKey(c => c.DependantsRelationId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.UserPhoto)
                .WithOne(b => b.User)
                .HasForeignKey<User>(c => c.UserPhotoId);

            modelBuilder.Entity<UserDocument>()
                .HasOne(a => a.User)
                .WithMany(b => b.UserDocuments)
                .HasForeignKey(c => c.UserId);


            #region HR Attendance, Leave & Payroll

            //Attendance
            modelBuilder.Entity<AttendanceFlagExemption>()
                .HasOne(a => a.AttendanceFlag)
                .WithMany(b => b.AttendanceFlagExemptions)
                .HasForeignKey(c => c.AttendanceFlagId);

            modelBuilder.Entity<AttendanceFlagExemption>()
                .HasOne(a => a.FlagType)
                .WithMany()
                .HasForeignKey(b => b.FlagTypeId);

            modelBuilder.Entity<AttendanceRule>()
                .HasOne(a => a.AttendanceFlag)
                .WithMany(b => b.AttendanceRules)
                .HasForeignKey(c => c.AttendanceFlagId);

            modelBuilder.Entity<AttendanceRule>()
                .HasOne(a => a.Group)
                .WithMany(b => b.AttendanceRules)
                .HasForeignKey(c => c.GroupId);

            modelBuilder.Entity<AttendanceRuleLeaveType>()
                .HasKey(a => new { a.AttendanceRuleId, a.LeaveTypeId });

            modelBuilder.Entity<AttendanceRuleLeaveType>()
                .HasOne(a => a.AttendanceRule)
                .WithMany(b => b.AttendanceRuleLeaveTypes)
                .HasForeignKey(c => c.AttendanceRuleId);

            modelBuilder.Entity<AttendanceRuleLeaveType>()
                .HasOne(a => a.LeaveType)
                .WithMany(b => b.AttendanceRuleLeaveTypes)
                .HasForeignKey(c => c.LeaveTypeId);

            modelBuilder.Entity<UserAttendanceFlagExemption>()
                .HasKey(a => new { a.UserId, a.AttendanceFlagExemptionId });

            modelBuilder.Entity<UserAttendanceFlagExemption>()
                .HasOne(a => a.User)
                .WithMany(b => b.UserAttendanceFlagExemptions)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<UserAttendanceFlagExemption>()
                .HasOne(a => a.AttendanceFlagExemption)
                .WithMany(b => b.UserAttendanceFlagExemptions)
                .HasForeignKey(c => c.AttendanceFlagExemptionId);

            modelBuilder.Entity<AssignRoster>()
                .HasOne(a => a.Roster)
                .WithMany(b => b.AssignRosters)
                .HasForeignKey(c => c.RosterId);

            modelBuilder.Entity<AssignRoster>()
                .HasOne(a => a.Shift)
                .WithMany(b => b.AssignRosters)
                .HasForeignKey(c => c.ShiftsId);

            modelBuilder.Entity<AttendanceFlag>()
                .HasOne(a => a.FlagValue)
                .WithMany(b => b.AttendanceFlags)
                .HasForeignKey(c => c.FlagValueId);

            modelBuilder.Entity<AttendanceFlag>()
                .HasOne(a => a.FlagCategory)
                .WithMany(b => b.AttendanceFlags)
                .HasForeignKey(c => c.FlagCategoryId);

            modelBuilder.Entity<AttendanceFlag>()
                .HasOne(a => a.FlagType)
                .WithMany(b => b.AttendanceFlags)
                .HasForeignKey(c => c.FlagTypeId);

            modelBuilder.Entity<AttendanceFlag>()
                .HasOne(a => a.FlagEffectType)
                .WithMany(b => b.AttendanceFlags)
                .HasForeignKey(c => c.FlagEffectTypeId);

            modelBuilder.Entity<AttendanceRequest>()
                .HasOne(a => a.AttendanceRequestApprover)
                .WithMany(b => b.AttendanceRequests)
                .HasForeignKey(c => c.AttendanceRequestApproverId);

            modelBuilder.Entity<AttendanceRequestApprover>()
                .HasOne(a => a.User)
                .WithMany(b => b.AttendanceRequestApprovers)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<UserRosterAttendanceAttendanceFlag>()
                .HasKey(a => new { a.AttendanceFlagId, a.UserRosterAttendanceId });

            modelBuilder.Entity<UserRosterAttendanceAttendanceFlag>()
                .HasOne(a => a.AttendanceFlag)
                .WithMany(b => b.UserRosterAttendanceAttendanceFlags)
                .HasForeignKey(c => c.AttendanceFlagId);

            modelBuilder.Entity<UserRosterAttendanceAttendanceFlag>()
                .HasOne(a => a.UserRosterAttendance)
                .WithMany(b => b.UserRosterAttendanceAttendanceFlags)
                .HasForeignKey(c => c.UserRosterAttendanceId);

            modelBuilder.Entity<ShiftAttendanceFlag>()
                .HasOne(a => a.Shift)
                .WithMany(b => b.ShiftAttendanceFlags)
                .HasForeignKey(c => c.ShiftId);

            modelBuilder.Entity<ShiftAttendanceFlag>()
                .HasOne(a => a.AttendanceFlag)
                .WithMany(b => b.ShiftAttendanceFlags)
                .HasForeignKey(c => c.AttendanceFlagId);

            modelBuilder.Entity<ShiftAttendanceFlag>()
                .HasOne(a => a.FlagType)
                .WithMany(b => b.ShiftAttendanceFlags)
                .HasForeignKey(c => c.FlagTypeId);

            modelBuilder.Entity<OverTimeType>()
                .HasOne(a => a.OverTimeFlag)
                .WithMany(b => b.OverTimeTypes)
                .HasForeignKey(c => c.OvertimeFlagId);

            modelBuilder.Entity<AttendanceRequest>()
                .HasOne(a => a.User)
                .WithMany(b => b.AttendanceRequests)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<AttendanceRequest>()
                .HasOne(a => a.AttendanceRequestType)
                .WithMany(b => b.AttendanceRequests)
                .HasForeignKey(c => c.AttendanceRequestTypeId);

            modelBuilder.Entity<AttendanceRequest>()
                .HasOne(a => a.AttendanceRequestApprover)
                .WithMany(b => b.AttendanceRequests)
                .HasForeignKey(c => c.AttendanceRequestApproverId);

            modelBuilder.Entity<AttendanceRequest>()
                .HasOne(a => a.AssignRoster)
                .WithMany(b => b.AttendanceRequests)
                .HasForeignKey(c => c.AssignRosterId);

            modelBuilder.Entity<EmployeeOverTimeEntitlement>()
                .HasOne(a => a.User)
                .WithMany(b => b.EmployeeOverTimeEntitlements)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<EmployeeOverTimeEntitlement>()
                .HasOne(a => a.EmployeeWorkingDayOt)
                .WithOne(b => b.EmployeeOverTimeEntitlement)
                .HasForeignKey<EmployeeOverTimeEntitlement>(c => c.EmployeeWorkingDayOtId);

            modelBuilder.Entity<EmployeeWorkingDayOt>()
                .HasOne(a => a.EmployeeOverTimeEntitlement)
                .WithOne(b => b.EmployeeWorkingDayOt)
                .HasForeignKey<EmployeeWorkingDayOt>(c => c.EmployeeOverTimeEntitlementId);

            modelBuilder.Entity<EmployeeOverTimeEntitlement>()
                .HasOne(a => a.EmployeeOffDayOt)
                .WithOne(b => b.EmployeeOverTimeEntitlement)
                .HasForeignKey<EmployeeOverTimeEntitlement>(c => c.EmployeeOffDayOtId);

            modelBuilder.Entity<EmployeeOffDayOt>()
                .HasOne(a => a.EmployeeOverTimeEntitlement)
                .WithOne(b => b.EmployeeOffDayOt)
                .HasForeignKey<EmployeeOffDayOt>(c => c.EmployeeOverTimeEntitlementId);

            modelBuilder.Entity<EmployeeOverTimeEntitlement>()
                .HasOne(a => a.EmployeeIncomingOt)
                .WithOne(b => b.EmployeeOverTimeEntitlement)
                .HasForeignKey<EmployeeOverTimeEntitlement>(c => c.EmployeeIncomingOtId);

            modelBuilder.Entity<EmployeeIncomingOt>()
                .HasOne(a => a.EmployeeOverTimeEntitlement)
                .WithOne(b => b.EmployeeIncomingOt)
                .HasForeignKey<EmployeeIncomingOt>(c => c.EmployeeOverTimeEntitlementId);

            modelBuilder.Entity<EmployeeOverTimeEntitlement>()
                .HasOne(a => a.EmployeeOutgoingOt)
                .WithOne(b => b.EmployeeOverTimeEntitlement)
                .HasForeignKey<EmployeeOverTimeEntitlement>(c => c.EmployeeOutgoingOtId);

            modelBuilder.Entity<EmployeeOutgoingOt>()
                .HasOne(a => a.EmployeeOverTimeEntitlement)
                .WithOne(b => b.EmployeeOutgoingOt)
                .HasForeignKey<EmployeeOutgoingOt>(c => c.EmployeeOverTimeEntitlementId);

            modelBuilder.Entity<OfficialVisitEntry>()
                .HasOne(a => a.User)
                .WithMany(b => b.OfficialVisitEntries)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<OfficialVisitEntry>()
                .HasOne(a => a.UserRosterAttendance)
                .WithMany(b => b.OfficialVisitEntries)
                .HasForeignKey(c => c.UserRosterAttendanceId);

            modelBuilder.Entity<OverTimeEntitlement>()
                .HasOne(a => a.User)
                .WithMany(b => b.OverTimeEntitlements)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<OverTimeEntitlement>()
                .HasOne(a => a.OverTimeType)
                .WithMany(b => b.OverTimeEntitlements)
                .HasForeignKey(c => c.OverTimeTypeId);

            modelBuilder.Entity<UserRosterAttendance>()
                .HasOne(a => a.User)
                .WithMany(b => b.UserRosterAttendances)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<UserRosterAttendance>()
                .HasOne(a => a.AssignRoster)
                .WithMany(b => b.UserRosterAttendances)
                .HasForeignKey(c => c.AssignRosterId);

            modelBuilder.Entity<UserRosterAttendance>()
                .HasOne(a => a.MonthlyUserSalary)
                .WithMany(b => b.UserRosterAttendances)
                .HasForeignKey(c => c.MonthlyUserSalaryId);

            modelBuilder.Entity<UserRosterAttendance>()
                .HasOne(a => a.LeavePolicyEmployee)
                .WithMany(b => b.UserRosterAttendances)
                .HasForeignKey(c => c.LeavePolicyEmployeeId);

            //Leave

            modelBuilder.Entity<LeaveOpening>()
                .HasOne(a => a.User)
                .WithMany(b => b.LeaveOpenings)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<LeaveOpening>()
                .HasOne(a => a.LeaveYear)
                .WithMany()
                .HasForeignKey(b => b.LeaveYearId);

            modelBuilder.Entity<LeaveOpening>()
                .HasOne(a => a.LeaveRequest)
                .WithOne(b => b.LeaveOpening)
                .HasForeignKey<LeaveOpening>(c => c.LeaveRequestId);

            modelBuilder.Entity<LeaveOpeningDetail>()
                .HasOne(a => a.LeaveOpening)
                .WithMany(b => b.LeaveOpeningDetails)
                .HasForeignKey(c => c.LeaveOpeningId);

            modelBuilder.Entity<LeaveOpeningDetail>()
                .HasOne(a => a.LeaveType)
                .WithMany(b => b.LeaveOpeningDetails)
                .HasForeignKey(c => c.LeaveTypeId);

            modelBuilder.Entity<LeavePolicyEmployee>()
                .HasOne(a => a.LeaveYear)
                .WithMany()
                .HasForeignKey(b => b.LeaveYearId);

            modelBuilder.Entity<LeavePolicyEmployee>()
                .HasOne(a => a.User)
                .WithMany(b => b.LeavePolicyEmployees)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<LeavePolicyEmployee>()
                .HasOne(a => a.LeaveType)
                .WithMany(b => b.LeavePolicyEmployees)
                .HasForeignKey(c => c.LeaveTypeId);

            modelBuilder.Entity<LeavePolicyEmployee>()
                .HasOne(a => a.LeaveDayType)
                .WithMany(b => b.LeavePolicyEmployees)
                .HasForeignKey(c => c.LeaveDayTypeId);

            modelBuilder.Entity<LeavePolicyEmployee>()
                .HasOne(a => a.LeaveEligibility)
                .WithMany(b => b.LeavePolicyEmployees)
                .HasForeignKey(c => c.LeaveEligibilityId);

            modelBuilder.Entity<DecimalRoundingMatrix>()
                .HasOne(a => a.LeavePolicy)
                .WithMany(b => b.DecimalRoundingMatrices)
                .HasForeignKey(c => c.LeavePolicyId);

            modelBuilder.Entity<DecimalRoundingMatrix>()
                .HasOne(a => a.LeavePolicyEmployee)
                .WithMany(b => b.DecimalRoundingMatrices)
                .HasForeignKey(c => c.LeavePolicyEmployeeId);

            modelBuilder.Entity<LeavePolicy>()
                .HasOne(a => a.LeaveYear)
                .WithMany()
                .HasForeignKey(b => b.LeaveYearId);

            modelBuilder.Entity<LeavePolicy>()
                .HasOne(a => a.Group)
                .WithMany(b => b.LeavePolicies)
                .HasForeignKey(c => c.GroupId);

            modelBuilder.Entity<LeavePolicy>()
                .HasOne(a => a.LeaveType)
                .WithMany(b => b.LeavePolicies)
                .HasForeignKey(c => c.LeaveTypeId);

            modelBuilder.Entity<LeavePolicy>()
                .HasOne(a => a.LeaveDayType)
                .WithMany(b => b.LeavePolicies)
                .HasForeignKey(c => c.LeaveDayTypeId);

            modelBuilder.Entity<LeavePolicy>()
                .HasOne(a => a.LeaveEligibility)
                .WithMany(b => b.LeavePolicies)
                .HasForeignKey(c => c.LeaveEligibilityId);

            modelBuilder.Entity<LeaveType>()
                .HasOne(a => a.LeaveSubType)
                .WithMany(b => b.LeaveTypes)
                .HasForeignKey(b => b.LeaveSubTypeId);

            modelBuilder.Entity<LeaveTypeBalance>()
                .HasOne(a => a.LeaveType)
                .WithMany(b => b.LeaveTypeBalances)
                .HasForeignKey(c => c.LeaveTypeId);

            modelBuilder.Entity<LeaveTypeBalance>()
                .HasOne(a => a.User)
                .WithMany(b => b.LeaveTypeBalances)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<ProrateMatrix>()
                .HasOne(a => a.LeavePolicy)
                .WithMany(b => b.ProrateMatrices)
                .HasForeignKey(c => c.LeavePolicyId);

            modelBuilder.Entity<ProrateMatrix>()
                .HasOne(a => a.LeavePolicyEmployee)
                .WithMany(b => b.ProrateMatrices)
                .HasForeignKey(c => c.LeavePolicyEmployeeId);

            modelBuilder.Entity<LeaveClosing>()
                .HasOne(a => a.LeaveYear)
                .WithMany()
                .HasForeignKey(b => b.LeaveYearId);

            modelBuilder.Entity<LeaveClosing>()
                .HasOne(a => a.Department)
                .WithMany(b => b.LeaveClosings)
                .HasForeignKey(c => c.DepartmentId);

            modelBuilder.Entity<LeaveClosing>()
                .HasOne(a => a.Group)
                .WithMany(b => b.LeaveClosings)
                .HasForeignKey(c => c.GroupId);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(a => a.LeaveApproval)
                .WithOne(b => b.LeaveRequest)
                .HasForeignKey<LeaveRequest>(c => c.LeaveApprovalId);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(a => a.User)
                .WithMany(b => b.LeaveRequests)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<LeaveRequest>()
                .HasOne(a => a.LeaveOpening)
                .WithOne(b => b.LeaveRequest)
                .HasForeignKey<LeaveRequest>(c => c.LeaveOpeningId);

            modelBuilder.Entity<LeaveRequestDetail>()
                .HasOne(a => a.LeaveRequest)
                .WithMany(b => b.LeaveRequestDetails)
                .HasForeignKey(c => c.LeaveRequestId);

            modelBuilder.Entity<LeaveRequestDetail>()
                .HasOne(a => a.LeaveYear)
                .WithMany()
                .HasForeignKey(b => b.LeaveYearId);

            modelBuilder.Entity<LeaveRequestDetail>()
                .HasOne(a => a.LeaveType)
                .WithMany(b => b.LeaveRequestDetails)
                .HasForeignKey(c => c.LeaveTypeId);

            modelBuilder.Entity<LeaveApproval>()
                .HasOne(a => a.LeaveRequest)
                .WithOne(b => b.LeaveApproval)
                .HasForeignKey<LeaveApproval>(c => c.LeaveRequestId);

            modelBuilder.Entity<LeaveApproval>()
                .HasOne(a => a.LeaveApprover)
                .WithMany(b => b.LeaveApprovals)
                .HasForeignKey(c => c.LeaveApproverId);

            modelBuilder.Entity<LeaveApprover>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);

            //Loan

            modelBuilder.Entity<UserLoan>()
                .HasOne(a => a.User)
                .WithMany(b => b.UserLoans)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<UserLoan>()
                .HasOne(a => a.LoanType)
                .WithMany(b => b.UserLoans)
                .HasForeignKey(c => c.LoanTypeId);

            modelBuilder.Entity<UserLoanPayslip>()
                .HasKey(a => new { a.PayslipId, a.UserLoanId });

            modelBuilder.Entity<UserLoanPayslip>()
                .HasOne(a => a.PaySlip)
                .WithMany(b => b.UserLoanPayslips)
                .HasForeignKey(c => c.PayslipId);

            modelBuilder.Entity<UserLoanPayslip>()
                .HasOne(a => a.UserLoan)
                .WithMany(b => b.UserLoanPayslips)
                .HasForeignKey(c => c.UserLoanId);

            //Payroll

            modelBuilder.Entity<StopSalary>()
                .HasOne(a => a.PayrollType)
                .WithMany(c => c.StopSalaries)
                .HasForeignKey(b => b.PayrollTypeId);

            modelBuilder.Entity<Allowance>()
                .HasOne(a => a.AllowanceDeduction)
                .WithMany(b => b.Allowances)
                .HasForeignKey(c => c.AllowanceDeductionId);

            modelBuilder.Entity<AllowanceDeduction>()
                .HasOne(a => a.AllowanceCalculationType)
                .WithMany(b => b.AllowanceDeductions)
                .HasForeignKey(c => c.AllowanceCalculationTypeId);

            modelBuilder.Entity<AllowanceRate>()
                .HasOne(a => a.Allowance)
                .WithMany(b => b.AllowanceRates)
                .HasForeignKey(c => c.AllowanceId);

            modelBuilder.Entity<CompensationTransaction>()
                .HasOne(a => a.PayrollYear)
                .WithMany()
                .HasForeignKey(b => b.PayrollyearId);

            modelBuilder.Entity<CompensationTransaction>()
                .HasOne(a => a.PayrollType)
                .WithMany(c => c.CompensationTransactions)
                .HasForeignKey(b => b.PayrollTypeId);

            modelBuilder.Entity<CompensationTransaction>()
                .HasOne(a => a.Allowance)
                .WithMany()
                .HasForeignKey(b => b.AllowanceId);

            modelBuilder.Entity<CompensationTransaction>()
                .HasOne(a => a.User)
                .WithMany(b => b.CompensationTransactions)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<FundSetup>()
                .HasOne(a => a.PayrollYear)
                .WithMany()
                .HasForeignKey(b => b.PayrollYearId);

            modelBuilder.Entity<GratuitySlabGratuity>()
                .HasOne(a => a.Gratuity)
                .WithMany(b => b.GratuitySlabGratuities)
                .HasForeignKey(c => c.GratuityId);

            modelBuilder.Entity<GratuitySlabGratuity>()
                .HasOne(a => a.GratuitySlab)
                .WithMany(b => b.GratuitySlabGratuities)
                .HasForeignKey(c => c.GratuitySlabId);

            modelBuilder.Entity<MasterPayroll>()
                .HasOne(a => a.Bank)
                .WithMany(b => b.MasterPayrolls)
                .HasForeignKey(c => c.BankId);

            modelBuilder.Entity<MasterPayroll>()
                .HasOne(a => a.Currency)
                .WithMany()
                .HasForeignKey(b => b.CurrencyId);

            modelBuilder.Entity<MasterPayrollDetails>()
                .HasOne(a => a.Allowance)
                .WithMany()
                .HasForeignKey(b => b.AllowanceId);

            modelBuilder.Entity<MasterPayrollDetails>()
                .HasOne(a => a.Frequency)
                .WithMany(b => b.MasterPayrollDetails)
                .HasForeignKey(c => c.FrequencyId);

            modelBuilder.Entity<MasterPayrollDetails>()
                .HasOne(a => a.PayrollType)
                .WithMany(c => c.MasterPayrollDetails)
                .HasForeignKey(b => b.PayrollTypeId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Payroll)
                .WithOne(b => b.User)
                .HasForeignKey<Payroll>(c => c.UserId);

            modelBuilder.Entity<Payroll>()
                .HasOne(a => a.MasterPayroll)
                .WithMany(b => b.Payrolls)
                .HasForeignKey(c => c.PayrollId);

            //Monthly User Salary

            modelBuilder.Entity<MonthlyUserSalary>()
                .HasOne(a => a.Payroll)
                .WithMany(b => b.MonthlyUserSalaries)
                .HasForeignKey(c => c.PayrollId);

            modelBuilder.Entity<MonthlyUserSalary>()
                .HasOne(a => a.StopSalary)
                .WithMany(b => b.MonthlyUserSalaries)
                .HasForeignKey(c => c.StopSalaryId);

            modelBuilder.Entity<MonthlyUserSalary>()
                .HasOne(a => a.UserSalary)
                .WithMany(b => b.MonthlyUserSalaries)
                .HasForeignKey(c => c.UserSalaryId);

            modelBuilder.Entity<MonthlyUserSalary>()
                .HasOne(a => a.PfPayment)
                .WithMany(b => b.MonthlyUserSalaries)
                .HasForeignKey(c => c.PfPaymentId);

            modelBuilder.Entity<MonthlyUserSalary>()
                .HasOne(a => a.PaySlip)
                .WithOne(b => b.MonthlyUserSalary)
                .HasForeignKey<PaySlip>(c => c.MonthlyUserSalaryId);

            //User Roster Attendance
            //modelBuilder.Entity<UserRosterAttendance>()
            //    .HasOne(a => a.MonthlyUserSalary)
            //    .WithMany(b => b.UserRosterAttendances)
            //    .HasForeignKey(c => c.MonthlyUserSalaryId);



            modelBuilder.Entity<PayrollBank>()
                .HasOne(a => a.ChequeTemplate)
                .WithMany(b => b.PayrollBanks)
                .HasForeignKey(c => c.ChequeTemplateId);

            modelBuilder.Entity<PayrollBank>()
                .HasOne(a => a.BankAdviceTemplate)
                .WithMany(b => b.PayrollBanks)
                .HasForeignKey(c => c.BankAdviceTemplateId);

            modelBuilder.Entity<PayrollBank>()
                .HasOne(a => a.Bank)
                .WithMany(b => b.PayrollBanks)
                .HasForeignKey(c => c.BankId);

            modelBuilder.Entity<PfPayment>()
                .HasOne(a => a.LeavingReason)
                .WithMany(b => b.PfPayments)
                .HasForeignKey(c => c.LeavingReasonId);

            modelBuilder.Entity<PfPayment>()
                .HasOne(a => a.User)
                .WithOne(b => b.PfPayment)
                .HasForeignKey<PfPayment>(c => c.UserId);

            modelBuilder.Entity<PfPayment>()
                .HasOne(a => a.FundSetup)
                .WithMany()
                .HasForeignKey(b => b.FundSetupId);

            modelBuilder.Entity<SalaryStructure>()
                .HasOne(a => a.Group)
                .WithOne(b => b.SalaryStructure)
                .HasForeignKey<SalaryStructure>(c => c.GroupId);

            modelBuilder.Entity<SalaryStructure>()
                .HasOne(a => a.PayrollType)
                .WithMany(c => c.SalaryStructures)
                .HasForeignKey(b => b.PayrollTypeId);

            modelBuilder.Entity<SalaryStructureDetail>()
                .HasOne(a => a.SalaryCalculationType)
                .WithMany()
                .HasForeignKey(b => b.SalaryCalculationTypeId);

            modelBuilder.Entity<SalaryStructureDetail>()
                .HasOne(a => a.Benefit)
                .WithMany(b => b.SalaryStructureDetails)
                .HasForeignKey(c => c.BenefitId);

            modelBuilder.Entity<SalaryStructureDetail>()
                .HasOne(a => a.Allowance)
                .WithMany(b => b.SalaryStructureDetails)
                .HasForeignKey(c => c.AllowanceId);

            modelBuilder.Entity<SalaryStructureDetail>()
                .HasOne(a => a.SalaryStructure)
                .WithMany(b => b.SalaryStructureDetails)
                .HasForeignKey(c => c.SalaryStructureId);

            modelBuilder.Entity<UserSalary>()
                .HasOne(a => a.IncomeTaxRule)
                .WithMany(b => b.UserSalaries)
                .HasForeignKey(c => c.IncomeTaxRuleId);

            modelBuilder.Entity<UserSalary>()
                .HasOne(a => a.Group)
                .WithMany(b => b.UserSalaries)
                .HasForeignKey(c => c.GroupId);

            modelBuilder.Entity<UserSalary>()
                .HasOne(a => a.User)
                .WithOne(b => b.UserSalary)
                .HasForeignKey<UserSalary>(c => c.UserId);

            modelBuilder.Entity<IncomeTaxRule>()
                .HasOne(a => a.PayrollYear)
                .WithMany()
                .HasForeignKey(b => b.PayrollYearId);

            modelBuilder.Entity<TaxableIncomeAdjustment>()
                .HasOne(a => a.User)
                .WithMany(b => b.TaxableIncomeAdjustments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<TaxableIncomeAdjustment>()
                .HasOne(a => a.Group)
                .WithMany(b => b.TaxableIncomeAdjustments)
                .HasForeignKey(c => c.GroupId);

            modelBuilder.Entity<TaxableIncomeAdjustment>()
                .HasOne(a => a.TaxYear)
                .WithMany()
                .HasForeignKey(b => b.TaxYearId);

            modelBuilder.Entity<TaxableIncomeAdjustment>()
                .HasOne(a => a.PayrollType)
                .WithMany(c => c.TaxableIncomeAdjustments)
                .HasForeignKey(b => b.PayrollTypeId);

            modelBuilder.Entity<TaxableIncomeAdjustment>()
                .HasOne(a => a.TaxAdjustmentReason)
                .WithMany(b => b.TaxableIncomeAdjustments)
                .HasForeignKey(c => c.TaxAdjustmentReasonId);

            modelBuilder.Entity<TaxBenefit>()
                .HasOne(a => a.PayrollType)
                .WithMany(c => c.TaxBenefits)
                .HasForeignKey(b => b.PayrollTypeId);

            modelBuilder.Entity<TaxBenefit>()
                .HasOne(a => a.TaxYear)
                .WithMany()
                .HasForeignKey(b => b.TaxYearId);

            modelBuilder.Entity<TaxBenefit>()
                .HasOne(a => a.Benefit)
                .WithMany(b => b.TaxBenefits)
                .HasForeignKey(c => c.BenefitId);

            modelBuilder.Entity<TaxRelief>()
                .HasOne(a => a.IncomeTaxRule)
                .WithMany(b => b.TaxReliefs)
                .HasForeignKey(c => c.IncomeTaxRuleId);

            modelBuilder.Entity<TaxSchedule>()
                .HasOne(a => a.IncomeTaxRule)
                .WithMany(b => b.TaxSchedules)
                .HasForeignKey(c => c.IncomeTaxRuleId);

            modelBuilder.Entity<Gratuity>()
                .HasOne(a => a.GratuityType)
                .WithMany(b => b.Gratuities)
                .HasForeignKey(c => c.GratuityTypeId);

            modelBuilder.Entity<Gratuity>()
                .HasOne(a => a.LeavingReason)
                .WithMany()
                .HasForeignKey(c => c.LeavingReasonId);

            modelBuilder.Entity<Gratuity>()
                .HasOne(a => a.User)
                .WithOne(b => b.Gratuity)
                .HasForeignKey<Gratuity>(c => c.UserId);

            modelBuilder.Entity<Gratuity>()
                .HasOne(a => a.FundSetup)
                .WithMany()
                .HasForeignKey(b => b.FundSetupId);

            //modelBuilder.Entity<MonthlyUserSalary>()
            //    .HasOne(a => a.StopSalary)
            //    .WithMany(b => b.MonthlyUserSalaries)
            //    .HasForeignKey(c => c.StopSalaryId);

            //modelBuilder.Entity<MonthlyUserSalary>()
            //    .HasOne(a => a.UserSalary)
            //    .WithMany(b => b.MonthlyUserSalaries)
            //    .HasForeignKey(c => c.UserSalaryId);

            //modelBuilder.Entity<MonthlyUserSalary>()
            //    .HasOne(a => a.PfPayment)
            //    .WithMany(b => b.MonthlyUserSalaries)
            //    .HasForeignKey(c => c.PfPaymentId);

            //modelBuilder.Entity<MonthlyUserSalary>()
            //    .HasOne(a => a.PaySlip)
            //    .WithOne(b => b.MonthlyUserSalary)
            //    .HasForeignKey<MonthlyUserSalary>(c => c.PayslipId);

            //modelBuilder.Entity<MonthlyUserSalary>()
            //    .HasOne(a => a.Payroll)
            //    .WithMany(b => b.MonthlyUserSalaries)
            //    .HasForeignKey(c => c.PayrollId);

            //modelBuilder.Entity<PaySlip>()
            //    .HasOne(a => a.MonthlyUserSalary)
            //    .WithOne(b => b.PaySlip)
            //    .HasForeignKey<PaySlip>(c => c.MonthlyUserSalaryId);

            modelBuilder.Entity<PaySlip>()
                .HasOne(a => a.User)
                .WithMany(b => b.PaySlips)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<TaxAdjustment>()
                .HasOne(a => a.TaxYear)
                .WithMany()
                .HasForeignKey(b => b.TaxYearId);

            modelBuilder.Entity<TaxAdjustment>()
                .HasOne(a => a.User)
                .WithMany(b => b.TaxAdjustments)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<TaxAdjustment>()
                .HasOne(a => a.TaxAdjustmentReason)
                .WithMany(b => b.TaxAdjustments)
                .HasForeignKey(c => c.TaxAdjustmentReasonId);

            modelBuilder.Entity<TaxAdjustment>()
                .HasOne(a => a.PayrollType)
                .WithMany(c => c.TaxAdjustments)
                .HasForeignKey(b => b.PayrollTypeId);

            //PayrollFromGroup&User
            modelBuilder.Entity<Group>()
                .HasOne(a => a.SalaryStructure)
                .WithOne(b => b.Group)
                .HasForeignKey<Group>(c => c.SalaryStructureId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Payroll)
                .WithOne(b => b.User)
                .HasForeignKey<User>(c => c.PayrollId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.Gratuity)
                .WithOne(b => b.User)
                .HasForeignKey<User>(c => c.GratuityId);

            //modelBuilder.Entity<User>()
            //    .HasOne(a => a.PfPayment)
            //    .WithOne(b => b.User)
            //    .HasForeignKey<User>(c => c.PfPaymentId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.UserSalary)
                .WithOne(b => b.User)
                .HasForeignKey<User>(c => c.UserSalaryId);

            modelBuilder.Entity<User>()
                .HasOne(a => a.MasterPayroll)
                .WithMany(b => b.Users)
                .HasForeignKey(c => c.MasterPayrollId);

            modelBuilder.Entity<UserAssignRoster>()
                .HasKey(a => new { a.UserId, a.AssignRosterId });

            modelBuilder.Entity<UserAssignRoster>()
                .HasOne(a => a.User)
                .WithMany(b => b.UserAssignRosters)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<UserAssignRoster>()
                .HasOne(a => a.AssignRoster)
                .WithMany(b => b.UserAssignRosters)
                .HasForeignKey(c => c.AssignRosterId);
            #endregion

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var directory = System.IO.Directory.GetCurrentDirectory();

                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(directory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), options => options.ExecutionStrategy(c => new MyExecutionStrategy(c, 0, TimeSpan.FromSeconds(0))));

            }
        }

        //Finance
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UnprocessedAccountsLedger> UnprocessedAccountsLedgers { get; set; }
        public DbSet<ProcessedAccountsLedger> ProcessedAccountsLedgers { get; set; }
        public DbSet<MasterAccount> MasterAccounts { get; set; }
        public DbSet<DetailAccount> DetailAccounts { get; set; }
        public DbSet<SubAccount> SubAccounts { get; set; }
        public DbSet<SecondSubAccount> SecondSubAccounts { get; set; }
        public DbSet<FinancialYear> FinancialYears { get; set; }
        public DbSet<VoucherType> VoucherTypes { get; set; }
        public DbSet<FinancePurchaseInvoice> FinancePurchaseInvoices { get; set; }
        public DbSet<FinancePurchaseInvoiceDetail> FinancePurchaseInvoiceDetails { get; set; }
        public DbSet<FinancePurchaseReturn> FinancePurchaseReturns { get; set; }
        public DbSet<FinancePurchaseReturnDetail> FinancePurchaseReturnDetails { get; set; }
        public DbSet<FinanceSalesInvoice> FinanceSalesInvoices { get; set; }
        public DbSet<FinanceSalesInvoiceDetail> FinanceSalesInvoiceDetails { get; set; }
        public DbSet<FinanceSalesReturn> FinanceSalesReturns { get; set; }
        public DbSet<FinanceSalesReturnDetail> FinanceSalesReturnDetails { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherDetail> VoucherDetails { get; set; }
        public DbSet<UnpostedVoucher> UnpostedVouchers { get; set; }
        public DbSet<PostedVoucher> Postedvouchers { get; set; }

        //HIMS
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PatientReference> PatientReferences { get; set; }
        public DbSet<PatientDocument> PatientDocuments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Consultant> Consultants { get; set; }
        public DbSet<PatientInvoice> PatientInvoices { get; set; }
        public DbSet<PatientInvoiceItem> PatientInvoiceItems { get; set; }
        public DbSet<PatientInvoiceReturn> PatientInvoiceReturns { get; set; }
        public DbSet<PatientInvoiceReturnItem> PatientInvoiceReturnItems { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<AppointmentTest> AppointmentTests { get; set; }
        public DbSet<VisitDiagnosis> VisitDiagnoses { get; set; }
        public DbSet<VisitTest> VisitTests { get; set; }
        public DbSet<PatientPackage> PatientPackages { get; set; }
        public DbSet<DailyProcedure> DailyProcedures { get; set; }
        public DbSet<DailySemenAnalysis> DailySemenAnalysis { get; set; }

        //HimsSetup
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<TestCategory> TestCategories { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Procedure> Procedures { get; set; }

        //Visit
        public DbSet<PatientVital> PatientVitals { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<VisitNote> VisitNotes { get; set; }

        //Laboratory
        public DbSet<TestUnit> TestUnits { get; set; }
        public DbSet<ReferenceRange> ReferenceRanges { get; set; }
        public DbSet<BioChemistryTest> BioChemistryTests { get; set; }
        public DbSet<BioChemistryTestDetails> BioChemistryTestDetails { get; set; }
        public DbSet<BioChemistryTestOnTreatment> BioChemistryTestOnTreatments { get; set; }
        public DbSet<Embryologist> Embryologists { get; set; }
        public DbSet<EmbryologyCode> EmbryologyCodes { get; set; }
        public DbSet<PatientClinicalRecord> PatientClinicalRecords { get; set; }
        public DbSet<TreatmentType> TreatmentTypes { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<ClinicalRecordDrugs> ClinicalRecordDrugs { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PatientInsemenation> PatientInsemenations { get; set; }
        public DbSet<Tvopu> Tvopus { get; set; }
        public DbSet<PatientEmbryology> PatientEmbryologies { get; set; }
        public DbSet<PatientEmbryologyDetails> PatientEmbryologyDetails { get; set; }
        public DbSet<ThawAssessment> ThawAssessments { get; set; }
        public DbSet<EmbryoFreezeThawed> EmbryoFreezeThaweds { get; set; }
        public DbSet<EmbryoFreezeUnthawed> EmbryoFreezeUnthaweds { get; set; }
        public DbSet<FreezePrepration> FreezePreprations { get; set; }
        public DbSet<SemenAnalysis> SemenAnalyses { get; set; }
        public DbSet<BioChemistryTestOutsider> BioChemistryTestOutsiders { get; set; }

        //Inventory
        public DbSet<Inventory> Inventories { get; set; }

        //Purchase
        public DbSet<PurchaseIndent> PurchaseIndents { get; set; }
        public DbSet<PurchaseIndentItem> PurchaseIndentItems { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }

        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }

        public DbSet<GRN> GRNs { get; set; }
        public DbSet<GrnItem> GrnItems { get; set; }

        public DbSet<PurchaseReturn> PurchaseReturns { get; set; }
        public DbSet<PurchaseReturnItem> PurchaseReturnItems { get; set; }

        //Setup
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Comission> Comissions { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerBank> CustomerBanks { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryItemCategory> InventoryItemCategories { get; set; }
        public DbSet<ItemPriceStructure> ItemPriceStructures { get; set; }
        public DbSet<ModeOfPayment> ModeOfPayments { get; set; }
        public DbSet<PackCategory> PackCategories { get; set; }
        public DbSet<PackSize> PackSizes { get; set; }
        public DbSet<PackType> PackTypes { get; set; }
        public DbSet<PackageType> PackageTypes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ReturnReason> ReturnReasons { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<CustomerWarehouse> CustomerWarehouses { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerPricePickLevel> CustomerPricePickLevels { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Subsection> Subsections { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<InventoryCurrency> InventoryCurrencies { get; set; }

        //Tracker
        public DbSet<CompetatorStock> CompetatorStocks { get; set; }
        public DbSet<Merchandising> Merchandisings { get; set; }
        public DbSet<OrderTaking> OrderTakings { get; set; }
        public DbSet<OutletStock> OutletStocks { get; set; }
        public DbSet<StoreVisit> StoreVisits { get; set; }
        public DbSet<VisitDay> VisitDays { get; set; }

        //Sale
        public DbSet<SalesIndent> SalesIndents { get; set; }
        public DbSet<SalesIndentItem> SalesIndentItems { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }

        public DbSet<DeliveryOrder> DeliveryOrders { get; set; }
        public DbSet<DeliveryOrderItem> DeliveryOrderItems { get; set; }

        public DbSet<DeliveryChallan> DeliveryChallans { get; set; }

        public DbSet<SalesInvoice> SalesInvoices { get; set; }

        public DbSet<SalesReturn> SalesReturns { get; set; }
        public DbSet<SalesReturnItem> SalesReturnItems { get; set; }

        //SystemAdministration
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<RoleFeature> RoleFeatures { get; set; }
        public DbSet<RoleModule> RoleModules { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        //SystemAdministration/HRSetup
        public DbSet<Bank> Banks { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<GazettedHolidays> GazettedHolidays { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<ManagementLevel> ManagementLevels { get; set; }
        public DbSet<Relation> Relations { get; set; }
        public DbSet<Religion> Religions { get; set; }
        //public DbSet<Roster> Rosters { get; set; }
        //public DbSet<Shift> Shifts { get; set; }
        public DbSet<SkillLevel> SkillLevels { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<UserLanguage> UserLanguages { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }
        public DbSet<DependantsRelation> DependantsRelations { get; set; }

        //HR Leave
        public DbSet<LeaveApproval> LeaveApprovals { get; set; }
        public DbSet<LeaveClosing> LeaveClosings { get; set; }
        public DbSet<LeaveDayType> LeaveDayTypes { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        //public DbSet<LeaveDocument> LeaveDocuments { get; set; }
        public DbSet<LeaveEligibility> LeaveEligibilities { get; set; }
        public DbSet<LeaveOpening> LeaveOpenings { get; set; }
        public DbSet<LeaveOpeningDetail> LeaveOpeningDetails { get; set; }
        public DbSet<LeavePolicy> LeavePolicies { get; set; }
        public DbSet<LeavePolicyEmployee> LeavePolicyEmployees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveRequestDetail> LeaveRequestDetails { get; set; }
        public DbSet<LeaveYear> LeaveYears { get; set; }
        public DbSet<DecimalRoundingMatrix> DecimalRoundingMatrixs { get; set; }
        public DbSet<LeaveApprover> LeaveApprovers { get; set; }
        public DbSet<LeavePurpose> LeavePurposes { get; set; }
        public DbSet<LeaveSubType> LeaveSubTypes { get; set; }
        public DbSet<LeaveTypeBalance> LeaveTypeBalances { get; set; }
        public DbSet<ProrateMatrix> ProrateMatrixs { get; set; }

        //HR Attendance

        public DbSet<AttendanceFlagExemption> AttendanceFlagExemptions { get; set; }
        public DbSet<AttendanceRule> AttendanceRules { get; set; }
        public DbSet<AttendanceRuleLeaveType> AttendanceRuleLeaveTypes { get; set; }
        public DbSet<UserAttendanceFlagExemption> UserAttendanceFlagExemptions { get; set; }

        public DbSet<AssignRoster> AssignRosters { get; set; }
        public DbSet<AttendanceFlag> AttendanceFlag { get; set; }
        public DbSet<AttendanceRequestApprover> AttendanceRequestApprovers { get; set; }
        public DbSet<AttendanceRequestType> AttendanceRequestTypes { get; set; }
        public DbSet<FlagCategory> FlagCategories { get; set; }
        public DbSet<FlagEffectType> FlagEffectTypes { get; set; }
        public DbSet<FlagType> FlagTypes { get; set; }
        public DbSet<FlagValue> FlagValues { get; set; }
        public DbSet<Roster> Rosters { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftAttendanceFlag> ShiftAttendanceFlags { get; set; }
        public DbSet<UserRosterAttendanceAttendanceFlag> UserRosterAttendanceAttendanceFlags { get; set; }
        public DbSet<UserAssignRoster> UserAssignRosters { get; set; }

        public DbSet<OverTimeFlag> OverTimeFlags { get; set; }
        public DbSet<OverTimeType> OverTimeTypes { get; set; }
        public DbSet<EmployeeWorkingDayOt> EmployeeWorkingDayOts { get; set; }
        public DbSet<EmployeeOffDayOt> EmployeeOffDayOts { get; set; }
        public DbSet<EmployeeIncomingOt> EmployeeIncomingOts { get; set; }
        public DbSet<EmployeeOutgoingOt> EmployeeOutgoingOts { get; set; }

        public DbSet<AttendanceRequest> AttendanceRequests { get; set; }
        public DbSet<EmployeeOverTimeEntitlement> EmployeeOverTimeEntitlements { get; set; }
        public DbSet<OfficialVisitEntry> OfficialVisitEntries { get; set; }
        public DbSet<OverTimeEntitlement> OverTimeEntitlement { get; set; }
        public DbSet<UserRosterAttendance> UserRosterAttendances { get; set; }

        //HR Payroll
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<UserLoan> UserLoans { get; set; }
        public DbSet<UserLoanPayslip> UserLoanPayslips { get; set; }

        public DbSet<StopSalary> StopSalaries { get; set; }

        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<AllowanceArrear> AllowanceArrears { get; set; }
        public DbSet<AllowanceCalculationType> AllowanceCalculationTypes { get; set; }
        public DbSet<AllowanceDeduction> AllowanceDeductions { get; set; }
        public DbSet<AllowanceRate> AllowanceRates { get; set; }
        public DbSet<BankAdviceTemplate> BankAdviceTemplates { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<ChequeTemplate> ChequeTemplates { get; set; }
        public DbSet<CompensationTransaction> CompensationTransactions { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<FundSetup> FundSetups { get; set; }
        public DbSet<GratuitySlab> GratuitySlabs { get; set; }
        public DbSet<GratuitySlabGratuity> GratuitySlabGratuities { get; set; }
        public DbSet<GratuityType> GratuityTypes { get; set; }
        public DbSet<LeavingReason> LeavingReasons { get; set; }
        public DbSet<MasterPayroll> MasterPayrolls { get; set; }
        public DbSet<MasterPayrollDetails> MasterPayrollDetails { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<PayrollBank> PayrollBanks { get; set; }
        public DbSet<PayrollType> PayrollTypes { get; set; }
        public DbSet<PayrollYear> PayrollYears { get; set; }
        public DbSet<PfPayment> PfPayments { get; set; }
        public DbSet<SalaryCalculationType> SalaryCalculationTypesLeavingReasons { get; set; }
        public DbSet<SalaryStructure> SalaryStructures { get; set; }
        public DbSet<SalaryStructureDetail> SalaryStructureDetails { get; set; }
        public DbSet<UserSalary> UserSalaries { get; set; }

        public DbSet<IncomeTaxRule> IncomeTaxRules { get; set; }
        public DbSet<TaxableIncomeAdjustment> TaxableIncomeAdjustments { get; set; }
        public DbSet<TaxAdjustmentReason> TaxAdjustmentReasons { get; set; }
        public DbSet<TaxBenefit> TaxBenefits { get; set; }
        public DbSet<TaxRelief> TaxReliefs { get; set; }
        public DbSet<TaxSchedule> TaxSchedules { get; set; }
        public DbSet<TaxYear> TaxYears { get; set; }

        public DbSet<Gratuity> Gratuities { get; set; }
        public DbSet<MonthlyUserSalary> MonthlyUserSalaries { get; set; }

        public DbSet<PaySlip> PaySlips { get; set; }
        public DbSet<TaxAdjustment> TaxAdjustments { get; set; }

    }
}
