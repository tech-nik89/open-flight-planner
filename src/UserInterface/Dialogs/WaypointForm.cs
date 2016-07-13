using FlightPlanner.Configuration;
using FlightPlanner.Ressources;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Dialogs {
	public partial class WaypointForm : Form {

        private readonly List<Waypoint> _Waypoints;

        public Waypoint Waypoint { get; private set; }

        public WaypointForm() {
            InitializeComponent();
			InitializeIcon();
			ApplyLocalization();

            _Waypoints = new List<Waypoint>();
            _Waypoints.AddRange(RessourceManager.GetWaypointsForCountries(Config.Current.Countries));

            UpdateList();
        }

		private void InitializeIcon() {
			Bitmap bitmap = UserInterface.Properties.Resources.Waypoint;
			Icon = Icon.FromHandle(bitmap.GetHicon());
		}

		private void ApplyLocalization() {
			Text = Strings.Waypoint;

			btnAdd.Text = Strings.Add;
			btnCancel.Text = Strings.Cancel;

			gbxSearch.Text = Strings.Search;
			lblSearch.Text = String.Concat(Strings.SearchFor, ":");

			clnType.Text = Strings.Type;
			clnName.Text = Strings.Name;
			clnLat.Text = Strings.Latitude;
			clnLng.Text = Strings.Longitude;

			cmsWaypointAirfieldDetails.Text = Strings.ShowDetails;
		}

		private void UpdateList() {
            lvwWaypoints.VirtualListSize = 0;
            lvwWaypoints.VirtualListSize = _Waypoints.Count;
			lblCount.Text = String.Format(Strings.WaypointsFound, _Waypoints.Count);
        }

        private void lvwWaypoints_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            Waypoint waypoint = _Waypoints[e.ItemIndex];

            String[] fields = new String[] {
                GetLocalizedWaypointType(waypoint),
                waypoint.Name,
                waypoint.Latitude.ToString("00.000"),
                waypoint.Longitude.ToString("000.000")
            };

            e.Item = new ListViewItem(fields);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if (_Waypoints.Count == 0 || (lvwWaypoints.SelectedIndices.Count == 0 && _Waypoints.Count > 1)) {
                return;
            }

            DialogResult = DialogResult.OK;

            if (_Waypoints.Count == 1) {
                Waypoint = _Waypoints[0];
            }
            else {
                Waypoint = _Waypoints[lvwWaypoints.SelectedIndices[0]];
            }

            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) {
			_Waypoints.Clear();
			_Waypoints.AddRange(RessourceManager.SearchWaypoints(txtSearch.Text, Config.Current.Countries));

            UpdateList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Down) {
                e.Handled = true;

                if (lvwWaypoints.SelectedIndices.Count == 0) {
                    lvwWaypoints.SelectedIndices.Add(0);
                }
                else if (lvwWaypoints.SelectedIndices[0] < _Waypoints.Count - 1) {
                    Int32 n = lvwWaypoints.SelectedIndices[0] + 1;
                    lvwWaypoints.SelectedIndices.Clear();
                    lvwWaypoints.SelectedIndices.Add(n);
                }
            }
            else if (e.KeyCode == Keys.Up) {
                e.Handled = true;

                if (lvwWaypoints.SelectedIndices.Count == 0) {
                    lvwWaypoints.SelectedIndices.Add(_Waypoints.Count - 1);
                }
                else if (lvwWaypoints.SelectedIndices[0] > 0) {
                    Int32 n = lvwWaypoints.SelectedIndices[0] - 1;
                    lvwWaypoints.SelectedIndices.Clear();
                    lvwWaypoints.SelectedIndices.Add(n);
                }
            }
        }

		private String GetLocalizedWaypointType(Waypoint waypoint) {
			if (waypoint is Airfield) {
				return Strings.Airfield;
			}
			else if (waypoint is Navaid) {
				Navaid navaid = (Navaid)waypoint;
				return navaid.FormattedType;
			}

			return Strings.Waypoint;
		}

		private void cmsWaypointAirfieldDetails_Click(object sender, EventArgs e) {
			if (lvwWaypoints.SelectedIndices.Count == 0) {
				return;
			}

			Waypoint waypoint = _Waypoints[lvwWaypoints.SelectedIndices[0]];
			if (!(waypoint is Airfield)) {
				return;
			}

			Airfield airfield = (Airfield)waypoint;
			AirfieldDetailsForm form = new AirfieldDetailsForm(airfield);
			form.ShowDialog();
		}

		private void cmsWaypoint_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
			if (lvwWaypoints.SelectedIndices.Count == 0) {
				cmsWaypointAirfieldDetails.Enabled = false;
				return;
			}

			Waypoint waypoint = _Waypoints[lvwWaypoints.SelectedIndices[0]];
			cmsWaypointAirfieldDetails.Enabled = waypoint is Airfield;
		}
	}
}
