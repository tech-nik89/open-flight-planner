using FlightPlanner.Briefing;
using FlightPlanner.Configuration;
using FlightPlanner.Exceptions;
using FlightPlanner.Export;
using FlightPlanner.Interfaces;
using FlightPlanner.Plugins;
using FlightPlanner.Ressources;
using FlightPlanner.Tools;
using FlightPlanner.UserInterface.Dialogs;
using FlightPlanner.Waypoints;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface {
	public partial class MainForm : Form {

		private Boolean _ExportPluginsInitialized;
        private FlightPlan _ActiveFlightPlan;

		private String _ActivePlanPath;
		
        private FlightPlan ActiveFlightPlan {
            get {
                return _ActiveFlightPlan;
            }
            set {
                _ActiveFlightPlan = value;
                mapMain.Route = _ActiveFlightPlan.Route;
				mapMain.UpdateRoute();
            }
        }

		public MainForm() {
			InitializeComponent();
            Config.Load();

			ApplyLocalization();
            UpdateSettings();

            ActiveFlightPlan = new FlightPlan();
			UpdateFormTitle();

            mapMain.OnRouteChanged += MapMain_RouteChanged;
			mapMain.OnShowAirfieldDetails += MapMain_OnShowAirfieldDetails;
			mapMain.MouseEnter += MapMain_MouseEnter;

			pgbProgress.Visible = false;
		}

		private void MapMain_OnShowAirfieldDetails(object sender, MapControl.EventArguments.ShowAirfieldDetailsEventArgs e) {
			AirfieldDetailsForm form = new AirfieldDetailsForm(e.Airfield);
			form.ShowDialog();
		}

		private void MapMain_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e) {
			mapMain.Focus();
		}

		private void UpdateSettings() {
            RessourceManager.LoadResources();
            mapMain.UpdateResources(Config.Current.Countries.ToArray());
			mapMain.Provider = Config.Current.MapType;
        }

        private void MapMain_RouteChanged(object sender, EventArgs e) {
            UpdateRoute();
        }

        private void UpdateRoute() {
            lvwWaypoints.VirtualListSize = 0;
            lvwWaypoints.VirtualListSize = ActiveFlightPlan.Route.WaypointCount;
            
            lvwLegs.VirtualListSize = 0;
            lvwLegs.VirtualListSize = ActiveFlightPlan.Route.LegCount;
        }

        private void lvwWaypoints_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            Waypoint waypoint = ActiveFlightPlan.Route[e.ItemIndex];

            String[] fields = new String[] {
                waypoint.Name,
                waypoint.Latitude.ToString("00.000"),
                waypoint.Longitude.ToString("000.000")
            };

            e.Item = new ListViewItem(fields);
        }

        private void lvwLegs_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            Leg leg = ActiveFlightPlan.Route.Legs.ElementAt(e.ItemIndex);

            String[] fields = new String[] {
                leg.Name,
                leg.Distance.ToString(),
                Formatting.FormatDirection(leg.MagneticCourse),
                Formatting.FormatDirection(leg.MagneticHeading)
            };

            e.Item = new ListViewItem(fields);
        }

        private void mnuRouteWaypointAddFree_Click(object sender, EventArgs e) {
            mapMain.AddWaypointMode = !mapMain.AddWaypointMode;
            mnuRouteWaypointAddFree.Checked = mapMain.AddWaypointMode;
			tsbRouteAddFreeWaypoint.Checked = mapMain.AddWaypointMode;
        }

        private void mnuRouteWaypointAddKnown_Click(object sender, EventArgs e) {
            WaypointForm form = new WaypointForm();
            DialogResult result = form.ShowDialog();

            if (result != DialogResult.OK) {
                return;
            }

            mapMain.Route.AddWaypoint(form.Waypoint);
            mapMain.UpdateRoute();
        }

        private void mnuRouteWaypointRemove_Click(object sender, EventArgs e) {
            if (lvwWaypoints.SelectedIndices.Count == 0) {
                return;
            }

            Int32[] indices = new Int32[lvwWaypoints.SelectedIndices.Count];
            lvwWaypoints.SelectedIndices.CopyTo(indices, 0);

            mapMain.Route.RemoveWaypoints(indices);
            mapMain.UpdateRoute();
        }

        private void lvwLegs_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvwLegs.SelectedIndices.Count == 0) {
                return;
            }

            loLegOptions.Leg = ActiveFlightPlan.Route.Legs.ElementAt(lvwLegs.SelectedIndices[0]);
        }

        private void mnuFileExit_Click(object sender, EventArgs e) {
            Close();
        }

        private void mnuAircraftManage_Click(object sender, EventArgs e) {
            ManageAircraftsForm form = new ManageAircraftsForm(ActiveFlightPlan);
            form.ShowDialog();
        }

        private void mnuRouteGlobalSettings_Click(object sender, EventArgs e) {
            RouteGlobalSettingsForm form = new RouteGlobalSettingsForm();
            DialogResult result = form.ShowDialog();

            if (result != DialogResult.OK) {
                return;
            }
            
            if (form.ApplyAltitude) {
                ActiveFlightPlan.Route.ApplyGlobalAltitude(form.Altitude);
            }

            if (form.ApplyWind) {
                ActiveFlightPlan.Route.ApplyGlobalWind(form.Wind);
            }

			if (form.ApplyGaforArea) {
				ActiveFlightPlan.Route.ApplyGlobalGaforArea(form.GaforArea);
			}
        }

        private void mnuFileSettings_Click(object sender, EventArgs e) {
            SettingsForm form = new SettingsForm();
            form.ShowDialog();

			if (form.Changed) {
				UpdateSettings();
			}
        }

        private void tsbZoomIn_Click(object sender, EventArgs e) {
            mapMain.ZoomIn();
        }

        private void tsbZoomOut_Click(object sender, EventArgs e) {
            mapMain.ZoomOut();
        }

        private void mnuAircraftMassAndBalance_Click(object sender, EventArgs e) {
            MassAndBalanceForm form = new MassAndBalanceForm(ActiveFlightPlan);
            form.ShowDialog();
        }

        private void mnuRouteWaypointsMoveUp_Click(object sender, EventArgs e) {
            MoveWaypoints(WaypointMoveDirection.Up);
        }

        private void mnuRouteWaypointsMoveDown_Click(object sender, EventArgs e) {
            MoveWaypoints(WaypointMoveDirection.Down);
        }

        private void MoveWaypoints(WaypointMoveDirection direction) {
            if (lvwWaypoints.SelectedIndices.Count == 0) {
                return;
            }

            Int32[] indices = new Int32[lvwWaypoints.SelectedIndices.Count];
            lvwWaypoints.SelectedIndices.CopyTo(indices, 0);

            List<Waypoint> waypoints = new List<Waypoint>();
            foreach (Int32 index in indices) {
                waypoints.Add(ActiveFlightPlan.Route[index]);
            }

            ActiveFlightPlan.Route.MoveWaypoints(indices, direction);
            mapMain.UpdateRoute();

            foreach (Waypoint waypoint in waypoints) {
                Int32 newIndex = ActiveFlightPlan.Route.GetWaypointIndex(waypoint);
                if (newIndex > -1) {
                    lvwWaypoints.SelectedIndices.Add(newIndex);
                }
            }
        }

		private void mnuBriefingWeather_Click(object sender, EventArgs e) {
			WeatherBriefingForm form = new WeatherBriefingForm(ActiveFlightPlan);
			form.ShowDialog();
		}

		private void mnuBriefingNotams_Click(object sender, EventArgs e) {
			NotamsForm form = new NotamsForm(ActiveFlightPlan);
			form.ShowDialog();
		}

		private void mnuRouteUpperWind_Click(object sender, EventArgs e) {
			ActiveFlightPlan.Route.ApplyUpperWind(PluginManager.EnrouteWeatherSource);

			if (lvwLegs.SelectedIndices.Count > 0) {
				loLegOptions.Leg = ActiveFlightPlan.Route.Legs.ElementAt(lvwLegs.SelectedIndices[0]);
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
			Config.Current.WindowState = (Int32)WindowState;
			Config.Current.WindowPosition = new System.Windows.Point(Left, Top);
			Config.Current.WindowSize = new System.Windows.Size(Width, Height);

			Config.Current.MapPosition = mapMain.Position;
			Config.Current.MapZoom = mapMain.Zoom;

			Config.Save();
		}

		private void MainForm_Shown(object sender, EventArgs e) {
			WindowState = (FormWindowState)Config.Current.WindowState;
			Left = (Int32)Config.Current.WindowPosition.X;
			Top = (Int32)Config.Current.WindowPosition.Y;
			Width = (Int32)Config.Current.WindowSize.Width;
			Height = (Int32)Config.Current.WindowSize.Height;

			if (Config.Current.MapPosition != null) {
				mapMain.Position = Config.Current.MapPosition;
			}
			if (Config.Current.MapZoom > 0) {
				mapMain.Zoom = Config.Current.MapZoom;
			}

			SuggestDefaultRessources();
		}

		private void SuggestDefaultRessources() {
			if (!Config.Current.SuggestLoadingDefaultRessources) {
				return;
			}

			DialogResult result = MessageBox.Show(
				Strings.SuggestLoadingDefaultRessourcesMessage,
				Strings.SuggestLoadingDefaultRessourcesTitle,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			if (result != DialogResult.Yes) {
				return;
			}

			Config.Current.LoadDefaultRessources();
			UpdateSettings();
		}

		private void mnuBriefing_DropDownOpening(object sender, EventArgs e) {
			if (_ExportPluginsInitialized) {
				return;
			}

			List<IFlightLogExport> plugins = PluginManager.GetPlugins().Where(p => p is IFlightLogExport).Cast<IFlightLogExport>().ToList();

			mnuBriefingExport.DropDownItems.Clear();
			mnuBriefingExport.Enabled = plugins.Any();
			
			foreach (IFlightLogExport plugin in plugins) {
				plugin.ProgressChanged += Export_ProgressChanged;

				ToolStripItem item = new ToolStripMenuItem(plugin.Name);
				item.Tag = plugin;
				item.Click += mnuFileExportChild_Click;

				mnuBriefingExport.DropDownItems.Add(item);
			}

			_ExportPluginsInitialized = true;
		}
		
		private void mnuFileExportChild_Click(object sender, EventArgs e) {
			ToolStripItem item = (ToolStripItem)sender;
			IFlightLogExport plugin = (IFlightLogExport)item.Tag;

			sfdSave.Filter = plugin.Filter;
			DialogResult result = sfdSave.ShowDialog();

			if (result != DialogResult.OK) {
				return;
			}

			pgbProgress.Visible = true;
			foreach (ToolStripItem child in mnuBriefingExport.DropDownItems) {
				child.Enabled = false;
			}

			BackgroundWorker worker = new BackgroundWorker();

			worker.DoWork += (s, args) => {
				plugin.Export(ActiveFlightPlan, sfdSave.FileName);
			};

			worker.RunWorkerCompleted += (s, args) => {
				foreach (ToolStripItem child in mnuBriefingExport.DropDownItems) {
					child.Enabled = true;
				}
				pgbProgress.Visible = false;
			};

			worker.RunWorkerAsync();
		}

		private void Export_ProgressChanged(object sender, EventArgs e) {
			if (InvokeRequired) {
				BeginInvoke(new Action(() => {
					Export_ProgressChanged(sender, e);
				}));
			}
			else {
				IFlightLogExport plugin = (IFlightLogExport)sender;
				tslStatus.Text = plugin.CurrentStep;
				pgbProgress.Value = plugin.Progress;
			}
		}

		private void mnuFileNew_Click(object sender, EventArgs e) {
			_ActivePlanPath = String.Empty;
			ActiveFlightPlan = new FlightPlan();
		}

		private void mnuFileOpen_Click(object sender, EventArgs e) {
			OpenActiveFlightPlan();
		}

		private void mnuFileSave_Click(object sender, EventArgs e) {
			SaveActiveFlightPlan(false);
		}

		private void mnuFileSaveAs_Click(object sender, EventArgs e) {
			SaveActiveFlightPlan(true);
		}

		private void SaveActiveFlightPlan(Boolean saveAs) {

			String path = null;

			if (!saveAs && !String.IsNullOrWhiteSpace(_ActivePlanPath) && File.Exists(_ActivePlanPath)) {
				path = _ActivePlanPath;
				sfdSave.FileName = path;
			}
			else { 
				sfdSave.Filter = FlightPlan.Filter;
				DialogResult result = sfdSave.ShowDialog();

				if (result != DialogResult.OK) {
					return;
				}

				path = sfdSave.FileName;
			}

			try {
				FlightPlan.Save(ActiveFlightPlan, path);
				_ActivePlanPath = sfdSave.FileName;
				UpdateFormTitle();
			}
			catch (ArgumentException) {
				MessageBox.Show(Strings.SaveFlightPlanInvalidPathError, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception e) {
				String message = String.Format(Strings.SaveFlightPlanGeneralError, e.Message);
				MessageBox.Show(message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void OpenActiveFlightPlan() {
			ofdOpen.Filter = FlightPlan.Filter;
			DialogResult result = ofdOpen.ShowDialog();

			if (result != DialogResult.OK) {
				return;
			}

			try {
				FlightPlan flightPlan = FlightPlan.Load(ofdOpen.FileName);

				if (flightPlan != null) {
					ActiveFlightPlan = flightPlan;
					_ActivePlanPath = ofdOpen.FileName;
					UpdateFormTitle();
				}
			}
			catch (FileNotFoundException) {
				MessageBox.Show(Strings.FileNotFoundError, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (AircraftNotFoundException) {
				MessageBox.Show(Strings.LoadFlightPlanAircraftNotFoundError, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			catch (Exception e) {
				String message = String.Format(Strings.LoadFlightPlanGeneralError, e.Message);
				MessageBox.Show(message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void UpdateFormTitle() {
			String title = null;

			if (!String.IsNullOrWhiteSpace(_ActivePlanPath) && File.Exists(_ActivePlanPath)) {
				title = _ActivePlanPath;
			}
			else {
				title = String.Format("[{0}]", Strings.Unsaved);
			}

			Text = String.Format(Strings.WindowTitle, title, String.Empty);
		}

		private void mnuRouteExportGPX_Click(object sender, EventArgs e) {
			ExportRoute<GPXExporter>();
		}

		private void mnuRouteExportKML_Click(object sender, EventArgs e) {
			ExportRoute<KMLExporter>();
		}

		private void mnuRouteExportWaypointPlus_Click(object sender, EventArgs e) {
			ExportRoute<WaypointPlusExporter>();
		}

		private void ExportRoute<T>() where T : IRouteExporter {
			IRouteExporter exporter = (IRouteExporter)Activator.CreateInstance(typeof(T));

			sfdSave.Filter = exporter.Filter;
			DialogResult result = sfdSave.ShowDialog();

			if (result != DialogResult.OK) {
				return;
			}

			exporter.Export(ActiveFlightPlan, sfdSave.FileName);
		}

		private void mnuInfoAbout_Click(object sender, EventArgs e) {
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}
	}
}
