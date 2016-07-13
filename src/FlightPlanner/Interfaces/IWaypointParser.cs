using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightPlanner.Interfaces {
	public interface IWaypointParser {

		IEnumerable<Waypoint> GetWaypoints();

	}
}
