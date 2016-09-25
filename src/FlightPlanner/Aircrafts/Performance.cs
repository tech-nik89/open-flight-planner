using FlightPlanner.Tools;
using FlightPlanner.Units;
using System;
using System.Collections.Generic;

namespace FlightPlanner.Aircrafts {
    public class Performance {

		public Altitude PressureAltitude { get; set; }

		public Airspeed Airspeed { get; set; }

		public Double FuelFlow { get; set; }

		public Int32 Rate { get; set; }

		public static Performance CalculateAtAltitude(List<Performance> items, Altitude altitude) {

			Performance performance = new Performance();
			performance.PressureAltitude = altitude;

			if (items.Count == 0) {
				return performance;
			}

			Performance[] array = new Performance[items.Count];

			items.CopyTo(array);
			items.Sort(delegate(Performance p1, Performance p2) {
				return p1.PressureAltitude.CompareTo(p2.PressureAltitude);
			});

			if (altitude < array[0].PressureAltitude) {
				return array[0];
			}

			if (altitude > array[array.Length - 1].PressureAltitude) {
				return array[array.Length - 1];
			}

			for (Int32 i = 1; i < array.Length; i++) {
				if (altitude < array[i].PressureAltitude) {
					performance.Airspeed = new Airspeed((Int32)Math.Round(Utilities.Interpolate(
						altitude.Feet,
						array[i - 1].PressureAltitude.Feet,
						array[i].PressureAltitude.Feet,
						array[i - 1].Airspeed.Knots,
						array[i].Airspeed.Knots), 0));

					performance.FuelFlow = (Int32)Math.Round(Utilities.Interpolate(
						altitude.Feet,
						array[i - 1].PressureAltitude.Feet,
						array[i].PressureAltitude.Feet,
						array[i - 1].FuelFlow,
						array[i].FuelFlow), 1);

					break;
				}
			}

			return performance;
		}
	}
}
