using FlightPlanner.Briefing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace FlightPlanner.Weather {
	public abstract class MetarWebService {

		public abstract List<Metar> RetrieveRouteMetar(FlightPlan flightPlan);

		public void RetrieveRouteMetarAsync(FlightPlan flightPlan, Action<List<Metar>> finished) {

			if (finished == null || flightPlan == null) {
				return;
			}

			List<Metar> list = new List<Metar>();

			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.DoWork += (sender, e) => {
				list = RetrieveRouteMetar(flightPlan);
			};

			backgroundWorker.RunWorkerCompleted += (sender, e) => {
				finished(list);
			};

			backgroundWorker.RunWorkerAsync();
		}
	}
}
