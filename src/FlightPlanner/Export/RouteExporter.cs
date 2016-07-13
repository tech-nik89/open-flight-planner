using FlightPlanner.Briefing;
using System;
using System.Globalization;
using System.Text;

namespace FlightPlanner.Export {
	public class RouteExporter {

		protected static readonly Encoding _Encoding = Encoding.UTF8;
		protected static readonly CultureInfo _FormatProvider = new CultureInfo("en-US");

		protected static String GetRouteName(FlightPlan flightPlan) {
			StringBuilder name = new StringBuilder();

			if (flightPlan.Route.Departure != null) {
				name.Append(flightPlan.Route.Departure.Name);
			}

			name.Append(" -> ");

			if (flightPlan.Route.Destination != null) {
				name.Append(flightPlan.Route.Destination.Name);
			}

			return name.ToString();
		}

		protected static String XmlEncode(String str) {
			return str.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
		}
	}
}
