using FlightPlanner.Common;
using FlightPlanner.Interfaces;
using FlightPlanner.Units;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.IO;

namespace FlightPlanner.Parser {
	public class Welt2kParser : Parser, IWaypointParser {

		public Welt2kParser(FileInfo file)
			: base(file) {
		}

		public Welt2kParser(String input)
			: base(input) {
		}

		public IEnumerable<Waypoint> GetWaypoints() {
			return Parse(Lines);
		}

		private List<Waypoint> Parse(String[] lines) {
			List<Waypoint> waypoints = new List<Waypoint>();

			foreach (String line in lines) {
				
				if (line.Length != 64 || line.StartsWith("$")) {
					continue;
				}

				String gpsInput = line.Substring(0, 6);
				String name = line.Substring(7, 16).Trim();
				Coordinate coordinate = ParseCoordinate(line.Substring(45, 15));
				Country country = ParseCountry(line.Substring(60, 2));

				if (gpsInput.EndsWith("1") && line.Substring(23, 1) == "#") {
					String icaoCode = line.Substring(24, 4);
					Single frequency = ParseFrequency(line.Substring(36, 5));
					Elevation elevation = ParseElevation(line.Substring(42, 3));

					Runway.SurfaceType runwaySurface = ParseRunwaySurface(line.Substring(28, 1));
					Int32 length = ParseInt(line.Substring(29, 3)) * 10;
					Int32 direction1 = ParseInt(line.Substring(32, 2));
					Int32 direction2 = ParseInt(line.Substring(34, 2));

					List<Runway> runways = new List<Runway>();
					runways.Add(new Runway(direction1, length, runwaySurface));

					if (!AreRunwayDirectionsEqual(direction1, direction2)) {
						runways.Add(new Runway(direction2, length, runwaySurface));
					}

					Airfield airfield = new Airfield(name, icaoCode, coordinate, elevation, runways.ToArray(), new Frequency(frequency), country);
					waypoints.Add(airfield);
				}
			}

			return waypoints;
		}

		private Elevation ParseElevation(String input) {
			Int32 elevation = 0;
			Int32.TryParse(input.Trim(), out elevation);

			return new Elevation(Altitude.Unit.Meters, elevation);
		}

		private static Boolean AreRunwayDirectionsEqual(Int32 direction1, Int32 direction2) {
			Int32 diff = Math.Abs(direction1 - direction2);
			return diff == 18;
		}

		private static Int32 ParseInt(String input) {
			Int32 value = 0;
			Int32.TryParse(input.Trim(), out value);
			return value;
		}

		private static Single ParseFrequency(String input) {
			Single value = 0;

			if (input.Length == 5) {
				input = String.Format("{0}.{1}", input.Substring(0, 3), input.Substring(3, 2));
				Single.TryParse(input, System.Globalization.NumberStyles.Number, ParserFormatProvider, out value);
			}

			return value;
		}

		private static Runway.SurfaceType ParseRunwaySurface(String input) {
			
			switch (input) {
				case "A": return Runway.SurfaceType.Asphalt;
				case "C": return Runway.SurfaceType.Concrete;
				case "L": return Runway.SurfaceType.Loam;
				case "S": return Runway.SurfaceType.Sand;
				case "Y": return Runway.SurfaceType.Clay;
				case "G": return Runway.SurfaceType.Grass;
				case "V": return Runway.SurfaceType.Gravel;
				case "D": return Runway.SurfaceType.Dirt;
			}

			return Runway.SurfaceType.Undefined;
		}

		private static Coordinate ParseCoordinate(String input) {
			Double latitude = ParseSingleCoordinate(input.Substring(0, 7));
			Double longitude = ParseSingleCoordinate(input.Substring(7, 8));
			return new Coordinate(latitude, longitude);
		}

		private static Double ParseSingleCoordinate(String input) {
			Double degrees = 0, minutes = 0, seconds = 0;
			Boolean positive = false;

			if (input.StartsWith("N", StringComparison.InvariantCultureIgnoreCase) || input.StartsWith("E", StringComparison.InvariantCultureIgnoreCase)) {
				positive = true;
			}

			if (input.Length == 7) {
				Double.TryParse(input.Substring(1, 2), out degrees);
				Double.TryParse(input.Substring(3, 2), out minutes);
				Double.TryParse(input.Substring(5, 2), out seconds);
			}
			else if (input.Length == 8) {
				Double.TryParse(input.Substring(1, 3), out degrees);
				Double.TryParse(input.Substring(4, 2), out minutes);
				Double.TryParse(input.Substring(6, 2), out seconds);
			}
			
			degrees += minutes / 60;
			degrees += seconds / 3600;

			if (!positive) {
				degrees *= -1;
			}

			return degrees;
		}

		private static Country ParseCountry(String input) {

			switch (input) {
                case "AL": return Country.Albania;
                case "AT": return Country.Austria;
                case "AR": return Country.Argentina;
                case "AU": return Country.Australia;
                case "AF": return Country.Afghanistan;
                case "BA": return Country.Bosnia;
                case "BE": return Country.Belgium;
                case "BG": return Country.Bulgaria;
                case "BW": return Country.Botswana;
                case "BR": return Country.Brasilia;
                case "CA": return Country.Canada;
                case "CH": return Country.Swiss;
                case "CL": return Country.Chile;
                //case "CH": return Country.China;
                case "CY": return Country.Cyprus;
                case "CZ": return Country.Czechia;
                case "DE": return Country.Germany;
                case "DK": return Country.Denmark;
                case "DO": return Country.DominicanRepublic;
                case "DZ": return Country.Algeria;
                case "EE": return Country.Estonia;
                case "ES": return Country.Spain;
                case "FR": return Country.France;
                case "FI": return Country.Finland;
                case "GR": return Country.Greece;
                case "HR": return Country.Croatia;
                case "HU": return Country.Hungary;
                case "SD": return Country.Sudan;
                case "IE": return Country.Ireland;
                case "IQ": return Country.Iraq;
                case "IK": return Country.Iran;
                case "IN": return Country.India;
                case "IL": return Country.Israel;
                case "IT": return Country.Italia;
                case "JP": return Country.Japan;
                case "LU": return Country.Luxembourg;
                case "LI": return Country.Lebanon;
                case "LK": return Country.SriLanka;
                case "LT": return Country.Lithuania;
                case "LV": return Country.Latvia;
                case "LY": return Country.Libya;
                case "MA": return Country.Morocco;
                case "MN": return Country.Mongolia;
                case "MK": return Country.Macedonia;
                case "MT": return Country.Malta;
                case "MW": return Country.Malawi;
                case "MD": return Country.Moldavia;
                case "MM": return Country.Myanmar;
                case "MX": return Country.Mexico;
                case "MZ": return Country.Mozambique;
                case "NA": return Country.Namibia;
                case "NL": return Country.Netherlands;
                case "NO": return Country.Norway;
                case "NZ": return Country.NewZealand;
                case "OM": return Country.Dubai;
                case "PK": return Country.Pakistan;
                case "PL": return Country.Poland;
                case "PT": return Country.Portugal;
                case "ID": return Country.Indonesia;
                case "RO": return Country.Romania;
                case "RU": return Country.Russia;
                case "SE": return Country.Sweden;
                case "ZM": return Country.Sambia;
                case "EG": return Country.Egypt;
                case "SK": return Country.Slovakia;
                case "SI": return Country.Slovenia;
                case "SY": return Country.Syria;
                case "TH": return Country.Thailand;
                case "TR": return Country.Turkey;
                case "TN": return Country.Tunisia;
                case "GB": return Country.England;
                case "US": return Country.USA;
                case "RS": return Country.Serbia;
                case "ZA": return Country.SouthAfrica;
                case "ZE": return Country.Zimbabwe;
			}

			return Country.Undefined;
		}
	}
}
