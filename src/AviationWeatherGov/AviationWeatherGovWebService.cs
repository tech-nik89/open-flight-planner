using FlightPlanner.Briefing;
using FlightPlanner.Common;
using FlightPlanner.Plugins;
using FlightPlanner.Units;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Xml;

namespace FlightPlanner.Weather.MetarTaf {
	public class AviationWeatherGovWebService : IMetarWeatherSource {

		public String Name {
			get {
				return "aviationweather.gov Metar Web Service";
			}
		}

		private static readonly String _BaseUrl = @"https://aviationweather.gov/adds/dataserver_current/";
		private static readonly IFormatProvider _FormatProvider = new CultureInfo("en-US");

		private const String DataSourceMetar = "metars";
		private const String DataSourceTaf = "tafs";

		private WebClient _WebClient;

		private WebClient WebClient {
			get {
				if (_WebClient == null) {
					_WebClient = new WebClient();
				}

				return _WebClient;
			}
		}

		public Boolean Configurable { get; private set; } = false;

		public Dictionary<String, Object> Configuration {
			get {
				throw new NotSupportedException();
			}
		}

		public List<MetarTafInfo> RetrieveRouteWeatherInfo(FlightPlan flightPlan) {
			List<MetarTafInfo> list = new List<MetarTafInfo>();
			
			try {
				String url = CreateUrl(flightPlan.Route, DataSourceMetar);
				String xml = WebClient.DownloadString(url);

				XmlDocument document = new XmlDocument();
				document.LoadXml(xml);

				XmlNodeList nodes = document.SelectNodes("/response/data/METAR");

				foreach (XmlNode node in nodes) {
					Metar metar = ParseMetar(node);

					if (list.SingleOrDefault(m => m.Metar.ICAO == metar.ICAO) == null) {
						list.Add(new MetarTafInfo() { Metar = metar });
					}
				}
			}
			catch (Exception) {
			}

			try {
				String url = CreateUrl(flightPlan.Route, DataSourceTaf);
				String xml = WebClient.DownloadString(url);

				XmlDocument document = new XmlDocument();
				document.LoadXml(xml);

				XmlNodeList nodes = document.SelectNodes("/response/data/TAF");

				foreach (XmlNode node in nodes) {
					Taf taf = ParseTaf(node);
					MetarTafInfo info = list.SingleOrDefault(m => m.Metar.ICAO == taf.ICAO);

					if (info != null && info.Taf == null) {
						info.Taf = taf;
					}
				}
			}
			catch (Exception) {
			}

			return list;
		}

		private static Metar ParseMetar(XmlNode node) {
			Metar metar = new Metar();

			metar.Raw = GetStringValue(node, "raw_text");
			metar.ICAO = GetStringValue(node, "station_id");
			metar.ObservationTime = GetDateTimeValue(node, "observation_time");
			
			metar.Temperature = GetDoubleValue(node, "temp_c");
			metar.Dewpoint = GetDoubleValue(node, "dewpoint_c");
			
			metar.Wind = new Wind() {
				Direction = GetInt32Value(node, "wind_dir_degrees"),
				Speed = GetInt32Value(node, "wind_speed_kt"),
				GustSpeed = GetInt32Value(node, "wind_gust_kt")
			};

			metar.Visibility = new Distance(Distance.Unit.StatuteMiles, GetDoubleValue(node, "visibility_statute_mi"));
			metar.Altimeter = new Pressure(Pressure.Unit.InHg, GetDoubleValue(node, "altim_in_hg"));

			metar.Clouds = GetClouds(node);
			
			FlightCategory category = FlightCategory.Unknown;
			Enum.TryParse<FlightCategory>(GetStringValue(node, "flight_category"), out category);
			metar.Category = category;

			return metar;
		}

		private static Taf ParseTaf(XmlNode node) {
			Taf taf = new Taf();

			taf.Raw = GetStringValue(node, "raw_text");
			taf.ICAO = GetStringValue(node, "station_id");

			taf.ValidFrom = GetDateTimeValue(node, "valid_time_from");
			taf.ValidTo = GetDateTimeValue(node, "valid_time_to");

			return taf;
		}

		private static List<Clouds> GetClouds(XmlNode node) {
			XmlNodeList nodes = node.SelectNodes("sky_condition");
			List<Clouds> list = new List<Clouds>();

			foreach(XmlNode n in nodes) {
				Clouds clouds = new Clouds();

				String coverage = n.Attributes["sky_cover"].InnerText;
				
				switch(coverage.ToLower()) {
					case "few":
						clouds.Coverage = SkyCoverage.Few;
						break;
					case "sct":
						clouds.Coverage = SkyCoverage.Scattered;
						break;
					case "bkn":
						clouds.Coverage = SkyCoverage.Broken;
						break;
					case "ovc":
						clouds.Coverage = SkyCoverage.Overcast;
						break;
					case "nsc":
						clouds.Coverage = SkyCoverage.NoSignificantCloud;
						break;
					case "cavok":
						clouds.Coverage = SkyCoverage.CAVOK;
						break;
				}

				Int32 height = -1;
				if (n.Attributes["cloud_base_ft_agl"] != null) {
					Int32.TryParse(n.Attributes["cloud_base_ft_agl"].InnerText, out height);
				}

				clouds.HeightAboveGround = height;

				list.Add(clouds);
			}

			return list;
		}

		private static String GetStringValue(XmlNode node, String key) {
			XmlNode child = node.SelectSingleNode(key);

			if (child == null) {
				return String.Empty;
			}

			return child.InnerText;
		}

		private static Double GetDoubleValue(XmlNode node, String key) {
			XmlNode child = node.SelectSingleNode(key);
			Double value = Double.NaN;

			if (child != null) {
				Double.TryParse(child.InnerText, NumberStyles.Number, _FormatProvider, out value);
			}

			return value;
		}

		private static Int32 GetInt32Value(XmlNode node, String key) {
			XmlNode child = node.SelectSingleNode(key);
			Int32 value = 0;

			if (child != null) {
				Int32.TryParse(child.InnerText, NumberStyles.Number, _FormatProvider, out value);
			}

			return value;
		}

		private static DateTime GetDateTimeValue(XmlNode node, String key) {
			DateTime dateTime = DateTime.MinValue;
			XmlNode child = node.SelectSingleNode(key);

			if (child != null) {
				DateTime.TryParse(child.InnerText, _FormatProvider, DateTimeStyles.AssumeUniversal, out dateTime);
			}

			return dateTime;
		}

		private static String CreateUrl(Route route, String dataSource) {
			// httpparam?dataSource=metars&requestType=retrieve&format=xml&flightPath=2;EDDS;EDDN&hoursBeforeNow=3

			const Int32 radius = 30;
			const Int32 hoursBeforeNow = 2;
			const String routeBase = "httpparam?dataSource={3}&requestType=retrieve&format=xml&flightPath={0};{1}&hoursBeforeNow={2}";

			List<String> coordinates = new List<String>();
			foreach (Waypoint waypoint in route.Waypoints) {
				coordinates.Add(String.Format("{0},{1}", waypoint.Longitude.ToString("0.000", _FormatProvider), waypoint.Latitude.ToString("0.000", _FormatProvider)));
			}

			String strCoordinates = String.Join(";", coordinates);

			return String.Concat(_BaseUrl, String.Format(routeBase, radius, strCoordinates, hoursBeforeNow, dataSource));
		}

		public void ShowConfiguration() {
			throw new NotSupportedException();
		}
	}
}
