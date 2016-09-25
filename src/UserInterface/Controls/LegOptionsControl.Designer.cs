namespace FlightPlanner.UserInterface.Controls {
    partial class LegOptionsControl {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			FlightPlanner.Common.Wind wind2 = new FlightPlanner.Common.Wind();
			this.gbxDetails = new System.Windows.Forms.GroupBox();
			this.lvwDetails = new System.Windows.Forms.ListView();
			this.clnKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.gbxSettings = new System.Windows.Forms.GroupBox();
			this.cbxGaforArea = new System.Windows.Forms.ComboBox();
			this.lblGafor = new System.Windows.Forms.Label();
			this.txtAltitude = new System.Windows.Forms.TextBox();
			this.lblAltitude = new System.Windows.Forms.Label();
			this.lblWind = new System.Windows.Forms.Label();
			this.wcLeg = new FlightPlanner.UserInterface.Controls.WindControl();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.lblClimbFrom = new System.Windows.Forms.Label();
			this.txtClimbFrom = new System.Windows.Forms.TextBox();
			this.gbxDetails.SuspendLayout();
			this.gbxSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxDetails
			// 
			this.gbxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxDetails.Controls.Add(this.lvwDetails);
			this.gbxDetails.Location = new System.Drawing.Point(3, 3);
			this.gbxDetails.Name = "gbxDetails";
			this.gbxDetails.Size = new System.Drawing.Size(496, 235);
			this.gbxDetails.TabIndex = 0;
			this.gbxDetails.TabStop = false;
			this.gbxDetails.Text = "Details";
			// 
			// lvwDetails
			// 
			this.lvwDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvwDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnKey,
            this.clnValue});
			this.lvwDetails.FullRowSelect = true;
			this.lvwDetails.GridLines = true;
			this.lvwDetails.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvwDetails.Location = new System.Drawing.Point(6, 19);
			this.lvwDetails.MultiSelect = false;
			this.lvwDetails.Name = "lvwDetails";
			this.lvwDetails.Size = new System.Drawing.Size(484, 210);
			this.lvwDetails.TabIndex = 0;
			this.lvwDetails.UseCompatibleStateImageBehavior = false;
			this.lvwDetails.View = System.Windows.Forms.View.Details;
			// 
			// clnKey
			// 
			this.clnKey.Text = "Key";
			this.clnKey.Width = 120;
			// 
			// clnValue
			// 
			this.clnValue.Text = "Value";
			this.clnValue.Width = 120;
			// 
			// gbxSettings
			// 
			this.gbxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxSettings.Controls.Add(this.txtClimbFrom);
			this.gbxSettings.Controls.Add(this.lblClimbFrom);
			this.gbxSettings.Controls.Add(this.cbxGaforArea);
			this.gbxSettings.Controls.Add(this.lblGafor);
			this.gbxSettings.Controls.Add(this.txtAltitude);
			this.gbxSettings.Controls.Add(this.lblAltitude);
			this.gbxSettings.Controls.Add(this.lblWind);
			this.gbxSettings.Controls.Add(this.wcLeg);
			this.gbxSettings.Location = new System.Drawing.Point(3, 244);
			this.gbxSettings.Name = "gbxSettings";
			this.gbxSettings.Size = new System.Drawing.Size(496, 131);
			this.gbxSettings.TabIndex = 1;
			this.gbxSettings.TabStop = false;
			this.gbxSettings.Text = "Settings";
			// 
			// cbxGaforArea
			// 
			this.cbxGaforArea.FormattingEnabled = true;
			this.cbxGaforArea.Location = new System.Drawing.Point(104, 86);
			this.cbxGaforArea.Name = "cbxGaforArea";
			this.cbxGaforArea.Size = new System.Drawing.Size(121, 21);
			this.cbxGaforArea.TabIndex = 6;
			this.cbxGaforArea.SelectedIndexChanged += new System.EventHandler(this.cbxGaforArea_SelectedIndexChanged);
			this.cbxGaforArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbxGaforArea_KeyUp);
			// 
			// lblGafor
			// 
			this.lblGafor.AutoSize = true;
			this.lblGafor.Location = new System.Drawing.Point(17, 90);
			this.lblGafor.Name = "lblGafor";
			this.lblGafor.Size = new System.Drawing.Size(81, 13);
			this.lblGafor.TabIndex = 5;
			this.lblGafor.Text = "GAFOR Gebiet:";
			// 
			// txtAltitude
			// 
			this.txtAltitude.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAltitude.Location = new System.Drawing.Point(104, 55);
			this.txtAltitude.Name = "txtAltitude";
			this.txtAltitude.Size = new System.Drawing.Size(183, 20);
			this.txtAltitude.TabIndex = 4;
			this.txtAltitude.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtAltitude_KeyUp);
			// 
			// lblAltitude
			// 
			this.lblAltitude.AutoSize = true;
			this.lblAltitude.Location = new System.Drawing.Point(17, 58);
			this.lblAltitude.Name = "lblAltitude";
			this.lblAltitude.Size = new System.Drawing.Size(45, 13);
			this.lblAltitude.TabIndex = 3;
			this.lblAltitude.Text = "Altitude:";
			// 
			// lblWind
			// 
			this.lblWind.AutoSize = true;
			this.lblWind.Location = new System.Drawing.Point(17, 24);
			this.lblWind.Name = "lblWind";
			this.lblWind.Size = new System.Drawing.Size(35, 13);
			this.lblWind.TabIndex = 1;
			this.lblWind.Text = "Wind:";
			// 
			// wcLeg
			// 
			this.wcLeg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.wcLeg.Location = new System.Drawing.Point(104, 19);
			this.wcLeg.Name = "wcLeg";
			this.wcLeg.Size = new System.Drawing.Size(368, 27);
			this.wcLeg.TabIndex = 0;
			wind2.Direction = 0;
			wind2.GustSpeed = 0;
			wind2.Speed = 0;
			wind2.Variable = false;
			this.wcLeg.Wind = wind2;
			this.wcLeg.WindChanged += new System.EventHandler(this.wcLeg_WindChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// lblClimbFrom
			// 
			this.lblClimbFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblClimbFrom.AutoSize = true;
			this.lblClimbFrom.Location = new System.Drawing.Point(293, 58);
			this.lblClimbFrom.Name = "lblClimbFrom";
			this.lblClimbFrom.Size = new System.Drawing.Size(58, 13);
			this.lblClimbFrom.TabIndex = 7;
			this.lblClimbFrom.Text = "Climb from:";
			// 
			// txtClimbFrom
			// 
			this.txtClimbFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtClimbFrom.Location = new System.Drawing.Point(357, 55);
			this.txtClimbFrom.Name = "txtClimbFrom";
			this.txtClimbFrom.Size = new System.Drawing.Size(115, 20);
			this.txtClimbFrom.TabIndex = 8;
			this.txtClimbFrom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtClimbFrom_KeyUp);
			// 
			// LegOptionsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbxSettings);
			this.Controls.Add(this.gbxDetails);
			this.Name = "LegOptionsControl";
			this.Size = new System.Drawing.Size(505, 378);
			this.gbxDetails.ResumeLayout(false);
			this.gbxSettings.ResumeLayout(false);
			this.gbxSettings.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxDetails;
        private System.Windows.Forms.GroupBox gbxSettings;
        private System.Windows.Forms.Label lblWind;
        private WindControl wcLeg;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.ListView lvwDetails;
        private System.Windows.Forms.ColumnHeader clnKey;
        private System.Windows.Forms.ColumnHeader clnValue;
        private System.Windows.Forms.TextBox txtAltitude;
		private System.Windows.Forms.ComboBox cbxGaforArea;
		private System.Windows.Forms.Label lblGafor;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.TextBox txtClimbFrom;
		private System.Windows.Forms.Label lblClimbFrom;
	}
}
