using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLGDNganHang
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.IsMdiContainer = true;
            btnLogin.PerformClick();
        }

        public void reloadForm(string role)
        {
            switch(role)
            {
                case "login":
                    rbnPManage.Visible = rbnPReport.Visible = rbnPGRegister.Visible = false;
                    btnLogout.Enabled = false; 
                    break;
                case "KhachHang":
                    rbnPManage.Visible = rbnPGCustomer.Visible = rbnPGAccounts.Visible = rbnPGRegister.Visible = false;
                    rbnPReport.Visible = true;
                    btnLogin.Enabled = false;
                    btnLogout.Enabled = true;
                    break;
                case "NganHang":
                    rbnPGFeatures.Visible = false;
                    rbnPManage.Visible = rbnPReport.Visible = rbnPGAccounts.Visible = rbnPGCustomer.Visible 
                        = rbnPGRegister.Visible = true;
                    btnLogin.Enabled = false;
                    btnLogout.Enabled = true;
                    break;
                case "ChiNhanh":
                    rbnPManage.Visible = rbnPReport.Visible = rbnPGCustomer.Visible = rbnPGAccounts.Visible
                        = rbnPGFeatures.Visible = rbnPGRegister.Visible = true; 
                    btnLogin.Enabled = false;
                    btnLogout.Enabled = true; 
                    break;
                default:
                    MessageBox.Show("Role sai", "Fail to load MainForm", MessageBoxButtons.OK);
                    break;
            }
        }

        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        //-----------------Ribbon Page Accounts------------------------//
        //------Ribbon Page Group Log In/Out------//
        private void btnLogin_ItemClick(object sender, ItemClickEventArgs e)
        {
            reloadForm("login");
            Form form = this.CheckExists(typeof(frmLogin));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmLogin f = new frmLogin();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            lblUsername.Text = "Username: ";
            lblName.Text = "Full name: ";
            lblRole.Text = "Role: ";

            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }

            Program.Logout();
            btnLogin.Enabled = true;
            btnLogin.PerformClick();
        }

        //------Ribbon Page Group Register  ------//
        private void btnRegister_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frmRegister));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmRegister f = new frmRegister();
                f.MdiParent = this;
                f.Show();
            }
        }

        //-----------------Ribbon Page Manage  ------------------------//
        //------Ribbon Page Group People    ------//
        private void btnEmployee_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frmEmployee));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmEmployee f = new frmEmployee();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCustomers_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frmCustomers));
            if (form != null)
            {
                form.Activate();
                //this.ActivateMdiChild(form);
            }
            else
            {
                frmCustomers f = new frmCustomers();
                f.MdiParent = this;
                f.Show();
            }
        }

        //------Ribbon Page Group Features  ------//
        private void btnTransfer_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frmTransfer));
            if (form != null)
            {
                form.Activate();
                //this.ActivateMdiChild(form);
            }
            else
            {
                frmTransfer f = new frmTransfer();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnSendWithdraw_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frmTransaction));
            if (form != null)
            {
                form.Activate();
                //this.ActivateMdiChild(form);
            }
            else
            {
                frmTransaction f = new frmTransaction();
                f.MdiParent = this;
                f.Show();
            }
        }

        //-----------------Ribbon Page Reports ------------------------//
        //------Ribbon Page Group Statement ------//
        private void btnStatement_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frptAccountStatement));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frptAccountStatement f = new frptAccountStatement();
                f.MdiParent = this;
                f.Show();
            }
        }

        //------Ribbon Page Group Accounts  ------//
        private void btnBankAccountAnalys_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form form = this.CheckExists(typeof(frptAccountsList));
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frptAccountsList f = new frptAccountsList();
                f.MdiParent = this;
                f.Show();
            }
        }

        //------Ribbon Page Group Customers ------//
        private void btnCustomerAnalys_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btnPreviewCustomerReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            XrptCustomersList rpt = new XrptCustomersList();

            rpt.ShowPreviewDialog();
        }

        private void btnExportCustomerReport_ItemClick(object sender, ItemClickEventArgs e)
        {
            XrptCustomersList rpt = new XrptCustomersList();

            Program.ExportReport(rpt, "PDF");
        }
    }
}