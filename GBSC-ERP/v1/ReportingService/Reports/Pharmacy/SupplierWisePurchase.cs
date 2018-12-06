using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ReportingService.Reports.Pharmacy
{
    public partial class SupplierWisePurchase : DevExpress.XtraReports.UI.XtraReport
    {
        public SupplierWisePurchase()
        {
            InitializeComponent();
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
