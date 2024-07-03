﻿namespace QLGDNganHang
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
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.DrawGroupCaptions = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ExpandCollapseItem.Id = 0;
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
            this.btnBankAccountAnalys});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 11;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbnPAccount,
            this.rbnPManage,
            this.rbnPReport});
            this.ribbon.Size = new System.Drawing.Size(1203, 172);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnLogin
            // 
            this.btnLogin.Caption = "Login";
            this.btnLogin.Id = 1;
            this.btnLogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.ImageOptions.Image")));
            this.btnLogin.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.ImageOptions.LargeImage")));
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogin_ItemClick);
            // 
            // btnLogout
            // 
            this.btnLogout.Caption = "Log out";
            this.btnLogout.Id = 2;
            this.btnLogout.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.Image")));
            this.btnLogout.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.ImageOptions.LargeImage")));
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogout_ItemClick);
            // 
            // btnRegister
            // 
            this.btnRegister.Caption = "Register";
            this.btnRegister.Id = 3;
            this.btnRegister.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRegister.ImageOptions.Image")));
            this.btnRegister.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRegister.ImageOptions.LargeImage")));
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRegister_ItemClick);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Caption = "Employees";
            this.btnEmployee.Id = 4;
            this.btnEmployee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.Image")));
            this.btnEmployee.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmployee.ImageOptions.LargeImage")));
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployee_ItemClick);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Caption = "Customers";
            this.btnCustomers.Id = 5;
            this.btnCustomers.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomers.ImageOptions.Image")));
            this.btnCustomers.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCustomers.ImageOptions.LargeImage")));
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomers_ItemClick);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Caption = "Transfer";
            this.btnTransfer.Id = 6;
            this.btnTransfer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTransfer.ImageOptions.Image")));
            this.btnTransfer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTransfer.ImageOptions.LargeImage")));
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTransfer_ItemClick);
            // 
            // btnSendWithdraw
            // 
            this.btnSendWithdraw.Caption = "Send/Withdraw";
            this.btnSendWithdraw.Id = 7;
            this.btnSendWithdraw.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSendWithdraw.ImageOptions.Image")));
            this.btnSendWithdraw.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSendWithdraw.ImageOptions.LargeImage")));
            this.btnSendWithdraw.Name = "btnSendWithdraw";
            this.btnSendWithdraw.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSendWithdraw_ItemClick);
            // 
            // btnStatement
            // 
            this.btnStatement.Caption = "Account Statement";
            this.btnStatement.Id = 8;
            this.btnStatement.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnStatement.ImageOptions.Image")));
            this.btnStatement.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnStatement.ImageOptions.LargeImage")));
            this.btnStatement.Name = "btnStatement";
            this.btnStatement.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStatement_ItemClick);
            // 
            // btnCustomerAnalys
            // 
            this.btnCustomerAnalys.Caption = "Customers Analys";
            this.btnCustomerAnalys.Id = 9;
            this.btnCustomerAnalys.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomerAnalys.ImageOptions.Image")));
            this.btnCustomerAnalys.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCustomerAnalys.ImageOptions.LargeImage")));
            this.btnCustomerAnalys.Name = "btnCustomerAnalys";
            this.btnCustomerAnalys.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomerAnalys_ItemClick);
            // 
            // btnBankAccountAnalys
            // 
            this.btnBankAccountAnalys.Caption = "BankAccounts Analys";
            this.btnBankAccountAnalys.Id = 10;
            this.btnBankAccountAnalys.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBankAccountAnalys.ImageOptions.Image")));
            this.btnBankAccountAnalys.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBankAccountAnalys.ImageOptions.LargeImage")));
            this.btnBankAccountAnalys.Name = "btnBankAccountAnalys";
            this.btnBankAccountAnalys.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBankAccountAnalys_ItemClick);
            // 
            // rbnPAccount
            // 
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 680);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "BANK\'S TRANSACTION MANAGER";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem btnLogout;
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
    }
}