using FlightPlanner.Common;
using FlightPlanner.Units;
using System;

namespace FlightPlanner.Waypoints {
	public class Navaid : Waypoint {

		private String _Name;
		public NavaidType Type { get; private set; }
		public String Identifier { get; private set; }
		public Elevation Elevation { get; private set; }

		public Navaid(String name, String identifier, NavaidType type, Elevation elevation, Coordinate coordinate, Country country) : base(coordinate, country) {
			_Name = name;
			Identifier = identifier;
			Type = type;
			Elevation = elevation;
		}

		public override String Name {
			get {
				return _Name;
			}
		}

		public String FormattedType {
			get {
				return Type.ToString();
			}
		}

		[Flags]
		public enum NavaidType {
			Undefined = 0,
			NDB = 1,
			VOR = 2,
			DME = 4,
			VORTAC = 8,
			TACAN = 16
		}
	}
}
