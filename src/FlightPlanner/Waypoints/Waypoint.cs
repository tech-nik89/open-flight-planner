using FlightPlanner.Common;
using System;

namespace FlightPlanner.Waypoints {

    public class Waypoint : Coordinate {

		private readonly Country _Country;

		public Waypoint(Coordinate coordinate, Country country)
			: base(coordinate.Latitude, coordinate.Longitude) {

			_Country = country;
		}

		public Country Country {
			get {
				return _Country;
			}
		}

		public virtual String Name {
			get {
				return String.Format("WP-{0}-{1}", Math.Round(Latitude, 0), Math.Round(Longitude, 0));
			}
		}

		public virtual Boolean Search(String searchFor) {
			return false;
		}
		
		public override String ToString() {
			return Name;
		}
	}
}
