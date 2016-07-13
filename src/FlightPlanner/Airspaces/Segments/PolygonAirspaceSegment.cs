using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightPlanner.Waypoints;

namespace FlightPlanner.Airspaces.Segments {
	public class PolygonAirspaceSegment : AirspaceSegment {

		private readonly Coordinate _Coordinate;

		public Coordinate Coordinate { get { return _Coordinate; } }

        public override Coordinate BaseCoordinate {
            get {
                return _Coordinate;
            }
        }

        public PolygonAirspaceSegment(Coordinate coordinate) {
			_Coordinate = coordinate;
		}

	}
}
