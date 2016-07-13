using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightPlanner.Units {

	public class Pressure {

		private const Double InHgTohPaConversion = 33.8638866667;

		private readonly Double _Pressure;

		public Pressure(Unit unit, Double pressure) {
			if (unit == Unit.hPa) {
				_Pressure = pressure;
			}
			else if (unit == Unit.InHg) {
				_Pressure = InHgTohPa(pressure);
			}
		}

		private static Double InHgTohPa(Double value) {
			return value * InHgTohPaConversion;
		}

		private static Double hPaToInHg(Double value) {
			return value / InHgTohPaConversion;
		}

		public Int32 hPa {
			get {
				return (Int32)Math.Round(_Pressure);
			}
		}

		public Double InHg {
			get {
				return Math.Round(hPaToInHg(_Pressure), 2);
			}
		}

		public String FormattedhPa {
			get {
				return String.Format("{0} hPa", hPa);
			}
		}

		public enum Unit {
			hPa,
			InHg
		}

		public override string ToString() {
			return FormattedhPa;
		}
	}
}
