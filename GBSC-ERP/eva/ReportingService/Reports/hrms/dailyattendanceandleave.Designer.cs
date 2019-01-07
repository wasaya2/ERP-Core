namespace ReportingService.Reports.hrms
{
  partial class dailyattendanceandleave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dailyattendanceandleave));
            DevExpress.DataAccess.Sql.StoredProcQuery storedProcQuery1 = new DevExpress.DataAccess.Sql.StoredProcQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter2 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter3 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter4 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter5 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter6 = new DevExpress.DataAccess.Sql.QueryParameter();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter7 = new DevExpress.DataAccess.Sql.QueryParameter();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.vendorTable = new DevExpress.XtraReports.UI.XRTable();
            this.vendorTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorName = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorPhone = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorEmail = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.vendorAddress = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorEmptyCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorWebsite = new DevExpress.XtraReports.UI.XRTableCell();
            this.vendorLogo2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.label18 = new DevExpress.XtraReports.UI.XRLabel();
            this.label17 = new DevExpress.XtraReports.UI.XRLabel();
            this.label16 = new DevExpress.XtraReports.UI.XRLabel();
            this.vendorLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.line2 = new DevExpress.XtraReports.UI.XRLine();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLine1 = new DevExpress.XtraReports.UI.XRLine();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell51 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.userId = new DevExpress.XtraReports.Parameters.Parameter();
            this.startDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.endDate = new DevExpress.XtraReports.Parameters.Parameter();
            this.nullparam = new DevExpress.XtraReports.Parameters.Parameter();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.vendorTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.line2,
            this.xrLabel1,
            this.xrLine1,
            this.label18,
            this.label17,
            this.label16,
            this.vendorLogo});
            this.TopMargin.HeightF = 148.9583F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.vendorTable,
            this.vendorLogo2});
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // vendorTable
            // 
            this.vendorTable.BorderColor = System.Drawing.Color.Gray;
            this.vendorTable.Borders = DevExpress.XtraPrinting.BorderSide.Left;
            this.vendorTable.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.vendorTable.LocationFloat = new DevExpress.Utils.PointFloat(177.4388F, 9.999974F);
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
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Calibri", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label18.LocationFloat = new DevExpress.Utils.PointFloat(222.4359F, 10.00001F);
            this.label18.Multiline = true;
            this.label18.Name = "label18";
            this.label18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label18.SizeF = new System.Drawing.SizeF(290.0758F, 36.10999F);
            this.label18.StylePriority.UseFont = false;
            this.label18.Text = "Global Blue Sky Consulting";
            // 
            // label17
            // 
            this.label17.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[sp_dailyattendanceandleave].[AttendanceDate]")});
            this.label17.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label17.LocationFloat = new DevExpress.Utils.PointFloat(691.8752F, 80.15925F);
            this.label17.Multiline = true;
            this.label17.Name = "label17";
            this.label17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.label17.SizeF = new System.Drawing.SizeF(100.2081F, 20.48499F);
            this.label17.StylePriority.UseFont = false;
            this.label17.StylePriority.UseTextAlignment = false;
            this.label17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.label17.TextFormatString = "{0:dd/MM/yyyy}";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label16.LocationFloat = new DevExpress.Utils.PointFloat(608.5949F, 80.15925F);
            this.label16.Multiline = true;
            this.label16.Name = "label16";
            this.label16.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 3, 0, 100F);
            this.label16.SizeF = new System.Drawing.SizeF(83.28027F, 18.055F);
            this.label16.StylePriority.UseFont = false;
            this.label16.StylePriority.UsePadding = false;
            this.label16.StylePriority.UseTextAlignment = false;
            this.label16.Text = "Date";
            this.label16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
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
            // line2
            // 
            this.line2.BorderWidth = 0F;
            this.line2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.line2.LineWidth = 2F;
            this.line2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 110.0507F);
            this.line2.Name = "line2";
            this.line2.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.line2.SizeF = new System.Drawing.SizeF(811F, 4.999985F);
            this.line2.StylePriority.UseBorderWidth = false;
            this.line2.StylePriority.UseForeColor = false;
            this.line2.StylePriority.UsePadding = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.AutoWidth = true;
            this.xrLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(258.3333F, 115.0507F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(293.3703F, 28.76923F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Dailyndanceandleave";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLine1
            // 
            this.xrLine1.BorderWidth = 0F;
            this.xrLine1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.xrLine1.LineWidth = 2F;
            this.xrLine1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 143.9583F);
            this.xrLine1.Name = "xrLine1";
            this.xrLine1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrLine1.SizeF = new System.Drawing.SizeF(811.0001F, 4.999985F);
            this.xrLine1.StylePriority.UseBorderWidth = false;
            this.xrLine1.StylePriority.UseForeColor = false;
            this.xrLine1.StylePriority.UsePadding = false;
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table1});
            this.GroupHeader1.HeightF = 26.04167F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // table1
            // 
            this.table1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.table1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.table1.Name = "table1";
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1});
            this.table1.SizeF = new System.Drawing.SizeF(811F, 25.99999F);
            this.table1.StylePriority.UseBorders = false;
            this.table1.StylePriority.UseFont = false;
            this.table1.StylePriority.UseTextAlignment = false;
            this.table1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // tableRow1
            // 
            this.tableRow1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell2,
            this.tableCell51,
            this.tableCell32,
            this.xrTableCell7,
            this.xrTableCell9});
            this.tableRow1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.tableRow1.ForeColor = System.Drawing.Color.Black;
            this.tableRow1.Name = "tableRow1";
            this.tableRow1.StylePriority.UseBackColor = false;
            this.tableRow1.StylePriority.UseFont = false;
            this.tableRow1.StylePriority.UseForeColor = false;
            this.tableRow1.StylePriority.UseTextAlignment = false;
            this.tableRow1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableRow1.Weight = 1D;
            // 
            // tableCell2
            // 
            this.tableCell2.Multiline = true;
            this.tableCell2.Name = "tableCell2";
            this.tableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 0, 0, 100F);
            this.tableCell2.StylePriority.UsePadding = false;
            this.tableCell2.StylePriority.UseTextAlignment = false;
            this.tableCell2.Text = "S . No";
            this.tableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell2.Weight = 1.2894061132651176D;
            // 
            // tableCell51
            // 
            this.tableCell51.Multiline = true;
            this.tableCell51.Name = "tableCell51";
            this.tableCell51.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell51.StylePriority.UsePadding = false;
            this.tableCell51.StylePriority.UseTextAlignment = false;
            this.tableCell51.Text = "Employee";
            this.tableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell51.Weight = 2.2212609635064551D;
            // 
            // tableCell32
            // 
            this.tableCell32.Multiline = true;
            this.tableCell32.Name = "tableCell32";
            this.tableCell32.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.tableCell32.StylePriority.UsePadding = false;
            this.tableCell32.StylePriority.UseTextAlignment = false;
            this.tableCell32.Text = "Attendance Date";
            this.tableCell32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.tableCell32.Weight = 2.3260445853673484D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.Multiline = true;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell7.StylePriority.UsePadding = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "In Time";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell7.Weight = 1.4978494417757968D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.Multiline = true;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell9.StylePriority.UsePadding = false;
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            this.xrTableCell9.Text = "Out Time";
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell9.Weight = 1.9097943138316018D;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
            this.DetailReport.DataMember = "sp_dailyattendanceandleave";
            this.DetailReport.DataSource = this.sqlDataSource1;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.Detail1.HeightF = 26.04167F;
            this.Detail1.Name = "Detail1";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(811.0001F, 25.99999F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.BackColor = System.Drawing.Color.Transparent;
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell6,
            this.xrTableCell8});
            this.xrTableRow1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold);
            this.xrTableRow1.ForeColor = System.Drawing.Color.Black;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.StylePriority.UseBackColor = false;
            this.xrTableRow1.StylePriority.UseFont = false;
            this.xrTableRow1.StylePriority.UseForeColor = false;
            this.xrTableRow1.StylePriority.UseTextAlignment = false;
            this.xrTableRow1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[SNo]")});
            this.xrTableCell2.Font = new System.Drawing.Font("Calibri", 10F);
            this.xrTableCell2.Multiline = true;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Padding = new DevExpress.XtraPrinting.PaddingInfo(4, 2, 0, 0, 100F);
            this.xrTableCell2.StylePriority.UseFont = false;
            this.xrTableCell2.StylePriority.UsePadding = false;
            this.xrTableCell2.StylePriority.UseTextAlignment = false;
            this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell2.Weight = 1.2894062876304642D;
            // 
            // xrTableCell3
            // 
            this.xrTableCell3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Employee]")});
            this.xrTableCell3.Font = new System.Drawing.Font("Calibri", 10F);
            this.xrTableCell3.Multiline = true;
            this.xrTableCell3.Name = "xrTableCell3";
            this.xrTableCell3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell3.StylePriority.UseFont = false;
            this.xrTableCell3.StylePriority.UsePadding = false;
            this.xrTableCell3.StylePriority.UseTextAlignment = false;
            this.xrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell3.Weight = 2.2212604404104166D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[AttendanceDate]")});
            this.xrTableCell4.Font = new System.Drawing.Font("Calibri", 10F);
            this.xrTableCell4.Multiline = true;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UsePadding = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            this.xrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell4.Weight = 2.3260448905067048D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CheckInTime]")});
            this.xrTableCell6.Font = new System.Drawing.Font("Calibri", 10F);
            this.xrTableCell6.Multiline = true;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell6.StylePriority.UseFont = false;
            this.xrTableCell6.StylePriority.UsePadding = false;
            this.xrTableCell6.StylePriority.UseTextAlignment = false;
            this.xrTableCell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell6.TextFormatString = "{0:h:mm:ss tt}";
            this.xrTableCell6.Weight = 1.5161851046495949D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[CheckOutTime]")});
            this.xrTableCell8.Font = new System.Drawing.Font("Calibri", 10F);
            this.xrTableCell8.Multiline = true;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrTableCell8.StylePriority.UseFont = false;
            this.xrTableCell8.StylePriority.UsePadding = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell8.TextFormatString = "{0:h:mm:ss tt}";
            this.xrTableCell8.Weight = 1.9145694639990853D;
            // 
            // userId
            // 
            this.userId.Description = "userId";
            this.userId.Name = "userId";
            this.userId.Type = typeof(int);
            this.userId.ValueInfo = "0";
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
            this.endDate.ValueInfo = "2019-01-01";
            // 
            // nullparam
            // 
            this.nullparam.AllowNull = true;
            this.nullparam.Description = "nullparam";
            this.nullparam.Name = "nullparam";
            this.nullparam.Type = typeof(int);
            this.nullparam.Visible = false;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "ERPDB_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            storedProcQuery1.Name = "sp_dailyattendanceandleave";
            queryParameter1.Name = "@userId";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("?userId", typeof(int));
            queryParameter2.Name = "@startDate";
            queryParameter2.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter2.Value = new DevExpress.DataAccess.Expression("?startDate", typeof(string));
            queryParameter3.Name = "@endDate";
            queryParameter3.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter3.Value = new DevExpress.DataAccess.Expression("?endDate", typeof(string));
            queryParameter4.Name = "@companyid";
            queryParameter4.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter4.Value = new DevExpress.DataAccess.Expression("?nullparam", typeof(long));
            queryParameter5.Name = "@countryid";
            queryParameter5.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter5.Value = new DevExpress.DataAccess.Expression("?nullparam", typeof(long));
            queryParameter6.Name = "@branchid";
            queryParameter6.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter6.Value = new DevExpress.DataAccess.Expression("?nullparam", typeof(long));
            queryParameter7.Name = "@cityid";
            queryParameter7.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter7.Value = new DevExpress.DataAccess.Expression("?nullparam", typeof(long));
            storedProcQuery1.Parameters.Add(queryParameter1);
            storedProcQuery1.Parameters.Add(queryParameter2);
            storedProcQuery1.Parameters.Add(queryParameter3);
            storedProcQuery1.Parameters.Add(queryParameter4);
            storedProcQuery1.Parameters.Add(queryParameter5);
            storedProcQuery1.Parameters.Add(queryParameter6);
            storedProcQuery1.Parameters.Add(queryParameter7);
            storedProcQuery1.StoredProcName = "sp_dailyattendanceandleave";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            storedProcQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // dailyattendanceandleave
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
            this.Margins = new System.Drawing.Printing.Margins(17, 22, 149, 100);
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.userId,
            this.startDate,
            this.endDate,
            this.nullparam});
            this.Version = "18.2";
            ((System.ComponentModel.ISupportInitialize)(this.vendorTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

    }

    #endregion

    private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
    private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    private DevExpress.XtraReports.UI.DetailBand Detail;
    private DevExpress.XtraReports.UI.XRTable vendorTable;
    private DevExpress.XtraReports.UI.XRTableRow vendorTableRow1;
    private DevExpress.XtraReports.UI.XRTableCell vendorName;
    private DevExpress.XtraReports.UI.XRTableCell vendorPhone;
    private DevExpress.XtraReports.UI.XRTableCell vendorEmail;
    private DevExpress.XtraReports.UI.XRTableRow vendorTableRow2;
    private DevExpress.XtraReports.UI.XRTableCell vendorAddress;
    private DevExpress.XtraReports.UI.XRTableCell vendorEmptyCell;
    private DevExpress.XtraReports.UI.XRTableCell vendorWebsite;
    private DevExpress.XtraReports.UI.XRPictureBox vendorLogo2;
    private DevExpress.XtraReports.UI.XRLabel label18;
    private DevExpress.XtraReports.UI.XRLabel label17;
    private DevExpress.XtraReports.UI.XRLabel label16;
    private DevExpress.XtraReports.UI.XRPictureBox vendorLogo;
    private DevExpress.XtraReports.UI.XRLine line2;
    private DevExpress.XtraReports.UI.XRLabel xrLabel1;
    private DevExpress.XtraReports.UI.XRLine xrLine1;
    private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
    private DevExpress.XtraReports.UI.XRTable table1;
    private DevExpress.XtraReports.UI.XRTableRow tableRow1;
    private DevExpress.XtraReports.UI.XRTableCell tableCell2;
    private DevExpress.XtraReports.UI.XRTableCell tableCell51;
    private DevExpress.XtraReports.UI.XRTableCell tableCell32;
    private DevExpress.XtraReports.UI.XRTableCell xrTableCell7;
    private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
    private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
    private DevExpress.XtraReports.UI.DetailBand Detail1;
    private DevExpress.XtraReports.UI.XRTable xrTable1;
    private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
    private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
    private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
    private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
    private DevExpress.XtraReports.UI.XRTableCell xrTableCell6;
    private DevExpress.XtraReports.UI.XRTableCell xrTableCell8;
    private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
    private DevExpress.XtraReports.Parameters.Parameter userId;
    private DevExpress.XtraReports.Parameters.Parameter startDate;
    private DevExpress.XtraReports.Parameters.Parameter endDate;
    private DevExpress.XtraReports.Parameters.Parameter nullparam;
  }
}
