using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace FlightPlanner.Tools {
    public static class Utilities {

		private static readonly IFormatProvider _FormatProvider = new CultureInfo("en-US");

		public static Double ParseDoubleForGrid(Object input) {
			if (input is Double) {
				return (Double)input;
			}

			if (input == null) {
				return 0;
			}

			String str = input.ToString();
			Double value = 0;

			Double.TryParse(str.Trim().Replace(",", "."), NumberStyles.Number, _FormatProvider, out value);

			return value;
		}

		public static Int32 ParseIntForGrid(Object input) {
			if (input is Int32) {
				return (Int32)input;
			}

			if (input == null) {
				return 0;
			}

			String str = input.ToString();
			Int32 value = 0;

			Int32.TryParse(str.Trim().Replace(",", "."), NumberStyles.Number, _FormatProvider, out value);

			return value;
		}

		public static Double ToRadians(Double val) {
			return (Math.PI / 180) * val;
		}

		public static Double ToDegrees(Double val) {
			return (180 / Math.PI) * val;
		}

		public static Double Interpolate(Double x, Double x0, Double x1, Double y0, Double y1) {
			if ((x1 - x0) == 0) {
				return (y0 + y1) / 2;
			}

			return y0 + (x - x0) * (y1 - y0) / (x1 - x0);
		}

		public static TimeSpan RoundToMinutes(TimeSpan timeSpan) {
			Int32 minutes = ((Int32)timeSpan.TotalMinutes) + (timeSpan.Seconds > 30 ? 1 : 0);
			return TimeSpan.FromMinutes(minutes);
		}

		public static String RemoveInvalidFileNameCharacters(String fileName) {

			foreach (Char c in System.IO.Path.GetInvalidFileNameChars()) {
				fileName = fileName.Replace(c, '_');
			}

			return fileName;
		}

        public static IEnumerable<Type> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class {
            return Assembly.GetAssembly(typeof(T))
                .GetTypes()
                .Where(myType => myType.IsClass
                    && !myType.IsAbstract
                    && myType.IsSubclassOf(typeof(T)));
        }

		public static String GetVersion() {
			Version version = Assembly.GetExecutingAssembly().GetName().Version;
			return String.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Revision);
		}
    }
}
