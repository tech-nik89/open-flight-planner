using FlightPlanner.Briefing;
using FlightPlanner.Notams;
using FlightPlanner.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Dialogs {
	public partial class NotamsForm : Form {

		private readonly BackgroundWorker _BriefingWorker;
		private readonly FlightPlan _FlightPlan;
		private List<Notam> _Notams;

		public NotamsForm(FlightPlan flightPlan) {
			InitializeComponent();
			InitializeIcon();
			ApplyLocalization();

			_FlightPlan = flightPlan;
			_BriefingWorker = new BackgroundWorker();
		}

		private void InitializeIcon() {
			Bitmap bitmap = UserInterface.Properties.Resources.Notams;
			Icon = Icon.FromHandle(bitmap.GetHicon());
		}

		private void ApplyLocalization() {
			Text = Strings.Notams;
			clnNumber.Text = Strings.Number;
			clnArea.Text = Strings.Area;
			clnYear.Text = Strings.Year;
			clnText.Text = Strings.Text;
		}

		private void NotamsForm_Shown(object sender, EventArgs e) {
			if (PluginManager.NotamSource == null) {
				String message = String.Format(Strings.PluginNotConfigured, Strings.Notams);
				MessageBox.Show(message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			_BriefingWorker.DoWork += BriefingWorker_DoWork;
			_BriefingWorker.RunWorkerCompleted += BriefingWorker_RunWorkerCompleted;

			tslStatus.Text = Strings.Loading;
			_BriefingWorker.RunWorkerAsync();
		}

		private void BriefingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			lvwNotams.Items.Clear();
			tslStatus.Text = Strings.Completed;

			if (_Notams == null || _Notams.Count == 0) {
				return;
			}

			foreach (Notam notam in _Notams) {
				String[] cells = new String[] {
					notam.Number,
					notam.Area,
					notam.Year.Year.ToString(),
					notam.Text
				};

				ListViewItem item = new ListViewItem(cells);
				item.ToolTipText = notam.Text;
				lvwNotams.Items.Add(item);
			}
		}

		private void BriefingWorker_DoWork(object sender, DoWorkEventArgs e) {
			_Notams = PluginManager.NotamSource.GetNotams(_FlightPlan);
		}

		private void lvwNotams_SelectedIndexChanged(object sender, EventArgs e) {
			if (lvwNotams.SelectedIndices.Count == 0) {
				txtNotam.Text = String.Empty;
				return;
			}
			
			txtNotam.Text = _Notams[lvwNotams.SelectedIndices[0]].Text.Replace("\n", "\r\n");
		}
	}
}
