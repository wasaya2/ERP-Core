﻿namespace ReportingService.Reports.hrms
{
    partial class ListOfJoiners
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListOfJoiners));
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
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
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell11 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell14 = new DevExpress.XtraReports.UI.XRTableCell();
            this.startdate = new DevExpress.XtraReports.Parameters.Parameter();
            this.endDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.Nullparam = new DevExpress.XtraReports.Parameters.Parameter();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.label16 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.label17 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.line2 = new DevExpress.XtraReports.UI.XRLine();
            ((System.ComponentModel.ISupportInitialize)(this.vendorTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.label16,
            this.xrLabel3,
            this.label17,
            this.vendorLogo});
            this.TopMargin.HeightF = 110.4867F;
            this.TopMargin.Name = "TopMargin";
            // 
            // vendorLogo
            // 
            this.vendorLogo.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopLeft;
            this.vendorLogo.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("vendorLogo.ImageSource"));
            this.vendorLogo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
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
            this.BottomMargin.HeightF = 99.44855F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // vendorLogo2
            // 
            this.vendorLogo2.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.TopLeft;
            this.vendorLogo2.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("vendorLogo2.ImageSource"));
            this.vendorLogo2.LocationFloat = new DevExpress.Utils.PointFloat(7.836533F, 9.999974F);
            this.vendorLogo2.Name = "vendorLogo2";
            this.vendorLogo2.SizeF = new System.Drawing.SizeF(125.8333F, 62.5F);
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
            this.vendorTable.LocationFloat = new DevExpress.Utils.PointFloat(211.9387F, 9.999974F);
            this.vendorTable.Name = "vendorTable";
            this.vendorTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(12, 0, 0, 0, 100F);
            this.vendorTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.vendorTableRow1,
            this.vendorTableRow2});
            this.vendorTable.SizeF = new System.Drawing.SizeF(636.0612F, 80F);
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
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLine1,
            this.xrLabel1,
            this.line2,
            this.xrTable1});
            this.GroupHeader1.HeightF = 80.61968F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrTable1
            // 
            this.xrTable1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.xrTable1.ForeColor = System.Drawing.Color.White;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 56.66135F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(848F, 23.95833F);
            this.xrTable1.StylePriority.UseBackColor = false;
            this.xrTable1.StylePriority.UseForeColor = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrTableRow1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell8,
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell4,
            this.xrTableCell5,
            this.xrTableCell6,
            this.xrTableCell7});
            this.xrTableRow1.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow1.ForeColor = System.Drawing.Color.Black;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseBackColor = false;
            this.xrTableRow1.StylePriority.UseBorders = false;
            this.xrTableRow1.StylePriority.UseFont = false;
            this.xrTableRow1.StylePriority.UseForeColor = false;
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.Multiline = true;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            this.xrTableCell1.Text = "Employee ID";
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell1.Weight = 1.6676273162909385D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.Text = "Employee Name";
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell2.Weight = 2.1368726906958351D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell4.StylePriority.UsePadding = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.Text = "City";
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell4.Weight = 1.4952680297921512D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.Multiline = true;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell5.StylePriority.UsePadding = false;
            this.xrTableCell5.StylePriority.UseTextAlignment = false;
            this.xrTableCell5.Text = "Designation";
            this.xrTableCell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell5.Weight = 2.1510085450108289D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.Text = "Appointment Date";
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell6.Weight = 2.031850689524016D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Confirmation Date";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell7.Weight = 2.0255225175885521D;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
            this.DetailReport.DataMember = "sp_ListofJoiners";
            this.DetailReport.DataSource = this.sqlDataSource1;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.Detail1.HeightF = 25.24357F;
            this.Detail1.Name = "Detail1";
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "ERPDB_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "sp_ListofJoiners";
            queryParameter1.Name = "@startdate";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("?startdate", typeof(System.DateTime));
            queryParameter2.Name = "@endDate";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("?endDate", typeof(System.DateTime));
            queryParameter3.Name = "@companyid";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("?Nullparam", typeof(long));
            queryParameter4.Name = "@countryid";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("?Nullparam", typeof(long));
            queryParameter5.Name = "@branchid";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("?Nullparam", typeof(long));
            queryParameter6.Name = "@cityid";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("?Nullparam", typeof(long));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.Parameters.Add(queryParameter6);
            storedProcQuery1.StoredProcName = "sp_ListofJoiners";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.Text = "S.No";
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrTableCell8.Weight = 1.0846135627326059D;
            // 
            // xrTable2
            // 
            this.xrTable2.BackColor = System.Drawing.Color.Transparent;
            this.xrTable2.ForeColor = System.Drawing.Color.White;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(848F, 23.95833F);
            this.xrTable2.StylePriority.UseBackColor = false;
            this.xrTable2.StylePriority.UseForeColor = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.xrTableRow2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell3,
            this.xrTableCell9,
            this.xrTableCell10,
            this.xrTableCell11,
            this.xrTableCell12,
            this.xrTableCell13,
            this.xrTableCell14});
            this.xrTableRow2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableRow2.ForeColor = System.Drawing.Color.Black;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.StylePriority.UseBackColor = false;
            this.xrTableRow2.StylePriority.UseBorders = false;
            this.xrTableRow2.StylePriority.UseFont = false;
            this.xrTableRow2.StylePriority.UseForeColor = false;
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SNo]")});
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell3.StylePriority.UseBackColor = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.Text = "S.No";
            this.xrTableCell3.Weight = 1.0846135627326059D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell9.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EmployeeID]")});
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell9.StylePriority.UseBackColor = false;
            this.xrTableCell9.Text = "Employee ID";
            this.xrTableCell9.Weight = 1.6676273162909385D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Employee]")});
            this.xrTableCell10.Multiline = true;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell10.StylePriority.UseBackColor = false;
            this.xrTableCell10.Text = "Employee Name";
            this.xrTableCell10.Weight = 2.1368726906958351D;
            // 
            // xrTableCell11
            // 
            this.xrTableCell11.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell11.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[City]")});
            this.xrTableCell11.Multiline = true;
            this.xrTableCell11.Name = "xrTableCell11";
            this.xrTableCell11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell11.StylePriority.UseBackColor = false;
            this.xrTableCell11.StylePriority.UsePadding = false;
            this.xrTableCell11.Text = "City";
            this.xrTableCell11.Weight = 1.4952680297921512D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[EmployeeDesignation]")});
            this.xrTableCell12.Multiline = true;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell12.StylePriority.UseBackColor = false;
            this.xrTableCell12.StylePriority.UsePadding = false;
            this.xrTableCell12.Text = "Designation";
            this.xrTableCell12.Weight = 2.1510085450108289D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AppointmentDate]")});
            this.xrTableCell13.Multiline = true;
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell13.StylePriority.UseBackColor = false;
            this.xrTableCell13.StylePriority.UsePadding = false;
            this.xrTableCell13.Text = "Appointment Date";
            this.xrTableCell13.TextFormatString = "{0:dd-MMM-yy}";
            this.xrTableCell13.Weight = 2.031850689524016D;
            // 
            // xrTableCell14
            // 
            this.xrTableCell14.BackColor = System.Drawing.Color.Transparent;
            this.xrTableCell14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[ConfirmationDate]")});
            this.xrTableCell14.Multiline = true;
            this.xrTableCell14.Name = "xrTableCell14";
            this.xrTableCell14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell14.StylePriority.UseBackColor = false;
            this.xrTableCell14.StylePriority.UsePadding = false;
            this.xrTableCell14.Text = "Confirmation Date";
            this.xrTableCell14.TextFormatString = "{0:dd-MMM-yy}";
            this.xrTableCell14.Weight = 2.0255225175885521D;
            // 
            // startdate
            // 
            this.startdate.Description = "startdate";
            this.startdate.Name = "startdate";
            this.startdate.Type = typeof(System.DateTime);
            this.startdate.ValueInfo = "2018-01-01";
            // 
            // endDate
            // 
            this.endDate.Description = "endDate";
            this.endDate.Name = "endDate";
            this.endDate.Type = typeof(System.DateTime);
            this.endDate.ValueInfo = "2018-12-01";
            // 
            // Nullparam
            // 
            this.Nullparam.AllowNull = true;
            this.Nullparam.Description = "Nullparam";
            this.Nullparam.Name = "Nullparam";
            this.Nullparam.Type = typeof(long);
            this.Nullparam.Visible = false;
            // 
            // xrLabel2
            // 
            this.xrLabel2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?startdate")});
            this.xrLabel2.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(742.1666F, 47.91667F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(95.83337F, 15.625F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.xrLabel2.TextFormatString = "{0:dd-MMM-yy}";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label16.LocationFloat = new DevExpress.Utils.PointFloat(689.0947F, 65.97166F);
            this.label16.Multiline = true;
            this.label16.Name = "label16";
            this.label16.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 3, 0, 100F);
            this.label16.SizeF = new System.Drawing.SizeF(53.07196F, 18.055F);
            this.label16.StylePriority.UseFont = false;
            this.label16.StylePriority.UsePadding = false;
            this.label16.StylePriority.UseTextAlignment = false;
            this.label16.Text = "To";
            this.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(689.0946F, 47.91667F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 3, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(53.07196F, 18.055F);
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UsePadding = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "From";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // label17
            // 
            this.label17.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?endDate")});
            this.label17.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label17.LocationFloat = new DevExpress.Utils.PointFloat(742.1666F, 65.97166F);
            this.label17.Multiline = true;
            this.label17.Name = "label17";
            this.label17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label17.SizeF = new System.Drawing.SizeF(95.83337F, 15.625F);
            this.label17.StylePriority.UseFont = false;
            this.label17.StylePriority.UseTextAlignment = false;
            this.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.label17.TextFormatString = "{0:dd-MMM-yy}";
            // 
            // xrLine1
            // 
            this.xrLine1.BorderWidth = 0F;
            this.xrLine1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.xrLine1.LineWidth = 2F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine1.SizeF = new System.Drawing.SizeF(847.9999F, 4.999992F);
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
            this.xrLabel1.SizeF = new System.Drawing.SizeF(308.0479F, 33.80085F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "List of Joiners";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // line2
            // 
            this.line2.BorderWidth = 0F;
            this.line2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.line2.LineWidth = 2F;
            this.line2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 38.80081F);
            this.line2.Name = "line2";
            this.line2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.line2.SizeF = new System.Drawing.SizeF(847.9999F, 4.999985F);
            this.line2.StylePriority.UseBorderWidth = false;
            this.line2.StylePriority.UseForeColor = false;
            this.line2.StylePriority.UsePadding = false;
            // 
            // ListOfJoiners
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.GroupHeader1,
            this.DetailReport});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
            this.DataSource = this.sqlDataSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(0, 2, 110, 99);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.startdate,
            this.endDate,
            this.Nullparam});
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this.vendorTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
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
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell11;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell13;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell14;
        private DevExpress.XtraReports.Parameters.Parameter startdate;
        private DevExpress.XtraReports.Parameters.Parameter endDate;
        private DevExpress.XtraReports.Parameters.Parameter Nullparam;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel label16;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel label17;
        private DevExpress.XtraReports.UI.XRLine xrLine1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLine line2;
    }
}
