using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QLGDNganHang
{
    public partial class XrptAccountStatement : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptAccountStatement()
        {
            InitializeComponent();
        }
        public XrptAccountStatement(DateTime startDate, DateTime endDate, string accountID, string cmnd, string name)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connectionString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = accountID;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = startDate;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = endDate;
            this.sqlDataSource1.Fill();

            lblAccount.Text = accountID;
            lblCMND.Text = cmnd;
            lblCustomerName.Text = name;
            lblDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            lblUsername.Text = Program.mUsername;
            lblNameOfUser.Text = Program.mName;
            lblStartDate.Text = startDate.ToString("dd/MM/yyyy");
            lblEndDate.Text = endDate.ToString("dd/MM/yyyy");
        }
    }
}
