namespace FlightPlanner.UserInterface.Dialogs {
    partial class SettingsForm {
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
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.gscSettings = new FlightPlanner.UserInterface.Controls.GeneralSettingsControl();
			this.tabResources = new System.Windows.Forms.TabPage();
			this.ascResources = new FlightPlanner.UserInterface.Controls.ResourcesControl();
			this.tabCountries = new System.Windows.Forms.TabPage();
			this.ccCountries = new FlightPlanner.UserInterface.Controls.CountriesControl();
			this.tabAirspaces = new System.Windows.Forms.TabPage();
			this.ascAirspaces = new FlightPlanner.UserInterface.Controls.AirspacesControl();
			this.tabPlugins = new System.Windows.Forms.TabPage();
			this.pccPlugins = new FlightPlanner.UserInterface.Controls.PluginConfigurationControl();
			this.tabMain.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.tabResources.SuspendLayout();
			this.tabCountries.SuspendLayout();
			this.tabAirspaces.SuspendLayout();
			this.tabPlugins.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabGeneral);
			this.tabMain.Controls.Add(this.tabResources);
			this.tabMain.Controls.Add(this.tabCountries);
			this.tabMain.Controls.Add(this.tabAirspaces);
			this.tabMain.Controls.Add(this.tabPlugins);
			this.tabMain.Location = new System.Drawing.Point(12, 12);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(546, 289);
			this.tabMain.TabIndex = 0;
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.gscSettings);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabGeneral.Size = new System.Drawing.Size(538, 263);
			this.tabGeneral.TabIndex = 3;
			this.tabGeneral.Text = "General";
			this.tabGeneral.UseVisualStyleBackColor = true;
			// 
			// gscSettings
			// 
			this.gscSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gscSettings.Location = new System.Drawing.Point(3, 3);
			this.gscSettings.Name = "gscSettings";
			this.gscSettings.Size = new System.Drawing.Size(532, 257);
			this.gscSettings.TabIndex = 0;
			// 
			// tabResources
			// 
			this.tabResources.Controls.Add(this.ascResources);
			this.tabResources.Location = new System.Drawing.Point(4, 22);
			this.tabResources.Name = "tabResources";
			this.tabResources.Padding = new System.Windows.Forms.Padding(3);
			this.tabResources.Size = new System.Drawing.Size(538, 263);
			this.tabResources.TabIndex = 0;
			this.tabResources.Text = "Resource Files";
			this.tabResources.UseVisualStyleBackColor = true;
			// 
			// ascResources
			// 
			this.ascResources.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ascResources.Location = new System.Drawing.Point(3, 3);
			this.ascResources.Name = "ascResources";
			this.ascResources.Size = new System.Drawing.Size(532, 257);
			this.ascResources.TabIndex = 0;
			// 
			// tabCountries
			// 
			this.tabCountries.Controls.Add(this.ccCountries);
			this.tabCountries.Location = new System.Drawing.Point(4, 22);
			this.tabCountries.Name = "tabCountries";
			this.tabCountries.Padding = new System.Windows.Forms.Padding(3);
			this.tabCountries.Size = new System.Drawing.Size(538, 263);
			this.tabCountries.TabIndex = 1;
			this.tabCountries.Text = "Countries";
			this.tabCountries.UseVisualStyleBackColor = true;
			// 
			// ccCountries
			// 
			this.ccCountries.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ccCountries.Location = new System.Drawing.Point(3, 3);
			this.ccCountries.Name = "ccCountries";
			this.ccCountries.Size = new System.Drawing.Size(532, 257);
			this.ccCountries.TabIndex = 0;
			// 
			// tabAirspaces
			// 
			this.tabAirspaces.Controls.Add(this.ascAirspaces);
			this.tabAirspaces.Location = new System.Drawing.Point(4, 22);
			this.tabAirspaces.Name = "tabAirspaces";
			this.tabAirspaces.Padding = new System.Windows.Forms.Padding(3);
			this.tabAirspaces.Size = new System.Drawing.Size(538, 263);
			this.tabAirspaces.TabIndex = 4;
			this.tabAirspaces.Text = "Airspaces";
			this.tabAirspaces.UseVisualStyleBackColor = true;
			// 
			// ascAirspaces
			// 
			this.ascAirspaces.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ascAirspaces.Location = new System.Drawing.Point(3, 3);
			this.ascAirspaces.Name = "ascAirspaces";
			this.ascAirspaces.Size = new System.Drawing.Size(532, 257);
			this.ascAirspaces.TabIndex = 0;
			// 
			// tabPlugins
			// 
			this.tabPlugins.Controls.Add(this.pccPlugins);
			this.tabPlugins.Location = new System.Drawing.Point(4, 22);
			this.tabPlugins.Name = "tabPlugins";
			this.tabPlugins.Padding = new System.Windows.Forms.Padding(3);
			this.tabPlugins.Size = new System.Drawing.Size(538, 263);
			this.tabPlugins.TabIndex = 2;
			this.tabPlugins.Text = "Plugins";
			this.tabPlugins.UseVisualStyleBackColor = true;
			// 
			// pccPlugins
			// 
			this.pccPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pccPlugins.Location = new System.Drawing.Point(3, 3);
			this.pccPlugins.Name = "pccPlugins";
			this.pccPlugins.Size = new System.Drawing.Size(532, 257);
			this.pccPlugins.TabIndex = 0;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(570, 313);
			this.Controls.Add(this.tabMain);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(410, 250);
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Settings";
			this.tabMain.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabResources.ResumeLayout(false);
			this.tabCountries.ResumeLayout(false);
			this.tabAirspaces.ResumeLayout(false);
			this.tabPlugins.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabResources;
        private Controls.ResourcesControl ascResources;
        private System.Windows.Forms.TabPage tabCountries;
        private Controls.CountriesControl ccCountries;
		private System.Windows.Forms.TabPage tabPlugins;
		private Controls.PluginConfigurationControl pccPlugins;
		private System.Windows.Forms.TabPage tabGeneral;
		private Controls.GeneralSettingsControl gscSettings;
		private System.Windows.Forms.TabPage tabAirspaces;
		private Controls.AirspacesControl ascAirspaces;
	}
}