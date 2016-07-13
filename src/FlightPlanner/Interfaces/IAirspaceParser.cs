using FlightPlanner.Airspaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Interfaces {
	public interface IAirspaceParser {

		IEnumerable<Airspace> GetAirspaces(IEnumerable<AirspaceClass> visibleAirspaces);

	}
}
