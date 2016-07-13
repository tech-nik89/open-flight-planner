using FlightPlanner.Configuration;
using System;
using System.Threading;

namespace FlightPlanner.UserInterface {
	public partial class MainForm {

		private void ApplyLocalization() {

			if (!String.IsNullOrWhiteSpace(Config.Current.Language) && Config.SupportedCultures.ContainsKey(Config.Current.Language)) {
				Thread.CurrentThread.CurrentCulture = Config.SupportedCultures[Config.Current.Language];
				Thread.CurrentThread.CurrentUICulture = Config.SupportedCultures[Config.Current.Language];
			}

			tslStatus.Text = Strings.Ready;

			mnuFile.Text = Strings.File;
			mnuFileNew.Text = Strings.New;
			mnuFileOpen.Text = Strings.Open;
			mnuFileSave.Text = Strings.Save;
			mnuFileSaveAs.Text = Strings.SaveAs;
			mnuFileExit.Text = Strings.Exit;
			mnuFileSettings.Text = Strings.Settings;

			mnuRoute.Text = Strings.Route;
			mnuRouteWaypointAddFree.Text = Strings.RouteWaypointAddFree;
			mnuRouteWaypointAddKnown.Text = Strings.RouteWaypointAddKnown;
			mnuRouteWaypointsMoveUp.Text = Strings.RouteWaypointsMoveUp;
			mnuRouteWaypointsMoveDown.Text = Strings.RouteWaypointsMoveDown;
			mnuRouteWaypointsRemove.Text = Strings.RouteWaypointsRemove;
			mnuRouteGlobalSettings.Text = Strings.RouteGlobalSettings;
			mnuRouteUpperWind.Text = Strings.RouteUpperWind;
			mnuRouteExport.Text = Strings.Export;

			mnuAircraft.Text = Strings.Aircraft;
			mnuAircraftManage.Text = Strings.AircraftsManage;
			mnuAircraftMassAndBalance.Text = Strings.MassAndBalance;

			mnuBriefing.Text = Strings.Briefing;
			mnuBriefingWeather.Text = Strings.Weather;
			mnuBriefingNotams.Text = Strings.Notams;
			mnuBriefingExport.Text = Strings.Export;

			mnuInfoAbout.Text = Strings.Info;

			tsbOpen.Text = Strings.Open;
			tsbSave.Text = Strings.Save;

			tsbRouteAddKnownWaypoint.Text = Strings.RouteWaypointAddKnown;
			tsbRouteAddFreeWaypoint.Text = Strings.RouteWaypointAddFree;
			tsbRouteRemoveSelectedWaypoints.Text = Strings.RouteWaypointsRemove;

			tsbWaypointUp.Text = Strings.RouteWaypointsMoveUp;
			tsbWaypointDown.Text = Strings.RouteWaypointsMoveDown;

			tsbMassAndBalance.Text = Strings.MassAndBalance;

			tsbZoomIn.Text = Strings.ZoomIn;
			tsbZoomOut.Text = Strings.ZoomOut;

			clnWaypointName.Text = Strings.Waypoint;
			clnWaypointLat.Text = Strings.Latitude;
			clnWaypointLng.Text = Strings.Longitude;

			tabMap.Text = Strings.Map;
			tabLegs.Text = Strings.Legs;

			clnLegName.Text = Strings.Name;
			clnLegDistance.Text = Strings.Distance;
			clnLegMC.Text = Strings.MagneticTrack;
			clnLegMH.Text = Strings.MagneticHeading;
		}

	}
}
