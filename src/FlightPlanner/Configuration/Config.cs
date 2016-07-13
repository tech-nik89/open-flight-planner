using FlightPlanner.Aircrafts;
using FlightPlanner.Airspaces;
using FlightPlanner.Common;
using FlightPlanner.Waypoints;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;

namespace FlightPlanner.Configuration {
    public class Config {

		public static Config Current { get; private set; }

		public List<Aircraft> Aircrafts { get; private set; }

		public List<DataFile> RessourceFiles { get; private set; }
        
		public List<Country> Countries { get; set; }

		public Dictionary<String, String> Plugins { get; private set; }

		public Int32 WindowState { get; set; }

		public Point WindowPosition { get; set; }

		public Size WindowSize { get; set; }

		public String Language { get; set; }

		public String MapType { get; set; }

		public Coordinate MapPosition { get; set; }

		public Double MapZoom { get; set; }

		public Dictionary<String, Dictionary<String, Object>> PluginConfiguration { get; private set; }

		public List<AirspaceClass> VisibleAirspaces { get; set; }

		[JsonIgnore]
		public Boolean SuggestLoadingDefaultRessources {
			get {
				return RessourceFiles.Count == 0;
			}
		}

		public void LoadDefaultRessources() {
			RessourceFiles.Clear();

			Welt2kFile worldWaypoints = new Welt2kFile() {
				Name = "Woldwide Waypoints",
				Path = "http://www.segelflug.de/vereine/welt2000/download/WELT2000.TXT",
				Visible = true
			};
			
			OpenAirFile germanAirspaces = new OpenAirFile() {
				Name = "German Airspaces",
				Path = "http://www.daec.de/fileadmin/user_upload/files/2012/fachbereiche/luftraum/20151112_OpenAir.txt",
				Visible = true
			};

			RessourceFiles.Add(worldWaypoints);
			RessourceFiles.Add(germanAirspaces);

			Countries.Clear();
			Countries.Add(Country.Germany);

			Save();
		}

		public static Dictionary<String, CultureInfo> SupportedCultures { get; private set; } = new Dictionary<String, CultureInfo>() {
			{ "English", new CultureInfo("en-US") },
			{ "Deutsch", new CultureInfo("de-DE") }
		};

		private const String AppDirectoryName = "OpenFlightPlanner";

		private const String ConfigFileName = "config.json";
		private static String _FilePath;

		private static String _AppDataDirectory;
		public static String AppDataDirectory {
			get {
				if (String.IsNullOrEmpty(_AppDataDirectory)) {
					String appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
					String path = Path.Combine(appData, AppDirectoryName);

					if (!Directory.Exists(path)) {
						Directory.CreateDirectory(path);
					}

					_AppDataDirectory = path;
				}

				return _AppDataDirectory;
			}
		}

		private static String FilePath {
			get {
				if (String.IsNullOrWhiteSpace(_FilePath)) {
					_FilePath = Path.Combine(AppDataDirectory, ConfigFileName);
				}

				return _FilePath;
			}
		}

		private static readonly JsonSerializerSettings _SerializerSettings = new JsonSerializerSettings() {
			TypeNameHandling = TypeNameHandling.Auto
		};

		public Config() {
			Aircrafts = new List<Aircraft>();
			RessourceFiles = new List<DataFile>();
			Countries = new List<Country>();
			Plugins = new Dictionary<String, String>();
			PluginConfiguration = new Dictionary<String, Dictionary<String, Object>>();
			VisibleAirspaces = new List<AirspaceClass>();
		}

		public static void Load() {
			if (!File.Exists(FilePath)) {
				Current = new Config();
				return;
			}

			String content = File.ReadAllText(FilePath);
			Current = JsonConvert.DeserializeObject<Config>(content, _SerializerSettings);
		}

		public static void Save() {
			String content = JsonConvert.SerializeObject(Current, _SerializerSettings);
			File.WriteAllText(FilePath, content);
		}
	}
}
