using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Filtering.Internal;

namespace QLGDNganHang
{
    public partial class frmTransfer : Form
    {
        private int state = 0;
        private DataTable dtCustomer = new DataTable(); 
        private DataTable dtAccountOrigin = new DataTable();
        private DataTable dtAccount = new DataTable();

        public frmTransfer()
        {
            InitializeComponent();
        }

        public frmTransfer(string account)
        {
            InitializeComponent();

            state = 2;
            foreach (DataGridViewRow row in data.Rows)
            {
                if (row.Cells["SOTK"].Value.ToString() == account)
                {
                    loadSendInformation(row);
                    break;
                }
            }
            loadDataTable(account);
        }

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.txtEmployeeID.Text = Program.mUsername;

            dtCustomer = Program.ExecStoredProcedureReturnTable("Select CMND from dbo.V_DanhSachKhachHang_NganHang");
            dtAccountOrigin = Program.ExecStoredProcedureReturnTable("Select SOTK, CMND, HOTEN, SODU from dbo.V_TaiKhoanKhachHang");
            dtAccount = dtAccountOrigin.Copy();
            data.AutoGenerateColumns = false;

            cbxCustomer.DataSource = dtCustomer;
            cbxCustomer.DisplayMember = "CMND";
            cbxCustomer.ValueMember = "CMND";

            btnShowAll.PerformClick();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (state != 0)
            {
                if (MessageBox.Show("Do you want to exit?\nYour incomplete transaction will be deleted!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
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
            {
                txtSendAccount.Text = "";    
                txtSendCMND.Text = "";
                txtSendName.Text = "";
                txtBalance.Text = "";
                return;
            }

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


        private void loadReceiveInformation(DataGridViewRow row)
        {
            if (row == null || row.Cells.Count < 4)
            {
                txtReceiveAccount.Text = "";
                txtReceiveCMND.Text = "";
                txtReceiveName.Text = "";
                return;
            }

            txtReceiveAccount.Text = row.Cells["SOTK"].Value?.ToString();
            txtReceiveCMND.Text = row.Cells["CMND"].Value?.ToString();
            txtReceiveName.Text = row.Cells["HOTEN"].Value?.ToString();

            if(txtReceiveAccount.Text == txtSendAccount.Text)
            {
                MessageBox.Show("The sending and receiving accounts must be different!");
            }
        }

        private void stateChange(int state)
        {
            switch (state)
            {
                case 0:
                    lblNotification.Text = "PRESS \"CHOOSE\" SEND ACCOUNT";
                    loadSendInformation(null);
                    loadReceiveInformation(null);
                    break;
                case 1: //Choossing send account
                    lblNotification.Text = "CHOOSE SEND ACCOUNT";
                    loadDataTable(account: txtReceiveAccount.Text, cbxCustomer.Text);
                    break;
                case 2: //Choossing receive account
                    lblNotification.Text = "CHOOSE RECEIVE ACCOUNT";
                    loadDataTable(account: txtSendAccount.Text, cbxCustomer.Text);
                    break;
                default:
                    MessageBox.Show("State error!");
                    break;
            } 
        }

        private void cbxCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CMND = cbxCustomer.Text;
            loadDataTable("", CMND);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            cbxCustomer.Text = "";
            loadDataTable();
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
                    break;
                case 1:
                    loadSendInformation(row);
                    break;
                case 2:
                    loadReceiveInformation(row);
                    break;
                default:
                    MessageBox.Show("State error!");
                    break;
            }
        }

        private void btnSendInfo_Click(object sender, EventArgs e)
        {
            state = 1;
            stateChange(state);
        }

        private void btnReceiveInfo_Click(object sender, EventArgs e)
        {
            state = 2;
            stateChange(state);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (state == 0)
            {
                return;
            }
            string sendAccount = txtSendAccount.Text;
            string receiveAccount = txtReceiveAccount.Text;
            long sendBalance = Convert.ToInt64(txtBalance.Text.Replace(" VND", "").Replace(",", ""));
            long amount = Convert.ToInt64(txtAmount.Text.Replace(",", ""));

            if (string.IsNullOrEmpty(sendAccount) || string.IsNullOrEmpty(receiveAccount))
            {
                MessageBox.Show("Please choose both the sending and receiving accounts before confirming!");
                return;
            }
            if (sendAccount == receiveAccount)
            {
                MessageBox.Show("The sending and receiving accounts must be different!");
                return;
            }
            if (sendBalance < amount)
            {
                MessageBox.Show("The sending account balance is insufficient!");
                return;
            }

            int result = 0;
            string notification = $"Confirm transaction:\nSending account: {sendAccount}\nRecieve account: {receiveAccount}\nAmount: {txtAmount.Text} VND";
            if (MessageBox.Show(notification, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    result = Program.ExecStoredProcedureReturnInt("sp_ChuyenTien", new SqlParameter("STKGUI", sendAccount),
                        new SqlParameter("STKNHAN", receiveAccount),
                        new SqlParameter("TIEN", amount),
                        new SqlParameter("NGAYGD", DateTime.Now),
                        new SqlParameter("MANV", Program.mUsername));
                    if (result == 0)
                    {
                        MessageBox.Show("Transaction successful!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        btnReload.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Transaction Failed!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:\n" + ex.Message, ex.InnerException.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            state = 0;
            stateChange(state);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnClear.PerformClick();

            dtCustomer = Program.ExecStoredProcedureReturnTable("Select CMND from dbo.V_DanhSachKhachHang_NganHang");
            dtAccountOrigin = Program.ExecStoredProcedureReturnTable("Select SOTK, CMND, HOTEN, SODU from dbo.V_TaiKhoanKhachHang");

            btnShowAll.PerformClick();
        }
    }
}
