using FlightPlanner.Aircrafts;
using FlightPlanner.Storage;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FlightPlanner.Briefing {
	public class FlightPlan {
		
		public Aircraft Aircraft { get; set; }

		public Route Route { get; set; }

		public Dictionary<FuelTank, Double> FuelTanks { get; private set; }

		public Dictionary<LoadingStation, Double> Loading { get; private set; }

		private static readonly String _Extension = "ofpx";
		private static readonly Encoding _Encoding = Encoding.UTF8;

		public static String Filter {
			get {
				return String.Format("Flight Plan (*.{0})|*.{0}", _Extension);
			}
		}

		public static String Extension { get {
				return _Extension;
			}
		}

		public static Encoding Encoding {
			get {
				return _Encoding;
			}
		}

		public FlightPlan() {
			Aircraft = new Aircraft();
			FuelTanks = new Dictionary<FuelTank, Double>();
			Loading = new Dictionary<LoadingStation, Double>();
			Route = new Route(this);
		}

		public static Boolean Save(FlightPlan flightPlan, String path) {
			if (String.IsNullOrWhiteSpace(path) || !path.EndsWith(_Extension)) {
				throw new ArgumentException();
			}

			FlightPlanXmlDocument document = new FlightPlanXmlDocument();
			document.SaveFlightPlan(flightPlan);
			document.Save(path);

			return true;
		}
		
		public static FlightPlan Load(String path) {
			if (String.IsNullOrWhiteSpace(path) || !File.Exists(path) || !path.EndsWith(_Extension)) {
				throw new FileNotFoundException();
			}
			
			FlightPlanXmlDocument document = new FlightPlanXmlDocument();
			document.Load(path);

			return document.ReadFlightPlan();
		}
	}
}
