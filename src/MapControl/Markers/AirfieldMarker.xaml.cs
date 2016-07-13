using FlightPlanner.Waypoints;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace FlightPlanner.MapControl.Markers {
	/// <summary>
	/// Interaction logic for AirfieldMarker.xaml
	/// </summary>
	public partial class AirfieldMarker : UserControl {

		private static readonly Color _GrassRunwayColor = Color.FromArgb(120, 0, 200, 0);
		private static readonly Color _SolidRunwayColor = Colors.Gray;

		private static readonly Brush _PopupBackground = Brushes.White;
		private static readonly Brush _PopupBorder = Brushes.DarkGray;
		private static readonly Brush _PopupForeground = Brushes.Black;
		private static readonly Thickness _PopupBorderThickness = new Thickness(1);
		private static readonly Thickness _PopupPadding = new Thickness(8);

		private readonly Popup _Popup;
		private readonly Label _Label;

        private readonly Map _Map;
        private readonly Airfield _Airfield;

		public AirfieldMarker(Map map, Airfield airfield) {
			InitializeComponent();
			Effect = null;

			rectRunway.RenderTransform = new RotateTransform(airfield.RunwayDirection * 10 + 90, 10, 2);

			if (airfield.HardSurface) {
				rectRunway.Fill = new SolidColorBrush(_SolidRunwayColor);
			}
			else {
				rectRunway.Fill = new SolidColorBrush(_GrassRunwayColor);
			}

            _Map = map;
            _Airfield = airfield;

			_Label = new Label();
			_Label.Content = GetPopupContent(airfield);
			_Label.Background = _PopupBackground;
			_Label.BorderBrush = _PopupBorder;
			_Label.Foreground = _PopupForeground;
			_Label.BorderThickness = _PopupBorderThickness;
			_Label.Padding = _PopupPadding;
			
			_Popup = new Popup();
			_Popup.Placement = PlacementMode.Mouse;
			_Popup.Child = _Label;

			mnuAddToRoute.Header = Strings.AddToRoute;
			mnuAirfieldDetails.Header = Strings.ShowDetails;
		}

		private static String GetPopupContent(Airfield airfield) {
			StringBuilder builder = new StringBuilder();

			builder.AppendLine(airfield.Name);
			builder.AppendLine();

			builder.AppendLine(String.Format("ICAO: {0}", airfield.ICAOCode));
			builder.AppendLine(String.Format("{0}: {1}", Strings.Elevation, airfield.Elevation.FormattedFeet));
			
			return builder.ToString();
		}

		private void UserControl_MouseEnter(object sender, MouseEventArgs e) {
			_Popup.IsOpen = true;
		}

		private void UserControl_MouseLeave(object sender, MouseEventArgs e) {
			_Popup.IsOpen = false;
		}

		private void AddToRoute_Click(object sender, RoutedEventArgs e) {
            _Map.Route.AddWaypoint(_Airfield);
            _Map.UpdateRoute();
		}

		private void AirfieldDetails_Click(object sender, RoutedEventArgs e) {
			_Map.ShowAirfieldDetails(_Airfield);
		}
	}
}
