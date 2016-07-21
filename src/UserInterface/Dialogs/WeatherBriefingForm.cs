using FlightPlanner.Briefing;
using FlightPlanner.Weather.Gafor;
using FlightPlanner.Weather.MetarTaf;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using FlightPlanner.Exceptions;
using FlightPlanner.Plugins;
using FlightPlanner.Units;

namespace FlightPlanner.UserInterface.Dialogs {
	public partial class WeatherBriefingForm : Form {

		private readonly FlightPlan _FlightPlan;
		private WeatherBriefing _Weather;

		private SvgDocument _GaforSvg;

		private readonly BackgroundWorker _BriefingWorker;
		private Exception _PluginException;

		public WeatherBriefingForm(FlightPlan flightPlan) {
			InitializeComponent();
			InitializeIcon();
			ApplyLocalization();

			_FlightPlan = flightPlan;
			_BriefingWorker = new BackgroundWorker();
		}

		private void InitializeIcon() {
			Bitmap bitmap = UserInterface.Properties.Resources.Weather;
			Icon = Icon.FromHandle(bitmap.GetHicon());
		}

		private void ApplyLocalization() {
			Text = Strings.WeatherBriefing;
			tslStatus.Text = Strings.Ready;

			tabGafor.Text = Strings.Gafor;
			tabMetar.Text = Strings.Metar;

			clnStation.Text = Strings.Station;
			clnAltimeter.Text = Strings.Altimeter;
			clnVisibility.Text = Strings.Visibility;
			clnTemperature.Text = Strings.Temperature;
			clnWind.Text = Strings.Wind;
			clnCeiling.Text = Strings.Ceiling;

			clnGaforArea.Text = Strings.GaforArea;
			clnGaforDetails.Text = Strings.Details;
		}

		private void BriefingWorker_DoWork(object sender, DoWorkEventArgs e) {
			try {
				_Weather = WeatherBriefing.Create(_FlightPlan);
			}
			catch (Exception ex) {
				_PluginException = ex;
			}
		}

		private void BriefingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (_Weather == null || _PluginException != null) {
				String message = Strings.Error;

				if (_PluginException != null) {
					message = _PluginException.Message;
					if (_PluginException is PluginNotConfiguredException) {
						String pluginType = String.Empty;
						PluginNotConfiguredException pluginNotConfiguredException = (PluginNotConfiguredException)_PluginException;

						if (pluginNotConfiguredException.PluginType == typeof(IEnrouteWeatherSource)) {
							pluginType = Strings.WeatherSourceEnroute;
						} else if (pluginNotConfiguredException.PluginType == typeof(IMetarWeatherSource)) {
							pluginType = Strings.WeatherSourceMetar;
						}

						message = String.Format(Strings.PluginNotConfigured, pluginType);
					}
				}

				MessageBox.Show(message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			lvwMetar.VirtualListSize = 0;
			lvwMetar.VirtualListSize = _Weather.MetarTaf.Count;

			lvwGaforDetails.VirtualListSize = 0;
			lvwGaforDetails.VirtualListSize = _Weather.Gafor != null ? _Weather.Gafor.Areas.Count : 0;

			if (_Weather.SignificantWeather != null) {
				pbxSWC.Height = _Weather.SignificantWeather.Height;
				pbxSWC.Width = _Weather.SignificantWeather.Width;
				pbxSWC.Image = _Weather.SignificantWeather;
			}

			if (!String.IsNullOrWhiteSpace(_Weather.TextReport)) {
				txtTextReport.Text = _Weather.TextReport;
			}

			FillGaforDropDown();

			tslStatus.Text = Strings.Completed;
		}
		
		private void LoadGaforSvgFile() {
			String path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gafor.svg");
			_GaforSvg = SvgDocument.Open(path);
		}

		private void FillGaforDropDown() {
			tscForecast.Items.Clear();

			if (_Weather.Gafor == null) {
				return;
			}

			foreach (String forecast in _Weather.Gafor.Forecasts) {
				tscForecast.Items.Add(forecast);
			}

			if (tscForecast.Items.Count > 0) {
				tscForecast.SelectedIndex = 0;
			}
		}

		private void FillGaforSvg() {
			Int32 selectedIndex = tscForecast.SelectedIndex;
			if (selectedIndex < 0 || _Weather.Gafor == null) {
				return;
			}

			foreach (KeyValuePair<Int32, GaforForecast[]> item in _Weather.Gafor.Areas) {
				if (item.Value.Length < selectedIndex) {
					continue;
				}

				GaforForecast forecast = item.Value[selectedIndex];
				SvgPath element = _GaforSvg.GetElementById(String.Format("gafor_{0:00}", item.Key)) as SvgPath;

				if (element != null) {
					element.Content = forecast.Info;
					element.Fill = new SvgColourServer(Color.FromArgb(GaforInfo.ResolveStatusColor(forecast.Status)));
				}
			}
		}

		private void DrawGaforSvg() {
			_GaforSvg.Height = pbxGafor.Height;
			_GaforSvg.Width = pbxGafor.Width;
			pbxGafor.Image = _GaforSvg.Draw();
		}

		private void lvwMetar_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			MetarTafInfo info = _Weather.MetarTaf[e.ItemIndex];
			Clouds ceiling = info.Metar.Ceiling;
			Distance visibility = info.Metar.Visibility;

			String[] fields = new String[] {
				info.Metar.ICAO,
				info.Metar.Altimeter.ToString(),
				visibility != null ? visibility.FormattedKilometers : String.Empty,
				info.Metar.TemperatureAndDewpoint,
				info.Metar.Wind.ToString(),
				ceiling != null ? ceiling.ToString() : String.Empty
			};

			e.Item = new ListViewItem(fields);
			e.Item.UseItemStyleForSubItems = false;
			e.Item.ToolTipText = info.Metar.Category.ToString();
			e.Item.BackColor = Color.FromArgb(info.Metar.ColorCode);
		}

		private void lvwMetar_DoubleClick(object sender, EventArgs e) {
			if (lvwMetar.SelectedIndices.Count == 0) {
				return;
			}

			MetarTafInfo info = _Weather.MetarTaf[lvwMetar.SelectedIndices[0]];
			MetarTafDetailsForm form = new MetarTafDetailsForm(info);
			form.ShowDialog();
		}

		private void WeatherBriefingForm_ResizeEnd(object sender, EventArgs e) {
			DrawGaforSvg();
		}

		private void tscForecast_SelectedIndexChanged(object sender, EventArgs e) {
			FillGaforSvg();
			DrawGaforSvg();
		}

		private void WeatherBriefingForm_Resize(object sender, EventArgs e) {
			if (WindowState == FormWindowState.Maximized || WindowState == FormWindowState.Minimized) {
				DrawGaforSvg();
			}
		}
		
		private void WeatherBriefingForm_Shown(object sender, EventArgs e) {
			tslStatus.Text = Strings.Loading;
			
			_BriefingWorker.DoWork += BriefingWorker_DoWork;
			_BriefingWorker.RunWorkerCompleted += BriefingWorker_RunWorkerCompleted;

			LoadGaforSvgFile();
			_BriefingWorker.RunWorkerAsync();
		}

		private void lvwGaforDetails_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			Int32 area = _Weather.Gafor.Areas.Keys.ElementAt(e.ItemIndex);
			GaforForecast[] gafor = _Weather.Gafor.Areas[area];

			if (gafor.Length == 0) {
				return;
			}

			String[] fields = new String[] {
				area.ToString("00"),
				gafor[0].Info
			};

			e.Item = new ListViewItem(fields);
		}
	}
}
