using FlightPlanner.Airspaces;
using FlightPlanner.Waypoints;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace FlightPlanner.MapControl.Markers {
    class GMapAirspaceLabel : GMapMarker {

        private readonly Airspace _Airspace;

        public GMapAirspaceLabel(Airspace airspace)
            : base(new PointLatLng(airspace.NameCoordinate.Latitude, airspace.NameCoordinate.Longitude)) {

            String text = String.Empty;

            switch (airspace.Class) {
                case AirspaceClass.Restricted:
                    text = airspace.Name;
                    break;
                default:
                    text = String.Format("{0} ({1} - {2})", airspace.Class, airspace.Floor, airspace.Ceiling);
                    break;
            }

            _Airspace = airspace;
            Shape = new Label() {
                Content = text,
                Background = Brushes.White,
                BorderBrush = Brushes.DarkGray,
                BorderThickness = new System.Windows.Thickness(1),
                Foreground = Brushes.Black,
                FontSize = 8
            };
        }

    }
}
