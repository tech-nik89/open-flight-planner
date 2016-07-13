using FlightPlanner.Aircrafts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightPlanner.Briefing {
	public class WeightAndBalance {

		public WeightAndBalanceItem Empty { get; private set; }

		public List<WeightAndBalanceItem> LoadingStations { get; private set; }

		public WeightAndBalanceItem DryOperating { get; private set; }

		public List<WeightAndBalanceItem> TakeOffFuel { get; private set; }

		public WeightAndBalanceItem TakeOff { get; private set; }

		public WeightAndBalanceItem Landing { get; private set; }

		public List<WeightAndBalanceItem> LandingFuel { get; private set; }

		public WeightAndBalance() {
			LoadingStations = new List<WeightAndBalanceItem>();
			TakeOffFuel = new List<WeightAndBalanceItem>();
			LandingFuel = new List<WeightAndBalanceItem>();
		}

		public static WeightAndBalance Create(FlightPlan flightPlan) {
			WeightAndBalance wab = new WeightAndBalance();
			Double totalMass, totalMoment;

			wab.Empty = WeightAndBalanceItem.FromMassAndMoment("Empty", flightPlan.Aircraft.EmptyMass, flightPlan.Aircraft.EmptyMoment);

			totalMoment = wab.Empty.Moment;
			totalMass = wab.Empty.Mass;

			foreach (LoadingStation loadingStation in flightPlan.Aircraft.LoadingStations) {
				if (!(loadingStation is FuelTank)) {
					Double mass = 0;

					if (flightPlan.Loading.ContainsKey(loadingStation)) {
						mass = flightPlan.Loading[loadingStation];
					}

					WeightAndBalanceItem item = WeightAndBalanceItem.FromMassAndArm(loadingStation, mass);
					wab.LoadingStations.Add(item);

					totalMoment += item.Moment;
					totalMass += item.Mass;
				}
			}

			wab.DryOperating = WeightAndBalanceItem.FromMassAndMoment("Dry", totalMass, totalMoment);

			foreach (LoadingStation loadingStation in flightPlan.Aircraft.LoadingStations) {
				if (loadingStation != null && loadingStation is FuelTank) {

					FuelTank fuelTank = (FuelTank)loadingStation;
					Double mass = 0;

					if (flightPlan.FuelTanks.ContainsKey(fuelTank)) {
						mass = flightPlan.Aircraft.ConvertFuelToMass(flightPlan.FuelTanks[fuelTank]);
					}

					WeightAndBalanceItem item = WeightAndBalanceItem.FromMassAndArm(fuelTank, mass);
					wab.TakeOffFuel.Add(item);

					totalMoment += item.Moment;
					totalMass += item.Mass;
				}
			}

			wab.TakeOff = WeightAndBalanceItem.FromMassAndMoment("Take Off", totalMass, totalMoment);

			Double fuelLeft = flightPlan.Route.TripFuel;

			foreach (LoadingStation loadingStation in flightPlan.Aircraft.LoadingStations) {
				if (loadingStation != null && loadingStation is FuelTank) {

					FuelTank fuelTank = (FuelTank)loadingStation;
					Double fuel = 0;
					Double mass = 0;
					Double startFuel = 0;

					if (flightPlan.FuelTanks.ContainsKey(fuelTank)) {
						startFuel = flightPlan.FuelTanks[fuelTank];
						fuel = startFuel;

						if (fuelLeft <= fuel) {
							fuel -= fuelLeft;
							fuelLeft = 0;
						}
						else {
							fuelLeft -= fuel;
							fuel = 0;
						}

						mass = flightPlan.Aircraft.ConvertFuelToMass(startFuel - fuel);

						WeightAndBalanceItem item = WeightAndBalanceItem.FromMassAndArm(fuelTank, mass);
						wab.LandingFuel.Add(item);

						totalMoment -= item.Moment;
						totalMass -= item.Mass;
					}
				}
			}

			wab.Landing = WeightAndBalanceItem.FromMassAndMoment("Landing", totalMass, totalMoment);

			return wab;
		}
	}
}
