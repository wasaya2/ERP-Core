using System.Collections.Generic;
using DevExpress.XtraReports.Web.Extensions;
using DevExpress.XtraReports.UI;
using ReportingService.Reports;
using System.IO;
using System.Linq;
using ReportingService.Reports.hims;
using ReportingService.Reports.hrms;
using ReportingService.Reports.Lab;
using ReportingService.Reports.Payroll;
using ReportingService.Reports.etracker;
using ReportingService.Reports.Inventory;
using ReportingService.Reports.UltraSound;

namespace ReportingService
{
    public class ReportStorageWebExtension1 : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
    {
        public Dictionary<string, XtraReport> Reports = new Dictionary<string, XtraReport>();

        public ReportStorageWebExtension1()
        {
            Reports.Add("EmployeeInformation", new EmployeeDetail());
            Reports.Add("EmployeeCard", new EmployeeCard());
            Reports.Add("ListofLeavers", new ListOfLeavers());
            Reports.Add("EmployeeList", new EmployeeList()); 
            Reports.Add("ListofJoiners", new ListOfJoiners());
            Reports.Add("LeaveDetail", new LeaveDetailReport());
            Reports.Add("LeaveLedger", new LeaveLedger1());
            Reports.Add("LeaveBalance", new LeaveHistory());
            Reports.Add("InOutDuration", new InOutDurationAttendance());
            Reports.Add("MissingEntries", new MissingEntries());
            Reports.Add("dailyattendanceandleave", new dailyattendanceandleave());
            Reports.Add("DepartmentWiseAttendance", new DepartmentWiseAttendance());
            Reports.Add("DailyAttendance", new DailyAttendance());
            Reports.Add("SalaryPayment", new SalaryPayment());
            Reports.Add("MonthlyLeave", new MonthlyLeaveSheet()); 
            Reports.Add("OverTime", new MonthlyOvertime()); 
            Reports.Add("GrossSalary", new GrossSalary()); 
            Reports.Add("LoanSummary", new LoanSummary()); 
            Reports.Add("SemenAnalysis", new SemenAnalysis());
            Reports.Add("AssignRosterExcelSheet", new assignRosterExcelSheet());

            //////////HIMS////////////
            Reports.Add("RegisterationList", new RegisterationInformation());
            Reports.Add("AppointmenSheet", new AppointmenSheet());
            Reports.Add("DailyActivityReport", new DailyActivityReport1());

            Reports.Add("FcProcedureMovementSummary", new FcProcedureMovementSummary());
            Reports.Add("BloodConsultationMovementSummary", new BloodConsultationMovementSummary1());
            Reports.Add("SemenConsultationMovementSummary", new SEMEN_CONSULTATION_MOVEMENT_SUMMARY());

            Reports.Add("FcConsultationMovementSummary", new FC_CONSULTATION_MOVEMENT_SUMMARY());
            Reports.Add("NewPatientSheetSemenKarachi", new NEW_PATIENT_SHEET___SEMEN___KARACHI_());
            Reports.Add("NewPatientSheetBloodKarachi", new NewPatientSheetBloodKarachi());

            Reports.Add("NewPatientSheetFcKarachi", new NewPatientSheetFC());
            Reports.Add("TotalPatientsReferenceSummary", new TOTAL_PATIENTS_REFFERENCE_SUMMARY());
            Reports.Add("SemenPatientReferenceSummary", new SEMEN_PATIENTS_REFERENCE_SUMMARY());

            Reports.Add("BloodTestReferenceSummary", new XtraReport1());
            Reports.Add("FcPatientReferenceSummary", new FCPatientReferenceSummary());
            Reports.Add("NewFcClinicPatientsSummary", new NEW__FC___CLINIC___PATIENTS_SUMMARY());
             Reports.Add("DailySemenAnalysisSheet", new DailySemenAnalysisSheet());  
            Reports.Add("SubsequentSemenFreezingList", new SubsequentSemenFreezingList());
            Reports.Add("MedicineDetails", new MEDICINE_DETAILS());
            Reports.Add("ConsultantActivtityDetails", new ConsultantActivtityDetails());
            //////////HIMS////////////
            ///////////uLTRA SOUND//////////////
            Reports.Add("ultraSoundPelvisReport", new ultraSoundPelvisReport());
            ///////////ULTRA SOUND//////////////
            ///

      #region Lab Reports

      Reports.Add("SemenAnalysisOutsider", new AnalysisWorkSheet_Outsiders());
            Reports.Add("BiochemistryDetailsOntreatment", new Bio_ChemistryDetails_OnTreatment());
            Reports.Add("BiochemistryOutsider", new Biochemistry_Outsider());
            Reports.Add("BiochemistryOntreatment", new Biochemistry());
            Reports.Add("LabSummary", new LabSummary());
            Reports.Add("Biopsy", new PESA_TESE());

            #endregion

            #region etracker reports
            Reports.Add("ShopCensusSummary", new ShopCensusSummary());
            Reports.Add("ShopCensusDetail", new ShopCensusDetail());
            Reports.Add("ShopStatusDetail", new ShopStatusDetail());
            Reports.Add("VisitSummary", new VisitSummaryReport());
            Reports.Add("ShopStatusSummary", new ShopStatusSummary());
            Reports.Add("VisitDetail", new VisitDetailReport());

            #endregion

            #region Inventory
            Reports.Add("OrderDetail", new OrderDetail());
            Reports.Add("OrderSummary", new OrderSummary());
            #endregion

        }

        public override bool CanSetData(string url)
        {
            return true;
        }

        public override byte[] GetData(string url)
        {
            var report = Reports[url];
            using (MemoryStream stream = new MemoryStream())
            {
                report.SaveLayoutToXml(stream);
                return stream.ToArray();
            }
        }

        public override Dictionary<string, string> GetUrls()
        {
            return Reports.ToDictionary(x => x.Key, y => y.Key);
        }

        public override void SetData(XtraReport report, string url)
        {
            if (Reports.ContainsKey(url))
            {
                Reports[url] = report;
            }
            else
            {
                Reports.Add(url, report);
            }
        }

        public override string SetNewData(XtraReport report, string defaultUrl)
        {
            SetData(report, defaultUrl);
            return defaultUrl;
        }

        public override bool IsValidUrl(string url)
        {
            return true;
        }
    }
}
