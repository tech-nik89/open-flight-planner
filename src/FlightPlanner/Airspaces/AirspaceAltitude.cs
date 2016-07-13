using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightPlanner.Airspaces {

	public class AirspaceAltitude {

		public Int32 Value { get; private set; }

		public AltitudeType Type { get; private set; }

		private const Int32 AltitudeZero = 0;

		public AirspaceAltitude(AltitudeType type) : this(type, AltitudeZero) {
		}

		public AirspaceAltitude(AltitudeType type, Int32 value) {
			Type = type;
			Value = value;	
		}

        public override string ToString() {
            switch (Type) {
                case AltitudeType.Ground:
                    return "GND";
                case AltitudeType.FlightLevel:
                    return String.Format("FL {0}", Value);
                case AltitudeType.Altitude:
                default:
                    return String.Format("{0} ft", Value);
            }
        }
    }
}
