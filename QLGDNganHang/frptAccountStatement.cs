using DevExpress.XtraReports;
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

namespace QLGDNganHang
{
    public partial class frptAccountStatement : Form
    {
        private DataTable dt = new DataTable();
        private XrptAccountStatement rpt;

        public frptAccountStatement()
        {
            InitializeComponent();
        }

        private void frptAccountStatement_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            switch (Program.mRole)
            {
                case "KhachHang":
                    dt = Program.ExecStoredProcedureReturnTable($"EXEC dbo.sp_DanhSachTaiKhoan_KhachHang @CMND = {Program.mUsername}");
                    txtCMND.Text = Program.mUsername;
                    txtName.Text = Program.mName;
                    break;
                default:
                    dt = Program.ExecStoredProcedureReturnTable("Select * from dbo.v_taiKhoanKhachHang");
                    break;
            }
            cbxAccountID.DataSource = dt;
            cbxAccountID.DisplayMember = "SOTK";
            cbxAccountID.ValueMember = "SOTK";
            cbxAccountID.SelectedIndex = 0;
            cbxAccountID.DropDownStyle = ComboBoxStyle.DropDownList;
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!checkForm())
                return;

            rpt = new XrptAccountStatement(pickerStartDate.Value, pickerEndDate.Value, cbxAccountID.Text, txtCMND.Text, txtName.Text);

            rpt.ShowPreviewDialog();
        }

        private void cbxAccountID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.mRole == "KhachHang")
                return;

            txtCMND.Text = dt.Rows[cbxAccountID.SelectedIndex]["CMND"].ToString();
            txtName.Text = dt.Rows[cbxAccountID.SelectedIndex]["HOTEN"].ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!checkForm())
                return; 
            
            rpt = new XrptAccountStatement(pickerStartDate.Value, pickerEndDate.Value, cbxAccountID.Text, txtCMND.Text, txtName.Text);
            Program.ExportReport(rpt, "PDF");
        }
    }
}
