namespace FlightPlanner.UserInterface.Controls {
	partial class PluginConfigurationControl {
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("METAR Weather Source", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Enroute Weather Source", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Notam Source", System.Windows.Forms.HorizontalAlignment.Left);
			this.lvwPlugins = new System.Windows.Forms.ListView();
			this.clnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbConfigurePlugin = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwPlugins
			// 
			this.lvwPlugins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvwPlugins.CheckBoxes = true;
			this.lvwPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnName});
			this.lvwPlugins.FullRowSelect = true;
			listViewGroup1.Header = "METAR Weather Source";
			listViewGroup1.Name = "grpWeatherMetar";
			listViewGroup2.Header = "Enroute Weather Source";
			listViewGroup2.Name = "grpWeatherEnroute";
			listViewGroup3.Header = "Notam Source";
			listViewGroup3.Name = "grpNotams";
			this.lvwPlugins.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
			this.lvwPlugins.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvwPlugins.Location = new System.Drawing.Point(0, 28);
			this.lvwPlugins.MultiSelect = false;
			this.lvwPlugins.Name = "lvwPlugins";
			this.lvwPlugins.Size = new System.Drawing.Size(491, 300);
			this.lvwPlugins.TabIndex = 0;
			this.lvwPlugins.UseCompatibleStateImageBehavior = false;
			this.lvwPlugins.View = System.Windows.Forms.View.Details;
			this.lvwPlugins.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwPlugins_ItemChecked);
			this.lvwPlugins.SelectedIndexChanged += new System.EventHandler(this.lvwPlugins_SelectedIndexChanged);
			// 
			// clnName
			// 
			this.clnName.Text = "Name";
			this.clnName.Width = 320;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbConfigurePlugin});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(491, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbConfigurePlugin
			// 
			this.tsbConfigurePlugin.Enabled = false;
			this.tsbConfigurePlugin.Image = global::FlightPlanner.UserInterface.Properties.Resources.Configuration;
			this.tsbConfigurePlugin.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbConfigurePlugin.Name = "tsbConfigurePlugin";
			this.tsbConfigurePlugin.Size = new System.Drawing.Size(80, 22);
			this.tsbConfigurePlugin.Text = "Configure";
			this.tsbConfigurePlugin.Click += new System.EventHandler(this.tsbConfigurePlugin_Click);
			// 
			// PluginConfigurationControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.lvwPlugins);
			this.Name = "PluginConfigurationControl";
			this.Size = new System.Drawing.Size(491, 328);
			this.Load += new System.EventHandler(this.PluginConfigurationControl_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lvwPlugins;
		private System.Windows.Forms.ColumnHeader clnName;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbConfigurePlugin;
	}
}
