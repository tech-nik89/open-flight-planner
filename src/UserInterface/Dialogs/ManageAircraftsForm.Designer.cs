namespace FlightPlanner.UserInterface.Dialogs {
    partial class ManageAircraftsForm {
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
			this.lvwAircrafts = new System.Windows.Forms.ListView();
			this.clnRegistration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbAdd = new System.Windows.Forms.ToolStripButton();
			this.tsbEdit = new System.Windows.Forms.ToolStripButton();
			this.tsbRemove = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbUse = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwAircrafts
			// 
			this.lvwAircrafts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvwAircrafts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnRegistration,
            this.clnType});
			this.lvwAircrafts.FullRowSelect = true;
			this.lvwAircrafts.GridLines = true;
			this.lvwAircrafts.HideSelection = false;
			this.lvwAircrafts.Location = new System.Drawing.Point(0, 28);
			this.lvwAircrafts.MultiSelect = false;
			this.lvwAircrafts.Name = "lvwAircrafts";
			this.lvwAircrafts.Size = new System.Drawing.Size(497, 240);
			this.lvwAircrafts.TabIndex = 0;
			this.lvwAircrafts.UseCompatibleStateImageBehavior = false;
			this.lvwAircrafts.View = System.Windows.Forms.View.Details;
			this.lvwAircrafts.VirtualMode = true;
			this.lvwAircrafts.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwAircrafts_RetrieveVirtualItem);
			this.lvwAircrafts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwAircrafts_MouseDoubleClick);
			// 
			// clnRegistration
			// 
			this.clnRegistration.Text = "Registration";
			this.clnRegistration.Width = 120;
			// 
			// clnType
			// 
			this.clnType.Text = "Type";
			this.clnType.Width = 100;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbRemove,
            this.toolStripSeparator1,
            this.tsbUse});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(497, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
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
			// tsbUse
			// 
			this.tsbUse.Image = global::FlightPlanner.UserInterface.Properties.Resources.Apply;
			this.tsbUse.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbUse.Name = "tsbUse";
			this.tsbUse.Size = new System.Drawing.Size(88, 22);
			this.tsbUse.Text = "Use Aircraft";
			this.tsbUse.Click += new System.EventHandler(this.tsbUse_Click);
			// 
			// ManageAircraftsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(497, 268);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.lvwAircrafts);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(340, 180);
			this.Name = "ManageAircraftsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Manage aircrafts";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwAircrafts;
        private System.Windows.Forms.ColumnHeader clnRegistration;
        private System.Windows.Forms.ColumnHeader clnType;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbUse;
    }
}