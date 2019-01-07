using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ReportingService.Reports.hims
{
  public partial class DailySemenAnalysisSheet : DevExpress.XtraReports.UI.XtraReport
  {
    public DailySemenAnalysisSheet()
    {
      InitializeComponent();
    }

    private void xrTableCell2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
    {

    }
  }
}
