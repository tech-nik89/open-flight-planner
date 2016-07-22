using FlightPlanner.Export;
using System;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Dialogs {
	public partial class ExportOptionsForm : Form {

		public ExportOptions Options { get; private set; }

		public ExportOptionsForm() {
			InitializeComponent();
			ApplyLocalization();
		}

		private void ApplyLocalization() {
			Text = Strings.ExportOptions;

			gbxGeneral.Text = Strings.General;
			gbxWeather.Text = Strings.Weather;

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;

			chkFlightLog.Text = Strings.FlightLog;
			chkMassAndBalance.Text = Strings.MassAndBalance;
			chkNotams.Text = Strings.Notams;
			chkMetar.Text = Strings.Metar;
			chkGafor.Text = Strings.Gafor;
			chkWeatherTextReport.Text = Strings.WeatherTextReport;
			chkSignificantWeatherChart.Text = Strings.SignificantWeatherChart;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
			Options = null;
			Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;

			Options = new ExportOptions() {
				FlightLog = chkFlightLog.Checked,
				MassAndBalance = chkMassAndBalance.Checked,
				Notams = chkNotams.Checked,
				Metar = chkMetar.Checked,
				Gafor = chkGafor.Checked,
				TextWeatherReport = chkWeatherTextReport.Checked,
				SignificantWeatherChart = chkSignificantWeatherChart.Checked
			};

			Close();
		}
	}
}
