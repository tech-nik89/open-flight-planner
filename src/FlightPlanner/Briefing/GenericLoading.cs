using System;
using System.Collections;
using System.Collections.Generic;

namespace FlightPlanner.Briefing {
	public abstract class GenericLoading<T> : IEnumerable<KeyValuePair<T, Double>> {

		private readonly Dictionary<T, Double> _Data;
		private readonly FlightPlan _FlightPlan;

		public GenericLoading(FlightPlan flightPlan) {
			_Data = new Dictionary<T, Double>();
			_FlightPlan = flightPlan;
		}

		public Boolean ContainsKey(T key) {
			return _Data.ContainsKey(key);
		}

		public IEnumerator<KeyValuePair<T, Double>> GetEnumerator() {
			return _Data.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return _Data.GetEnumerator();
		}

		public Double this[T key] {
			get {
				return _Data[key];
			}
			set {
				_Data[key] = value;
				_FlightPlan.Dirty = true;
			}
		}
	}
}
