using FlightPlanner.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FlightPlanner.Plugins {
	public class PluginManager {

		private static List<IPlugin> _Plugins;

		private static IEnrouteWeatherSource _EnrouteWeatherSource;
		private static IMetarWeatherSource _MetarWeatherSource;
		private static INotamSource _NotamSource;

		public static IEnrouteWeatherSource EnrouteWeatherSource {
			get {
				if (_EnrouteWeatherSource == null) {
					_EnrouteWeatherSource = GetPluginType<IEnrouteWeatherSource>();
				}

				return _EnrouteWeatherSource;
			}
			set {
				_EnrouteWeatherSource = value;
				SetPluginType<IEnrouteWeatherSource>(_EnrouteWeatherSource);
			}
		}

		public static IMetarWeatherSource MetarWeatherSource {
			get {
				if (_MetarWeatherSource == null) {
					_MetarWeatherSource = GetPluginType<IMetarWeatherSource>();
				}

				return _MetarWeatherSource;
			}
			set {
				_MetarWeatherSource = value;
				SetPluginType<IMetarWeatherSource>(_MetarWeatherSource);
			}
		}

		public static INotamSource NotamSource {
			get {
				if (_NotamSource == null) {
					_NotamSource = GetPluginType<INotamSource>();
				}

				return _NotamSource;
			}
			set {
				_NotamSource = value;
				SetPluginType<INotamSource>(_NotamSource);
			}
		}

		public static List<IPlugin> GetPlugins() {
			if (_Plugins != null) {
				return _Plugins;
			}

			_Plugins = new List<IPlugin>();

			DirectoryInfo directory = new DirectoryInfo(Environment.CurrentDirectory);
			FileInfo[] files = directory.GetFiles("*.FlightPlanner.Plugin.dll");
			
			foreach (FileInfo file in files) {
				try {
					Assembly assembly = Assembly.LoadFile(file.FullName);
					Type[] types = assembly.GetTypes();
					
					foreach (Type type in types) {
						if (type.GetInterfaces().Contains(typeof(IPlugin))) {
							IPlugin instance = (IPlugin)Activator.CreateInstance(type);
							_Plugins.Add(instance);
							
							if (instance.Configurable) {
								ApplySettings(instance);
							}
						}
					}
				}
				catch {
				}
			}

			return _Plugins;
		}

		private static void SetPluginType<T>(IPlugin plugin) {
			Type interfaceType = typeof(T);

			if (plugin != null) {
				Type pluginType = plugin.GetType();

				Config.Current.Plugins[interfaceType.Name] = String.Concat(pluginType.FullName, ", ", pluginType.Assembly.FullName);
			}
			else {
				Config.Current.Plugins[interfaceType.Name] = String.Empty;
			}

			Config.Save();
		}

		private static T GetPluginType<T>() {
			Type interfaceType = typeof(T);

			if (!Config.Current.Plugins.ContainsKey(interfaceType.Name)) {
				return default(T);
			}

			try {
				Type type = Type.GetType(Config.Current.Plugins[interfaceType.Name]);
				return (T)Activator.CreateInstance(type);
			}
			catch {
				return default(T);
			}
		}

		private static void ApplySettings(IPlugin plugin) {
			var settings = Config.Current.PluginConfiguration;
			if (settings.ContainsKey(plugin.Name)) {
				foreach (var item in settings[plugin.Name]) {
					plugin.Configuration[item.Key] = item.Value;
				}
			}
		}
	}
}
