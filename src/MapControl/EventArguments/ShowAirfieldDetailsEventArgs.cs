using FlightPlanner.Waypoints;
using System;

namespace FlightPlanner.MapControl.EventArguments {
	public class ShowAirfieldDetailsEventArgs : EventArgs {

		public Airfield Airfield { get; private set; }

		public ShowAirfieldDetailsEventArgs(Airfield airfield) {
			Airfield = airfield;
		}

	}
}
