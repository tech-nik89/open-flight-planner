namespace FlightPlanner.UserInterface.Dialogs {
    partial class ResourceFileForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.cbxType = new System.Windows.Forms.ComboBox();
			this.lblType = new System.Windows.Forms.Label();
			this.gbxProperties = new System.Windows.Forms.GroupBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.lblVisible = new System.Windows.Forms.Label();
			this.chkVisible = new System.Windows.Forms.CheckBox();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.lblPath = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbLocationLocal = new System.Windows.Forms.RadioButton();
			this.rbLocationOnline = new System.Windows.Forms.RadioButton();
			this.lblLocation = new System.Windows.Forms.Label();
			this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
			this.gbxProperties.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbxType
			// 
			this.cbxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxType.FormattingEnabled = true;
			this.cbxType.Location = new System.Drawing.Point(91, 22);
			this.cbxType.Name = "cbxType";
			this.cbxType.Size = new System.Drawing.Size(302, 21);
			this.cbxType.TabIndex = 0;
			// 
			// lblType
			// 
			this.lblType.AutoSize = true;
			this.lblType.Location = new System.Drawing.Point(20, 25);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(34, 13);
			this.lblType.TabIndex = 1;
			this.lblType.Text = "Type:";
			// 
			// gbxProperties
			// 
			this.gbxProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxProperties.Controls.Add(this.btnBrowse);
			this.gbxProperties.Controls.Add(this.lblVisible);
			this.gbxProperties.Controls.Add(this.chkVisible);
			this.gbxProperties.Controls.Add(this.txtPath);
			this.gbxProperties.Controls.Add(this.lblPath);
			this.gbxProperties.Controls.Add(this.txtName);
			this.gbxProperties.Controls.Add(this.lblName);
			this.gbxProperties.Location = new System.Drawing.Point(12, 98);
			this.gbxProperties.Name = "gbxProperties";
			this.gbxProperties.Size = new System.Drawing.Size(417, 99);
			this.gbxProperties.TabIndex = 2;
			this.gbxProperties.TabStop = false;
			this.gbxProperties.Text = "Properties";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(351, 45);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(42, 20);
			this.btnBrowse.TabIndex = 6;
			this.btnBrowse.Text = "...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// lblVisible
			// 
			this.lblVisible.AutoSize = true;
			this.lblVisible.Location = new System.Drawing.Point(20, 72);
			this.lblVisible.Name = "lblVisible";
			this.lblVisible.Size = new System.Drawing.Size(40, 13);
			this.lblVisible.TabIndex = 5;
			this.lblVisible.Text = "Visible:";
			// 
			// chkVisible
			// 
			this.chkVisible.AutoSize = true;
			this.chkVisible.Location = new System.Drawing.Point(91, 72);
			this.chkVisible.Name = "chkVisible";
			this.chkVisible.Size = new System.Drawing.Size(15, 14);
			this.chkVisible.TabIndex = 4;
			this.chkVisible.UseVisualStyleBackColor = true;
			// 
			// txtPath
			// 
			this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPath.Location = new System.Drawing.Point(91, 45);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(254, 20);
			this.txtPath.TabIndex = 3;
			// 
			// lblPath
			// 
			this.lblPath.AutoSize = true;
			this.lblPath.Location = new System.Drawing.Point(20, 48);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(32, 13);
			this.lblPath.TabIndex = 2;
			this.lblPath.Text = "URL:";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(91, 19);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(302, 20);
			this.txtName.TabIndex = 1;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(20, 22);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Name:";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(329, 210);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(223, 210);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 4;
			this.btnAccept.Text = "OK";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.rbLocationLocal);
			this.groupBox1.Controls.Add(this.rbLocationOnline);
			this.groupBox1.Controls.Add(this.lblLocation);
			this.groupBox1.Controls.Add(this.lblType);
			this.groupBox1.Controls.Add(this.cbxType);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(417, 80);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Resource";
			// 
			// rbLocationLocal
			// 
			this.rbLocationLocal.AutoSize = true;
			this.rbLocationLocal.Location = new System.Drawing.Point(173, 49);
			this.rbLocationLocal.Name = "rbLocationLocal";
			this.rbLocationLocal.Size = new System.Drawing.Size(51, 17);
			this.rbLocationLocal.TabIndex = 4;
			this.rbLocationLocal.TabStop = true;
			this.rbLocationLocal.Text = "Local";
			this.rbLocationLocal.UseVisualStyleBackColor = true;
			this.rbLocationLocal.CheckedChanged += new System.EventHandler(this.rbLocation_CheckedChanged);
			// 
			// rbLocationOnline
			// 
			this.rbLocationOnline.AutoSize = true;
			this.rbLocationOnline.Location = new System.Drawing.Point(91, 49);
			this.rbLocationOnline.Name = "rbLocationOnline";
			this.rbLocationOnline.Size = new System.Drawing.Size(55, 17);
			this.rbLocationOnline.TabIndex = 3;
			this.rbLocationOnline.TabStop = true;
			this.rbLocationOnline.Text = "Online";
			this.rbLocationOnline.UseVisualStyleBackColor = true;
			this.rbLocationOnline.CheckedChanged += new System.EventHandler(this.rbLocation_CheckedChanged);
			// 
			// lblLocation
			// 
			this.lblLocation.AutoSize = true;
			this.lblLocation.Location = new System.Drawing.Point(20, 51);
			this.lblLocation.Name = "lblLocation";
			this.lblLocation.Size = new System.Drawing.Size(51, 13);
			this.lblLocation.TabIndex = 2;
			this.lblLocation.Text = "Location:";
			// 
			// ResourceFileForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(441, 247);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbxProperties);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(280, 250);
			this.Name = "ResourceFileForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Resource File";
			this.gbxProperties.ResumeLayout(false);
			this.gbxProperties.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.GroupBox gbxProperties;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblVisible;
        private System.Windows.Forms.CheckBox chkVisible;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbLocationLocal;
		private System.Windows.Forms.RadioButton rbLocationOnline;
		private System.Windows.Forms.Label lblLocation;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.OpenFileDialog ofdOpen;
	}
}