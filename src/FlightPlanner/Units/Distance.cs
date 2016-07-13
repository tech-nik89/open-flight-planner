using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightPlanner.Units {
	public class Distance {

		private const Double NauticalMilesConversionFactor = 1.852;
		private const Double StatuteMilesConversionFactor = 0.868976242;

		private readonly Double _Distance;

		public Distance() {
			_Distance = 0;
		}

		public Distance(Unit unit, Double distance) {
			if (unit == Unit.Kilometers) {
				_Distance = KilometersToNauticalMiles(distance);
			}
			else if (unit == Unit.NauticalMiles) {
				_Distance = distance;
			}
			else if (unit == Unit.StatuteMiles) {
				_Distance = StatuteMilesToNauticalMiles(distance);
			}
		}

		public Double NauticalMiles {
			get {
				return _Distance;
			}
		}

		public String FormattedNauticalMiles {
			get {
				return String.Format("{0:0.0} NM", NauticalMiles);
			}
		}

		public Double Kilometers {
			get {
				return NauticalMilesToKilometers(_Distance);
			}
		}

		public String FormattedKilometers {
			get {
				return String.Format("{0:0.0} km", Kilometers);
			}
		}

		public static Double KilometersToNauticalMiles(Double value) {
			return value / NauticalMilesConversionFactor;
		}

        public static Double NauticalMilesToKilometers(Double value) {
			return value * NauticalMilesConversionFactor;
		}

        public static Double StatuteMilesToNauticalMiles(Double value) {
			return value * StatuteMilesConversionFactor;
		}

        public static Double NauticalMilesToStatueMiles(Double value) {
			return value / StatuteMilesConversionFactor;
		}

		public override String ToString() {
			return FormattedNauticalMiles;
		}

		public enum Unit {
			NauticalMiles,
			StatuteMiles,
			Kilometers
		}
	}
}
