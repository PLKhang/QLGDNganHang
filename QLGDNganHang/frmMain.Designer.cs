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
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblName = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnAccount = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnLogin = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogout = new DevExpress.XtraBars.BarButtonItem();
            this.btnRegister = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.btnSendWithdraw = new DevExpress.XtraBars.BarButtonItem();
            this.btnTransfer = new DevExpress.XtraBars.BarButtonItem();
            this.btnStatementReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnAccountReport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.rbnAccount = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnLogin = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnRegister = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnManage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnPeople = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnTransaction = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnReport = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rbnPageGroupReport = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnPageGroupAnalys = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsername,
            this.lblName,
            this.lblRole});
            this.statusStrip.Location = new System.Drawing.Point(0, 532);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(1049, 26);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // lblUsername
            // 
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(41, 20);
            this.lblUsername.Text = "User:";
            // 
            // lblName
            // 
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 20);
            this.lblName.Text = "Họ tên:";
            // 
            // lblRole
            // 
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(42, 20);
            this.lblRole.Text = "Role:";
            // 
            // btnAccount
            // 
            this.btnAccount.AutoSizeItems = true;
            this.btnAccount.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            this.btnAccount.ExpandCollapseItem.Id = 0;
            this.btnAccount.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.btnAccount.GalleryAnimationLength = 0;
            this.btnAccount.GroupAnimationLength = 0;
            this.btnAccount.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAccount.ExpandCollapseItem,
            this.btnAccount.SearchEditItem,
            this.btnLogin,
            this.btnLogout,
            this.btnRegister,
            this.btnEmployee,
            this.btnCustomer,
            this.btnSendWithdraw,
            this.btnTransfer,
            this.btnStatementReport,
            this.btnAccountReport,
            this.barButtonItem1,
            this.barButtonItem2});
            this.btnAccount.Location = new System.Drawing.Point(0, 0);
            this.btnAccount.MaxItemId = 12;
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.PageAnimationLength = 0;
            this.btnAccount.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnAccount,
            this.rbnManage,
            this.rbnReport,
            this.ribbonPage1});
            this.btnAccount.Size = new System.Drawing.Size(1049, 162);
            // 
            // btnLogin
            // 
            this.btnLogin.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.btnLogin.Caption = "Login";
            this.btnLogin.Id = 1;
            this.btnLogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.ImageOptions.Image")));
            this.btnLogin.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.ImageOptions.LargeImage")));
            this.btnLogin.Name = "btnLogin";
            toolTipItem3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            toolTipItem3.Appearance.Options.UseFont = true;
            toolTipItem3.Appearance.Options.UseTextOptions = true;
            toolTipItem3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            toolTipItem3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            toolTipItem3.Text = "ss";
            superToolTip3.Items.Add(toolTipItem3);
            this.btnLogin.SuperTip = superToolTip3;
            this.btnLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogin_ItemClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Đăng xuất";
            this.btnLogout.Id = 2;
            this.btnLogout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.Image")));
            this.btnLogout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.LargeImage")));
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            toolTipItem4.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            toolTipItem4.Appearance.Options.UseFont = true;
            toolTipItem4.Text = "ss";
            superToolTip4.Items.Add(toolTipItem4);
            this.btnLogout.SuperTip = superToolTip4;
            // 
            // btnRegister
            // 
            this.btnRegister.Caption = "Đăng ký";
            this.btnRegister.Id = 3;
            this.btnRegister.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRegister.ImageOptions.Image")));
            this.btnRegister.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRegister.ImageOptions.LargeImage")));
            this.btnRegister.Name = "btnRegister";
            // 
            // btnEmployee
            // 
            this.btnEmployee.Caption = "Nhân viên";
            this.btnEmployee.Id = 4;
            this.btnEmployee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.Image")));
            this.btnEmployee.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.LargeImage")));
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnCustomer
            // 
            this.btnCustomer.Caption = "Khách hàng";
            this.btnCustomer.Id = 5;
            this.btnCustomer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.ImageOptions.Image")));
            this.btnCustomer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCustomer.ImageOptions.LargeImage")));
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnSendWithdraw
            // 
            this.btnSendWithdraw.Caption = "Gửi/Rút tiền";
            this.btnSendWithdraw.Id = 6;
            this.btnSendWithdraw.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSendWithdraw.ImageOptions.Image")));
            this.btnSendWithdraw.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSendWithdraw.ImageOptions.LargeImage")));
            this.btnSendWithdraw.Name = "btnSendWithdraw";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Caption = "Chuyển tiền";
            this.btnTransfer.Id = 7;
            this.btnTransfer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTransfer.ImageOptions.Image")));
            this.btnTransfer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTransfer.ImageOptions.LargeImage")));
            this.btnTransfer.Name = "btnTransfer";
            // 
            // btnStatementReport
            // 
            this.btnStatementReport.Caption = " Sao kê\r\nTài khoản ngân hàng\r\n";
            this.btnStatementReport.Id = 8;
            this.btnStatementReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStatementReport.ImageOptions.Image")));
            this.btnStatementReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStatementReport.ImageOptions.LargeImage")));
            this.btnStatementReport.Name = "btnStatementReport";
            // 
            // btnAccountReport
            // 
            this.btnAccountReport.Caption = "Tài khoản ngân hàng mở";
            this.btnAccountReport.Id = 9;
            this.btnAccountReport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAccountReport.ImageOptions.Image")));
            this.btnAccountReport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAccountReport.ImageOptions.LargeImage")));
            this.btnAccountReport.Name = "btnAccountReport";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Toàn bộ khách hàng";
            this.barButtonItem1.Id = 10;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 11;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // rbnAccount
            // 
            this.rbnAccount.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnLogin,
            this.rbnRegister});
            this.rbnAccount.MergeOrder = 0;
            this.rbnAccount.Name = "rbnAccount";
            this.rbnAccount.Text = "Tài khoản";
            // 
            // rbnLogin
            // 
            this.rbnLogin.ItemLinks.Add(this.btnLogin, true);
            this.rbnLogin.ItemLinks.Add(this.btnLogout);
            this.rbnLogin.Name = "rbnLogin";
            this.rbnLogin.Text = "ribbonPageGroup2";
            // 
            // rbnRegister
            // 
            this.rbnRegister.AccessibleDescription = "Đăng ký tài khoản đăng nhập";
            this.rbnRegister.ItemLinks.Add(this.btnRegister);
            this.rbnRegister.Name = "rbnRegister";
            this.rbnRegister.Text = "Đăng ký";
            // 
            // rbnManage
            // 
            this.rbnManage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnPeople,
            this.rbnTransaction});
            this.rbnManage.MergeOrder = 0;
            this.rbnManage.Name = "rbnManage";
            this.rbnManage.Text = "Quản lý";
            // 
            // rbnPeople
            // 
            this.rbnPeople.ItemLinks.Add(this.btnEmployee);
            this.rbnPeople.ItemLinks.Add(this.btnCustomer);
            this.rbnPeople.Name = "rbnPeople";
            this.rbnPeople.Text = "Nhân sự";
            // 
            // rbnTransaction
            // 
            this.rbnTransaction.ItemLinks.Add(this.btnSendWithdraw);
            this.rbnTransaction.ItemLinks.Add(this.btnTransfer);
            this.rbnTransaction.Name = "rbnTransaction";
            this.rbnTransaction.Text = "Giao dịch";
            // 
            // rbnReport
            // 
            this.rbnReport.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rbnPageGroupReport,
            this.rbnPageGroupAnalys});
            this.rbnReport.MergeOrder = 0;
            this.rbnReport.Name = "rbnReport";
            this.rbnReport.Text = "Báo cáo";
            // 
            // rbnPageGroupReport
            // 
            this.rbnPageGroupReport.ItemLinks.Add(this.btnStatementReport);
            this.rbnPageGroupReport.Name = "rbnPageGroupReport";
            this.rbnPageGroupReport.Text = "Báo cáo";
            // 
            // rbnPageGroupAnalys
            // 
            this.rbnPageGroupAnalys.ItemLinks.Add(this.btnAccountReport);
            this.rbnPageGroupAnalys.ItemLinks.Add(this.barButtonItem1);
            this.rbnPageGroupAnalys.Name = "rbnPageGroupAnalys";
            this.rbnPageGroupAnalys.Text = "Thống kê";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1049, 558);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.statusStrip);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblUsername;
        private DevExpress.XtraBars.Ribbon.RibbonControl btnAccount;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnAccount;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnLogin;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnPageGroupReport;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnManage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnPeople;
        private DevExpress.XtraBars.BarButtonItem btnLogin;
        private DevExpress.XtraBars.BarButtonItem btnLogout;
        private DevExpress.XtraBars.BarButtonItem btnRegister;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnRegister;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripStatusLabel lblName;
        private System.Windows.Forms.ToolStripStatusLabel lblRole;
        private DevExpress.XtraBars.BarButtonItem btnEmployee;
        private DevExpress.XtraBars.BarButtonItem btnCustomer;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnTransaction;
        private DevExpress.XtraBars.BarButtonItem btnSendWithdraw;
        private DevExpress.XtraBars.BarButtonItem btnTransfer;
        private DevExpress.XtraBars.BarButtonItem btnStatementReport;
        private DevExpress.XtraBars.BarButtonItem btnAccountReport;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnPageGroupAnalys;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
    }
}



