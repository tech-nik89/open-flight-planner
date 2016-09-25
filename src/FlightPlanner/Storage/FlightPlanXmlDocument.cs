using FlightPlanner.Briefing;
using FlightPlanner.Common;
using FlightPlanner.Configuration;
using FlightPlanner.Exceptions;
using FlightPlanner.Units;
using FlightPlanner.Waypoints;
using System;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace FlightPlanner.Storage {
	class FlightPlanXmlDocument : XmlDocument {

		private static readonly IFormatProvider _FormatProvider = new CultureInfo("en-US");

		public void SaveFlightPlan(FlightPlan flightPlan) {
			XmlElement root = CreateElement("flightPlan");
			AppendChild(root);

			ApplyAircraft(flightPlan, root);
			ApplyFuelTanks(flightPlan, root);
			ApplyLoading(flightPlan, root);
			ApplyRoute(flightPlan, root);
		}

		private void ApplyAircraft(FlightPlan flightPlan, XmlElement parent) {
			XmlElement xmlAircraft = CreateElement("aircraft");
			parent.AppendChild(xmlAircraft);
			xmlAircraft.InnerText = flightPlan.Aircraft.Registration;
		}

		private void ApplyFuelTanks(FlightPlan flightPlan, XmlElement parent) {
			XmlElement xmlfuelTanks = CreateElement("fuelTanks");
			parent.AppendChild(xmlfuelTanks);

			foreach (var fuelTank in flightPlan.FuelTanks) {
				XmlElement xmlFuelTank = CreateElement("fuelTank");
				xmlfuelTanks.AppendChild(xmlFuelTank);

				xmlFuelTank.SetAttribute("name", fuelTank.Key.Name);
				xmlFuelTank.SetAttribute("value", fuelTank.Value.ToString(_FormatProvider));
			}
		}

		private void ApplyLoading(FlightPlan flightPlan, XmlElement parent) {
			XmlElement xmlLoading = CreateElement("loading");
			parent.AppendChild(xmlLoading);

			foreach (var loading in flightPlan.Loading) {
				XmlElement xmlLoadingItem = CreateElement("item");
				xmlLoading.AppendChild(xmlLoadingItem);

				xmlLoadingItem.SetAttribute("name", loading.Key.Name);
				xmlLoadingItem.SetAttribute("value", loading.Value.ToString(_FormatProvider));
			}
		}

		private void ApplyRoute(FlightPlan flightPlan, XmlElement parent) {
			XmlElement xmlWaypoints = CreateElement("waypoints");
			parent.AppendChild(xmlWaypoints);

			foreach (var waypoint in flightPlan.Route.Waypoints) {
				xmlWaypoints.AppendChild(CreateWaypointElement(waypoint));
			}

			XmlElement xmlLegs = CreateElement("legs");
			parent.AppendChild(xmlLegs);

			foreach (var leg in flightPlan.Route.Legs) {
				xmlLegs.AppendChild(CreateLegElement(leg));
			}
		}

		private XmlElement CreateLegElement(Leg leg) {
			XmlElement xmlLeg = CreateElement("leg");

			xmlLeg.SetAttribute("altitude", leg.Altitude.ToString());
			xmlLeg.SetAttribute("wind-direction", leg.Wind.Direction.ToString(_FormatProvider));
			xmlLeg.SetAttribute("wind-speed", leg.Wind.Speed.ToString(_FormatProvider));
			xmlLeg.SetAttribute("gafor", leg.GaforArea.ToString(_FormatProvider));

			return xmlLeg;
		}

		private XmlElement CreateWaypointElement(Waypoint waypoint) {
			XmlElement element = null;

			if (waypoint is Airfield) {
				element = CreateElement("airfield");
				Airfield airfield = (Airfield)waypoint;
				element.SetAttribute("name", airfield.Name);
				element.SetAttribute("icao", airfield.ICAOCode);
				element.SetAttribute("latitude", airfield.Latitude.ToString(_FormatProvider));
				element.SetAttribute("longitude", airfield.Longitude.ToString(_FormatProvider));
				element.SetAttribute("elevation", airfield.Elevation.Feet.ToString(_FormatProvider));
				element.SetAttribute("frequency", airfield.Frequency.Value.ToString(_FormatProvider));
				element.SetAttribute("country", airfield.Country.ToString());

				XmlElement xmlRunways = CreateElement("runways");
				element.AppendChild(xmlRunways);

				foreach (Runway runway in airfield.Runways) {
					XmlElement xmlRunway = CreateElement("runway");
					xmlRunways.AppendChild(xmlRunway);

					xmlRunway.SetAttribute("direction", runway.Direction.ToString(_FormatProvider));
					xmlRunway.SetAttribute("length", runway.Length.ToString(_FormatProvider));
					xmlRunway.SetAttribute("surface", runway.Surface.ToString());
				}
			}
			else {
				element = CreateElement("waypoint");
				element.SetAttribute("name", waypoint.Name);
				element.SetAttribute("country", waypoint.Country.ToString());
				element.SetAttribute("latitude", waypoint.Latitude.ToString(_FormatProvider));
				element.SetAttribute("longitude", waypoint.Longitude.ToString(_FormatProvider));
			}

			return element;
		}

		public FlightPlan ReadFlightPlan() {
			FlightPlan flightPlan = new FlightPlan();

			LoadAircraft(flightPlan);
			LoadFuelTanks(flightPlan);
			LoadLoading(flightPlan);
			LoadRoute(flightPlan);

			return flightPlan;
		}
		
		private void LoadAircraft(FlightPlan flightPlan) {
			XmlNode element = SelectSingleNode("/flightPlan/aircraft");
			if (element == null) {
				return;
			}

			String registration = element.InnerText;
			foreach (var aircraft in Config.Current.Aircrafts) {
				if (aircraft.Registration == registration) {
					flightPlan.Aircraft = aircraft;
					return;
				}
			}

			throw new AircraftNotFoundException();
		}

		private void LoadFuelTanks(FlightPlan flightPlan) {
			XmlNodeList elements = SelectNodes("/flightPlan/fuelTanks/fuelTank");

			foreach (XmlNode element in elements) {
				String name = element.Attributes["name"].InnerText;
				String value = element.Attributes["value"].InnerText;

				foreach (var fuelTank in flightPlan.Aircraft.GetFuelTanks()) {
					if (fuelTank.Name == name) {
						Double fuel = 0;

						if (Double.TryParse(value, NumberStyles.Any, _FormatProvider, out fuel)) {
							flightPlan.FuelTanks[fuelTank] = fuel;
						}

						break;
					}
				}
			}
		}

		private void LoadLoading(FlightPlan flightPlan) {
			XmlNodeList elements = SelectNodes("/flightPlan/loading/item");

			foreach (XmlNode element in elements) {
				String name = element.Attributes["name"].InnerText;
				String value = element.Attributes["value"].InnerText;

				foreach(var loadingStation in flightPlan.Aircraft.LoadingStations) {
					if (loadingStation.Name == name) {
						Double mass = 0;

						if (Double.TryParse(value, NumberStyles.Any, _FormatProvider, out mass)) {
							flightPlan.Loading[loadingStation] = mass;
						}

						break;
					}
				}
			}
		}

		private void LoadRoute(FlightPlan flightPlan) {
			XmlNodeList xmlWaypoints = SelectNodes("/flightPlan/waypoints/*");

			foreach (XmlElement xmlWaypoint in xmlWaypoints) {
				Double latitude = 0;
				Double longitude = 0;
				Country country = Country.Undefined;
				String name = String.Empty;

				Double.TryParse(xmlWaypoint.Attributes["latitude"].InnerText, NumberStyles.Any, _FormatProvider, out latitude);
				Double.TryParse(xmlWaypoint.Attributes["longitude"].InnerText, NumberStyles.Any, _FormatProvider, out longitude);
				Enum.TryParse<Country>(xmlWaypoint.Attributes["country"].InnerText, out country);
				name = xmlWaypoint.Attributes["name"].InnerText;

				if (xmlWaypoint.Name == "airfield") {
					String icao = xmlWaypoint.Attributes["icao"].InnerText;

					Int32 elevation = 0;
					Int32.TryParse(xmlWaypoint.Attributes["elevation"].InnerText, out elevation);

					Single frequency = 0;
					Single.TryParse(xmlWaypoint.Attributes["frequency"].InnerText, out frequency);

					XmlNodeList xmlRunways = xmlWaypoint.SelectNodes("runways/runway");
					Runway[] runways = new Runway[xmlRunways.Count];

					for(Int32 i = 0; i < xmlRunways.Count; i++) {
						XmlNode xmlRunway = xmlRunways[i];

						Int32 direction = 0;
						Int32.TryParse(xmlRunway.Attributes["direction"].InnerText, out direction);

						Int32 length = 0;
						Int32.TryParse(xmlRunway.Attributes["length"].InnerText, out length);

						Runway.SurfaceType surface = Runway.SurfaceType.Undefined;
						Enum.TryParse<Runway.SurfaceType>(xmlRunway.Attributes["surface"].InnerText, out surface);

						runways[i] = new Runway(direction, length, surface);
					}

					flightPlan.Route.AddWaypoint(new Airfield(name, icao, new Coordinate(latitude, longitude), new Elevation(Altitude.Unit.Feet, elevation), runways, new Frequency(frequency), country));
				}
				else if (xmlWaypoint.Name == "waypoint") {
					Waypoint waypoint = new Waypoint(new Coordinate(latitude, longitude), country);
					waypoint.Name = name;
					flightPlan.Route.AddWaypoint(waypoint);
				}
			}

			XmlNodeList xmlLegs = SelectNodes("/flightPlan/legs/leg");

			for(Int32 i = 0; i < xmlLegs.Count; i++) {
				XmlElement xmlLeg = (XmlElement)xmlLegs[i];
				Leg leg = flightPlan.Route.Legs.ElementAt(i);

				leg.Altitude = Altitude.Parse(xmlLeg.Attributes["altitude"].InnerText);

				Int32 windDirection = 0;
				Int32.TryParse(xmlLeg.Attributes["wind-direction"].InnerText, out windDirection);

				Int32 windSpeed = 0;
				Int32.TryParse(xmlLeg.Attributes["wind-speed"].InnerText, out windSpeed);

				leg.Wind = new Wind() { Direction = windDirection, Speed = windSpeed };

				Int32 gafor = 0;
				Int32.TryParse(xmlLeg.Attributes["gafor"].InnerText, out gafor);
				leg.GaforArea = gafor;
			}
		}
	}
}
