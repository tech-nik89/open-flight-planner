using FlightPlanner.Waypoints;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Dialogs {
	public partial class AirfieldDetailsForm : Form {

		private readonly Airfield _Airfield;

		public AirfieldDetailsForm(Airfield airfield) {
			InitializeComponent();
			InitializeIcon();
			ApplyLocalization();

			_Airfield = airfield;
		}

		private void InitializeIcon() {
			Bitmap bitmap = UserInterface.Properties.Resources.Waypoint;
			Icon = Icon.FromHandle(bitmap.GetHicon());
		}

		private void ApplyLocalization() {
			Text = Strings.Airfield;
			btnCancel.Text = Strings.Close;

			lblName.Text = String.Format("{0}:", Strings.Name);
			lblCoordinates.Text = String.Format("{0}:", Strings.Coordinates);
			lblElevation.Text = String.Format("{0}:", Strings.Elevation);
			lblRunways.Text = String.Format("{0}:", Strings.Runways);
			lblFrequency.Text = String.Format("{0}:", Strings.Frequency);

			clnRunwayDirection.Text = Strings.Direction;
			clnRunwayLength.Text = Strings.Length;
			clnRunwaySurface.Text = Strings.Surface;
		}

		private void AirfieldDetailsForm_Load(object sender, EventArgs e) {
			txtICAO.Text = _Airfield.ICAOCode;
			txtName.Text = _Airfield.Name;
			txtElevation.Text = _Airfield.Elevation.ToString();
			txtCoordinates.Text = _Airfield.FormattedCoordinates;

			if (_Airfield.Frequency != null) {
				txtFrequency.Text = _Airfield.Frequency.ToString();
			}

			foreach (Runway runway in _Airfield.Runways) {
				String[] cells = new String[] {
					runway.DirectionInfo,
					String.Format("{0} m", runway.Length),
					runway.Surface.ToString()
				};

				ListViewItem item = new ListViewItem(cells);
				lvwRunways.Items.Add(item);
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
