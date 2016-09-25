using FlightPlanner.Waypoints;
using System;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Dialogs {
	public partial class WaypointDetailsForm : Form {

		private readonly Waypoint _Waypoint;

		public WaypointDetailsForm(Waypoint waypoint) {
			InitializeComponent();
			ApplyLocalization();

			_Waypoint = waypoint;

			txtName.Text = waypoint.Name;
			txtLatitude.Text = waypoint.Latitude.ToString();
			txtLongitude.Text = waypoint.Longitude.ToString();
		}

		private void ApplyLocalization() {
			Name = Strings.WaypointDetails;
			gbxGeneral.Text = Strings.General;

			lblName.Text = Strings.Name;
			lblLatitude.Text = Strings.Latitude;
			lblLongitude.Text = Strings.Longitude;

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			if (!String.IsNullOrWhiteSpace(txtName.Text)) {
				_Waypoint.Name = txtName.Text;
			}

			Close();
		}
	}
}
