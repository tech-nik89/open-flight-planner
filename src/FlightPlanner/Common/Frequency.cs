using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightPlanner.Common {
	public class Frequency {

		private readonly Single _Frequency;

		public Frequency(Single frequency) {
			_Frequency = frequency;
		}

		public Single Value {
			get {
				return _Frequency;
			}
		}

		public override String ToString() {
			if (_Frequency >= 108 && _Frequency <= 137) {
				return _Frequency.ToString("000.000 MHz");
			}

			if (_Frequency >= 150 && _Frequency <= 1610) {
				return _Frequency.ToString("000.0 kHz");
			}

			return _Frequency.ToString();
		}
	}
}
