namespace QLGDNganHang
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnRegister = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomers = new DevExpress.XtraBars.BarButtonItem();
            this.btnTransfer = new DevExpress.XtraBars.BarButtonItem();
            this.btnSendWithdraw = new DevExpress.XtraBars.BarButtonItem();
            this.btnStatement = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomerAnalys = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnPreviewCustomerReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportCustomerReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnBankAccountAnalys = new DevExpress.XtraBars.BarButtonItem();
            this.rbnPAccount = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnPGLog = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnPGRegister = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnPManage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnPGPeople = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnPGFeatures = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnPReport = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnPGStatement = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnPGAccounts = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnPGCustomer = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.btn_DangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.sttStrip = new System.Windows.Forms.StatusStrip();
            this.lblUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRole = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.sttStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ribbon.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(71);
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnLogin,
            this.btnLogout,
            this.btnRegister,
            this.btnEmployee,
            this.btnCustomers,
            this.btnTransfer,
            this.btnSendWithdraw,
            this.btnStatement,
            this.btnCustomerAnalys,
            this.btnBankAccountAnalys,
            this.btnPreviewCustomerReport,
            this.btnExportCustomerReport});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.ribbon.MaxItemId = 13;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 805;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPAccount,
            this.rbnPManage,
            this.rbnPReport});
            this.ribbon.Size = new System.Drawing.Size(1203, 178);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnLogin
            // 
            this.btnLogin.Caption = "Login";
            this.btnLogin.Id = 1;
            this.btnLogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.ImageOptions.Image")));
            this.btnLogin.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.ImageOptions.LargeImage")));
            this.btnLogin.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLogin.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnLogin.ItemAppearance.Disabled.Options.UseTextOptions = true;
            this.btnLogin.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnLogin.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLogin.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnLogin.ItemAppearance.Hovered.Options.UseTextOptions = true;
            this.btnLogin.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnLogin.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLogin.ItemAppearance.Normal.Options.UseFont = true;
            this.btnLogin.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.btnLogin.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnLogin.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLogin.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnLogin.ItemAppearance.Pressed.Options.UseTextOptions = true;
            this.btnLogin.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnLogin.ItemInMenuAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogin_ItemClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Log out";
            this.btnLogout.Id = 2;
            this.btnLogout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.Image")));
            this.btnLogout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.LargeImage")));
            this.btnLogout.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLogout.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnLogout.ItemAppearance.Disabled.Options.UseTextOptions = true;
            this.btnLogout.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnLogout.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLogout.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnLogout.ItemAppearance.Hovered.Options.UseTextOptions = true;
            this.btnLogout.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnLogout.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLogout.ItemAppearance.Normal.Options.UseFont = true;
            this.btnLogout.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.btnLogout.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnLogout.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLogout.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnLogout.ItemAppearance.Pressed.Options.UseTextOptions = true;
            this.btnLogout.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // btnRegister
            // 
            this.btnRegister.Caption = "Register";
            this.btnRegister.Id = 3;
            this.btnRegister.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRegister.ImageOptions.Image")));
            this.btnRegister.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRegister.ImageOptions.LargeImage")));
            this.btnRegister.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnRegister.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnRegister.ItemAppearance.Disabled.Options.UseTextOptions = true;
            this.btnRegister.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnRegister.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnRegister.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnRegister.ItemAppearance.Hovered.Options.UseTextOptions = true;
            this.btnRegister.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnRegister.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnRegister.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRegister.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.btnRegister.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnRegister.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnRegister.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnRegister.ItemAppearance.Pressed.Options.UseTextOptions = true;
            this.btnRegister.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRegister_ItemClick);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Caption = "Employees";
            this.btnEmployee.Id = 4;
            this.btnEmployee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.Image")));
            this.btnEmployee.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.LargeImage")));
            this.btnEmployee.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnEmployee.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnEmployee.ItemAppearance.Disabled.Options.UseTextOptions = true;
            this.btnEmployee.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnEmployee.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnEmployee.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnEmployee.ItemAppearance.Hovered.Options.UseTextOptions = true;
            this.btnEmployee.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnEmployee.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnEmployee.ItemAppearance.Normal.Options.UseFont = true;
            this.btnEmployee.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.btnEmployee.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnEmployee.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnEmployee.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnEmployee.ItemAppearance.Pressed.Options.UseTextOptions = true;
            this.btnEmployee.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployee_ItemClick);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Caption = "Customers";
            this.btnCustomers.Id = 5;
            this.btnCustomers.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomers.ImageOptions.Image")));
            this.btnCustomers.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCustomers.ImageOptions.LargeImage")));
            this.btnCustomers.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnCustomers.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnCustomers.ItemAppearance.Disabled.Options.UseTextOptions = true;
            this.btnCustomers.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnCustomers.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnCustomers.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnCustomers.ItemAppearance.Hovered.Options.UseTextOptions = true;
            this.btnCustomers.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnCustomers.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnCustomers.ItemAppearance.Normal.Options.UseFont = true;
            this.btnCustomers.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.btnCustomers.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnCustomers.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnCustomers.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnCustomers.ItemClickFireMode = DevExpress.XtraBars.BarItemEventFireMode.Immediate;
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomers_ItemClick);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Caption = "Transfer";
            this.btnTransfer.Id = 6;
            this.btnTransfer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTransfer.ImageOptions.Image")));
            this.btnTransfer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTransfer.ImageOptions.LargeImage")));
            this.btnTransfer.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTransfer.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnTransfer.ItemAppearance.Disabled.Options.UseTextOptions = true;
            this.btnTransfer.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnTransfer.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTransfer.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnTransfer.ItemAppearance.Hovered.Options.UseTextOptions = true;
            this.btnTransfer.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnTransfer.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTransfer.ItemAppearance.Normal.Options.UseFont = true;
            this.btnTransfer.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.btnTransfer.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnTransfer.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnTransfer.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnTransfer.ItemAppearance.Pressed.Options.UseTextOptions = true;
            this.btnTransfer.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTransfer_ItemClick);
            // 
            // btnSendWithdraw
            // 
            this.btnSendWithdraw.Caption = "Send/Withdraw";
            this.btnSendWithdraw.Id = 7;
            this.btnSendWithdraw.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSendWithdraw.ImageOptions.Image")));
            this.btnSendWithdraw.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSendWithdraw.ImageOptions.LargeImage")));
            this.btnSendWithdraw.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSendWithdraw.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnSendWithdraw.ItemAppearance.Disabled.Options.UseTextOptions = true;
            this.btnSendWithdraw.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnSendWithdraw.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSendWithdraw.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnSendWithdraw.ItemAppearance.Hovered.Options.UseTextOptions = true;
            this.btnSendWithdraw.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnSendWithdraw.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSendWithdraw.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSendWithdraw.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.btnSendWithdraw.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnSendWithdraw.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSendWithdraw.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnSendWithdraw.ItemAppearance.Pressed.Options.UseTextOptions = true;
            this.btnSendWithdraw.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnSendWithdraw.Name = "btnSendWithdraw";
            this.btnSendWithdraw.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSendWithdraw_ItemClick);
            // 
            // btnStatement
            // 
            this.btnStatement.Caption = "Account Statement";
            this.btnStatement.Id = 8;
            this.btnStatement.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStatement.ImageOptions.Image")));
            this.btnStatement.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStatement.ImageOptions.LargeImage")));
            this.btnStatement.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnStatement.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnStatement.ItemAppearance.Disabled.Options.UseTextOptions = true;
            this.btnStatement.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnStatement.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnStatement.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnStatement.ItemAppearance.Hovered.Options.UseTextOptions = true;
            this.btnStatement.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnStatement.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnStatement.ItemAppearance.Normal.Options.UseFont = true;
            this.btnStatement.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.btnStatement.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnStatement.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnStatement.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnStatement.ItemAppearance.Pressed.Options.UseTextOptions = true;
            this.btnStatement.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnStatement.Name = "btnStatement";
            this.btnStatement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStatement_ItemClick);
            // 
            // btnCustomerAnalys
            // 
            this.btnCustomerAnalys.ActAsDropDown = true;
            this.btnCustomerAnalys.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.btnCustomerAnalys.Caption = "Customers Analys";
            this.btnCustomerAnalys.DropDownControl = this.popupMenu1;
            this.btnCustomerAnalys.Id = 9;
            this.btnCustomerAnalys.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerAnalys.ImageOptions.Image")));
            this.btnCustomerAnalys.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCustomerAnalys.ImageOptions.LargeImage")));
            this.btnCustomerAnalys.ItemAppearance.Disabled.Options.UseTextOptions = true;
            this.btnCustomerAnalys.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnCustomerAnalys.ItemAppearance.Hovered.Options.UseTextOptions = true;
            this.btnCustomerAnalys.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnCustomerAnalys.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnCustomerAnalys.ItemAppearance.Normal.Options.UseFont = true;
            this.btnCustomerAnalys.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.btnCustomerAnalys.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnCustomerAnalys.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnCustomerAnalys.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnCustomerAnalys.ItemAppearance.Pressed.Options.UseTextOptions = true;
            this.btnCustomerAnalys.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnCustomerAnalys.Name = "btnCustomerAnalys";
            this.btnCustomerAnalys.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomerAnalys_ItemClick);
            // 
            // popupMenu1
            // 
            this.popupMenu1.ItemLinks.Add(this.btnPreviewCustomerReport);
            this.popupMenu1.ItemLinks.Add(this.btnExportCustomerReport);
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbon;
            // 
            // btnPreviewCustomerReport
            // 
            this.btnPreviewCustomerReport.Caption = "Preview Report";
            this.btnPreviewCustomerReport.Id = 11;
            this.btnPreviewCustomerReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviewCustomerReport.ImageOptions.Image")));
            this.btnPreviewCustomerReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPreviewCustomerReport.ImageOptions.LargeImage")));
            this.btnPreviewCustomerReport.Name = "btnPreviewCustomerReport";
            this.btnPreviewCustomerReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPreviewCustomerReport_ItemClick);
            // 
            // btnExportCustomerReport
            // 
            this.btnExportCustomerReport.Caption = "Export PDF";
            this.btnExportCustomerReport.Id = 12;
            this.btnExportCustomerReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExportCustomerReport.ImageOptions.Image")));
            this.btnExportCustomerReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExportCustomerReport.ImageOptions.LargeImage")));
            this.btnExportCustomerReport.Name = "btnExportCustomerReport";
            this.btnExportCustomerReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportCustomerReport_ItemClick);
            // 
            // btnBankAccountAnalys
            // 
            this.btnBankAccountAnalys.Caption = "Bank Accounts Analys";
            this.btnBankAccountAnalys.Id = 10;
            this.btnBankAccountAnalys.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBankAccountAnalys.ImageOptions.Image")));
            this.btnBankAccountAnalys.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBankAccountAnalys.ImageOptions.LargeImage")));
            this.btnBankAccountAnalys.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnBankAccountAnalys.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnBankAccountAnalys.ItemAppearance.Disabled.Options.UseTextOptions = true;
            this.btnBankAccountAnalys.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnBankAccountAnalys.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnBankAccountAnalys.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnBankAccountAnalys.ItemAppearance.Hovered.Options.UseTextOptions = true;
            this.btnBankAccountAnalys.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnBankAccountAnalys.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnBankAccountAnalys.ItemAppearance.Normal.Options.UseFont = true;
            this.btnBankAccountAnalys.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.btnBankAccountAnalys.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnBankAccountAnalys.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnBankAccountAnalys.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnBankAccountAnalys.ItemAppearance.Pressed.Options.UseTextOptions = true;
            this.btnBankAccountAnalys.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.btnBankAccountAnalys.Name = "btnBankAccountAnalys";
            this.btnBankAccountAnalys.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBankAccountAnalys_ItemClick);
            // 
            // rbnPAccount
            // 
            this.rbnPAccount.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rbnPAccount.Appearance.Options.UseFont = true;
            this.rbnPAccount.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rbnPAccount.AppearanceHovered.Options.UseFont = true;
            this.rbnPAccount.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rbnPAccount.AppearanceSelected.Options.UseFont = true;
            this.rbnPAccount.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnPGLog,
            this.rbnPGRegister});
            this.rbnPAccount.Name = "rbnPAccount";
            this.rbnPAccount.Text = "Accounts";
            // 
            // rbnPGLog
            // 
            this.rbnPGLog.ItemLinks.Add(this.btnLogin);
            this.rbnPGLog.ItemLinks.Add(this.btnLogout);
            this.rbnPGLog.Name = "rbnPGLog";
            // 
            // rbnPGRegister
            // 
            this.rbnPGRegister.ItemLinks.Add(this.btnRegister);
            this.rbnPGRegister.Name = "rbnPGRegister";
            // 
            // rbnPManage
            // 
            this.rbnPManage.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rbnPManage.Appearance.Options.UseFont = true;
            this.rbnPManage.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rbnPManage.AppearanceHovered.Options.UseFont = true;
            this.rbnPManage.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rbnPManage.AppearanceSelected.Options.UseFont = true;
            this.rbnPManage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnPGPeople,
            this.rbnPGFeatures});
            this.rbnPManage.Name = "rbnPManage";
            this.rbnPManage.Text = "Manage";
            // 
            // rbnPGPeople
            // 
            this.rbnPGPeople.ItemLinks.Add(this.btnEmployee);
            this.rbnPGPeople.ItemLinks.Add(this.btnCustomers);
            this.rbnPGPeople.Name = "rbnPGPeople";
            // 
            // rbnPGFeatures
            // 
            this.rbnPGFeatures.ItemLinks.Add(this.btnTransfer);
            this.rbnPGFeatures.ItemLinks.Add(this.btnSendWithdraw);
            this.rbnPGFeatures.Name = "rbnPGFeatures";
            this.rbnPGFeatures.Text = "ribbonPageGroup1";
            // 
            // rbnPReport
            // 
            this.rbnPReport.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rbnPReport.Appearance.Options.UseFont = true;
            this.rbnPReport.AppearanceHovered.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rbnPReport.AppearanceHovered.Options.UseFont = true;
            this.rbnPReport.AppearanceSelected.Font = new System.Drawing.Font("Tahoma", 11F);
            this.rbnPReport.AppearanceSelected.Options.UseFont = true;
            this.rbnPReport.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnPGStatement,
            this.rbnPGAccounts,
            this.rbnPGCustomer});
            this.rbnPReport.Name = "rbnPReport";
            this.rbnPReport.Text = "Reports";
            // 
            // rbnPGStatement
            // 
            this.rbnPGStatement.ItemLinks.Add(this.btnStatement);
            this.rbnPGStatement.Name = "rbnPGStatement";
            // 
            // rbnPGAccounts
            // 
            this.rbnPGAccounts.ItemLinks.Add(this.btnBankAccountAnalys);
            this.rbnPGAccounts.Name = "rbnPGAccounts";
            // 
            // rbnPGCustomer
            // 
            this.rbnPGCustomer.ItemLinks.Add(this.btnCustomerAnalys);
            this.rbnPGCustomer.Name = "rbnPGCustomer";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 650);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1203, 30);
            // 
            // btn_DangNhap
            // 
            this.btn_DangNhap.Caption = "Đăng Nhập";
            this.btn_DangNhap.Id = 1;
            this.btn_DangNhap.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_DangNhap.ImageOptions.SvgImage")));
            this.btn_DangNhap.Name = "btn_DangNhap";
            // 
            // sttStrip
            // 
            this.sttStrip.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sttStrip.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sttStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsername,
            this.lblName,
            this.lblRole});
            this.sttStrip.Location = new System.Drawing.Point(0, 619);
            this.sttStrip.Name = "sttStrip";
            this.sttStrip.Size = new System.Drawing.Size(1203, 31);
            this.sttStrip.TabIndex = 2;
            this.sttStrip.Text = "statusStrip1";
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 25);
            this.lblUsername.Text = "Username: ";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(97, 25);
            this.lblName.Text = "Full name: ";
            // 
            // lblRole
            // 
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(55, 25);
            this.lblRole.Text = "Role: ";
            // 
            // frmMain
            // 
            this.ActiveGlowColor = System.Drawing.Color.Silver;
            this.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 680);
            this.Controls.Add(this.sttStrip);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmMain.IconOptions.Image")));
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "BANK\'S TRANSACTION MANAGER";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.sttStrip.ResumeLayout(false);
            this.sttStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPAccount;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnPGLog;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btn_DangNhap;
        private DevExpress.XtraBars.BarButtonItem btnLogin;
        private DevExpress.XtraBars.BarButtonItem btnRegister;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnPGRegister;
        private DevExpress.XtraBars.BarButtonItem btnEmployee;
        private DevExpress.XtraBars.BarButtonItem btnCustomers;
        private DevExpress.XtraBars.BarButtonItem btnTransfer;
        private DevExpress.XtraBars.BarButtonItem btnSendWithdraw;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPManage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnPGPeople;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnPGFeatures;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnPGStatement;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnPGAccounts;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnPGCustomer;
        private DevExpress.XtraBars.BarButtonItem btnStatement;
        private DevExpress.XtraBars.BarButtonItem btnCustomerAnalys;
        private DevExpress.XtraBars.BarButtonItem btnBankAccountAnalys;
        public System.Windows.Forms.StatusStrip sttStrip;
        public System.Windows.Forms.ToolStripStatusLabel lblUsername;
        public System.Windows.Forms.ToolStripStatusLabel lblName;
        public System.Windows.Forms.ToolStripStatusLabel lblRole;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem btnPreviewCustomerReport;
        private DevExpress.XtraBars.BarButtonItem btnExportCustomerReport;
        public DevExpress.XtraBars.BarButtonItem btnLogout;
    }
}