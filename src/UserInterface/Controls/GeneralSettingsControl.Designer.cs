namespace FlightPlanner.UserInterface.Controls {
	partial class GeneralSettingsControl {
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
			this.lblLanguage = new System.Windows.Forms.Label();
			this.cbxLanguage = new System.Windows.Forms.ComboBox();
			this.lblLanguageRestart = new System.Windows.Forms.Label();
			this.lblRequiresRestart = new System.Windows.Forms.Label();
			this.gbxMap = new System.Windows.Forms.GroupBox();
			this.gbxLanguage = new System.Windows.Forms.GroupBox();
			this.lblMapType = new System.Windows.Forms.Label();
			this.cbxMapType = new System.Windows.Forms.ComboBox();
			this.gbxMap.SuspendLayout();
			this.gbxLanguage.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblLanguage
			// 
			this.lblLanguage.AutoSize = true;
			this.lblLanguage.Location = new System.Drawing.Point(20, 31);
			this.lblLanguage.Name = "lblLanguage";
			this.lblLanguage.Size = new System.Drawing.Size(58, 13);
			this.lblLanguage.TabIndex = 3;
			this.lblLanguage.Text = "Language:";
			// 
			// cbxLanguage
			// 
			this.cbxLanguage.FormattingEnabled = true;
			this.cbxLanguage.Location = new System.Drawing.Point(97, 28);
			this.cbxLanguage.Name = "cbxLanguage";
			this.cbxLanguage.Size = new System.Drawing.Size(137, 21);
			this.cbxLanguage.TabIndex = 2;
			this.cbxLanguage.SelectedIndexChanged += new System.EventHandler(this.cbxLanguage_Changed);
			this.cbxLanguage.TextUpdate += new System.EventHandler(this.cbxLanguage_Changed);
			// 
			// lblLanguageRestart
			// 
			this.lblLanguageRestart.AutoSize = true;
			this.lblLanguageRestart.Location = new System.Drawing.Point(240, 31);
			this.lblLanguageRestart.Name = "lblLanguageRestart";
			this.lblLanguageRestart.Size = new System.Drawing.Size(11, 13);
			this.lblLanguageRestart.TabIndex = 4;
			this.lblLanguageRestart.Text = "*";
			// 
			// lblRequiresRestart
			// 
			this.lblRequiresRestart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblRequiresRestart.Location = new System.Drawing.Point(12, 249);
			this.lblRequiresRestart.Name = "lblRequiresRestart";
			this.lblRequiresRestart.Size = new System.Drawing.Size(431, 13);
			this.lblRequiresRestart.TabIndex = 5;
			this.lblRequiresRestart.Text = "*";
			// 
			// gbxMap
			// 
			this.gbxMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxMap.Controls.Add(this.cbxMapType);
			this.gbxMap.Controls.Add(this.lblMapType);
			this.gbxMap.Location = new System.Drawing.Point(3, 82);
			this.gbxMap.Name = "gbxMap";
			this.gbxMap.Size = new System.Drawing.Size(452, 73);
			this.gbxMap.TabIndex = 6;
			this.gbxMap.TabStop = false;
			this.gbxMap.Text = "Map";
			// 
			// gbxLanguage
			// 
			this.gbxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxLanguage.Controls.Add(this.lblLanguage);
			this.gbxLanguage.Controls.Add(this.cbxLanguage);
			this.gbxLanguage.Controls.Add(this.lblLanguageRestart);
			this.gbxLanguage.Location = new System.Drawing.Point(3, 3);
			this.gbxLanguage.Name = "gbxLanguage";
			this.gbxLanguage.Size = new System.Drawing.Size(452, 73);
			this.gbxLanguage.TabIndex = 7;
			this.gbxLanguage.TabStop = false;
			this.gbxLanguage.Text = "Language";
			// 
			// lblMapType
			// 
			this.lblMapType.AutoSize = true;
			this.lblMapType.Location = new System.Drawing.Point(20, 28);
			this.lblMapType.Name = "lblMapType";
			this.lblMapType.Size = new System.Drawing.Size(34, 13);
			this.lblMapType.TabIndex = 4;
			this.lblMapType.Text = "Type:";
			// 
			// cbxMapType
			// 
			this.cbxMapType.FormattingEnabled = true;
			this.cbxMapType.Location = new System.Drawing.Point(97, 25);
			this.cbxMapType.Name = "cbxMapType";
			this.cbxMapType.Size = new System.Drawing.Size(137, 21);
			this.cbxMapType.TabIndex = 5;
			this.cbxMapType.SelectedIndexChanged += new System.EventHandler(this.cbxMapType_SelectedIndexChanged);
			this.cbxMapType.TextUpdate += new System.EventHandler(this.cbxMapType_SelectedIndexChanged);
			// 
			// GeneralSettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbxLanguage);
			this.Controls.Add(this.gbxMap);
			this.Controls.Add(this.lblRequiresRestart);
			this.Name = "GeneralSettingsControl";
			this.Size = new System.Drawing.Size(458, 271);
			this.gbxMap.ResumeLayout(false);
			this.gbxMap.PerformLayout();
			this.gbxLanguage.ResumeLayout(false);
			this.gbxLanguage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblLanguage;
		private System.Windows.Forms.ComboBox cbxLanguage;
		private System.Windows.Forms.Label lblLanguageRestart;
		private System.Windows.Forms.Label lblRequiresRestart;
		private System.Windows.Forms.GroupBox gbxMap;
		private System.Windows.Forms.ComboBox cbxMapType;
		private System.Windows.Forms.Label lblMapType;
		private System.Windows.Forms.GroupBox gbxLanguage;
	}
}
