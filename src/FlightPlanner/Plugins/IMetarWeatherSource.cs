using FlightPlanner.Briefing;
using FlightPlanner.Weather.MetarTaf;
using System.Collections.Generic;

namespace FlightPlanner.Plugins {
	public interface IMetarWeatherSource : IPlugin {

		List<MetarTafInfo> RetrieveRouteWeatherInfo(FlightPlan flightPlan);

	}
}
