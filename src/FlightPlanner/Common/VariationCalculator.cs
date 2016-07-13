using FlightPlanner.Tools;
using FlightPlanner.Units;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMM_Magnetic_Field_Calculator;

namespace FlightPlanner.Common {
	public class VariationCalculator {

		public static Int32 GetVariation(Coordinate coordinate, Altitude altitude) {
			clsWMM_Magnetic_Field_Calculator calculator = new clsWMM_Magnetic_Field_Calculator();
			calculator.Altitude_km = altitude.Kilometers;
			calculator.Latitude = coordinate.Latitude;
			calculator.longitude = coordinate.Longitude;
			calculator.WMM_Decimal_Year = GetDecimalYear();
			calculator.Calculate_Magnetic_Field();
			return -(Int32)Utilities.ToDegrees(calculator.DEC);
		}

        private static Double GetDecimalYear() {
            return DateTime.Now.Year + (DateTime.Now.Month / 12.0);
        }
	}
}
