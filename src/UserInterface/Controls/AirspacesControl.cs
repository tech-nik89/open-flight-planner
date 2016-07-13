using FlightPlanner.Airspaces;
using FlightPlanner.Configuration;
using System;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Controls {
	public partial class AirspacesControl : UserControl {

		private Boolean _Initializing;
		
		public Boolean Changed { get; private set; }

		public AirspacesControl() {
			InitializeComponent();
			ApplyLocalization();
		}

		private void ApplyLocalization() {
			clnAirspace.Text = Strings.Airspace;
		}

		private void FillListView() {
			var airspaceClasses = Enum.GetValues(typeof(AirspaceClass));
			lvwAirspaces.Items.Clear();
			_Initializing = true;

			foreach (AirspaceClass airspaceClass in airspaceClasses) {
				if (airspaceClass == AirspaceClass.Undefined) {
					continue;
				}

				ListViewItem item = new ListViewItem(airspaceClass.ToString());
				item.Tag = airspaceClass;
				if (Config.Current != null && Config.Current.VisibleAirspaces.Contains(airspaceClass)) {
					item.Checked = true;
				}

				lvwAirspaces.Items.Add(item);
			}

			_Initializing = false;
		}

		private void lvwAirspaces_ItemChecked(object sender, ItemCheckedEventArgs e) {
			if (_Initializing) {
				return;
			}

			AirspaceClass airspaceClass = (AirspaceClass)e.Item.Tag;

			if (e.Item.Checked && !Config.Current.VisibleAirspaces.Contains(airspaceClass)) {
				Config.Current.VisibleAirspaces.Add(airspaceClass);
				Changed = true;
				Config.Save();
			}
			else if (!e.Item.Checked && Config.Current.VisibleAirspaces.Contains(airspaceClass)) {
				Config.Current.VisibleAirspaces.Remove(airspaceClass);
				Changed = true;
				Config.Save();
			}
		}

		private void AirspacesControl_Load(object sender, EventArgs e) {
			FillListView();
			Changed = false;
		}
	}
}
