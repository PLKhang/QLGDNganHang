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
    public partial class frmEmployee : Form
    {
        private DataTable dt;
        public frmEmployee()
        {
            InitializeComponent();
            Debug.WriteLine("Constructor: " + data.Width);
            frmEmployee_Load();
        }

        private void frmEmployee_Load()
        {
            dt = Program.ExecStoredProcedureReturnTable("select MANV, HO, TEN, CMND, PHAI, SODT, MACN, TRANGTHAIXOA from dbo.NHANVIEN");
            data.AutoGenerateColumns = false;

            btnReload.PerformClick();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        //manv(15,mid), ho (30, left), ten(15, left), CMND(15, mid), phai(10, mid), sdt(15, mid) -> 100%
        private void loadDataGridView()
        {
            int panelWidth = data.Width - 35;
            Debug.WriteLine("Load: " + data.Width);
            data.Columns.Clear();

            // Tạo cột cho MANV
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "MANV";
            idColumn.HeaderText = "Employee ID";
            idColumn.Width = panelWidth * 15 / 100;
            idColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(idColumn);

            // Tạo cột cho HO
            DataGridViewTextBoxColumn lastNameColumn = new DataGridViewTextBoxColumn();
            lastNameColumn.DataPropertyName = "HO";
            lastNameColumn.HeaderText = "Last name";
            lastNameColumn.Width = panelWidth * 30 / 100;
            lastNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            data.Columns.Add(lastNameColumn);

            // Tạo cột cho TEN
            DataGridViewTextBoxColumn firstNameColumn = new DataGridViewTextBoxColumn();
            firstNameColumn.DataPropertyName = "TEN";
            firstNameColumn.HeaderText = "First name";
            firstNameColumn.Width = panelWidth * 15 / 100;
            firstNameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            data.Columns.Add(firstNameColumn);

            // Tạo cột cho CMND
            DataGridViewTextBoxColumn cmndColumn = new DataGridViewTextBoxColumn();
            cmndColumn.DataPropertyName = "CMND";
            cmndColumn.HeaderText = "ID Card";
            cmndColumn.Width = panelWidth * 15 / 100;
            cmndColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(cmndColumn);

            // Tạo cột cho PHAI
            DataGridViewTextBoxColumn genderColumn = new DataGridViewTextBoxColumn();
            genderColumn.DataPropertyName = "PHAI";
            genderColumn.HeaderText = "Gender";
            genderColumn.Width = panelWidth * 10 / 100;
            genderColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(genderColumn);

            // Tạo cột cho SODT
            DataGridViewTextBoxColumn phoneColumn = new DataGridViewTextBoxColumn();
            phoneColumn.DataPropertyName = "SODT";
            phoneColumn.HeaderText = "Phone number";
            phoneColumn.Width = panelWidth * 15 / 100;
            phoneColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            data.Columns.Add(phoneColumn);
        }

        private void btnReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Debug.WriteLine("Button reload clicked: width = " + data.Width);
            try
            {
                // Thực hiện lấy dữ liệu từ stored procedure vào DataTable
                dt = Program.ExecStoredProcedureReturnTable("select MANV, HO, TEN, CMND, PHAI, SODT, MACN, TRANGTHAIXOA from dbo.NHANVIEN");

                // Gán lại DataSource cho DataGridView
                data.DataSource = null; // Reset DataSource trước khi gán lại
                data.DataSource = dt;

                // Gọi lại loadDataGridView để thiết lập lại kích thước cột
                loadDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reloading data: " + ex.Message);
                // Xử lý ngoại lệ hoặc ghi log ở đây
            }
        }
    }
}
