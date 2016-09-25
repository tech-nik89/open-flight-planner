using System;

namespace FlightPlanner.Export {
	public class ExportOptions {

		public Boolean All {
			get {
				return FlightLog
					&& Gafor
					&& Metar
					&& SignificantWeatherChart
					&& TextWeatherReport
					&& MassAndBalance
					&& Notams;
			}
			set {
				FlightLog
					= Gafor
					= Metar
					= SignificantWeatherChart
					= TextWeatherReport
					= MassAndBalance
					= Notams
					= value;
			}
		}

		public Boolean FlightLog { get; set; }

		public Boolean Gafor { get; set; }

		public Boolean Metar { get; set; }

		public Boolean SignificantWeatherChart { get; set; }

		public Boolean TextWeatherReport { get; set; }

		public Boolean MassAndBalance { get; set; }

		public Boolean Notams { get; set; }
		
		public Boolean OpenAfterExport { get; set; }

	}
}
