using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Dialogs {
	public partial class SettingsForm : Form {

		public Boolean Changed { get {
				return ascResources.Changed || ccCountries.Changed || pccPlugins.Changed || gscSettings.Changed || ascAirspaces.Changed;
			}
		}

        public SettingsForm() {
            InitializeComponent();
			InitializeIcon();
			ApplyLocalization();
        }

		private void InitializeIcon() {
			Bitmap bitmap = UserInterface.Properties.Resources.Configuration;
			Icon = Icon.FromHandle(bitmap.GetHicon());
		}

		private void ApplyLocalization() {
			Text = Strings.Settings;

			tabResources.Text = Strings.ResourceFiles;
			tabCountries.Text = Strings.Countries;
			tabPlugins.Text = Strings.Plugins;
			tabAirspaces.Text = Strings.Airspaces;
		}
	}
}
