using FlightPlanner.Airspaces.Segments;
using FlightPlanner.Common;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FlightPlanner.Airspaces {

    [DebuggerDisplay("{Name}")]
	public class Airspace {

		public String Name { get; set; }

		public Country Country { get; set; }

		public Coordinate NameCoordinate { get; set; }

		public List<AirspaceSegment> Segments { get; set; }

		public AirspaceAltitude Ceiling { get; set; }

		public AirspaceAltitude Floor { get; set; }

		public AirspaceClass Class { get; set; }

		public Airspace() {
			Segments = new List<AirspaceSegment>();
		}

	}
}
