using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FlightPlanner.PCMET {
	class Constants {

		public static Dictionary<String, Object> Configuration { get; private set; } = new Dictionary<String, Object>();

		public const String DataSourceName = "PC_MET";

		public static readonly String BaseUri = "ftp://ftp.pcmet.de/{0}";

		public const String SettingUserName = "UserName";

		public const String SettingPassword = "Password";

		private const String MetarFileName = "sa_all.xml";

		private const String TafFileName = "taf_all.xml";

		private const String GaforFileName = "gafor2.xml";

		private const String SignificantWeatherBaseFileName = "llswc_dl_{0:00}.png";

		public static readonly Uri MetarUri = new Uri(String.Format(BaseUri, MetarFileName));

		public static readonly Uri TafUri = new Uri(String.Format(BaseUri, TafFileName));

		public static readonly Uri GaforUri = new Uri(String.Format(BaseUri, GaforFileName));

		public static readonly String SignificantWeatherBaseUrl = String.Format(BaseUri, SignificantWeatherBaseFileName);

		public static readonly Regex MetarWindRegex = new Regex(@"([0123]\d\d|VRB)(\d\d)(?:G(\d\d))?KT");

		public static readonly Regex MetarAltimeterRegex = new Regex(@"Q(\d{3,4})");

		public static readonly Regex MetarVisibilityRegex = new Regex(@"\s(\d{3,4})\s");

		public static readonly Regex MetarTemperatureDewpointRegex = new Regex(@"(\d+)/(\d+)");

		public static readonly Regex MetarCloudsRegex = new Regex(@"(FEW|BKN|SCT|OVC|NSC|CAVOK)(\d*)");

		public const Int32 GaforIntervalCount = 3;
	}
}
