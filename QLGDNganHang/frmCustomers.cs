using DevExpress.Charts.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLGDNganHang
{
    public partial class frmCustomers : Form
    {
        private DataTable dtCustomerOrigin;
        private DataTable dtAccountOrigin;
        private DataTable dtCustomer;
        private DataTable dtAccount;
        private bool isOpenPanelAccount = false;
        private bool isEditCustomer = false;
        private bool isAddAccount = false;
        
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            hidePanelAccount();
            unenablelEditCustomerInformation();

            dtCustomerOrigin = Program.ExecStoredProcedureReturnTable("select CMND, HO, TEN, PHAI, SODT, MACN, NGAYCAP, DIACHI from dbo.V_DanhSachKhachHang_NganHang");
            dtAccountOrigin = Program.ExecStoredProcedureReturnTable("select SOTK, CMND, SODU from dbo.V_TaiKhoanKhachHang");

            dtCustomer = dtCustomerOrigin.Copy();
            dtAccount = dtAccountOrigin.Copy();

            data.AutoGenerateColumns = false;
            dataAccount.AutoGenerateColumns = false;

            cbxCMND.DataSource = dtCustomerOrigin;
            cbxCMND.DisplayMember = "CMND";
            cbxCMND.ValueMember = "CMND";

            btnShowAll.PerformClick();
        }

        private void loadAccounts()
        {

        }

        private void showPanelAccount()
        {
            label5.Visible = label6.Visible = label7.Visible = label9.Visible = false;
            pickerDateIssue.Visible = cbxGender.Visible = txtPhone.Visible = txtAddress.Visible = false;

            btnAdd.Enabled = btnEdit.Enabled = btnLoginInfo.Enabled = btnReload.Enabled = btnBankAccount.Enabled = false;

            pnlAccount.Visible = true;
            isOpenPanelAccount = true;
            unenabelEditAccount();
            loadDataAccount(txtCMND.Text);
        }

        private void hidePanelAccount()
        {
            label5.Visible = label6.Visible = label7.Visible = label9.Visible = true;
            pickerDateIssue.Visible = cbxGender.Visible = txtPhone.Visible = txtAddress.Visible = true;
            
            btnAdd.Enabled = btnEdit.Enabled = btnLoginInfo.Enabled = btnReload.Enabled = btnBankAccount.Enabled = true;
            
            pnlAccount.Visible = false;
            isOpenPanelAccount = false;
        }

        private void loadCustomerInformation(DataGridViewRow row)
        {
            if (row == null || row.Cells.Count < 8)
            {
                resetCustomerInformation();
                return;
            }

            try
            {
                txtFirstName.Text = row.Cells["HO"].Value.ToString();
                txtLastName.Text = row.Cells["TEN"].Value.ToString();
                txtCMND.Text = row.Cells["CMND"].Value.ToString();
                cbxGender.Text = row.Cells["PHAI"].Value.ToString();
                txtPhone.Text = row.Cells["SODT"].Value.ToString();
                txtAddress.Text = row.Cells["DIACHI"].Value.ToString();
                pickerDateIssue.Text = row.Cells["NGAYCAP"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void loadAccountInformation(DataGridViewRow row)
        {
            if (row == null || row.Cells.Count < 3)
            {
                resetAccountInformation();
                return;
            }
            try
            {
                txtAccount.Text = row.Cells["SOTK"].Value.ToString();
                txtBalance.Value = Decimal.Parse(row.Cells["SODU"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void resetCustomerInformation()
        {
            txtFirstName.Text = txtLastName.Text = txtCMND.Text
                = cbxGender.Text = txtPhone.Text = txtAddress.Text = "";

            pickerDateIssue.Value = DateTime.Now;
        }

        private void unenablelEditCustomerInformation()
        {
            txtFirstName.ReadOnly = txtLastName.ReadOnly = txtCMND.ReadOnly
                = txtAddress.ReadOnly = txtPhone.ReadOnly = true;

            pickerDateIssue.Enabled = cbxGender.Enabled = false;

            btnSave.Visible = btnCancel.Visible = false;

            btnAdd.Enabled = btnEdit.Enabled = btnLoginInfo.Enabled = btnReload.Enabled = btnBankAccount.Enabled = true;

            data.Enabled = true;
        }

        private void enableEditCustomerInformation()
        {
            txtFirstName.ReadOnly = txtLastName.ReadOnly = txtCMND.ReadOnly
                = txtAddress.ReadOnly = txtPhone.ReadOnly = false;

            pickerDateIssue.Enabled = cbxGender.Enabled = true;

            btnSave.Visible = btnCancel.Visible = true;

            btnAdd.Enabled = btnEdit.Enabled = btnLoginInfo.Enabled = btnReload.Enabled = btnBankAccount.Enabled = false;

            data.Enabled = false;
        }

        private void resetAccountInformation()
        {
            txtAccount.Text = "";
            txtBalance.ResetText();
        }

        private void enabelEditAccount()
        {
            isAddAccount = true;
            txtAccount.ReadOnly = txtBalance.ReadOnly = false;

            btnSaveAccount.Visible = btnCancelAccount.Visible = true;

            btnTransfer.Enabled = btnAddAccount.Enabled = btnDeleteAccount.Enabled = btnTransaction.Enabled = btnReloadAccount.Enabled = false;

            dataAccount.Enabled = false;
        }

        private void unenabelEditAccount()
        {
            isAddAccount = false;

            txtAccount.ReadOnly = txtBalance.ReadOnly = true;

            btnSaveAccount.Visible = btnCancelAccount.Visible = false;

            btnTransfer.Enabled = btnAddAccount.Enabled = btnDeleteAccount.Enabled = btnTransaction.Enabled = btnReloadAccount.Enabled = true;

            dataAccount.Enabled = true;
        }

        private void loadDataCustomer(string CMND = "")
        {
            string filterExpression = "";

            if (!string.IsNullOrEmpty(CMND))
            {
                filterExpression += $"CMND = '{CMND}'";
            }

            DataRow[] filteredRows = dtCustomerOrigin.Select(filterExpression);
            dtCustomer = dtCustomerOrigin.Clone();

            foreach (DataRow row in filteredRows)
            {
                dtCustomer.ImportRow(row);
            }
            Debug.WriteLine(filteredRows.Length);
            loadCustomerGridView();
        }

        private void loadDataAccount(string CMND)
        {
            string filterExpression = $"CMND = '{CMND}'";

            DataRow[] filteredRows = dtAccountOrigin.Select(filterExpression);
            dtAccount = dtAccountOrigin.Clone();

            foreach (DataRow row in filteredRows)
            {
                dtAccount.ImportRow(row);
            }
            Debug.WriteLine("CMND:" + CMND + "|find: " + filteredRows.Length);
            loadAccountGridView();
        }

        private void loadCustomerGridView()
        {
            data.DataSource = dtCustomer;
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

            // Tạo cột cho CMND
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "CMND";
            idColumn.Name = "CMND";
            idColumn.HeaderText = "Customer's CMND";
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(idColumn);

            // Tạo cột cho HO
            DataGridViewTextBoxColumn lastNameColumn = new DataGridViewTextBoxColumn();
            lastNameColumn.DataPropertyName = "HO";
            lastNameColumn.Name = "HO";
            lastNameColumn.HeaderText = "Last Name";
            lastNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            data.Columns.Add(lastNameColumn);

            // Tạo cột cho TEN
            DataGridViewTextBoxColumn firstNameColumn = new DataGridViewTextBoxColumn();
            firstNameColumn.DataPropertyName = "TEN";
            firstNameColumn.Name = "TEN";
            firstNameColumn.HeaderText = "First Name";
            firstNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            data.Columns.Add(firstNameColumn);

            // Tạo cột cho PHAI
            DataGridViewTextBoxColumn genderColumn = new DataGridViewTextBoxColumn();
            genderColumn.DataPropertyName = "PHAI";
            genderColumn.Name = "PHAI";
            genderColumn.HeaderText = "Gender";
            genderColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(genderColumn);

            // Tạo cột cho SODT
            DataGridViewTextBoxColumn phoneColumn = new DataGridViewTextBoxColumn();
            phoneColumn.DataPropertyName = "SODT";
            phoneColumn.Name = "SODT";
            phoneColumn.HeaderText = "Phone number";
            phoneColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            data.Columns.Add(phoneColumn);

            // Tạo cột cho MACN
            DataGridViewTextBoxColumn branchColumn = new DataGridViewTextBoxColumn();
            branchColumn.DataPropertyName = "MACN"; // Tên cột trong DataTable
            branchColumn.Name = "MACN";
            branchColumn.HeaderText = "Branch";
            branchColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(branchColumn);

            // Tạo cột cho DIACHI
            DataGridViewTextBoxColumn addressColumn = new DataGridViewTextBoxColumn();
            addressColumn.DataPropertyName = "DIACHI"; // Tên cột trong DataTable
            addressColumn.Name = "DIACHI";
            addressColumn.Visible = false; // Ẩn cột
            data.Columns.Add(addressColumn);

            // Tạo cột cho DIACHI
            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.DataPropertyName = "NGAYCAP"; // Tên cột trong DataTable
            dateColumn.Name = "NGAYCAP";
            dateColumn.Visible = false; // Ẩn cột
            data.Columns.Add(dateColumn);
        }

        private void loadAccountGridView()
        {
            dataAccount.DataSource = dtAccount;
            dataAccount.Columns.Clear();

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataAccount.ColumnHeadersHeight = 35;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataAccount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataAccount.DefaultCellStyle = dataGridViewCellStyle2;

            // Tạo cột cho SOTK
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "SOTK";
            idColumn.Name = "SOTK";
            idColumn.HeaderText = "Account Number";
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataAccount.Columns.Add(idColumn);

            // Tạo cột cho CMND
            DataGridViewTextBoxColumn CMNDColumn = new DataGridViewTextBoxColumn();
            CMNDColumn.DataPropertyName = "CMND";
            CMNDColumn.Name = "CMND";
            CMNDColumn.HeaderText = "Customer's CMND";
            CMNDColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataAccount.Columns.Add(CMNDColumn);

            // Tạo cột cho SODU
            DataGridViewTextBoxColumn balanceColumn = new DataGridViewTextBoxColumn();
            balanceColumn.DataPropertyName = "SODU";
            balanceColumn.Name = "SODU";
            balanceColumn.HeaderText = "Account Balance";
            balanceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            balanceColumn.DefaultCellStyle.Format = "##,# VND";
            dataAccount.Columns.Add(balanceColumn);
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEditCustomerInformation();
            resetCustomerInformation();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            enableEditCustomerInformation();
            isEditCustomer = true;
        }

        private void btnLoginInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // ------------------
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            dtCustomerOrigin = Program.ExecStoredProcedureReturnTable("select CMND, HO, TEN, PHAI, SODT, MACN, NGAYCAP, DIACHI from dbo.V_DanhSachKhachHang_NganHang");
            
            loadDataCustomer();
            btnShowAll.PerformClick();
        }

        private void btnUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // pass
        }

        private void btnBankAccount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showPanelAccount();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (isEditCustomer || isAddAccount)
            {
                if (MessageBox.Show("Do you want to exit?\nYour processing will be deleted!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEditCustomer)
            {
                this.updateCustomer(data.SelectedRows[0].Cells["CMND"].Value.ToString());
                return;
            }

            string newCMND = txtCMND.Text;
            string newFname = txtFirstName.Text;
            string newLname = txtLastName.Text;
            string newAddress = txtAccount.Text;
            string newPhone = txtPhone.Text;
            DateTime newDateIssue = pickerDateIssue.Value.Date;
            string newGender = cbxGender.Text;

            try
            {
                int result = Program.ExecStoredProcedureReturnInt("sp_ThemKH",
                    new SqlParameter("CMND", newCMND),
                    new SqlParameter("HO", newLname),
                    new SqlParameter("TEN", newFname),
                    new SqlParameter("SODT", newPhone),
                    new SqlParameter("PHAI", newGender),
                    new SqlParameter("NGAYCAP", newDateIssue),
                    new SqlParameter("DIACHI", newAddress));

                switch (result)
                {
                    case 0:
                        MessageBox.Show("This customer's information have been updated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isEditCustomer = false;
                        unenablelEditCustomerInformation();
                        btnReload.PerformClick();
                        break;
                    case 1:
                        MessageBox.Show("Can not create bank account!\nThis customer's CMND does not exist!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Some error in SqlServer!");
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not create bank account!\nError: " + ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void updateCustomer(string oldCMND)
        {
            string newCMND = txtCMND.Text;
            string newFname = txtFirstName.Text;
            string newLname = txtLastName.Text;
            string newAddress = txtAccount.Text;
            string newPhone = txtPhone.Text;
            DateTime newDateIssue = pickerDateIssue.Value.Date;
            string newGender = cbxGender.Text;

            try
            {
                int result = Program.ExecStoredProcedureReturnInt("sp_SuaThongTinKH", new SqlParameter("oldCMND", oldCMND),
                    new SqlParameter("newCMND", newCMND),
                    new SqlParameter("HO", newLname),
                    new SqlParameter("TEN", newFname),
                    new SqlParameter("SODT", newPhone),
                    new SqlParameter("PHAI", newGender),
                    new SqlParameter("NGAYCAP", newDateIssue),
                    new SqlParameter("DIACHI", newAddress));

                switch (result)
                {
                    case 0:
                        MessageBox.Show("This customer's information have been updated!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isEditCustomer = false;
                        unenabelEditAccount();
                        btnReload.PerformClick();
                        break;
                    case 1:
                        MessageBox.Show("Can not create bank account!\nThis customer's CMND does not exist!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Some error in SqlServer!");
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not create bank account!\nError: " + ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to cancel?\nYour processing will be deleted!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                resetCustomerInformation();
                unenablelEditCustomerInformation();

                isEditCustomer = false;

                btnReload.PerformClick();
            }
        }

        private void btnExitAccount_Click(object sender, EventArgs e)
        {
            if (isAddAccount)
            {
                if (MessageBox.Show("Do you want to exit?\nYour processing will be deleted!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    isAddAccount = false;
                    data.Enabled = true;
                    hidePanelAccount();
                }
            }
            else
            {
                hidePanelAccount();
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            //----------------------------
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            //---------------------------
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can not delete bank account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCMND.Text))
            {
                MessageBox.Show("Choose customer before create bank account");
                return;
            }
            enabelEditAccount();
            data.Enabled = false;

            resetAccountInformation();
            txtAccount.Text = Program.ExecStoredProcedureReturnString("EXEC sp_TaoSTK");
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            cbxCMND.Text = "";
            loadDataCustomer();
        }

        private void cbxCMND_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CMND = cbxCMND.Text;
            Debug.WriteLine("CMND: "+ CMND);
            loadDataCustomer(CMND); 
        }

        private void btnReloadAccount_Click(object sender, EventArgs e)
        {
            dtAccountOrigin = Program.ExecStoredProcedureReturnTable("select SOTK, CMND, SODU from dbo.V_TaiKhoanKhachHang");

            loadDataAccount(txtCMND.Text);
        }

        private void data_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = null;
            if (data.SelectedRows.Count > 0)
            {
                row = data.SelectedRows[0];
            }

            if (isOpenPanelAccount)
            {
                loadDataAccount(row.Cells["CMND"].Value.ToString());
            }
            loadCustomerInformation(row);
        }

        private void dataAccount_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = null;
            if (dataAccount.SelectedRows.Count > 0)
            {
                row = dataAccount.SelectedRows[0];
            }

            loadAccountInformation(row);
        }

        private void btnCancelAccount_Click(object sender, EventArgs e)
        {
            if (isAddAccount)
            {
                if (MessageBox.Show("Do you want to cancel?\nYour processing will be deleted!", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    resetAccountInformation();
                    unenabelEditAccount();
                    data.Enabled = true;

                    btnReloadAccount.PerformClick();
                }
            }
        }

        private void btnSaveAccount_Click(object sender, EventArgs e)
        {
            string CMND = txtCMND.Text;
            string account = txtAccount.Text;
            long balance = Convert.ToInt64(txtBalance.Text.Replace(",", ""));

            try
            {
                int result = Program.ExecStoredProcedureReturnInt("sp_TaoTK_KH", new SqlParameter("SOTK", account),
                    new SqlParameter("CMND", CMND),
                    new SqlParameter("SODU", balance),
                    new SqlParameter("NGAYMOTK", DateTime.Now),
                    new SqlParameter("MACN", Program.branchID));
                switch (result)
                {
                    case 0:
                        MessageBox.Show("This bank account have been created!");
                        isAddAccount = false;
                        data.Enabled = true;
                        btnCancelAccount.PerformClick();
                        break;
                    case 1:
                        MessageBox.Show("Can not create bank account!\nThis customer's CMND does not exist!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        MessageBox.Show("Some error in SqlServer!");
                        break;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Can not create bank account!\nError: " + ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
