namespace FlightPlanner.UserInterface.Dialogs {
    partial class RouteGlobalSettingsForm {
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
			FlightPlanner.Common.Wind wind2 = new FlightPlanner.Common.Wind();
			this.gbxWind = new System.Windows.Forms.GroupBox();
			this.chkWind = new System.Windows.Forms.CheckBox();
			this.gbxAltitude = new System.Windows.Forms.GroupBox();
			this.txtAltitude = new System.Windows.Forms.TextBox();
			this.chkAltitude = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.gbxGafor = new System.Windows.Forms.GroupBox();
			this.cbxGaforArea = new System.Windows.Forms.ComboBox();
			this.chkGaforArea = new System.Windows.Forms.CheckBox();
			this.wcWind = new FlightPlanner.UserInterface.Controls.WindControl();
			this.gbxWind.SuspendLayout();
			this.gbxAltitude.SuspendLayout();
			this.gbxGafor.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxWind
			// 
			this.gbxWind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxWind.Controls.Add(this.wcWind);
			this.gbxWind.Controls.Add(this.chkWind);
			this.gbxWind.Location = new System.Drawing.Point(12, 12);
			this.gbxWind.Name = "gbxWind";
			this.gbxWind.Size = new System.Drawing.Size(317, 64);
			this.gbxWind.TabIndex = 0;
			this.gbxWind.TabStop = false;
			// 
			// chkWind
			// 
			this.chkWind.AutoSize = true;
			this.chkWind.Location = new System.Drawing.Point(16, 0);
			this.chkWind.Name = "chkWind";
			this.chkWind.Size = new System.Drawing.Size(51, 17);
			this.chkWind.TabIndex = 1;
			this.chkWind.Text = "Wind";
			this.chkWind.UseVisualStyleBackColor = true;
			// 
			// gbxAltitude
			// 
			this.gbxAltitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxAltitude.Controls.Add(this.txtAltitude);
			this.gbxAltitude.Controls.Add(this.chkAltitude);
			this.gbxAltitude.Location = new System.Drawing.Point(12, 82);
			this.gbxAltitude.Name = "gbxAltitude";
			this.gbxAltitude.Size = new System.Drawing.Size(317, 64);
			this.gbxAltitude.TabIndex = 1;
			this.gbxAltitude.TabStop = false;
			// 
			// txtAltitude
			// 
			this.txtAltitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAltitude.Location = new System.Drawing.Point(16, 27);
			this.txtAltitude.Name = "txtAltitude";
			this.txtAltitude.Size = new System.Drawing.Size(282, 20);
			this.txtAltitude.TabIndex = 1;
			this.txtAltitude.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAltitude_KeyDown);
			// 
			// chkAltitude
			// 
			this.chkAltitude.AutoSize = true;
			this.chkAltitude.Location = new System.Drawing.Point(16, 0);
			this.chkAltitude.Name = "chkAltitude";
			this.chkAltitude.Size = new System.Drawing.Size(61, 17);
			this.chkAltitude.TabIndex = 0;
			this.chkAltitude.Text = "Altitude";
			this.chkAltitude.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(229, 241);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(123, 241);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 3;
			this.btnAccept.Text = "OK";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// gbxGafor
			// 
			this.gbxGafor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxGafor.Controls.Add(this.chkGaforArea);
			this.gbxGafor.Controls.Add(this.cbxGaforArea);
			this.gbxGafor.Location = new System.Drawing.Point(12, 152);
			this.gbxGafor.Name = "gbxGafor";
			this.gbxGafor.Size = new System.Drawing.Size(317, 70);
			this.gbxGafor.TabIndex = 4;
			this.gbxGafor.TabStop = false;
			// 
			// cbxGaforArea
			// 
			this.cbxGaforArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxGaforArea.FormattingEnabled = true;
			this.cbxGaforArea.Location = new System.Drawing.Point(16, 28);
			this.cbxGaforArea.Name = "cbxGaforArea";
			this.cbxGaforArea.Size = new System.Drawing.Size(282, 21);
			this.cbxGaforArea.TabIndex = 0;
			this.cbxGaforArea.SelectedIndexChanged += new System.EventHandler(this.cbxGaforArea_SelectedIndexChanged);
			this.cbxGaforArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxGaforArea_KeyUp);
			// 
			// chkGaforArea
			// 
			this.chkGaforArea.AutoSize = true;
			this.chkGaforArea.Location = new System.Drawing.Point(16, 0);
			this.chkGaforArea.Name = "chkGaforArea";
			this.chkGaforArea.Size = new System.Drawing.Size(88, 17);
			this.chkGaforArea.TabIndex = 5;
			this.chkGaforArea.Text = "GAFOR Area";
			this.chkGaforArea.UseVisualStyleBackColor = true;
			// 
			// wcWind
			// 
			this.wcWind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.wcWind.Location = new System.Drawing.Point(16, 23);
			this.wcWind.Name = "wcWind";
			this.wcWind.Size = new System.Drawing.Size(282, 27);
			this.wcWind.TabIndex = 2;
			wind2.Direction = 0;
			wind2.GustSpeed = 0;
			wind2.Speed = 0;
			this.wcWind.Wind = wind2;
			this.wcWind.WindChanged += new System.EventHandler(this.wcWind_WindChanged);
			// 
			// RouteGlobalSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(341, 278);
			this.Controls.Add(this.gbxGafor);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbxAltitude);
			this.Controls.Add(this.gbxWind);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(280, 230);
			this.Name = "RouteGlobalSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Global Route Settings";
			this.gbxWind.ResumeLayout(false);
			this.gbxWind.PerformLayout();
			this.gbxAltitude.ResumeLayout(false);
			this.gbxAltitude.PerformLayout();
			this.gbxGafor.ResumeLayout(false);
			this.gbxGafor.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxWind;
        private System.Windows.Forms.CheckBox chkWind;
        private System.Windows.Forms.GroupBox gbxAltitude;
        private System.Windows.Forms.CheckBox chkAltitude;
        private System.Windows.Forms.TextBox txtAltitude;
        private Controls.WindControl wcWind;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.GroupBox gbxGafor;
		private System.Windows.Forms.ComboBox cbxGaforArea;
		private System.Windows.Forms.CheckBox chkGaforArea;
	}
}