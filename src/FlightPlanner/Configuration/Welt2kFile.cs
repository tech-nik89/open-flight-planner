using FlightPlanner.Parser;
using System;

namespace FlightPlanner.Configuration {

	[Serializable]
	public class Welt2kFile : DataFile {

		public override String FileName {
			get {
				return String.Format("Welt2k_{0}.txt", InternalFileName);
			}
		}

		public override String FileExtension {
			get {
				return "txt";
			}
		}

		public Welt2kFile() {
		}

		public override Object Clone() {
			Welt2kFile file = new Welt2kFile() {
				Name = Name,
				Path = Path,
				Visible = Visible
			};

			return file;
		}

		public override Parser.Parser GetParser() {
			return new Welt2kParser(GetFileContent());
		}
	}
}
