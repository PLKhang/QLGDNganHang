using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLGDNganHang
{
    public partial class frmTransfer : Form
    {
        private int state = 0;
        private DataTable dtCustomer = new DataTable(); 
        private DataTable dtAccountOrigin = new DataTable();
        private DataTable dtAccount = new DataTable();
        private bool isLoading = false;


        public frmTransfer()
        {
            InitializeComponent();
        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.txtEmployeeID.Text = Program.mUsername;

            dtCustomer = Program.ExecStoredProcedureReturnTable("Select CMND, trim(HO) + ' ' + trim(TEN) as HOTEN, MACN from dbo.V_DanhSachKhachHang");
            dtAccountOrigin = Program.ExecStoredProcedureReturnTable("Select SOTK, CMND, HOTEN, SODU, MACN from dbo.V_TaiKhoanKhachHang");
            dtAccount = dtAccountOrigin.Copy();
            data.AutoGenerateColumns = false;

            cbxCustomer.DataSource = dtCustomer;
            cbxCustomer.DisplayMember = "CMND";
            cbxCustomer.ValueMember = "CMND";
            cbxCustomer.Text = "";

            btnShowAll.PerformClick();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void loadDataGridView()
        {
            data.DataSource = dtAccount;
            int width = data.Width - 40;
            data.Columns.Clear();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.data.ColumnHeadersHeight = 35;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data.DefaultCellStyle = dataGridViewCellStyle2;

            // Tạo cột cho SOTK
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "SOTK";
            idColumn.Name = "SOTK";
            idColumn.HeaderText = "Account Number";
            idColumn.Width = width * 20 / 100;
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(idColumn);

            // Tạo cột cho CMND
            DataGridViewTextBoxColumn CMNDColumn = new DataGridViewTextBoxColumn();
            CMNDColumn.DataPropertyName = "CMND";
            CMNDColumn.Name = "CMND";
            CMNDColumn.HeaderText = "Customer's CMND";
            CMNDColumn.Width = width * 20 / 100;
            CMNDColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(CMNDColumn);

            // Tạo cột cho HOTEN
            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "HOTEN";
            nameColumn.Name = "HOTEN";
            nameColumn.HeaderText = "Customer's Name";
            nameColumn.Width = width * 35 / 100;
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            data.Columns.Add(nameColumn);

            // Tạo cột cho HOTEN
            DataGridViewTextBoxColumn balanceColumn = new DataGridViewTextBoxColumn();
            balanceColumn.DataPropertyName = "SODU";
            balanceColumn.Name = "SODU";
            balanceColumn.HeaderText = "Account Balance";
            balanceColumn.Width = width * 25 / 100;
            balanceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            balanceColumn.DefaultCellStyle.Format = "##,# VND";
            data.Columns.Add(balanceColumn);

            // Tạo cột cho MACN
            DataGridViewTextBoxColumn branchColumn = new DataGridViewTextBoxColumn();
            branchColumn.DataPropertyName = "MACN";
            branchColumn.Name = "MACN";
            branchColumn.HeaderText = "MACN";
            branchColumn.Visible = false;
            data.Columns.Add(branchColumn);
        }

        private void loadDataTable(string account = "", string CMND = "")
        {
            string filterExpression = "";
            if (!string.IsNullOrEmpty(account))
            {
                filterExpression += $"SOTK <> '{account}'";
            }
            if (!string.IsNullOrEmpty(CMND))
            {
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    filterExpression += " AND ";
                }
                filterExpression += $"CMND = '{CMND}'";
            }

            DataRow[] filteredRows = dtAccountOrigin.Select(filterExpression);
            dtAccount = dtAccountOrigin.Clone();
            Debug.WriteLine("Numof row: " + filteredRows.Length);
            foreach (DataRow row in filteredRows)
            {
                dtAccount.ImportRow(row);
            }

            loadDataGridView();
        }

        private void loadSendInformation(DataGridViewRow row)
        {
            if (row == null || row.Cells.Count < 4)
                return;

            try
            {
                txtSendAccount.Text = row.Cells["SOTK"].Value?.ToString();
                txtSendCMND.Text = row.Cells["CMND"].Value?.ToString();
                txtSendName.Text = row.Cells["HOTEN"].Value?.ToString();

                if (decimal.TryParse(row.Cells["SODU"].Value?.ToString(), out decimal balance))
                {
                    txtBalance.Text = balance.ToString("#,##0") + " VND";
                }
                else
                {
                    txtBalance.Text = "0 VND"; // Giá trị mặc định nếu không thể chuyển đổi
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void loadRecieveInformation(DataGridViewRow row)
        {
            if (row == null || row.Cells.Count < 4)
                return;

            txtRecieveAccount.Text = row.Cells["SOTK"].ToString();
            txtRecieveCMND.Text = row.Cells["CMND"].ToString();
            txtRecieveName.Text = row.Cells["HOTEN"].ToString();
        }

        private void stateChange(int state)
        {
            switch (state)
            {
                case 0: //Choossing send account
                    lblNotification.Text = "CHOOSE SEND ACCOUNT";
                    cbxCustomer.Text = "";
                    break;
                case 1: //Choossing recieve account
                    lblNotification.Text = "CHOOSE RECIEVE ACCOUNT";
                    cbxCustomer.Text = "";
                    loadDataTable(account: txtSendAccount.Text, CMND: cbxCustomer.Text);
                    break;
                case 2:
                    break;
                default:
                    MessageBox.Show("State error!");
                    break;
            } 
        }

        private void cbxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CMND = cbxCustomer.Text;
            loadDataTable(txtSendAccount.Text, CMND);
            Debug.WriteLine("cbx change");
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            cbxCustomer.Text = "";
            loadDataTable(txtSendAccount.Text);
            Debug.WriteLine("btn showall change");
        }

        private void data_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = null;
            if (data.SelectedRows.Count > 0) 
            { 
                row = data.SelectedRows[0]; 
            }
            else
            {
                return;
            }
            switch (state)
            {
                case 0:
                    isLoading = true;
                    loadSendInformation(row);
                    break;
                case 1:
                    loadRecieveInformation(row);
                    break;
                default:
                    break;
            }
        }
    }
}
