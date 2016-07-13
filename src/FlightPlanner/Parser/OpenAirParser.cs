using FlightPlanner.Airspaces;
using FlightPlanner.Airspaces.Segments;
using FlightPlanner.Interfaces;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlightPlanner.Parser {
	public class OpenAirParser : Parser, IAirspaceParser {

		private const String TagAirspaceClass = "AC";
		private const String TagAirspaceName = "AN";
		private const String TagAirspaceFloor = "AL";
		private const String TagAirspaceCeiling = "AH";
		private const String TagAirspacePolygon = "DP";
		private const String TagAirspaceVariable = "V ";
		private const Char VariableSeparator = '=';
        private const String TagAirspaceNameCoordinate = "AT";

        private const String AirspaceClassRestricted = "R";
		private const String AirspaceClassDanger = "Q";
		private const String AirspaceClassProhibited = "P";
		private const String AirspaceClassA = "A";
		private const String AirspaceClassB = "B";
		private const String AirspaceClassC = "C";
		private const String AirspaceClassD = "D";
		private const String AirspaceClassGliderProhibited = "GP";
		private const String AirspaceClassCTR = "CTR";

		private const String AltitudeGround = "GND";
		private const String AltitudeFlightLevel = "FL";
		private const String AltitudeFeet = "ft";
		private const String AltitudeMSL = "MSL";

		private const String VariableArcDirection = "D";
		private const String VariableArcDirectionClockwise = "+";
		private const String VariableArcDirectionCounterClockwise = "-";

		private const String VariableArcCenter = "X";

		private const String TagAirspaceArcByAngle = "DA";
		private const String TagAirspaceArcByCoordinates = "DB";
		private const String TagAirspaceCircleByRadius = "DC";

		public OpenAirParser(FileInfo file)
			: base(file) {
		}	

		public OpenAirParser(String input)
			: base(input) {
		}

		public IEnumerable<Airspace> GetAirspaces(IEnumerable<AirspaceClass> visibleAirspaces) {
			return Parse(Lines, visibleAirspaces);
		}

		private List<Airspace> Parse(String[] data, IEnumerable<AirspaceClass> visibleAirspaces) {

			List<Airspace> airspaces = new List<Airspace>();

			String tag = null;
			String value = null;
			Airspace airspace = null;

			ArcDirection arcDirection = ArcDirection.Clockwise;
			Coordinate arcCenter = null;

			foreach (String line in data) {
				if (line.StartsWith("*")) {
					continue;
				}

				if (String.IsNullOrWhiteSpace(line) || line.StartsWith(TagAirspaceClass)) {
					if (airspace != null) {

                        if (airspace.NameCoordinate == null && airspace.Segments.Any()) {
                            airspace.NameCoordinate = airspace.Segments.Last().BaseCoordinate;
                        }

						airspaces.Add(airspace);
						airspace = null;

						arcDirection = ArcDirection.Clockwise;
						arcCenter = null;
					}

					if (String.IsNullOrWhiteSpace(line)) {
						continue;
					}
				}

				if (line.Length >= 4) {
					tag = line.Substring(0, 2);
					value = line.Substring(2).Trim();

					Int32 commentIndex = value.IndexOf("*");
					if (commentIndex > -1) {
						value = value.Substring(0, commentIndex).Trim();
					}

					if (airspace == null && tag.Equals(TagAirspaceClass)) {
						airspace = new Airspace();
						airspace.Class = ParseAirspaceClass(value);
					}

					if (airspace != null) {
						switch (tag) {
							case TagAirspaceName:
								airspace.Name = value;
								break;

							case TagAirspaceCeiling:
								airspace.Ceiling = ParseAltitude(value);
								break;

							case TagAirspaceFloor:
								airspace.Floor = ParseAltitude(value);
								break;

                            case TagAirspaceNameCoordinate:
                                airspace.NameCoordinate = ParseCoordinate(value);
                                break;

							case TagAirspacePolygon:
								Coordinate coordinate = ParseCoordinate(value);

								if (coordinate != null) {
									airspace.Segments.Add(new PolygonAirspaceSegment(coordinate));
								}

								break;

							case TagAirspaceVariable:
								String[] parts = value.Split(VariableSeparator);

								if (parts.Length == 2) {

									switch (parts[0]) {
										case VariableArcDirection:
											if (parts[1].Equals(VariableArcDirectionCounterClockwise, StringComparison.InvariantCultureIgnoreCase)) {
												arcDirection = ArcDirection.CounterClockwise;
											}
                                            else if (parts[1].Equals(VariableArcDirectionClockwise, StringComparison.InvariantCultureIgnoreCase)) {
                                                arcDirection = ArcDirection.Clockwise;
                                            }

											break;

										case VariableArcCenter:
											arcCenter = ParseCoordinate(parts[1]);
											break;
									}
								}

								break;

							case TagAirspaceArcByAngle:
								ArcByAngleAirspaceSegment arcByAngleSegment = ParseArcByAngle(value, arcCenter, arcDirection);

								if (arcByAngleSegment != null) {
									airspace.Segments.Add(arcByAngleSegment);
								}

								break;

							case TagAirspaceArcByCoordinates:
								ArcByCoordinatesAirspaceSegment arcByCoordinatesSegment = ParseArcByCoordinate(value, arcCenter, arcDirection);

								if (arcByCoordinatesSegment != null) {
									airspace.Segments.Add(arcByCoordinatesSegment);
								}

								break;

							case TagAirspaceCircleByRadius:
								CircleByRadiusAirspaceSegment circleByRadiusSegment = ParseCircleByRadius(value, arcCenter);
								
								if (circleByRadiusSegment != null) {
									airspace.Segments.Add(circleByRadiusSegment);
								}

								break;
						}
					}
				}
			}

			if (airspace != null) {
				if (!visibleAirspaces.Any() || visibleAirspaces.Contains(airspace.Class)) {
					airspaces.Add(airspace);
				}
			}

			return airspaces;
		}

		private static ArcByAngleAirspaceSegment ParseArcByAngle(String input, Coordinate center, ArcDirection direction) {
			Single radius = 0;
			Int32 start = 0;
			Int32 end = 0;

			String[] parts = input.Split(',');
			if (parts.Length != 3) {
				return null;
			}

			if (!TryParseSingle(parts[0], out radius) || !Int32.TryParse(parts[1], out start) || !Int32.TryParse(parts[2], out end)) {
				return null;
			}

			return new ArcByAngleAirspaceSegment(center, radius, start, end, direction);
		}

		private static CircleByRadiusAirspaceSegment ParseCircleByRadius(String input, Coordinate center) {
			Single radius = 0;

			if (center == null || !TryParseSingle(input, out radius)) {
				return null;
			}

			return new CircleByRadiusAirspaceSegment(center, radius);
		}

		private static ArcByCoordinatesAirspaceSegment ParseArcByCoordinate(String input, Coordinate center, ArcDirection direction) {
			String[] parts = input.Split(',');

			if (center == null || parts.Length != 2) {
				return null;
			}

			Coordinate coordinate1 = ParseCoordinate(parts[0]);
			Coordinate coordinate2 = ParseCoordinate(parts[1]);

			if (coordinate1 == null || coordinate2 == null) {
				return null;
			}

			return new ArcByCoordinatesAirspaceSegment(center, coordinate1, coordinate2, direction);
		}

		private static AirspaceClass ParseAirspaceClass(String input) {

			switch (input) {
				case AirspaceClassRestricted: return AirspaceClass.Restricted;
				case AirspaceClassDanger: return AirspaceClass.Danger;
				case AirspaceClassProhibited: return AirspaceClass.Prohibited;
				case AirspaceClassA: return AirspaceClass.A;
				case AirspaceClassB: return AirspaceClass.B;
				case AirspaceClassC: return AirspaceClass.C;
				case AirspaceClassD: return AirspaceClass.D;
				case AirspaceClassGliderProhibited: return AirspaceClass.GliderProhibited;
				case AirspaceClassCTR: return AirspaceClass.CTR;
			}

			return AirspaceClass.Undefined;
		}

		private static AirspaceAltitude ParseAltitude(String input) {
			String data = input.Trim();

			if (data.Equals(AltitudeGround, StringComparison.InvariantCultureIgnoreCase)) {
				return new AirspaceAltitude(AltitudeType.Ground);
			}

			if (data.StartsWith(AltitudeFlightLevel, StringComparison.InvariantCultureIgnoreCase)) {
				String value = data.Substring(2);
				Int32 flightLevel = 0;

				if (Int32.TryParse(value, out flightLevel)) {
					return new AirspaceAltitude(AltitudeType.FlightLevel, flightLevel);
				}
			}

			if (data.EndsWith(AltitudeFeet, StringComparison.InvariantCultureIgnoreCase)) {
				String value = data.Substring(0, data.Length - AltitudeFeet.Length);
				Int32 altitude = 0;

				if (Int32.TryParse(value, out altitude)) {
					return new AirspaceAltitude(AltitudeType.Altitude, altitude);
				}
			}

			if (data.EndsWith(AltitudeMSL, StringComparison.InvariantCultureIgnoreCase)) {
				String value = data.Substring(0, data.Length - AltitudeMSL.Length);
				Int32 altitude = 0;

				if (Int32.TryParse(value, out altitude)) {
					return new AirspaceAltitude(AltitudeType.Altitude, altitude);
				}
			}

			return null;
		}

		private static Coordinate ParseCoordinate(String input) {
			// 54:02:00 N 008:51:00 E

			String data = input.Trim();
			String latitude = data.Substring(0, 10);
			String longitude = data.Substring(10);

			return new Coordinate(ParseSingleCoordinate(latitude), ParseSingleCoordinate(longitude));
		}

		private static Double ParseSingleCoordinate(String input) {
			// 54:02:00 N
			String data = input.Trim();

			Boolean positive = false;

			if (data.EndsWith("N", StringComparison.InvariantCultureIgnoreCase) || data.EndsWith("E", StringComparison.InvariantCultureIgnoreCase)) {
				positive = true;
			}

			data = data.Substring(0, data.Length - 1);

			String[] parts = data.Split(':');
			Double result = 0;

			if (parts.Length >= 3) {
				Double degrees, minutes, seconds;

				Double.TryParse(parts[0], out degrees);
				Double.TryParse(parts[1], out minutes);
				Double.TryParse(parts[2], out seconds);

				result = degrees;
				result += minutes / 60;
				result += seconds / 3600;
			}

			if (!positive) {
				result = result * -1;
			}

			return result;
		}

		private static Boolean TryParseSingle(String input, out Single value) {
			return Single.TryParse(input, System.Globalization.NumberStyles.Number, ParserFormatProvider, out value);
		}
	}
}
