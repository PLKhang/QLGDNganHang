using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLGDNganHang
{
    public partial class XrptCustomersList : DevExpress.XtraReports.UI.XtraReport
    {
        public XrptCustomersList()
        {
            InitializeComponent();
            lblDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            lblUser.Text = Program.mUsername;
            lblNameOfUser.Text = Program.mName;
        }



    }
}
