using FlightPlanner.Briefing;
using FlightPlanner.Exceptions;
using FlightPlanner.Notams;
using FlightPlanner.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlExport {
	class NotamExporter {
		public static void AddNotams(StringBuilder document, FlightPlan flightPlan) {
			document.AppendLine("<h1>NOTAMS</h1>");
			
			try {
				if (PluginManager.NotamSource == null) {
					throw new PluginNotConfiguredException(typeof(INotamSource));
				}

				List<Notam> notams = PluginManager.NotamSource.GetNotams(flightPlan);

				foreach (Notam notam in notams) {
					document.Append("<p><pre><strong>");
					document.Append(notam.Number);
					document.Append("/");
					document.Append(notam.Year.ToString("yy"));
					document.Append("</strong> - ");
					document.Append(PrepareNotamText(notam.Text));
					document.AppendLine("</pre></p>");
				}
			}
			catch (Exception e) {
				document.Append("<p>Error: ");
				document.Append(e.Message);
				document.AppendLine("</p>");
			}
		}

		private static String PrepareNotamText(String text) {
			String result = String.Empty;
			result = text.Replace("\n", Environment.NewLine);
			result = result.Replace(Environment.NewLine, "<br />" + Environment.NewLine);

			return result;
		}
	}
}
