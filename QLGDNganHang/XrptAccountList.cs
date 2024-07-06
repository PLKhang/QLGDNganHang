using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLGDNganHang
{
    public partial class XrptAccountList : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptAccountList()
        {
            InitializeComponent();
        }

        public XrptAccountList(DateTime startDate, DateTime endDate, char type, string branch) {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connectionString;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = startDate;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = endDate;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = type;
            this.sqlDataSource1.Queries[0].Parameters[3].Value = branch;
            this.sqlDataSource1.Fill();

            if (type == 'T')
            {
                lblBranch.Text = "ALL BRANCHS";
            }
            else
            {
                lblBranch.Text = branch;
            }
            lblDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            lblUser.Text = Program.mUsername;
            lblNameOfUser.Text = Program.mName;
            lblStartDate.Text = startDate.ToString("dd/MM/yyyy");
            lblEndDate.Text = endDate.ToString("dd/MM/yyyy");
        }

    }
}
