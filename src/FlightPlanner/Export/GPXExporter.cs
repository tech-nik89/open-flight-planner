using FlightPlanner.Briefing;
using FlightPlanner.Interfaces;
using FlightPlanner.Waypoints;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace FlightPlanner.Export {
	public class GPXExporter : RouteExporter, IRouteExporter {
		
		public String Extension {
			get {
				return "gpx";
			}
		}
		
		public string Name {
			get {
				return "GPX";
			}
		}

		public String Filter {
			get {
				return String.Format("{0} (*.{1})|*.{1}", Name, Extension);
			}
		}

		public void Export(FlightPlan flightPlan, String path) {
			XmlDocument document = new XmlDocument();

			XmlElement gpx = document.CreateElement("gpx");
			document.AppendChild(gpx);
			gpx.SetAttribute("xmlns", "http://www.topografix.com/GPX/1/1");
			gpx.SetAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
			gpx.SetAttribute("xsi:schemaLocation", "http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd");
			gpx.SetAttribute("version", "1.1");
			gpx.SetAttribute("creator", "Open Flight Planner");

			XmlElement rte = document.CreateElement("rte");
			gpx.AppendChild(rte);

			XmlElement name = document.CreateElement("name");
			rte.AppendChild(name);
			name.InnerText = GetRouteName(flightPlan);

			foreach (Waypoint waypoint in flightPlan.Route.Waypoints) {
				XmlElement rtept = document.CreateElement("rtept");
				rte.AppendChild(rtept);

				rtept.SetAttribute("lat", waypoint.Latitude.ToString(_FormatProvider));
				rtept.SetAttribute("lon", waypoint.Longitude.ToString(_FormatProvider));
			}

			StringBuilder xml = new StringBuilder();
			xml.Append("<?xml version=\"1.0\" encoding=\"");
			xml.Append(_Encoding.WebName);
			xml.AppendLine("\" standalone=\"yes\" ?>");
			xml.Append(document.OuterXml);

			File.WriteAllText(path, xml.ToString(), _Encoding);
		}
	}
}
