using Newtonsoft.Json;
using System;

namespace FlightPlanner.Units {
    public class Airspeed {

		public Int32 Knots { get; private set; }

		public Airspeed(Int32 knots) {
			Knots = knots;
		}
        
        [JsonIgnore]
        public String FormattedKnots {
            get {
                return String.Format("{0} kt", Knots);
            }
        }

		public override string ToString() {
            return FormattedKnots;
		}

		public static Airspeed Parse(Object input) {
			if (input is Airspeed) {
				return (Airspeed)input;
			}

			if (input is String) {
				String str = ((String)input).Trim();

				if (str.EndsWith("kt", StringComparison.InvariantCultureIgnoreCase)) {
					str.Substring(0, str.Length - 2).Trim();
				}

				Int32 speed = 0;
				Int32.TryParse(str, out speed);

				return new Airspeed(speed);
			}

			return new Airspeed(0);
		}
	}
}
