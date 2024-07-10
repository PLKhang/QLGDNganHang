using DevExpress.CodeParser;
using DevExpress.Data.Helpers;
using DevExpress.Pdf.Native.BouncyCastle.Utilities;
using DevExpress.Utils.MVVM.Services;
using DevExpress.XtraEditors.Controls;
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
    public partial class frmEmployee : Form
    {
        private SqlConnection tempConnection = new SqlConnection();
        private DataTable dt;
        private DataTable dt_login;
        private int currentBranch = Program.currentBranch;
        private int currentRow = 0; // reload datagridview
        private string currentLogin = Program.mLoginName;
        private string currentPassword = Program.mPassword;
        private bool clickReload = false;
        private bool isEditInfo = false;
        private bool isEditLoginInfo = false;
        private bool checkPassword = false, checkNewPassword = false, checkConfirmPassword = false;
        private string sortedColumnName;
        private System.Windows.Forms.SortOrder sortedOrder;
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.unenableEditInfo();
            this.unenableLoginInfo();
            if (Program.mRole == "ChiNhanh")
            {
                cbxBranch.Enabled = btnLoad.Enabled = false;
            }
            else
            {
                this.roleNganHang();
            }

            dt = Program.ExecStoredProcedureReturnTable("select MANV, HO, TEN, CMND, PHAI, SODT, DIACHI, TRANGTHAIXOA as TTX from dbo.NHANVIEN");
            data.AutoGenerateColumns = false;
            data.DataSource = dt;

            cbxBranch.DataSource = Program.bds;
            cbxBranch.DisplayMember = "TENCN";
            cbxBranch.ValueMember = "TENSERVER";
            cbxBranch.SelectedIndex = currentBranch;
            cbxBranch.DropDownStyle = ComboBoxStyle.DropDownList;

            List<string> gender = new List<string>() { "Nam", "Nữ" };
            cbxGender.DataSource = gender;
            cbxGender.DropDownStyle = ComboBoxStyle.DropDownList;

            loadDataGridView();
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
            btnAdd.Enabled = btnDelete.Enabled = btnUndoDelete.Enabled = btnEdit.Enabled
                = btnTransfer.Enabled = btnLoginInfo.Enabled 
                = btnUndo.Enabled = false;
        }

        private void unenableEditInfo()
        {
            txtFirstName.ReadOnly = txtLastName.ReadOnly = txtID.ReadOnly
                = txtCMND.ReadOnly = txtPhone.ReadOnly = txtAddress.ReadOnly = true;
            btnAdd.Enabled = btnDelete.Enabled = btnUndoDelete.Enabled = btnEdit.Enabled
                = btnTransfer.Enabled = btnReload.Enabled = btnLoginInfo.Enabled = true;

            cbxGender.Enabled = false;

            btnCancel.Visible = btnSave.Visible = false;
            data.Enabled = true;

            this.isEditInfo = false;
        }

        private void enableEditInfo()
        {
            txtFirstName.ReadOnly = txtLastName.ReadOnly 
                = txtCMND.ReadOnly = txtPhone.ReadOnly = txtAddress.ReadOnly = false;
            btnAdd.Enabled = btnDelete.Enabled = btnUndoDelete.Enabled = btnEdit.Enabled
                = btnTransfer.Enabled = btnReload.Enabled = btnLoginInfo.Enabled = false;

            cbxGender.Enabled = true;

            btnCancel.Visible = btnSave.Visible = true;
            data.Enabled = false;

            this.isEditInfo = true;
        }

        private void deletePanelInfo()
        {
            txtCMND.Text = txtFirstName.Text = txtLastName.Text = txtPhone.Text = txtAddress.Text = cbxGender.Text = "";
            txtStatus.Text = "ACTIVE";
            txtStatus.BackColor = Color.LightGreen;
        }

        private void enableLoginInfo()
        {
            btnAdd.Enabled = btnDelete.Enabled = btnUndoDelete.Enabled = btnEdit.Enabled
                = btnTransfer.Enabled = btnReload.Enabled = btnLoginInfo.Enabled = false;
            lblStatus.Visible = lblID.Visible = lblFname.Visible = lblLname.Visible
                = lblCMND.Visible = lblGender.Visible = lblAddress.Visible = lblPhone.Visible = false;
            lblLoginName.Visible = lblID1.Visible = lblUsername.Visible = lblNote.Visible
                = lblCrrPw.Visible = lblNewPw.Visible = lblConfirmNewPw.Visible = true;
            txtFirstName.Visible = txtLastName.Visible = txtStatus.Visible = txtID.Visible
                = txtCMND.Visible = txtPhone.Visible = txtAddress.Visible = cbxGender.Visible = false;
            txtLoginName.Visible = txtUsername.Visible = txtID1.Visible
                = txtNewPw.Visible = txtCurrentPw.Visible = txtConfirmNewPw.Visible = true;
            btnChangePassword.Visible = btnDeleteLogin.Visible = btnCancelPnlLoginInfo.Visible = true;
            this.isEditLoginInfo = true;
        }

        private void unenableLoginInfo()
        {
            btnAdd.Enabled = btnDelete.Enabled = btnUndoDelete.Enabled = btnEdit.Enabled
                = btnTransfer.Enabled = btnReload.Enabled = btnLoginInfo.Enabled = true;
            lblStatus.Visible = lblID.Visible = lblFname.Visible = lblLname.Visible
                = lblCMND.Visible = lblGender.Visible = lblAddress.Visible = lblPhone.Visible = true;
            lblLoginName.Visible = lblID1.Visible = lblUsername.Visible = lblNote.Visible
                = lblCrrPw.Visible = lblNewPw.Visible = lblConfirmNewPw.Visible = false;
            txtFirstName.Visible = txtLastName.Visible = txtStatus.Visible = txtID.Visible
                = txtCMND.Visible = txtPhone.Visible = txtAddress.Visible = cbxGender.Visible = true;
            txtLoginName.Visible = txtUsername.Visible = txtID1.Visible
                = txtNewPw.Visible = txtCurrentPw.Visible = txtConfirmNewPw.Visible = false;
            btnChangePassword.Visible = btnDeleteLogin.Visible = btnCancelPnlLoginInfo.Visible = false;
            this.isEditLoginInfo = false;
        }

        private void loadInfomation(DataGridViewRow row)
        {
            if (row == null || row.Cells.Count < 8)
                return;
            try
            {
                int inactive = int.Parse(row.Cells["TTX"].Value?.ToString());
                txtStatus.Text = (inactive == 1) ? "INACTIVE" : "ACTIVE";
                txtStatus.BackColor = (inactive == 1) ? Color.Red : Color.LightGreen;

                txtID.Text = row.Cells["MANV"].Value?.ToString();
                txtCMND.Text = row.Cells["CMND"].Value?.ToString();
                txtFirstName.Text = row.Cells["TEN"].Value?.ToString();
                txtLastName.Text = row.Cells["HO"].Value?.ToString();
                txtPhone.Text = row.Cells["SODT"].Value?.ToString();
                cbxGender.Text = row.Cells["PHAI"].Value?.ToString();
                txtAddress.Text = row.Cells["DIACHI"].Value?.ToString();

            }
            catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void loadLoginInfo(DataGridViewRow row)
        {
            if (row == null || row.Cells.Count < 8)
                return;
            string username = row.Cells["MANV"].Value?.ToString();
            try
            {
                DataRow foundRow = null;
                foreach (DataRow currentRow in dt_login.Rows)
                {
                    if (currentRow["UserName"].ToString() == username)
                    {
                        foundRow = currentRow;
                        break;
                    }
                }
                if (foundRow != null)
                {
                    txtLoginName.Text = foundRow[0].ToString();
                    txtID1.Text = txtUsername.Text = username;
                }
                else
                {
                    txtID1.Text = txtUsername.Text = txtLoginName.Text = "";
                    string notification = $"Employee ID {username} doesn't have a login account yet!\nDo you want to create one?";
                    
                    if (row.Cells["TTX"].Value?.ToString() == "1")
                    {
                        MessageBox.Show("INACTIVE employee don't have login account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else if (MessageBox.Show(notification, "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        frmRegister form = new frmRegister(username);
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //manv(15,mid), ho (25, left), ten(15, left), CMND(15, mid), phai(10, mid), sdt(15, mid), ttx(5, mid) -> 100%
        private void loadDataGridView()
        {
            int panelWidth = data.Width - 40;
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

            // Tạo cột cho MANV
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "MANV";
            idColumn.Name = "MANV";
            idColumn.HeaderText = "Employee ID";
            idColumn.Width = panelWidth * 15 / 100;
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(idColumn);

            // Tạo cột cho CMND
            DataGridViewTextBoxColumn cmndColumn = new DataGridViewTextBoxColumn();
            cmndColumn.DataPropertyName = "CMND";
            cmndColumn.Name = "CMND";
            cmndColumn.HeaderText = "ID Card";
            cmndColumn.Width = panelWidth * 15 / 100;
            cmndColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(cmndColumn);

            // Tạo cột cho HO
            DataGridViewTextBoxColumn lastNameColumn = new DataGridViewTextBoxColumn();
            lastNameColumn.DataPropertyName = "HO";
            lastNameColumn.Name = "HO";
            lastNameColumn.HeaderText = "Last name";
            lastNameColumn.Width = panelWidth * 25 / 100;
            lastNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            data.Columns.Add(lastNameColumn);

            // Tạo cột cho TEN
            DataGridViewTextBoxColumn firstNameColumn = new DataGridViewTextBoxColumn();
            firstNameColumn.DataPropertyName = "TEN";
            firstNameColumn.Name = "TEN";
            firstNameColumn.HeaderText = "First name";
            firstNameColumn.Width = panelWidth * 15 / 100;
            firstNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            data.Columns.Add(firstNameColumn);

            // Tạo cột cho PHAI
            DataGridViewTextBoxColumn genderColumn = new DataGridViewTextBoxColumn();
            genderColumn.DataPropertyName = "PHAI";
            genderColumn.Name = "PHAI";
            genderColumn.HeaderText = "Gender";
            genderColumn.Width = panelWidth * 10 / 100;
            genderColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(genderColumn);

            // Tạo cột cho SODT
            DataGridViewTextBoxColumn phoneColumn = new DataGridViewTextBoxColumn();
            phoneColumn.DataPropertyName = "SODT";
            phoneColumn.Name = "SODT";
            phoneColumn.HeaderText = "Phone number";
            phoneColumn.Width = panelWidth * 15 / 100;
            phoneColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(phoneColumn);

            Debug.WriteLine("format ttx");
            // Tạo cột cho TTX
            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.DataPropertyName = "TTX"; // Tên cột trong DataTable
            statusColumn.Name = "TTX";
            statusColumn.HeaderText = "Status";
            statusColumn.Width = panelWidth * 5 / 100;
            statusColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(statusColumn);

            // Tạo cột cho DIACHI
            DataGridViewTextBoxColumn addressColumn = new DataGridViewTextBoxColumn();
            addressColumn.DataPropertyName = "DIACHI"; // Tên cột trong DataTable
            addressColumn.Name = "DIACHI";
            addressColumn.Visible = false; // Ẩn cột
            data.Columns.Add(addressColumn);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.clickReload = true;
            this.SaveSortState();
            try
            {
                dt = Program.ExecStoredProcedureReturnTable("select MANV, HO, TEN, CMND, PHAI, SODT, DIACHI, TRANGTHAIXOA as TTX from dbo.NHANVIEN");
                data.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reloading data: " + ex.Message);
            }

            if (currentRow >= 0 && currentRow < data.Rows.Count)
            {
                data.CurrentCell = data.Rows[currentRow].Cells[0];
            }
            this.ApplySortState();
            this.clickReload = false;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.enableEditInfo();
            this.deletePanelInfo();
            
            txtID.Text = Program.ExecStoredProcedureReturnString("sp_TaoMANV");
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ID = data.SelectedRows[0].Cells["MANV"].Value.ToString();
            if (data.SelectedRows[0].Cells["TTX"].Value.ToString() == "1")
            {
                MessageBox.Show($"Can not delete an \'INACTIVE\' employee!\nEmployee ID: {ID}", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ID == Program.mUsername)
            {
                MessageBox.Show($"Can not delete yourself!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (MessageBox.Show($"Are you sure to delete this employee?\nEmployee ID: {ID}", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    int result = Program.ExecStoredProcedureReturnInt("sp_XoaNV", new SqlParameter("MANV", ID));
                    switch (result)
                    {
                        case 0:
                            MessageBox.Show($"This employee's status have set to \'INACTIVE\'!\nEmployee ID: {ID}", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Program.ExecStoredProcedureReturnInt("sp_Existed_Username", new SqlParameter("Username", ID)) == 1)
                                try
                                {
                                    Program.ExecStoredProcedureReturnDataReader($"EXEC sp_XoaLogin @USRNAME = {ID}");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Can not delete login of this employee!\nError : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            btnReload.PerformClick();
                            break;
                        case 1:
                            MessageBox.Show($"This employee haven't been existed!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 2:
                            MessageBox.Show($"This employee have been deleted before!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        default:
                            MessageBox.Show($"Some error in SqlServer!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUndoDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ID = data.SelectedRows[0].Cells["MANV"].Value.ToString();
            if (data.SelectedRows[0].Cells["TTX"].Value.ToString() == "0")
            {
                MessageBox.Show($"Can not undo delete  \'ACTIVE\' employee!\nEmployee ID: {ID}", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (MessageBox.Show($"Are you sure to undo delete this employee?\nEmployee ID: {ID}", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    int result = Program.ExecStoredProcedureReturnInt("sp_HuyXoaNV", new SqlParameter("MANV", ID));
                    switch (result)
                    {
                        case 0:
                            MessageBox.Show($"This employee's status have set to \'ACTIVE\'!\nEmployee ID: {ID}", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnReload.PerformClick();
                            break;
                        case 1:
                            MessageBox.Show($"This employee haven't been existed!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case 2:
                            MessageBox.Show($"This employee have been deleted before!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case 3:
                            MessageBox.Show($"This employee have working in an other Bank's branch!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        default:
                            MessageBox.Show($"Some error in SqlServer!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.enableEditInfo();
            this.btnSave.Text = "UPDATE";
        }

        private void btnLoginInfo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.enableLoginInfo();

            dt_login = Program.ExecStoredProcedureReturnTable("Select * from dbo.V_AllLoginName");

        }

        private void btnTransfer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string ID = data.SelectedRows[0].Cells["MANV"].Value.ToString();
            if (data.SelectedRows[0].Cells["TTX"].Value.ToString() == "1")
            {
                MessageBox.Show($"Can not move an \'INACTIVE\' employee to anothers Bank's branches!\nEmployee ID: {ID}", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ID == Program.mUsername)
            {
                MessageBox.Show($"Can not move yourself to another Bank's branches!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to transfer this employee to another bank branch?\nEmployee ID: {ID}", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    int result = Program.ExecStoredProcedureReturnInt("sp_ChuyenChiNhanh", new SqlParameter("MANV", ID));
                    switch (result)
                    {
                        case 0:
                            MessageBox.Show($"This employee's status have set to \'INACTIVE\'!\nEmployee ID: {ID}", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Program.ExecStoredProcedureReturnInt("sp_Existed_Username", new SqlParameter("Username", ID)) == 1)
                                try
                                {
                                    Program.ExecStoredProcedureReturnDataReader($"EXEC sp_XoaLogin @USRNAME = {ID}");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Can not delete login of this employee!\nError exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            btnReload.PerformClick();
                            break;
                        case 1:
                            MessageBox.Show($"This employee haven't been existed!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case 2:
                            MessageBox.Show($"This employee have been deleted before!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        default:
                            MessageBox.Show($"Some error in SqlServer!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.btnReload.PerformClick();
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void cbxBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBranch.SelectedIndex != currentBranch)
            {
                Program.mLoginName = Program.remoteLogin;
                Program.mPassword = Program.remotePassword;
            }
            else
            {
                Program.mLoginName = currentLogin;
                Program.mPassword = currentPassword;
            }
            Program.serverName = cbxBranch.SelectedValue.ToString();
            if (Program.Connect() == 1)
            {
                btnReload.PerformClick();
            }
        }

        private void data_SelectionChanged(object sender, EventArgs e)
        {
            if (data.SelectedRows.Count > 0)
            {
                DataGridViewRow row = data.SelectedRows[0];
                if (this.isEditLoginInfo)
                {
                    this.loadLoginInfo(row);
                }
                else
                {
                    this.loadInfomation(row);
                }
                
                if (!this.clickReload)
                this.currentRow = data.Rows.IndexOf(row);
            }
        }

        private void data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (data.Rows.Count > 0 && data.Columns.Count > 0)
            {
                // Kiểm tra xem có đúng là cột "TTX" không
                DataGridViewColumn column = data.Columns["TTX"];
                if (column != null && e.ColumnIndex == column.Index)
                {
                    if (e.Value != null)
                    {
                        if (e.Value.ToString() == "1")
                        {
                            e.Value = "INACTIVE";
                        }
                        else
                        {
                            e.Value = "ACTIVE";
                        }
                        e.FormattingApplied = true;
                    }
                }
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.unenableEditInfo();
            btnReload.PerformClick();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string phoneNumber = txtPhone.Text;
            string address = txtAddress.Text;
            string gender = cbxGender.Text;
            string CMND = txtCMND.Text;
            string notification = $"Do you want to add this employee?\nEmployeeID: {ID}\nName: {lastName + " " + firstName}\n";
            if (isEditInfo)
            {
                updateEmployeeInfo(ID, firstName, lastName, phoneNumber, address, gender, CMND);
            }
            else if (MessageBox.Show(notification, "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    int result = Program.ExecStoredProcedureReturnInt("sp_ThemNV", new SqlParameter("CMND", CMND),
                        new SqlParameter("HO", lastName),
                        new SqlParameter("TEN", firstName),
                        new SqlParameter("PHAI", gender),
                        new SqlParameter("SODT", phoneNumber),
                        new SqlParameter("DIACHI", address));
                    switch (result)
                    {
                        case 0:
                            notification = $"Add successful!\nEmployeeID: {ID}\nName: {lastName + " " + firstName}";
                            MessageBox.Show(notification, "SUCCESS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 1:
                            MessageBox.Show($"Can not add this employee!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        default:
                            MessageBox.Show($"Some error in SqlServer!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.unenableEditInfo();
            btnReload.PerformClick();
        }
        
        private void updateEmployeeInfo(string ID, string firstName, string lastName, string phoneNumber, string address, string gender, string CMND)
        {
            this.btnSave.Text = "SAVE";
            string notification = $"Do you want to update infomation of this employee?\nEmployeeID: {ID}\nName: {lastName + " " + firstName}\n";
            if (MessageBox.Show(notification, "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    int result = Program.ExecStoredProcedureReturnInt("sp_SuaThongTinNV", new SqlParameter("MANV", ID), 
                        new SqlParameter("CMND", CMND),
                        new SqlParameter("HO", lastName),
                        new SqlParameter("TEN", firstName),
                        new SqlParameter("PHAI", gender),
                        new SqlParameter("SODT", phoneNumber),
                        new SqlParameter("DIACHI", address));
                    switch (result)
                    {
                        case 0:
                            notification = $"Update successful!\nEmployeeID: {ID}\nName: {lastName + " " + firstName}";
                            MessageBox.Show(notification, "SUCCESS!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 1:
                            MessageBox.Show($"Can not update this employee!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case 2:
                            MessageBox.Show($"This CMND have been existed!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        default:
                            MessageBox.Show($"Some error in SqlServer!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string loginName = txtLoginName.Text;
            string currentPassword = txtCurrentPw.Text;
            string newPassword = txtNewPw.Text;
            string confirmPassword = txtConfirmNewPw.Text;
            if (!(checkPassword && checkNewPassword && checkConfirmPassword))
            {
                MessageBox.Show("Complete all password to continue!", "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if (this.TryConnect(loginName, currentPassword) == 1)
            {
                tempConnection.Close();
                Program.mLoginName = currentLogin;
                Program.mPassword = this.currentPassword;
                if (Program.Connect() == 1)
                {
                    btnReload.PerformClick();
                }
                string notification = $"Are you sure to change this account's password?\nLogin name: {loginName}";
                if (MessageBox.Show(notification, "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    Program.ExecStoredProcedureReturnDataReader($"EXEC ChangePassword '{loginName}', '{newPassword}'");
                    if (txtUsername.Text == Program.mUsername)
                    {
                        MessageBox.Show("Your password have been changed!\nPlease login again!");
                        Program.main.btnLogout.PerformClick();
                    }
                }
            }
            else
            {
                MessageBox.Show("Your current password is incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteLogin_Click(object sender, EventArgs e)
        {
            string username = txtID1.Text;
            Debug.WriteLine("Username: " + username + "Connection string: " + Program.connectionString);
            if (txtUsername.Text == "")
            {
                return;
            }
            if (username == Program.mUsername)
            {
                MessageBox.Show("You can not delete your login account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show($"Delete login account of Employee ID {username}?", "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    Program.ExecStoredProcedureReturnDataReader($"EXEC sp_XoaLogin @USRNAME = {username}");
                    MessageBox.Show("Login account have been deleted!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataRow foundRow = null;
                    foreach (DataRow currentRow in dt_login.Rows)
                    {
                        if (currentRow["UserName"].ToString() == username)
                        {
                            foundRow = currentRow;
                            break;
                        }
                    }
                    dt_login.Rows.Remove(foundRow);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can not delete login: \n" + ex.Message, "Fail!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelPnlLoginInfo_Click(object sender, EventArgs e)
        {
            this.unenableLoginInfo();
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
            if (txtCurrentPw.Text.Length == 0)
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

        private void txtConfirmNewPw_TextChanged(object sender, EventArgs e)
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
        }

        private void txtCurrentPw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Program.ValidateKeyPress(e.KeyChar))
            { e.Handled = true; }
        }
    }
}
