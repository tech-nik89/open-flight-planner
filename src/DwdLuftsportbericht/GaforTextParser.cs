using FlightPlanner.Weather.Gafor;
using System;
using System.Text.RegularExpressions;

namespace FlightPlanner.DwdLuftsportbericht {
	class GaforTextParser {

		private readonly String _Report;

		public GaforTextParser(String report) {
			_Report = report;
		}

		private static readonly Regex _StatusRegex = new Regex(@"(\d{2})(?:/(\d{2}))? ((?:C|O|D1|M2|D3|D4|M5|M6|M7|M8|X)[A-Z ]*),((?:C|O|D1|M2|D3|D4|M5|M6|M7|M8|X)[A-Z ]*),((?:C|O|D1|M2|D3|D4|M5|M6|M7|M8|X)[A-Z ]*)", RegexOptions.IgnoreCase);
		private static readonly Regex _ValidityRegex = new Regex(@"von (\d{2}) bis (\d{2}) UTC", RegexOptions.IgnoreCase);

		public Boolean Parse(GaforInfo gafor) {
			if (String.IsNullOrWhiteSpace(_Report)) {
				return false;
			}

			gafor.Forecasts = new String[3];
			DateTime today = DateTime.UtcNow;

			MatchCollection statusMatches = _StatusRegex.Matches(_Report);
			Match validityMatch = _ValidityRegex.Match(_Report);

			foreach (Match statusMatch in statusMatches) {
				Int32 area = 0;
				if (!Int32.TryParse(statusMatch.Groups[1].Value, out area)) {
					continue;
				}

				GaforForecast[] forecasts = new GaforForecast[3];

				for (Int32 i = 0; i < 3; i++) {
					GaforAreaStatus areaStatus = GaforAreaStatus.Unknown;

					Group group = statusMatch.Groups[i + 3];
					String[] parts = group.Value.Split(' ');

					Enum.TryParse<GaforAreaStatus>(parts[0].Trim(), out areaStatus);

					forecasts[i] = new GaforForecast() {
						Status = areaStatus,
						Info = group.Value.ToString()
					};
				}

				gafor.Areas.Add(area, forecasts);

				if (statusMatch.Groups[2].Success) {
					Int32 toArea = 0;
					if (Int32.TryParse(statusMatch.Groups[2].Value, out toArea)) {
						for (Int32 i = area + 1; i <= toArea; i++) {
							gafor.Areas.Add(i, forecasts);
						}
					}
				}
			}

			if (validityMatch.Success) {
				Int32 fromHour = 0;
				Int32 toHour = 0;

				if (Int32.TryParse(validityMatch.Groups[1].Value, out fromHour)) {
					gafor.ValidFrom = new DateTime(today.Year, today.Month, today.Day, fromHour, 0, 0);
				}

				if (Int32.TryParse(validityMatch.Groups[2].Value, out toHour)) {
					gafor.ValidTo = new DateTime(today.Year, today.Month, today.Day, toHour, 0, 0);
				}
			}
			
			TimeSpan timeSpan = gafor.ValidTo - gafor.ValidFrom;
			Int32 step = timeSpan.Hours / gafor.Forecasts.Length;

			for(Int32 i = 0; i < gafor.Forecasts.Length; i++) {
				DateTime from = gafor.ValidFrom.AddHours(step * i);
				DateTime to = from.AddHours(step);
				gafor.Forecasts[i] = String.Format("{0} to {1} UTC", from.ToShortTimeString(), to.ToShortTimeString());
			}

			return true;
		}
	}
}
