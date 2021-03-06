﻿using System;

namespace FlightPlanner.Weather.MetarTaf {
	public class Clouds {

		public SkyCoverage Coverage { get; set; }

		public Int32 HeightAboveGround { get; set; }

		public override string ToString() {
			if (Coverage == SkyCoverage.CAVOK) {
				return "CAVOK";
			}

			return String.Format("{0} ft {1}", HeightAboveGround, Coverage.ToString());
		}
	}
}
