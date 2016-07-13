using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightPlanner.Waypoints;

namespace FlightPlanner.Airspaces.Segments {
	public class ArcByAngleAirspaceSegment : AirspaceSegment {

		private readonly Coordinate _Center;
		private readonly Single _Radius;
		private readonly Int32 _StartDegrees;
		private readonly Int32 _EndDegrees;
        private readonly ArcDirection _Direction;

        public override Coordinate BaseCoordinate {
            get {
                return _Center;
            }
        }

        public ArcByAngleAirspaceSegment(Coordinate center, Single radius, Int32 startDegrees, Int32 endDegrees, ArcDirection direction) {
			_Center = center;
			_Radius = radius;
			_StartDegrees = startDegrees;
			_EndDegrees = endDegrees;
            _Direction = direction;
		}
	}
}
