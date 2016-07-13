using FlightPlanner.Common;
using FlightPlanner.Units;
using FlightPlanner.Weather.Gafor;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FlightPlanner.Plugins {
	public interface IEnrouteWeatherSource : IPlugin {
		
		GaforInfo GetGafor();

		Dictionary<Int32, Dictionary<Altitude, Wind>> GetUpperWind();

		Image GetSignificantWeather();

		Image GetSignificantWeather(DateTime flightTime);

	}
}
