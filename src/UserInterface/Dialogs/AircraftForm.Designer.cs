﻿namespace FlightPlanner.UserInterface.Dialogs {
    partial class AircraftForm {
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			this.gbxGeneral = new System.Windows.Forms.GroupBox();
			this.txtType = new System.Windows.Forms.TextBox();
			this.lblType = new System.Windows.Forms.Label();
			this.txtRegistration = new System.Windows.Forms.TextBox();
			this.lblRegistration = new System.Windows.Forms.Label();
			this.tabCtrl = new System.Windows.Forms.TabControl();
			this.tabProperties = new System.Windows.Forms.TabPage();
			this.pgProperties = new System.Windows.Forms.PropertyGrid();
			this.tabStations = new System.Windows.Forms.TabPage();
			this.dgvStations = new System.Windows.Forms.DataGridView();
			this.clnStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnStationArm = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabFuelTanks = new System.Windows.Forms.TabPage();
			this.dgvFuelTanks = new System.Windows.Forms.DataGridView();
			this.clnFuelTankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnFuelTankArm = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnFuelTankCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabCenterOfGravity = new System.Windows.Forms.TabPage();
			this.dgvCenterOfGravity = new System.Windows.Forms.DataGridView();
			this.clnMass = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnForwardLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnAftLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabCruisePerformance = new System.Windows.Forms.TabPage();
			this.dgvCruisePerformance = new System.Windows.Forms.DataGridView();
			this.clnCruisePerformanceAltitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCruisePerformanceTrueAirspeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnCruisePerformanceFuelFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabClimbPerformance = new System.Windows.Forms.TabPage();
			this.dgvClimbPerformance = new System.Windows.Forms.DataGridView();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.clnClimbPerformanceAltitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnClimbPerformanceTrueAirspeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnClimbPerformanceFuelFlow = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.clnClimbPerformanceRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gbxGeneral.SuspendLayout();
			this.tabCtrl.SuspendLayout();
			this.tabProperties.SuspendLayout();
			this.tabStations.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
			this.tabFuelTanks.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvFuelTanks)).BeginInit();
			this.tabCenterOfGravity.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCenterOfGravity)).BeginInit();
			this.tabCruisePerformance.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCruisePerformance)).BeginInit();
			this.tabClimbPerformance.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvClimbPerformance)).BeginInit();
			this.SuspendLayout();
			// 
			// gbxGeneral
			// 
			this.gbxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxGeneral.Controls.Add(this.txtType);
			this.gbxGeneral.Controls.Add(this.lblType);
			this.gbxGeneral.Controls.Add(this.txtRegistration);
			this.gbxGeneral.Controls.Add(this.lblRegistration);
			this.gbxGeneral.Location = new System.Drawing.Point(12, 12);
			this.gbxGeneral.Name = "gbxGeneral";
			this.gbxGeneral.Size = new System.Drawing.Size(596, 88);
			this.gbxGeneral.TabIndex = 0;
			this.gbxGeneral.TabStop = false;
			this.gbxGeneral.Text = "General";
			// 
			// txtType
			// 
			this.txtType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtType.Location = new System.Drawing.Point(92, 51);
			this.txtType.Name = "txtType";
			this.txtType.Size = new System.Drawing.Size(478, 20);
			this.txtType.TabIndex = 3;
			// 
			// lblType
			// 
			this.lblType.AutoSize = true;
			this.lblType.Location = new System.Drawing.Point(20, 54);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(34, 13);
			this.lblType.TabIndex = 2;
			this.lblType.Text = "Type:";
			// 
			// txtRegistration
			// 
			this.txtRegistration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRegistration.Location = new System.Drawing.Point(92, 25);
			this.txtRegistration.Name = "txtRegistration";
			this.txtRegistration.Size = new System.Drawing.Size(478, 20);
			this.txtRegistration.TabIndex = 1;
			// 
			// lblRegistration
			// 
			this.lblRegistration.AutoSize = true;
			this.lblRegistration.Location = new System.Drawing.Point(20, 28);
			this.lblRegistration.Name = "lblRegistration";
			this.lblRegistration.Size = new System.Drawing.Size(66, 13);
			this.lblRegistration.TabIndex = 0;
			this.lblRegistration.Text = "Registration:";
			// 
			// tabCtrl
			// 
			this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabCtrl.Controls.Add(this.tabProperties);
			this.tabCtrl.Controls.Add(this.tabStations);
			this.tabCtrl.Controls.Add(this.tabFuelTanks);
			this.tabCtrl.Controls.Add(this.tabCenterOfGravity);
			this.tabCtrl.Controls.Add(this.tabCruisePerformance);
			this.tabCtrl.Controls.Add(this.tabClimbPerformance);
			this.tabCtrl.Location = new System.Drawing.Point(12, 106);
			this.tabCtrl.Name = "tabCtrl";
			this.tabCtrl.SelectedIndex = 0;
			this.tabCtrl.Size = new System.Drawing.Size(596, 284);
			this.tabCtrl.TabIndex = 1;
			// 
			// tabProperties
			// 
			this.tabProperties.Controls.Add(this.pgProperties);
			this.tabProperties.Location = new System.Drawing.Point(4, 22);
			this.tabProperties.Name = "tabProperties";
			this.tabProperties.Padding = new System.Windows.Forms.Padding(3);
			this.tabProperties.Size = new System.Drawing.Size(588, 258);
			this.tabProperties.TabIndex = 0;
			this.tabProperties.Text = "Properties";
			this.tabProperties.UseVisualStyleBackColor = true;
			// 
			// pgProperties
			// 
			this.pgProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pgProperties.HelpVisible = false;
			this.pgProperties.Location = new System.Drawing.Point(3, 3);
			this.pgProperties.Name = "pgProperties";
			this.pgProperties.Size = new System.Drawing.Size(582, 252);
			this.pgProperties.TabIndex = 1;
			this.pgProperties.ToolbarVisible = false;
			// 
			// tabStations
			// 
			this.tabStations.Controls.Add(this.dgvStations);
			this.tabStations.Location = new System.Drawing.Point(4, 22);
			this.tabStations.Name = "tabStations";
			this.tabStations.Padding = new System.Windows.Forms.Padding(3);
			this.tabStations.Size = new System.Drawing.Size(588, 258);
			this.tabStations.TabIndex = 1;
			this.tabStations.Text = "Loading Stations";
			this.tabStations.UseVisualStyleBackColor = true;
			// 
			// dgvStations
			// 
			this.dgvStations.AllowUserToOrderColumns = true;
			this.dgvStations.AllowUserToResizeColumns = false;
			this.dgvStations.AllowUserToResizeRows = false;
			this.dgvStations.BackgroundColor = System.Drawing.Color.White;
			this.dgvStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnStationName,
            this.clnStationArm});
			this.dgvStations.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvStations.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvStations.Location = new System.Drawing.Point(3, 3);
			this.dgvStations.Name = "dgvStations";
			this.dgvStations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvStations.Size = new System.Drawing.Size(582, 252);
			this.dgvStations.TabIndex = 0;
			// 
			// clnStationName
			// 
			this.clnStationName.HeaderText = "Name";
			this.clnStationName.Name = "clnStationName";
			this.clnStationName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.clnStationName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.clnStationName.Width = 200;
			// 
			// clnStationArm
			// 
			this.clnStationArm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle1.Format = "N3";
			dataGridViewCellStyle1.NullValue = null;
			this.clnStationArm.DefaultCellStyle = dataGridViewCellStyle1;
			this.clnStationArm.HeaderText = "Arm";
			this.clnStationArm.Name = "clnStationArm";
			this.clnStationArm.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.clnStationArm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// tabFuelTanks
			// 
			this.tabFuelTanks.Controls.Add(this.dgvFuelTanks);
			this.tabFuelTanks.Location = new System.Drawing.Point(4, 22);
			this.tabFuelTanks.Name = "tabFuelTanks";
			this.tabFuelTanks.Padding = new System.Windows.Forms.Padding(3);
			this.tabFuelTanks.Size = new System.Drawing.Size(588, 258);
			this.tabFuelTanks.TabIndex = 2;
			this.tabFuelTanks.Text = "Fuel Tanks";
			this.tabFuelTanks.UseVisualStyleBackColor = true;
			// 
			// dgvFuelTanks
			// 
			this.dgvFuelTanks.AllowUserToOrderColumns = true;
			this.dgvFuelTanks.AllowUserToResizeColumns = false;
			this.dgvFuelTanks.AllowUserToResizeRows = false;
			this.dgvFuelTanks.BackgroundColor = System.Drawing.Color.White;
			this.dgvFuelTanks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvFuelTanks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnFuelTankName,
            this.clnFuelTankArm,
            this.clnFuelTankCapacity});
			this.dgvFuelTanks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvFuelTanks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvFuelTanks.Location = new System.Drawing.Point(3, 3);
			this.dgvFuelTanks.Name = "dgvFuelTanks";
			this.dgvFuelTanks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvFuelTanks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvFuelTanks.Size = new System.Drawing.Size(582, 252);
			this.dgvFuelTanks.TabIndex = 1;
			// 
			// clnFuelTankName
			// 
			this.clnFuelTankName.HeaderText = "Name";
			this.clnFuelTankName.Name = "clnFuelTankName";
			this.clnFuelTankName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.clnFuelTankName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.clnFuelTankName.Width = 200;
			// 
			// clnFuelTankArm
			// 
			this.clnFuelTankArm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle2.Format = "N3";
			dataGridViewCellStyle2.NullValue = null;
			this.clnFuelTankArm.DefaultCellStyle = dataGridViewCellStyle2;
			this.clnFuelTankArm.HeaderText = "Arm";
			this.clnFuelTankArm.Name = "clnFuelTankArm";
			this.clnFuelTankArm.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.clnFuelTankArm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// clnFuelTankCapacity
			// 
			dataGridViewCellStyle3.Format = "N1";
			dataGridViewCellStyle3.NullValue = null;
			this.clnFuelTankCapacity.DefaultCellStyle = dataGridViewCellStyle3;
			this.clnFuelTankCapacity.HeaderText = "Capacity";
			this.clnFuelTankCapacity.Name = "clnFuelTankCapacity";
			this.clnFuelTankCapacity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.clnFuelTankCapacity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// tabCenterOfGravity
			// 
			this.tabCenterOfGravity.Controls.Add(this.dgvCenterOfGravity);
			this.tabCenterOfGravity.Location = new System.Drawing.Point(4, 22);
			this.tabCenterOfGravity.Name = "tabCenterOfGravity";
			this.tabCenterOfGravity.Padding = new System.Windows.Forms.Padding(3);
			this.tabCenterOfGravity.Size = new System.Drawing.Size(588, 258);
			this.tabCenterOfGravity.TabIndex = 3;
			this.tabCenterOfGravity.Text = "Center Of Gravity";
			this.tabCenterOfGravity.UseVisualStyleBackColor = true;
			// 
			// dgvCenterOfGravity
			// 
			this.dgvCenterOfGravity.AllowUserToOrderColumns = true;
			this.dgvCenterOfGravity.AllowUserToResizeColumns = false;
			this.dgvCenterOfGravity.AllowUserToResizeRows = false;
			this.dgvCenterOfGravity.BackgroundColor = System.Drawing.Color.White;
			this.dgvCenterOfGravity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCenterOfGravity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnMass,
            this.clnForwardLimit,
            this.clnAftLimit});
			this.dgvCenterOfGravity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCenterOfGravity.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvCenterOfGravity.Location = new System.Drawing.Point(3, 3);
			this.dgvCenterOfGravity.Name = "dgvCenterOfGravity";
			this.dgvCenterOfGravity.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvCenterOfGravity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCenterOfGravity.Size = new System.Drawing.Size(582, 252);
			this.dgvCenterOfGravity.TabIndex = 2;
			// 
			// clnMass
			// 
			this.clnMass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.clnMass.HeaderText = "Mass";
			this.clnMass.Name = "clnMass";
			this.clnMass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.clnMass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// clnForwardLimit
			// 
			this.clnForwardLimit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle4.Format = "N3";
			dataGridViewCellStyle4.NullValue = null;
			this.clnForwardLimit.DefaultCellStyle = dataGridViewCellStyle4;
			this.clnForwardLimit.HeaderText = "Forward Limit";
			this.clnForwardLimit.Name = "clnForwardLimit";
			this.clnForwardLimit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.clnForwardLimit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// clnAftLimit
			// 
			this.clnAftLimit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle5.Format = "N3";
			dataGridViewCellStyle5.NullValue = null;
			this.clnAftLimit.DefaultCellStyle = dataGridViewCellStyle5;
			this.clnAftLimit.HeaderText = "Aft Limit";
			this.clnAftLimit.Name = "clnAftLimit";
			this.clnAftLimit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.clnAftLimit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// tabCruisePerformance
			// 
			this.tabCruisePerformance.Controls.Add(this.dgvCruisePerformance);
			this.tabCruisePerformance.Location = new System.Drawing.Point(4, 22);
			this.tabCruisePerformance.Name = "tabCruisePerformance";
			this.tabCruisePerformance.Padding = new System.Windows.Forms.Padding(3);
			this.tabCruisePerformance.Size = new System.Drawing.Size(588, 258);
			this.tabCruisePerformance.TabIndex = 4;
			this.tabCruisePerformance.Text = "Cruise Performance";
			this.tabCruisePerformance.UseVisualStyleBackColor = true;
			// 
			// dgvCruisePerformance
			// 
			this.dgvCruisePerformance.AllowUserToOrderColumns = true;
			this.dgvCruisePerformance.AllowUserToResizeColumns = false;
			this.dgvCruisePerformance.AllowUserToResizeRows = false;
			this.dgvCruisePerformance.BackgroundColor = System.Drawing.Color.White;
			this.dgvCruisePerformance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCruisePerformance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnCruisePerformanceAltitude,
            this.clnCruisePerformanceTrueAirspeed,
            this.clnCruisePerformanceFuelFlow});
			this.dgvCruisePerformance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCruisePerformance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvCruisePerformance.Location = new System.Drawing.Point(3, 3);
			this.dgvCruisePerformance.Name = "dgvCruisePerformance";
			this.dgvCruisePerformance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvCruisePerformance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCruisePerformance.Size = new System.Drawing.Size(582, 252);
			this.dgvCruisePerformance.TabIndex = 3;
			// 
			// clnCruisePerformanceAltitude
			// 
			this.clnCruisePerformanceAltitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle6.Format = "N0";
			dataGridViewCellStyle6.NullValue = null;
			this.clnCruisePerformanceAltitude.DefaultCellStyle = dataGridViewCellStyle6;
			this.clnCruisePerformanceAltitude.HeaderText = "Pressure Altitude";
			this.clnCruisePerformanceAltitude.Name = "clnCruisePerformanceAltitude";
			this.clnCruisePerformanceAltitude.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.clnCruisePerformanceAltitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// clnCruisePerformanceTrueAirspeed
			// 
			this.clnCruisePerformanceTrueAirspeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle7.Format = "N0";
			dataGridViewCellStyle7.NullValue = null;
			this.clnCruisePerformanceTrueAirspeed.DefaultCellStyle = dataGridViewCellStyle7;
			this.clnCruisePerformanceTrueAirspeed.HeaderText = "TAS";
			this.clnCruisePerformanceTrueAirspeed.Name = "clnCruisePerformanceTrueAirspeed";
			// 
			// clnCruisePerformanceFuelFlow
			// 
			this.clnCruisePerformanceFuelFlow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle8.Format = "N1";
			dataGridViewCellStyle8.NullValue = null;
			this.clnCruisePerformanceFuelFlow.DefaultCellStyle = dataGridViewCellStyle8;
			this.clnCruisePerformanceFuelFlow.HeaderText = "Fuel Flow";
			this.clnCruisePerformanceFuelFlow.Name = "clnCruisePerformanceFuelFlow";
			// 
			// tabClimbPerformance
			// 
			this.tabClimbPerformance.Controls.Add(this.dgvClimbPerformance);
			this.tabClimbPerformance.Location = new System.Drawing.Point(4, 22);
			this.tabClimbPerformance.Name = "tabClimbPerformance";
			this.tabClimbPerformance.Padding = new System.Windows.Forms.Padding(3);
			this.tabClimbPerformance.Size = new System.Drawing.Size(588, 258);
			this.tabClimbPerformance.TabIndex = 5;
			this.tabClimbPerformance.Text = "Climb Performance";
			this.tabClimbPerformance.UseVisualStyleBackColor = true;
			// 
			// dgvClimbPerformance
			// 
			this.dgvClimbPerformance.AllowUserToOrderColumns = true;
			this.dgvClimbPerformance.AllowUserToResizeColumns = false;
			this.dgvClimbPerformance.AllowUserToResizeRows = false;
			this.dgvClimbPerformance.BackgroundColor = System.Drawing.Color.White;
			this.dgvClimbPerformance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvClimbPerformance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnClimbPerformanceAltitude,
            this.clnClimbPerformanceTrueAirspeed,
            this.clnClimbPerformanceFuelFlow,
            this.clnClimbPerformanceRate});
			this.dgvClimbPerformance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvClimbPerformance.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.dgvClimbPerformance.Location = new System.Drawing.Point(3, 3);
			this.dgvClimbPerformance.Name = "dgvClimbPerformance";
			this.dgvClimbPerformance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgvClimbPerformance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvClimbPerformance.Size = new System.Drawing.Size(582, 252);
			this.dgvClimbPerformance.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(508, 396);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAccept.Location = new System.Drawing.Point(402, 396);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 3;
			this.btnAccept.Text = "OK";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// clnClimbPerformanceAltitude
			// 
			this.clnClimbPerformanceAltitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle9.Format = "N0";
			dataGridViewCellStyle9.NullValue = null;
			this.clnClimbPerformanceAltitude.DefaultCellStyle = dataGridViewCellStyle9;
			this.clnClimbPerformanceAltitude.HeaderText = "Pressure Altitude";
			this.clnClimbPerformanceAltitude.Name = "clnClimbPerformanceAltitude";
			this.clnClimbPerformanceAltitude.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.clnClimbPerformanceAltitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// clnClimbPerformanceTrueAirspeed
			// 
			this.clnClimbPerformanceTrueAirspeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle10.Format = "N0";
			dataGridViewCellStyle10.NullValue = null;
			this.clnClimbPerformanceTrueAirspeed.DefaultCellStyle = dataGridViewCellStyle10;
			this.clnClimbPerformanceTrueAirspeed.HeaderText = "TAS";
			this.clnClimbPerformanceTrueAirspeed.Name = "clnClimbPerformanceTrueAirspeed";
			// 
			// clnClimbPerformanceFuelFlow
			// 
			this.clnClimbPerformanceFuelFlow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			dataGridViewCellStyle11.Format = "N1";
			dataGridViewCellStyle11.NullValue = null;
			this.clnClimbPerformanceFuelFlow.DefaultCellStyle = dataGridViewCellStyle11;
			this.clnClimbPerformanceFuelFlow.HeaderText = "Fuel Flow";
			this.clnClimbPerformanceFuelFlow.Name = "clnClimbPerformanceFuelFlow";
			// 
			// clnClimbPerformanceRate
			// 
			this.clnClimbPerformanceRate.HeaderText = "Climb rate";
			this.clnClimbPerformanceRate.Name = "clnClimbPerformanceRate";
			// 
			// AircraftForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(620, 433);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tabCtrl);
			this.Controls.Add(this.gbxGeneral);
			this.MinimumSize = new System.Drawing.Size(480, 300);
			this.Name = "AircraftForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Aircraft";
			this.gbxGeneral.ResumeLayout(false);
			this.gbxGeneral.PerformLayout();
			this.tabCtrl.ResumeLayout(false);
			this.tabProperties.ResumeLayout(false);
			this.tabStations.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
			this.tabFuelTanks.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvFuelTanks)).EndInit();
			this.tabCenterOfGravity.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCenterOfGravity)).EndInit();
			this.tabCruisePerformance.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCruisePerformance)).EndInit();
			this.tabClimbPerformance.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvClimbPerformance)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxGeneral;
        private System.Windows.Forms.TextBox txtRegistration;
        private System.Windows.Forms.Label lblRegistration;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabProperties;
        private System.Windows.Forms.TabPage tabStations;
        private System.Windows.Forms.PropertyGrid pgProperties;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.DataGridView dgvStations;
        private System.Windows.Forms.TabPage tabFuelTanks;
        private System.Windows.Forms.DataGridView dgvFuelTanks;
        private System.Windows.Forms.TabPage tabCenterOfGravity;
        private System.Windows.Forms.DataGridView dgvCenterOfGravity;
        private System.Windows.Forms.TabPage tabCruisePerformance;
        private System.Windows.Forms.DataGridView dgvCruisePerformance;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnStationArm;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFuelTankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFuelTankArm;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFuelTankCapacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMass;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnForwardLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAftLimit;
		private System.Windows.Forms.TabPage tabClimbPerformance;
		private System.Windows.Forms.DataGridView dgvClimbPerformance;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCruisePerformanceAltitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCruisePerformanceTrueAirspeed;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnCruisePerformanceFuelFlow;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnClimbPerformanceAltitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnClimbPerformanceTrueAirspeed;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnClimbPerformanceFuelFlow;
		private System.Windows.Forms.DataGridViewTextBoxColumn clnClimbPerformanceRate;
	}
}