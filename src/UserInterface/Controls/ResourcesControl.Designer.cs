namespace FlightPlanner.UserInterface.Controls {
    partial class ResourcesControl {
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
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbEdit = new System.Windows.Forms.ToolStripButton();
			this.tsbRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
			this.lvwResources = new System.Windows.Forms.ListView();
			this.clnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnVisible = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tsbAdd = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbRemove,
            this.toolStripSeparator1,
            this.tsbUpdate});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(520, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbEdit
			// 
			this.tsbEdit.Image = global::FlightPlanner.UserInterface.Properties.Resources.Edit;
			this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbEdit.Name = "tsbEdit";
			this.tsbEdit.Size = new System.Drawing.Size(47, 22);
			this.tsbEdit.Text = "Edit";
			this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
			// 
			// tsbRemove
			// 
			this.tsbRemove.Image = global::FlightPlanner.UserInterface.Properties.Resources.Delete;
			this.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRemove.Name = "tsbRemove";
			this.tsbRemove.Size = new System.Drawing.Size(70, 22);
			this.tsbRemove.Text = "Remove";
			this.tsbRemove.Click += new System.EventHandler(this.tsbRemove_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbUpdate
			// 
			this.tsbUpdate.Image = global::FlightPlanner.UserInterface.Properties.Resources.Website;
			this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbUpdate.Name = "tsbUpdate";
			this.tsbUpdate.Size = new System.Drawing.Size(65, 22);
			this.tsbUpdate.Text = "Update";
			this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
			// 
			// lvwResources
			// 
			this.lvwResources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnName,
            this.clnVisible,
            this.clnPath});
			this.lvwResources.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwResources.FullRowSelect = true;
			this.lvwResources.Location = new System.Drawing.Point(0, 25);
			this.lvwResources.Name = "lvwResources";
			this.lvwResources.Size = new System.Drawing.Size(520, 268);
			this.lvwResources.TabIndex = 1;
			this.lvwResources.UseCompatibleStateImageBehavior = false;
			this.lvwResources.View = System.Windows.Forms.View.Details;
			this.lvwResources.DoubleClick += new System.EventHandler(this.tsbEdit_Click);
			// 
			// clnName
			// 
			this.clnName.Text = "Name";
			this.clnName.Width = 120;
			// 
			// clnVisible
			// 
			this.clnVisible.Text = "Visible";
			// 
			// clnPath
			// 
			this.clnPath.Text = "Path";
			this.clnPath.Width = 280;
			// 
			// tsbAdd
			// 
			this.tsbAdd.Image = global::FlightPlanner.UserInterface.Properties.Resources.Add;
			this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAdd.Name = "tsbAdd";
			this.tsbAdd.Size = new System.Drawing.Size(49, 22);
			this.tsbAdd.Text = "Add";
			this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
			// 
			// ResourcesControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lvwResources);
			this.Controls.Add(this.toolStrip1);
			this.Name = "ResourcesControl";
			this.Size = new System.Drawing.Size(520, 293);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListView lvwResources;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ColumnHeader clnName;
        private System.Windows.Forms.ColumnHeader clnPath;
        private System.Windows.Forms.ColumnHeader clnVisible;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbUpdate;
		private System.Windows.Forms.ToolStripButton tsbAdd;
	}
}
