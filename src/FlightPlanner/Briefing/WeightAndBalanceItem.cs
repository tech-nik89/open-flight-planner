using FlightPlanner.Aircrafts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightPlanner.Briefing {
	public class WeightAndBalanceItem {

		public String Name { get; private set; }

		public Double Mass { get; private set; }

		public Double Arm { get; private set; }

		public Double Moment { get; private set; }

		public LoadingStation LoadingStation { get; private set; }

		private WeightAndBalanceItem() {
			Name = String.Empty;
			Mass = 0;
			Arm = 0;
			Moment = 0;
		}

		public static WeightAndBalanceItem FromMassAndArm(LoadingStation loadingStation, Double mass) {
			WeightAndBalanceItem item = new WeightAndBalanceItem();

			item.LoadingStation = loadingStation;
			item.Name = loadingStation.Name;
			item.Mass = mass;
			item.Arm = loadingStation.Arm;
			item.Moment = mass * loadingStation.Arm;

			return item;
		}

		public static WeightAndBalanceItem FromMassAndMoment(String name, Double mass, Double moment) {
			WeightAndBalanceItem item = new WeightAndBalanceItem();

			item.Name = name;
			item.Mass = mass;
			item.Moment = moment;
			item.Arm = moment / mass;

			return item;
		}
	}
}
