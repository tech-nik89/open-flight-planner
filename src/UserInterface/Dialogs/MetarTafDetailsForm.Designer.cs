namespace FlightPlanner.UserInterface.Dialogs {
	partial class MetarTafDetailsForm {
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
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabMetar = new System.Windows.Forms.TabPage();
			this.txtMetar = new System.Windows.Forms.TextBox();
			this.tabTAF = new System.Windows.Forms.TabPage();
			this.txtTaf = new System.Windows.Forms.TextBox();
			this.btnAccept = new System.Windows.Forms.Button();
			this.tabMain.SuspendLayout();
			this.tabMetar.SuspendLayout();
			this.tabTAF.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabMetar);
			this.tabMain.Controls.Add(this.tabTAF);
			this.tabMain.Location = new System.Drawing.Point(12, 12);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(495, 280);
			this.tabMain.TabIndex = 0;
			// 
			// tabMetar
			// 
			this.tabMetar.Controls.Add(this.txtMetar);
			this.tabMetar.Location = new System.Drawing.Point(4, 22);
			this.tabMetar.Name = "tabMetar";
			this.tabMetar.Padding = new System.Windows.Forms.Padding(3);
			this.tabMetar.Size = new System.Drawing.Size(487, 254);
			this.tabMetar.TabIndex = 0;
			this.tabMetar.Text = "METAR";
			this.tabMetar.UseVisualStyleBackColor = true;
			// 
			// txtMetar
			// 
			this.txtMetar.BackColor = System.Drawing.Color.White;
			this.txtMetar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMetar.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMetar.Location = new System.Drawing.Point(3, 3);
			this.txtMetar.Multiline = true;
			this.txtMetar.Name = "txtMetar";
			this.txtMetar.ReadOnly = true;
			this.txtMetar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtMetar.Size = new System.Drawing.Size(481, 248);
			this.txtMetar.TabIndex = 0;
			// 
			// tabTAF
			// 
			this.tabTAF.Controls.Add(this.txtTaf);
			this.tabTAF.Location = new System.Drawing.Point(4, 22);
			this.tabTAF.Name = "tabTAF";
			this.tabTAF.Padding = new System.Windows.Forms.Padding(3);
			this.tabTAF.Size = new System.Drawing.Size(487, 254);
			this.tabTAF.TabIndex = 1;
			this.tabTAF.Text = "TAF";
			this.tabTAF.UseVisualStyleBackColor = true;
			// 
			// txtTaf
			// 
			this.txtTaf.BackColor = System.Drawing.Color.White;
			this.txtTaf.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtTaf.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTaf.Location = new System.Drawing.Point(3, 3);
			this.txtTaf.Multiline = true;
			this.txtTaf.Name = "txtTaf";
			this.txtTaf.ReadOnly = true;
			this.txtTaf.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTaf.Size = new System.Drawing.Size(481, 248);
			this.txtTaf.TabIndex = 1;
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(403, 298);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 1;
			this.btnAccept.Text = "Close";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// MetarTafDetailsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(519, 335);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.tabMain);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(270, 180);
			this.Name = "MetarTafDetailsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "METAR / TAF Details";
			this.tabMain.ResumeLayout(false);
			this.tabMetar.ResumeLayout(false);
			this.tabMetar.PerformLayout();
			this.tabTAF.ResumeLayout(false);
			this.tabTAF.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabMetar;
		private System.Windows.Forms.TabPage tabTAF;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.TextBox txtMetar;
		private System.Windows.Forms.TextBox txtTaf;
	}
}