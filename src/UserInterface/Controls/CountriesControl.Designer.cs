namespace FlightPlanner.UserInterface.Controls {
    partial class CountriesControl {
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
            this.lvwCountries = new System.Windows.Forms.ListView();
            this.clnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwCountries
            // 
            this.lvwCountries.CheckBoxes = true;
            this.lvwCountries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnName});
            this.lvwCountries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCountries.FullRowSelect = true;
            this.lvwCountries.GridLines = true;
            this.lvwCountries.Location = new System.Drawing.Point(0, 0);
            this.lvwCountries.Name = "lvwCountries";
            this.lvwCountries.Size = new System.Drawing.Size(448, 272);
            this.lvwCountries.TabIndex = 0;
            this.lvwCountries.UseCompatibleStateImageBehavior = false;
            this.lvwCountries.View = System.Windows.Forms.View.Details;
            this.lvwCountries.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvwCountries_ItemCheck);
            // 
            // clnName
            // 
            this.clnName.Text = "Name";
            this.clnName.Width = 240;
            // 
            // CountriesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwCountries);
            this.Name = "CountriesControl";
            this.Size = new System.Drawing.Size(448, 272);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwCountries;
        private System.Windows.Forms.ColumnHeader clnName;
    }
}
