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
        //test current password to change
        private SqlConnection tempConnection = new SqlConnection();

        //login info: login name, username
        private DataTable dt_login;

        private DataTable dtCustomerOrigin;
        private DataTable dtAccountOrigin;
        private DataTable dtCustomer;
        private DataTable dtAccount;
        
        //save current row, sort state to reload
        private bool clickReload = false;
        private int currentRow = 0;
        private string sortedColumnName;
        private System.Windows.Forms.SortOrder sortedOrder;

        private bool isOpenPanelAccount = false;
        private bool isOpenPanelInfo = false;
        private bool isOpenPanelLogin = false;
        private bool isEditCustomer = false;
        private bool isAddAccount = false;

        private bool isChangePassword = false;
        private bool isCreateLogin = false;
        private string currentLogin = Program.mLoginName;
        private string currentPassword = Program.mPassword;
        private bool checkPassword = false, checkNewPassword = false, checkConfirmPassword = false, checkLoginName = false;

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            unenablelEditCustomerInformation();
            hidePanelAccount();
            hidePanelLogin();
            if (Program.mRole == "NganHang")
            {
                roleNganHang();
            }

            

            dtCustomerOrigin = Program.ExecStoredProcedureReturnTable("select CMND, HO, TEN, PHAI, SODT, MACN, NGAYCAP, DIACHI from dbo.V_DanhSachKhachHang_NganHang");
            dtAccountOrigin = Program.ExecStoredProcedureReturnTable("select SOTK, CMND, SODU from dbo.V_TaiKhoanKhachHang");

            dtCustomer = dtCustomerOrigin.Copy();
            dtAccount = dtAccountOrigin.Copy();

            data.AutoGenerateColumns = false;
            dataAccount.AutoGenerateColumns = false;

            cbxCMND.DataSource = dtCustomerOrigin;
            cbxCMND.DisplayMember = "CMND";
            cbxCMND.ValueMember = "CMND";

            List<string> gender = new List<string>() { "Nam", "Nữ" };
            cbxGender.DataSource = gender;
            cbxGender.DropDownStyle = ComboBoxStyle.DropDownList;

            btnShowAll.PerformClick();
        }

        public int TryConnect(string loginName, string password)
        {
            if (tempConnection != null && tempConnection.State == ConnectionState.Open)
            {
                tempConnection.Close();
            }
            try
            {
                string connectionString = "Data Source=" + Program.serverName + ";Initial Catalog=" + Program.databaseName + ";User ID=" + loginName + ";Password=" + password;
                tempConnection.ConnectionString = connectionString;
                tempConnection.Open();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        
        private void roleNganHang()
        {
            btnAdd.Enabled = btnAddAccount.Enabled = btnEdit.Enabled = btnDelete.Enabled = btnLoginInfo.Enabled
                = btnTransfer.Enabled = btnTransaction.Enabled = btnUndo.Enabled = false;
        }

        private void showPanelAccount()
        {
            label5.Visible = label6.Visible = label7.Visible = label9.Visible = false;
            pickerDateIssue.Visible = cbxGender.Visible = txtPhone.Visible = txtAddress.Visible = false;
            if (Program.mRole != "NganHang")
            {
                btnAdd.Enabled = btnEdit.Enabled = btnLoginInfo.Enabled = btnReload.Enabled = btnBankAccount.Enabled = false;
            }
            pnlAccount.Visible = true;
            isOpenPanelAccount = true;
            unenabelEditAccount();
            loadDataAccount(txtCMND.Text);
        }

        private void hidePanelAccount()
        {
            label5.Visible = label6.Visible = label7.Visible = label9.Visible = true;
            pickerDateIssue.Visible = cbxGender.Visible = txtPhone.Visible = txtAddress.Visible = true;
            if (Program.mRole != "NganHang")
            { 
                btnAdd.Enabled = btnEdit.Enabled = btnLoginInfo.Enabled = btnReload.Enabled = btnBankAccount.Enabled = true;
            }
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
                txtFirstName.Text = row.Cells["TEN"].Value.ToString();
                txtLastName.Text = row.Cells["HO"].Value.ToString();
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
            txtBalance.Value = 0;
        }

        private void enabelEditAccount()
        {
            isAddAccount = true;

            label8.Visible = label10.Visible = txtAccount.Visible = txtBalance.Visible = true;

            btnSaveAccount.Visible = btnCancelAccount.Visible = true;

            if (Program.mRole != "NganHang")
            {
                btnTransfer.Enabled = btnAddAccount.Enabled = btnDeleteAccount.Enabled = btnTransaction.Enabled = btnReloadAccount.Enabled = false;
            }

            dataAccount.Enabled = false;
        }

        private void showPanelLogin()
        {
            btnAdd.Enabled = btnEdit.Enabled = btnLoginInfo.Enabled = btnReload.Enabled = btnBankAccount.Enabled = false;

            pnlLogin.Visible = isOpenPanelLogin = true;
            loadDataCustomer("", Program.branchID);
        }

        private void hidePanelLogin()
        {
            btnAdd.Enabled = btnEdit.Enabled = btnLoginInfo.Enabled = btnReload.Enabled = btnBankAccount.Enabled = true;

            pnlLogin.Visible = isOpenPanelLogin = false;
        }

        private void createLoginAccount()
        {
            btnSaveLogin.Visible = btnCancelLogin.Visible = true;
            txtLoginName.ReadOnly = false;

            btnSaveLogin.Text = "CREATE";
            lblLoginNote.Text = "CREATE LOGIN ACCOUNT FOR CUSTOMER";
            lblNewPw.Text = "Password:";

            txtNewPw.Text = txtConfirmNewPw.Text = lblConfirmPasswordError.Text = lblNewPasswordError.Text = "";

            lblCrrPw.Visible = txtCurrentPw.Visible = false;

            isCreateLogin = true; 
            isChangePassword = false;
        }

        private void changeLoginPassword()
        {
            btnSaveLogin.Visible = btnCancelLogin.Visible = true;
            btnSaveLogin.Text = "CHANGE";
            txtLoginName.ReadOnly = true;

            lblLoginNote.Text = "CHANGE PASSWORD FOR LOGIN ACCOUNT";
            lblNewPw.Text = "New Password:";

            txtNewPw.Text = txtConfirmNewPw.Text = lblConfirmPasswordError.Text = lblNewPasswordError.Text = "";

            lblCrrPw.Visible = txtCurrentPw.Visible = true;

            isChangePassword = true;
            isCreateLogin = false;
        }

        private void unenabelEditAccount()
        {
            isAddAccount = false;

            label8.Visible = label10.Visible = txtAccount.Visible = txtBalance.Visible = false;

            btnSaveAccount.Visible = btnCancelAccount.Visible = false;

            if (Program.mRole != "NganHang")
            {
                btnTransfer.Enabled = btnAddAccount.Enabled = btnDeleteAccount.Enabled = btnTransaction.Enabled = btnReloadAccount.Enabled = true;
            }

            dataAccount.Enabled = true;
        }

        private void loadDataCustomer(string CMND = "", string branch = "")
        {
            string filterExpression = "";

            if (!string.IsNullOrEmpty(CMND))
            {
                filterExpression += $"CMND = '{CMND}'";
            }

            if (!string.IsNullOrEmpty(branch))
            {
                if (!string.IsNullOrEmpty(CMND))
                {
                    filterExpression += " AND ";
                }

                filterExpression += $"MACN = '{branch}'";
            }

            DataRow[] filteredRows = dtCustomerOrigin.Select(filterExpression);
            dtCustomer = dtCustomerOrigin.Clone();

            foreach (DataRow row in filteredRows)
            {
                dtCustomer.ImportRow(row);
            }
            
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
            
            loadAccountGridView();
        }

        private void loadLoginInfo(string CMND)
        {
            if (string.IsNullOrEmpty(CMND))
                return;

            try
            {
                DataRow foundRow = null;
                foreach (DataRow currentRow in dt_login.Rows)
                {
                    if (currentRow["UserName"].ToString() == CMND)
                    {
                        foundRow = currentRow;
                        break;
                    }
                }
                if (foundRow != null)
                {
                    changeLoginPassword();
                    txtLoginName.Text = foundRow[0].ToString();
                }
                else
                {
                    createLoginAccount();
                    txtLoginName.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
            showPanelLogin();
            dt_login = Program.ExecStoredProcedureReturnTable("Select * from dbo.V_AllLoginName");
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clickReload = true;
            SaveSortState();
            dtCustomerOrigin = Program.ExecStoredProcedureReturnTable("select CMND, HO, TEN, PHAI, SODT, MACN, NGAYCAP, DIACHI from dbo.V_DanhSachKhachHang_NganHang");
            dt_login = Program.ExecStoredProcedureReturnTable("Select * from dbo.V_AllLoginName");

            loadDataCustomer(cbxCMND.Text);

            if (currentRow >= 0 && currentRow < data.Rows.Count)
            {
                data.CurrentCell = data.Rows[currentRow].Cells[0];
            }

            ApplySortState();
            clickReload = false;
        }

        private void SaveSortState()
        {
            if (data.SortedColumn != null)
            {
                sortedColumnName = data.SortedColumn.Name;
                sortedOrder = data.SortOrder;
            }
            else
            {
                sortedColumnName = null;
            }
        }

        private void ApplySortState()
        {
            if (!string.IsNullOrEmpty(sortedColumnName))
            {
                DataGridViewColumn sortedColumn = data.Columns[sortedColumnName];
                ListSortDirection direction = sortedOrder == System.Windows.Forms.SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;
                data.Sort(sortedColumn, direction);
            }
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
            string newAddress = txtAddress.Text;
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
                        MessageBox.Show("Customer has been created!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Can not create customer!\nError: " + ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void updateCustomer(string oldCMND)
        {
            string newCMND = txtCMND.Text;
            string newFname = txtFirstName.Text;
            string newLname = txtLastName.Text;
            string newAddress = txtAddress.Text;
            string newPhone = txtPhone.Text;
            DateTime newDateIssue = pickerDateIssue.Value.Date;
            string newGender = cbxGender.Text;

            try
            {
                int result = Program.ExecStoredProcedureReturnInt("sp_SuaThongTinKH",
                    new SqlParameter("HO", newLname),
                    new SqlParameter("TEN", newFname),
                    new SqlParameter("DIACHI", newAddress),
                    new SqlParameter("newCMND", newCMND),
                    new SqlParameter("oldCMND", oldCMND),
                    new SqlParameter("NGAYCAP", newDateIssue),
                    new SqlParameter("SODT", newPhone),
                    new SqlParameter("PHAI", newGender));

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
                MessageBox.Show("Can not update information!\nError: " + ex.Message, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DataGridViewRow row = null;

            if (dataAccount.SelectedRows.Count > 0)
            {
                row = dataAccount.SelectedRows[0];
            }

            if (row == null)
            {
                MessageBox.Show("Click to an account before begin transfer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmTransfer form = new frmTransfer(row.Cells["SOTK"].Value.ToString());
            form.ShowDialog();

            loadDataAccount(txtCMND.Text);
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = null;

            if (dataAccount.SelectedRows.Count > 0)
            {
                row = dataAccount.SelectedRows[0];
            }

            if (row == null)
            {
                MessageBox.Show("Click to an account before begin transfer!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmTransaction form = new frmTransaction(row.Cells["SOTK"].Value.ToString());
            form.ShowDialog();

            loadDataAccount(txtCMND.Text);
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
            if (isOpenPanelLogin)
            {
                loadDataCustomer("", Program.branchID);
            }
            else 
            { 
                loadDataCustomer();
            }
        }

        private void cbxCMND_SelectedIndexChanged(object sender, EventArgs e)
        {
            string CMND = cbxCMND.Text;
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

            if (isOpenPanelLogin)
            {
                loadLoginInfo(row.Cells["CMND"].Value.ToString());
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
            if (!this.clickReload)
                this.currentRow = data.Rows.IndexOf(row);
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
            else
            {
                resetAccountInformation();
                unenabelEditAccount();
                data.Enabled = true;

                btnReloadAccount.PerformClick();
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

        private void btnSaveLogin_Click(object sender, EventArgs e)
        {
            string loginName = txtLoginName.Text;
            string currentPassword = txtCurrentPw.Text;
            string newPassword = txtNewPw.Text;
            string confirmPassword = txtConfirmNewPw.Text;
            string username = txtCMND.Text;

            if (isChangePassword)
            {
                if (!(checkNewPassword && checkConfirmPassword))
                {
                    MessageBox.Show("Complete all password to continue!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (this.TryConnect(loginName, currentPassword) == 1)
                {
                    
                    tempConnection.Close();
                    Program.mLoginName = this.currentLogin;
                    Program.mPassword = this.currentPassword;
                    Program.Connect();

                    string notification = $"Are you sure to change this account's password?\nLogin name: {loginName}\nUsername: {username}";
                    if (MessageBox.Show(notification, "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Program.ExecStoredProcedureReturnDataReader($"EXEC ChangePassword '{loginName}', '{newPassword}'");
                    }
                    btnCancelLogin.PerformClick();
                }
                else
                {
                    MessageBox.Show("Your current password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (!(checkPassword && checkNewPassword && checkConfirmPassword && checkLoginName))
                {
                    MessageBox.Show("Complete all password to continue!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                loginName = txtLoginName.Text;
                username = txtCMND.Text;
                if (MessageBox.Show($"Do you want to create this login account?\nLoginName: {loginName}\nUsername: {username}", "CONFIRM!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    try
                    {
                        Program.CreateLoginToSystem(loginName, username, newPassword, "KhachHang");
                        MessageBox.Show($"This login account has been created!\nLoginName: {loginName}\nUsername: {username}\n", "SUCCESS!", MessageBoxButtons.OK);

                        //Refresh form
                        dt_login.Rows.Add(loginName);
                        btnCancelLogin.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can not create login!\n" + ex.Message, "ERROR!", MessageBoxButtons.OK);
                    }
                }
            }

        }

        private bool IsExistedLoginName(string loginName)
        {
            foreach (DataRow row in dt_login.Rows)
            {
                if (loginName.Equals(row["LoginName"].ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnCancelLogin_Click(object sender, EventArgs e)
        {
            hidePanelLogin();
            btnReload.PerformClick();
        }

        private void txtLoginName_TextChanged(object sender, EventArgs e)
        {
            if (isChangePassword)
            {
                lblLoginNameError.Text = "";
                return;
            }
            if (txtLoginName.Text.Length == 0)
            {
                lblLoginNameError.ForeColor = Color.Red;
                lblLoginNameError.Text = "Enter this area!";
                checkLoginName = false;
            }
            else if (IsExistedLoginName(txtLoginName.Text))
            {
                lblLoginNameError.ForeColor = Color.Red;
                lblLoginNameError.Text = "This login name have been existed!";
                checkLoginName = false;
            }
            else
            {
                lblLoginNameError.ForeColor = Color.Green;
                lblLoginNameError.Text = "✅";
                checkLoginName = true;
            }
        }

        private void txtCurrentPw_TextChanged(object sender, EventArgs e)
        {
            if (txtCurrentPw.Text.Length == 0)
            {
                lblPasswordError.ForeColor = Color.Red;
                lblPasswordError.Text = "❎";
                checkPassword = false;
            }
            else
            {
                lblPasswordError.ForeColor = Color.Green;
                lblPasswordError.Text = "✅";
                checkPassword = true;
            }
        }

        private void txtNewPw_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmNewPw.Text.Length == 0)
            {
                lblConfirmPasswordError.ForeColor = Color.Red;
                lblConfirmPasswordError.Text = "❎";
                checkConfirmPassword = false;
            }
            else if (txtConfirmNewPw.Text != txtNewPw.Text)
            {
                lblConfirmPasswordError.ForeColor = Color.Red;
                lblConfirmPasswordError.Text = "❎";
                checkConfirmPassword = false;
            }
            else
            {
                lblConfirmPasswordError.ForeColor = Color.Green;
                lblConfirmPasswordError.Text = "✅";
                checkConfirmPassword = true;
            }

            if (txtNewPw.Text.Length == 0)
            {
                lblNewPasswordError.ForeColor = Color.Red;
                lblNewPasswordError.Text = "❎";
                checkNewPassword = false;
            }
            else
            {
                lblNewPasswordError.ForeColor = Color.Green;
                lblNewPasswordError.Text = "✅";
                checkNewPassword = true;
            }
        }

        private void btnStatement_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = null;

            if (dataAccount.SelectedRows.Count > 0)
            {
                row = dataAccount.SelectedRows[0];
            }

            if (row == null)
            {
                MessageBox.Show("Click to an account before begin statment!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frptAccountStatement form = new frptAccountStatement(row.Cells["SOTK"].Value.ToString());
            form.ShowDialog();

            loadDataAccount(txtCMND.Text);
        }

        private void txtConfirmNewPw_TextChanged(object sender, EventArgs e)
        {
            if (txtNewPw.Text.Length == 0)
            {
                lblNewPasswordError.ForeColor = Color.Red;
                lblNewPasswordError.Text = "❎";
                checkNewPassword = false;
            }
            else
            {
                lblNewPasswordError.ForeColor = Color.Green;
                lblNewPasswordError.Text = "✅";
                checkNewPassword = true;
            }

            if (txtConfirmNewPw.Text.Length == 0)
            {
                lblConfirmPasswordError.ForeColor = Color.Red;
                lblConfirmPasswordError.Text = "❎";
                checkConfirmPassword = false;
            }
            else if (txtConfirmNewPw.Text != txtNewPw.Text)
            {
                lblConfirmPasswordError.ForeColor = Color.Red;
                lblConfirmPasswordError.Text = "❎";
                checkConfirmPassword = false;
            }
            else
            {
                lblConfirmPasswordError.ForeColor = Color.Green;
                lblConfirmPasswordError.Text = "✅";
                checkConfirmPassword = true;
            }
        }

        private void txtCurrentPw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Program.ValidateKeyPress(e.KeyChar))
            { e.Handled = true; }
        }
    }
}
