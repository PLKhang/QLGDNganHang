using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace QLGDNganHang
{
    partial class frmEmployee
    {
        public System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee));
            this.pnlEmployeeInfo = new DevExpress.XtraEditors.PanelControl();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.btnCancelPnlLoginInfo = new System.Windows.Forms.Button();
            this.btnDeleteLogin = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.lblCrrPw = new System.Windows.Forms.Label();
            this.lblNote = new System.Windows.Forms.Label();
            this.lblLoginName = new System.Windows.Forms.Label();
            this.lblConfirmNewPw = new System.Windows.Forms.Label();
            this.txtConfirmNewPw = new System.Windows.Forms.TextBox();
            this.lblNewPw = new System.Windows.Forms.Label();
            this.txtCurrentPw = new System.Windows.Forms.TextBox();
            this.txtNewPw = new System.Windows.Forms.TextBox();
            this.lblID1 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtID1 = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxGender = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.RichTextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblConfirmPasswordError = new System.Windows.Forms.Label();
            this.lblNewPasswordError = new System.Windows.Forms.Label();
            this.lblPasswordError = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblCMND = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLname = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFname = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barControl = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndoDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnLoginInfo = new DevExpress.XtraBars.BarButtonItem();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnTransfer = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlControl = new DevExpress.XtraEditors.PanelControl();
            this.cbxBranch = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.data = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmployeeInfo)).BeginInit();
            this.pnlEmployeeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).BeginInit();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlEmployeeInfo
            // 
            this.pnlEmployeeInfo.Controls.Add(this.txtLoginName);
            this.pnlEmployeeInfo.Controls.Add(this.btnCancelPnlLoginInfo);
            this.pnlEmployeeInfo.Controls.Add(this.btnDeleteLogin);
            this.pnlEmployeeInfo.Controls.Add(this.btnChangePassword);
            this.pnlEmployeeInfo.Controls.Add(this.lblCrrPw);
            this.pnlEmployeeInfo.Controls.Add(this.lblNote);
            this.pnlEmployeeInfo.Controls.Add(this.lblLoginName);
            this.pnlEmployeeInfo.Controls.Add(this.lblConfirmNewPw);
            this.pnlEmployeeInfo.Controls.Add(this.txtConfirmNewPw);
            this.pnlEmployeeInfo.Controls.Add(this.lblNewPw);
            this.pnlEmployeeInfo.Controls.Add(this.txtCurrentPw);
            this.pnlEmployeeInfo.Controls.Add(this.txtNewPw);
            this.pnlEmployeeInfo.Controls.Add(this.lblID1);
            this.pnlEmployeeInfo.Controls.Add(this.lblUsername);
            this.pnlEmployeeInfo.Controls.Add(this.txtID1);
            this.pnlEmployeeInfo.Controls.Add(this.txtUsername);
            this.pnlEmployeeInfo.Controls.Add(this.txtStatus);
            this.pnlEmployeeInfo.Controls.Add(this.btnCancel);
            this.pnlEmployeeInfo.Controls.Add(this.btnSave);
            this.pnlEmployeeInfo.Controls.Add(this.cbxGender);
            this.pnlEmployeeInfo.Controls.Add(this.txtAddress);
            this.pnlEmployeeInfo.Controls.Add(this.lblGender);
            this.pnlEmployeeInfo.Controls.Add(this.lblAddress);
            this.pnlEmployeeInfo.Controls.Add(this.lblConfirmPasswordError);
            this.pnlEmployeeInfo.Controls.Add(this.lblNewPasswordError);
            this.pnlEmployeeInfo.Controls.Add(this.lblPasswordError);
            this.pnlEmployeeInfo.Controls.Add(this.lblStatus);
            this.pnlEmployeeInfo.Controls.Add(this.lblPhone);
            this.pnlEmployeeInfo.Controls.Add(this.txtPhone);
            this.pnlEmployeeInfo.Controls.Add(this.lblID);
            this.pnlEmployeeInfo.Controls.Add(this.lblCMND);
            this.pnlEmployeeInfo.Controls.Add(this.txtLastName);
            this.pnlEmployeeInfo.Controls.Add(this.lblLname);
            this.pnlEmployeeInfo.Controls.Add(this.txtFirstName);
            this.pnlEmployeeInfo.Controls.Add(this.lblFname);
            this.pnlEmployeeInfo.Controls.Add(this.txtID);
            this.pnlEmployeeInfo.Controls.Add(this.txtCMND);
            this.pnlEmployeeInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEmployeeInfo.Location = new System.Drawing.Point(635, 40);
            this.pnlEmployeeInfo.Margin = new System.Windows.Forms.Padding(12);
            this.pnlEmployeeInfo.Name = "pnlEmployeeInfo";
            this.pnlEmployeeInfo.Size = new System.Drawing.Size(616, 688);
            this.pnlEmployeeInfo.TabIndex = 1;
            // 
            // txtLoginName
            // 
            this.txtLoginName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLoginName.Location = new System.Drawing.Point(207, 87);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.ReadOnly = true;
            this.txtLoginName.Size = new System.Drawing.Size(327, 28);
            this.txtLoginName.TabIndex = 40;
            // 
            // btnCancelPnlLoginInfo
            // 
            this.btnCancelPnlLoginInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelPnlLoginInfo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnCancelPnlLoginInfo.Location = new System.Drawing.Point(417, 501);
            this.btnCancelPnlLoginInfo.Name = "btnCancelPnlLoginInfo";
            this.btnCancelPnlLoginInfo.Size = new System.Drawing.Size(117, 47);
            this.btnCancelPnlLoginInfo.TabIndex = 39;
            this.btnCancelPnlLoginInfo.Text = "CANCEL";
            this.btnCancelPnlLoginInfo.UseVisualStyleBackColor = false;
            this.btnCancelPnlLoginInfo.Click += new System.EventHandler(this.btnCancelPnlLoginInfo_Click);
            // 
            // btnDeleteLogin
            // 
            this.btnDeleteLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnDeleteLogin.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnDeleteLogin.Location = new System.Drawing.Point(271, 501);
            this.btnDeleteLogin.Name = "btnDeleteLogin";
            this.btnDeleteLogin.Size = new System.Drawing.Size(117, 47);
            this.btnDeleteLogin.TabIndex = 37;
            this.btnDeleteLogin.Text = "DELETE";
            this.btnDeleteLogin.UseVisualStyleBackColor = false;
            this.btnDeleteLogin.Click += new System.EventHandler(this.btnDeleteLogin_Click);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnChangePassword.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnChangePassword.Location = new System.Drawing.Point(28, 501);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(144, 47);
            this.btnChangePassword.TabIndex = 38;
            this.btnChangePassword.Text = "SAVE CHANGE";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // lblCrrPw
            // 
            this.lblCrrPw.AutoSize = true;
            this.lblCrrPw.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblCrrPw.Location = new System.Drawing.Point(25, 282);
            this.lblCrrPw.Name = "lblCrrPw";
            this.lblCrrPw.Size = new System.Drawing.Size(147, 21);
            this.lblCrrPw.TabIndex = 34;
            this.lblCrrPw.Text = "Current password:";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblNote.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblNote.Location = new System.Drawing.Point(25, 19);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(567, 21);
            this.lblNote.TabIndex = 35;
            this.lblNote.Text = "YOU CAN ONLY CHANGE PASSWORD OR DELETE LOGIN ACCOUNT HERE!";
            // 
            // lblLoginName
            // 
            this.lblLoginName.AutoSize = true;
            this.lblLoginName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblLoginName.Location = new System.Drawing.Point(64, 87);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(101, 21);
            this.lblLoginName.TabIndex = 36;
            this.lblLoginName.Text = "Login name:";
            // 
            // lblConfirmNewPw
            // 
            this.lblConfirmNewPw.AutoSize = true;
            this.lblConfirmNewPw.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblConfirmNewPw.Location = new System.Drawing.Point(23, 389);
            this.lblConfirmNewPw.Name = "lblConfirmNewPw";
            this.lblConfirmNewPw.Size = new System.Drawing.Size(149, 21);
            this.lblConfirmNewPw.TabIndex = 32;
            this.lblConfirmNewPw.Text = "Confirm password:";
            // 
            // txtConfirmNewPw
            // 
            this.txtConfirmNewPw.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtConfirmNewPw.Location = new System.Drawing.Point(207, 389);
            this.txtConfirmNewPw.Name = "txtConfirmNewPw";
            this.txtConfirmNewPw.Size = new System.Drawing.Size(327, 28);
            this.txtConfirmNewPw.TabIndex = 26;
            this.txtConfirmNewPw.UseSystemPasswordChar = true;
            this.txtConfirmNewPw.TextChanged += new System.EventHandler(this.txtConfirmNewPw_TextChanged);
            this.txtConfirmNewPw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentPw_KeyPress);
            // 
            // lblNewPw
            // 
            this.lblNewPw.AutoSize = true;
            this.lblNewPw.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblNewPw.Location = new System.Drawing.Point(47, 334);
            this.lblNewPw.Name = "lblNewPw";
            this.lblNewPw.Size = new System.Drawing.Size(125, 21);
            this.lblNewPw.TabIndex = 33;
            this.lblNewPw.Text = "New password:";
            // 
            // txtCurrentPw
            // 
            this.txtCurrentPw.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCurrentPw.Location = new System.Drawing.Point(207, 282);
            this.txtCurrentPw.Name = "txtCurrentPw";
            this.txtCurrentPw.Size = new System.Drawing.Size(327, 28);
            this.txtCurrentPw.TabIndex = 27;
            this.txtCurrentPw.UseSystemPasswordChar = true;
            this.txtCurrentPw.TextChanged += new System.EventHandler(this.txtCurrentPw_TextChanged);
            this.txtCurrentPw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentPw_KeyPress);
            // 
            // txtNewPw
            // 
            this.txtNewPw.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNewPw.Location = new System.Drawing.Point(207, 334);
            this.txtNewPw.Name = "txtNewPw";
            this.txtNewPw.Size = new System.Drawing.Size(327, 28);
            this.txtNewPw.TabIndex = 28;
            this.txtNewPw.UseSystemPasswordChar = true;
            this.txtNewPw.TextChanged += new System.EventHandler(this.txtNewPw_TextChanged);
            this.txtNewPw.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentPw_KeyPress);
            // 
            // lblID1
            // 
            this.lblID1.AutoSize = true;
            this.lblID1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblID1.Location = new System.Drawing.Point(54, 137);
            this.lblID1.Name = "lblID1";
            this.lblID1.Size = new System.Drawing.Size(111, 21);
            this.lblID1.TabIndex = 31;
            this.lblID1.Text = "Employee ID:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblUsername.Location = new System.Drawing.Point(74, 189);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(91, 21);
            this.lblUsername.TabIndex = 30;
            this.lblUsername.Text = "Username:";
            // 
            // txtID1
            // 
            this.txtID1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtID1.Location = new System.Drawing.Point(207, 137);
            this.txtID1.Name = "txtID1";
            this.txtID1.ReadOnly = true;
            this.txtID1.Size = new System.Drawing.Size(327, 28);
            this.txtID1.TabIndex = 29;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtUsername.Location = new System.Drawing.Point(207, 189);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.Size = new System.Drawing.Size(327, 28);
            this.txtUsername.TabIndex = 25;
            // 
            // txtStatus
            // 
            this.txtStatus.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtStatus.Location = new System.Drawing.Point(176, 61);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(327, 28);
            this.txtStatus.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnCancel.Location = new System.Drawing.Point(386, 546);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 47);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnSave.Location = new System.Drawing.Point(240, 546);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 47);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxGender
            // 
            this.cbxGender.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbxGender.FormattingEnabled = true;
            this.cbxGender.Location = new System.Drawing.Point(176, 310);
            this.cbxGender.Name = "cbxGender";
            this.cbxGender.Size = new System.Drawing.Size(327, 29);
            this.cbxGender.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtAddress.Location = new System.Drawing.Point(176, 416);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(327, 90);
            this.txtAddress.TabIndex = 2;
            this.txtAddress.Text = "";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblGender.Location = new System.Drawing.Point(66, 310);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(69, 21);
            this.lblGender.TabIndex = 1;
            this.lblGender.Text = "Gender:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblAddress.Location = new System.Drawing.Point(59, 416);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(76, 21);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Address:";
            // 
            // lblConfirmPasswordError
            // 
            this.lblConfirmPasswordError.AutoSize = true;
            this.lblConfirmPasswordError.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblConfirmPasswordError.Location = new System.Drawing.Point(541, 392);
            this.lblConfirmPasswordError.Name = "lblConfirmPasswordError";
            this.lblConfirmPasswordError.Size = new System.Drawing.Size(0, 21);
            this.lblConfirmPasswordError.TabIndex = 1;
            // 
            // lblNewPasswordError
            // 
            this.lblNewPasswordError.AutoSize = true;
            this.lblNewPasswordError.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblNewPasswordError.Location = new System.Drawing.Point(541, 337);
            this.lblNewPasswordError.Name = "lblNewPasswordError";
            this.lblNewPasswordError.Size = new System.Drawing.Size(0, 21);
            this.lblNewPasswordError.TabIndex = 1;
            // 
            // lblPasswordError
            // 
            this.lblPasswordError.AutoSize = true;
            this.lblPasswordError.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblPasswordError.Location = new System.Drawing.Point(540, 285);
            this.lblPasswordError.Name = "lblPasswordError";
            this.lblPasswordError.Size = new System.Drawing.Size(0, 21);
            this.lblPasswordError.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblStatus.Location = new System.Drawing.Point(72, 61);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(63, 21);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblPhone.Location = new System.Drawing.Point(13, 361);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(122, 21);
            this.lblPhone.TabIndex = 1;
            this.lblPhone.Text = "Phone number:";
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPhone.Location = new System.Drawing.Point(176, 361);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(327, 28);
            this.txtPhone.TabIndex = 0;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblID.Location = new System.Drawing.Point(24, 111);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(111, 21);
            this.lblID.TabIndex = 1;
            this.lblID.Text = "Employee ID:";
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblCMND.Location = new System.Drawing.Point(73, 161);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(62, 21);
            this.lblCMND.TabIndex = 1;
            this.lblCMND.Text = "CMND:";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtLastName.Location = new System.Drawing.Point(176, 258);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(327, 28);
            this.txtLastName.TabIndex = 0;
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblLname.Location = new System.Drawing.Point(42, 258);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(93, 21);
            this.lblLname.TabIndex = 1;
            this.lblLname.Text = "Last name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFirstName.Location = new System.Drawing.Point(176, 213);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(327, 28);
            this.txtFirstName.TabIndex = 0;
            // 
            // lblFname
            // 
            this.lblFname.AutoSize = true;
            this.lblFname.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFname.Location = new System.Drawing.Point(40, 213);
            this.lblFname.Name = "lblFname";
            this.lblFname.Size = new System.Drawing.Size(95, 21);
            this.lblFname.TabIndex = 1;
            this.lblFname.Text = "First name:";
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtID.Location = new System.Drawing.Point(176, 111);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(327, 28);
            this.txtID.TabIndex = 0;
            // 
            // txtCMND
            // 
            this.txtCMND.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCMND.Location = new System.Drawing.Point(176, 161);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(327, 28);
            this.txtCMND.TabIndex = 0;
            // 
            // barManager1
            // 
            this.barManager1.AllowMoveBarOnToolbar = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barControl});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnDelete,
            this.btnEdit,
            this.btnUndoDelete,
            this.btnLoginInfo,
            this.btnReload,
            this.btnUndo,
            this.btnTransfer,
            this.btnExit});
            this.barManager1.MaxItemId = 12;
            // 
            // barControl
            // 
            this.barControl.BarAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 9F);
            this.barControl.BarAppearance.Disabled.Options.UseFont = true;
            this.barControl.BarAppearance.Disabled.Options.UseTextOptions = true;
            this.barControl.BarAppearance.Disabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barControl.BarAppearance.Disabled.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.barControl.BarAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 9F);
            this.barControl.BarAppearance.Hovered.Options.UseFont = true;
            this.barControl.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F);
            this.barControl.BarAppearance.Normal.Options.UseFont = true;
            this.barControl.BarAppearance.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.barControl.BarAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9F);
            this.barControl.BarAppearance.Pressed.Options.UseBackColor = true;
            this.barControl.BarAppearance.Pressed.Options.UseFont = true;
            this.barControl.BarName = "Tools";
            this.barControl.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barControl.DockCol = 0;
            this.barControl.DockRow = 0;
            this.barControl.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barControl.FloatLocation = new System.Drawing.Point(249, 328);
            this.barControl.FloatSize = new System.Drawing.Size(731, 56);
            this.barControl.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndoDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLoginInfo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnReload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTransfer, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barControl.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.barControl.OptionsBar.Hidden = true;
            this.barControl.OptionsBar.MinHeight = 40;
            this.barControl.OptionsBar.MultiLine = true;
            this.barControl.Text = "Tools";
            // 
            // btnAdd
            // 
            this.btnAdd.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnAdd.Caption = "Add";
            this.btnAdd.Id = 0;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.LargeImage")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 0);
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnDelete.Caption = "Delete";
            this.btnDelete.Id = 1;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.LargeImage")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnUndoDelete
            // 
            this.btnUndoDelete.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnUndoDelete.Caption = "Undo Delete";
            this.btnUndoDelete.Id = 3;
            this.btnUndoDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUndoDelete.ImageOptions.Image")));
            this.btnUndoDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUndoDelete.ImageOptions.LargeImage")));
            this.btnUndoDelete.Name = "btnUndoDelete";
            this.btnUndoDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUndoDelete_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Id = 2;
            this.btnEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.Image")));
            this.btnEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.ImageOptions.LargeImage")));
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(60, 0);
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnLoginInfo
            // 
            this.btnLoginInfo.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnLoginInfo.Caption = "Login Info";
            this.btnLoginInfo.Id = 4;
            this.btnLoginInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLoginInfo.ImageOptions.Image")));
            this.btnLoginInfo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLoginInfo.ImageOptions.LargeImage")));
            this.btnLoginInfo.Name = "btnLoginInfo";
            this.btnLoginInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLoginInfo_ItemClick);
            // 
            // btnReload
            // 
            this.btnReload.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReload.Caption = "Reload";
            this.btnReload.Id = 5;
            this.btnReload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.Image")));
            this.btnReload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.LargeImage")));
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnUndo.Caption = "Undo";
            this.btnUndo.Id = 6;
            this.btnUndo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.ImageOptions.Image")));
            this.btnUndo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUndo.ImageOptions.LargeImage")));
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(60, 0);
            // 
            // btnTransfer
            // 
            this.btnTransfer.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnTransfer.Caption = "Transfer";
            this.btnTransfer.Id = 7;
            this.btnTransfer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTransfer.ImageOptions.Image")));
            this.btnTransfer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTransfer.ImageOptions.LargeImage")));
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTransfer_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExit.Caption = "EXIT";
            this.btnExit.Id = 10;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.LargeImage")));
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 0);
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.barDockControlTop.Appearance.Options.UseFont = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1251, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 728);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1251, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 688);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1251, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 688);
            // 
            // pnlControl
            // 
            this.pnlControl.Appearance.Options.UseFont = true;
            this.pnlControl.Controls.Add(this.cbxBranch);
            this.pnlControl.Controls.Add(this.label1);
            this.pnlControl.Controls.Add(this.btnLoad);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControl.Location = new System.Drawing.Point(0, 40);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(8);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(635, 117);
            this.pnlControl.TabIndex = 7;
            // 
            // cbxBranch
            // 
            this.cbxBranch.AllowDrop = true;
            this.cbxBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxBranch.FormattingEnabled = true;
            this.cbxBranch.Location = new System.Drawing.Point(80, 55);
            this.cbxBranch.Margin = new System.Windows.Forms.Padding(6);
            this.cbxBranch.Name = "cbxBranch";
            this.cbxBranch.Size = new System.Drawing.Size(228, 26);
            this.cbxBranch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Branch:";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLoad.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnLoad.Location = new System.Drawing.Point(331, 53);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(112, 28);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.cbxBranch_SelectedIndexChanged);
            // 
            // data
            // 
            this.data.AllowUserToAddRows = false;
            this.data.AllowUserToDeleteRows = false;
            this.data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.data.ColumnHeadersHeight = 35;
            this.data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data.Location = new System.Drawing.Point(0, 157);
            this.data.MultiSelect = false;
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.RowHeadersWidth = 40;
            this.data.RowTemplate.Height = 24;
            this.data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data.Size = new System.Drawing.Size(635, 571);
            this.data.TabIndex = 13;
            this.data.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.data_CellFormatting);
            this.data.SelectionChanged += new System.EventHandler(this.data_SelectionChanged);
            this.data.Click += new System.EventHandler(this.data_SelectionChanged);
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1251, 728);
            this.Controls.Add(this.data);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlEmployeeInfo);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEmployee";
            this.Text = "EMPLOYEES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmployeeInfo)).EndInit();
            this.pnlEmployeeInfo.ResumeLayout(false);
            this.pnlEmployeeInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlControl)).EndInit();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl pnlEmployeeInfo;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barControl;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        //private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnUndoDelete;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnLoginInfo;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnTransfer;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraEditors.PanelControl pnlControl;
        private System.Windows.Forms.ComboBox cbxBranch;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DataGridView data;
        private Label lblFname;
        private TextBox txtCMND;
        private Label lblGender;
        private Label lblStatus;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblCMND;
        private TextBox txtLastName;
        private Label lblLname;
        private TextBox txtFirstName;
        private ComboBox cbxGender;
        private RichTextBox txtAddress;
        private Label lblAddress;
        private Button btnCancel;
        private Button btnSave;
        private Label lblID;
        private TextBox txtID;
        private TextBox txtStatus;
        private Button btnLoad;
        private TextBox txtLoginName;
        private Button btnCancelPnlLoginInfo;
        private Button btnDeleteLogin;
        private Button btnChangePassword;
        private Label lblCrrPw;
        private Label lblNote;
        private Label lblLoginName;
        private Label lblConfirmNewPw;
        private TextBox txtConfirmNewPw;
        private Label lblNewPw;
        private TextBox txtCurrentPw;
        private TextBox txtNewPw;
        private Label lblID1;
        private Label lblUsername;
        private TextBox txtID1;
        private TextBox txtUsername;
        private Label lblConfirmPasswordError;
        private Label lblPasswordError;
        private Label lblNewPasswordError;
    }
}