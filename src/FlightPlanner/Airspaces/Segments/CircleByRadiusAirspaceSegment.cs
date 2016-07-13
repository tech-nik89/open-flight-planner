using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightPlanner.Waypoints;

namespace FlightPlanner.Airspaces.Segments {
	public class CircleByRadiusAirspaceSegment : AirspaceSegment {

		private readonly Coordinate _Center;
		private readonly Single _Radius;

		public Coordinate Center { get { return _Center; } }
		public Single Radius { get { return _Radius; } }

        public override Coordinate BaseCoordinate {
            get {
                return _Center;
            }
        }

        public CircleByRadiusAirspaceSegment(Coordinate center, Single radius) {
			_Center = center;
			_Radius = radius;
		}
	}
}
