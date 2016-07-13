using FlightPlanner.Briefing;
using FlightPlanner.Interfaces;
using FlightPlanner.Waypoints;
using System;
using System.IO;
using System.Text;

namespace FlightPlanner.Export {
	public class WaypointPlusExporter : RouteExporter, IRouteExporter {

		public String Extension {
			get {
				return "txt";
			}
		}

		public String Name {
			get {
				return "Waypoint+";
			}
		}

		public String Filter {
			get {
				return String.Format("{0} (*.{1})|*.{1}", Name, Extension);
			}
		}

		private const String _RowTemplate = "RP,D,{0},{1},{2},{3},{4},{5}";
		private const String _HeadTemplate = "RN,1,{0}";

		public void Export(FlightPlan flightPlan, String path) {
			StringBuilder contents = new StringBuilder();

			String date = DateTime.Now.ToString("MM/dd/yyyy");
			String time = DateTime.Now.ToString("HH:mm:ss");

			contents.AppendFormat(_HeadTemplate, GetRouteName(flightPlan));
			contents.AppendLine();

			foreach (Waypoint waypoint in flightPlan.Route.Waypoints) {
				contents.AppendFormat(_RowTemplate,
					waypoint.Name,
					waypoint.Latitude.ToString(_FormatProvider),
					waypoint.Longitude.ToString(_FormatProvider),
					date,
					time,
					waypoint.Name);
				contents.AppendLine();
			}

			File.WriteAllText(path, contents.ToString(), _Encoding);
		}
	}
}
