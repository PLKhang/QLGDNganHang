namespace QLGDNganHang
{
    partial class frmTransfer
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransfer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSendInfo = new System.Windows.Forms.Button();
            this.btnReceiveInfo = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtReceiveAccount = new System.Windows.Forms.TextBox();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSendAccount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReceiveName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReceiveCMND = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSendCMND = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSendName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barControl = new DevExpress.XtraBars.Bar();
            this.btnReload = new DevExpress.XtraBars.BarButtonItem();
            this.btnUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.cbxCustomer = new System.Windows.Forms.ComboBox();
            this.lblNotification = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.data = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSendInfo);
            this.panel1.Controls.Add(this.btnReceiveInfo);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtReceiveAccount);
            this.panel1.Controls.Add(this.txtBalance);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSendAccount);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtEmployeeID);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtReceiveName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtReceiveCMND);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtSendCMND);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtSendName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panel1.Location = new System.Drawing.Point(744, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(714, 763);
            this.panel1.TabIndex = 0;
            // 
            // btnSendInfo
            // 
            this.btnSendInfo.BackColor = System.Drawing.Color.White;
            this.btnSendInfo.Location = new System.Drawing.Point(477, 40);
            this.btnSendInfo.Name = "btnSendInfo";
            this.btnSendInfo.Size = new System.Drawing.Size(120, 41);
            this.btnSendInfo.TabIndex = 4;
            this.btnSendInfo.Text = "CHOOSE";
            this.btnSendInfo.UseVisualStyleBackColor = false;
            this.btnSendInfo.Click += new System.EventHandler(this.btnSendInfo_Click);
            // 
            // btnReceiveInfo
            // 
            this.btnReceiveInfo.BackColor = System.Drawing.Color.White;
            this.btnReceiveInfo.Location = new System.Drawing.Point(477, 309);
            this.btnReceiveInfo.Name = "btnReceiveInfo";
            this.btnReceiveInfo.Size = new System.Drawing.Size(120, 41);
            this.btnReceiveInfo.TabIndex = 4;
            this.btnReceiveInfo.Text = "CHOOSE";
            this.btnReceiveInfo.UseVisualStyleBackColor = false;
            this.btnReceiveInfo.Click += new System.EventHandler(this.btnReceiveInfo_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnConfirm.Location = new System.Drawing.Point(320, 624);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(120, 52);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClear.Location = new System.Drawing.Point(477, 624);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(120, 52);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtAmount.Location = new System.Drawing.Point(224, 549);
            this.txtAmount.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(373, 28);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.ThousandsSeparator = true;
            this.txtAmount.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(47, 309);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(550, 41);
            this.label6.TabIndex = 0;
            this.label6.Text = "         RECEIVE INFORMATION";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(550, 41);
            this.label5.TabIndex = 0;
            this.label5.Text = "         SEND INFORMATION";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(87, 552);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Amount:";
            // 
            // txtReceiveAccount
            // 
            this.txtReceiveAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveAccount.Location = new System.Drawing.Point(224, 456);
            this.txtReceiveAccount.Name = "txtReceiveAccount";
            this.txtReceiveAccount.ReadOnly = true;
            this.txtReceiveAccount.Size = new System.Drawing.Size(373, 28);
            this.txtReceiveAccount.TabIndex = 1;
            // 
            // txtBalance
            // 
            this.txtBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(224, 240);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Size = new System.Drawing.Size(373, 28);
            this.txtBalance.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Balance:";
            // 
            // txtSendAccount
            // 
            this.txtSendAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendAccount.Location = new System.Drawing.Point(224, 194);
            this.txtSendAccount.Name = "txtSendAccount";
            this.txtSendAccount.ReadOnly = true;
            this.txtSendAccount.Size = new System.Drawing.Size(373, 28);
            this.txtSendAccount.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(97, 460);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 22);
            this.label9.TabIndex = 0;
            this.label9.Text = "Account:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(90, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Account:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Enabled = false;
            this.txtEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeID.Location = new System.Drawing.Point(224, 710);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(373, 28);
            this.txtEmployeeID.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(54, 713);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 22);
            this.label10.TabIndex = 0;
            this.label10.Text = "Employee ID:";
            // 
            // txtReceiveName
            // 
            this.txtReceiveName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveName.Location = new System.Drawing.Point(224, 412);
            this.txtReceiveName.Name = "txtReceiveName";
            this.txtReceiveName.ReadOnly = true;
            this.txtReceiveName.Size = new System.Drawing.Size(373, 28);
            this.txtReceiveName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(115, 416);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Name:";
            // 
            // txtReceiveCMND
            // 
            this.txtReceiveCMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiveCMND.Location = new System.Drawing.Point(224, 364);
            this.txtReceiveCMND.Name = "txtReceiveCMND";
            this.txtReceiveCMND.ReadOnly = true;
            this.txtReceiveCMND.Size = new System.Drawing.Size(373, 28);
            this.txtReceiveCMND.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(109, 368);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 22);
            this.label13.TabIndex = 0;
            this.label13.Text = "CMND:";
            // 
            // txtSendCMND
            // 
            this.txtSendCMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendCMND.Location = new System.Drawing.Point(224, 107);
            this.txtSendCMND.Name = "txtSendCMND";
            this.txtSendCMND.ReadOnly = true;
            this.txtSendCMND.Size = new System.Drawing.Size(373, 28);
            this.txtSendCMND.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(102, 110);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 22);
            this.label12.TabIndex = 0;
            this.label12.Text = "CMND:";
            // 
            // txtSendName
            // 
            this.txtSendName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendName.Location = new System.Drawing.Point(224, 150);
            this.txtSendName.Name = "txtSendName";
            this.txtSendName.ReadOnly = true;
            this.txtSendName.Size = new System.Drawing.Size(373, 28);
            this.txtSendName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barControl});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnReload,
            this.btnUndo,
            this.btnExit,
            this.barButtonItem1});
            this.barManager1.MaxItemId = 5;
            // 
            // barControl
            // 
            this.barControl.BarAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 10F);
            this.barControl.BarAppearance.Disabled.Options.UseFont = true;
            this.barControl.BarAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 10F);
            this.barControl.BarAppearance.Hovered.Options.UseFont = true;
            this.barControl.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.barControl.BarAppearance.Normal.Options.UseFont = true;
            this.barControl.BarAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 10F);
            this.barControl.BarAppearance.Pressed.Options.UseFont = true;
            this.barControl.BarName = "Tools";
            this.barControl.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barControl.DockCol = 0;
            this.barControl.DockRow = 0;
            this.barControl.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barControl.FloatLocation = new System.Drawing.Point(77, 361);
            this.barControl.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnReload, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUndo, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.barControl.Offset = 3;
            this.barControl.OptionsBar.MinHeight = 40;
            this.barControl.Text = "Tools";
            // 
            // btnReload
            // 
            this.btnReload.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnReload.Caption = "RELOAD";
            this.btnReload.Id = 1;
            this.btnReload.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.Image")));
            this.btnReload.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReload.ImageOptions.LargeImage")));
            this.btnReload.Name = "btnReload";
            this.btnReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReload_ItemClick);
            // 
            // btnUndo
            // 
            this.btnUndo.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnUndo.Caption = "UNDO";
            this.btnUndo.Id = 2;
            this.btnUndo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.ImageOptions.Image")));
            this.btnUndo.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnUndo.ImageOptions.LargeImage")));
            this.btnUndo.Name = "btnUndo";
            // 
            // btnExit
            // 
            this.btnExit.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnExit.Caption = "EXIT";
            this.btnExit.Id = 3;
            this.btnExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.Image")));
            this.btnExit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExit.ImageOptions.LargeImage")));
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 0);
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1458, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 803);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1458, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 763);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1458, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 763);
            // 
            // btnAdd
            // 
            this.btnAdd.Border = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btnAdd.Caption = "ADD";
            this.btnAdd.Id = 0;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.LargeImage")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(60, 0);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 4;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnShowAll);
            this.panel2.Controls.Add(this.cbxCustomer);
            this.panel2.Controls.Add(this.lblNotification);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 144);
            this.panel2.TabIndex = 5;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnShowAll.Location = new System.Drawing.Point(558, 89);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(161, 33);
            this.btnShowAll.TabIndex = 4;
            this.btnShowAll.Text = "SHOW ALL";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // cbxCustomer
            // 
            this.cbxCustomer.AllowDrop = true;
            this.cbxCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCustomer.FormattingEnabled = true;
            this.cbxCustomer.Location = new System.Drawing.Point(223, 94);
            this.cbxCustomer.Name = "cbxCustomer";
            this.cbxCustomer.Size = new System.Drawing.Size(295, 28);
            this.cbxCustomer.TabIndex = 0;
            this.cbxCustomer.SelectedIndexChanged += new System.EventHandler(this.cbxCustomer_SelectedIndexChanged);
            // 
            // lblNotification
            // 
            this.lblNotification.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblNotification.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotification.Location = new System.Drawing.Point(20, 40);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(699, 41);
            this.lblNotification.TabIndex = 0;
            this.lblNotification.Text = "PRESS \"CHOOSE\" SEND ACCOUNT";
            this.lblNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer\'s CMND:";
            // 
            // data
            // 
            this.data.AllowUserToAddRows = false;
            this.data.AllowUserToDeleteRows = false;
            this.data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.data.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.data.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.data.DefaultCellStyle = dataGridViewCellStyle2;
            this.data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.data.Location = new System.Drawing.Point(0, 184);
            this.data.MultiSelect = false;
            this.data.Name = "data";
            this.data.ReadOnly = true;
            this.data.RowHeadersWidth = 35;
            this.data.RowTemplate.Height = 24;
            this.data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data.Size = new System.Drawing.Size(744, 619);
            this.data.TabIndex = 6;
            this.data.Click += new System.EventHandler(this.data_SelectionChanged);
            // 
            // frmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1458, 803);
            this.Controls.Add(this.data);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmTransfer";
            this.Text = "TRANSFERING";
            this.Load += new System.EventHandler(this.frmTransfer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barControl;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnReload;
        private DevExpress.XtraBars.BarButtonItem btnUndo;
        private DevExpress.XtraBars.BarButtonItem btnExit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.DataGridView data;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown txtAmount;
        private System.Windows.Forms.TextBox txtSendName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNotification;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtReceiveAccount;
        private System.Windows.Forms.TextBox txtSendAccount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtReceiveName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReceiveCMND;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSendCMND;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnShowAll;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.TextBox txtBalance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSendInfo;
        private System.Windows.Forms.Button btnReceiveInfo;
    }
}