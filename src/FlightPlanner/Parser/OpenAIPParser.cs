using FlightPlanner.Common;
using FlightPlanner.Interfaces;
using FlightPlanner.Units;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using FlightPlanner.Airspaces;
using FlightPlanner.Airspaces.Segments;
using System.Linq;

namespace FlightPlanner.Parser {
	public class OpenAIPParser : Parser, IWaypointParser, IAirspaceParser {

		private static readonly CultureInfo _Culture = new CultureInfo("en-US");
		private static readonly Char[] _Separator = new Char[] { ' ' };

		public OpenAIPParser(string input) : base(input) {
		}

		public OpenAIPParser(FileInfo file) : base(file) {
		}

		public IEnumerable<Airspace> GetAirspaces(IEnumerable<AirspaceClass> visibleAirspaces) {
			List<Airspace> airspaces = new List<Airspace>();

			XmlDocument document = new XmlDocument();
			document.LoadXml(FileContent);

			XmlNodeList xAirspaces = document.SelectNodes("/OPENAIP/AIRSPACES/ASP");
			foreach (XmlNode xAirspace in xAirspaces) {
				XmlAttribute xCategory = xAirspace.Attributes["CATEGORY"];
				if (xCategory == null) {
					continue;
				}

				XmlNode xCeiling = xAirspace.SelectSingleNode("ALTLIMIT_TOP");
				if (xCeiling == null) {
					continue;
				}

				XmlNode xFloor = xAirspace.SelectSingleNode("ALTLIMIT_BOTTOM");
				if (xFloor == null) {
					continue;
				}

				XmlNode xName = xAirspace.SelectSingleNode("NAME");
				if (xName == null) {
					continue;
				}

				XmlNode xGeometry = xAirspace.SelectSingleNode("GEOMETRY");
				if (xGeometry == null) {
					continue;
				}

				XmlNode xCountry = xAirspace.SelectSingleNode("COUNTRY");
				if (xCountry == null) {
					continue;
				}

				Airspace airspace = new Airspace();

				airspace.Class = ParseAirspaceClass(xCategory.InnerText);
				if (visibleAirspaces.Any() && !visibleAirspaces.Contains(airspace.Class)) {
					continue;
				}

				airspace.Name = xName.InnerText;
				airspace.Floor = ParseAltitude(xFloor);
				airspace.Ceiling = ParseAltitude(xCeiling);
				airspace.Segments.AddRange(GetAirspaceSegments(xGeometry));
				airspace.Country = ParseCountry(xCountry.InnerText);

				airspaces.Add(airspace);
			}

			return airspaces;
		}

		private static List<AirspaceSegment> GetAirspaceSegments(XmlNode node) {
			List<AirspaceSegment> segments = new List<AirspaceSegment>();
			XmlNodeList xPolygons = node.SelectNodes("POLYGON");

			foreach (XmlNode xPolygon in xPolygons) {
				String[] coordinates = xPolygon.InnerText.Split(',');

				foreach (String coordinate in coordinates) {
					String[] parts = coordinate.Split(_Separator, StringSplitOptions.RemoveEmptyEntries);
					if (parts.Length == 2) {
						Double latitude = Double.NaN;
						Double longitude = Double.NaN;

						if (!Double.TryParse(parts[0].Trim(), NumberStyles.Float, _Culture, out longitude)) {
							continue;
						}

						if (!Double.TryParse(parts[1].Trim(), NumberStyles.Float, _Culture, out latitude)) {
							continue;
						}

						segments.Add(new PolygonAirspaceSegment(new Coordinate(latitude, longitude)));
					}
				}
			}

			return segments;
		}

		private static AirspaceAltitude ParseAltitude(XmlNode node) {
			XmlAttribute xReference = node.Attributes["REFERENCE"];
			if (xReference == null) {
				return null;
			}

			XmlNode xAltitude = node.SelectSingleNode("ALT");
			if (xAltitude == null) {
				return null;
			}

			Int32 value = 0;
			if (!Int32.TryParse(xAltitude.InnerText, out value)) {
				return null;
			}

			if (xReference.InnerText == "STD") {
				return new AirspaceAltitude(AltitudeType.FlightLevel, value);
			}
			else if (xReference.InnerText == "MSL") {
				return new AirspaceAltitude(AltitudeType.Altitude, value);
			}
			else if (xReference.InnerText == "GND") {
				return new AirspaceAltitude(AltitudeType.Ground, value);
			}

			return null;
		}

		private static AirspaceClass ParseAirspaceClass(String input) {
			switch(input) {
				case "A": return AirspaceClass.C;
				case "B": return AirspaceClass.C;
				case "C": return AirspaceClass.C;
				case "D": return AirspaceClass.D;
				case "E": return AirspaceClass.E;
				case "CTR": return AirspaceClass.CTR;
				case "TMZ": return AirspaceClass.TMZ;
				case "WAVE": return AirspaceClass.WaveWindow;
				case "RMZ": return AirspaceClass.RMZ;
				case "RESTRICTED": return AirspaceClass.Restricted;
				case "DANGER": return AirspaceClass.Danger;
				case "FIR": return AirspaceClass.FIR;
				case "GLIDING": return AirspaceClass.Gliding;
				default: return AirspaceClass.Undefined;
			}
		}

		public IEnumerable<Waypoint> GetWaypoints() {
			List<Waypoint> waypoints = new List<Waypoint>();

			XmlDocument document = new XmlDocument();
			document.LoadXml(FileContent);

			ParseAirports(waypoints, document);
			ParseNavaids(waypoints, document);

			return waypoints;
		}

		private static void ParseNavaids(List<Waypoint> waypoints, XmlDocument document) {
			XmlNodeList xNavaids = document.SelectNodes("/OPENAIP/NAVAIDS/NAVAID");

			foreach (XmlNode xNavaid in xNavaids) {
				Double latitude = 0;
				Double longitude = 0;
				Double elevation = 0;
				Frequency frequency = null;

				XmlAttribute xType = xNavaid.Attributes["TYPE"];
				if (xType == null) {
					continue;
				}

				XmlNode xName = xNavaid.SelectSingleNode("NAME");
				if (xName == null) {
					continue;
				}

				XmlNode xIdentifier = xNavaid.SelectSingleNode("ID");
				if (xIdentifier == null) {
					continue;
				}

				XmlNode xLatitude = xNavaid.SelectSingleNode("GEOLOCATION/LAT");
				if (xLatitude == null) {
					continue;
				}

				XmlNode xLongitude = xNavaid.SelectSingleNode("GEOLOCATION/LON");
				if (xLongitude == null) {
					continue;
				}

				XmlNode xElevation = xNavaid.SelectSingleNode("GEOLOCATION/ELEV");
				if (xElevation == null) {
					continue;
				}

				XmlNode xCountry = xNavaid.SelectSingleNode("COUNTRY");
				if (xCountry == null) {
					continue;
				}

				XmlNode xFrequency = xNavaid.SelectSingleNode("RADIO/FREQUENCY");
				if (xFrequency == null) {
					continue;
				}

				Single freqValue = 0;
				if (Single.TryParse(xFrequency.InnerText, NumberStyles.Float, _Culture, out freqValue)) {
					frequency = new Frequency(freqValue);
				}

				if (!Double.TryParse(xLatitude.InnerText, NumberStyles.Float, _Culture, out latitude)) {
					continue;
				}

				if (!Double.TryParse(xLongitude.InnerText, NumberStyles.Float, _Culture, out longitude)) {
					continue;
				}

				if (!Double.TryParse(xElevation.InnerText, NumberStyles.Float, _Culture, out elevation)) {
					continue;
				}

				Elevation navaidElevation = new Elevation(Altitude.Unit.Meters, elevation);
				Coordinate coordinate = new Coordinate(latitude, longitude);
				Country country = ParseCountry(xCountry.InnerText);
				Navaid.NavaidType type = ParseNavaidType(xType.InnerText);

				Navaid navaid = new Navaid(xName.InnerText, xIdentifier.InnerText, type, navaidElevation, coordinate, country);
				waypoints.Add(navaid);
			}
		}

		private static void ParseAirports(List<Waypoint> waypoints, XmlDocument document) {
			XmlNodeList xAirports = document.SelectNodes("/OPENAIP/WAYPOINTS/AIRPORT");

			foreach (XmlNode xAirport in xAirports) {
				Double elevation = 0;
				Double latitude = 0;
				Double longitude = 0;
				Frequency frequency = null;

				XmlNode xName = xAirport.SelectSingleNode("NAME");
				if (xName == null) {
					continue;
				}

				XmlNode xICAO = xAirport.SelectSingleNode("ICAO");
				if (xICAO == null) {
					continue;
				}

				XmlNode xCountry = xAirport.SelectSingleNode("COUNTRY");
				if (xCountry == null) {
					continue;
				}

				XmlNode xLatitude = xAirport.SelectSingleNode("GEOLOCATION/LAT");
				if (xLatitude == null) {
					continue;
				}

				XmlNode xLongitude = xAirport.SelectSingleNode("GEOLOCATION/LON");
				if (xLongitude == null) {
					continue;
				}

				XmlNode xElevation = xAirport.SelectSingleNode("GEOLOCATION/ELEV");
				if (xElevation == null) {
					continue;
				}

				XmlNode xRadio = xAirport.SelectSingleNode("RADIO[@CATEGORY='COMMUNICATION']/FREQUENCY");
				if (xRadio != null) {
					Single freqValue = 0;
					if (Single.TryParse(xRadio.InnerText, NumberStyles.Float, _Culture, out freqValue)) {
						frequency = new Frequency(freqValue);
					}
				}

				if (!Double.TryParse(xLatitude.InnerText, NumberStyles.Float, _Culture, out latitude)) {
					continue;
				}

				if (!Double.TryParse(xLongitude.InnerText, NumberStyles.Float, _Culture, out longitude)) {
					continue;
				}

				if (!Double.TryParse(xElevation.InnerText, NumberStyles.Float, _Culture, out elevation)) {
					continue;
				}

				Elevation airportElevation = new Elevation(Altitude.Unit.Meters, elevation);
				Coordinate coordinate = new Coordinate(latitude, longitude);
				List<Runway> runways = ParseRunways(xAirport);
				Country country = ParseCountry(xCountry.InnerText);

				Airfield airfield = new Airfield(xName.InnerText, xICAO.InnerText, coordinate, airportElevation, runways.ToArray(), frequency, country);
				waypoints.Add(airfield);
			}
		}

		private static List<Runway> ParseRunways(XmlNode xAirport) {
			List<Runway> runways = new List<Runway>();
			XmlNodeList xRunways = xAirport.SelectNodes("RWY");

			foreach (XmlNode xRunway in xRunways) {
				Single direction = 0;
				Int32 length = 0;
				Runway.SurfaceType surface = Runway.SurfaceType.Undefined;

				XmlNode xDirection = xRunway.SelectSingleNode("DIRECTION");
				if (xDirection == null || xDirection.Attributes["TC"] == null) {
					continue;
				}

				XmlNode xLength = xRunway.SelectSingleNode("LENGTH");
				if (xLength == null) {
					continue;
				}

				XmlNode xSurface = xRunway.SelectSingleNode("SFC");
				if (xSurface == null) {
					continue;
				}

				if (!Single.TryParse(xDirection.Attributes["TC"].InnerText, out direction)) {
					continue;
				}

				if (!Int32.TryParse(xLength.InnerText, out length)) {
					continue;
				}

				surface = ParseRunwaySurface(xSurface.InnerText);
				runways.Add(new Runway((Int32)(Math.Round(direction / 10.0)), length, surface));
			}

			return runways;
		}

		private static Runway.SurfaceType ParseRunwaySurface(String input) {
			switch (input) {
				case "CONC": return Runway.SurfaceType.Concrete;
				case "ASPH": return Runway.SurfaceType.Asphalt;
				case "GRAS": return Runway.SurfaceType.Grass;
				default: return Runway.SurfaceType.Undefined;
			}
		}

		private static Navaid.NavaidType ParseNavaidType(String input) {
			switch (input) {
				case "NDB":return Navaid.NavaidType.NDB;
				case "DME": return Navaid.NavaidType.DME;
				case "VOR": return Navaid.NavaidType.VOR;
				case "DVOR": return Navaid.NavaidType.VOR;
				case "VOR-DME": return Navaid.NavaidType.VOR | Navaid.NavaidType.DME;
				case "DVOR-DME": return Navaid.NavaidType.VOR | Navaid.NavaidType.DME;
				case "VORTAC": return Navaid.NavaidType.VORTAC;
				case "DVORTAC": return Navaid.NavaidType.VORTAC;
				case "TACAN": return Navaid.NavaidType.TACAN;
				default: return Navaid.NavaidType.Undefined;
			}
		}

		private static Country ParseCountry(String input) {
			switch(input) {
				case "AF": return Country.Afghanistan;
				case "AL": return Country.Albania;
				case "DZ": return Country.Algeria;
				case "AO": return Country.Angola;
				case "AR": return Country.Argentina;
				case "AM": return Country.Armenia;
				case "AU": return Country.Australia;
				case "AT": return Country.Austria;
				case "AZ": return Country.Azerbaijan;
				case "BS": return Country.Bahamas;
				case "BD": return Country.Bangladesh;
				case "BB": return Country.Barbados;
				case "BE": return Country.Belgium;
				case "BM": return Country.Bermuda;
				case "BO": return Country.Bolivia;
				case "BA": return Country.Bosnia;
				case "BW": return Country.Botswana;
				case "BR": return Country.Brasilia;
				case "BG": return Country.Bulgaria;
				case "BF": return Country.BurkinaFaso;
				case "BI": return Country.Burundi;
				case "KH": return Country.Cambodia;
				case "CM": return Country.Cameroon;
				case "CA": return Country.Canada;
				case "CV": return Country.CapeVerde;
				case "KY": return Country.CaymanIslands;
				case "CF": return Country.CentralAfricanRepublic;
				case "TD": return Country.Chad;
				case "CL": return Country.Chile;
				case "CN": return Country.China;
				case "CX": return Country.ChristmasIsland;
				case "CC": return Country.CocosIslands;
				case "CO": return Country.Colombia;
				case "CR": return Country.CostaRica;
				case "HR": return Country.Croatia;
				case "CU": return Country.Cuba;
				case "CY": return Country.Cyprus;
				case "CZ": return Country.Czechia;
				case "DK": return Country.Denmark;
				case "DM": return Country.DominicanRepublic;
				case "DO": return Country.DominicanRepublic;
				case "EC": return Country.Ecuador;
				case "EG": return Country.Egypt;
				case "SV": return Country.ElSalvador;
				case "GQ": return Country.EquatorialGuinea;
				case "ER": return Country.Eritrea;
				case "EE": return Country.Estonia;
				case "ET": return Country.Ethiopia;
				case "FJ": return Country.Fiji;
				case "FI": return Country.Finland;
				case "FR": return Country.France;
				case "GE": return Country.Georgia;
				case "DE": return Country.Germany;
				case "GH": return Country.Ghana;
				case "GI": return Country.Gibraltar;
				case "GR": return Country.Greece;
				case "GL": return Country.Greenland;
				case "GD": return Country.Grenada;
				case "GT": return Country.Guatemala;
				case "GN": return Country.Guinea;
				case "GW": return Country.GuineaBissau;
				case "HT": return Country.Haiti;
				case "VA": return Country.VaticanCityState;
				case "HN": return Country.Honduras;
				case "HK": return Country.HongKong;
				case "HU": return Country.Hungary;
				case "IS": return Country.Iceland;
				case "IN": return Country.India;
				case "ID": return Country.Indonesia;
				case "IR": return Country.Iran;
				case "IQ": return Country.Iraq;
				case "IE": return Country.Ireland;
				case "IM": return Country.IsleOfMan;
				case "IL": return Country.Israel;
				case "IT": return Country.Italia;
				case "JM": return Country.Jamaica;
				case "JP": return Country.Japan;
				case "JE": return Country.Jersey;
				case "JO": return Country.Jordan;
				case "KZ": return Country.Kazakhstan;
				case "KE": return Country.Kenya;
				case "KP": return Country.Korea;
				case "KR": return Country.Korea;
				case "KW": return Country.Kuwait;
				case "LV": return Country.Latvia;
				case "LB": return Country.Lebanon;
				case "LS": return Country.Lesotho;
				case "LR": return Country.Liberia;
				case "LI": return Country.Liechtenstein;
				case "LT": return Country.Lithuania;
				case "LU": return Country.Luxembourg;
				case "MK": return Country.Macedonia;
				case "MG": return Country.Madagascar;
				case "MW": return Country.Malawi;
				case "MY": return Country.Malaysia;
				case "MV": return Country.Maldives;
				case "ML": return Country.Mali;
				case "MT": return Country.Malta;
				case "MH": return Country.MarshallIslands;
				case "MQ": return Country.Martinique;
				case "MR": return Country.Mauritania;
				case "MU": return Country.Mauritius;
				case "YT": return Country.Mayotte;
				case "MX": return Country.Mexico;
				case "FM": return Country.Micronesia;
				case "MD": return Country.Moldova;
				case "MC": return Country.Monaco;
				case "MN": return Country.Mongolia;
				case "ME": return Country.Montenegro;
				case "MS": return Country.Montserrat;
				case "MA": return Country.Morocco;
				case "MZ": return Country.Mozambique;
				case "MM": return Country.Myanmar;
				case "NA": return Country.Namibia;
				case "NR": return Country.Nauru;
				case "NP": return Country.Nepal;
				case "NL": return Country.Netherlands;
				case "AN": return Country.Netherlands;
				case "NC": return Country.NewCaledonia;
				case "NZ": return Country.NewZealand;
				case "NI": return Country.Nicaragua;
				case "NE": return Country.Niger;
				case "NG": return Country.Nigeria;
				case "NU": return Country.Niue;
				case "NF": return Country.NorfolkIsland;
				case "MP": return Country.NorthernMarianaIslands;
				case "NO": return Country.Norway;
				case "OM": return Country.Oman;
				case "PK": return Country.Pakistan;
				case "PW": return Country.Palau;
				case "PS": return Country.PalestinianTerritory;
				case "PA": return Country.Panama;
				case "PG": return Country.PapuaNewGuinea;
				case "PY": return Country.Paraguay;
				case "PE": return Country.Peru;
				case "PH": return Country.Philippines;
				case "PN": return Country.Pitcairn;
				case "PL": return Country.Poland;
				case "PT": return Country.Portugal;
				case "PR": return Country.PuertoRico;
				case "QA": return Country.Qatar;
				case "RO": return Country.Romania;
				case "RU": return Country.Russia;
				case "BL": return Country.SaintBarthelemy;
				case "SH": return Country.SaintHelena;
				case "KN": return Country.SaintKittsAndNevis;
				case "LC": return Country.SaintLucia;
				case "MF": return Country.SaintMartin;
				case "SM": return Country.SanMarino;
				case "SA": return Country.SaudiArabia;
				case "SN": return Country.Senegal;
				case "RS": return Country.Serbia;
				case "SC": return Country.Seychelles;
				case "SL": return Country.SierraLeone;
				case "SG": return Country.Singapore;
				case "SX": return Country.SintMaarten;
				case "SK": return Country.Slovakia;
				case "SI": return Country.Slovenia;
				case "SB": return Country.SolomonIslands;
				case "SO": return Country.Somalia;
				case "ZA": return Country.SouthAfrica;
				case "SS": return Country.Sudan;
				case "ES": return Country.Spain;
				case "LK": return Country.SriLanka;
				case "SD": return Country.Sudan;
				case "SZ": return Country.Swaziland;
				case "SE": return Country.Sweden;
				case "CH": return Country.Swiss;
				case "SY": return Country.Syria;
				case "TW": return Country.Taiwan;
				case "TH": return Country.Thailand;
				case "TG": return Country.Togo;
				case "TK": return Country.Tokelau;
				case "TO": return Country.Tonga;
				case "TN": return Country.Tunisia;
				case "TR": return Country.Turkey;
				case "TM": return Country.Turkmenistan;
				case "TC": return Country.TurksAndCaicosIslands;
				case "TV": return Country.Tuvalu;
				case "UG": return Country.Uganda;
				case "UA": return Country.Ukraine;
				case "AE": return Country.UnitedArabEmirates;
				case "GB": return Country.UnitedKingdom;
				case "US": return Country.USA;
				case "VU": return Country.Vanuatu;
				case "VE": return Country.Venezuela;
				case "VN": return Country.VietNam;
				case "VG": return Country.VirginIslands;
				case "VI": return Country.VirginIslands;
				case "WF": return Country.WallisandFutuna;
				case "EH": return Country.WesternSahara;
				case "YE": return Country.Yemen;
				case "ZM": return Country.Zambia;
				case "ZW": return Country.Zimbabwe;
				default: return Country.Undefined;
			}
		}
	}
}
