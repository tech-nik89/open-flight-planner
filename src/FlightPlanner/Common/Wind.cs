using FlightPlanner.Interfaces;
using System;
using System.Text;

namespace FlightPlanner.Common {
    public class Wind : ICloneable<Wind> {

		private Int32 _Direction;

		public Int32 Direction {
			get {
				return _Direction;
			}
			set {
				_Direction = value;

				while (_Direction > 360) {
					_Direction -= 360;
				}
			}
		}

		public Int32 Speed { get; set; }

		public Int32 GustSpeed { get; set; }

		public Boolean Variable { get; set; }

		public Wind() {
		}

		public override string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}° / {1} kt", Direction, Speed);

            if (GustSpeed > 0) {
                builder.AppendFormat(" G {0} kt", GustSpeed);
            }

            return builder.ToString();
		}

        public Wind Clone() {
            Wind wind = new Wind();

            wind.Direction = Direction;
            wind.Speed = Speed;
            wind.GustSpeed = GustSpeed;

            return wind;
        }
    }
}
