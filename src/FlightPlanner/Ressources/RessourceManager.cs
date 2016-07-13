using FlightPlanner.Airspaces;
using FlightPlanner.Common;
using FlightPlanner.Configuration;
using FlightPlanner.Interfaces;
using FlightPlanner.Parser;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.IO;

namespace FlightPlanner.Ressources {
    public class RessourceManager {

        public static List<Waypoint> Waypoints { get; private set; } = new List<Waypoint>();
        public static List<Airspace> Airspaces { get; private set; } = new List<Airspace>();
		
		public static void LoadResources() {
			LoadResources(Config.Current.RessourceFiles, Config.Current.VisibleAirspaces);
		}

        public static void LoadResources(IEnumerable<DataFile> dataFiles, IEnumerable<AirspaceClass> visibleAirspaces) {
            Waypoints.Clear();
            Airspaces.Clear();

            foreach (DataFile file in dataFiles) {
                if (!file.Visible) {
                    continue;
                }

				Parser.Parser parser = file.GetParser();
				IWaypointParser waypointParser = parser as IWaypointParser;
				IAirspaceParser airspaceParser = parser as IAirspaceParser;

                if (waypointParser != null) {
                    Waypoints.AddRange(waypointParser.GetWaypoints());
                }

                if (airspaceParser != null) {
                    Airspaces.AddRange(airspaceParser.GetAirspaces(visibleAirspaces));
                }
            }
        }

		public static void UpdateAll() {
			UpdateAll(Config.Current.RessourceFiles, Config.Current.VisibleAirspaces);
		}

		public static void UpdateAll(IEnumerable<DataFile> dataFiles, IEnumerable<AirspaceClass> visibleAirspaces) {
			foreach(DataFile dataFile in dataFiles) {
				FileInfo fileInfo = new FileInfo(dataFile.LocalPath);
				if (fileInfo.Exists) {
					fileInfo.Delete();
				}
			}

			LoadResources(dataFiles, visibleAirspaces);
		}

		public static List<Waypoint> GetWaypointsForCountries(List<Country> countries) {
			List<Waypoint> result = new List<Waypoint>();
			
			foreach (Waypoint waypoint in Waypoints) {
				if (countries.Contains(waypoint.Country)) {
					result.Add(waypoint);
				}
			}

			return result;
		}

		public static List<Waypoint> SearchWaypoints(String searchFor, List<Country> countries) {
			List<Waypoint> result = new List<Waypoint>();
			searchFor = searchFor.ToLower().Trim();

			foreach (Waypoint waypoint in GetWaypointsForCountries(countries)) {
				if (waypoint.Name.ToLower().Contains(searchFor)) {
					result.Add(waypoint);
				}
				else if (waypoint is Airfield) {
					Airfield airfield = (Airfield)waypoint;
					if (airfield.ICAOCode.ToLower().Contains(searchFor)) {
						result.Add(waypoint);
					}
				}
			}

			return result;
		}
    }
}
