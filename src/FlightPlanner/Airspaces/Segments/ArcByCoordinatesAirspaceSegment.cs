using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightPlanner.Waypoints;

namespace FlightPlanner.Airspaces.Segments {
	public class ArcByCoordinatesAirspaceSegment : AirspaceSegment {

		private readonly Coordinate _Center;

		private readonly Coordinate _Coordinate1;
		private readonly Coordinate _Coordinate2;
        private readonly ArcDirection _Direction;

		public Coordinate Center { get { return _Center; } }
		public Coordinate Coordinate1 { get { return _Coordinate1; } }
		public Coordinate Coordinate2 { get { return _Coordinate2; } }
        public ArcDirection Direction { get { return _Direction; } }

        public override Coordinate BaseCoordinate {
            get {
                return _Center;
            }
        }

        public ArcByCoordinatesAirspaceSegment(Coordinate center, Coordinate coordinate1, Coordinate coordinate2, ArcDirection direction) {
			_Center = center;
            _Direction = direction;

			_Coordinate1 = coordinate1;
			_Coordinate2 = coordinate2;
		}
	}
}
