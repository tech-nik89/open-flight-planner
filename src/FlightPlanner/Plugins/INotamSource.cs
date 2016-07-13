using FlightPlanner.Briefing;
using FlightPlanner.Notams;
using System.Collections.Generic;

namespace FlightPlanner.Plugins {
	public interface INotamSource : IPlugin {

		List<Notam> GetNotams(FlightPlan flightPlan);

	}
}
