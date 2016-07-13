using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FlightPlanner.MapControl.Markers {
	class GMapRouteMarker : GMapRoute {

		private static readonly Brush _RouteBrush = new SolidColorBrush(Color.FromArgb(255, 255, 0, 213));

		public GMapRouteMarker(List<PointLatLng> points) : base(points) {
			ZIndex = Constants.RouteZIndex;
		}

		public override void RegenerateShape(GMapControl map) {
			base.RegenerateShape(map);

			Path path = Shape as Path;
			if (path != null) {
				path.Stroke = _RouteBrush;
				path.StrokeThickness = 3;
			}
		}

	}
}
