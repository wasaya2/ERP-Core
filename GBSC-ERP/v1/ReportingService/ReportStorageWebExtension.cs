using System.Collections.Generic;
using DevExpress.XtraReports.Web.Extensions;
using DevExpress.XtraReports.UI;
using ReportingService.Reports;
using System.IO;
using System.Linq;
using ReportingService.Reports.hims;

namespace ReportingService
{
    public class ReportStorageWebExtension1 : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
    {
        public Dictionary<string, XtraReport> Reports = new Dictionary<string, XtraReport>();

        public ReportStorageWebExtension1()
        {
            Reports.Add("Products", new TOTAL_PATIENTS_REFFERENCE_SUMMARY());
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