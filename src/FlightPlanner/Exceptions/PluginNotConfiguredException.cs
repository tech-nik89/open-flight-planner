using System;

namespace FlightPlanner.Exceptions {
	public class PluginNotConfiguredException : Exception {

		public Type PluginType { get; private set; }

		public PluginNotConfiguredException(Type type) : base(type.Name + " not configured")  {
			PluginType = type;
		}

	}
}
