using System;
using System.Collections.Generic;

namespace FlightPlanner.Plugins {
	public interface IPlugin {

		String Name { get; }

		Boolean Configurable { get; }

		void ShowConfiguration();

		Dictionary<String, Object> Configuration { get; }

	}
}
