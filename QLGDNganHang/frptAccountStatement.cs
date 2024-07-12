using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.Import.Doc;
using DevExpress.XtraRichEdit.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLGDNganHang
{
    public partial class frptAccountStatement : Form
    {
        private DataTable dtCustomer = new DataTable();
        private DataTable dtAccountOrigin = new DataTable();
        private DataTable dtAccount = new DataTable();
        private XrptAccountStatement rpt;

        private bool isSpecialReport = false;
        private string specialAccount = "";
        private bool allowCbxCustomer = false;

        public frptAccountStatement()
        {
            InitializeComponent();
        }

        public frptAccountStatement(string account)
        {
            InitializeComponent();

            specialAccount = account;
            isSpecialReport = true;
        }

        private void frptAccountStatement_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            switch (Program.mRole)
            {
                case "KhachHang":
                    dtAccount = Program.ExecStoredProcedureReturnTable($"EXEC dbo.sp_DanhSachTaiKhoan_KhachHang @CMND = {Program.mUsername}");
                    cbxCMND.Text = Program.mUsername;
                    txtName.Text = Program.mName;
                    cbxCMND.Enabled = false;
                    break;
                default:
                    dtCustomer = Program.ExecStoredProcedureReturnTable("Select CMND from dbo.V_DanhSachKhachHang_NganHang");
                    dtAccountOrigin = Program.ExecStoredProcedureReturnTable("Select * from dbo.v_taiKhoanKhachHang");
                    break;
            }

            dtAccount = dtAccountOrigin.Copy();

            cbxCMND.DataSource = dtCustomer;
            cbxCMND.DisplayMember = "CMND";
            cbxCMND.ValueMember = "CMND";

            cbxAccountID.DataSource = dtAccount;
            cbxAccountID.DisplayMember = "SOTK";
            cbxAccountID.ValueMember = "SOTK";
            cbxAccountID.DropDownStyle = ComboBoxStyle.DropDownList;

            if (isSpecialReport)
            {
                int i = 0;
                foreach (DataRowView row in cbxAccountID.Items)
                {
                    if (row["SOTK"].ToString() == specialAccount)
                    {
                        cbxAccountID.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }
            else
            {
                cbxAccountID.SelectedIndex = 0;
            }
            allowCbxCustomer = true;
        }

        private bool checkForm()
        {
            if (string.IsNullOrEmpty(cbxAccountID.Text))
            {
                MessageBox.Show("Choose an bank account to continue!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (pickerEndDate.Value < pickerStartDate.Value.Date)
            {
                MessageBox.Show("End date must be larger than or equal Start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (pickerEndDate.Value.CompareTo(DateTime.Now.Date.AddDays(1)) > 0)
            {
                MessageBox.Show("End date must be smaller than or equal Current date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (!checkForm())
                return;

            rpt = new XrptAccountStatement(pickerStartDate.Value, pickerEndDate.Value.AddDays(1), cbxAccountID.Text, cbxCMND.Text, txtName.Text);

            rpt.ShowPreviewDialog();
        }

        private void cbxAccountID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.mRole == "KhachHang")
                return;

            getAccountInfo(cbxAccountID.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getAccountInfo(string account)
        {
            foreach (DataRow row in dtAccount.Rows)
            {
                if (row["SOTK"].ToString() == account)
                {
                    cbxCMND.Text = row["CMND"]?.ToString();
                    txtName.Text = row["HOTEN"]?.ToString();
                    break;
                }
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!checkForm())
                return; 
            
            rpt = new XrptAccountStatement(pickerStartDate.Value, pickerEndDate.Value, cbxAccountID.Text, cbxCMND.Text, txtName.Text);
            Program.ExportReport(rpt, "PDF");
        }

        private void cbxCMND_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (allowCbxCustomer)
            {
                loadDataTable(cbxCMND.Text);
            }

            foreach (DataRow row in dtAccount.Rows)
            {
                if (row["CMND"].ToString() == cbxCMND.Text)
                {
                    txtName.Text = row["HOTEN"]?.ToString();
                    break;
                }
            }
        }

        private void loadDataTable(string CMND = "")
        {
            string filterExpression = "";
            if (!string.IsNullOrEmpty(CMND))
            {
                filterExpression += $"CMND = '{CMND}'";
            }

            DataRow[] filteredRows = dtAccountOrigin.Select(filterExpression);
            dtAccount = dtAccountOrigin.Clone();

            foreach (DataRow row in filteredRows)
            {
                dtAccount.ImportRow(row);
            }

            cbxAccountID.DataSource = dtAccount;
            cbxAccountID.DisplayMember = "SOTK";
            cbxAccountID.ValueMember = "SOTK";
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            loadDataTable();
        }
    }
}
