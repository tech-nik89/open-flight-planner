using FlightPlanner.Briefing;
using FlightPlanner.Common;
using FlightPlanner.Plugins;
using FlightPlanner.Units;
using FlightPlanner.Waypoints;
using FlightPlanner.Weather.MetarTaf;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace FlightPlanner.PCMET {
	public class MetarTafWeatherSource : IMetarWeatherSource {

		public String Name {
			get {
				return Constants.DataSourceName;
			}
		}

		public Boolean Configurable { get; private set; } = true;

		public Dictionary<String, Object> Configuration {
			get {
				return Constants.Configuration;
			}
		}

		public List<MetarTafInfo> RetrieveRouteWeatherInfo(FlightPlan flightPlan) {
			Route route = flightPlan.Route;

			Airfield departureAirport = route.Departure as Airfield;
			Airfield destinationAirport = route.Destination as Airfield;

			List<MetarTafInfo> list = new List<MetarTafInfo>();
			
			String metarXml = Connection.DownloadMetar();
			String tafXml = Connection.DownloadTaf();

			XmlDocument metarDocument = new XmlDocument();
			metarDocument.LoadXml(metarXml);

			XmlDocument tafDocument = new XmlDocument();
			tafDocument.LoadXml(tafXml);

			if (departureAirport != null) {
				list.Add(GetMetarTafFromDocuments(departureAirport.ICAOCode, metarDocument, tafDocument));
			}

			if (destinationAirport != null) {
				list.Add(GetMetarTafFromDocuments(destinationAirport.ICAOCode, metarDocument, tafDocument));
			}

			return list;
		}

		private static MetarTafInfo GetMetarTafFromDocuments(String icao, XmlDocument metarDocument, XmlDocument tafDocument) {
			XmlNode metarNode = metarDocument.SelectSingleNode(String.Format("/metars/metar[@id='{0}']", icao));
			XmlNode tafNode = tafDocument.SelectSingleNode(String.Format("/tafs/taf[@id='{0}']", icao));

			MetarTafInfo info = new MetarTafInfo();

			if (metarNode != null) {
				info.Metar = ParseMetar(metarNode.Attributes["report"].InnerText, icao);
			}

			if (tafNode != null) {
				info.Taf = new Taf() { Raw = tafNode.Attributes["report"].InnerText  };
			}

			return info;
		}

		private static Metar ParseMetar(String raw, String icao) {
			Metar metar = new Metar() { Raw = raw, ICAO = icao };
			
			Match altimeterMatch = Constants.MetarAltimeterRegex.Match(raw);
			if (altimeterMatch.Success) {
				Int32 qnh = Int32.Parse(altimeterMatch.Groups[1].Value);
				metar.Altimeter = new Pressure(Pressure.Unit.hPa, qnh);
				raw = raw.Substring(0, altimeterMatch.Index + altimeterMatch.Length);
			}

			metar.Wind = new Wind();
			Match windMatch = Constants.MetarWindRegex.Match(raw);
			if (windMatch.Success) {
				if (windMatch.Groups[1].Value == "VRB") {
					metar.Wind.Variable = true;
				}
				else {
					metar.Wind.Direction = Int32.Parse(windMatch.Groups[1].Value);
				}

				metar.Wind.Speed = Int32.Parse(windMatch.Groups[2].Value);
				if (windMatch.Groups[3].Success) {
					metar.Wind.GustSpeed = Int32.Parse(windMatch.Groups[3].Value);
				}
			}

			Match visibilityMatch = Constants.MetarVisibilityRegex.Match(raw);
			if (visibilityMatch.Success) {
				Int32 kilometers = Int32.Parse(visibilityMatch.Groups[1].Value);
				metar.Visibility = new Distance(Distance.Unit.Kilometers, kilometers);
			}

			Match temperatureDewpointMatch = Constants.MetarTemperatureDewpointRegex.Match(raw);
			if (temperatureDewpointMatch.Success) {
				metar.Temperature = Int32.Parse(temperatureDewpointMatch.Groups[1].Value);
				metar.Dewpoint = Int32.Parse(temperatureDewpointMatch.Groups[2].Value);
			}

			MatchCollection cloudMatches = Constants.MetarCloudsRegex.Matches(raw);
			foreach (Match cloudMatch in cloudMatches) {
				Clouds clouds = new Clouds() {
					Coverage = GetSkyCoverage(cloudMatch.Groups[1].Value)
				};

				if (cloudMatch.Groups[2].Success) {
					if (cloudMatch.Value != "CAVOK") {
						clouds.HeightAboveGround = Int32.Parse(cloudMatch.Groups[2].Value);
					}
				}
			}

			return metar;
		}

		private static SkyCoverage GetSkyCoverage(String raw) {
			switch (raw) {
				case "FEW": return SkyCoverage.Few;
				case "SCT": return SkyCoverage.Scattered;
				case "BKN": return SkyCoverage.Broken;
				case "OVC": return SkyCoverage.Overcast;
				case "CAVOK": return SkyCoverage.CAVOK;
				default:
				case "NSC": return SkyCoverage.NoSignificantCloud;
			}
		}

		public void ShowConfiguration() {
			new SettingsForm().ShowDialog();
		}
	}
}
