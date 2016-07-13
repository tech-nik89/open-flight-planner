using FlightPlanner.Aircrafts;
using System;
using System.Collections.Generic;

namespace FlightPlanner.Briefing {
    public class MassAndBalance {

		public MassAndBalanceItem Empty { get; private set; }

		public List<MassAndBalanceItem> LoadingStations { get; private set; }

		public MassAndBalanceItem DryOperating { get; private set; }
		
		public MassAndBalanceItem Ramp { get; private set; }

		public MassAndBalanceItem TakeOff { get; private set; }

		public MassAndBalanceItem Landing { get; private set; }

		public Double RampFuel { get; private set; }

		public Double StartupAndTaxiFuel { get; private set; }

		public Double TakeOffFuel { get; private set; }

		public Double TripFuel { get; private set; }

		public Double LandingFuel { get; private set; }

		public Double AlternateFuel { get; private set; }

		public Double ContingencyFuel { get; private set; }

		public Double FinalReserveFuel { get; private set; }

		public Double ExtraFuel { get; private set; }

		public MassAndBalance() {
			LoadingStations = new List<MassAndBalanceItem>();
		}

		public static MassAndBalance Create(FlightPlan flightPlan) {
			if (flightPlan.Aircraft == null) {
				return null;
			}

			MassAndBalance mab = new MassAndBalance();
			Double totalMass, totalMoment;

			mab.Empty = MassAndBalanceItem.FromMassAndMoment("Empty Mass", flightPlan.Aircraft.EmptyMass, flightPlan.Aircraft.EmptyMoment);

			totalMoment = mab.Empty.Moment;
			totalMass = mab.Empty.Mass;

			foreach (LoadingStation loadingStation in flightPlan.Aircraft.GetLoadingStations()) {
				Double mass = 0;

				if (flightPlan.Loading.ContainsKey(loadingStation)) {
					mass = flightPlan.Loading[loadingStation];
				}

				MassAndBalanceItem item = MassAndBalanceItem.FromMassAndArm(loadingStation, mass);
				mab.LoadingStations.Add(item);

				totalMoment += item.Moment;
				totalMass += item.Mass;
			}

			mab.DryOperating = MassAndBalanceItem.FromMassAndMoment("Dry Operating Mass", totalMass, totalMoment);

			foreach (FuelTank fuelTank in flightPlan.Aircraft.GetFuelTanks()) {
				Double mass = 0;

				if (flightPlan.FuelTanks.ContainsKey(fuelTank)) {
					mab.RampFuel += flightPlan.FuelTanks[fuelTank];
					mass = flightPlan.Aircraft.ConvertFuelToMass(flightPlan.FuelTanks[fuelTank]);
				}

				MassAndBalanceItem item = MassAndBalanceItem.FromMassAndArm(fuelTank, mass);

				totalMoment += item.Moment;
				totalMass += item.Mass;
			}

			mab.Ramp = MassAndBalanceItem.FromMassAndMoment("Ramp Mass", totalMass, totalMoment);
			
			mab.StartupAndTaxiFuel = flightPlan.Aircraft.StartupAndTaxiFuel;
			BurnFuel(flightPlan, mab, ref totalMass, ref totalMoment, mab.StartupAndTaxiFuel);

			mab.TakeOffFuel = mab.RampFuel - mab.StartupAndTaxiFuel;
			mab.TakeOff = MassAndBalanceItem.FromMassAndMoment("Take Off", totalMass, totalMoment);

			mab.TripFuel = flightPlan.Route.TripFuel;
			BurnFuel(flightPlan, mab, ref totalMass, ref totalMoment, mab.TripFuel);

			mab.LandingFuel = mab.TakeOffFuel - mab.TripFuel;
			mab.Landing = MassAndBalanceItem.FromMassAndMoment("Landing", totalMass, totalMoment);

			mab.ContingencyFuel = flightPlan.Route.TripFuel * 0.15;
			mab.FinalReserveFuel = flightPlan.Aircraft.AverageFuelFlow * 0.75;

			mab.ExtraFuel = mab.LandingFuel - mab.ContingencyFuel - mab.FinalReserveFuel;

			return mab;
		}
		
		private static void BurnFuel(FlightPlan flightPlan, MassAndBalance wab, ref Double totalMass, ref Double totalMoment, Double burnFuel) {
			foreach (FuelTank fuelTank in flightPlan.Aircraft.GetFuelTanks()) {
				Double fuel = 0;
				Double mass = 0;
				Double startFuel = 0;

				if (flightPlan.FuelTanks.ContainsKey(fuelTank)) {
					startFuel = flightPlan.FuelTanks[fuelTank];
					fuel = startFuel;

					if (burnFuel <= fuel) {
						fuel -= burnFuel;
						burnFuel = 0;
					} else {
						burnFuel -= fuel;
						fuel = 0;
					}

					mass = flightPlan.Aircraft.ConvertFuelToMass(startFuel - fuel);

					MassAndBalanceItem item = MassAndBalanceItem.FromMassAndArm(fuelTank, mass);

					totalMoment -= item.Moment;
					totalMass -= item.Mass;
				}
			}
		}
	}
}
