namespace FlightPlanner.UserInterface.Dialogs {
    partial class MassAndBalanceForm {
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.scMain = new System.Windows.Forms.SplitContainer();
			this.dgvStations = new System.Windows.Forms.DataGridView();
			this.clnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnLeverArm = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnMass = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnFuelTankSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.crtCenterOfGravity = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.lvwMass = new System.Windows.Forms.ListView();
			this.clnFuelKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnFuelValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabMass = new System.Windows.Forms.TabPage();
			this.tabFuel = new System.Windows.Forms.TabPage();
			this.lvwFuel = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.crtCenterOfGravity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabMass.SuspendLayout();
			this.tabFuel.SuspendLayout();
			this.SuspendLayout();
			// 
			// scMain
			// 
			this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.scMain.Location = new System.Drawing.Point(0, 0);
			this.scMain.Name = "scMain";
			this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.AutoScroll = true;
			this.scMain.Panel1.Controls.Add(this.dgvStations);
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.Controls.Add(this.splitContainer1);
			this.scMain.Size = new System.Drawing.Size(656, 406);
			this.scMain.SplitterDistance = 158;
			this.scMain.TabIndex = 0;
			// 
			// dgvStations
			// 
			this.dgvStations.AllowUserToAddRows = false;
			this.dgvStations.AllowUserToDeleteRows = false;
			this.dgvStations.AllowUserToResizeColumns = false;
			this.dgvStations.AllowUserToResizeRows = false;
			this.dgvStations.BackgroundColor = System.Drawing.Color.White;
			this.dgvStations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.dgvStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnName,
            this.clnLeverArm,
            this.clnMass,
            this.clnFuelTankSize});
			this.dgvStations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvStations.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvStations.Location = new System.Drawing.Point(0, 0);
			this.dgvStations.MultiSelect = false;
			this.dgvStations.Name = "dgvStations";
			this.dgvStations.RowHeadersVisible = false;
			this.dgvStations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvStations.Size = new System.Drawing.Size(656, 158);
			this.dgvStations.TabIndex = 1;
			this.dgvStations.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStations_CellValueChanged);
			// 
			// clnName
			// 
			this.clnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.clnName.HeaderText = "Name";
			this.clnName.Name = "clnName";
			this.clnName.ReadOnly = true;
			this.clnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// clnLeverArm
			// 
			this.clnLeverArm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.clnLeverArm.HeaderText = "Lever Arm";
			this.clnLeverArm.Name = "clnLeverArm";
			this.clnLeverArm.ReadOnly = true;
			this.clnLeverArm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// clnMass
			// 
			this.clnMass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.clnMass.HeaderText = "Mass";
			this.clnMass.Name = "clnMass";
			this.clnMass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// clnFuelTankSize
			// 
			this.clnFuelTankSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.clnFuelTankSize.HeaderText = "Capacity";
			this.clnFuelTankSize.Name = "clnFuelTankSize";
			this.clnFuelTankSize.ReadOnly = true;
			this.clnFuelTankSize.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.clnFuelTankSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// crtCenterOfGravity
			// 
			chartArea1.AlignmentOrientation = ((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical | System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal)));
			chartArea1.AxisX.Crossing = -1.7976931348623157E+308D;
			chartArea1.AxisX.IsStartedFromZero = false;
			chartArea1.AxisX.LabelStyle.Format = "{0:0.000}";
			chartArea1.AxisX.LineColor = System.Drawing.Color.DarkGray;
			chartArea1.AxisX.MajorGrid.Enabled = false;
			chartArea1.AxisX.MajorTickMark.Enabled = false;
			chartArea1.AxisX.MinorTickMark.Enabled = true;
			chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Gray;
			chartArea1.AxisY.IsStartedFromZero = false;
			chartArea1.AxisY.LabelStyle.Format = "{0:0}";
			chartArea1.AxisY.LineColor = System.Drawing.Color.DarkGray;
			chartArea1.AxisY.MajorGrid.Enabled = false;
			chartArea1.AxisY.MajorTickMark.Enabled = false;
			chartArea1.Name = "ChartArea1";
			this.crtCenterOfGravity.ChartAreas.Add(chartArea1);
			this.crtCenterOfGravity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crtCenterOfGravity.Location = new System.Drawing.Point(0, 0);
			this.crtCenterOfGravity.Name = "crtCenterOfGravity";
			this.crtCenterOfGravity.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square;
			series1.Name = "Series1";
			this.crtCenterOfGravity.Series.Add(series1);
			this.crtCenterOfGravity.Size = new System.Drawing.Size(377, 244);
			this.crtCenterOfGravity.TabIndex = 0;
			this.crtCenterOfGravity.Text = "chart1";
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.crtCenterOfGravity);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer1.Size = new System.Drawing.Size(656, 244);
			this.splitContainer1.SplitterDistance = 377;
			this.splitContainer1.TabIndex = 1;
			// 
			// lvwMass
			// 
			this.lvwMass.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnFuelKey,
            this.clnFuelValue});
			this.lvwMass.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwMass.FullRowSelect = true;
			this.lvwMass.GridLines = true;
			this.lvwMass.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvwMass.Location = new System.Drawing.Point(3, 3);
			this.lvwMass.Name = "lvwMass";
			this.lvwMass.Size = new System.Drawing.Size(261, 212);
			this.lvwMass.TabIndex = 0;
			this.lvwMass.UseCompatibleStateImageBehavior = false;
			this.lvwMass.View = System.Windows.Forms.View.Details;
			// 
			// clnFuelKey
			// 
			this.clnFuelKey.Width = 120;
			// 
			// clnFuelValue
			// 
			this.clnFuelValue.Width = 120;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabMass);
			this.tabControl1.Controls.Add(this.tabFuel);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(275, 244);
			this.tabControl1.TabIndex = 1;
			// 
			// tabMass
			// 
			this.tabMass.Controls.Add(this.lvwMass);
			this.tabMass.Location = new System.Drawing.Point(4, 22);
			this.tabMass.Name = "tabMass";
			this.tabMass.Padding = new System.Windows.Forms.Padding(3);
			this.tabMass.Size = new System.Drawing.Size(267, 218);
			this.tabMass.TabIndex = 0;
			this.tabMass.Text = "Mass";
			this.tabMass.UseVisualStyleBackColor = true;
			// 
			// tabFuel
			// 
			this.tabFuel.Controls.Add(this.lvwFuel);
			this.tabFuel.Location = new System.Drawing.Point(4, 22);
			this.tabFuel.Name = "tabFuel";
			this.tabFuel.Padding = new System.Windows.Forms.Padding(3);
			this.tabFuel.Size = new System.Drawing.Size(267, 218);
			this.tabFuel.TabIndex = 1;
			this.tabFuel.Text = "Fuel";
			this.tabFuel.UseVisualStyleBackColor = true;
			// 
			// lvwFuel
			// 
			this.lvwFuel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.lvwFuel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwFuel.FullRowSelect = true;
			this.lvwFuel.GridLines = true;
			this.lvwFuel.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvwFuel.Location = new System.Drawing.Point(3, 3);
			this.lvwFuel.Name = "lvwFuel";
			this.lvwFuel.Size = new System.Drawing.Size(261, 212);
			this.lvwFuel.TabIndex = 1;
			this.lvwFuel.UseCompatibleStateImageBehavior = false;
			this.lvwFuel.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Width = 120;
			// 
			// MassAndBalanceForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(656, 406);
			this.Controls.Add(this.scMain);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(340, 290);
			this.Name = "MassAndBalanceForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Mass And Balance";
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
			this.scMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.crtCenterOfGravity)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabMass.ResumeLayout(false);
			this.tabFuel.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtCenterOfGravity;
        private System.Windows.Forms.DataGridView dgvStations;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLeverArm;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMass;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFuelTankSize;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListView lvwMass;
		private System.Windows.Forms.ColumnHeader clnFuelKey;
		private System.Windows.Forms.ColumnHeader clnFuelValue;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabMass;
		private System.Windows.Forms.TabPage tabFuel;
		private System.Windows.Forms.ListView lvwFuel;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
	}
}