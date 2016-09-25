using FlightPlanner.Briefing;
using FlightPlanner.Common;
using FlightPlanner.Parser;
using FlightPlanner.Plugins;
using FlightPlanner.Units;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightPlanner.Waypoints {
    public class Route {

		private readonly List<Waypoint> _Waypoints;
		private readonly List<Leg> _Legs;
		private readonly FlightPlan _FlightPlan;

		public Route(FlightPlan flightPlan) {
			_FlightPlan = flightPlan;
			_Waypoints = new List<Waypoint>();
			_Legs = new List<Leg>();
		}

		public FlightPlan FlightPlan {
			get {
                return _FlightPlan;
            }
		}

		public IEnumerable<Waypoint> Waypoints {
			get {
				return _Waypoints;
			}
		}

		public void AddWaypoint(Waypoint waypoint) {
			_Waypoints.Add(waypoint);
			Int32 count = _Waypoints.Count;

			if (count - 1 > _Legs.Count) {
				_Legs.Add(new Leg(this, _Waypoints[count - 2], _Waypoints[count - 1]));
			}

			_FlightPlan.Dirty = true;
		}

		public Int32 WaypointCount {
			get {
				return _Waypoints.Count;
			}
		}

		public Waypoint this[Int32 index] {
			get {
				return _Waypoints[index];
			}
		}

		public void RemoveWaypoint(Int32 index) {
			RemoveWaypoints(new Int32[] { index });
		}

		public void RemoveWaypoints(Int32[] indices) {
			List<Waypoint> waypointsToRemove = new List<Waypoint>();
			
			foreach (Int32 index in indices) {
				waypointsToRemove.Add(_Waypoints[index]);

                if (_Legs.Any()) {
                    _Legs.RemoveAt(0);
                }
			}

			foreach (Waypoint waypoint in waypointsToRemove) {
				_Waypoints.Remove(waypoint);
			}
            
			ReassignWaypointsToLegs();
			_FlightPlan.Dirty = true;
		}

        public void MoveWaypoint(Int32 index, WaypointMoveDirection direction) {
            MoveWaypoints(new Int32[] { index }, direction);
        }

        public void MoveWaypoints(Int32[] indices, WaypointMoveDirection direction) {
            if (direction == WaypointMoveDirection.Down) {
                for (Int32 i = indices.Length - 1; i >= 0; i--) {
                    Int32 index = indices[i];
                    if (index >= WaypointCount - 1) {
                        continue;
                    }

                    Waypoint waypoint = _Waypoints[index];
                    _Waypoints.Remove(waypoint);
                    _Waypoints.Insert(index + 1, waypoint);
                }
            }
            else if (direction == WaypointMoveDirection.Up) {
                for (Int32 i = 0; i < indices.Length; i++) {
                    Int32 index = indices[i];
                    if (index <= 0) {
                        continue;
                    }

                    Waypoint waypoint = _Waypoints[index];
                    _Waypoints.Remove(waypoint);
                    _Waypoints.Insert(index - 1, waypoint);
                }
            }

            ReassignWaypointsToLegs();
			_FlightPlan.Dirty = true;
        }

		private void ReassignWaypointsToLegs() {
			for (Int32 i = 0; i < _Legs.Count; i++) {
				_Legs[i].UpdateWaypoints(_Waypoints[i], _Waypoints[i + 1]);
			}
		}

        public Int32 GetWaypointIndex(Waypoint waypoint) {
            return _Waypoints.IndexOf(waypoint);
        }

		public IEnumerable<Leg> Legs {
			get {
				return _Legs;
			}
		}

        public Int32 LegCount {
            get {
                return _Legs.Count;
            }
        }

		public Distance Distance {
			get {
                Double distance = 0;
				
				foreach (Leg leg in _Legs) {
					distance += leg.Distance.NauticalMiles;
				}

				return new Distance(Distance.Unit.NauticalMiles, distance);
			}
		}

		public Double TripFuel {
			get {
				Double tripFuel = 0;

				foreach (Leg leg in Legs) {
					tripFuel += leg.FuelConsumption;
				}

				return tripFuel;
			}
		}

		public TimeSpan TotalTime {
			get {
				TimeSpan totalTime = TimeSpan.Zero;

				foreach (Leg leg in _Legs) {
					totalTime += leg.Time;
				}

				return totalTime;
			}
		}

		public String TotalTimeFormatted {
			get {
				return TotalTime.ToString(@"hh\:mm");
			}
		}

        public void ApplyGlobalWind(Wind wind) {
            foreach (Leg leg in _Legs) {
                leg.Wind = wind.Clone();
            }

			_FlightPlan.Dirty = true;
        }

        public void ApplyGlobalAltitude(Altitude altitude) {
            foreach (Leg leg in _Legs) {
                leg.Altitude = altitude.Clone();
            }

			_FlightPlan.Dirty = true;
		}

		public void ApplyGlobalGaforArea(Int32 area) {
			foreach (Leg leg in _Legs) {
				leg.GaforArea = area;
			}

			_FlightPlan.Dirty = true;
		}

		public Boolean ApplyUpperWind(IEnrouteWeatherSource weatherSource) {
			var upperWind = weatherSource.GetUpperWind();

			if (!upperWind.Any()) {
				return false;
			}

			foreach (Leg leg in _Legs) {
				if (!upperWind.ContainsKey(leg.GaforArea)) {
					continue;
				}

				leg.Wind = IntercalateWindForAltitude(upperWind[leg.GaforArea], leg.Altitude);
			}

			_FlightPlan.Dirty = true;
			return true;
		}

		private static Wind IntercalateWindForAltitude(Dictionary<Altitude, Wind> winds, Altitude altitude) {
			if (winds.Count == 0) {
				return new Wind();
			}

			Dictionary<Altitude, Wind> orderedWinds = winds.OrderBy(w => w.Key.Feet).ToDictionary(i => i.Key, i => i.Value);
			if (altitude < orderedWinds.First().Key) {
				return orderedWinds.First().Value.Clone();
			}
			else if (altitude > orderedWinds.Last().Key) {
				return orderedWinds.Last().Value.Clone();
			}
			else {
				KeyValuePair<Altitude, Wind> upper = orderedWinds.Where(w => w.Key > altitude).First();
				KeyValuePair<Altitude, Wind> lower = orderedWinds.Where(w => w.Key < altitude).Last();

				Double altitudeDelta = upper.Key.Feet - lower.Key.Feet;
				Double valueOverLower = altitude.Feet - lower.Key.Feet;
				Double percent = valueOverLower / altitudeDelta;

				Int32 directionDelta = upper.Value.Direction - lower.Value.Direction;
				Int32 speedDelta = upper.Value.Speed - lower.Value.Speed;

				while(directionDelta > 360) {
					directionDelta -= 360;
				}

				while (directionDelta < 0) {
					directionDelta += 360;
				}

				return new Wind() {
					Direction = (Int32)Math.Round((Double)lower.Value.Direction + (directionDelta * percent)),
					Speed = (Int32)Math.Round((Double)lower.Value.Speed + (speedDelta * percent))
				};
			}
		}

		public Waypoint Departure {
			get {
				if (_Waypoints.Count == 0) {
					return null;
				}

				return _Waypoints[0];
			}
		}

		public Waypoint Destination {
			get {
				if (_Waypoints.Count == 0) {
					return null;
				}

				return _Waypoints[_Waypoints.Count - 1];
			}
		}
	}
}
