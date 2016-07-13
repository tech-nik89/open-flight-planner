using FlightPlanner.Common;
using FlightPlanner.Plugins;
using FlightPlanner.Units;
using FlightPlanner.Weather.Gafor;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace FlightPlanner.DwdLuftsportbericht {
	public class WeatherSource : IEnrouteWeatherSource {

		private String _Report;

		public Boolean Configurable { get; private set; } = false;

		public Dictionary<String, Object> Configuration {
			get {
				throw new NotSupportedException();
			}
		}

		public String Name {
			get {
				return "DWD Luftsportbericht Enroute Weather";
			}
		}

		public GaforInfo GetGafor() {

			if (!EnsureReport()) {
				return null;
			}
			
			GaforInfo info = new GaforInfo();
			GaforTextParser gaforParser = new GaforTextParser(_Report);
			gaforParser.Parse(info);

			return info;
		}

		public Image GetSignificantWeather() {
			return GetSignificantWeather(DateTime.UtcNow);
		}

		public Image GetSignificantWeather(DateTime flightTime) {
			throw new NotSupportedException();
		}

		public Dictionary<Int32, Dictionary<Altitude, Wind>> GetUpperWind() {

			Dictionary<Int32, Dictionary<Altitude, Wind>> upperWind = new Dictionary<Int32, Dictionary<Altitude, Wind>>();

			if (!EnsureReport()) {
				return null;
			}
			
			UpperWindParser windParser = new UpperWindParser(_Report);
			windParser.Parse(upperWind);

			return upperWind;
		}

		public void ShowConfiguration() {
			throw new NotSupportedException();
		}

		private Boolean EnsureReport() {
			if (!String.IsNullOrWhiteSpace(_Report)) {
				return true;
			}

			DwdLuftsportBerichtForm form = new DwdLuftsportBerichtForm();
			DialogResult result = form.ShowDialog();

			if (result == DialogResult.OK) {
				_Report = form.Report;
			}

			return !String.IsNullOrWhiteSpace(_Report);
		}
	}
}
