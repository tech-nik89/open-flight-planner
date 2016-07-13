using FlightPlanner.Common;
using FlightPlanner.Units;
using System;
using System.Linq;

namespace FlightPlanner.Waypoints {
	public class Airfield : Waypoint {

		private readonly String _Name;
		private readonly String _ICAO;
		private readonly Runway[] _Runways;
		private readonly Frequency _Frequency;
		private readonly Elevation _Elevation;

		public Airfield(String name, String icaoCode, Coordinate coordinate, Elevation elevation, Runway[] runways, Frequency frequency = null, Country country = Country.Undefined)
			: base(coordinate, country) {

			_Name = name;
			_ICAO = icaoCode;
			_Runways = runways;
			_Frequency = frequency;
			_Elevation = elevation;
		}

		public Elevation Elevation {
			get {
				return _Elevation;
			}
		}

		public Runway.SurfaceType RunwaySurface {
			get {
				if (_Runways.Length == 0) {
					return Runway.SurfaceType.Undefined;
				}

				return _Runways[0].Surface;
			}
		}

		public Int32 RunwayLength {
			get {
				if (_Runways.Length == 0) {
					return -1;
				}

				return _Runways[0].Length;
			}
		}

		public Int32 RunwayDirection {
			get {
				if (_Runways.Length == 0) {
					return -1;
				}

				return _Runways[0].Direction;
			}
		}

		public String RunwayDirectionInfo {
			get {
				if (_Runways.Length == 0) {
					return String.Empty;
				}

				return String.Join(", ", _Runways.Select(r => r.DirectionInfo).ToArray());
			}
		}

		public Boolean HardSurface {
			get {
				if (_Runways.Length == 0) {
					return false;
				}

				return _Runways[0].Surface == Runway.SurfaceType.Asphalt || _Runways[0].Surface == Runway.SurfaceType.Concrete;
			}
		}

		public override String Name {
			get {
				return _Name;
			}
		}

		public String ICAOCode {
			get {
				return _ICAO;
			}
		}
		
		public override Boolean Search(String searchFor) {
			return _Name.IndexOf(searchFor, StringComparison.InvariantCultureIgnoreCase) >= 0 || _ICAO.IndexOf(searchFor, StringComparison.InvariantCultureIgnoreCase) >= 0;
		}

		public Frequency Frequency {
			get {
				return _Frequency;
			}
		}

		public Runway[] Runways {
			get {
				return _Runways;
			}
		}
	}
}
