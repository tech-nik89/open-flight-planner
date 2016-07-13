using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FlightPlanner.Aircrafts {
    public class CenterOfGravity : List<CenterOfGravityLimit> {

        public List<Point> GetLimitPoints() {
            List<Point> points = new List<Point>();

            if (!this.Any()) {
                return points;
            }

            List<CenterOfGravityLimit> limits = this.OrderByDescending(l => l.Mass).ToList();
            EnsureForwardLowerThanAft(limits);

            Int32 lastIndex = limits.Count - 1;

            points.Add(new Point(limits[0].ForwardLimit, limits[0].Mass));

            for (Int32 i = 0; i < limits.Count; i++) {
                points.Add(new Point(limits[i].AftLimit, limits[i].Mass));
            }

            points.Add(new Point(limits[lastIndex].ForwardLimit, limits[lastIndex].Mass));
            
            for (Int32 i = limits.Count - 2; i > 0; i--) {
                points.Add(new Point(limits[i].ForwardLimit, limits[i].Mass));
            }

            points.Add(points[0]);

            return points;
        }

        private static void EnsureForwardLowerThanAft(List<CenterOfGravityLimit> limits) {

        }
    }
}
