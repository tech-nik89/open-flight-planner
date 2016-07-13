using FlightPlanner.Interfaces;
using System;

namespace FlightPlanner.Units {
	public class FlightLevel : Altitude, ICloneable<Altitude> {

		private const Int32 ConversionFactor = 100;

		public FlightLevel(Int32 flightLevel)
			: base(Unit.Feet, flightLevel * ConversionFactor) {
		}

		public Int32 Altitude {
			get {
				return Feet / ConversionFactor;
			}
		}

		public String FormattedFlightLevel {
			get {
				return String.Format("FL {0}", Altitude);
			}
		}

		public override String ToString() {
			return FormattedFlightLevel;
		}

		public override Altitude Clone() {
			FlightLevel flightLevel = new FlightLevel(this.Feet / ConversionFactor);
			return flightLevel;
		}
	}
}
