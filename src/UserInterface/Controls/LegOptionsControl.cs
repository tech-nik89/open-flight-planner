using FlightPlanner.Units;
using FlightPlanner.Waypoints;
using FlightPlanner.Weather.Gafor;
using System;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Controls {
    public partial class LegOptionsControl : UserControl {

        private Leg _Leg;

        public Leg Leg {
            get {
                return _Leg;
            }
            set {
                _Leg = value;
                ApplyLeg();
            }
        }

        public LegOptionsControl() {
            InitializeComponent();
			ApplyLocalization();

			cbxGaforArea.Items.Clear();
			foreach (Int32 area in GaforInfo.GaforAreas) {
				cbxGaforArea.Items.Add(area.ToString("00"));
			}
        }

		private void ApplyLocalization() {
			gbxDetails.Text = Strings.LegDetails;
			gbxSettings.Text = Strings.LegSettings;

			lblWind.Text = Strings.Wind;
			lblAltitude.Text = Strings.Altitude;
			lblGafor.Text = Strings.GaforArea;
		}

		private void ApplyLeg() {
            lvwDetails.Items.Clear();

            if (_Leg == null) {
                return;
            }

            ApplyDetailsRow(Strings.TrueTrack, _Leg.TrueCourse);
            ApplyDetailsRow(Strings.MagneticTrack, _Leg.MagneticCourse);
            ApplyDetailsRow(Strings.WindCorrectionAngle, _Leg.WindCorrectionAngleFormatted);
            ApplyDetailsRow(Strings.MagneticHeading, _Leg.MagneticHeading);
            ApplyDetailsRow(Strings.TrueAirspeed, _Leg.TrueAirspeed);
            ApplyDetailsRow(Strings.Groundspeed, _Leg.GroundSpeed);
            ApplyDetailsRow(Strings.FuelConsumption, _Leg.FuelConsumption);
            ApplyDetailsRow(Strings.Variation, _Leg.VariationFormatted);
			ApplyDetailsRow(Strings.Time, _Leg.TimeFormatted);

            wcLeg.Wind = _Leg.Wind;
            txtAltitude.Text = _Leg.Altitude.ToString();
			txtClimbFrom.Text = _Leg.ClimbFromAltitude != null ? _Leg.ClimbFromAltitude.ToString() : String.Empty;

			cbxGaforArea.Text = _Leg.GaforArea.ToString("00");
        }
        
        private void ApplyDetailsRow(String key, Object value) {
            lvwDetails.Items.Add(new ListViewItem(new String[] { key, value.ToString() }));
        }

        private void txtAltitude_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter) {
                return;
            }

            e.Handled = true;
            _Leg.Altitude = Altitude.Parse(txtAltitude.Text);
            ApplyLeg();
        }

        private void wcLeg_WindChanged(object sender, EventArgs e) {
            _Leg.Wind = wcLeg.Wind;
            ApplyLeg();
        }

		private void cbxGaforArea_SelectedIndexChanged(object sender, EventArgs e) {
			Int32 area = -1;
			if (Int32.TryParse(cbxGaforArea.Text, out area)) {
				_Leg.GaforArea = area;
			}
		}

		private void cbxGaforArea_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				cbxGaforArea_SelectedIndexChanged(this, new EventArgs());
			}
		}

		private void txtClimbFrom_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode != Keys.Enter) {
				return;
			}

			e.Handled = true;
			_Leg.ClimbFromAltitude = Altitude.Parse(txtClimbFrom.Text);
			ApplyLeg();
		}
	}
}
