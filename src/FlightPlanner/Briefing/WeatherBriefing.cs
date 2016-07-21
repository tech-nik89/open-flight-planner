using FlightPlanner.Common;
using FlightPlanner.Exceptions;
using FlightPlanner.Plugins;
using FlightPlanner.Units;
using FlightPlanner.Weather.Gafor;
using FlightPlanner.Weather.MetarTaf;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FlightPlanner.Briefing {
	public class WeatherBriefing {

		public List<MetarTafInfo> MetarTaf { get; private set; }

		public GaforInfo Gafor { get; private set; }

		public Dictionary<Int32, Dictionary<Altitude, Wind>> UpperWind { get; private set; }

		public Image SignificantWeather { get; private set; }

		public String TextReport { get; private set; }

		private WeatherBriefing() {
		}

		public static WeatherBriefing Create(FlightPlan flightPlan) {
			WeatherBriefing weatherBriefing = new WeatherBriefing();

			IEnrouteWeatherSource enrouteWeatherSource = PluginManager.EnrouteWeatherSource;
			IMetarWeatherSource metarSource = PluginManager.MetarWeatherSource;

			if (enrouteWeatherSource == null) {
				throw new PluginNotConfiguredException(typeof(IEnrouteWeatherSource));
			}

			if (metarSource == null) {
				throw new PluginNotConfiguredException(typeof(IMetarWeatherSource));
			}

			weatherBriefing.MetarTaf = metarSource.RetrieveRouteWeatherInfo(flightPlan);
			weatherBriefing.Gafor = enrouteWeatherSource.GetGafor();
			weatherBriefing.UpperWind = enrouteWeatherSource.GetUpperWind();
			weatherBriefing.TextReport = enrouteWeatherSource.GetTextReport();

			try {
				weatherBriefing.SignificantWeather = enrouteWeatherSource.GetSignificantWeather();
			}
			catch(NotSupportedException) {
				weatherBriefing.SignificantWeather = null;
			}

			return weatherBriefing;
		}
	}
}
