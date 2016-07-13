using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FlightPlanner.DwdLuftsportbericht {
	public partial class DwdLuftsportBerichtForm : Form {

		private const String DwdReportUrl = "http://www.dwd.de/DE/fachnutzer/luftfahrt/teaser/luftsportberichte/luftsportberichte_node.html";

		public String Report {
			get {
				return txtReport.Text;
			}
		}

		public DwdLuftsportBerichtForm() {
			InitializeComponent();
		}

		private void tsbOpenWebsite_Click(object sender, EventArgs e) {
			Process.Start(DwdReportUrl);
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
