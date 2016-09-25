namespace FlightPlanner.UserInterface {
	partial class MainForm {
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileNew = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSep6 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSep5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSep3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRoute = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRouteWaypointAddFree = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRouteWaypointAddKnown = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuRouteWaypointsMoveUp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRouteWaypointsMoveDown = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSep1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuRouteWaypointsRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSep9 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuRouteWaypointDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSep2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuRouteGlobalSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRouteUpperWind = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuRouteExport = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRouteExportGPX = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRouteExportKML = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRouteExportWaypointPlus = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAircraft = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuAircraftManage = new System.Windows.Forms.ToolStripMenuItem();
			this.tsSep7 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuAircraftMassAndBalance = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuBriefing = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuBriefingWeather = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuBriefingNotams = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuBriefingExport = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuInfo = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuInfoAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.scMain = new System.Windows.Forms.SplitContainer();
			this.lvwWaypoints = new System.Windows.Forms.ListView();
			this.clnWaypointName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnWaypointLat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnWaypointLng = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmsWaypoint = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmsWaypointDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.tabRoute = new System.Windows.Forms.TabControl();
			this.tabMap = new System.Windows.Forms.TabPage();
			this.ehMapMain = new System.Windows.Forms.Integration.ElementHost();
			this.mapMain = new FlightPlanner.MapControl.Map();
			this.tabLegs = new System.Windows.Forms.TabPage();
			this.scLegs = new System.Windows.Forms.SplitContainer();
			this.lvwLegs = new System.Windows.Forms.ListView();
			this.clnLegName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnLegDistance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnLegMC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnLegMH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnLegTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbOpen = new System.Windows.Forms.ToolStripButton();
			this.tsbSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbRouteAddKnownWaypoint = new System.Windows.Forms.ToolStripButton();
			this.tsbRouteAddFreeWaypoint = new System.Windows.Forms.ToolStripButton();
			this.tsbRouteRemoveSelectedWaypoints = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbWaypointUp = new System.Windows.Forms.ToolStripButton();
			this.tsbWaypointDown = new System.Windows.Forms.ToolStripButton();
			this.tsSep4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbMassAndBalance = new System.Windows.Forms.ToolStripButton();
			this.tsSep8 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbZoomIn = new System.Windows.Forms.ToolStripButton();
			this.tsbZoomOut = new System.Windows.Forms.ToolStripButton();
			this.sfdSave = new System.Windows.Forms.SaveFileDialog();
			this.ofdOpen = new System.Windows.Forms.OpenFileDialog();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.pgbProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.loLegOptions = new FlightPlanner.UserInterface.Controls.LegOptionsControl();
			this.cmsWaypointCenter = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
			this.scMain.Panel1.SuspendLayout();
			this.scMain.Panel2.SuspendLayout();
			this.scMain.SuspendLayout();
			this.cmsWaypoint.SuspendLayout();
			this.tabRoute.SuspendLayout();
			this.tabMap.SuspendLayout();
			this.tabLegs.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scLegs)).BeginInit();
			this.scLegs.Panel1.SuspendLayout();
			this.scLegs.Panel2.SuspendLayout();
			this.scLegs.SuspendLayout();
			this.tsMain.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuRoute,
            this.mnuAircraft,
            this.mnuBriefing,
            this.mnuInfo});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(825, 24);
			this.mnuMain.TabIndex = 1;
			this.mnuMain.Text = "menuStrip1";
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileNew,
            this.mnuFileOpen,
            this.tsSep6,
            this.mnuFileSave,
            this.mnuFileSaveAs,
            this.tsSep5,
            this.mnuFileSettings,
            this.tsSep3,
            this.mnuFileExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(37, 20);
			this.mnuFile.Text = "&File";
			this.mnuFile.DropDownOpening += new System.EventHandler(this.mnuBriefing_DropDownOpening);
			// 
			// mnuFileNew
			// 
			this.mnuFileNew.Name = "mnuFileNew";
			this.mnuFileNew.Size = new System.Drawing.Size(148, 22);
			this.mnuFileNew.Text = "New";
			this.mnuFileNew.Click += new System.EventHandler(this.mnuFileNew_Click);
			// 
			// mnuFileOpen
			// 
			this.mnuFileOpen.Image = global::FlightPlanner.UserInterface.Properties.Resources.Open;
			this.mnuFileOpen.Name = "mnuFileOpen";
			this.mnuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.mnuFileOpen.Size = new System.Drawing.Size(148, 22);
			this.mnuFileOpen.Text = "Open";
			this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
			// 
			// tsSep6
			// 
			this.tsSep6.Name = "tsSep6";
			this.tsSep6.Size = new System.Drawing.Size(145, 6);
			// 
			// mnuFileSave
			// 
			this.mnuFileSave.Image = global::FlightPlanner.UserInterface.Properties.Resources.Save;
			this.mnuFileSave.Name = "mnuFileSave";
			this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.mnuFileSave.Size = new System.Drawing.Size(148, 22);
			this.mnuFileSave.Text = "Save";
			this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
			// 
			// mnuFileSaveAs
			// 
			this.mnuFileSaveAs.Name = "mnuFileSaveAs";
			this.mnuFileSaveAs.Size = new System.Drawing.Size(148, 22);
			this.mnuFileSaveAs.Text = "Save As ...";
			this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
			// 
			// tsSep5
			// 
			this.tsSep5.Name = "tsSep5";
			this.tsSep5.Size = new System.Drawing.Size(145, 6);
			// 
			// mnuFileSettings
			// 
			this.mnuFileSettings.Image = global::FlightPlanner.UserInterface.Properties.Resources.Configuration;
			this.mnuFileSettings.Name = "mnuFileSettings";
			this.mnuFileSettings.Size = new System.Drawing.Size(148, 22);
			this.mnuFileSettings.Text = "Settings";
			this.mnuFileSettings.Click += new System.EventHandler(this.mnuFileSettings_Click);
			// 
			// tsSep3
			// 
			this.tsSep3.Name = "tsSep3";
			this.tsSep3.Size = new System.Drawing.Size(145, 6);
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.Name = "mnuFileExit";
			this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.mnuFileExit.Size = new System.Drawing.Size(148, 22);
			this.mnuFileExit.Text = "Exit";
			this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
			// 
			// mnuRoute
			// 
			this.mnuRoute.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRouteWaypointAddFree,
            this.mnuRouteWaypointAddKnown,
            this.toolStripSeparator2,
            this.mnuRouteWaypointsMoveUp,
            this.mnuRouteWaypointsMoveDown,
            this.tsSep1,
            this.mnuRouteWaypointsRemove,
            this.tsSep9,
            this.mnuRouteWaypointDetails,
            this.tsSep2,
            this.mnuRouteGlobalSettings,
            this.mnuRouteUpperWind,
            this.toolStripSeparator5,
            this.mnuRouteExport});
			this.mnuRoute.Name = "mnuRoute";
			this.mnuRoute.Size = new System.Drawing.Size(50, 20);
			this.mnuRoute.Text = "Route";
			// 
			// mnuRouteWaypointAddFree
			// 
			this.mnuRouteWaypointAddFree.Image = global::FlightPlanner.UserInterface.Properties.Resources.Add;
			this.mnuRouteWaypointAddFree.Name = "mnuRouteWaypointAddFree";
			this.mnuRouteWaypointAddFree.Size = new System.Drawing.Size(220, 22);
			this.mnuRouteWaypointAddFree.Text = "Add free waypoint";
			this.mnuRouteWaypointAddFree.Click += new System.EventHandler(this.mnuRouteWaypointAddFree_Click);
			// 
			// mnuRouteWaypointAddKnown
			// 
			this.mnuRouteWaypointAddKnown.Image = global::FlightPlanner.UserInterface.Properties.Resources.Waypoint;
			this.mnuRouteWaypointAddKnown.Name = "mnuRouteWaypointAddKnown";
			this.mnuRouteWaypointAddKnown.Size = new System.Drawing.Size(220, 22);
			this.mnuRouteWaypointAddKnown.Text = "Add known waypoint";
			this.mnuRouteWaypointAddKnown.Click += new System.EventHandler(this.mnuRouteWaypointAddKnown_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(217, 6);
			// 
			// mnuRouteWaypointsMoveUp
			// 
			this.mnuRouteWaypointsMoveUp.Image = global::FlightPlanner.UserInterface.Properties.Resources.Up;
			this.mnuRouteWaypointsMoveUp.Name = "mnuRouteWaypointsMoveUp";
			this.mnuRouteWaypointsMoveUp.Size = new System.Drawing.Size(220, 22);
			this.mnuRouteWaypointsMoveUp.Text = "Move waypoints up";
			this.mnuRouteWaypointsMoveUp.Click += new System.EventHandler(this.mnuRouteWaypointsMoveUp_Click);
			// 
			// mnuRouteWaypointsMoveDown
			// 
			this.mnuRouteWaypointsMoveDown.Image = global::FlightPlanner.UserInterface.Properties.Resources.Down;
			this.mnuRouteWaypointsMoveDown.Name = "mnuRouteWaypointsMoveDown";
			this.mnuRouteWaypointsMoveDown.Size = new System.Drawing.Size(220, 22);
			this.mnuRouteWaypointsMoveDown.Text = "Move waypoints down";
			this.mnuRouteWaypointsMoveDown.Click += new System.EventHandler(this.mnuRouteWaypointsMoveDown_Click);
			// 
			// tsSep1
			// 
			this.tsSep1.Name = "tsSep1";
			this.tsSep1.Size = new System.Drawing.Size(217, 6);
			// 
			// mnuRouteWaypointsRemove
			// 
			this.mnuRouteWaypointsRemove.Image = global::FlightPlanner.UserInterface.Properties.Resources.Delete;
			this.mnuRouteWaypointsRemove.Name = "mnuRouteWaypointsRemove";
			this.mnuRouteWaypointsRemove.Size = new System.Drawing.Size(220, 22);
			this.mnuRouteWaypointsRemove.Text = "Remove selected waypoints";
			this.mnuRouteWaypointsRemove.Click += new System.EventHandler(this.mnuRouteWaypointRemove_Click);
			// 
			// tsSep9
			// 
			this.tsSep9.Name = "tsSep9";
			this.tsSep9.Size = new System.Drawing.Size(217, 6);
			// 
			// mnuRouteWaypointDetails
			// 
			this.mnuRouteWaypointDetails.Name = "mnuRouteWaypointDetails";
			this.mnuRouteWaypointDetails.Size = new System.Drawing.Size(220, 22);
			this.mnuRouteWaypointDetails.Text = "Waypoint details";
			this.mnuRouteWaypointDetails.Click += new System.EventHandler(this.mnuRouteWaypointDetails_Click);
			// 
			// tsSep2
			// 
			this.tsSep2.Name = "tsSep2";
			this.tsSep2.Size = new System.Drawing.Size(217, 6);
			// 
			// mnuRouteGlobalSettings
			// 
			this.mnuRouteGlobalSettings.Name = "mnuRouteGlobalSettings";
			this.mnuRouteGlobalSettings.Size = new System.Drawing.Size(220, 22);
			this.mnuRouteGlobalSettings.Text = "Global route settings";
			this.mnuRouteGlobalSettings.Click += new System.EventHandler(this.mnuRouteGlobalSettings_Click);
			// 
			// mnuRouteUpperWind
			// 
			this.mnuRouteUpperWind.Name = "mnuRouteUpperWind";
			this.mnuRouteUpperWind.Size = new System.Drawing.Size(220, 22);
			this.mnuRouteUpperWind.Text = "Apply upper wind";
			this.mnuRouteUpperWind.Click += new System.EventHandler(this.mnuRouteUpperWind_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(217, 6);
			// 
			// mnuRouteExport
			// 
			this.mnuRouteExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRouteExportGPX,
            this.mnuRouteExportKML,
            this.mnuRouteExportWaypointPlus});
			this.mnuRouteExport.Name = "mnuRouteExport";
			this.mnuRouteExport.Size = new System.Drawing.Size(220, 22);
			this.mnuRouteExport.Text = "Export";
			// 
			// mnuRouteExportGPX
			// 
			this.mnuRouteExportGPX.Name = "mnuRouteExportGPX";
			this.mnuRouteExportGPX.Size = new System.Drawing.Size(133, 22);
			this.mnuRouteExportGPX.Text = "GPX";
			this.mnuRouteExportGPX.Click += new System.EventHandler(this.mnuRouteExportGPX_Click);
			// 
			// mnuRouteExportKML
			// 
			this.mnuRouteExportKML.Name = "mnuRouteExportKML";
			this.mnuRouteExportKML.Size = new System.Drawing.Size(133, 22);
			this.mnuRouteExportKML.Text = "KML";
			this.mnuRouteExportKML.Click += new System.EventHandler(this.mnuRouteExportKML_Click);
			// 
			// mnuRouteExportWaypointPlus
			// 
			this.mnuRouteExportWaypointPlus.Name = "mnuRouteExportWaypointPlus";
			this.mnuRouteExportWaypointPlus.Size = new System.Drawing.Size(133, 22);
			this.mnuRouteExportWaypointPlus.Text = "Waypoint+";
			this.mnuRouteExportWaypointPlus.Click += new System.EventHandler(this.mnuRouteExportWaypointPlus_Click);
			// 
			// mnuAircraft
			// 
			this.mnuAircraft.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAircraftManage,
            this.tsSep7,
            this.mnuAircraftMassAndBalance});
			this.mnuAircraft.Name = "mnuAircraft";
			this.mnuAircraft.Size = new System.Drawing.Size(58, 20);
			this.mnuAircraft.Text = "Aircraft";
			// 
			// mnuAircraftManage
			// 
			this.mnuAircraftManage.Name = "mnuAircraftManage";
			this.mnuAircraftManage.Size = new System.Drawing.Size(168, 22);
			this.mnuAircraftManage.Text = "Manage aircrafts";
			this.mnuAircraftManage.Click += new System.EventHandler(this.mnuAircraftManage_Click);
			// 
			// tsSep7
			// 
			this.tsSep7.Name = "tsSep7";
			this.tsSep7.Size = new System.Drawing.Size(165, 6);
			// 
			// mnuAircraftMassAndBalance
			// 
			this.mnuAircraftMassAndBalance.Image = global::FlightPlanner.UserInterface.Properties.Resources.Loading;
			this.mnuAircraftMassAndBalance.Name = "mnuAircraftMassAndBalance";
			this.mnuAircraftMassAndBalance.Size = new System.Drawing.Size(168, 22);
			this.mnuAircraftMassAndBalance.Text = "Mass and balance";
			this.mnuAircraftMassAndBalance.Click += new System.EventHandler(this.mnuAircraftMassAndBalance_Click);
			// 
			// mnuBriefing
			// 
			this.mnuBriefing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBriefingWeather,
            this.mnuBriefingNotams,
            this.toolStripSeparator3,
            this.mnuBriefingExport});
			this.mnuBriefing.Name = "mnuBriefing";
			this.mnuBriefing.Size = new System.Drawing.Size(60, 20);
			this.mnuBriefing.Text = "Briefing";
			this.mnuBriefing.DropDownOpening += new System.EventHandler(this.mnuBriefing_DropDownOpening);
			// 
			// mnuBriefingWeather
			// 
			this.mnuBriefingWeather.Image = global::FlightPlanner.UserInterface.Properties.Resources.Weather;
			this.mnuBriefingWeather.Name = "mnuBriefingWeather";
			this.mnuBriefingWeather.Size = new System.Drawing.Size(118, 22);
			this.mnuBriefingWeather.Text = "Weather";
			this.mnuBriefingWeather.Click += new System.EventHandler(this.mnuBriefingWeather_Click);
			// 
			// mnuBriefingNotams
			// 
			this.mnuBriefingNotams.Image = global::FlightPlanner.UserInterface.Properties.Resources.Notams;
			this.mnuBriefingNotams.Name = "mnuBriefingNotams";
			this.mnuBriefingNotams.Size = new System.Drawing.Size(118, 22);
			this.mnuBriefingNotams.Text = "Notams";
			this.mnuBriefingNotams.Click += new System.EventHandler(this.mnuBriefingNotams_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(115, 6);
			// 
			// mnuBriefingExport
			// 
			this.mnuBriefingExport.Name = "mnuBriefingExport";
			this.mnuBriefingExport.Size = new System.Drawing.Size(118, 22);
			this.mnuBriefingExport.Text = "Export";
			// 
			// mnuInfo
			// 
			this.mnuInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfoAbout});
			this.mnuInfo.Name = "mnuInfo";
			this.mnuInfo.Size = new System.Drawing.Size(24, 20);
			this.mnuInfo.Text = "?";
			// 
			// mnuInfoAbout
			// 
			this.mnuInfoAbout.Name = "mnuInfoAbout";
			this.mnuInfoAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.mnuInfoAbout.Size = new System.Drawing.Size(114, 22);
			this.mnuInfoAbout.Text = "Info";
			this.mnuInfoAbout.Click += new System.EventHandler(this.mnuInfoAbout_Click);
			// 
			// scMain
			// 
			this.scMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.scMain.Location = new System.Drawing.Point(0, 52);
			this.scMain.Name = "scMain";
			// 
			// scMain.Panel1
			// 
			this.scMain.Panel1.Controls.Add(this.lvwWaypoints);
			// 
			// scMain.Panel2
			// 
			this.scMain.Panel2.Controls.Add(this.tabRoute);
			this.scMain.Size = new System.Drawing.Size(825, 388);
			this.scMain.SplitterDistance = 295;
			this.scMain.TabIndex = 2;
			// 
			// lvwWaypoints
			// 
			this.lvwWaypoints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnWaypointName,
            this.clnWaypointLat,
            this.clnWaypointLng});
			this.lvwWaypoints.ContextMenuStrip = this.cmsWaypoint;
			this.lvwWaypoints.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwWaypoints.FullRowSelect = true;
			this.lvwWaypoints.GridLines = true;
			this.lvwWaypoints.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwWaypoints.Location = new System.Drawing.Point(0, 0);
			this.lvwWaypoints.Name = "lvwWaypoints";
			this.lvwWaypoints.Size = new System.Drawing.Size(295, 388);
			this.lvwWaypoints.TabIndex = 0;
			this.lvwWaypoints.UseCompatibleStateImageBehavior = false;
			this.lvwWaypoints.View = System.Windows.Forms.View.Details;
			this.lvwWaypoints.VirtualMode = true;
			this.lvwWaypoints.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwWaypoints_RetrieveVirtualItem);
			// 
			// clnWaypointName
			// 
			this.clnWaypointName.Text = "Name";
			this.clnWaypointName.Width = 100;
			// 
			// clnWaypointLat
			// 
			this.clnWaypointLat.Text = "Latitude";
			this.clnWaypointLat.Width = 80;
			// 
			// clnWaypointLng
			// 
			this.clnWaypointLng.Text = "Longitude";
			this.clnWaypointLng.Width = 80;
			// 
			// cmsWaypoint
			// 
			this.cmsWaypoint.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsWaypointDetails,
            this.cmsWaypointCenter});
			this.cmsWaypoint.Name = "cmsWaypoint";
			this.cmsWaypoint.Size = new System.Drawing.Size(163, 70);
			// 
			// cmsWaypointDetails
			// 
			this.cmsWaypointDetails.Name = "cmsWaypointDetails";
			this.cmsWaypointDetails.Size = new System.Drawing.Size(162, 22);
			this.cmsWaypointDetails.Text = "Waypoint details";
			this.cmsWaypointDetails.Click += new System.EventHandler(this.mnuRouteWaypointDetails_Click);
			// 
			// tabRoute
			// 
			this.tabRoute.Controls.Add(this.tabMap);
			this.tabRoute.Controls.Add(this.tabLegs);
			this.tabRoute.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabRoute.Location = new System.Drawing.Point(0, 0);
			this.tabRoute.Name = "tabRoute";
			this.tabRoute.SelectedIndex = 0;
			this.tabRoute.Size = new System.Drawing.Size(526, 388);
			this.tabRoute.TabIndex = 1;
			// 
			// tabMap
			// 
			this.tabMap.Controls.Add(this.ehMapMain);
			this.tabMap.Location = new System.Drawing.Point(4, 22);
			this.tabMap.Name = "tabMap";
			this.tabMap.Padding = new System.Windows.Forms.Padding(3);
			this.tabMap.Size = new System.Drawing.Size(518, 362);
			this.tabMap.TabIndex = 0;
			this.tabMap.Text = "Map";
			this.tabMap.UseVisualStyleBackColor = true;
			// 
			// ehMapMain
			// 
			this.ehMapMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ehMapMain.Location = new System.Drawing.Point(3, 3);
			this.ehMapMain.Margin = new System.Windows.Forms.Padding(0);
			this.ehMapMain.Name = "ehMapMain";
			this.ehMapMain.Size = new System.Drawing.Size(512, 356);
			this.ehMapMain.TabIndex = 0;
			this.ehMapMain.Child = this.mapMain;
			// 
			// tabLegs
			// 
			this.tabLegs.Controls.Add(this.scLegs);
			this.tabLegs.Location = new System.Drawing.Point(4, 22);
			this.tabLegs.Name = "tabLegs";
			this.tabLegs.Padding = new System.Windows.Forms.Padding(3);
			this.tabLegs.Size = new System.Drawing.Size(518, 362);
			this.tabLegs.TabIndex = 1;
			this.tabLegs.Text = "Legs";
			this.tabLegs.UseVisualStyleBackColor = true;
			// 
			// scLegs
			// 
			this.scLegs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scLegs.Location = new System.Drawing.Point(3, 3);
			this.scLegs.Name = "scLegs";
			this.scLegs.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scLegs.Panel1
			// 
			this.scLegs.Panel1.Controls.Add(this.lvwLegs);
			// 
			// scLegs.Panel2
			// 
			this.scLegs.Panel2.Controls.Add(this.loLegOptions);
			this.scLegs.Size = new System.Drawing.Size(512, 356);
			this.scLegs.SplitterDistance = 120;
			this.scLegs.TabIndex = 2;
			// 
			// lvwLegs
			// 
			this.lvwLegs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnLegName,
            this.clnLegDistance,
            this.clnLegMC,
            this.clnLegMH,
            this.clnLegTime});
			this.lvwLegs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwLegs.FullRowSelect = true;
			this.lvwLegs.GridLines = true;
			this.lvwLegs.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwLegs.HideSelection = false;
			this.lvwLegs.Location = new System.Drawing.Point(0, 0);
			this.lvwLegs.Name = "lvwLegs";
			this.lvwLegs.Size = new System.Drawing.Size(512, 120);
			this.lvwLegs.TabIndex = 1;
			this.lvwLegs.UseCompatibleStateImageBehavior = false;
			this.lvwLegs.View = System.Windows.Forms.View.Details;
			this.lvwLegs.VirtualMode = true;
			this.lvwLegs.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwLegs_RetrieveVirtualItem);
			this.lvwLegs.SelectedIndexChanged += new System.EventHandler(this.lvwLegs_SelectedIndexChanged);
			// 
			// clnLegName
			// 
			this.clnLegName.Text = "Name";
			this.clnLegName.Width = 160;
			// 
			// clnLegDistance
			// 
			this.clnLegDistance.Text = "Distance";
			this.clnLegDistance.Width = 100;
			// 
			// clnLegMC
			// 
			this.clnLegMC.Text = "Magnetic Course";
			this.clnLegMC.Width = 130;
			// 
			// clnLegMH
			// 
			this.clnLegMH.Text = "Magnetic Heading";
			this.clnLegMH.Width = 130;
			// 
			// clnLegTime
			// 
			this.clnLegTime.Text = "Time";
			this.clnLegTime.Width = 130;
			// 
			// tsMain
			// 
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbSave,
            this.toolStripSeparator4,
            this.tsbRouteAddKnownWaypoint,
            this.tsbRouteAddFreeWaypoint,
            this.tsbRouteRemoveSelectedWaypoints,
            this.toolStripSeparator1,
            this.tsbWaypointUp,
            this.tsbWaypointDown,
            this.tsSep4,
            this.tsbMassAndBalance,
            this.tsSep8,
            this.tsbZoomIn,
            this.tsbZoomOut});
			this.tsMain.Location = new System.Drawing.Point(0, 24);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(825, 25);
			this.tsMain.TabIndex = 3;
			// 
			// tsbOpen
			// 
			this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbOpen.Image = global::FlightPlanner.UserInterface.Properties.Resources.Open;
			this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbOpen.Name = "tsbOpen";
			this.tsbOpen.Size = new System.Drawing.Size(23, 22);
			this.tsbOpen.Text = "toolStripButton1";
			this.tsbOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
			// 
			// tsbSave
			// 
			this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSave.Image = global::FlightPlanner.UserInterface.Properties.Resources.Save;
			this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSave.Name = "tsbSave";
			this.tsbSave.Size = new System.Drawing.Size(23, 22);
			this.tsbSave.Text = "toolStripButton2";
			this.tsbSave.Click += new System.EventHandler(this.mnuFileSave_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbRouteAddKnownWaypoint
			// 
			this.tsbRouteAddKnownWaypoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRouteAddKnownWaypoint.Image = global::FlightPlanner.UserInterface.Properties.Resources.Waypoint;
			this.tsbRouteAddKnownWaypoint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRouteAddKnownWaypoint.Name = "tsbRouteAddKnownWaypoint";
			this.tsbRouteAddKnownWaypoint.Size = new System.Drawing.Size(23, 22);
			this.tsbRouteAddKnownWaypoint.Text = "Add known waypoint";
			this.tsbRouteAddKnownWaypoint.Click += new System.EventHandler(this.mnuRouteWaypointAddKnown_Click);
			// 
			// tsbRouteAddFreeWaypoint
			// 
			this.tsbRouteAddFreeWaypoint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRouteAddFreeWaypoint.Image = global::FlightPlanner.UserInterface.Properties.Resources.Add;
			this.tsbRouteAddFreeWaypoint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRouteAddFreeWaypoint.Name = "tsbRouteAddFreeWaypoint";
			this.tsbRouteAddFreeWaypoint.Size = new System.Drawing.Size(23, 22);
			this.tsbRouteAddFreeWaypoint.Text = "Add free waypoint";
			this.tsbRouteAddFreeWaypoint.Click += new System.EventHandler(this.mnuRouteWaypointAddFree_Click);
			// 
			// tsbRouteRemoveSelectedWaypoints
			// 
			this.tsbRouteRemoveSelectedWaypoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRouteRemoveSelectedWaypoints.Image = global::FlightPlanner.UserInterface.Properties.Resources.Delete;
			this.tsbRouteRemoveSelectedWaypoints.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRouteRemoveSelectedWaypoints.Name = "tsbRouteRemoveSelectedWaypoints";
			this.tsbRouteRemoveSelectedWaypoints.Size = new System.Drawing.Size(23, 22);
			this.tsbRouteRemoveSelectedWaypoints.Text = "Remove selected waypoints";
			this.tsbRouteRemoveSelectedWaypoints.Click += new System.EventHandler(this.mnuRouteWaypointRemove_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbWaypointUp
			// 
			this.tsbWaypointUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbWaypointUp.Image = global::FlightPlanner.UserInterface.Properties.Resources.Up;
			this.tsbWaypointUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbWaypointUp.Name = "tsbWaypointUp";
			this.tsbWaypointUp.Size = new System.Drawing.Size(23, 22);
			this.tsbWaypointUp.Text = "Move selected waypoints up";
			this.tsbWaypointUp.Click += new System.EventHandler(this.mnuRouteWaypointsMoveUp_Click);
			// 
			// tsbWaypointDown
			// 
			this.tsbWaypointDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbWaypointDown.Image = global::FlightPlanner.UserInterface.Properties.Resources.Down;
			this.tsbWaypointDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbWaypointDown.Name = "tsbWaypointDown";
			this.tsbWaypointDown.Size = new System.Drawing.Size(23, 22);
			this.tsbWaypointDown.Text = "Move selected waypoints down";
			this.tsbWaypointDown.Click += new System.EventHandler(this.mnuRouteWaypointsMoveDown_Click);
			// 
			// tsSep4
			// 
			this.tsSep4.Name = "tsSep4";
			this.tsSep4.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbMassAndBalance
			// 
			this.tsbMassAndBalance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbMassAndBalance.Image = global::FlightPlanner.UserInterface.Properties.Resources.Loading;
			this.tsbMassAndBalance.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbMassAndBalance.Name = "tsbMassAndBalance";
			this.tsbMassAndBalance.Size = new System.Drawing.Size(23, 22);
			this.tsbMassAndBalance.Text = "Mass and balance";
			this.tsbMassAndBalance.Click += new System.EventHandler(this.mnuAircraftMassAndBalance_Click);
			// 
			// tsSep8
			// 
			this.tsSep8.Name = "tsSep8";
			this.tsSep8.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbZoomIn
			// 
			this.tsbZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomIn.Image")));
			this.tsbZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbZoomIn.Name = "tsbZoomIn";
			this.tsbZoomIn.Size = new System.Drawing.Size(23, 22);
			this.tsbZoomIn.Text = "Zoom In";
			this.tsbZoomIn.Click += new System.EventHandler(this.tsbZoomIn_Click);
			// 
			// tsbZoomOut
			// 
			this.tsbZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomOut.Image")));
			this.tsbZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbZoomOut.Name = "tsbZoomOut";
			this.tsbZoomOut.Size = new System.Drawing.Size(23, 22);
			this.tsbZoomOut.Text = "Zoom Out";
			this.tsbZoomOut.Click += new System.EventHandler(this.tsbZoomOut_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pgbProgress,
            this.tslStatus});
			this.statusStrip1.Location = new System.Drawing.Point(0, 443);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(825, 22);
			this.statusStrip1.TabIndex = 4;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// pgbProgress
			// 
			this.pgbProgress.Name = "pgbProgress";
			this.pgbProgress.Size = new System.Drawing.Size(100, 16);
			this.pgbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// tslStatus
			// 
			this.tslStatus.Name = "tslStatus";
			this.tslStatus.Size = new System.Drawing.Size(39, 17);
			this.tslStatus.Text = "Ready";
			// 
			// loLegOptions
			// 
			this.loLegOptions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.loLegOptions.Leg = null;
			this.loLegOptions.Location = new System.Drawing.Point(0, 0);
			this.loLegOptions.Name = "loLegOptions";
			this.loLegOptions.Size = new System.Drawing.Size(512, 232);
			this.loLegOptions.TabIndex = 0;
			// 
			// cmsWaypointCenter
			// 
			this.cmsWaypointCenter.Name = "cmsWaypointCenter";
			this.cmsWaypointCenter.Size = new System.Drawing.Size(162, 22);
			this.cmsWaypointCenter.Text = "Center";
			this.cmsWaypointCenter.Click += new System.EventHandler(this.cmsWaypointCenter_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(825, 465);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.tsMain);
			this.Controls.Add(this.scMain);
			this.Controls.Add(this.mnuMain);
			this.MainMenuStrip = this.mnuMain;
			this.MinimumSize = new System.Drawing.Size(790, 460);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Open Flight Planner";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.scMain.Panel1.ResumeLayout(false);
			this.scMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
			this.scMain.ResumeLayout(false);
			this.cmsWaypoint.ResumeLayout(false);
			this.tabRoute.ResumeLayout(false);
			this.tabMap.ResumeLayout(false);
			this.tabLegs.ResumeLayout(false);
			this.scLegs.Panel1.ResumeLayout(false);
			this.scLegs.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scLegs)).EndInit();
			this.scLegs.ResumeLayout(false);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Integration.ElementHost ehMapMain;
		private FlightPlanner.MapControl.Map mapMain;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.ListView lvwWaypoints;
        private System.Windows.Forms.ToolStripMenuItem mnuRoute;
        private System.Windows.Forms.ToolStripMenuItem mnuRouteWaypointAddFree;
        private System.Windows.Forms.ColumnHeader clnWaypointName;
        private System.Windows.Forms.ColumnHeader clnWaypointLat;
        private System.Windows.Forms.ColumnHeader clnWaypointLng;
        private System.Windows.Forms.TabControl tabRoute;
        private System.Windows.Forms.TabPage tabMap;
        private System.Windows.Forms.TabPage tabLegs;
        private System.Windows.Forms.ListView lvwLegs;
        private System.Windows.Forms.ColumnHeader clnLegName;
        private System.Windows.Forms.ColumnHeader clnLegDistance;
        private System.Windows.Forms.ColumnHeader clnLegMC;
        private System.Windows.Forms.ColumnHeader clnLegMH;
        private System.Windows.Forms.ToolStripMenuItem mnuRouteWaypointAddKnown;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbRouteRemoveSelectedWaypoints;
        private System.Windows.Forms.SplitContainer scLegs;
        private Controls.LegOptionsControl loLegOptions;
        private System.Windows.Forms.ToolStripSeparator tsSep1;
        private System.Windows.Forms.ToolStripMenuItem mnuRouteWaypointsRemove;
        private System.Windows.Forms.ToolStripMenuItem mnuAircraft;
        private System.Windows.Forms.ToolStripMenuItem mnuAircraftManage;
        private System.Windows.Forms.ToolStripSeparator tsSep2;
        private System.Windows.Forms.ToolStripMenuItem mnuRouteGlobalSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSettings;
        private System.Windows.Forms.ToolStripSeparator tsSep3;
        private System.Windows.Forms.ToolStripSeparator tsSep4;
        private System.Windows.Forms.ToolStripButton tsbZoomIn;
        private System.Windows.Forms.ToolStripButton tsbZoomOut;
        private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
        private System.Windows.Forms.ToolStripSeparator tsSep6;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator tsSep5;
        private System.Windows.Forms.ToolStripMenuItem mnuAircraftMassAndBalance;
        private System.Windows.Forms.ToolStripSeparator tsSep7;
        private System.Windows.Forms.ToolStripButton tsbMassAndBalance;
        private System.Windows.Forms.ToolStripSeparator tsSep8;
        private System.Windows.Forms.ToolStripButton tsbWaypointUp;
        private System.Windows.Forms.ToolStripButton tsbWaypointDown;
        private System.Windows.Forms.ToolStripMenuItem mnuRouteWaypointsMoveUp;
        private System.Windows.Forms.ToolStripMenuItem mnuRouteWaypointsMoveDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem mnuInfo;
		private System.Windows.Forms.ToolStripMenuItem mnuInfoAbout;
		private System.Windows.Forms.ToolStripMenuItem mnuBriefing;
		private System.Windows.Forms.ToolStripMenuItem mnuBriefingWeather;
		private System.Windows.Forms.ToolStripMenuItem mnuBriefingNotams;
		private System.Windows.Forms.ToolStripMenuItem mnuRouteUpperWind;
		private System.Windows.Forms.ToolStripButton tsbRouteAddKnownWaypoint;
		private System.Windows.Forms.ToolStripButton tsbRouteAddFreeWaypoint;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.SaveFileDialog sfdSave;
		private System.Windows.Forms.OpenFileDialog ofdOpen;
		private System.Windows.Forms.ToolStripMenuItem mnuFileNew;
		private System.Windows.Forms.ToolStripButton tsbOpen;
		private System.Windows.Forms.ToolStripButton tsbSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel tslStatus;
		private System.Windows.Forms.ToolStripProgressBar pgbProgress;
		private System.Windows.Forms.ToolStripMenuItem mnuBriefingExport;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem mnuRouteExport;
		private System.Windows.Forms.ToolStripMenuItem mnuRouteExportGPX;
		private System.Windows.Forms.ToolStripMenuItem mnuRouteExportKML;
		private System.Windows.Forms.ToolStripMenuItem mnuRouteExportWaypointPlus;
		private System.Windows.Forms.ColumnHeader clnLegTime;
		private System.Windows.Forms.ToolStripSeparator tsSep9;
		private System.Windows.Forms.ToolStripMenuItem mnuRouteWaypointDetails;
		private System.Windows.Forms.ContextMenuStrip cmsWaypoint;
		private System.Windows.Forms.ToolStripMenuItem cmsWaypointDetails;
		private System.Windows.Forms.ToolStripMenuItem cmsWaypointCenter;
	}
}

