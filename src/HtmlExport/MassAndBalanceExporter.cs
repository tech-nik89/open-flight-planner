using FlightPlanner.Briefing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace HtmlExport {
	class MassAndBalanceExporter {

		private static readonly ImageFormat _ImageFormat = ImageFormat.Png;

		public static void AddMassAndBalance(StringBuilder document, FlightPlan flightPlan) {
			MassAndBalance mab = MassAndBalance.Create(flightPlan);

			document.AppendLine("<div>");

			document.AppendLine("<div class=\"left\">");
			AddFuel(document, mab);
			document.AppendLine("</div>");

			document.AppendLine("<div class=\"left\">");
			AddMass(document, mab);
			document.AppendLine("</div>");

			document.AppendLine("<div class=\"left\">");
			AddCenterOfGravity(document, flightPlan, mab);
			document.AppendLine("</div>");

			document.AppendLine("<div class=\"clear\">&nbsp;</div>");
			document.AppendLine("</div>");
		}

		private static void AddCenterOfGravity(StringBuilder document, FlightPlan flightPlan, MassAndBalance mab) {
			document.AppendLine("<h1>Center Of Gravity</h1>");
			
			Chart chart = new Chart();
			chart.Height = 250;
			chart.Width = 380;
			chart.Series.Clear();

			ChartArea chartArea = new ChartArea("Mass and Balance");
			chartArea.AxisX.MajorGrid.Enabled = false;
			chartArea.AxisY.MajorGrid.Enabled = false;
			chartArea.AxisX.LabelStyle.Format = "{0:0.000}";
			chartArea.AxisY.LabelStyle.Format = "{0:0}";
			chart.ChartAreas.Add(chartArea);
			
			Series limits = new Series("Center of gravity limits");
			limits.ChartType = SeriesChartType.Line;
			limits.Color = Color.DarkGray;
			limits.MarkerStyle = MarkerStyle.Square;

			List<System.Windows.Point> points = flightPlan.Aircraft.CenterOfGravityLimits.GetLimitPoints();
			foreach (System.Windows.Point point in points) {
				limits.Points.Add(new DataPoint(point.X, point.Y));
			}

			chart.Series.Add(limits);

			Series centerOfGravity = new Series();
			centerOfGravity.ChartType = SeriesChartType.Line;
			centerOfGravity.Color = Color.DarkRed;
			centerOfGravity.MarkerStyle = MarkerStyle.Cross;
			centerOfGravity.MarkerSize = 10;

			centerOfGravity.Points.Add(new DataPoint(mab.TakeOff.Arm, mab.TakeOff.Mass));
			centerOfGravity.Points.Add(new DataPoint(mab.Landing.Arm, mab.Landing.Mass));

			chart.Series.Add(centerOfGravity);

			using (MemoryStream stream = new MemoryStream()) {
				chart.SaveImage(stream, ChartImageFormat.Png);

				document.Append("<img src=\"data:image/");
				document.Append(_ImageFormat.ToString().ToLower());
				document.Append(";base64,");
				document.Append(Convert.ToBase64String(stream.ToArray()));
				document.Append("\" alt=\"");
				document.Append("COG");
				document.Append("\" height=\"");
				document.Append(chart.Height);
				document.Append("\" width=\"");
				document.Append(chart.Width);
				document.AppendLine("\" />");
			}
		}

		private static void AddMass(StringBuilder document, MassAndBalance mab) {
			document.AppendLine("<h1>Mass</h1>");

			document.AppendLine("<table class=\"mass\" border=\"0\">");

			AddMassItem(document, mab.Empty);
			AddMassItem(document, mab.DryOperating);
			AddMassItem(document, mab.Ramp);
			AddMassItem(document, mab.TakeOff);
			AddMassItem(document, mab.Landing);

			document.AppendLine("</table>");
		}

		private static void AddFuel(StringBuilder document, MassAndBalance mab) {
			document.AppendLine("<h1>Fuel</h1>");

			document.AppendLine("<table class=\"fuel\" border=\"0\">");

			AddFuelItem(document, "Ramp", mab.RampFuel);
			AddFuelItem(document, "Startup and Taxi", mab.StartupAndTaxiFuel);
			AddFuelItem(document, "Take Off", mab.TakeOffFuel, true);
			AddFuelItem(document, "Trip Fuel", mab.TripFuel);
			AddFuelItem(document, "Landing", mab.LandingFuel, true);
			AddFuelItem(document, "Alternate", mab.AlternateFuel);
			AddFuelItem(document, "Final Reserve", mab.FinalReserveFuel);
			AddFuelItem(document, "Extra Fuel", mab.ExtraFuel, true);

			document.AppendLine("</table>");
		}

		private static void AddMassItem(StringBuilder document, MassAndBalanceItem item) {
			document.AppendLine("<tr>");

			document.Append("<td>");
			document.Append(item.Name);
			document.Append("</td>");

			document.Append("<td>");
			document.Append(Math.Round(item.Mass, 1).ToString("0.0"));
			document.Append("</td>");

			document.AppendLine("</tr>");
		}

		private static void AddFuelItem(StringBuilder document, String name, Double fuel, Boolean colorize = false) {
			document.Append("<tr");

			if (colorize) {
				document.Append(" style=\"");
				if (fuel < 0) {
					document.Append(GetColorAsHex(Color.DarkRed));
				}
				else if (fuel > 0) {
					document.Append(GetColorAsHex(Color.DarkGreen));
				}
				document.Append("\"");
			}

			document.AppendLine(">");

			String value = Math.Round(fuel, 1).ToString("0.0");

			document.Append("<td>");
			document.Append(name);
			document.Append("</td>");
			document.Append("<td>");
			document.Append(value);
			document.Append("</td>");

			document.AppendLine("</tr>");
		}

		private static String GetColorAsHex(Color color) {
			return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
		}
	}
}
