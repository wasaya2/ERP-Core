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

namespace ReportingService
{
    public class ReportStorageWebExtension1 : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
    {
        public Dictionary<string, XtraReport> Reports = new Dictionary<string, XtraReport>();

        public ReportStorageWebExtension1()
        {
            Reports.Add("Products", new TOTAL_PATIENTS_REFFERENCE_SUMMARY());
            Reports.Add("EmployeeInformation", new EmployeeDetail());
            Reports.Add("EmployeeCard", new EmployeeCard());
            Reports.Add("ListofLeavers", new ListOfLeavers());
            Reports.Add("EmployeeList", new EmployeeList()); 
            Reports.Add("ListofJoiners", new ListOfJoiners());
            Reports.Add("LeaveDetail", new LeaveDetailReport());
            Reports.Add("In/OutDuration", new InOutDurationAttendance());
            Reports.Add("MissingEntries", new MissingEntries());
            Reports.Add("SalaryPayment", new SalaryPayment());
            Reports.Add("MonthlyLeave", new MonthlyLeaveSheet()); 
            Reports.Add("OverTime", new MonthlyOvertime()); 
            Reports.Add("GrossSalary", new GrossSalary()); 
            Reports.Add("LoanSummary", new LoanSummary()); 
            Reports.Add("LeaveBalance", new LeaveHistory());
            Reports.Add("SemenAnalysis", new SemenAnalysis());
            Reports.Add("BiochemistryOnTreatment", new Biochemistry());

            //////////HIMS////////////
            Reports.Add("RegisterationList", new RegisterationInformation());
            Reports.Add("AppointmenSheet", new AppointmenSheet());
            Reports.Add("NewPatientSheetFcKarachi", new NewPatientSheetFC());
            Reports.Add("DailyActivityReport", new DailyActivityReport1());
            Reports.Add("FcProcedureMovementSummary", new FcProcedureMovementSummary());
            Reports.Add("FcConsultationMovementSummary", new FC_CONSULTATION_MOVEMENT_SUMMARY());
            Reports.Add("SemenConsultationMovementSummary", new SEMEN_CONSULTATION_MOVEMENT_SUMMARY());
            Reports.Add("BloodConsultationMovementSummary", new BloodConsultationMovementSummary1());

    

            //////////HIMS////////////

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
