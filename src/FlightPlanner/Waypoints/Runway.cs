using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlightPlanner.Waypoints {
	public class Runway {

		private readonly Int32 _Direction;
		private readonly Int32 _Length;
		private readonly SurfaceType _Surface;

		public Runway(Int32 direction, Int32 length, SurfaceType surface) {
			_Direction = direction;
			_Length = length;
			_Surface = surface;
		}

		public SurfaceType Surface {
			get {
				return _Surface;
			}
		}

		public Int32 Direction {
			get {
				return _Direction;
			}
		}

		public Int32 ReverseDirection {
			get {
				Int32 reverseDirection = _Direction + 18;

				if (reverseDirection > 36) {
					reverseDirection -= 36;
				}

				return reverseDirection;
			}
		}

		public String DirectionInfo {
			get {
				return String.Format("{0:00} / {1:00}", Direction, ReverseDirection);
			}
		}

		public Int32 Length {
			get {
				return _Length;
			}
		}

		public enum SurfaceType {
			Undefined,
			Asphalt,
			Concrete,
			Loam,
			Sand,
			Clay,
			Grass,
			Gravel,
			Dirt
		}

	}
}
