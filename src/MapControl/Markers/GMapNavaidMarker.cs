using FlightPlanner.Waypoints;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using System.Windows;

namespace FlightPlanner.MapControl.Markers {
	class GMapNavaidMarker : GMapMarker {

		private readonly Navaid _Navaid;

		public Navaid Navaid {
			get {
				return _Navaid;
			}
		}

		public GMapNavaidMarker(Map map, Navaid navaid)
			: base(new PointLatLng(navaid.Latitude, navaid.Longitude)) {

			_Navaid = navaid;

			if (navaid.Type.HasFlag(Navaid.NavaidType.VOR) && navaid.Type.HasFlag(Navaid.NavaidType.DME)) {
				Shape = new VORDMEMarker();
			}
			else if (navaid.Type.HasFlag(Navaid.NavaidType.VOR)) {
				Shape = new VORMarker();
			}
			else if (navaid.Type.HasFlag(Navaid.NavaidType.DME)) {
				Shape = new DMEMarker();
			}
			
			ZIndex = Constants.WaypointZIndex;
			Offset = new Point(-10, -10);
		}

	}
}
