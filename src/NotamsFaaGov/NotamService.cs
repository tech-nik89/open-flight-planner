using FlightPlanner.Briefing;
using FlightPlanner.Notams;
using FlightPlanner.Plugins;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace NotamsFaaGov {
	public class NotamService : INotamSource {
		
		private const String _FlightPathUrl = "https://pilotweb.nas.faa.gov/PilotWeb/flightPathSearchAction.do";
		private const Int32 _FlightPathBuffer = 20;
		private const String _HttpHeaderForm = "application/x-www-form-urlencoded";
		
        private static readonly Regex _NotamRegex = new Regex(@"<a[\s]*name=""(\w{4})"">|<span>\s*<strong>(\w*)/(\d{2})</strong> - ([^<]*)\s*</span>", RegexOptions.IgnoreCase);
		private static readonly Regex _NotamCountRegex = new Regex(@"Number of NOTAMS:(?:&nbsp;|\s)*(\d+)", RegexOptions.IgnoreCase);

		public String Name {
			get {
				return "pilotweb.nas.faa.gov";
			}
		}

		public Boolean Configurable { get; private set; } = false;

		public Dictionary<String, Object> Configuration {
			get {
				throw new NotSupportedException();
			}
		}

		public List<Notam> GetNotams(FlightPlan flightPlan) {
			List<Notam> list = new List<Notam>();

			Airfield departure = flightPlan.Route.Departure as Airfield;
			Airfield destination = flightPlan.Route.Destination as Airfield;

			if (departure == null || destination == null) {
				return list;
			}

			using (WebClient client = new WebClient()) {
				client.Headers[HttpRequestHeader.ContentType] = _HttpHeaderForm;
				
				String data = CreateRequestData(new Dictionary<String, String>(){
					{ "formatType", "DOMESTIC" },
					{ "geoFlightPathIcao1", departure.ICAOCode },
					{ "geoFlightPathIcao2", destination.ICAOCode },
					{ "geoFlightPathIcao3", "" },
					{ "geoFlightPathIcao4", "" },
					{ "geoFlightPathIcao5", "" },
					{ "geoFlightPathbuffer", _FlightPathBuffer.ToString() },
					{ "openItems", "icaosHeader,icaos:icaoHead,icao:flightPathHeader,flightPath:rightNavSec0,rightNavSecBorder0:" },
					{ "actionType", "flightPathSearch" }
				});

				String html = client.UploadString(_FlightPathUrl, data);
				ReadNotamsFromWebsite(list, html);
			}

			return list;
		}

		private static void ReadNotamsFromWebsite(List<Notam> list, String html) {
			Match numberOfNotamsMatch = _NotamCountRegex.Match(html);
			if (!numberOfNotamsMatch.Success) {
				return;
			}

			Int32 notamCount = Int32.Parse(numberOfNotamsMatch.Groups[1].Value.Trim());
			MatchCollection matches = _NotamRegex.Matches(html);

			String area = String.Empty;

			foreach (Match match in matches) {
				if (match.Groups[1].Success) {
					area = match.Groups[1].Value.Trim();
				}
				else if (!match.Groups[1].Success && !String.IsNullOrWhiteSpace(area)) {
					Notam notam = new Notam();

					notam.Area = area;
					notam.Number = match.Groups[2].Value.Trim();
					notam.Year = GetYear(match.Groups[3].Value.Trim());
					notam.Text = match.Groups[4].Value.Trim();

					list.Add(notam);
				}
			}
		}

		private static DateTime GetYear(String match) {
			Int32 year = -1;

			if (!Int32.TryParse(match, out year)) {
				return DateTime.MinValue;
			}

			if (year > 70) {
				year += 1900;
			}
			else {
				year += 2000;
			}

			return new DateTime(year, 1, 1);
		}

		private static String CreateRequestData(Dictionary<String, String> vars) {
			List<String> str = new List<String>();

			foreach (var item in vars) {
				str.Add(String.Format("{0}={1}", item.Key, item.Value));
			}

			return String.Join("&", str);
		}

		public void ShowConfiguration() {
			throw new NotSupportedException();
		}
	}
}
