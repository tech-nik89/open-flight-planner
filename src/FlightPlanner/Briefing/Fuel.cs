using FlightPlanner.Aircrafts;
using FlightPlanner.Briefing;
using FlightPlanner.Tools;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightPlanner.Briefing {
	public class Fuel {

		public TimeSpan AdditionalTime {
			get {
				return TimeSpan.FromMinutes(45);
			}
		}

		public Double OffBlockFuel { get; private set; }

		public Double TaxiFuel { get; private set; }

		public Double TakeOffFuel { get; private set; }

		public TimeSpan TakeOffTime { get; private set; }

		public Double TripFuel { get; private set; }

		public Double LandingFuel { get; private set; }

		public TimeSpan LandingTime { get; private set; }

		public Double AdditionalFuel { get; private set; }

		public Double ExtraFuel { get; private set; }

		public TimeSpan ExtraTime { get; private set; }

		public static Fuel Calculate(FlightPlan flightPlan) {
			Fuel fuel = new Fuel();

			foreach (KeyValuePair<FuelTank, Double> fuelTank in flightPlan.FuelTanks) {
				fuel.OffBlockFuel += fuelTank.Value;
			}

			fuel.TaxiFuel = flightPlan.Aircraft.StartupAndTaxiFuel;
			fuel.TakeOffFuel = fuel.OffBlockFuel - fuel.TaxiFuel;

			fuel.TripFuel = flightPlan.Route.TripFuel;

			fuel.LandingFuel = fuel.TakeOffFuel - fuel.TripFuel;

			fuel.AdditionalFuel = flightPlan.Aircraft.AverageFuelFlow * fuel.AdditionalTime.TotalHours;
			fuel.ExtraFuel = fuel.LandingFuel - fuel.AdditionalFuel;

			fuel.TakeOffTime = Utilities.RoundToMinutes(TimeSpan.FromHours(fuel.TakeOffFuel / flightPlan.Aircraft.AverageFuelFlow));
			fuel.LandingTime = Utilities.RoundToMinutes(TimeSpan.FromHours(fuel.LandingFuel / flightPlan.Aircraft.AverageFuelFlow));
			fuel.ExtraTime = Utilities.RoundToMinutes(TimeSpan.FromHours(fuel.ExtraFuel / flightPlan.Aircraft.AverageFuelFlow));

			return fuel;
		}

		public static String Format(Double fuel) {
			return String.Format("{0:0.0} l", Math.Round(fuel, 1));
		}
	}
}
