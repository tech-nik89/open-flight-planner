using FlightPlanner.Common;
using FlightPlanner.Units;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FlightPlanner.DwdLuftsportbericht {
	class UpperWindParser {

		private readonly String _Report;
		private readonly String[] _Lines;

		private static readonly Regex _WindRegex = new Regex(@"((\d{4}) FT AMSL|FL(\d{3})) +(\d{3}) */ +(\d+) +KT", RegexOptions.IgnoreCase);
		private static readonly Regex _GaforAreaRegex = new Regex(@"GAFOR-Gebiete +(\d{2})-(\d{2})(?: +und +(\d{2})-(\d{2}))?:", RegexOptions.IgnoreCase);

		public UpperWindParser(String report) {
			_Report = report;

			if (_Report.Contains("\r\n")) {
				_Lines = _Report.Split(new String[] { "\r\n" }, StringSplitOptions.None);
			}
			else {
				_Lines = _Report.Split(new String[] { "\n" }, StringSplitOptions.None);
			}
		}

		public Boolean Parse(Dictionary<Int32, Dictionary<Altitude, Wind>> upperWind) {
			
			Int32[] startAreas = new Int32[0];
			Int32[] endAreas = new Int32[0];

			foreach (String line in _Lines) {
				Match areaMatch = _GaforAreaRegex.Match(line);
				Match windMatch = _WindRegex.Match(line);

				if (areaMatch.Success) {
					GetAreas(areaMatch, out startAreas, out endAreas);
				}
				else if (windMatch.Success && startAreas.Length > 0 && endAreas.Length > 0) {
					Group amslGroup = windMatch.Groups[2];
					Group flGroup = windMatch.Groups[3];
					Group directionGroup = windMatch.Groups[4];
					Group speedGroup = windMatch.Groups[5];

					Altitude altitude = null;
					if (amslGroup.Success) {
						Int32 feet = 0;
						if (Int32.TryParse(amslGroup.Value, out feet)) {
							altitude = new Altitude(Altitude.Unit.Feet, feet);
						}
					}
					else if (flGroup.Success) {
						Int32 fl = 0;
						if (Int32.TryParse(flGroup.Value, out fl)) {
							altitude = new FlightLevel(fl);
						}
					}

					if (altitude == null) {
						continue;
					}

					Int32 direction = 0;
					Int32 speed = 0;

					if (!Int32.TryParse(directionGroup.Value, out direction) || !Int32.TryParse(speedGroup.Value, out speed)) {
						continue;
					}

					Wind wind = new Wind() { Direction = direction, Speed = speed };

					for (Int32 i = 0; i < startAreas.Length; i++) {
						for (Int32 j = startAreas[i]; j <= endAreas[i]; j++) {
							if (!upperWind.ContainsKey(j)) {
								upperWind.Add(j, new Dictionary<Altitude, Wind>());
							}

							upperWind[j].Add(altitude, wind);
						}
					}
				}
			}

			return true;
		}

		private static void GetAreas(Match areaMatch, out Int32[] startAreas, out Int32[] endAreas) {
			if (areaMatch.Groups[3].Success) {
				startAreas = new Int32[2];
				endAreas = new Int32[2];

				startAreas[0] = Int32.Parse(areaMatch.Groups[1].Value);
				endAreas[0] = Int32.Parse(areaMatch.Groups[2].Value);

				startAreas[1] = Int32.Parse(areaMatch.Groups[3].Value);
				endAreas[1] = Int32.Parse(areaMatch.Groups[4].Value);
			}
			else {
				startAreas = new Int32[1];
				endAreas = new Int32[1];

				startAreas[0] = Int32.Parse(areaMatch.Groups[1].Value);
				endAreas[0] = Int32.Parse(areaMatch.Groups[2].Value);
			}
		}
	}
}
