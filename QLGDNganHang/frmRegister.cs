﻿using DevExpress.XtraBars.ViewInfo;
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
    public partial class frmRegister : Form
    {
        private string loginName;
        private string password;
        private string username;
        private string specialUsername;
        private DataTable dt = new DataTable();
        private DataTable dtLoginName = new DataTable();
        private bool isShowingPassword = true;
        private bool checkLoginName = false, checkPassword = false, checkConfirmPassword = false;
        private bool isSpecialAccountCreate = false;
        public frmRegister()
        {
            InitializeComponent();
        }

        public frmRegister(string username)
        {
            InitializeComponent();

            this.isSpecialAccountCreate = true;
            this.specialUsername = username;
            this.cbxUsername.Enabled = false;

        }
        private void frmRegister_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            dt = Program.ExecStoredProcedureReturnTable("SELECT * FROM V_EX_LoginName");
            dtLoginName = Program.ExecStoredProcedureReturnTable("SELECT * FROM DBO.V_LOGINNAME");

            int index = 0;
            cbxUsername.DataSource = dt;
            cbxUsername.DisplayMember = "MANV";
            cbxUsername.ValueMember = "MANV";
            cbxUsername.DropDownStyle = ComboBoxStyle.DropDownList;
            if (isSpecialAccountCreate)
            {
                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["MANV"].ToString() == specialUsername)
                    {
                        index = i;
                        break;
                    }
                    i++; 
                }
            }
            cbxUsername.SelectedIndex = index;

            txtRole.Text = Program.mRole;

            txtCMND.Text = dt.Rows[cbxUsername.SelectedIndex]["CMND"].ToString();
            txtFullName.Text = dt.Rows[cbxUsername.SelectedIndex]["HOTEN"].ToString();
            txtPhoneNumber.Text = dt.Rows[cbxUsername.SelectedIndex]["SODT"].ToString();
        }
        private bool IsExistedLoginName(string loginName)
        {
            foreach (DataRow row in dtLoginName.Rows)
            {
                if (loginName.Equals(row["LoginName"].ToString()))
                { 
                    return true;
                }
            }
            return false;
        }


        private void txtLoginName_TextChanged(object sender, EventArgs e)
        {
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text.Length == 0)
            {
                lblConfirmPasswordError.ForeColor = Color.Red;
                lblConfirmPasswordError.Text = "Enter this area!";
                checkConfirmPassword = false;
            }else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                lblConfirmPasswordError.ForeColor = Color.Red;
                lblConfirmPasswordError.Text = "You should enter the same Password";
                checkConfirmPassword = false;
            }
            else
            {
                lblConfirmPasswordError.ForeColor = Color.Green;
                lblConfirmPasswordError.Text = "✅";
                checkConfirmPassword = true;
            }

            if (txtPassword.Text.Length == 0)
            {
                lblPasswordError.ForeColor = Color.Red;
                lblPasswordError.Text = "Enter this area!";
                checkPassword = false;
            }
            else
            {
                lblPasswordError.ForeColor = Color.Green;
                lblPasswordError.Text = "✅";
                checkPassword = true;
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text.Length == 0)
            {
                lblConfirmPasswordError.ForeColor = Color.Red;
                lblConfirmPasswordError.Text = "Enter this area!";
                checkConfirmPassword = false;
            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                lblConfirmPasswordError.ForeColor = Color.Red;
                lblConfirmPasswordError.Text = "You should enter the same Password";
                checkConfirmPassword = false;
            }
            else
            {
                lblConfirmPasswordError.ForeColor = Color.Green;
                lblConfirmPasswordError.Text = "✅";
                checkConfirmPassword = true;
            }
        }

        private void cbxUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCMND.Text = dt.Rows[cbxUsername.SelectedIndex]["CMND"].ToString();
            txtFullName.Text = dt.Rows[cbxUsername.SelectedIndex]["HOTEN"].ToString();
            txtPhoneNumber.Text = dt.Rows[cbxUsername.SelectedIndex]["SODT"].ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            isShowingPassword = !isShowingPassword;
            txtPassword.UseSystemPasswordChar = isShowingPassword;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Program.ValidateKeyPress(e.KeyChar))
            { e.Handled = true; }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(checkLoginName && checkPassword && checkConfirmPassword)
            {
                loginName = txtLoginName.Text;
                password = txtPassword.Text;
                username = cbxUsername.Text;
                if (MessageBox.Show("Do you want to create this login account?", "CONFIRM!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        Program.CreateLoginToSystem(loginName, username, password, Program.mRole);
                        MessageBox.Show($"This login account has been created!\nLoginName: {loginName}\nUsername: {username}\n", "SUCCESS!", MessageBoxButtons.OK);
                        if (isSpecialAccountCreate)
                        {
                            btnExit.PerformClick();
                            return;
                        }
                        
                        //Refresh form
                        dtLoginName.Rows.Add(loginName);
                        dt.Rows.RemoveAt(cbxUsername.SelectedIndex);
                        cbxUsername_SelectedIndexChanged(sender, new EventArgs());
                        txtLoginName.Text = txtPassword.Text = txtConfirmPassword.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can not create login!\n" + ex.Message, "ERROR!", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Your should complete your form to CONFIRM!");
            }
        }
    }
}
