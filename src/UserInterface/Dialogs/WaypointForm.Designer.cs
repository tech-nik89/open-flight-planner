namespace FlightPlanner.UserInterface.Dialogs {
    partial class WaypointForm {
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
			this.components = new System.ComponentModel.Container();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.lblSearch = new System.Windows.Forms.Label();
			this.gbxSearch = new System.Windows.Forms.GroupBox();
			this.lvwWaypoints = new System.Windows.Forms.ListView();
			this.clnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnLat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnLng = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lblCount = new System.Windows.Forms.Label();
			this.cmsWaypoint = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmsWaypointAirfieldDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.gbxSearch.SuspendLayout();
			this.cmsWaypoint.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(98, 21);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(400, 20);
			this.txtSearch.TabIndex = 0;
			this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(14, 24);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(59, 13);
			this.lblSearch.TabIndex = 1;
			this.lblSearch.Text = "Search for:";
			// 
			// gbxSearch
			// 
			this.gbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxSearch.Controls.Add(this.txtSearch);
			this.gbxSearch.Controls.Add(this.lblSearch);
			this.gbxSearch.Location = new System.Drawing.Point(12, 12);
			this.gbxSearch.Name = "gbxSearch";
			this.gbxSearch.Size = new System.Drawing.Size(517, 53);
			this.gbxSearch.TabIndex = 2;
			this.gbxSearch.TabStop = false;
			this.gbxSearch.Text = "Search";
			// 
			// lvwWaypoints
			// 
			this.lvwWaypoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvwWaypoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnType,
            this.clnName,
            this.clnLat,
            this.clnLng});
			this.lvwWaypoints.ContextMenuStrip = this.cmsWaypoint;
			this.lvwWaypoints.FullRowSelect = true;
			this.lvwWaypoints.GridLines = true;
			this.lvwWaypoints.HideSelection = false;
			this.lvwWaypoints.Location = new System.Drawing.Point(12, 71);
			this.lvwWaypoints.MultiSelect = false;
			this.lvwWaypoints.Name = "lvwWaypoints";
			this.lvwWaypoints.Size = new System.Drawing.Size(517, 207);
			this.lvwWaypoints.TabIndex = 3;
			this.lvwWaypoints.UseCompatibleStateImageBehavior = false;
			this.lvwWaypoints.View = System.Windows.Forms.View.Details;
			this.lvwWaypoints.VirtualMode = true;
			this.lvwWaypoints.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwWaypoints_RetrieveVirtualItem);
			this.lvwWaypoints.DoubleClick += new System.EventHandler(this.btnAdd_Click);
			// 
			// clnType
			// 
			this.clnType.Text = "Type";
			this.clnType.Width = 120;
			// 
			// clnName
			// 
			this.clnName.Text = "Name";
			this.clnName.Width = 160;
			// 
			// clnLat
			// 
			this.clnLat.Text = "Latitude";
			this.clnLat.Width = 100;
			// 
			// clnLng
			// 
			this.clnLng.Text = "Longitude";
			this.clnLng.Width = 100;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(429, 284);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(323, 284);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(100, 25);
			this.btnAdd.TabIndex = 5;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// lblCount
			// 
			this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblCount.AutoSize = true;
			this.lblCount.Location = new System.Drawing.Point(12, 290);
			this.lblCount.Name = "lblCount";
			this.lblCount.Size = new System.Drawing.Size(99, 13);
			this.lblCount.TabIndex = 6;
			this.lblCount.Text = "Waypoints found: 0";
			// 
			// cmsWaypoint
			// 
			this.cmsWaypoint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsWaypointAirfieldDetails});
			this.cmsWaypoint.Name = "cmsWaypoint";
			this.cmsWaypoint.Size = new System.Drawing.Size(110, 26);
			this.cmsWaypoint.Opening += new System.ComponentModel.CancelEventHandler(this.cmsWaypoint_Opening);
			// 
			// cmsWaypointAirfieldDetails
			// 
			this.cmsWaypointAirfieldDetails.Name = "cmsWaypointAirfieldDetails";
			this.cmsWaypointAirfieldDetails.Size = new System.Drawing.Size(152, 22);
			this.cmsWaypointAirfieldDetails.Text = "Details";
			this.cmsWaypointAirfieldDetails.Click += new System.EventHandler(this.cmsWaypointAirfieldDetails_Click);
			// 
			// WaypointForm
			// 
			this.AcceptButton = this.btnAdd;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(541, 321);
			this.Controls.Add(this.lblCount);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lvwWaypoints);
			this.Controls.Add(this.gbxSearch);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(410, 270);
			this.Name = "WaypointForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Waypoints";
			this.gbxSearch.ResumeLayout(false);
			this.gbxSearch.PerformLayout();
			this.cmsWaypoint.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.GroupBox gbxSearch;
        private System.Windows.Forms.ListView lvwWaypoints;
        private System.Windows.Forms.ColumnHeader clnType;
        private System.Windows.Forms.ColumnHeader clnName;
        private System.Windows.Forms.ColumnHeader clnLat;
        private System.Windows.Forms.ColumnHeader clnLng;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Label lblCount;
		private System.Windows.Forms.ContextMenuStrip cmsWaypoint;
		private System.Windows.Forms.ToolStripMenuItem cmsWaypointAirfieldDetails;
	}
}