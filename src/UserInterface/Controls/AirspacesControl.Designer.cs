namespace FlightPlanner.UserInterface.Controls {
	partial class AirspacesControl {
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
			this.lvwAirspaces = new System.Windows.Forms.ListView();
			this.clnAirspace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// lvwAirspaces
			// 
			this.lvwAirspaces.CheckBoxes = true;
			this.lvwAirspaces.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnAirspace});
			this.lvwAirspaces.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwAirspaces.FullRowSelect = true;
			this.lvwAirspaces.GridLines = true;
			this.lvwAirspaces.Location = new System.Drawing.Point(0, 0);
			this.lvwAirspaces.MultiSelect = false;
			this.lvwAirspaces.Name = "lvwAirspaces";
			this.lvwAirspaces.Size = new System.Drawing.Size(498, 306);
			this.lvwAirspaces.TabIndex = 0;
			this.lvwAirspaces.UseCompatibleStateImageBehavior = false;
			this.lvwAirspaces.View = System.Windows.Forms.View.Details;
			this.lvwAirspaces.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwAirspaces_ItemChecked);
			// 
			// clnAirspace
			// 
			this.clnAirspace.Text = "Airspace";
			this.clnAirspace.Width = 200;
			// 
			// AirspacesControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lvwAirspaces);
			this.Name = "AirspacesControl";
			this.Size = new System.Drawing.Size(498, 306);
			this.Load += new System.EventHandler(this.AirspacesControl_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvwAirspaces;
		private System.Windows.Forms.ColumnHeader clnAirspace;
	}
}
