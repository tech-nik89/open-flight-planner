using FlightPlanner.Configuration;
using System;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Controls {
	public partial class GeneralSettingsControl : UserControl {

		private Boolean _Initializing;

		public Boolean Changed { get; private set; }

		public GeneralSettingsControl() {
			InitializeComponent();
			ApplyLocalization();

			_Initializing = true;
			FillLanguageDropDown();
			FillMapProvidersDropDown();
			_Initializing = false;

			Changed = false;
		}

		private void ApplyLocalization() {
			lblLanguage.Text = String.Concat(Strings.Language, ":");
			gbxMap.Text = Strings.Map;
			lblMapType.Text = String.Concat(Strings.Type, ":");
			lblRequiresRestart.Text = String.Concat("* ", Strings.RequiresRestart);
		}

		private void FillLanguageDropDown() {
			cbxLanguage.Items.Clear();

			foreach (var culture in Config.SupportedCultures) {
				cbxLanguage.Items.Add(culture.Key);
			}

			if (Config.Current != null && !String.IsNullOrWhiteSpace(Config.Current.Language) && Config.SupportedCultures.ContainsKey(Config.Current.Language)) {
				cbxLanguage.Text = Config.Current.Language;
			}
		}

		private void FillMapProvidersDropDown() {
			cbxMapType.Items.Clear();

			foreach (var provider in MapControl.Map.AvailableProviders) {
				cbxMapType.Items.Add(provider);
			}

			if (Config.Current != null && !String.IsNullOrWhiteSpace(Config.Current.MapType) && MapControl.Map.AvailableProviders.Contains(Config.Current.MapType)) {
				cbxMapType.Text = Config.Current.MapType;
			}
		}

		private void cbxLanguage_Changed(object sender, EventArgs e) {
			if (_Initializing) {
				return;
			}

			String language = cbxLanguage.Text;
			if (!String.IsNullOrWhiteSpace(language) && Config.SupportedCultures.ContainsKey(language)) {
				Config.Current.Language = language;
			}
		}

		private void cbxMapType_SelectedIndexChanged(object sender, EventArgs e) {
			if (_Initializing) {
				return;
			}

			String name = cbxMapType.Text;
			if (!String.IsNullOrWhiteSpace(name) && MapControl.Map.AvailableProviders.Contains(name)) {
				Config.Current.MapType = name;
				Changed = true;
			}
		}
	}
}
