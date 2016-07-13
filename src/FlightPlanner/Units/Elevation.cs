using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightPlanner.Units {
	public class Elevation : Altitude {

		public Elevation(Altitude.Unit unit, Double elevation)
			: base(unit, elevation) {
		}

	}
}
