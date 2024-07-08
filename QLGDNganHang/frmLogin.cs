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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.MinimizeBox = false;     // Ẩn nút Minimize
            this.MaximizeBox = false;     // Ẩn nút Maximize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            cbxBranchs.DataSource = Program.bds;
            cbxBranchs.DisplayMember = "TENCN";
            cbxBranchs.ValueMember = "TENSERVER";
            cbxBranchs.SelectedIndex = 0;
            cbxBranchs.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string loginName = Program.mLoginName = txtLoginName.Text;
            string password = Program.mPassword = txtPassword.Text;

            if (loginName.Trim() == "" || password.Trim() == "")
            {
                MessageBox.Show("You should enter your \'Login name\' and \'Password\' before clicking \'LOGIN\'","Login Fail!",MessageBoxButtons.OK);
                return;
            }

            Program.serverName = cbxBranchs.SelectedValue.ToString();
            if(Program.Connect() == 0)
            {
                return;
            }

            Program.sqlDataReader = Program.ExecStoredProcedureReturnDataReader($"Exec sp_LayThongTinLogin @TENLOGIN = {loginName}");
            if (Program.sqlDataReader == null || !Program.sqlDataReader.HasRows)
            {
                MessageBox.Show("Your account has no access to this system", "Login Fail!", MessageBoxButtons.OK);
                return;
            }

            try
            {
                Program.sqlDataReader.Read();
                string username = Program.sqlDataReader.GetString(0);
                string name = Program.sqlDataReader.GetString(1);
                string role = Program.sqlDataReader.GetString(2);
                Program.sqlDataReader.Close();

                Program.Login(loginName, username, name, role);
                Program.currentBranch = cbxBranchs.SelectedIndex;

                Program.main.lblUsername.Text += username;
                Program.main.lblName.Text += name;
                Program.main.lblRole.Text += role;
            } 
            catch 
            { 
                MessageBox.Show("Your account has no access to this system", "Login Fail!", MessageBoxButtons.OK);
                return;
            }

            Program.main.reloadForm(Program.mRole);
            this.Close();
        }
    }
}
