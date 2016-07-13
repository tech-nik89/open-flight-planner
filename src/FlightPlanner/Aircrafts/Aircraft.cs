using FlightPlanner.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightPlanner.Aircrafts {
    public class Aircraft {

		public String Type { get; set; }

		public String Registration { get; set; }

		public Double EmptyMass { get; set; }

		public Double MaxTakeoffMass { get; set; }

		public Double MaxLandingMass { get; set; }

		public Double EmptyMoment { get; set; }

		public List<LoadingStation> LoadingStations { get; private set; }

		public CenterOfGravity CenterOfGravityLimits { get; private set; }

		public MassUnit UnitMass { get; set; }

		public ArmUnit UnitArm { get; set; }

		public VolumeUnit UnitVolume { get; set; }

		public Double StartupAndTaxiFuel { get; set; }

		public Double AverageFuelFlow { get; set; }

		public List<Performance> CruisePerformance { get; set; }

		public TypeOfFuel FuelType { get; set; }

		public Aircraft() {
			LoadingStations = new List<LoadingStation>();
			CenterOfGravityLimits = new CenterOfGravity();
			CruisePerformance = new List<Performance>();
		}

		public override String ToString() {
			return String.Format("{0} ({1})", Registration, Type);
		}

		public Performance GetCruisePerformanceAt(Altitude altitude) {
			return Performance.CalculateAtAltitude(CruisePerformance, altitude);
		}

		public Double ConvertFuelToMass(Double fuel) {

			switch (this.FuelType) {
				case Aircraft.TypeOfFuel.Avgas:
					return fuel * 0.715;
				case Aircraft.TypeOfFuel.Mogas:
					return fuel * 0.753;
				case Aircraft.TypeOfFuel.JetA1:
					return fuel * 0.804;
				case Aircraft.TypeOfFuel.Diesel:
					return fuel * 0.833;
			}

			return 0;
		}

        public IEnumerable<LoadingStation> GetLoadingStations() {
            return LoadingStations.Where(s => s.GetType() == typeof(LoadingStation));
        }

        public IEnumerable<FuelTank> GetFuelTanks() {
            return LoadingStations.Where(s => s.GetType() == typeof(FuelTank)).Cast<FuelTank>();
        }

        public enum MassUnit {
			Kilogram
		}

		public enum ArmUnit {
			Meter
		}

		public enum VolumeUnit {
			Liter
		}

		public enum TypeOfFuel {
			Avgas,
			Mogas,
			JetA1,
			Diesel
		}
	}
}
