using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Text;

namespace FlightPlanner.Waypoints {

	[DebuggerDisplay("{FormattedCoordinates}")]
	public class Coordinate {

		public Coordinate(Double latitude, Double longitude) {
			Latitude = latitude;
			Longitude = longitude;
		}

		public Double Latitude { get; private set; }

		public Double Longitude { get; private set; }

		public void MoveTo(Double latitude, Double longitude) {
			Latitude = latitude;
			Longitude = longitude;
		}

		public override String ToString() {
			return FormattedCoordinates;
		}

		[JsonIgnore]
		public String FormattedCoordinates {
			get {
				StringBuilder builder = new StringBuilder();

				if (Latitude > 0) {
					builder.Append("N");
				} else if (Latitude < 0) {
					builder.Append("S");
				}

				builder.Append(" ");
				builder.AppendFormat("{0:00.0000}°", Math.Abs(Latitude));
				builder.Append(" ");

				if (Longitude > 0) {
					builder.Append("E");
				} else if (Longitude < 0) {
					builder.Append("W");
				}

				builder.Append(" ");
				builder.AppendFormat("{0:00.0000}°", Math.Abs(Longitude));

				return builder.ToString();
			}
		}
	}
}
