namespace FlightPlanner.UserInterface.Dialogs {
	partial class WeatherBriefingForm {
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
			this.tabMetar = new System.Windows.Forms.TabPage();
			this.lvwMetar = new System.Windows.Forms.ListView();
			this.clnStation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnAltimeter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnVisibility = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnTemperature = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnWind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnCeiling = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabGafor = new System.Windows.Forms.TabPage();
			this.scMain = new System.Windows.Forms.SplitContainer();
			this.pbxGafor = new System.Windows.Forms.PictureBox();
			this.lvwGaforDetails = new System.Windows.Forms.ListView();
			this.clnGaforArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnGaforDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.lblForecast = new System.Windows.Forms.ToolStripLabel();
			this.tscForecast = new System.Windows.Forms.ToolStripComboBox();
			this.tabSWC = new System.Windows.Forms.TabPage();
			this.pnlSWC = new System.Windows.Forms.Panel();
			this.pbxSWC = new System.Windows.Forms.PictureBox();
			this.ssMain = new System.Windows.Forms.StatusStrip();
			this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabTextReport = new System.Windows.Forms.TabPage();
			this.txtTextReport = new System.Windows.Forms.TextBox();
			this.tabMain.SuspendLayout();
			this.tabMetar.SuspendLayout();
			this.tabGafor.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxGafor)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.tabSWC.SuspendLayout();
			this.pnlSWC.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxSWC)).BeginInit();
			this.ssMain.SuspendLayout();
			this.tabTextReport.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabMetar);
			this.tabMain.Controls.Add(this.tabGafor);
			this.tabMain.Controls.Add(this.tabTextReport);
			this.tabMain.Controls.Add(this.tabSWC);
			this.tabMain.Location = new System.Drawing.Point(0, 1);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(664, 345);
			this.tabMain.TabIndex = 0;
			// 
			// tabMetar
			// 
			this.tabMetar.Controls.Add(this.lvwMetar);
			this.tabMetar.Location = new System.Drawing.Point(4, 22);
			this.tabMetar.Name = "tabMetar";
			this.tabMetar.Padding = new System.Windows.Forms.Padding(3);
			this.tabMetar.Size = new System.Drawing.Size(656, 319);
			this.tabMetar.TabIndex = 0;
			this.tabMetar.Text = "Enroute METAR";
			this.tabMetar.UseVisualStyleBackColor = true;
			// 
			// lvwMetar
			// 
			this.lvwMetar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnStation,
            this.clnAltimeter,
            this.clnVisibility,
            this.clnTemperature,
            this.clnWind,
            this.clnCeiling});
			this.lvwMetar.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwMetar.FullRowSelect = true;
			this.lvwMetar.GridLines = true;
			this.lvwMetar.Location = new System.Drawing.Point(3, 3);
			this.lvwMetar.MultiSelect = false;
			this.lvwMetar.Name = "lvwMetar";
			this.lvwMetar.ShowItemToolTips = true;
			this.lvwMetar.Size = new System.Drawing.Size(650, 313);
			this.lvwMetar.TabIndex = 0;
			this.lvwMetar.UseCompatibleStateImageBehavior = false;
			this.lvwMetar.View = System.Windows.Forms.View.Details;
			this.lvwMetar.VirtualMode = true;
			this.lvwMetar.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwMetar_RetrieveVirtualItem);
			this.lvwMetar.DoubleClick += new System.EventHandler(this.lvwMetar_DoubleClick);
			// 
			// clnStation
			// 
			this.clnStation.Text = "Station";
			this.clnStation.Width = 100;
			// 
			// clnAltimeter
			// 
			this.clnAltimeter.Text = "Altimeter";
			this.clnAltimeter.Width = 80;
			// 
			// clnVisibility
			// 
			this.clnVisibility.Text = "Visibility";
			this.clnVisibility.Width = 90;
			// 
			// clnTemperature
			// 
			this.clnTemperature.Text = "Temperature";
			this.clnTemperature.Width = 100;
			// 
			// clnWind
			// 
			this.clnWind.Text = "Wind";
			this.clnWind.Width = 90;
			// 
			// clnCeiling
			// 
			this.clnCeiling.Text = "Ceiling";
			this.clnCeiling.Width = 120;
			// 
			// tabGafor
			// 
			this.tabGafor.Controls.Add(this.scMain);
			this.tabGafor.Controls.Add(this.toolStrip1);
			this.tabGafor.Location = new System.Drawing.Point(4, 22);
			this.tabGafor.Name = "tabGafor";
			this.tabGafor.Padding = new System.Windows.Forms.Padding(3);
			this.tabGafor.Size = new System.Drawing.Size(656, 319);
			this.tabGafor.TabIndex = 1;
			this.tabGafor.Text = "GAFOR";
			this.tabGafor.UseVisualStyleBackColor = true;
			// 
			// scMain
			// 
			this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.scMain.Location = new System.Drawing.Point(3, 31);
			this.scMain.Name = "scMain";
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.pbxGafor);
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.Controls.Add(this.lvwGaforDetails);
			this.scMain.Size = new System.Drawing.Size(650, 285);
			this.scMain.SplitterDistance = 424;
			this.scMain.TabIndex = 2;
			// 
			// pbxGafor
			// 
			this.pbxGafor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbxGafor.Location = new System.Drawing.Point(0, 0);
			this.pbxGafor.Name = "pbxGafor";
			this.pbxGafor.Size = new System.Drawing.Size(424, 285);
			this.pbxGafor.TabIndex = 0;
			this.pbxGafor.TabStop = false;
			// 
			// lvwGaforDetails
			// 
			this.lvwGaforDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnGaforArea,
            this.clnGaforDetails});
			this.lvwGaforDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwGaforDetails.FullRowSelect = true;
			this.lvwGaforDetails.GridLines = true;
			this.lvwGaforDetails.Location = new System.Drawing.Point(0, 0);
			this.lvwGaforDetails.Name = "lvwGaforDetails";
			this.lvwGaforDetails.Size = new System.Drawing.Size(222, 285);
			this.lvwGaforDetails.TabIndex = 0;
			this.lvwGaforDetails.UseCompatibleStateImageBehavior = false;
			this.lvwGaforDetails.View = System.Windows.Forms.View.Details;
			this.lvwGaforDetails.VirtualMode = true;
			this.lvwGaforDetails.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwGaforDetails_RetrieveVirtualItem);
			// 
			// clnGaforArea
			// 
			this.clnGaforArea.Text = "Area";
			// 
			// clnGaforDetails
			// 
			this.clnGaforDetails.Text = "Details";
			this.clnGaforDetails.Width = 120;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblForecast,
            this.tscForecast});
			this.toolStrip1.Location = new System.Drawing.Point(3, 3);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(650, 25);
			this.toolStrip1.TabIndex = 1;
			// 
			// lblForecast
			// 
			this.lblForecast.Name = "lblForecast";
			this.lblForecast.Size = new System.Drawing.Size(54, 22);
			this.lblForecast.Text = "Forecast:";
			// 
			// tscForecast
			// 
			this.tscForecast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscForecast.Name = "tscForecast";
			this.tscForecast.Size = new System.Drawing.Size(121, 25);
			this.tscForecast.SelectedIndexChanged += new System.EventHandler(this.tscForecast_SelectedIndexChanged);
			// 
			// tabSWC
			// 
			this.tabSWC.Controls.Add(this.pnlSWC);
			this.tabSWC.Location = new System.Drawing.Point(4, 22);
			this.tabSWC.Name = "tabSWC";
			this.tabSWC.Padding = new System.Windows.Forms.Padding(3);
			this.tabSWC.Size = new System.Drawing.Size(656, 319);
			this.tabSWC.TabIndex = 2;
			this.tabSWC.Text = "Significant Weather";
			this.tabSWC.UseVisualStyleBackColor = true;
			// 
			// pnlSWC
			// 
			this.pnlSWC.AutoScroll = true;
			this.pnlSWC.Controls.Add(this.pbxSWC);
			this.pnlSWC.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlSWC.Location = new System.Drawing.Point(3, 3);
			this.pnlSWC.Name = "pnlSWC";
			this.pnlSWC.Size = new System.Drawing.Size(650, 313);
			this.pnlSWC.TabIndex = 1;
			// 
			// pbxSWC
			// 
			this.pbxSWC.Location = new System.Drawing.Point(3, 3);
			this.pbxSWC.Name = "pbxSWC";
			this.pbxSWC.Size = new System.Drawing.Size(100, 50);
			this.pbxSWC.TabIndex = 0;
			this.pbxSWC.TabStop = false;
			// 
			// ssMain
			// 
			this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
			this.ssMain.Location = new System.Drawing.Point(0, 349);
			this.ssMain.Name = "ssMain";
			this.ssMain.Size = new System.Drawing.Size(664, 22);
			this.ssMain.TabIndex = 1;
			this.ssMain.Text = "statusStrip1";
			// 
			// tslStatus
			// 
			this.tslStatus.Name = "tslStatus";
			this.tslStatus.Size = new System.Drawing.Size(39, 17);
			this.tslStatus.Text = "Ready";
			// 
			// tabTextReport
			// 
			this.tabTextReport.Controls.Add(this.txtTextReport);
			this.tabTextReport.Location = new System.Drawing.Point(4, 22);
			this.tabTextReport.Name = "tabTextReport";
			this.tabTextReport.Padding = new System.Windows.Forms.Padding(3);
			this.tabTextReport.Size = new System.Drawing.Size(656, 319);
			this.tabTextReport.TabIndex = 3;
			this.tabTextReport.Text = "Report";
			this.tabTextReport.UseVisualStyleBackColor = true;
			// 
			// txtTextReport
			// 
			this.txtTextReport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtTextReport.Location = new System.Drawing.Point(3, 3);
			this.txtTextReport.Multiline = true;
			this.txtTextReport.Name = "txtTextReport";
			this.txtTextReport.ReadOnly = true;
			this.txtTextReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTextReport.Size = new System.Drawing.Size(650, 313);
			this.txtTextReport.TabIndex = 0;
			// 
			// WeatherBriefingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 371);
			this.Controls.Add(this.ssMain);
			this.Controls.Add(this.tabMain);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(360, 200);
			this.Name = "WeatherBriefingForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Weather Briefing";
			this.Shown += new System.EventHandler(this.WeatherBriefingForm_Shown);
			this.ResizeEnd += new System.EventHandler(this.WeatherBriefingForm_ResizeEnd);
			this.Resize += new System.EventHandler(this.WeatherBriefingForm_Resize);
			this.tabMain.ResumeLayout(false);
			this.tabMetar.ResumeLayout(false);
			this.tabGafor.ResumeLayout(false);
			this.tabGafor.PerformLayout();
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
			this.scMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbxGafor)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tabSWC.ResumeLayout(false);
			this.pnlSWC.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbxSWC)).EndInit();
			this.ssMain.ResumeLayout(false);
			this.ssMain.PerformLayout();
			this.tabTextReport.ResumeLayout(false);
			this.tabTextReport.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabMetar;
		private System.Windows.Forms.StatusStrip ssMain;
		private System.Windows.Forms.ToolStripStatusLabel tslStatus;
		private System.Windows.Forms.ListView lvwMetar;
		private System.Windows.Forms.ColumnHeader clnStation;
		private System.Windows.Forms.ColumnHeader clnAltimeter;
		private System.Windows.Forms.ColumnHeader clnVisibility;
		private System.Windows.Forms.ColumnHeader clnTemperature;
		private System.Windows.Forms.ColumnHeader clnWind;
		private System.Windows.Forms.ColumnHeader clnCeiling;
		private System.Windows.Forms.TabPage tabGafor;
		private System.Windows.Forms.PictureBox pbxGafor;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripLabel lblForecast;
		private System.Windows.Forms.ToolStripComboBox tscForecast;
		private System.Windows.Forms.SplitContainer scMain;
		private System.Windows.Forms.ListView lvwGaforDetails;
		private System.Windows.Forms.ColumnHeader clnGaforArea;
		private System.Windows.Forms.ColumnHeader clnGaforDetails;
		private System.Windows.Forms.TabPage tabSWC;
		private System.Windows.Forms.PictureBox pbxSWC;
		private System.Windows.Forms.Panel pnlSWC;
		private System.Windows.Forms.TabPage tabTextReport;
		private System.Windows.Forms.TextBox txtTextReport;
	}
}