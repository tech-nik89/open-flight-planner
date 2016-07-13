using FlightPlanner.Configuration;
using FlightPlanner.Plugins;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Controls {
	public partial class PluginConfigurationControl : UserControl {

		private Boolean _Initializing;

		private const String _GroupWeatherMetar = "grpWeatherMetar";
		private const String _GroupWeatherEnroute = "grpWeatherEnroute";
		private const String _GroupNotams = "grpNotams";

		public Boolean Changed { get; private set; }

		private IPlugin SelectedPlugin {
			get {
				if (lvwPlugins.SelectedIndices.Count == 0) {
					return null;
				}

				Int32 index = lvwPlugins.SelectedIndices[0];
				return lvwPlugins.Items[index].Tag as IPlugin;
			}
		}

		public PluginConfigurationControl() {
			InitializeComponent();
			ApplyLocalization();
		}

		private void ApplyLocalization() {
			lvwPlugins.Groups[_GroupWeatherMetar].Header = Strings.WeatherSourceMetar;
			lvwPlugins.Groups[_GroupWeatherEnroute].Header = Strings.WeatherSourceEnroute;
			lvwPlugins.Groups[_GroupNotams].Header = Strings.NotamSource;
		}

		private void PluginConfigurationControl_Load(object sender, EventArgs e) {
			RefreshPluginList();
		}

		private void RefreshPluginList() {

			_Initializing = true;

			lvwPlugins.Items.Clear();
			
			List<IPlugin> plugins = PluginManager.GetPlugins();
			
			foreach (IPlugin plugin in plugins) {
				ListViewItem item = new ListViewItem(plugin.Name);
				item.Tag = plugin;

				if (plugin is IMetarWeatherSource) {
					item.Group = lvwPlugins.Groups[_GroupWeatherMetar];
					item.Checked = IsPluginActive(plugin, PluginManager.MetarWeatherSource);
				}
				else if (plugin is IEnrouteWeatherSource) {
					item.Group = lvwPlugins.Groups[_GroupWeatherEnroute];
					item.Checked = IsPluginActive(plugin, PluginManager.EnrouteWeatherSource);
				}
				else if (plugin is INotamSource) {
					item.Group = lvwPlugins.Groups[_GroupNotams];
					item.Checked = IsPluginActive(plugin, PluginManager.NotamSource);
				}
				if (plugin is IFlightLogExport) {
					continue;
				}
				
				lvwPlugins.Items.Add(item);
			}

			_Initializing = false;
		}

		private void lvwPlugins_ItemChecked(object sender, ItemCheckedEventArgs e) {
			if (_Initializing) {
				return;
			}

			IPlugin plugin = (IPlugin)e.Item.Tag;

			if (plugin is IMetarWeatherSource) {
				PluginManager.MetarWeatherSource = e.Item.Checked ? (IMetarWeatherSource)plugin : null;
			}
			else if (plugin is IEnrouteWeatherSource) {
				PluginManager.EnrouteWeatherSource = e.Item.Checked ? (IEnrouteWeatherSource)plugin : null;
			}
			else if (plugin is INotamSource) {
				PluginManager.NotamSource = e.Item.Checked ? (INotamSource)plugin : null;
			}

			foreach (ListViewItem item in e.Item.Group.Items) {
				if (item != e.Item) {
					item.Checked = false;
				}
			}

			Changed = true;
		}

		private static Boolean IsPluginActive(IPlugin plugin, IPlugin activePlugin) {
			if (plugin == null || activePlugin == null) {
				return false;
			}

			return plugin.GetType() == activePlugin.GetType();
		}

		private void lvwPlugins_SelectedIndexChanged(object sender, EventArgs e) {
			IPlugin plugin = SelectedPlugin;
			if (plugin == null) {
				return;
			}

			tsbConfigurePlugin.Enabled = plugin.Configurable;
		}

		private void tsbConfigurePlugin_Click(object sender, EventArgs e) {
			IPlugin plugin = SelectedPlugin;
			if (plugin == null) {
				return;
			}

			plugin.ShowConfiguration();

			var config = Config.Current.PluginConfiguration;
			config[plugin.Name] = plugin.Configuration;

			Config.Save();
		}
	}
}
