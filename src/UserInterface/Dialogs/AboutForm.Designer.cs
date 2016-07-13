namespace FlightPlanner.UserInterface.Dialogs {
	partial class AboutForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.lblApp = new System.Windows.Forms.Label();
			this.lblVersionTitle = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.lblThirdpartyComponents = new System.Windows.Forms.Label();
			this.txtLibraries = new System.Windows.Forms.TextBox();
			this.txtDisclaimer = new System.Windows.Forms.TextBox();
			this.lblDisclaimer = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblApp
			// 
			this.lblApp.AutoSize = true;
			this.lblApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblApp.Location = new System.Drawing.Point(11, 9);
			this.lblApp.Name = "lblApp";
			this.lblApp.Size = new System.Drawing.Size(179, 24);
			this.lblApp.TabIndex = 0;
			this.lblApp.Text = "Open Flight Planner";
			// 
			// lblVersionTitle
			// 
			this.lblVersionTitle.AutoSize = true;
			this.lblVersionTitle.Location = new System.Drawing.Point(12, 49);
			this.lblVersionTitle.Name = "lblVersionTitle";
			this.lblVersionTitle.Size = new System.Drawing.Size(45, 13);
			this.lblVersionTitle.TabIndex = 1;
			this.lblVersionTitle.Text = "Version:";
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new System.Drawing.Point(141, 49);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(31, 13);
			this.lblVersion.TabIndex = 2;
			this.lblVersion.Text = "1.0.0";
			// 
			// lblThirdpartyComponents
			// 
			this.lblThirdpartyComponents.AutoSize = true;
			this.lblThirdpartyComponents.Location = new System.Drawing.Point(12, 72);
			this.lblThirdpartyComponents.Name = "lblThirdpartyComponents";
			this.lblThirdpartyComponents.Size = new System.Drawing.Size(118, 13);
			this.lblThirdpartyComponents.TabIndex = 3;
			this.lblThirdpartyComponents.Text = "Thirdparty components:";
			// 
			// txtLibraries
			// 
			this.txtLibraries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLibraries.Location = new System.Drawing.Point(144, 69);
			this.txtLibraries.Multiline = true;
			this.txtLibraries.Name = "txtLibraries";
			this.txtLibraries.ReadOnly = true;
			this.txtLibraries.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLibraries.Size = new System.Drawing.Size(496, 99);
			this.txtLibraries.TabIndex = 4;
			this.txtLibraries.Text = resources.GetString("txtLibraries.Text");
			// 
			// txtDisclaimer
			// 
			this.txtDisclaimer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDisclaimer.Location = new System.Drawing.Point(144, 174);
			this.txtDisclaimer.Multiline = true;
			this.txtDisclaimer.Name = "txtDisclaimer";
			this.txtDisclaimer.ReadOnly = true;
			this.txtDisclaimer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDisclaimer.Size = new System.Drawing.Size(496, 193);
			this.txtDisclaimer.TabIndex = 6;
			// 
			// lblDisclaimer
			// 
			this.lblDisclaimer.AutoSize = true;
			this.lblDisclaimer.Location = new System.Drawing.Point(12, 177);
			this.lblDisclaimer.Name = "lblDisclaimer";
			this.lblDisclaimer.Size = new System.Drawing.Size(58, 13);
			this.lblDisclaimer.TabIndex = 5;
			this.lblDisclaimer.Text = "Disclaimer:";
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(652, 379);
			this.Controls.Add(this.txtDisclaimer);
			this.Controls.Add(this.lblDisclaimer);
			this.Controls.Add(this.txtLibraries);
			this.Controls.Add(this.lblThirdpartyComponents);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.lblVersionTitle);
			this.Controls.Add(this.lblApp);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Info";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblApp;
		private System.Windows.Forms.Label lblVersionTitle;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.Label lblThirdpartyComponents;
		private System.Windows.Forms.TextBox txtLibraries;
		private System.Windows.Forms.TextBox txtDisclaimer;
		private System.Windows.Forms.Label lblDisclaimer;
	}
}