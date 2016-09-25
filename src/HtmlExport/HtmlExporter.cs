using FlightPlanner.Briefing;
using FlightPlanner.Plugins;
using FlightPlanner.Waypoints;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using FlightPlanner.Export;

namespace HtmlExport {
	public class HtmlExporter : IFlightLogExport {

		public event EventHandler<EventArgs> ProgressChanged;

		public Int32 Progress { get; private set; }

		public String CurrentStep { get; private set; }

		private const String NonBreakingSpace = "&nbsp;";

		private const Int32 Steps = 6;

		public String Name {
			get {
				return "HTML";
			}
		}

		public String Extension {
			get {
				return "html";
			}
		}

		public String Filter {
			get {
				return String.Format("HTML (*.{0})|*.{0}", Extension);
			}
		}

		public Boolean Configurable { get; private set; } = false;

		public Dictionary<String, Object> Configuration {
			get {
				throw new NotSupportedException();
			}
		}

		private static readonly Encoding _Encoding = Encoding.UTF8;

		public void Export(FlightPlan flightPlan, String path) {
			Export(flightPlan, path, new ExportOptions() { All = true });
		}

		public void Export(FlightPlan flightPlan, String path, ExportOptions options) {
			UpdateStatus(0, "Preparing file ...");

			StringBuilder document = CreateDocument();

			document.AppendLine("<html>");
			document.AppendLine("<head>");

			AddEncoding(document);
			AddCss(document);

			document.AppendLine("</head>");
			document.AppendLine("<body>");

			UpdateStatus(1, "Adding general information ...");

			AddHeader(document, flightPlan);

			if (options.FlightLog) {
				AddLegs(document, flightPlan);
				AddPageBreak(document);
			}

			UpdateStatus(2, "Adding weather information ...");
			WeatherExporter.AddWeatherBriefing(document, flightPlan, options);
			
			UpdateStatus(3, "Adding mass and balance ...");
			if (options.MassAndBalance) {
				MassAndBalanceExporter.AddMassAndBalance(document, flightPlan);
			}

			UpdateStatus(4, "Adding NOTAMS ...");
			if (options.Notams) {
				NotamExporter.AddNotams(document, flightPlan);
			}

			document.AppendLine("</body>");
			document.AppendLine("</html>");

			UpdateStatus(5, "Writing file ...");
			File.WriteAllText(path, document.ToString(), _Encoding);

			UpdateStatus(6, "Completed");
		}
		
		private static StringBuilder CreateDocument() {
			StringBuilder document = new StringBuilder();
			document.AppendLine("<!DOCTYPE html>");
			return document;
		}

		private static void AddEncoding(StringBuilder document) {
			document.Append("<meta charset=\"");
			document.Append(_Encoding.WebName);
			document.AppendLine("\" />");
		}

		private static void AddLegs(StringBuilder document, FlightPlan flightPlan) {
			document.Append("<p><table border=\"1\" class=\"legs\">");

			document.AppendLine("<tr>");
			document.AppendLine(CreateTag("th", "From"));
			document.AppendLine(CreateTag("th", "To"));
			document.AppendLine(CreateTag("th", "Altitude"));
			document.AppendLine(CreateTag("th", "TC"));
			document.AppendLine(CreateTag("th", "MH"));
			document.AppendLine(CreateTag("th", "GS"));
			document.AppendLine(CreateTag("th", "Distance"));
			document.AppendLine(CreateTag("th", "Leg Time"));
			document.AppendLine(CreateTag("th", "Act Time"));
			document.AppendLine("</tr>");

			foreach (Leg leg in flightPlan.Route.Legs) {
				document.AppendLine("<tr>");
				document.AppendLine(CreateTag("td", leg.Waypoint1.Name));
				document.AppendLine(CreateTag("td", leg.Waypoint2.Name));
				document.AppendLine(CreateTag("td", leg.Altitude.ToString()));
				document.AppendLine(CreateTag("td", leg.TrueCourseFormatted));
				document.AppendLine(CreateTag("td", leg.MagneticHeadingFormatted));
				document.AppendLine(CreateTag("td", leg.GroundSpeed.ToString()));
				document.AppendLine(CreateTag("td", leg.Distance.FormattedNauticalMiles));
				document.AppendLine(CreateTag("td", leg.TimeFormatted));
				document.AppendLine(CreateTag("td", NonBreakingSpace));
				document.AppendLine("</tr>");
			}

			document.AppendLine("<tr>");
			document.AppendLine("<td colspan=\"6\">&nbsp;</td>");
			document.AppendLine(CreateTag("td", flightPlan.Route.Distance.FormattedNauticalMiles));
			document.AppendLine(CreateTag("td", flightPlan.Route.TotalTimeFormatted));
			document.AppendLine("</tr>");

			document.Append("</table></p>");
		}

		private static void AddHeader(StringBuilder document, FlightPlan flightPlan) {
			document.Append("<table border=\"1\" class=\"header\"><tr>");

			document.Append(CreateTag("td", "VFR Flight Briefing"));

			document.Append(CreateTag("td", CreateTag("span", "Date:") + DateTime.Now.ToShortDateString()));
			document.Append(CreateTag("td", CreateTag("span", "From:") + (flightPlan.Route.Departure != null ? flightPlan.Route.Departure.Name : String.Empty)));
			document.Append(CreateTag("td", CreateTag("span", "To:") + (flightPlan.Route.Destination != null ? flightPlan.Route.Destination.Name : String.Empty)));
			document.Append(CreateTag("td", CreateTag("span", "Type:") + (flightPlan.Aircraft != null ? flightPlan.Aircraft.Type : String.Empty)));
			document.Append(CreateTag("td", CreateTag("span", "Registration:") + (flightPlan.Aircraft != null ? flightPlan.Aircraft.Registration : String.Empty)));

			document.Append("</tr></table>");
		}
		
		private static void AddCss(StringBuilder document) {
			document.AppendLine("<style type=\"text/css\">");

			document.AppendLine("html, body { width: 210mm; padding:5px; margin:0px; font-size:11pt; font-family:Calibri; }");
			document.AppendLine("h1 { font-size:1.2em; }");
			document.AppendLine("h2 { font-size:1.1em; }");
			document.AppendLine(".page-break { page-break-after:always; height:0px; }");
			document.AppendLine("table { width:100%; border-collapse:collapse; }");
			document.AppendLine("table th { text-align:left; font-weight:bold; }");
			document.AppendLine("table.header td:first-child { font-size:1.2em; padding:3px; }");
			document.AppendLine("table.header td:not(:first-child) { position:relative;padding-top:11pt; }");
			document.AppendLine("table.header td > span { position:absolute; left:1px; top:1px; font-size:0.8em; }");
			document.AppendLine(".left { float:left; }");
			document.AppendLine(".clear { clear:both; }");
			document.AppendLine("table.mass, table.fuel { width:200px; }");

			document.AppendLine("</style>");
		}

		private static String CreateTag(String tag) {
			return CreateTag(tag, null, null);
		}

		private static String CreateTag(String tag, String content) {
			return CreateTag(tag, content, null);
		}

		private static String CreateTag(String tag, String content, String cssClass) {
			StringBuilder document = new StringBuilder();

			document.Append("<");
			document.Append(tag);

			if (!String.IsNullOrEmpty(cssClass)) {
				document.Append(" class=\"");
				document.Append(cssClass);
				document.Append("\"");
			}

			if (!String.IsNullOrWhiteSpace(content)) {
				document.Append(">");
				document.Append(content);
				document.Append("</");
				document.Append(tag);
				document.Append(">");
			}
			else {
				document.Append(" />");
			}

			return document.ToString();
		}

		private static void AddPageBreak(StringBuilder document) {
			document.AppendLine("<div class=\"page-break\">&nbsp;</div>");
		}

		private void UpdateStatus(Int32 step, String text) {

			CurrentStep = text;
			Progress = (Int32)(((Single)step / (Single)Steps) * 100);

			if (ProgressChanged != null) {
				ProgressChanged.Invoke(this, new EventArgs());
			}
		}

		public void ShowConfiguration() {
			throw new NotSupportedException();
		}
	}
}
