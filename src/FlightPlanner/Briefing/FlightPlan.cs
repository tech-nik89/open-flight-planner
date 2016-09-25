using FlightPlanner.Aircrafts;
using FlightPlanner.Storage;
using FlightPlanner.Waypoints;
using System;
using System.IO;
using System.Text;

namespace FlightPlanner.Briefing {
	public class FlightPlan {

		private Aircraft _Aircraft;

		public Aircraft Aircraft {
			get {
				return _Aircraft;
			}
			set {
				_Aircraft = value;
				Dirty = true;
			}
		}

		public Route Route { get; set; }

		public FuelTanks FuelTanks { get; private set; }

		public Loading Loading { get; private set; }

		private const String _Extension = "ofpx";
		private static readonly Encoding _Encoding = Encoding.UTF8;

		public static String Filter {
			get {
				return String.Format("Flight Plan (*.{0})|*.{0}", _Extension);
			}
		}

		public static String Extension {
			get {
				return _Extension;
			}
		}

		public static Encoding Encoding {
			get {
				return _Encoding;
			}
		}
		
		public Boolean Dirty { get; internal set; }

		public FlightPlan() {
			Aircraft = new Aircraft();
			FuelTanks = new FuelTanks(this);
			Loading = new Loading(this);
			Route = new Route(this);
			Dirty = false;
		}

		public static Boolean Save(FlightPlan flightPlan, String path) {
			if (String.IsNullOrWhiteSpace(path) || !path.EndsWith(_Extension)) {
				throw new ArgumentException();
			}

			FlightPlanXmlDocument document = new FlightPlanXmlDocument();
			document.SaveFlightPlan(flightPlan);
			document.Save(path);

			flightPlan.Dirty = false;

			return true;
		}
		
		public static FlightPlan Load(String path) {
			if (String.IsNullOrWhiteSpace(path) || !File.Exists(path) || !path.EndsWith(_Extension)) {
				throw new FileNotFoundException();
			}
			
			FlightPlanXmlDocument document = new FlightPlanXmlDocument();
			document.Load(path);

			FlightPlan flightPlan = document.ReadFlightPlan();
			flightPlan.Dirty = false;

			return flightPlan;
		}
	}
}
