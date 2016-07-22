using FlightPlanner.Briefing;
using FlightPlanner.Export;
using System;

namespace FlightPlanner.Plugins {
	public interface IFlightLogExport : IPlugin {

		void Export(FlightPlan flightPlan, String path);

		void Export(FlightPlan flightPlan, String path, ExportOptions options);

		String Filter { get; }

		String Extension { get; }

		event EventHandler<EventArgs> ProgressChanged;

		Int32 Progress { get; }

		String CurrentStep { get; }

	}
}
