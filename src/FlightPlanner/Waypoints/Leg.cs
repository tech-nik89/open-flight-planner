using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlightPlanner.Units;
using FlightPlanner.Common;
using FlightPlanner.Aircrafts;
using FlightPlanner.Tools;

namespace FlightPlanner.Waypoints {
	public class Leg {

		public Waypoint Waypoint1 { get; private set; }
		public Waypoint Waypoint2 { get; private set; }

		private readonly Route _Route;

		private const String DirectionFormatString = "{0:000}°";

		private Double DeltaLatitude {
			get {
				return Utilities.ToRadians(Waypoint2.Latitude - Waypoint1.Latitude);
			}
		}

		private Double DeltaLongitude {
			get {
				return Utilities.ToRadians(Waypoint2.Longitude - Waypoint1.Longitude);
			}
		}

		private Double LatitudeFrom {
			get {
				return Utilities.ToRadians(Waypoint1.Latitude);
			}
		}

		private Double LatitudeTo {
			get {
				return Utilities.ToRadians(Waypoint2.Latitude);
			}
		}

		private const Int32 Axis = 6378137;
		private const Int32 EarthRadius = 6371;

		private const Int32 Dirty = Int32.MinValue;

		public Leg(Route route, Waypoint waypoint1, Waypoint waypoint2) {
			UpdateWaypoints(waypoint1, waypoint2);

			_Route = route;

			Wind = new Wind();
			Altitude = new Altitude(Altitude.Unit.Feet, 0);
		}

		public void UpdateWaypoints(Waypoint waypoint1, Waypoint waypoint2) {
			Waypoint1 = waypoint1;
			Waypoint2 = waypoint2;

			_TrueCourse = Dirty;
			_Variation = Dirty;
			_MagneticCourse = Dirty;
			_Distance = null;
		}

		private Altitude _Altitude;

		public Altitude Altitude {
			get {
				return _Altitude;
			}
			set {
				_Altitude = value;
				_Performance = null;
			}
		}

		private Wind _Wind;

		public Wind Wind {
			get {
				return _Wind;
			}
			set {
				_Wind = value;
			}
		}

		private Int32 _GaforArea;

		public Int32 GaforArea {
			get {
				return _GaforArea;
			}
			set {
				_GaforArea = value;
			}
		}

		public String Name {
			get {
				return String.Format("{0} -> {1}", Waypoint1.Name, Waypoint2.Name);
			}
		}

		private Int32 _TrueCourse;

		public Int32 TrueCourse {
			get {
				if (_TrueCourse == Dirty) {
					Double y = Math.Sin(DeltaLongitude) * Math.Cos(LatitudeTo);
					Double x = Math.Cos(LatitudeFrom) * Math.Sin(LatitudeTo) - Math.Sin(LatitudeFrom) * Math.Cos(LatitudeTo) * Math.Cos(DeltaLongitude);

					Double bearing = Utilities.ToDegrees(Math.Atan2(y, x));

					if (bearing < 0) {
						bearing = 360 + bearing;
					}

					_TrueCourse = (Int32)Math.Round(bearing, 0);
				}

				return _TrueCourse;
			}
		}

		public String TrueCourseFormatted {
			get {
				return String.Format(DirectionFormatString, TrueCourse);
			}
		}

		private Performance _Performance;
		private Aircraft _Aircraft;

		public Performance Performance {
			get {
				if (_Performance == null || _Aircraft == null || _Aircraft != _Route.FlightPlan.Aircraft) {
					_Aircraft = _Route.FlightPlan.Aircraft;
					_Performance = _Aircraft.GetCruisePerformanceAt(Altitude);
				}

				return _Performance;
			}
		}

		public Airspeed TrueAirspeed {
			get {
				Performance performance = Performance;

				if (performance == null) {
					return new Airspeed(0);
				}

				if (performance.Airspeed == null) {
					return new Airspeed(0);
				}

				return performance.Airspeed;
			}
		}

		public Int32 WindCorrectionAngle {
			get {
				Int32 trueCourse = TrueCourse;
				Wind wind = Wind;

				Double tc = Utilities.ToRadians(trueCourse);
				Double wd = Utilities.ToRadians(wind.Direction);

				Int32 tas = TrueAirspeed.Knots;
				if (tas <= 0) {
					return 0;
				}

				Double swc = (wind.Speed / tas) * Math.Sin(wd - tc);
				
				Double hd = tc + Math.Asin(swc);

				if (hd < 0) {
					hd = hd + 2 * Math.PI;
				}

				if (hd > 2 * Math.PI) {
					hd = hd - 2 * Math.PI;
				}

				Double wca = Math.Atan2(wind.Speed * Math.Sin(hd - wd), tas - wind.Speed * Math.Cos(hd - wd));
				
				return (Int32)(Math.Round(Utilities.ToDegrees(wca), 0) * -1);
			}
		}

        public String WindCorrectionAngleFormatted {
            get {
                Int32 wca = WindCorrectionAngle;

                if (wca < 0) {
                    return String.Format("{0}° L", Math.Abs(wca));
                }
                else if (wca > 0) {
                    return String.Format("{0}° R", Math.Abs(wca));
                }

                return "-";
            }
        }

		private Distance _Distance;

		public Distance Distance {
			get {
				if (_Distance == null) {
					Double a = Math.Sin(DeltaLatitude / 2) * Math.Sin(DeltaLatitude / 2) +
						Math.Sin(DeltaLongitude / 2) * Math.Sin(DeltaLongitude / 2) * Math.Cos(LatitudeFrom) * Math.Cos(LatitudeTo);

					Double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
					Double distance = EarthRadius * c;

					_Distance = new Distance(Distance.Unit.Kilometers, distance);
				}

				return _Distance;
			}
		}

		private Int32 _Variation;

		public Int32 Variation {
			get {
				if (_Variation == Dirty) {
					_Variation = VariationCalculator.GetVariation(Waypoint1, Altitude);
				}

				return _Variation;
			}
		}

        public String VariationFormatted {
            get {
                Int32 variation = Variation;

                if (variation < 0) {
                    return String.Format("{0}° E", Math.Abs(variation));
                }
                else if (variation > 0) {
                    return String.Format("{0}° W", Math.Abs(variation));
                }

                return "-";
            }
        }

		private Int32 _MagneticCourse;

		public Int32 MagneticCourse {
			get {
				if (_MagneticCourse == Dirty) {
					_MagneticCourse = AddCourses(TrueCourse, Variation);
				}

				return _MagneticCourse;
			}
		}

        public String MagneticCourseFormatted {
            get {
                return String.Format(DirectionFormatString, MagneticCourse);
            }
        }

		public Int32 MagneticHeading {
			get {
				return AddCourses(MagneticCourse, WindCorrectionAngle);
			}
		}

        public String MagneticHeadingFormatted {
            get {
                return String.Format(DirectionFormatString, MagneticHeading);
            }
        }

		public Airspeed GroundSpeed {
			get {
				Airspeed tas = TrueAirspeed;
				if (tas == null || tas.Knots == 0) {
					return new Airspeed(0);
				}

				Wind wind = Wind;
				Double trueCourse = TrueCourse;
				Int32 trueAirspeed = tas.Knots;

				Double tc = Utilities.ToRadians(trueCourse);
				Double wd = Utilities.ToRadians(wind.Direction);

				Double swc = (wind.Speed / trueAirspeed) * Math.Sin(wd - tc);
				
				Double hd = tc + Math.Asin(swc);

				if (hd < 0) {
					hd = hd + 2 * Math.PI;
				}

				if (hd > 2 * Math.PI) {
					hd = hd - 2 * Math.PI;
				}
				
				Int32 gs = (Int32)Math.Round(trueAirspeed * Math.Sqrt(1 - Math.Pow(swc, 2)) - (wind.Speed * Math.Cos(wd - tc)));

				return new Airspeed(gs);
			}
		}

		public TimeSpan Time {
			get {
				Airspeed gs = GroundSpeed;

				if (gs == null || gs.Knots == 0) {
					return TimeSpan.Zero;
				}

				Double hours = Distance.NauticalMiles / ((Double)gs.Knots);
				return Utilities.RoundToMinutes(TimeSpan.FromHours(hours));
			}
		}

		public String TimeFormatted {
			get {
				return Time.ToString(@"hh\:mm");
			}
		}

		public Double FuelFlow {
			get {
				Performance performance = Performance;

				if (performance == null) {
					return 0;
				}

				return performance.FuelFlow;
			}
		}

		public Double FuelConsumption {
			get {
				return Math.Round(FuelFlow * Time.TotalHours, 1);
			}
		}

		private static Double CalculateDistanceBetween(Coordinate p1, Coordinate p2) {
			double dLat1InRad = p1.Latitude * (Math.PI / 180);
			double dLong1InRad = p1.Longitude * (Math.PI / 180);
			double dLat2InRad = p2.Latitude * (Math.PI / 180);
			double dLong2InRad = p2.Longitude * (Math.PI / 180);
			double dLongitude = dLong2InRad - dLong1InRad;
			double dLatitude = dLat2InRad - dLat1InRad;
			double a = Math.Pow(Math.Sin(dLatitude / 2), 2) + Math.Cos(dLat1InRad) * Math.Cos(dLat2InRad) * Math.Pow(Math.Sin(dLongitude / 2), 2);
			double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
			double dDistance = (Axis / 1000.0) * c;
			return dDistance;
		}

		private static Int32 AddCourses(Int32 course1, Int32 course2) {
			Int32 course = course1 + course2;

			if (course > 360) {
				course -= 360;
			}
			else if (course < 0) {
				course += 360;
			}

			return course;
		}
	}
}
