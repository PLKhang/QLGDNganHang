using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QLGDNganHang
{
    public partial class frptAccountsList : Form
    {
        private string branch = "BENTHANH";
        private char type = 'C';

        private XrptAccountList rpt;
        public frptAccountsList()
        {
            InitializeComponent();
        }

        private void frptAccountsList_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            cbxBranchs.SelectedIndex = 0;
            cbxBranchs.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool checkForm()
        {
            if (pickerEndDate.Value < pickerStartDate.Value.Date)
            {
                MessageBox.Show("End date must be larger than or equal Start date!", "Error", MessageBoxButtons.OK);
                return false;
            }
            else if (pickerEndDate.Value.CompareTo(DateTime.Now.Date.AddDays(1)) > 0)
            {
                MessageBox.Show("End date must be smaller than or equal Current date!", "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void checkAllBranch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAllBranch.Checked)
            {
                cbxBranchs.Text = "ALL BRANCHS SELECTED";
                cbxBranchs.Enabled = false;

                type = 'T';

                panel.BackgroundImage = QLGDNganHang.Properties.Resources.BANK;
            }
            else
            {
                cbxBranchs.Enabled = true;
                cbxBranchs.SelectedIndex = 0;

                type = 'C';

                panel.BackgroundImage = QLGDNganHang.Properties.Resources.BENTHANH;

            }
        }

        private void cbxBranchs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBranchs.SelectedIndex == 0)
            {
                branch = "BENTHANH";
                panel.BackgroundImage = QLGDNganHang.Properties.Resources.BENTHANH;
            }
            else
            {
                branch = "TANDINH";
                panel.BackgroundImage = QLGDNganHang.Properties.Resources.TANDINH;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!checkForm())
                return;

            rpt = new XrptAccountList(pickerStartDate.Value, pickerEndDate.Value, type, branch);

            rpt.ShowPreviewDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            rpt = new XrptAccountList(pickerStartDate.Value, pickerEndDate.Value, type, branch);

            Program.ExportReport(rpt, "PDF");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
