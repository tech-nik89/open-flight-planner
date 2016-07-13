using FlightPlanner.Common;
using FlightPlanner.Units;
using FlightPlanner.Weather.Gafor;
using System;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Dialogs {
	public partial class RouteGlobalSettingsForm : Form {

        public Wind Wind { get; private set; }

        public Altitude Altitude { get; private set; }

		public Int32 GaforArea { get; private set; }

        public Boolean ApplyAltitude {
            get {
                return chkAltitude.Checked;
            }
        }

        public Boolean ApplyWind {
            get {
                return chkWind.Checked;
            }
        }

		public Boolean ApplyGaforArea {
			get {
				return chkGaforArea.Checked;
			}
		}

        public RouteGlobalSettingsForm() {
            InitializeComponent();
			ApplyLocalization();

			cbxGaforArea.Items.Clear();
			foreach (Int32 area in GaforInfo.GaforAreas) {
				cbxGaforArea.Items.Add(area.ToString("00"));
			}
		}

		private void ApplyLocalization() {
			Text = Strings.RouteGlobalSettings;
			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;

			chkWind.Text = Strings.Wind;
			chkAltitude.Text = Strings.Altitude;
			chkGaforArea.Text = Strings.GaforArea;
		}

		private void wcWind_WindChanged(object sender, EventArgs e) {
            chkWind.Checked = true;
            Wind = wcWind.Wind;
        }

        private void txtAltitude_TextChanged(object sender, EventArgs e) {
            chkAltitude.Checked = true;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtAltitude_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Enter) {
                return;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
            chkAltitude.Checked = true;

            Altitude = Altitude.Parse(txtAltitude.Text);
            txtAltitude.Text = Altitude.ToString();
        }

		private void cbxGaforArea_SelectedIndexChanged(object sender, EventArgs e) {
			Int32 area = -1;
			if (Int32.TryParse(cbxGaforArea.Text, out area)) {
				GaforArea = area;
			}
		}

		private void cbxGaforArea_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				cbxGaforArea_SelectedIndexChanged(this, new EventArgs());
			}
		}
	}
}
