using System;

namespace FlightPlanner.Tools {
    public static class Formatting {

        public static String FormatDirection(Int32 direction) {
            return String.Format("{0}°", direction);
        }

    }
}
