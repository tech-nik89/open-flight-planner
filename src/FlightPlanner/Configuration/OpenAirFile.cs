using FlightPlanner.Parser;
using System;

namespace FlightPlanner.Configuration {

	[Serializable]
	public class OpenAirFile : DataFile, ICloneable {

		public override String FileExtension {
			get {
				return "txt";
			}
		}

		public override String FileName {
			get {
				return String.Format("OpenAir_{0}.txt", InternalFileName);
			}
		}

		public override Object Clone() {
			return new OpenAirFile() {
				Name = Name,
				Path = Path,
				Visible = Visible
			};
		}

		public override Parser.Parser GetParser() {
			return new OpenAirParser(GetFileContent());
		}
	}
}
