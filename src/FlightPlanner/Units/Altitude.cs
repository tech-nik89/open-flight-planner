using FlightPlanner.Interfaces;
using Newtonsoft.Json;
using System;

namespace FlightPlanner.Units {
    public class Altitude : IComparable<Altitude>, ICloneable<Altitude> {

		private const Double ConversionFactor = 3.2808399;

		[JsonProperty]
		private Double _Alitude;

		public Altitude(Unit unit, Double altitude) {
			if (unit == Unit.Feet) {
				_Alitude = altitude;
			}
			else if (unit == Unit.Meters) {
				_Alitude = MetersToFeet(altitude);
			}
		}

		[JsonIgnore]
		public Int32 Feet {
			get {
				return (Int32)Math.Round(_Alitude);
			}
		}

		[JsonIgnore]
		public virtual String FormattedFeet {
			get {
				return String.Format("{0} ft", Feet);
			}
		}

		[JsonIgnore]
		public Int32 Meters {
			get {
				return (Int32)Math.Round(FeetToMeters(_Alitude));
			}
		}

		[JsonIgnore]
		public Int32 Kilometers {
			get {
				return (Int32)MetersToKilometers(FeetToMeters(_Alitude));
			}
		}

		[JsonIgnore]
		public String FormattedMeters {
			get {
				return String.Format("{0} m", Meters);
			}
		}

		private static Double FeetToMeters(Double value) {
			return value / ConversionFactor;
		}

		private static Double MetersToFeet(Double value) {
			return value * ConversionFactor;
		}

		private static Double MetersToKilometers(Double value) {
			return value / 1000;
		}

		public override String ToString() {
			return FormattedFeet;
		}

		public static Altitude Parse(Object input) {
			if (input is Altitude) {
				return (Altitude)input;
			}

			String data = input as String;
			if (String.IsNullOrWhiteSpace(data)) {
				return null;
			}

			String prepared = data.Trim().ToLower().Replace(",", ".");
			Double value = 0;
			Boolean flightLevel = false;
			Altitude.Unit unit = Altitude.Unit.Feet;

			if (prepared.StartsWith("fl")) {
				flightLevel = true;
				prepared = prepared.Substring(2).Trim();
			}

			if (prepared.EndsWith("ft")) {
				prepared = prepared.Substring(0, prepared.Length - 2).Trim();
			}
			else if (prepared.EndsWith("m")) {
				unit = Altitude.Unit.Meters;
				prepared = prepared.Substring(0, prepared.Length - 1).Trim();
			}

			Double.TryParse(prepared, out value);

			if (flightLevel) {
				return new FlightLevel((Int32)value);
			}
			else {
				return new Altitude(unit, value);
			}
		}

		public enum Unit {
			Feet,
			Meters
		}

		public Int32 CompareTo(Altitude other) {
			if (other == null)
				return 1;

			if (_Alitude == other._Alitude)
				return 0;

			if (_Alitude < other._Alitude)
				return -1;

			return 1;
		}

        public virtual Altitude Clone() {
            Altitude altitude = new Altitude(Unit.Feet, Feet);
            return altitude;
        }

        public static Boolean operator >(Altitude a1, Altitude a2) {
			return a1.CompareTo(a2) > 0;
		}

		public static Boolean operator <(Altitude a1, Altitude a2) {
			return a1.CompareTo(a2) < 0;
		}
	}
}
