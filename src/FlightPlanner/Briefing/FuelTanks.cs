using FlightPlanner.Aircrafts;

namespace FlightPlanner.Briefing {
	public class FuelTanks : GenericLoading<FuelTank> {

		public FuelTanks(FlightPlan flightPlan)
			: base(flightPlan) {
		}

	}
}
