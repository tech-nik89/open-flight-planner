namespace FlightPlanner.UserInterface.Dialogs {
	partial class ExportOptionsForm {
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
			this.gbxGeneral = new System.Windows.Forms.GroupBox();
			this.chkNotams = new System.Windows.Forms.CheckBox();
			this.chkMassAndBalance = new System.Windows.Forms.CheckBox();
			this.chkFlightLog = new System.Windows.Forms.CheckBox();
			this.gbxWeather = new System.Windows.Forms.GroupBox();
			this.chkSignificantWeatherChart = new System.Windows.Forms.CheckBox();
			this.chkWeatherTextReport = new System.Windows.Forms.CheckBox();
			this.chkGafor = new System.Windows.Forms.CheckBox();
			this.chkMetar = new System.Windows.Forms.CheckBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.gbxOptions = new System.Windows.Forms.GroupBox();
			this.chkOpenAfterExport = new System.Windows.Forms.CheckBox();
			this.gbxGeneral.SuspendLayout();
			this.gbxWeather.SuspendLayout();
			this.gbxOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxGeneral
			// 
			this.gbxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxGeneral.Controls.Add(this.chkNotams);
			this.gbxGeneral.Controls.Add(this.chkMassAndBalance);
			this.gbxGeneral.Controls.Add(this.chkFlightLog);
			this.gbxGeneral.Location = new System.Drawing.Point(12, 12);
			this.gbxGeneral.Name = "gbxGeneral";
			this.gbxGeneral.Size = new System.Drawing.Size(268, 117);
			this.gbxGeneral.TabIndex = 0;
			this.gbxGeneral.TabStop = false;
			this.gbxGeneral.Text = "General";
			// 
			// chkNotams
			// 
			this.chkNotams.AutoSize = true;
			this.chkNotams.Checked = true;
			this.chkNotams.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkNotams.Location = new System.Drawing.Point(25, 78);
			this.chkNotams.Name = "chkNotams";
			this.chkNotams.Size = new System.Drawing.Size(72, 17);
			this.chkNotams.TabIndex = 2;
			this.chkNotams.Text = "NOTAMS";
			this.chkNotams.UseVisualStyleBackColor = true;
			// 
			// chkMassAndBalance
			// 
			this.chkMassAndBalance.AutoSize = true;
			this.chkMassAndBalance.Checked = true;
			this.chkMassAndBalance.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMassAndBalance.Location = new System.Drawing.Point(25, 55);
			this.chkMassAndBalance.Name = "chkMassAndBalance";
			this.chkMassAndBalance.Size = new System.Drawing.Size(113, 17);
			this.chkMassAndBalance.TabIndex = 1;
			this.chkMassAndBalance.Text = "Mass and balance";
			this.chkMassAndBalance.UseVisualStyleBackColor = true;
			// 
			// chkFlightLog
			// 
			this.chkFlightLog.AutoSize = true;
			this.chkFlightLog.Checked = true;
			this.chkFlightLog.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkFlightLog.Location = new System.Drawing.Point(25, 32);
			this.chkFlightLog.Name = "chkFlightLog";
			this.chkFlightLog.Size = new System.Drawing.Size(68, 17);
			this.chkFlightLog.TabIndex = 0;
			this.chkFlightLog.Text = "Flight log";
			this.chkFlightLog.UseVisualStyleBackColor = true;
			// 
			// gbxWeather
			// 
			this.gbxWeather.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxWeather.Controls.Add(this.chkSignificantWeatherChart);
			this.gbxWeather.Controls.Add(this.chkWeatherTextReport);
			this.gbxWeather.Controls.Add(this.chkGafor);
			this.gbxWeather.Controls.Add(this.chkMetar);
			this.gbxWeather.Location = new System.Drawing.Point(12, 135);
			this.gbxWeather.Name = "gbxWeather";
			this.gbxWeather.Size = new System.Drawing.Size(268, 132);
			this.gbxWeather.TabIndex = 1;
			this.gbxWeather.TabStop = false;
			this.gbxWeather.Text = "Weather";
			// 
			// chkSignificantWeatherChart
			// 
			this.chkSignificantWeatherChart.AutoSize = true;
			this.chkSignificantWeatherChart.Location = new System.Drawing.Point(25, 99);
			this.chkSignificantWeatherChart.Name = "chkSignificantWeatherChart";
			this.chkSignificantWeatherChart.Size = new System.Drawing.Size(143, 17);
			this.chkSignificantWeatherChart.TabIndex = 4;
			this.chkSignificantWeatherChart.Text = "Significant weather chart";
			this.chkSignificantWeatherChart.UseVisualStyleBackColor = true;
			// 
			// chkWeatherTextReport
			// 
			this.chkWeatherTextReport.AutoSize = true;
			this.chkWeatherTextReport.Checked = true;
			this.chkWeatherTextReport.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkWeatherTextReport.Location = new System.Drawing.Point(25, 76);
			this.chkWeatherTextReport.Name = "chkWeatherTextReport";
			this.chkWeatherTextReport.Size = new System.Drawing.Size(118, 17);
			this.chkWeatherTextReport.TabIndex = 3;
			this.chkWeatherTextReport.Text = "Text weather report";
			this.chkWeatherTextReport.UseVisualStyleBackColor = true;
			// 
			// chkGafor
			// 
			this.chkGafor.AutoSize = true;
			this.chkGafor.Checked = true;
			this.chkGafor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkGafor.Location = new System.Drawing.Point(25, 53);
			this.chkGafor.Name = "chkGafor";
			this.chkGafor.Size = new System.Drawing.Size(63, 17);
			this.chkGafor.TabIndex = 2;
			this.chkGafor.Text = "GAFOR";
			this.chkGafor.UseVisualStyleBackColor = true;
			// 
			// chkMetar
			// 
			this.chkMetar.AutoSize = true;
			this.chkMetar.Checked = true;
			this.chkMetar.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMetar.Location = new System.Drawing.Point(25, 30);
			this.chkMetar.Name = "chkMetar";
			this.chkMetar.Size = new System.Drawing.Size(64, 17);
			this.chkMetar.TabIndex = 1;
			this.chkMetar.Text = "METAR";
			this.chkMetar.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(180, 345);
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
			this.btnAccept.Location = new System.Drawing.Point(74, 345);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 3;
			this.btnAccept.Text = "OK";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// gbxOptions
			// 
			this.gbxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxOptions.Controls.Add(this.chkOpenAfterExport);
			this.gbxOptions.Location = new System.Drawing.Point(12, 273);
			this.gbxOptions.Name = "gbxOptions";
			this.gbxOptions.Size = new System.Drawing.Size(268, 59);
			this.gbxOptions.TabIndex = 4;
			this.gbxOptions.TabStop = false;
			this.gbxOptions.Text = "Options";
			// 
			// chkOpenAfterExport
			// 
			this.chkOpenAfterExport.AutoSize = true;
			this.chkOpenAfterExport.Checked = true;
			this.chkOpenAfterExport.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkOpenAfterExport.Location = new System.Drawing.Point(25, 25);
			this.chkOpenAfterExport.Name = "chkOpenAfterExport";
			this.chkOpenAfterExport.Size = new System.Drawing.Size(108, 17);
			this.chkOpenAfterExport.TabIndex = 5;
			this.chkOpenAfterExport.Text = "Open after export";
			this.chkOpenAfterExport.UseVisualStyleBackColor = true;
			// 
			// ExportOptionsForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(292, 382);
			this.Controls.Add(this.gbxOptions);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbxWeather);
			this.Controls.Add(this.gbxGeneral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ExportOptionsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Export options";
			this.gbxGeneral.ResumeLayout(false);
			this.gbxGeneral.PerformLayout();
			this.gbxWeather.ResumeLayout(false);
			this.gbxWeather.PerformLayout();
			this.gbxOptions.ResumeLayout(false);
			this.gbxOptions.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbxGeneral;
		private System.Windows.Forms.CheckBox chkMassAndBalance;
		private System.Windows.Forms.CheckBox chkFlightLog;
		private System.Windows.Forms.CheckBox chkNotams;
		private System.Windows.Forms.GroupBox gbxWeather;
		private System.Windows.Forms.CheckBox chkMetar;
		private System.Windows.Forms.CheckBox chkGafor;
		private System.Windows.Forms.CheckBox chkSignificantWeatherChart;
		private System.Windows.Forms.CheckBox chkWeatherTextReport;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.GroupBox gbxOptions;
		private System.Windows.Forms.CheckBox chkOpenAfterExport;
	}
}