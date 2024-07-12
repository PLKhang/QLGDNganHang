namespace QLGDNganHang
{
    partial class frptAccountsList
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.pickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.pickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.checkAllBranch = new System.Windows.Forms.CheckBox();
            this.cbxBranchs = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExit.Location = new System.Drawing.Point(943, 523);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(135, 48);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExport.Location = new System.Drawing.Point(745, 523);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(135, 48);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "EXPORT";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnPreview.Location = new System.Drawing.Point(200, 523);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(314, 48);
            this.btnPreview.TabIndex = 18;
            this.btnPreview.Text = "PREVIEW";
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // pickerEndDate
            // 
            this.pickerEndDate.CustomFormat = "dddd dd/MM/yyyy";
            this.pickerEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pickerEndDate.Location = new System.Drawing.Point(200, 398);
            this.pickerEndDate.Margin = new System.Windows.Forms.Padding(4);
            this.pickerEndDate.Name = "pickerEndDate";
            this.pickerEndDate.Size = new System.Drawing.Size(314, 30);
            this.pickerEndDate.TabIndex = 12;
            // 
            // pickerStartDate
            // 
            this.pickerStartDate.CustomFormat = "dddd dd/MM/yyyy";
            this.pickerStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.pickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.pickerStartDate.Location = new System.Drawing.Point(200, 309);
            this.pickerStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.pickerStartDate.Name = "pickerStartDate";
            this.pickerStartDate.Size = new System.Drawing.Size(314, 30);
            this.pickerStartDate.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(21, 185);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Branch:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(21, 398);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "End date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(21, 309);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Begin date:";
            // 
            // panel
            // 
            this.panel.BackgroundImage = global::QLGDNganHang.Properties.Resources.BANK;
            this.panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.panel.Location = new System.Drawing.Point(654, 51);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(424, 391);
            this.panel.TabIndex = 19;
            // 
            // checkAllBranch
            // 
            this.checkAllBranch.AutoSize = true;
            this.checkAllBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkAllBranch.Location = new System.Drawing.Point(200, 97);
            this.checkAllBranch.Name = "checkAllBranch";
            this.checkAllBranch.Size = new System.Drawing.Size(194, 29);
            this.checkAllBranch.TabIndex = 20;
            this.checkAllBranch.Text = "Show all branchs?";
            this.checkAllBranch.UseVisualStyleBackColor = true;
            this.checkAllBranch.CheckedChanged += new System.EventHandler(this.checkAllBranch_CheckedChanged);
            // 
            // cbxBranchs
            // 
            this.cbxBranchs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbxBranchs.FormattingEnabled = true;
            this.cbxBranchs.Items.AddRange(new object[] {
            "BENTHANH",
            "TANDINH"});
            this.cbxBranchs.Location = new System.Drawing.Point(200, 185);
            this.cbxBranchs.Name = "cbxBranchs";
            this.cbxBranchs.Size = new System.Drawing.Size(314, 33);
            this.cbxBranchs.TabIndex = 21;
            this.cbxBranchs.SelectedIndexChanged += new System.EventHandler(this.cbxBranchs_SelectedIndexChanged);
            // 
            // frptAccountsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1114, 651);
            this.Controls.Add(this.cbxBranchs);
            this.Controls.Add(this.checkAllBranch);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.pickerEndDate);
            this.Controls.Add(this.pickerStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frptAccountsList";
            this.Text = "LIST OF ACCOUNTS";
            this.Load += new System.EventHandler(this.frptAccountsList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.DateTimePicker pickerEndDate;
        private System.Windows.Forms.DateTimePicker pickerStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.CheckBox checkAllBranch;
        private System.Windows.Forms.ComboBox cbxBranchs;
    }
}