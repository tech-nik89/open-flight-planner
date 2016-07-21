using FlightPlanner.Common;
using FlightPlanner.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightPlanner.Weather.MetarTaf {
	public class Metar {

		private const Int32 ColorLightBlue = -5383962;
		private const Int32 ColorLightGreen = -7278960;
		private const Int32 ColorTransparent = 16777215;
		private const Int32 ColorOrangeRed = -47872;
		private const Int32 ColorPink = -16181;

		public FlightCategory Category { get; set; }

		public String Raw { get; set; }

		public String ICAO { get; set; }

		public DateTime ObservationTime { get; set; }

		public Double Temperature { get; set; }

		public Double Dewpoint { get; set; }

		public Wind Wind { get; set; }

		public Distance Visibility { get; set; }

		public Pressure Altimeter { get; set; }

		public List<Clouds> Clouds { get; set; } = new List<Clouds>();

		public Clouds Ceiling {
			get {
				List<Clouds> clouds = Clouds
					.Where(c => c.Coverage == SkyCoverage.Broken || c.Coverage == SkyCoverage.Overcast || c.Coverage == SkyCoverage.CAVOK)
					.OrderBy(c => c.Coverage).ToList();

				if (clouds.Any()) {
					return clouds[0];
				}
				
				return null;
			}
		}

        public String TemperatureAndDewpoint {
            get {
                return String.Format("{0} / {1}", Temperature, Dewpoint);
            }
        }

		public Double Spread {
			get {
				return Math.Abs(Temperature - Dewpoint);
			}
		}

		public Int32 ColorCode {
			get {
				switch (Category) {
					case FlightCategory.VFR:
						return ColorLightBlue;
					case FlightCategory.MVFR:
						return ColorLightGreen;
					case FlightCategory.IFR:
						return ColorOrangeRed;
					case FlightCategory.LIFR:
						return ColorPink;
				}

				return ColorTransparent;
			}
		}
	}
}
