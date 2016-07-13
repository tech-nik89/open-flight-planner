using FlightPlanner.Aircrafts;
using FlightPlanner.Briefing;
using FlightPlanner.Configuration;
using System;
using System.Windows.Forms;

namespace FlightPlanner.UserInterface.Dialogs {
    public partial class ManageAircraftsForm : Form {

        private readonly FlightPlan _FlightPlan;

        public ManageAircraftsForm(FlightPlan flightPlan) {
            InitializeComponent();
			ApplyLocalization();

            _FlightPlan = flightPlan;
            UpdateList();
        }

		private void ApplyLocalization() {
			Text = Strings.AircraftsManage;

			tsbAdd.Text = Strings.Add;
			tsbEdit.Text = Strings.Edit;
			tsbRemove.Text = Strings.Remove;
			tsbUse.Text = Strings.UseAircraft;

			clnRegistration.Text = Strings.Registration;
			clnType.Text = Strings.Type;
		}

		private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void UpdateList() {
            lvwAircrafts.VirtualListSize = 0;
            lvwAircrafts.VirtualListSize = Config.Current.Aircrafts.Count;
        }

        private void lvwAircrafts_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            Aircraft aircraft = Config.Current.Aircrafts[e.ItemIndex];

            String[] fields = new String[] {
                aircraft.Registration,
                aircraft.Type
            };

            e.Item = new ListViewItem(fields);
        }

        private void tsbAdd_Click(object sender, EventArgs e) {
            AircraftForm form = new AircraftForm();
            DialogResult result = form.ShowDialog();

            if (result != DialogResult.OK) {
                return;
            }

            Config.Current.Aircrafts.Add(form.Aircraft);
            UpdateList();
            Config.Save();
        }

        private void tsbRemove_Click(object sender, EventArgs e) {
            if (lvwAircrafts.SelectedIndices.Count == 0) {
                return;
            }

            DialogResult result = MessageBox.Show("Do you really want to remove the selected aircraft?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) {
                return;
            }

            Config.Current.Aircrafts.RemoveAt(lvwAircrafts.SelectedIndices[0]);
            UpdateList();
            Config.Save();
        }

        private void tsbEdit_Click(object sender, EventArgs e) {
            if (lvwAircrafts.SelectedIndices.Count == 0) {
                return;
            }

            AircraftForm form = new AircraftForm(Config.Current.Aircrafts[lvwAircrafts.SelectedIndices[0]]);
            DialogResult result = form.ShowDialog();

            if (result != DialogResult.OK) {
                return;
            }

            UpdateList();
            Config.Save();
        }

        private void lvwAircrafts_MouseDoubleClick(object sender, MouseEventArgs e) {
            tsbEdit_Click(sender, e);
        }

        private void tsbUse_Click(object sender, EventArgs e) {
            if (lvwAircrafts.SelectedIndices.Count == 0) {
                return;
            }

            _FlightPlan.Aircraft = Config.Current.Aircrafts[lvwAircrafts.SelectedIndices[0]];
            Close();
        }
    }
}
