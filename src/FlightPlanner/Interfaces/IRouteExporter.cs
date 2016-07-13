using FlightPlanner.Briefing;
using System;

namespace FlightPlanner.Interfaces {
	public interface IRouteExporter {

		String Name { get; }

		String Filter { get; }

		String Extension { get; }

		void Export(FlightPlan flightPlan, String path);

	}
}
