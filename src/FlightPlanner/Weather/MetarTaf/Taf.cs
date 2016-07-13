using System;

namespace FlightPlanner.Weather.MetarTaf {
	public class Taf {

		public String Raw { get; set; }

		public String ICAO { get; set; }

		public DateTime ValidFrom { get; set; }

		public DateTime ValidTo { get; set; }

	}
}
