using FlightPlanner.Waypoints;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using System.Windows;

namespace FlightPlanner.MapControl.Markers {
    class GMapAirfieldMarker : GMapMarker {

		private readonly Airfield _Airfield;

		public Airfield Airfield {
			get {
				return _Airfield;
			}
		}
        
		public GMapAirfieldMarker(Map map, Airfield airfield)
			: base(new PointLatLng(airfield.Latitude, airfield.Longitude)) {

			_Airfield = airfield;
            
			Shape = new AirfieldMarker(map, airfield);
			ZIndex = Constants.WaypointZIndex;
			Offset = new Point(-10, -10);
		}

	}
}
