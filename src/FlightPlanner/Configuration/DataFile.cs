using FlightPlanner.Tools;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FlightPlanner.Configuration {

	[Serializable]
	public abstract class DataFile : ICloneable {

        private static IEnumerable<Type> _DataFiles;

		public String Path { get; set; }

		public String Name { get; set; }

		public Boolean Visible { get; set; }

		public abstract String FileExtension { get; }

		public String InternalFileName { get; set; }

		[JsonIgnore]
		public abstract String FileName { get; }

		public abstract Object Clone();

		public abstract Parser.Parser GetParser();

		[JsonIgnore]
		public String LocalPath {
			get {
				return System.IO.Path.Combine(Config.AppDataDirectory, FileName);
			}
		}

		[JsonIgnore]
		public Boolean IsOnlineFile {
			get {
				return !String.IsNullOrWhiteSpace(Path) && Path.StartsWith("http", StringComparison.InvariantCultureIgnoreCase);
			}
		}

		public DataFile() {
			InternalFileName = Guid.NewGuid().ToString();
		}

		public String GetFileContent() {
			String localPath = LocalPath;

			if (!File.Exists(localPath)) {
				if (IsOnlineFile) {
					WebClient webClient = new WebClient();
					String contents = webClient.DownloadString(Path);
					File.WriteAllText(localPath, contents);
				}
				else {
					CopyLocal();
				}
			}

			return File.ReadAllText(localPath);
		}

		public void CopyLocal() {
			if (IsOnlineFile) {
				return;
			}

			File.Copy(Path, LocalPath, true);
		}

        public static IEnumerable<Type> DataFileTypes {
            get {
                if (_DataFiles == null) {
                    _DataFiles = Utilities.GetEnumerableOfType<DataFile>();
                }

                return _DataFiles;
            }
        }

        public static DataFile CreateDataFile(Int32 index) {
            try {
                return CreateDataFile(DataFileTypes.ElementAt(index));
            }
            catch {
                return null;
            }
        }

        public static DataFile CreateDataFile(Type type) {
            try {
                return (DataFile)Activator.CreateInstance(type);
            }
            catch {
                return null;
            }
        }
    }
}
