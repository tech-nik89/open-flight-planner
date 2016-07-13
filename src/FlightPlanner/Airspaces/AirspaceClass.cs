using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightPlanner.Airspaces {
	public enum AirspaceClass {
		Undefined,
		Restricted,
		Danger,
		Prohibited,
		A,
		B,
		C,
		D,
		E,
		GliderProhibited,
		CTR,
		WaveWindow,
		TMZ,
		RMZ,
		FIR,
		Gliding
	}
}
