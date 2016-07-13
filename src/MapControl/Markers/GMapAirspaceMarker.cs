using FlightPlanner.Airspaces;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FlightPlanner.MapControl.Markers {
	class GMapAirspaceMarker : GMapPolygon {

		private readonly Airspace _Airspace;
		private readonly Brush _FillBrush;
        private readonly Brush _BorderBrush;
        private readonly Double _BorderThickness;

        private static readonly SolidColorBrush _DefaultBorderBrush = Brushes.DarkBlue;
        private static readonly Double _DefaultBorderThickness = 1.5;
        private static readonly SolidColorBrush _DefaultFillBrush = Brushes.Transparent;

        private static readonly SolidColorBrush _CtrFillBrush = new SolidColorBrush(Color.FromArgb(120, 255, 0, 0));

        private static readonly SolidColorBrush _RestrictedBorderBrush = new SolidColorBrush(Color.FromArgb(120, 255, 0, 0));
        private static readonly Double _RestrictedBorderThickness = 5;

        public GMapAirspaceMarker(Airspace airspace, IEnumerable<PointLatLng> points) : base(points) {
			_Airspace = airspace;
			ZIndex = Constants.AirspaceZIndex;

            _FillBrush = _DefaultFillBrush;
            _BorderBrush = _DefaultBorderBrush;
            _BorderThickness = _DefaultBorderThickness;

            switch (_Airspace.Class) {
                case AirspaceClass.CTR:
                    _FillBrush = _CtrFillBrush;
                    break;
                case AirspaceClass.Restricted:
                    _BorderBrush = _RestrictedBorderBrush;
                    _BorderThickness = _RestrictedBorderThickness;
                    break;
            }
			
		}

		public override void RegenerateShape(GMapControl map) {
			base.RegenerateShape(map);

			Path path = Shape as Path;

			if (path != null) {
				path.Stroke = _BorderBrush;
				path.StrokeThickness = _BorderThickness;
				path.Fill = _FillBrush;
			}
		}
	}
}
