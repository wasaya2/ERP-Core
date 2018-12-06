namespace ReportingService.Reports.finance
{
    partial class Voucher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraReports.UI.DetailBand Detail;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Voucher));
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.label19 = new DevExpress.XtraReports.UI.XRLabel();
            this.label20 = new DevExpress.XtraReports.UI.XRLabel();
            this.label14 = new DevExpress.XtraReports.UI.XRLabel();
            this.label21 = new DevExpress.XtraReports.UI.XRLabel();
            this.line2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.table4 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell15 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell16 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell18 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell20 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.vendorLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.vendorLogo2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.vendorTable = new DevExpress.XtraReports.UI.XRTable();
            this.vendorTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorName = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorPhone = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorEmail = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorAddress = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorEmptyCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorWebsite = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.table3 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.table2 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.startDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.endDate = new DevExpress.XtraReports.Parameters.Parameter();
            Detail = new DevExpress.XtraReports.UI.DetailBand();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table1,
            this.label19,
            this.label20,
            this.label14,
            this.label21,
            this.line2,
            this.xrLine1,
            this.xrLabel1});
            Detail.Expanded = false;
            Detail.HeightF = 116.9259F;
            Detail.Name = "Detail";
            Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // table1
            // 
            this.table1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.table1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.table1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(0.0001907349F, 89.84251F);
            this.table1.Name = "table1";
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1});
            this.table1.SizeF = new System.Drawing.SizeF(797.9999F, 27.08334F);
            this.table1.StylePriority.UseBackColor = false;
            this.table1.StylePriority.UseBorders = false;
            this.table1.StylePriority.UseFont = false;
            this.table1.StylePriority.UseTextAlignment = false;
            this.table1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tableRow1
            // 
            this.tableRow1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell1,
            this.tableCell2,
            this.tableCell3,
            this.tableCell4,
            this.tableCell5,
            this.tableCell6,
            this.tableCell7});
            this.tableRow1.ForeColor = System.Drawing.Color.White;
            this.tableRow1.Name = "tableRow1";
            this.tableRow1.StylePriority.UseBackColor = false;
            this.tableRow1.StylePriority.UseForeColor = false;
            this.tableRow1.Weight = 1D;
            // 
            // tableCell1
            // 
            this.tableCell1.Multiline = true;
            this.tableCell1.Name = "tableCell1";
            this.tableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell1.Text = "Doc.Date";
            this.tableCell1.Weight = 1.6313015403048117D;
            // 
            // tableCell2
            // 
            this.tableCell2.Multiline = true;
            this.tableCell2.Name = "tableCell2";
            this.tableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell2.Text = "Voucher Type";
            this.tableCell2.Weight = 2.0777763053035376D;
            // 
            // tableCell3
            // 
            this.tableCell3.Multiline = true;
            this.tableCell3.Name = "tableCell3";
            this.tableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell3.Text = "Voucher #";
            this.tableCell3.Weight = 1.7771802332606668D;
            // 
            // tableCell4
            // 
            this.tableCell4.Multiline = true;
            this.tableCell4.Name = "tableCell4";
            this.tableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell4.StylePriority.UsePadding = false;
            this.tableCell4.Text = "Narration";
            this.tableCell4.Weight = 2.1433507365119335D;
            // 
            // tableCell5
            // 
            this.tableCell5.Multiline = true;
            this.tableCell5.Name = "tableCell5";
            this.tableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell5.StylePriority.UsePadding = false;
            this.tableCell5.Text = "Debit";
            this.tableCell5.Weight = 1.3844180094245584D;
            // 
            // tableCell6
            // 
            this.tableCell6.Multiline = true;
            this.tableCell6.Name = "tableCell6";
            this.tableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell6.StylePriority.UsePadding = false;
            this.tableCell6.Text = "Credit";
            this.tableCell6.Weight = 1.7020953115742787D;
            // 
            // tableCell7
            // 
            this.tableCell7.Multiline = true;
            this.tableCell7.Name = "tableCell7";
            this.tableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell7.StylePriority.UsePadding = false;
            this.tableCell7.Text = "Balance";
            this.tableCell7.Weight = 1.9219939677240017D;
            // 
            // label19
            // 
            this.label19.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.label19.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[endDate]")});
            this.label19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label19.LocationFloat = new DevExpress.Utils.PointFloat(426.3227F, 47.75915F);
            this.label19.Multiline = true;
            this.label19.Name = "label19";
            this.label19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label19.SizeF = new System.Drawing.SizeF(86.45837F, 23F);
            this.label19.StylePriority.UseBorders = false;
            this.label19.StylePriority.UseFont = false;
            this.label19.StylePriority.UseTextAlignment = false;
            this.label19.Text = "12/2/2018\r\n";
            this.label19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.label19.TextFormatString = "{0:dd-MMM-yy}";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label20.LocationFloat = new DevExpress.Utils.PointFloat(390.2084F, 47.75915F);
            this.label20.Multiline = true;
            this.label20.Name = "label20";
            this.label20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label20.SizeF = new System.Drawing.SizeF(36.1142F, 23F);
            this.label20.StylePriority.UseFont = false;
            this.label20.StylePriority.UseTextAlignment = false;
            this.label20.Text = "To";
            this.label20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label14.LocationFloat = new DevExpress.Utils.PointFloat(259.375F, 47.75915F);
            this.label14.Multiline = true;
            this.label14.Name = "label14";
            this.label14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label14.SizeF = new System.Drawing.SizeF(43.75003F, 23F);
            this.label14.StylePriority.UseFont = false;
            this.label14.StylePriority.UseTextAlignment = false;
            this.label14.Text = "From";
            this.label14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // label21
            // 
            this.label21.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.label21.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Parameters].[startDate]")});
            this.label21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label21.LocationFloat = new DevExpress.Utils.PointFloat(303.125F, 47.75915F);
            this.label21.Multiline = true;
            this.label21.Name = "label21";
            this.label21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label21.SizeF = new System.Drawing.SizeF(86.45837F, 23F);
            this.label21.StylePriority.UseBorders = false;
            this.label21.StylePriority.UseFont = false;
            this.label21.StylePriority.UseTextAlignment = false;
            this.label21.Text = "12/2/2017";
            this.label21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.label21.TextFormatString = "{0:dd-MMM-yy}";
            // 
            // line2
            // 
            this.line2.BorderWidth = 0F;
            this.line2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.line2.LineWidth = 2F;
            this.line2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 33.76923F);
            this.line2.Name = "line2";
            this.line2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.line2.SizeF = new System.Drawing.SizeF(797.9999F, 2.083332F);
            this.line2.StylePriority.UseBorderWidth = false;
            this.line2.StylePriority.UseForeColor = false;
            this.line2.StylePriority.UsePadding = false;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderWidth = 0F;
            this.xrLine1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.xrLine1.LineWidth = 2F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine1.SizeF = new System.Drawing.SizeF(797.9999F, 4.999987F);
            this.xrLine1.StylePriority.UseBorderWidth = false;
            this.xrLine1.StylePriority.UseForeColor = false;
            this.xrLine1.StylePriority.UsePadding = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.AutoWidth = true;
            this.xrLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(253.125F, 4.999987F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(279.4649F, 28.76924F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "ACCOMODATION EXPENSE";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // table4
            // 
            this.table4.BackColor = System.Drawing.Color.Transparent;
            this.table4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.table4.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
            this.table4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table4.Name = "table4";
            this.table4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow4});
            this.table4.SizeF = new System.Drawing.SizeF(797.9999F, 27.08333F);
            this.table4.StylePriority.UseBackColor = false;
            this.table4.StylePriority.UseBorders = false;
            this.table4.StylePriority.UseFont = false;
            this.table4.StylePriority.UseTextAlignment = false;
            this.table4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tableRow4
            // 
            this.tableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell14,
            this.tableCell15,
            this.tableCell16,
            this.tableCell17,
            this.tableCell18,
            this.tableCell19,
            this.tableCell20});
            this.tableRow4.Name = "tableRow4";
            this.tableRow4.Weight = 1D;
            // 
            // tableCell14
            // 
            this.tableCell14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[sp_Voucher].[Date]")});
            this.tableCell14.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.tableCell14.Multiline = true;
            this.tableCell14.Name = "tableCell14";
            this.tableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell14.StylePriority.UseFont = false;
            this.tableCell14.Text = "12/2/2017";
            this.tableCell14.TextFormatString = "{0:dd-MMM-yy}";
            this.tableCell14.Weight = 1.6313015403048117D;
            // 
            // tableCell15
            // 
            this.tableCell15.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[sp_Voucher].[VoucherTypeId]")});
            this.tableCell15.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.tableCell15.Multiline = true;
            this.tableCell15.Name = "tableCell15";
            this.tableCell15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell15.StylePriority.UseFont = false;
            this.tableCell15.Text = "Cash Voucher";
            this.tableCell15.Weight = 2.0777763053035376D;
            // 
            // tableCell16
            // 
            this.tableCell16.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[sp_Voucher].[VoucherId]")});
            this.tableCell16.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.tableCell16.Multiline = true;
            this.tableCell16.Name = "tableCell16";
            this.tableCell16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell16.StylePriority.UseFont = false;
            this.tableCell16.Text = "001";
            this.tableCell16.Weight = 1.7771802332606668D;
            // 
            // tableCell17
            // 
            this.tableCell17.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[sp_Voucher].[Description]")});
            this.tableCell17.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.tableCell17.Multiline = true;
            this.tableCell17.Name = "tableCell17";
            this.tableCell17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell17.StylePriority.UseFont = false;
            this.tableCell17.StylePriority.UsePadding = false;
            this.tableCell17.Text = "Narration";
            this.tableCell17.Weight = 2.1493306990513017D;
            // 
            // tableCell18
            // 
            this.tableCell18.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[sp_Voucher].[DebitAmount]")});
            this.tableCell18.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.tableCell18.Multiline = true;
            this.tableCell18.Name = "tableCell18";
            this.tableCell18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell18.StylePriority.UseFont = false;
            this.tableCell18.StylePriority.UsePadding = false;
            this.tableCell18.Text = "40\r\n";
            this.tableCell18.Weight = 1.3855031090415306D;
            // 
            // tableCell19
            // 
            this.tableCell19.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[sp_Voucher].[CreditAmount]")});
            this.tableCell19.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.tableCell19.Multiline = true;
            this.tableCell19.Name = "tableCell19";
            this.tableCell19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell19.StylePriority.UseFont = false;
            this.tableCell19.StylePriority.UsePadding = false;
            this.tableCell19.Text = "45";
            this.tableCell19.Weight = 1.6950302494179388D;
            // 
            // tableCell20
            // 
            this.tableCell20.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.tableCell20.Multiline = true;
            this.tableCell20.Name = "tableCell20";
            this.tableCell20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell20.StylePriority.UseFont = false;
            this.tableCell20.StylePriority.UsePadding = false;
            this.tableCell20.Text = "200";
            this.tableCell20.Weight = 1.9318990334712736D;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.vendorLogo});
            this.TopMargin.HeightF = 110F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // vendorLogo
            // 
            this.vendorLogo.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopLeft;
            this.vendorLogo.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("vendorLogo.ImageSource"));
            this.vendorLogo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.vendorLogo.Name = "vendorLogo";
            this.vendorLogo.SizeF = new System.Drawing.SizeF(200.9616F, 90.64423F);
            this.vendorLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            this.vendorLogo.StylePriority.UseBorderColor = false;
            this.vendorLogo.StylePriority.UseBorders = false;
            this.vendorLogo.StylePriority.UsePadding = false;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.vendorLogo2,
            this.vendorTable});
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // vendorLogo2
            // 
            this.vendorLogo2.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopLeft;
            this.vendorLogo2.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("vendorLogo2.ImageSource"));
            this.vendorLogo2.LocationFloat = new DevExpress.Utils.PointFloat(7.836518F, 9.999979F);
            this.vendorLogo2.Name = "vendorLogo2";
            this.vendorLogo2.SizeF = new System.Drawing.SizeF(105F, 50F);
            this.vendorLogo2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            this.vendorLogo2.StylePriority.UseBorderColor = false;
            this.vendorLogo2.StylePriority.UseBorders = false;
            this.vendorLogo2.StylePriority.UsePadding = false;
            // 
            // vendorTable
            // 
            this.vendorTable.BorderColor = System.Drawing.Color.Gray;
            this.vendorTable.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.vendorTable.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.vendorTable.LocationFloat = new DevExpress.Utils.PointFloat(135.6247F, 9.999979F);
            this.vendorTable.Name = "vendorTable";
            this.vendorTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(12, 0, 0, 0, 100F);
            this.vendorTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.vendorTableRow1,
            this.vendorTableRow2});
            this.vendorTable.SizeF = new System.Drawing.SizeF(623.5612F, 80F);
            this.vendorTable.StylePriority.UseBorderColor = false;
            this.vendorTable.StylePriority.UseBorders = false;
            this.vendorTable.StylePriority.UseFont = false;
            this.vendorTable.StylePriority.UsePadding = false;
            // 
            // vendorTableRow1
            // 
            this.vendorTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.vendorName,
            this.vendorPhone,
            this.vendorEmail});
            this.vendorTableRow1.Name = "vendorTableRow1";
            this.vendorTableRow1.Weight = 1.0000282429281655D;
            // 
            // vendorName
            // 
            this.vendorName.CanShrink = true;
            this.vendorName.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.vendorName.Name = "vendorName";
            this.vendorName.StylePriority.UseFont = false;
            this.vendorName.StylePriority.UseTextAlignment = false;
            this.vendorName.Text = "Address";
            this.vendorName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.vendorName.Weight = 3.2160869766043354D;
            // 
            // vendorPhone
            // 
            this.vendorPhone.CanShrink = true;
            this.vendorPhone.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.vendorPhone.Name = "vendorPhone";
            this.vendorPhone.StylePriority.UseFont = false;
            this.vendorPhone.StylePriority.UseTextAlignment = false;
            this.vendorPhone.Text = "Phone";
            this.vendorPhone.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.vendorPhone.Weight = 2.3857055240558696D;
            // 
            // vendorEmail
            // 
            this.vendorEmail.CanShrink = true;
            this.vendorEmail.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.vendorEmail.Name = "vendorEmail";
            this.vendorEmail.StylePriority.UseFont = false;
            this.vendorEmail.StylePriority.UseTextAlignment = false;
            this.vendorEmail.Text = "Fax";
            this.vendorEmail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            this.vendorEmail.Weight = 2.8008962503301023D;
            // 
            // vendorTableRow2
            // 
            this.vendorTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.vendorAddress,
            this.vendorEmptyCell,
            this.vendorWebsite});
            this.vendorTableRow2.Name = "vendorTableRow2";
            this.vendorTableRow2.Weight = 1.57413724941719D;
            // 
            // vendorAddress
            // 
            this.vendorAddress.CanShrink = true;
            this.vendorAddress.Multiline = true;
            this.vendorAddress.Name = "vendorAddress";
            this.vendorAddress.StylePriority.UseBorders = false;
            this.vendorAddress.StylePriority.UseTextAlignment = false;
            this.vendorAddress.Text = "F-6/1, Block-8, KDA Scheme No.5,\r\nClifton, Karachi-75600";
            this.vendorAddress.Weight = 3.2160869766043354D;
            // 
            // vendorEmptyCell
            // 
            this.vendorEmptyCell.CanShrink = true;
            this.vendorEmptyCell.Multiline = true;
            this.vendorEmptyCell.Name = "vendorEmptyCell";
            this.vendorEmptyCell.Text = "92 21 35361846\r\n          35361397 \r\n          35810049";
            this.vendorEmptyCell.Weight = 2.3857055240558696D;
            // 
            // vendorWebsite
            // 
            this.vendorWebsite.CanShrink = true;
            this.vendorWebsite.Name = "vendorWebsite";
            this.vendorWebsite.Text = "021-35361397";
            this.vendorWebsite.Weight = 2.8008962503301023D;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupFooter1});
            this.DetailReport.DataMember = "sp_Voucher";
            this.DetailReport.DataSource = this.sqlDataSource1;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table4});
            this.Detail1.HeightF = 38.33335F;
            this.Detail1.KeepTogether = true;
            this.Detail1.Name = "Detail1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table3,
            this.table2});
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // table3
            // 
            this.table3.LocationFloat = new DevExpress.Utils.PointFloat(346.9446F, 75.00002F);
            this.table3.Name = "table3";
            this.table3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow3});
            this.table3.SizeF = new System.Drawing.SizeF(329.7086F, 24.99999F);
            // 
            // tableRow3
            // 
            this.tableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell11,
            this.tableCell12,
            this.tableCell13});
            this.tableRow3.Name = "tableRow3";
            this.tableRow3.Weight = 1D;
            // 
            // tableCell11
            // 
            this.tableCell11.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.tableCell11.Multiline = true;
            this.tableCell11.Name = "tableCell11";
            this.tableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell11.StylePriority.UseFont = false;
            this.tableCell11.Text = "Total";
            this.tableCell11.Weight = 1.2794502478876837D;
            // 
            // tableCell12
            // 
            this.tableCell12.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tableCell12.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.tableCell12.Multiline = true;
            this.tableCell12.Name = "tableCell12";
            this.tableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell12.StylePriority.UseBackColor = false;
            this.tableCell12.StylePriority.UseBorders = false;
            this.tableCell12.StylePriority.UseFont = false;
            this.tableCell12.StylePriority.UseTextAlignment = false;
            this.tableCell12.Text = "70";
            this.tableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell12.Weight = 0.8247601206996662D;
            // 
            // tableCell13
            // 
            this.tableCell13.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.tableCell13.Multiline = true;
            this.tableCell13.Name = "tableCell13";
            this.tableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell13.StylePriority.UseBackColor = false;
            this.tableCell13.StylePriority.UseBorders = false;
            this.tableCell13.StylePriority.UseFont = false;
            this.tableCell13.StylePriority.UseTextAlignment = false;
            this.tableCell13.Text = "0";
            this.tableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell13.Weight = 1.0090148703794508D;
            // 
            // table2
            // 
            this.table2.LocationFloat = new DevExpress.Utils.PointFloat(346.4152F, 50.00006F);
            this.table2.Name = "table2";
            this.table2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow2});
            this.table2.SizeF = new System.Drawing.SizeF(330.2381F, 24.99999F);
            // 
            // tableRow2
            // 
            this.tableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell8,
            this.tableCell9,
            this.tableCell10});
            this.tableRow2.Name = "tableRow2";
            this.tableRow2.Weight = 1D;
            // 
            // tableCell8
            // 
            this.tableCell8.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.tableCell8.Multiline = true;
            this.tableCell8.Name = "tableCell8";
            this.tableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell8.StylePriority.UseFont = false;
            this.tableCell8.Text = "Opening Balance";
            this.tableCell8.Weight = 1.2844478389074192D;
            // 
            // tableCell9
            // 
            this.tableCell9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.tableCell9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.tableCell9.Multiline = true;
            this.tableCell9.Name = "tableCell9";
            this.tableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell9.StylePriority.UseBorders = false;
            this.tableCell9.StylePriority.UseFont = false;
            this.tableCell9.StylePriority.UseTextAlignment = false;
            this.tableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell9.Weight = 0.81976137704902685D;
            // 
            // tableCell10
            // 
            this.tableCell10.BackColor = System.Drawing.Color.Transparent;
            this.tableCell10.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.tableCell10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.tableCell10.Multiline = true;
            this.tableCell10.Name = "tableCell10";
            this.tableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell10.StylePriority.UseBackColor = false;
            this.tableCell10.StylePriority.UseBorders = false;
            this.tableCell10.StylePriority.UseFont = false;
            this.tableCell10.StylePriority.UseTextAlignment = false;
            this.tableCell10.Text = "0";
            this.tableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            this.tableCell10.Weight = 1.0140149832412269D;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "ERPDB_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "sp_Voucher";
            storedProcQuery1.StoredProcName = "sp_Voucher";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // startDate
            // 
            this.startDate.Description = "startDate";
            this.startDate.Name = "startDate";
            this.startDate.Type = typeof(System.DateTime);
            // 
            // endDate
            // 
            this.endDate.Description = "endDate";
            this.endDate.Name = "endDate";
            this.endDate.Type = typeof(System.DateTime);
            // 
            // Voucher
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            Detail,
            this.TopMargin,
            this.BottomMargin,
            this.DetailReport});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataMember = "sp_Voucher";
            this.DataSource = this.sqlDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(26, 26, 110, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.startDate,
            this.endDate});
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendorTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRPictureBox vendorLogo;
        private DevExpress.XtraReports.UI.XRPictureBox vendorLogo2;
        private DevExpress.XtraReports.UI.XRTable vendorTable;
        private DevExpress.XtraReports.UI.XRTableRow vendorTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell vendorName;
        private DevExpress.XtraReports.UI.XRTableCell vendorPhone;
        private DevExpress.XtraReports.UI.XRTableCell vendorEmail;
        private DevExpress.XtraReports.UI.XRTableRow vendorTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell vendorAddress;
        private DevExpress.XtraReports.UI.XRTableCell vendorEmptyCell;
        private DevExpress.XtraReports.UI.XRTableCell vendorWebsite;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell3;
        private DevExpress.XtraReports.UI.XRTableCell tableCell4;
        private DevExpress.XtraReports.UI.XRTableCell tableCell5;
        private DevExpress.XtraReports.UI.XRTableCell tableCell6;
        private DevExpress.XtraReports.UI.XRTableCell tableCell7;
        private DevExpress.XtraReports.UI.XRLabel label14;
        private DevExpress.XtraReports.UI.XRLabel label20;
        private DevExpress.XtraReports.UI.XRLabel label21;
        private DevExpress.XtraReports.UI.XRLabel label19;
        private DevExpress.XtraReports.UI.XRTable table4;
        private DevExpress.XtraReports.UI.XRTableRow tableRow4;
        private DevExpress.XtraReports.UI.XRTableCell tableCell14;
        private DevExpress.XtraReports.UI.XRTableCell tableCell15;
        private DevExpress.XtraReports.UI.XRTableCell tableCell16;
        private DevExpress.XtraReports.UI.XRTableCell tableCell17;
        private DevExpress.XtraReports.UI.XRTableCell tableCell18;
        private DevExpress.XtraReports.UI.XRTableCell tableCell19;
        private DevExpress.XtraReports.UI.XRTableCell tableCell20;
        private DevExpress.XtraReports.UI.XRLine line2;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.Parameters.Parameter startDate;
        private DevExpress.XtraReports.Parameters.Parameter endDate;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRTable table3;
        private DevExpress.XtraReports.UI.XRTableRow tableRow3;
        private DevExpress.XtraReports.UI.XRTableCell tableCell11;
        private DevExpress.XtraReports.UI.XRTableCell tableCell12;
        private DevExpress.XtraReports.UI.XRTableCell tableCell13;
        private DevExpress.XtraReports.UI.XRTable table2;
        private DevExpress.XtraReports.UI.XRTableRow tableRow2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell8;
        private DevExpress.XtraReports.UI.XRTableCell tableCell9;
        private DevExpress.XtraReports.UI.XRTableCell tableCell10;
    }
}
