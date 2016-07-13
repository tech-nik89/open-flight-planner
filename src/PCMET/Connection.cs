using System;
using System.IO;
using System.Net;
using System.Text;

namespace FlightPlanner.PCMET {
	class Connection {

		public static String DownloadMetar() {
			return Download(Constants.MetarUri);
		}

		public static String DownloadTaf() {
			return Download(Constants.TafUri);
		}

		public static String DownloadGafor() {
			return Download(Constants.GaforUri);
		}

		public static Byte[] DownloadSignificantWeather(Int32 hour) {
			String url = String.Format(Constants.SignificantWeatherBaseUrl, hour);
			return DownloadBinary(new Uri(url));
		}

		private static String Download(Uri url) {
			String userName = (String)Constants.Configuration[Constants.SettingUserName];
			String password = (String)Constants.Configuration[Constants.SettingPassword];

			using (WebClient client = new WebClient()) {
				client.Encoding = Encoding.UTF8;
				client.Credentials = new NetworkCredential(userName, password);
				return client.DownloadString(url);
			}
		}

		private static Byte[] DownloadBinary(Uri url) {
			
			String userName = (String)Constants.Configuration[Constants.SettingUserName];
			String password = (String)Constants.Configuration[Constants.SettingPassword];

			using (WebClient client = new WebClient()) {
				client.Encoding = Encoding.UTF8;
				client.Credentials = new NetworkCredential(userName, password);
				return client.DownloadData(url);
			}
		}
	}
}
