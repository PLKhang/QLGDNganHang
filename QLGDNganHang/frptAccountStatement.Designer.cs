﻿namespace QLGDNganHang
{
    partial class frptAccountStatement
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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxAccountID = new System.Windows.Forms.ComboBox();
            this.pickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.cbxCMND = new System.Windows.Forms.ComboBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(35, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(35, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Begin date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(35, 309);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "End date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(613, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(613, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "CMND:";
            // 
            // cbxAccountID
            // 
            this.cbxAccountID.AllowDrop = true;
            this.cbxAccountID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxAccountID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxAccountID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbxAccountID.FormattingEnabled = true;
            this.cbxAccountID.Location = new System.Drawing.Point(192, 107);
            this.cbxAccountID.MaxLength = 9;
            this.cbxAccountID.Name = "cbxAccountID";
            this.cbxAccountID.Size = new System.Drawing.Size(289, 33);
            this.cbxAccountID.Sorted = true;
            this.cbxAccountID.TabIndex = 1;
            this.cbxAccountID.SelectedIndexChanged += new System.EventHandler(this.cbxAccountID_SelectedIndexChanged);
            // 
            // pickerEndDate
            // 
            this.pickerEndDate.CustomFormat = "dddd dd/MM/yyyy";
            this.pickerEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pickerEndDate.Location = new System.Drawing.Point(192, 309);
            this.pickerEndDate.Name = "pickerEndDate";
            this.pickerEndDate.Size = new System.Drawing.Size(289, 30);
            this.pickerEndDate.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtName.Location = new System.Drawing.Point(719, 221);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(290, 30);
            this.txtName.TabIndex = 3;
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPreview.Location = new System.Drawing.Point(192, 450);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(241, 46);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "PREVIEW";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExport.Location = new System.Drawing.Point(664, 450);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(146, 46);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "EXPORT";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExit.Location = new System.Drawing.Point(863, 450);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(146, 46);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pickerStartDate
            // 
            this.pickerStartDate.CustomFormat = "dddd dd/MM/yyyy";
            this.pickerStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pickerStartDate.Location = new System.Drawing.Point(192, 219);
            this.pickerStartDate.Name = "pickerStartDate";
            this.pickerStartDate.Size = new System.Drawing.Size(289, 30);
            this.pickerStartDate.TabIndex = 2;
            // 
            // cbxCMND
            // 
            this.cbxCMND.AllowDrop = true;
            this.cbxCMND.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxCMND.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxCMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbxCMND.FormattingEnabled = true;
            this.cbxCMND.Location = new System.Drawing.Point(719, 107);
            this.cbxCMND.MaxLength = 10;
            this.cbxCMND.Name = "cbxCMND";
            this.cbxCMND.Size = new System.Drawing.Size(290, 33);
            this.cbxCMND.Sorted = true;
            this.cbxCMND.TabIndex = 1;
            this.cbxCMND.SelectedIndexChanged += new System.EventHandler(this.cbxCMND_SelectedIndexChanged);
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnShowAll.Location = new System.Drawing.Point(192, 47);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(289, 38);
            this.btnShowAll.TabIndex = 4;
            this.btnShowAll.Text = "SHOW ALL ACCOUNTS";
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // frptAccountStatement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1112, 562);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.pickerEndDate);
            this.Controls.Add(this.pickerStartDate);
            this.Controls.Add(this.cbxCMND);
            this.Controls.Add(this.cbxAccountID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frptAccountStatement";
            this.Text = "ACCOUNT STATEMENT";
            this.Load += new System.EventHandler(this.frptAccountStatement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxAccountID;
        private System.Windows.Forms.DateTimePicker pickerEndDate;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker pickerStartDate;
        private System.Windows.Forms.ComboBox cbxCMND;
        private System.Windows.Forms.Button btnShowAll;
    }
}