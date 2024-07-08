using DevExpress.CodeParser;
using DevExpress.Data.Helpers;
using DevExpress.Pdf.Native.BouncyCastle.Utilities;
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
        private DataTable dt;
        private int currentBranch = Program.currentBranch;
        private string currentLogin = Program.mLoginName;
        private string currentPassword = Program.mPassword;
        private int currentRow = 0;
        private bool clickReload = false;
        private bool isEditInfo = false;
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
            /*if (Program.mRole == "ChiNhanh")
            {
                cbxBranch.Enabled = false;
            }*/

            dt = Program.ExecStoredProcedureReturnTable("select MANV, HO, TEN, CMND, PHAI, SODT, DIACHI, TRANGTHAIXOA as TTX from dbo.NHANVIEN");
            data.AutoGenerateColumns = false;
            data.DataSource = dt;

            cbxBranch.DataSource = Program.bds;
            cbxBranch.DisplayMember = "TENCN";
            cbxBranch.ValueMember = "TENSERVER";
            cbxBranch.SelectedIndex = currentBranch;
            cbxBranch.DropDownStyle = ComboBoxStyle.DropDownList;

            loadDataGridView();
        }

        private void unenableEditInfo()
        {
            txtFirstName.ReadOnly = txtLastName.ReadOnly = txtID.ReadOnly
                = txtCMND.ReadOnly = txtPhone.ReadOnly = txtAddress.ReadOnly = true; 

            cbxGender.Enabled = false;

            btnCancel.Visible = btnSave.Visible = false;
            data.Enabled = true;
        }

        private void enableEditInfo()
        {
            txtFirstName.ReadOnly = txtLastName.ReadOnly 
                = txtCMND.ReadOnly = txtPhone.ReadOnly = txtAddress.ReadOnly = false;

            cbxGender.Enabled = true;
            List<string> gender = new List<string>() { "Nam", "Nữ" };
            cbxGender.DataSource = gender;
            cbxGender.SelectedIndex = 0;
            cbxGender.DropDownStyle = ComboBoxStyle.DropDownList;

            btnCancel.Visible = btnSave.Visible = true;
            data.Enabled = false;
        }

        private void deletePanelInfo()
        {
            txtCMND.Text = txtFirstName.Text = txtLastName.Text = txtPhone.Text = txtAddress.Text = cbxGender.Text = "";
            txtStatus.Text = "ACTIVE";
            txtStatus.BackColor = Color.LightGreen;
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

        //manv(15,mid), ho (30, left), ten(15, left), CMND(15, mid), phai(10, mid), sdt(15, mid) -> 100%
        private void loadDataGridView()
        {
            int panelWidth = data.Width - 40;
            data.Columns.Clear();

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
            Debug.WriteLine(txtID.Text);
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
                                    MessageBox.Show("Can not delete login of this employee!\nError exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            MessageBox.Show($"This employee's status have set to \'ACTIVE\'!\nEmployee ID: {ID}", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Error exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Program.Connect();
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
                this.loadInfomation(row);
                
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
            if (MessageBox.Show(notification, "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
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
                    MessageBox.Show("Error exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Error exporting report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.enableEditInfo();
            this.btnReload.PerformClick();
        }
    }
}
