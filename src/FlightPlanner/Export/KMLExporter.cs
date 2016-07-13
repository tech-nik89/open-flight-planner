using FlightPlanner.Briefing;
using FlightPlanner.Interfaces;
using FlightPlanner.Waypoints;
using System;
using System.IO;
using System.Text;

namespace FlightPlanner.Export {
	public class KMLExporter : RouteExporter, IRouteExporter {
		
		private const String _Template = @"<?xml version=""1.0"" encoding=""{0}"" standalone=""yes""?>
<kml xmlns=""http://www.opengis.net/kml/2.2"">
  <Document>
	<name><![CDATA[test]]></name>
	<visibility>1</visibility>
	<open>1</open>
	<Snippet><![CDATA[created using Open Flight Planner]]></Snippet>
    <Style id=""track"">
	  <LineStyle>
		<color>ff0000e6</color>
		<width>4</width>
	  </LineStyle>
	</Style>
	<Folder id=""Tracks"">
      <name>Tracks</name>
      <visibility>1</visibility>
      <open>0</open>
      <Placemark>
        <name><![CDATA[{1}]]></name>
        <Snippet></Snippet>
        <description><![CDATA[&nbsp;]]></description>
        <styleUrl>#track</styleUrl>
        <Style>
          <LineStyle>
            <color>ff0000e6</color>
            <width>4</width>
          </LineStyle>
        </Style>
        <MultiGeometry>
          <LineString>
            <tessellate>1</tessellate>
            <altitudeMode>clampToGround</altitudeMode>
            <coordinates>{2}</coordinates>
          </LineString>
        </MultiGeometry>
      </Placemark>
    </Folder>
  </Document>
</kml>
";

		public String Extension {
			get {
				return "kml";
			}
		}

		public String Name {
			get {
				return "KML";
			}
		}

		public String Filter {
			get {
				return String.Format("{0} (*.{1})|*.{1}", Name, Extension);
			}
		}

		public void Export(FlightPlan flightPlan, String path) {
			StringBuilder coordinates = new StringBuilder();

			foreach (Waypoint waypoint in flightPlan.Route.Waypoints) {
				coordinates.Append(waypoint.Longitude.ToString(_FormatProvider));
				coordinates.Append(",");
				coordinates.Append(waypoint.Latitude.ToString(_FormatProvider));
				coordinates.Append(" ");
			}

			String xml = String.Format(_Template, _Encoding.WebName, XmlEncode(GetRouteName(flightPlan)), coordinates.ToString());
			File.WriteAllText(path, xml, _Encoding);
		}
	}
}
