using FlightPlanner.Common;
using FlightPlanner.DwdLuftsportbericht;
using FlightPlanner.Plugins;
using FlightPlanner.Units;
using FlightPlanner.Weather.Gafor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml;

namespace FlightPlanner.PCMET {
	public class EnrouteWeatherSource : IEnrouteWeatherSource {

		public Boolean Configurable { get; private set; } = true;

		public Dictionary<String, Object> Configuration {
			get {
				return Constants.Configuration;
			}
		}

		public String Name {
			get {
				return Constants.DataSourceName;
			}
		}

		public GaforInfo GetGafor() {
			String gaforXml = Connection.DownloadGafor();
			XmlDocument document = new XmlDocument();
			document.LoadXml(gaforXml);

			XmlNode validFromNode = document.SelectSingleNode("/gafor/header/valid_fr");
			XmlNode validToNode = document.SelectSingleNode("/gafor/header/valid_to");

			GaforInfo gafor = new GaforInfo();

			gafor.ValidFrom = DateTime.Parse(validFromNode.InnerText).ToUniversalTime();
			gafor.ValidTo = DateTime.Parse(validToNode.InnerText).ToUniversalTime();

			TimeSpan diff = gafor.ValidTo - gafor.ValidFrom;
			Int32 hoursPerInterval = (Int32)diff.TotalHours / Constants.GaforIntervalCount;

			gafor.Forecasts = new String[Constants.GaforIntervalCount];
			for(Int32 i = 0; i < Constants.GaforIntervalCount; i++) {
				DateTime from = gafor.ValidFrom.AddHours(i * hoursPerInterval);
				DateTime to = from.AddHours(hoursPerInterval);
				gafor.Forecasts[i] = String.Format("{0} to {1} UTC", from.ToShortTimeString(), to.ToShortTimeString());
			}

			XmlNodeList areaNodes = document.SelectNodes("/gafor/area");
			foreach (XmlNode areaNode in areaNodes) {
				Int32 areaId = Int32.Parse(areaNode.Attributes["id"].InnerText);
				XmlNodeList intervalNodes = areaNode.SelectNodes("interval");
				gafor.Areas.Add(areaId, new GaforForecast[intervalNodes.Count]);

				for(Int32 i = 0; i < intervalNodes.Count; i++) {
					XmlNode intervalNode = intervalNodes[i];

					String info = String.Empty;
					GaforAreaStatus status = GaforAreaStatus.Unknown;

					Enum.TryParse<GaforAreaStatus>(intervalNode.SelectSingleNode("gaforIndex").InnerText, out status);

					XmlNode wwNode = intervalNode.SelectSingleNode("ww");
					if (wwNode != null) {
						foreach (XmlNode child in wwNode.ChildNodes) {
							info += child.InnerText + " ";
						}
					}

					gafor.Areas[areaId][i] = new GaforForecast() { Status = status, Info = info.Trim() };
				}
			}
			
			return gafor;
		}

		public Image GetSignificantWeather() {
			return GetSignificantWeather(DateTime.UtcNow);
		}

		public Image GetSignificantWeather(DateTime flightTime) {
			Int32 hour = 0;

			for (hour = 3; hour <= 21; hour += 3) {
				if (hour > flightTime.Hour) {
					break;
				}
			}

			Byte[] buffer = Connection.DownloadSignificantWeather(hour);

			ImageConverter converter = new ImageConverter();
			return (Image)converter.ConvertFrom(buffer);
		}

		public Dictionary<Int32, Dictionary<Altitude, Wind>> GetUpperWind() {

			String report = GetTextReport();
			var dictionary = new Dictionary<Int32, Dictionary<Altitude, Wind>>();

			UpperWindParser parser = new UpperWindParser(report);
			parser.Parse(dictionary);

			return dictionary;
		}

		public String GetTextReport() {
			String gaforXml = Connection.DownloadGafor();
			XmlDocument document = new XmlDocument();
			document.LoadXml(gaforXml);

			StringBuilder report = new StringBuilder();

			XmlNodeList reportNodes = document.SelectNodes("/gafor/report/text");
			foreach (XmlNode reportNode in reportNodes) {
				report.AppendLine(reportNode.InnerText.Replace("\n", "\r\n"));
			}
			
			return report.ToString();
		}

		public void ShowConfiguration() {
			new SettingsForm().ShowDialog();
		}
	}
}
