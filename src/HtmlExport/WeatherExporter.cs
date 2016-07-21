using FlightPlanner.Briefing;
using FlightPlanner.Weather.Gafor;
using FlightPlanner.Weather.MetarTaf;
using Svg;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace HtmlExport {
	class WeatherExporter {

		private static readonly ImageFormat _ImageFormat = ImageFormat.Png;

		public static void AddWeatherBriefing(StringBuilder document, FlightPlan flightPlan) {
			try {
				WeatherBriefing weather = WeatherBriefing.Create(flightPlan);

				document.AppendLine("<h1>METAR / TAF</h1>");

				foreach (var item in weather.MetarTaf) {
					AddMetarTaf(document, item);
				}

				AddGafor(document, weather);
				AddTextReport(document, weather);

				AddSignificantWeather(document, weather);
			}
			catch (Exception e) {
				document.Append("<p>Error: ");
				document.Append(e.Message);
				document.AppendLine("</p>");
			}
		}

		private static void AddTextReport(StringBuilder document, WeatherBriefing briefing) {
			if (String.IsNullOrWhiteSpace(briefing.TextReport)) {
				return;
			}

			String report = briefing.TextReport.Replace("\r\n", "<br />\r\n");

			document.AppendLine("<h1>Weather Report</h1>");
			document.AppendLine("<p>");
			document.AppendLine(report);
			document.AppendLine("</p>");
		}

		private static void AddSignificantWeather(StringBuilder document, WeatherBriefing briefing) {
			if (briefing.SignificantWeather == null) {
				return;
			}

			document.AppendLine("<h1>Significant Weather</h1>");

			document.Append("<img src=\"data:image/");
			document.Append(_ImageFormat.ToString().ToLower());
			document.Append(";base64,");
			document.Append(BitmapToBase64(briefing.SignificantWeather));
			document.Append("\" alt=\"SWC Image\"");
			document.Append(" style=\"width:");
			document.Append("100%");
			document.AppendLine("\" />");
		}

		private static void AddMetarTaf(StringBuilder document, MetarTafInfo info) {
			if (info.Metar == null && info.Taf == null) {
				return;
			}

			document.Append("<h2>");
			document.Append(info.Metar.ICAO);
			document.AppendLine("</h2>");

			if (info.Metar != null) {
				document.Append("<p>");
				document.Append(info.Metar.Raw);
				document.AppendLine("</p>");
			}

			if (info.Taf != null) {
				document.Append("<p>");
				document.Append(info.Taf.Raw);
				document.AppendLine("</p>");
			}
		}

		private static void AddGafor(StringBuilder document, WeatherBriefing briefing) {
			if (briefing.Gafor == null) {
				return;
			}

			document.AppendLine("<h1>GAFOR</h1>");
			document.AppendLine("<div>");

			String path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gafor.svg");
			SvgDocument svg = SvgDocument.Open(path);
			GaforInfo gafor = briefing.Gafor;

			for (Int32 i = 0; i < gafor.Forecasts.Length; i++) {
				document.AppendLine("<div class=\"left\">");
				document.Append("<h2>");
				document.Append(gafor.Forecasts[i]);
				document.AppendLine("</h2>");

				Bitmap image = GenerateGaforImage(svg, gafor, i);

				document.Append("<img src=\"data:image/");
				document.Append(_ImageFormat.ToString().ToLower());
				document.Append(";base64,");
				document.Append(BitmapToBase64(image));
				document.Append("\" alt=\"");
				document.Append(gafor.Forecasts[i]);
				document.Append("\" style=\"width:");
				document.Append("65mm");
				document.AppendLine("\" />");

				document.AppendLine("</div>");
			}

			document.AppendLine("<div>");
			document.AppendLine("<div class=\"clear\">&nbsp;</div>");
		}

		private static Bitmap GenerateGaforImage(SvgDocument svg, GaforInfo gafor, Int32 index) {
			foreach (var item in gafor.Areas) {
				if (item.Value.Length < index) {
					continue;
				}

				GaforForecast forecast = item.Value[index];
				SvgPath element = svg.GetElementById(String.Format("gafor_{0:00}", item.Key)) as SvgPath;

				if (element != null) {
					element.Content = forecast.Info;
					element.Fill = new SvgColourServer(Color.FromArgb(GaforInfo.ResolveStatusColor(forecast.Status)));
				}
			}

			return svg.Draw();
		}

		private static String BitmapToBase64(Image image) {
			String base64 = null;

			using (MemoryStream memory = new MemoryStream()) {
				image.Save(memory, _ImageFormat);
				base64 = Convert.ToBase64String(memory.ToArray());
				memory.Close();
			}

			return base64;
		}
	}
}
