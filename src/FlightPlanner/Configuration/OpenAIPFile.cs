using FlightPlanner.Parser;
using System;

namespace FlightPlanner.Configuration {
	public class OpenAIPFile : DataFile {

		public override String FileName {
			get {
				return String.Format("AIP_{0}.aip", InternalFileName);
			}
		}

		public override String FileExtension {
			get {
				return "aip";
			}
		}

		public OpenAIPFile() {
		}

		public override Object Clone() {
			OpenAIPFile file = new OpenAIPFile() {
				Name = Name,
				Path = Path,
				Visible = Visible
			};

			return file;
		}

		public override Parser.Parser GetParser() {
			return new OpenAIPParser(GetFileContent());
		}
	}
}
