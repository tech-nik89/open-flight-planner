using FlightPlanner.Airspaces;
using FlightPlanner.Airspaces.Segments;
using FlightPlanner.Common;
using FlightPlanner.MapControl.EventArguments;
using FlightPlanner.MapControl.Markers;
using FlightPlanner.Ressources;
using FlightPlanner.Tools;
using FlightPlanner.Units;
using FlightPlanner.Waypoints;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlightPlanner.MapControl {

	/// <summary>
	/// Interaction logic for Map.xaml
	/// </summary>
	public partial class Map : UserControl {

		private readonly Cursor _DefaultMapCursor = Cursors.SizeAll;
		private readonly MouseButton _DefaultMapDragMouseButton = MouseButton.Left;

		public List<Waypoint> Waypoints { get; private set; }
		private List<GMapMarker> _AirspaceMarkers;
		private List<GMapMarker> _WaypointMarkers;

		public event EventHandler OnRouteChanged;

		public event EventHandler<ShowAirfieldDetailsEventArgs> OnShowAirfieldDetails;

		private const Double DegreeStepSize = 4;

        private GMapRoute _Route;

		private Mode _Mode;

        public Route Route { get; set; }

		public Coordinate Position {
			get {
				return new Coordinate(MapControl.Position.Lat, MapControl.Position.Lng);
			}
			set {
				MapControl.Position = new PointLatLng(value.Latitude, value.Longitude);
			}
		}

		public Double Zoom {
			get {
				return MapControl.Zoom;
			}
			set {
				MapControl.Zoom = value;
			}
		}
        
		public Map() {
			InitializeComponent();
			InitializeMapControl();

			Waypoints = new List<Waypoint>();

			lblNotification.Visibility = Visibility.Hidden;
			_AirspaceMarkers = new List<GMapMarker>();
			_WaypointMarkers = new List<GMapMarker>();
		}

		private void InitializeMapControl() {
			MapControl.MouseLeftButtonDown += MapControl_MouseLeftButtonDown;
			MapControl.MapProvider = GMapProviders.GoogleTerrainMap;
			MapControl.Position = new PointLatLng(48.631944, 9.430556);
			MapControl.ShowCenter = false;
			MapControl.MinZoom = 0;
			MapControl.MaxZoom = 48;
			MapControl.Zoom = 9;
			MapControl.DragButton = _DefaultMapDragMouseButton;
			MapControl.Cursor = _DefaultMapCursor;
			MapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
			MapControl.OnMapZoomChanged += MapControl_OnMapZoomChanged;
		}

		private void MapControl_OnMapZoomChanged() {
			Double zoom = Zoom;
			lblZoom.Content = zoom;

			if (zoom >= 8) {
				foreach (GMapMarker waypoint in _WaypointMarkers) {
					if (!MapControl.Markers.Contains(waypoint)) {
						MapControl.Markers.Add(waypoint);
					}
				}
			}
			else if (zoom == 7) {
				foreach (GMapMarker waypoint in _WaypointMarkers) {
					if (waypoint is GMapNavaidMarker && MapControl.Markers.Contains(waypoint)) {
						MapControl.Markers.Remove(waypoint);
					}
					else if (waypoint is GMapAirfieldMarker && !MapControl.Markers.Contains(waypoint)) {
						MapControl.Markers.Add(waypoint);
					}
				}
			}
			else if (zoom <= 6) {
				foreach (GMapMarker waypoint in _WaypointMarkers) {
					GMapNavaidMarker navaid = waypoint as GMapNavaidMarker;
					GMapAirfieldMarker airfield = waypoint as GMapAirfieldMarker;

					if ((navaid != null || (airfield != null && !airfield.Airfield.HardSurface))
						&& MapControl.Markers.Contains(waypoint)) {
						MapControl.Markers.Remove(waypoint);
					}
				}
			}
		}

		public static List<String> AvailableProviders {
			get {
				List<String> list = new List<String>();

				foreach (GMapProvider provider in GMapProviders.List) {
					if (provider.Name == "None") {
						continue;
					}

					list.Add(provider.Name);
				}

				return list;
			}
		}

		public String Provider {
			get {
				return MapControl.MapProvider.Name;
			}
			set {
				GMapProvider provider = GMapProviders.List.SingleOrDefault(p => p.Name == value);
				if (provider != null) {
					MapControl.MapProvider = provider;
				}
			}
		}

		public void ZoomIn() {
			MapControl.Zoom += 1;
		}

		public void ZoomOut() {
			MapControl.Zoom -= 1;
		}

		public void CenterRoute() {
			MapControl.ZoomAndCenterMarkers(Constants.RouteZIndex);
		}

        public void UpdateResources() {
            UpdateResources(new Country[0]);
        }

        public void UpdateResources(Country[] countries) {
            UpdateAirspaces(countries);
            UpdateWaypoints(countries);
        }

        public void UpdateAirspaces() {
            UpdateAirspaces(new Country[0]);
        }

        public void UpdateAirspaces(Country[] countries) {
            UpdateAirspaces(RessourceManager.Airspaces, countries);
        }

		public void UpdateAirspaces(List<Airspace> airspaces, Country[] countries) {
			foreach (GMapAirspaceMarker marker in _AirspaceMarkers) {
				MapControl.Markers.Remove(marker);
			}

			_AirspaceMarkers.Clear();

			foreach (Airspace airspace in airspaces) {
				if (Array.IndexOf(countries, airspace.Country) == -1) {
					continue;
				}

				List<PointLatLng> points = new List<PointLatLng>();
                
				foreach (AirspaceSegment segment in airspace.Segments) {
					if (segment is PolygonAirspaceSegment) {
						PolygonAirspaceSegment polygonAirspaceSegment = (PolygonAirspaceSegment)segment;
						points.Add(polygonAirspaceSegment.Coordinate.ToPointLatLng());
					}
					else if (segment is ArcByCoordinatesAirspaceSegment) {
                        AddArcByCoordinatesPoints((ArcByCoordinatesAirspaceSegment)segment, points);
					}
					else if (segment is CircleByRadiusAirspaceSegment) {
                        AddCircleByRadiusPoints((CircleByRadiusAirspaceSegment)segment, points);
					}
				}

				GMapAirspaceMarker airspaceMarker = new GMapAirspaceMarker(airspace, points);

				MapControl.Markers.Add(airspaceMarker);
				_AirspaceMarkers.Add(airspaceMarker);
			}

			ForceRedrawMap();
		}

        private void AddCircleByRadiusPoints(CircleByRadiusAirspaceSegment segment, List<PointLatLng> points) {
            PointLatLng center = segment.Center.ToPointLatLng();
            Double radius = Distance.NauticalMilesToKilometers(segment.Radius);

            for (Double bearing = 0; bearing < 360; bearing += DegreeStepSize) {
                points.Add(GetPointFromBearingAndDistance(center, bearing, radius));
            }
        }

        private void AddArcByCoordinatesPoints(ArcByCoordinatesAirspaceSegment segment, List<PointLatLng> points) {
            
            PointLatLng center = segment.Center.ToPointLatLng();
            PointLatLng p1 = segment.Coordinate1.ToPointLatLng();
            PointLatLng p2 = segment.Coordinate2.ToPointLatLng();
            
            Double radius = MapControl.MapProvider.Projection.GetDistance(center, p1);

            Double segStart = MapControl.MapProvider.Projection.GetBearing(center, p1);
            Double segEnd = MapControl.MapProvider.Projection.GetBearing(center, p2);
            
            if (segment.Direction == ArcDirection.Clockwise) {
                
                for (Double bearing = segStart; bearing < segEnd; bearing += DegreeStepSize) {
                    points.Add(GetPointFromBearingAndDistance(center, bearing, radius));
                }
                
            }
            else if (segment.Direction == ArcDirection.CounterClockwise) {
                
                for (Double bearing = segStart; bearing > segEnd; bearing -= DegreeStepSize) {
                    points.Add(GetPointFromBearingAndDistance(center, bearing, radius));
                }
                
            }

            points.Add(p2);
        }

        private static PointLatLng GetPointFromBearingAndDistance(PointLatLng p, Double bearing, Double distance) {
            Double rlat1 = Utilities.ToRadians(p.Lat);
            Double rlng1 = Utilities.ToRadians(p.Lng);
            Double rBearing = Utilities.ToRadians(bearing);
            Double rDistance = distance / 6371.01;

            Double rlat = Math.Asin(Math.Sin(rlat1) * Math.Cos(rDistance) + Math.Cos(rlat1) * Math.Sin(rDistance) * Math.Cos(rBearing));
            Double rlng = 0;

            if (Math.Cos(rlat) == 0 || Math.Abs(Math.Cos(rlat)) < 0.000001) {
                rlng = rlng1;
            }
            else {
                rlng = ((rlng1 + Math.Asin(Math.Sin(rBearing) * Math.Sin(rDistance) / Math.Cos(rlat)) + Math.PI) % (2 * Math.PI)) - Math.PI;
            }

            return new PointLatLng(Utilities.ToDegrees(rlat), Utilities.ToDegrees(rlng));
        }

        public void UpdateWaypoints() {
            UpdateWaypoints(new Country[0]);
        }

        public void UpdateWaypoints(Country[] countries) {
            UpdateWaypoints(RessourceManager.Waypoints, countries);
        }

        public void UpdateWaypoints(List<Waypoint> waypoints, Country[] countries) {
			Waypoints = waypoints;
			UpdateWaypointsInternal(countries);
		}

		private void UpdateWaypointsInternal(Country[] countries) {
			foreach (GMapMarker marker in _WaypointMarkers) {
				MapControl.Markers.Remove(marker);
			}

			_WaypointMarkers.Clear();

			foreach (Waypoint waypoint in Waypoints) {
				if (Array.IndexOf(countries, waypoint.Country) == -1) {
					continue;
				}

				if (waypoint is Airfield) {
					Airfield airfield = (Airfield)waypoint;
					GMapAirfieldMarker marker = new GMapAirfieldMarker(this, airfield);

					MapControl.Markers.Add(marker);
					_WaypointMarkers.Add(marker);
				}
				else if(waypoint is Navaid) {
					Navaid navaid = (Navaid)waypoint;
					GMapNavaidMarker marker = new GMapNavaidMarker(this, navaid);

					MapControl.Markers.Add(marker);
					_WaypointMarkers.Add(marker);
				}
			}

			ForceRedrawMap();
		}

		private void ForceRedrawMap() {
			Double zoom = MapControl.Zoom;
			MapControl.Zoom = zoom - 0.01;
			MapControl.Zoom = zoom;
		}

		public void UpdateRoute() {
			if (_Route != null) {
				MapControl.Markers.Remove(_Route);
			}

			List<PointLatLng> points = new List<PointLatLng>();
			foreach (Waypoint waypoint in Route.Waypoints) {
				points.Add(waypoint.ToPointLatLng());
			}

			_Route = new GMapRouteMarker(points);
			MapControl.Markers.Add(_Route);
			
			_Route.RegenerateShape(MapControl);

			OnRouteChanged?.Invoke(this, new EventArgs());
		}

		public void ShowAirfieldDetails(Airfield airfield) {
			OnShowAirfieldDetails?.Invoke(this, new ShowAirfieldDetailsEventArgs(airfield));
		}

		public void DeleteWaypoints(List<Int32> indices) {
			Route.RemoveWaypoints(indices.ToArray());
			UpdateRoute();
		}

		public Boolean AddWaypointMode {
			get {
				return _Mode == Mode.AddWaypoint;
			}
			set {
				_Mode = value ? Mode.AddWaypoint : Mode.None;
				UpdateMode();
			}
		}

		public Boolean MoveWaypointMode {
			get {
				return _Mode == Mode.MoveWaypoint;
			}
			set {
				_Mode = value ? Mode.MoveWaypoint : Mode.None;
				UpdateMode();
			}
		}

		private void UpdateMode() {

			if (_Mode == Mode.None) {
				MapControl.Cursor = _DefaultMapCursor;
				MapControl.DragButton = _DefaultMapDragMouseButton;

				HideNotification();

				return;
			}

			MapControl.Cursor = Cursors.Cross;
			MapControl.DragButton = MouseButton.Right;

			ShowNotification(_Mode);
		}

		private void ShowNotification(Mode mode) {
			String message = String.Empty;

			switch (mode) {
				case Mode.AddWaypoint:
					message = "Click on the map to add a new waypoint.";
					break;
				case Mode.MoveWaypoint:
					message = "Click on the map to move the selected waypoint.";
					break;
			}

			if (!String.IsNullOrEmpty(message)) {
				lblNotification.Content = message;
				lblNotification.Visibility = Visibility.Visible;
			}
		}

		private void HideNotification() {
			lblNotification.Visibility = Visibility.Hidden;
		}

		private void MapControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {

			if (_Mode == Mode.None) {
				return;
			}

			Point point = e.GetPosition(MapControl);
			PointLatLng pointLatLng = MapControl.FromLocalToLatLng((Int32)point.X, (Int32)point.Y);

			if (_Mode == Mode.AddWaypoint) {
				Waypoint waypoint = new Waypoint(new Coordinate(pointLatLng.Lat, pointLatLng.Lng), Country.Undefined);
				Route.AddWaypoint(waypoint);
			}
			else if (_Mode == Mode.MoveWaypoint) {
				//if (lvwWaypoints.SelectedIndex == -1) {
				//	return;
				//}

				//Waypoint waypoint = Route[lvwWaypoints.SelectedIndex];
				//waypoint.MoveTo(pointLatLng.Lat, pointLatLng.Lng);
			}

			UpdateRoute();
		}

		private enum Mode {
			None,
			AddWaypoint,
			MoveWaypoint
		}
	}

	static class ExtensionMethods {

		public static PointLatLng ToPointLatLng(this Coordinate coordinate) {
			return new PointLatLng(coordinate.Latitude, coordinate.Longitude);
		}

		public static Coordinate ToCoordinate(this PointLatLng coordinate) {
			return new Coordinate(coordinate.Lat, coordinate.Lng);
		}

	}
}
